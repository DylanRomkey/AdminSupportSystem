using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DALvb;
using UDT;

namespace SQL
{
    public class PurchaseOrderSQL
    {
        /// <summary>
        /// Retrieves a PurchaseOrder based on it's OrderNumber and the ID of the Employee that created it. Returns a DataTable
        /// </summary>
        /// <param name="orderNumber"></param>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        public static DataTable RetrieveOrdersByNumber(int orderNumber, int employeeId)
        {
            string sql = "spRetrieveOrderByNumber";
            List<parmStructure> myparms = new List<parmStructure>();

            myparms.Add(new parmStructure("@OrderNumber", orderNumber, ParameterDirection.Input, SqlDbType.Int));
            myparms.Add(new parmStructure("@EmployeeId", employeeId, ParameterDirection.Input, SqlDbType.Int));

            return DataAccess.GetData(sql, myparms);
        }

        /// <summary>
        /// Retrieves a PurchaseOrder based on it's OrderNumber. The Supervisor's ID is supplied to search PurchaseOrders for all Employee's in their Department
        /// </summary>
        /// <param name="orderNumber"></param>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        public static DataTable RetrieveOrdersByNumberSupervisor(int orderNumber, int employeeId)
        {
            string sql = "spRetrieveOrderByNumberSupervisor";
            List<parmStructure> myparms = new List<parmStructure>();

            myparms.Add(new parmStructure("@OrderNumber", orderNumber, ParameterDirection.Input, SqlDbType.Int));
            myparms.Add(new parmStructure("@EmployeeId", employeeId, ParameterDirection.Input, SqlDbType.Int));

            return DataAccess.GetData(sql, myparms);
        }

        /// <summary>
        /// Retrieves a list of PurchaseOrders based on a date range and the ID of the Employee that created them. Returns a DataTable
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        public static DataTable RetrieveOrdersByOther(DateTime startDate, DateTime endDate, int employeeId, string filter)
        {
            string sql = "spRetrieveOrderByOther";
            List<parmStructure> myparms = new List<parmStructure>();

            if (startDate == DateTime.MinValue)
            {
                myparms.Add(new parmStructure("@StartDate", DBNull.Value, ParameterDirection.Input, SqlDbType.DateTime));
            }
            else
            {
                myparms.Add(new parmStructure("@StartDate", startDate, ParameterDirection.Input, SqlDbType.DateTime));
            }

            if (endDate == DateTime.MinValue)
            {
                myparms.Add(new parmStructure("@EndDate", DBNull.Value, ParameterDirection.Input, SqlDbType.DateTime));
            }
            else
            {
                myparms.Add(new parmStructure("@EndDate", endDate, ParameterDirection.Input, SqlDbType.DateTime));
            }

            myparms.Add(new parmStructure("@EmployeeId", employeeId, ParameterDirection.Input, SqlDbType.Int));

            if (filter.Equals("A"))
            {
                myparms.Add(new parmStructure("@Filter", "A", ParameterDirection.Input, SqlDbType.Char, 1));
            }
            else if (filter.Equals("P"))
            {
                myparms.Add(new parmStructure("@Filter", "P", ParameterDirection.Input, SqlDbType.Char, 1));
            }
            else if (filter.Equals("C"))
            {
                myparms.Add(new parmStructure("@Filter", "C", ParameterDirection.Input, SqlDbType.Char, 1));
            }

            return DataAccess.GetData(sql, myparms);
        }

        /// <summary>
        /// Retrieves a list of PurchaseOrders based on a date range. The Supervisor's ID is supplied to search PurchaseOrders for all Employee's in their Department
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        public static DataTable RetrieveOrdersByOtherSupervisor(DateTime startDate, DateTime endDate, int employeeId, string filter, string employeeName)
        {
            string sql = "spRetrieveOrderByOtherSupervisor";
            List<parmStructure> myparms = new List<parmStructure>();

            if (startDate == DateTime.MinValue)
            {
                myparms.Add(new parmStructure("@StartDate", DBNull.Value, ParameterDirection.Input, SqlDbType.DateTime));
            }
            else
            {
                myparms.Add(new parmStructure("@StartDate", startDate, ParameterDirection.Input, SqlDbType.DateTime));
            }

            if (endDate == DateTime.MinValue)
            {
                myparms.Add(new parmStructure("@EndDate", DBNull.Value, ParameterDirection.Input, SqlDbType.DateTime));
            }
            else
            {
                myparms.Add(new parmStructure("@EndDate", endDate, ParameterDirection.Input, SqlDbType.DateTime));
            }

            myparms.Add(new parmStructure("@EmployeeId", employeeId, ParameterDirection.Input, SqlDbType.Int));

            if (filter.Equals("A"))
            {
                myparms.Add(new parmStructure("@Filter", "A", ParameterDirection.Input, SqlDbType.Char, 1));
            }
            else if (filter.Equals("P"))
            {
                myparms.Add(new parmStructure("@Filter", "P", ParameterDirection.Input, SqlDbType.Char, 1));
            }
            else if (filter.Equals("C"))
            {
                myparms.Add(new parmStructure("@Filter", "C", ParameterDirection.Input, SqlDbType.Char, 1));
            }

            if (employeeName != null)
            {
                myparms.Add(new parmStructure("@Name", employeeName, ParameterDirection.Input, SqlDbType.VarChar, 100));
            }
            else
            {
                myparms.Add(new parmStructure("@Name", DBNull.Value, ParameterDirection.Input, SqlDbType.VarChar, 100));
            }

            return DataAccess.GetData(sql, myparms);
        }

        /// <summary>
        /// Retrieves PurchaseOrders for processing. Supervisor is able to retrieve all PurchaseOrders in their department
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="employeeId"></param>
        /// <param name="filter"></param>
        /// <param name="employeeName"></param>
        /// <returns></returns>
        public static DataTable RetrieveOrdersForProcessing (DateTime startDate, DateTime endDate, int employeeId, string filter, string employeeName, string accessLevel)
        {
            string sql = "";
            if (accessLevel.Equals("C"))
            {
                sql = "spRetrieveOrdersForProcessingCEO";
            }
            else
            {
                sql = "spRetrieveOrdersForProcessing";
            }
            
            List<parmStructure> myparms = new List<parmStructure>();

            if (startDate == DateTime.MinValue)
            {
                myparms.Add(new parmStructure("@StartDate", DBNull.Value, ParameterDirection.Input, SqlDbType.DateTime));
            }
            else
            {
                myparms.Add(new parmStructure("@StartDate", startDate, ParameterDirection.Input, SqlDbType.DateTime));
            }

            if (endDate == DateTime.MinValue)
            {
                myparms.Add(new parmStructure("@EndDate", DBNull.Value, ParameterDirection.Input, SqlDbType.DateTime));
            }
            else
            {
                myparms.Add(new parmStructure("@EndDate", endDate, ParameterDirection.Input, SqlDbType.DateTime));
            }

            myparms.Add(new parmStructure("@EmployeeId", employeeId, ParameterDirection.Input, SqlDbType.Int));

            if (filter.Equals("A"))
            {
                myparms.Add(new parmStructure("@Filter", "A", ParameterDirection.Input, SqlDbType.Char, 1));
            }
            else if (filter.Equals("P"))
            {
                myparms.Add(new parmStructure("@Filter", "P", ParameterDirection.Input, SqlDbType.Char, 1));
            }
            else if (filter.Equals("C"))
            {
                myparms.Add(new parmStructure("@Filter", "C", ParameterDirection.Input, SqlDbType.Char, 1));
            }

            if (employeeName != null)
            {
                myparms.Add(new parmStructure("@Name", employeeName, ParameterDirection.Input, SqlDbType.VarChar, 100));
            }
            else
            {
                myparms.Add(new parmStructure("@Name", DBNull.Value, ParameterDirection.Input, SqlDbType.VarChar, 100));
            }

            return DataAccess.GetData(sql, myparms);
        }

        /// <summary>
        /// Retrieves a specified PurchaseOrder's information based on it's OrderNumber. Returns a DataTable
        /// </summary>
        /// <param name="orderNumber"></param>
        /// <returns></returns>
        public static DataTable RetrieveOrderDetails(int orderNumber)
        {
            string sql = "spRetrieveOrderDetails";
            List<parmStructure> myparms = new List<parmStructure>();

            myparms.Add(new parmStructure("@OrderNumber", orderNumber, ParameterDirection.Input, SqlDbType.Int));

            return DataAccess.GetData(sql, myparms);
        }

        /// <summary>
        /// Submits a newly created PurchaseOrder containing a list of Items to the database. Returns the newly created OrderNumber 
        /// </summary>
        /// <param name="tmpPurchaseOrder"></param>
        /// <returns></returns>
        public static int SubmitPurchaseOrder(IPurchaseOrder tmpPurchaseOrder)
        {
            string sql = "spSubmitPurchaseOrder";
            List<parmStructure> myparms = new List<parmStructure>();

            myparms.Add(new parmStructure("@OrderNumber", 0, ParameterDirection.Output, SqlDbType.Int));
            myparms.Add(new parmStructure("@OrderDate", tmpPurchaseOrder.OrderDate, ParameterDirection.Input, SqlDbType.DateTime));
            myparms.Add(new parmStructure("@Status", tmpPurchaseOrder.Status, ParameterDirection.Input, SqlDbType.NVarChar, 50));
            myparms.Add(new parmStructure("@Subtotal", tmpPurchaseOrder.Subtotal, ParameterDirection.Input, SqlDbType.Money));
            myparms.Add(new parmStructure("@Taxes", tmpPurchaseOrder.Taxes, ParameterDirection.Input, SqlDbType.Money));
            myparms.Add(new parmStructure("@Total", tmpPurchaseOrder.Total, ParameterDirection.Input, SqlDbType.Money));
            myparms.Add(new parmStructure("@EmployeeId", tmpPurchaseOrder.EmployeeId, ParameterDirection.Input, SqlDbType.Int));

            DataTable workTable = new DataTable("items");
            DataColumn Name = workTable.Columns.Add("Name", Type.GetType("System.String"));
            DataColumn Description = workTable.Columns.Add("Description", Type.GetType("System.String"));
            DataColumn Price = workTable.Columns.Add("Price", Type.GetType("System.Double"));
            DataColumn PurchaseLocation = workTable.Columns.Add("PurchaseLocation", Type.GetType("System.String"));
            DataColumn Quantity = workTable.Columns.Add("Quantity", Type.GetType("System.Int16"));
            DataColumn Justification = workTable.Columns.Add("Justification", Type.GetType("System.String"));
            DataColumn Status = workTable.Columns.Add("Status", Type.GetType("System.String"));
            DataColumn Subtotal = workTable.Columns.Add("Subtotal", Type.GetType("System.Double"));

            for (int i = 0; i < tmpPurchaseOrder.PurchaseOrderItemList.Count; i++)
            {
                workTable.Rows.Add(new Object[] {
                    tmpPurchaseOrder.PurchaseOrderItemList[i].Name,
                    tmpPurchaseOrder.PurchaseOrderItemList[i].Description,
                    tmpPurchaseOrder.PurchaseOrderItemList[i].Price,
                    tmpPurchaseOrder.PurchaseOrderItemList[i].PurchaseLocation,
                    tmpPurchaseOrder.PurchaseOrderItemList[i].Quantity,
                    tmpPurchaseOrder.PurchaseOrderItemList[i].Justification,
                    tmpPurchaseOrder.PurchaseOrderItemList[i].Status,
                    tmpPurchaseOrder.PurchaseOrderItemList[i].Subtotal
                });
            }

            myparms.Add(new parmStructure("@OrderDetail", workTable, ParameterDirection.Input, SqlDbType.Structured));

            DataAccess.SendData(sql, myparms);
            return Convert.ToInt32(myparms[0].parmValue);
        }

        /// <summary>
        /// Removes a PurchaseOrder based on it's OrderNumber from the Database after all of it's Items have been removed. Returns a Boolean
        /// </summary>
        /// <param name="orderNumber"></param>
        /// <returns></returns>
        public static bool EmployeeRemoveOrder(int orderNumber)
        {
            string sql = "spEmployeeRemoveOrder";
            List<parmStructure> myparms = new List<parmStructure>();

            myparms.Add(new parmStructure("@OrderNumber", orderNumber, ParameterDirection.Input, SqlDbType.Int));

            DataAccess.SendData(sql, myparms);
            return true;
        }

        /// <summary>
        /// Updates the totals of a specified Purchase Order. Accepts the entire PurchaseOrder and returns a boolean
        /// </summary>
        /// <param name="tmpOrder"></param>
        /// <returns></returns>
        public static bool EmployeeUpdateTotals(IPurchaseOrder tmpOrder)
        {
            string sql = "spEmployeeUpdateTotals";
            List<parmStructure> myparms = new List<parmStructure>();

            myparms.Add(new parmStructure("@OrderNumber", tmpOrder.OrderNumber, ParameterDirection.Input, SqlDbType.Int));
            myparms.Add(new parmStructure("@OrderSubtotal", tmpOrder.Subtotal, ParameterDirection.Input, SqlDbType.VarChar, 100));
            myparms.Add(new parmStructure("@OrderTaxes", tmpOrder.Taxes, ParameterDirection.Input, SqlDbType.VarChar, 200));
            myparms.Add(new parmStructure("@OrderTotal", tmpOrder.Total, ParameterDirection.Input, SqlDbType.Money));        

            DataAccess.SendData(sql, myparms);
            return true;
        }

        /// <summary>
        /// Updates a Purchase Order's status to Pending
        /// </summary>
        /// <param name="tmpOrder"></param>
        /// <returns></returns>
        public static bool UpdateStatusToPending(IPurchaseOrder tmpOrder)
        {
            string sql = "spUpdateOrderStatusToPending";
            List<parmStructure> myparms = new List<parmStructure>();

            myparms.Add(new parmStructure("@OrderNumber", tmpOrder.OrderNumber, ParameterDirection.Input, SqlDbType.Int));

            DataAccess.SendData(sql, myparms);
            return true;
        }

        /// <summary>
        /// Updates a Purchase Order's status to Closed
        /// </summary>
        /// <param name="tmpOrder"></param>
        /// <returns></returns>
        public static bool ClosePurchaseOrder(IPurchaseOrder tmpOrder)
        {
            string sql = "spClosePurchaseOrder";
            List<parmStructure> myparms = new List<parmStructure>();

            myparms.Add(new parmStructure("@OrderNumber", tmpOrder.OrderNumber, ParameterDirection.Input, SqlDbType.Int));

            DataAccess.SendData(sql, myparms);
            return true;
        }
    }
}
