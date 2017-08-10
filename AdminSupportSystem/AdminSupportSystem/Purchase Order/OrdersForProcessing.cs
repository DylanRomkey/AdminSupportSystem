using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UDT;

namespace BOL
{
    [Serializable]
    public class OrdersForProcessing
    {
        #region Variables

        private int orderNumber;
        private string employeeName;
        private DateTime orderDate;
        private double total;
        private string status;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor for OrdersForProcessing
        /// </summary>
        internal OrdersForProcessing() { }

        #endregion

        #region Properties

        /// <summary>
        /// Gets and sets the OrderNumber for a PurchaseOrder that is being processed
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
        /// Gets and sets the EmployeeName for a PurchaseOrder that is being processed
        /// </summary>
        public string EmployeeName
        {
            get
            {
                return employeeName;
            }
            set
            {
                employeeName = value;
            }
        }

        /// <summary>
        /// Gets and sets the OrderDate for a PurchaseOrder that is being processed
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
        /// Gets and sets the Total for a PurchaseOrder that is being processed
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
        /// Gets and sets the Status for a PurchaseOrder that is being processed
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

        #endregion
    }
}
