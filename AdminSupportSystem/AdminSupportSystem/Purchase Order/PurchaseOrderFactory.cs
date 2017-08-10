using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Net.Mail;
using SQL;
using UDT;

namespace BOL
{
    public class PurchaseOrderFactory
    {
        /// <summary>
        /// Concstuctor for PurchaseOrderFactory
        /// </summary>
        private PurchaseOrderFactory() { }

        /// <summary>
        /// Create function that returns a PurchaseOrder
        /// </summary>
        /// <returns></returns>
        public static PurchaseOrder Create()
        {
            return new PurchaseOrder();
        }

        /// <summary>
        /// Create function that returns a list of PurchaseOrders
        /// </summary>
        /// <returns></returns>
        public static List<PurchaseOrder> CreateList()
        {
            return new List<PurchaseOrder>();
        }

        /// <summary>
        /// Create function that returns a list of OrdersForProcessing
        /// </summary>
        /// <returns></returns>
        public static List<OrdersForProcessing> CreateListForProcessing()
        {
            return new List<OrdersForProcessing>();
        }

        /// <summary>
        /// Submit function that inserts a newly created PurchaseOrder full of items
        /// </summary>
        /// <param name="tmpPurchaseOrder"></param>
        /// <returns></returns>
        public static int Submit(PurchaseOrder tmpPurchaseOrder)
        {
            tmpPurchaseOrder.OrderNumber = PurchaseOrderSQL.SubmitPurchaseOrder(tmpPurchaseOrder);
            return tmpPurchaseOrder.OrderNumber;
        }

        /// <summary>
        /// Remove function that deletes a PurchaseOrder
        /// </summary>
        /// <param name="orderNumber"></param>
        /// <returns></returns>
        public static bool EmployeeRemoveOrder(int orderNumber)
        {
            return PurchaseOrderSQL.EmployeeRemoveOrder(orderNumber);
        }

        /// <summary>
        /// Update function that updates a PurchaseOrder's totals after Items have been added or modified
        /// </summary>
        /// <param name="tmpOrder"></param>
        /// <returns></returns>
        public static bool EmployeeUpdateTotals(PurchaseOrder tmpOrder)
        {
            return PurchaseOrderSQL.EmployeeUpdateTotals(tmpOrder);
        }

        /// <summary>
        /// Email function that send a message to an Employee once their Purchase Order has been closed. Includes information for all items on the Purchase Order
        /// </summary>
        /// <param name="employeeId"></param>
        /// <param name="email"></param>
        /// <param name="orderNumber"></param>
        /// <param name="total"></param>
        /// <param name="itemList"></param>
        public static void EmailEmployee(int employeeId, string email, int orderNumber, double total, List<Item> itemList)
        {
            string itemInformation = "";

            foreach (Item item in itemList)
            {
                itemInformation += "<b>Item Name: </b>" + item.Name + "<br><b>Item Status: </b>" + item.Status + "<br><br><br>";
            }

            MailMessage Mail = new MailMessage();
            Mail.To.Add(email);
            Mail.From = new MailAddress("orders@gearworks.com");
            Mail.Subject = "Purchase order #" + orderNumber.ToString() + " has been processed";
            Mail.Body = ("Hello,<br><br> This is a notice from GearWorks that your purchase order # " + orderNumber.ToString() +
                " has been processed by your supervisor on " + DateTime.Now.ToShortDateString() + ". Below is a summary of the " +
                "items that you have requested and the decisions that were made on each item by your supervisor.<br><br><br>" +
                itemInformation + "<br>The total cost of your purchase order is " + total.ToString("C") + "<br><br>Thank you for " +
                "placing your order through the GearWorks Admin Support System. You can view the full result of this order on our " +
                "website at this link: <a href='http://localhost:9089/ViewProcessedOrder.aspx?employeeId=" + employeeId + "&orderNumber=" + orderNumber +
                "'>GearWorks Online Admin Support System</a><br><br>Have a great day.");
            Mail.IsBodyHtml = true;

            SmtpClient client = new SmtpClient();
            client.Port = 25;
            client.EnableSsl = false;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = true;
            client.Host = "localhost";
            client.Send(Mail);
        }

        /// <summary>
        /// Retrieves a PurchaseOrder based on its OrderNumber and the EmployeeId of the Employee that created it
        /// </summary>
        /// <param name="OrderNumber"></param>
        /// <param name="EmployeeId"></param>
        /// <returns></returns>
        public static PurchaseOrder RetrieveByNumber(int OrderNumber, int EmployeeId)
        {
            DataTable tmpTable = PurchaseOrderSQL.RetrieveOrdersByNumber(OrderNumber, EmployeeId);
            return Repackager(tmpTable);
        }

        /// <summary>
        /// Retrieves a PurchaseOrder based on its OrderNumber. The Supervisor is able to retrieve all PurchaseOrders in their department
        /// </summary>
        /// <param name="OrderNumber"></param>
        /// <param name="EmployeeId"></param>
        /// <returns></returns>
        public static PurchaseOrder RetrieveByNumberSupervisor(int OrderNumber, int EmployeeId)
        {
            DataTable tmpTable = PurchaseOrderSQL.RetrieveOrdersByNumberSupervisor(OrderNumber, EmployeeId);
            return Repackager(tmpTable);
        }

        /// <summary>
        /// Retrieves a list of PurchaseOrders based on a specified date range and a filter parameter for status for the specified Employee
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        public static List<PurchaseOrder> RetrieveByOther(DateTime startDate, DateTime endDate, int employeeId, string filter)
        {
            DataTable tmpTable = PurchaseOrderSQL.RetrieveOrdersByOther(startDate, endDate, employeeId, filter);
            return RepackagerList(tmpTable);
        }

        /// <summary>
        /// Retrieves a list of PurchaseOrders based on a specified date range and a filter parameter for status. Supervisor's ID is entered to retrieve all PurchaseOrders for all Employee's in their Department
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        public static List<PurchaseOrder> RetrieveByOtherSupervisor(DateTime startDate, DateTime endDate, int employeeId, string filter, string employeeName)
        {
            DataTable tmpTable = PurchaseOrderSQL.RetrieveOrdersByOtherSupervisor(startDate, endDate, employeeId, filter, employeeName);
            return RepackagerList(tmpTable);
        }

        /// <summary>
        /// Retrieves a list of OrdersForProcessing based on a specefied date range and a filter parameter for status. Supervisor's ID is entered to retrieve all PurchaseOrders for all Employee's in their Department
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="employeeId"></param>
        /// <param name="filter"></param>
        /// <param name="employeeName"></param>
        /// <returns></returns>
        public static List<OrdersForProcessing> RetrieveOrdersForProcessing(DateTime startDate, DateTime endDate, int employeeId, string filter, string employeeName, string accessLevel)
        {
            DataTable tmpTable = PurchaseOrderSQL.RetrieveOrdersForProcessing(startDate, endDate, employeeId, filter, employeeName, accessLevel);
            return RepackagerListProcessing(tmpTable);
        }

        /// <summary>
        /// Sets a Purchase Order's status to Pending
        /// </summary>
        /// <param name="tmpOrder"></param>
        /// <returns></returns>
        public static bool UpdateStatusToPending(PurchaseOrder tmpOrder)
        {
            return PurchaseOrderSQL.UpdateStatusToPending(tmpOrder);
        }

        /// <summary>
        /// Sets a Purchase Order's status to Closed
        /// </summary>
        /// <param name="tmpOrder"></param>
        /// <returns></returns>
        public static bool ClosePurchaseOrder(PurchaseOrder tmpOrder)
        {
            return PurchaseOrderSQL.ClosePurchaseOrder(tmpOrder);
        }

        /// <summary>
        /// Repackager for a PurchaseOrder. Accepts a DataTable and returns a PurchaseOrder
        /// </summary>
        /// <param name="tmpTable"></param>
        /// <returns></returns>
        private static PurchaseOrder Repackager(DataTable tmpTable)
        {   
            PurchaseOrder tmpOrder = new PurchaseOrder();

            if (tmpTable.Rows.Count > 0)
            {
                tmpOrder.OrderNumber = Convert.ToInt32(tmpTable.Rows[0]["orderNumber"]);
                tmpOrder.OrderDate = Convert.ToDateTime(tmpTable.Rows[0]["orderDate"]);
                tmpOrder.Status = tmpTable.Rows[0]["status"].ToString();
                tmpOrder.Subtotal = Convert.ToDouble(tmpTable.Rows[0]["subtotal"]);
                tmpOrder.Taxes = Convert.ToDouble(tmpTable.Rows[0]["taxes"]);
                tmpOrder.Total = Convert.ToDouble(tmpTable.Rows[0]["total"]);

                return tmpOrder;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Repackager for a list of Purchase Orders. Accepts a DataTable and returns a list of PurchaseOrders
        /// </summary>
        /// <param name="tmpTable"></param>
        /// <returns></returns>
        private static List<PurchaseOrder> RepackagerList(DataTable tmpTable)
        {
            List<PurchaseOrder> tmpList = new List<PurchaseOrder>();

            for (int i = 0; i < tmpTable.Rows.Count; i++)
            {
                PurchaseOrder tmpOrder = new PurchaseOrder();
                tmpOrder.OrderNumber = Convert.ToInt32(tmpTable.Rows[i]["orderNumber"]);
                tmpOrder.OrderDate = Convert.ToDateTime(tmpTable.Rows[i]["orderDate"]);
                tmpOrder.Status = tmpTable.Rows[i]["status"].ToString();
                tmpOrder.Subtotal = Convert.ToDouble(tmpTable.Rows[i]["subtotal"]);
                tmpOrder.Taxes = Convert.ToDouble(tmpTable.Rows[i]["taxes"]);
                tmpOrder.Total = Convert.ToDouble(tmpTable.Rows[i]["total"]);

                tmpList.Add(tmpOrder);
            }

            return tmpList;
        }

        /// <summary>
        /// Repackager for a list of Purchase Orders for processing. Accepts a DataTable and returns a list of OrdersForProcessing
        /// </summary>
        /// <param name="tmpTable"></param>
        /// <returns></returns>
        private static List<OrdersForProcessing> RepackagerListProcessing(DataTable tmpTable)
        {
            List<OrdersForProcessing> tmpList = new List<OrdersForProcessing>();

            for (int i = 0; i < tmpTable.Rows.Count; i++)
            {
                OrdersForProcessing tmpOrder = new OrdersForProcessing();
                tmpOrder.OrderNumber = Convert.ToInt32(tmpTable.Rows[i]["orderNumber"]);
                tmpOrder.OrderDate = Convert.ToDateTime(tmpTable.Rows[i]["orderDate"]);
                tmpOrder.EmployeeName = tmpTable.Rows[i]["employeeName"].ToString();
                tmpOrder.Total = Convert.ToDouble(tmpTable.Rows[i]["total"]);
                tmpOrder.Status = tmpTable.Rows[i]["status"].ToString();

                tmpList.Add(tmpOrder);
            }

            return tmpList;
        }
    }
}
