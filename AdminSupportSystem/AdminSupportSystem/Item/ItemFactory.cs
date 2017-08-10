using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using SQL;

namespace BOL
{
    public class ItemFactory
    {
        /// <summary>
        /// Constructor for ItemFactory
        /// </summary>
        private ItemFactory() { }

        /// <summary>
        /// Create function that returns one Item
        /// </summary>
        /// <returns></returns>
        public static Item Create()
        {
            return new Item();
        }

        /// <summary>
        /// Create function that returns a new list of Items
        /// </summary>
        /// <returns></returns>
        public static List<Item> CreateList()
        {
            return new List<Item>();
        }

        /// <summary>
        /// Modify function that updates an Item's information
        /// </summary>
        /// <param name="tmpItem"></param>
        /// <returns></returns>
        public static bool EmployeeModifyItem(Item tmpItem)
        {
            return ItemSQL.EmployeeModifyItem(tmpItem);
        }

        /// <summary>
        /// Add function that adds a new Item to a PurchaseOrder
        /// </summary>
        /// <param name="tmpItem"></param>
        /// <param name="tmpOrder"></param>
        /// <returns></returns>
        public static int EmployeeAddItem(Item tmpItem, PurchaseOrder tmpOrder)
        {
            return ItemSQL.EmployeeAddItem(tmpItem, tmpOrder);
        }

        /// <summary>
        /// Remove function that removes an Item from a PurchaseOrder
        /// </summary>
        /// <param name="tmpItem"></param>
        /// <param name="tmpOrder"></param>
        /// <returns></returns>
        public static bool EmployeeRemoveItem(Item tmpItem, PurchaseOrder tmpOrder)
        {
            return ItemSQL.EmployeeRemoveItem(tmpItem, tmpOrder);
        }

        /// <summary>
        /// Approve function that sets a PurchaseOrder Item status to Approved
        /// </summary>
        /// <param name="tmpItem"></param>
        /// <returns></returns>
        public static bool ApproveItem(Item tmpItem, int employeeId)
        {
            return ItemSQL.ApproveItem(tmpItem, employeeId);
        }

        /// <summary>
        /// Deny function that sets a PurchaseOrder Item status to Denied
        /// </summary>
        /// <param name="tmpItem"></param>
        /// <returns></returns>
        public static bool DenyItem(Item tmpItem, int employeeId, string reason)
        {
            return ItemSQL.DenyItem(tmpItem, employeeId, reason);
        }

        /// <summary>
        /// Function that sets a PurchaseOrder Item status to Pending
        /// </summary>
        /// <param name="tmpItem"></param>
        /// <returns></returns>
        public static bool PendingItem(Item tmpItem, int employeeId)
        {
            return ItemSQL.PendingItem(tmpItem, employeeId);
        }

        /// <summary>
        /// Retrieves an Item based on its PurchaseOrder number
        /// </summary>
        /// <param name="orderNumber"></param>
        /// <returns></returns>
        public static List<Item> RetrieveByOrderNumber(int orderNumber)
        {
            DataTable tmpTable = ItemSQL.RetrieveOrderItems(orderNumber);
            return RepackagerList(tmpTable);
        }

        /// <summary>
        /// Retrieves an Item based on it's ItemId
        /// </summary>
        /// <param name="itemNumber"></param>
        /// <returns></returns>
        public static Item RetrieveByItemNumber(int itemId)
        {
            DataTable tmpTable = ItemSQL.RetrieveItemById(itemId);
            return Repackager(tmpTable);
        }

        /// <summary>
        /// Repackages for an Item that accepts a DataTable and returns an Item
        /// </summary>
        /// <param name="tmpTable"></param>
        /// <returns></returns>
        private static Item Repackager(DataTable tmpTable)
        {
            Item tmpItem = new Item();
            tmpItem.ItemId = Convert.ToInt32(tmpTable.Rows[0]["itemId"]);
            tmpItem.Name = tmpTable.Rows[0]["name"].ToString();
            tmpItem.Description = tmpTable.Rows[0]["description"].ToString();
            tmpItem.PurchaseLocation = tmpTable.Rows[0]["purchaseLocation"].ToString();
            tmpItem.Justification = tmpTable.Rows[0]["justification"].ToString();
            tmpItem.Price = Convert.ToDouble(tmpTable.Rows[0]["price"]);
            tmpItem.Quantity = Convert.ToInt32(tmpTable.Rows[0]["quantity"]);
            tmpItem.Subtotal = Convert.ToDouble(tmpTable.Rows[0]["subtotal"]);
            tmpItem.ModificationReason = tmpTable.Rows[0]["modificationReason"].ToString();
            tmpItem.Status = tmpTable.Rows[0]["status"].ToString();
            tmpItem.OrderNumber = Convert.ToInt32(tmpTable.Rows[0]["orderNumber"]);
            tmpItem.Timestamp = tmpTable.Rows[0]["timestamp"];

            return tmpItem;
        }

        /// <summary>
        /// Repackager for a list of Items that accepts a DataTable and returns a list of Items
        /// </summary>
        /// <param name="tmpTable"></param>
        /// <returns></returns>
        private static List<Item> RepackagerList(DataTable tmpTable)
        {
            List<Item> tmpList = new List<Item>();

            for (int i = 0; i < tmpTable.Rows.Count; i++)
            {
                Item tmpItem = new Item();
                tmpItem.ItemId = Convert.ToInt32(tmpTable.Rows[i]["itemId"]);
                tmpItem.Name = tmpTable.Rows[i]["name"].ToString();
                tmpItem.Description = tmpTable.Rows[i]["description"].ToString();
                tmpItem.PurchaseLocation = tmpTable.Rows[i]["purchaseLocation"].ToString();
                tmpItem.Justification = tmpTable.Rows[i]["justification"].ToString();
                tmpItem.Price = Convert.ToDouble(tmpTable.Rows[i]["price"]);
                tmpItem.Quantity = Convert.ToInt32(tmpTable.Rows[i]["quantity"]);
                tmpItem.Subtotal = Convert.ToDouble(tmpTable.Rows[i]["subtotal"]);

                if (tmpTable.Rows[i]["modificationReason"] == null)
                {
                    tmpItem.ModificationReason = null;
                }
                else
                {
                    tmpItem.ModificationReason = tmpTable.Rows[i]["modificationReason"].ToString();
                }

               
                tmpItem.Status = tmpTable.Rows[i]["status"].ToString();
                tmpItem.OrderNumber = Convert.ToInt32(tmpTable.Rows[i]["orderNumber"]);
                tmpItem.Timestamp = tmpTable.Rows[i]["timestamp"];

                tmpList.Add(tmpItem);
            }

            return tmpList;
        }
    }
}
