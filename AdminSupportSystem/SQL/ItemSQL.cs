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
    public class ItemSQL
    {
        /// <summary>
        /// Retrieves a single Item's information based on its ItemId and returns a DataTable
        /// </summary>
        /// <param name="itemId"></param>
        /// <returns></returns>
        public static DataTable RetrieveItemById(int itemId)
        {
            string sql = "spRetrieveItemById";
            List<parmStructure> myparms = new List<parmStructure>();

            myparms.Add(new parmStructure("@ItemId", itemId, ParameterDirection.Input, SqlDbType.Int));

            return DataAccess.GetData(sql, myparms);
        }

        /// <summary>
        /// Retrieves a list of Items that are on a specified PurchaseOrder. Accepts the OrderNumber and returns a DataTable
        /// </summary>
        /// <param name="orderNumber"></param>
        /// <returns></returns>
        public static DataTable RetrieveOrderItems(int orderNumber)
        {
            string sql = "spRetrieveOrderItems";
            List<parmStructure> myparms = new List<parmStructure>();

            myparms.Add(new parmStructure("@OrderNumber", orderNumber, ParameterDirection.Input, SqlDbType.Int));

            return DataAccess.GetData(sql, myparms);
        }

        /// <summary>
        /// Modifies a specified Item's information. Accepts the entire Item and the PurchaseOrder that it belongs to and returns a boolean
        /// </summary>
        /// <param name="tmpItem"></param>
        /// <param name="tmpOrder"></param>
        /// <returns></returns>
        public static bool EmployeeModifyItem(IItem tmpItem)
        {
            string sql = "spEmployeeModifyItem";
            List<parmStructure> myparms = new List<parmStructure>();

            myparms.Add(new parmStructure("@ItemId", tmpItem.ItemId, ParameterDirection.Input, SqlDbType.Int));
            myparms.Add(new parmStructure("@Name", tmpItem.Name, ParameterDirection.Input, SqlDbType.VarChar, 100));
            myparms.Add(new parmStructure("@Description", tmpItem.Description, ParameterDirection.Input, SqlDbType.VarChar, 200));
            myparms.Add(new parmStructure("@Price", tmpItem.Price, ParameterDirection.Input, SqlDbType.Money));
            myparms.Add(new parmStructure("@PurchaseLocation", tmpItem.PurchaseLocation, ParameterDirection.Input, SqlDbType.VarChar, 100));
            myparms.Add(new parmStructure("@Quantity", tmpItem.Quantity, ParameterDirection.Input, SqlDbType.Int));
            myparms.Add(new parmStructure("@Justification", tmpItem.Justification, ParameterDirection.Input, SqlDbType.VarChar, 300));
            myparms.Add(new parmStructure("@Subtotal", tmpItem.Subtotal, ParameterDirection.Input, SqlDbType.Money));

            if (tmpItem.ModificationReason != null)
            {
                myparms.Add(new parmStructure("@ModificationReason", tmpItem.ModificationReason, ParameterDirection.Input, SqlDbType.VarChar, 200));
            }
            else
            {
                myparms.Add(new parmStructure("@ModificationReason", DBNull.Value, ParameterDirection.Input, SqlDbType.VarChar, 200));
            }
            
            myparms.Add(new parmStructure("@Timestamp", tmpItem.Timestamp, ParameterDirection.InputOutput, SqlDbType.Timestamp));          

            DataAccess.SendData(sql, myparms);
            tmpItem.Timestamp = myparms[8].parmValue;
            return true;
        }

        /// <summary>
        /// Adds a new Item to the specified PurchaseOrder. Accepts the entire item and the PurchaseOrder it belongs to. Returns a boolean
        /// </summary>
        /// <param name="tmpItem"></param>
        /// <param name="tmpOrder"></param>
        /// <returns></returns>
        public static int EmployeeAddItem(IItem tmpItem, IPurchaseOrder tmpOrder)
        {
            string sql = "spEmployeeAddItem";
            List<parmStructure> myparms = new List<parmStructure>();

            myparms.Add(new parmStructure("@ItemId", 0, ParameterDirection.Output, SqlDbType.Int));
            myparms.Add(new parmStructure("@Name", tmpItem.Name, ParameterDirection.Input, SqlDbType.VarChar, 100));
            myparms.Add(new parmStructure("@Description", tmpItem.Description, ParameterDirection.Input, SqlDbType.VarChar, 200));
            myparms.Add(new parmStructure("@Price", tmpItem.Price, ParameterDirection.Input, SqlDbType.Money));
            myparms.Add(new parmStructure("@PurchaseLocation", tmpItem.PurchaseLocation, ParameterDirection.Input, SqlDbType.VarChar, 100));
            myparms.Add(new parmStructure("@Quantity", tmpItem.Quantity, ParameterDirection.Input, SqlDbType.Int));
            myparms.Add(new parmStructure("@Justification", tmpItem.Justification, ParameterDirection.Input, SqlDbType.VarChar, 300));
            myparms.Add(new parmStructure("@Subtotal", tmpItem.Subtotal, ParameterDirection.Input, SqlDbType.Money));
            myparms.Add(new parmStructure("@OrderNumber", tmpItem.OrderNumber, ParameterDirection.Input, SqlDbType.Int));        

            DataAccess.SendData(sql, myparms);
            return Convert.ToInt32(myparms[0].parmValue);
        }

        /// <summary>
        /// Removes an Item from the specified PurchaseOrder. Accepts the entire Item and the PurchaseOrder it belongs to. Returns a boolean
        /// </summary>
        /// <param name="tmpItem"></param>
        /// <param name="tmpOrder"></param>
        /// <returns></returns>
        public static bool EmployeeRemoveItem(IItem tmpItem, IPurchaseOrder tmpOrder)
        {
            string sql = "spEmployeeRemoveItem";
            List<parmStructure> myparms = new List<parmStructure>();

            myparms.Add(new parmStructure("@ItemId", tmpItem.ItemId, ParameterDirection.Input, SqlDbType.Int));
            myparms.Add(new parmStructure("@OrderNumber", tmpItem.OrderNumber, ParameterDirection.Input, SqlDbType.Int));
            myparms.Add(new parmStructure("@OrderSubtotal", tmpOrder.Subtotal, ParameterDirection.Input, SqlDbType.Money));
            myparms.Add(new parmStructure("@OrderTaxes", tmpOrder.Taxes, ParameterDirection.Input, SqlDbType.Money));
            myparms.Add(new parmStructure("@OrderTotal", tmpOrder.Total, ParameterDirection.Input, SqlDbType.Money));

            DataAccess.SendData(sql, myparms);
            return true;
        }

        /// <summary>
        /// Sets an Item's status to Approved and modifies the Purchase Order's totals
        /// </summary>
        /// <param name="tmpItem"></param>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        public static bool ApproveItem(IItem tmpItem, int employeeId)
        {
            string sql = "spApproveItem";
            List<parmStructure> myparms = new List<parmStructure>();

            myparms.Add(new parmStructure("@ItemId", tmpItem.ItemId, ParameterDirection.Input, SqlDbType.Int));
            myparms.Add(new parmStructure("@Timestamp", tmpItem.Timestamp, ParameterDirection.InputOutput, SqlDbType.Timestamp));
            myparms.Add(new parmStructure("@EmployeeId", employeeId, ParameterDirection.Input, SqlDbType.Int));

            DataAccess.SendData(sql, myparms);
            tmpItem.Timestamp = myparms[1].parmValue;
            return true;
        }

        /// <summary>
        /// Sets an Item's status to Denied and modifies the Purchase Order's totals
        /// </summary>
        /// <param name="tmpItem"></param>
        /// <param name="employeeId"></param>
        /// <param name="reason"></param>
        /// <returns></returns>
        public static bool DenyItem(IItem tmpItem, int employeeId, string reason)
        {
            string sql = "spDenyItem";
            List<parmStructure> myparms = new List<parmStructure>();

            myparms.Add(new parmStructure("@ItemId", tmpItem.ItemId, ParameterDirection.Input, SqlDbType.Int));
            myparms.Add(new parmStructure("@EmployeeId", employeeId, ParameterDirection.Input, SqlDbType.Int));
            myparms.Add(new parmStructure("@Reason", reason, ParameterDirection.Input, SqlDbType.VarChar, 200));
            myparms.Add(new parmStructure("@Timestamp", tmpItem.Timestamp, ParameterDirection.InputOutput, SqlDbType.Timestamp));

            DataAccess.SendData(sql, myparms);
            tmpItem.Timestamp = myparms[3].parmValue;
            return true;
        }

        /// <summary>
        /// Sets an Item's status to Pending and modifies the Purchase Order's status based on the number of pending Items
        /// </summary>
        /// <param name="tmpItem"></param>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        public static bool PendingItem(IItem tmpItem, int employeeId)
        {
            string sql = "spPendingItem";
            List<parmStructure> myparms = new List<parmStructure>();

            myparms.Add(new parmStructure("@ItemId", tmpItem.ItemId, ParameterDirection.Input, SqlDbType.Int));
            myparms.Add(new parmStructure("@Timestamp", tmpItem.Timestamp, ParameterDirection.InputOutput, SqlDbType.Timestamp));
            myparms.Add(new parmStructure("@EmployeeId", employeeId, ParameterDirection.Input, SqlDbType.Int));

            DataAccess.SendData(sql, myparms);
            tmpItem.Timestamp = myparms[1].parmValue;
            return true;
        }
    }
}
