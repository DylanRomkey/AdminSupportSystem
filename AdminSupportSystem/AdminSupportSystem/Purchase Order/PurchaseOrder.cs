using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UDT;

namespace BOL
{
    [Serializable]
    public class PurchaseOrder :IPurchaseOrder
    {
        #region Variables

        private int orderNumber;
        private DateTime orderDate;
        private string status;
        private double subtotal;
        private double taxes;
        private double total;
        private int employeeId;
        private List<IItem> purchaseOrderItemList = new List<IItem>();

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor for PurchaseOrder
        /// </summary>
        internal PurchaseOrder() { }

        #endregion

        #region Properties

        /// <summary>
        /// Gets and sets the OrderNumber for a PurchaseOrder
        /// </summary>
        public int OrderNumber
        {
            get
            {
                return orderNumber;
            }
            set
            {
                orderNumber = value;
            }
        }

        /// <summary>
        /// Gets and sets the OrderDate for a PurchaseOrder
        /// </summary>
        public DateTime OrderDate
        {
            get
            {
                return orderDate;
            }
            set
            {
                orderDate = value;
            }
        }

        /// <summary>
        /// Gets and sets the Status for a PurchaseOrder
        /// </summary>
        public string Status
        {
            get
            {
                return status;
            }
            set
            {
                status = value;
            }
        }

        /// <summary>
        /// Gets and sets the Subtotal for a PurchaseOrder
        /// </summary>
        public double Subtotal
        {
            get
            {
                return subtotal;
            }
            set
            {
                subtotal = value;
            }
        }

        /// <summary>
        /// Gets and sets the Taxes for a PurchaseOrder
        /// </summary>
        public double Taxes
        {
            get
            {
                return taxes;
            }
            set
            {
                taxes = value;
            }
        }

        /// <summary>
        /// Gets and sets the Total for a PurchaseOrder
        /// </summary>
        public double Total
        {
            get
            {
                return total;
            }
            set
            {
                total = value;
            }
        }

        /// <summary>
        /// Gets and sets the EmployeeId for a PurchaseOrder
        /// </summary>
        public int EmployeeId
        {
            get
            {
                return employeeId;
            }
            set
            {
                employeeId = value;
            }
        }

        /// <summary>
        /// Gets and sets the List of items on a PurchaseOrder
        /// </summary>
        public List<IItem> PurchaseOrderItemList
        {
            get
            {
                return purchaseOrderItemList;
            }
            set
            {
                purchaseOrderItemList = value;
            }
        }

        #endregion
    }
}
