using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UDT;

namespace BOL
{
    [Serializable]
    public class Item :IItem
    {
        #region Variables

        private int itemId;
        private string name;
        private string description;
        private double price;
        private string purchaseLocation;
        private int quantity;
        private string justification;
        private string modificationReason;
        private int orderNumber;
        private string status;
        private double subtotal;
        private object timestamp;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor for Item
        /// </summary>
        internal Item() { }

        #endregion

        #region Properties

        /// <summary>
        /// Gets and sets the ItemId for an Item
        /// </summary>
        public int ItemId
        {
            get
            {
                return itemId;
            }
            set
            {
                itemId = value;
            }
        }

        /// <summary>
        /// Gets and sets the Name for an Item
        /// </summary>
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        /// <summary>
        /// Gets and sets the Description for an Item
        /// </summary>
        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                description = value;
            }
        }

        /// <summary>
        /// Gets and sets the Price for an Item
        /// </summary>
        public double Price
        {
            get
            {
                return price;
            }
            set
            {
                price = value;
            }
        }

        /// <summary>
        /// Gets and sets the PurchaseLocation for an Item
        /// </summary>
        public string PurchaseLocation
        {
            get
            {
                return purchaseLocation;
            }
            set
            {
                purchaseLocation = value;
            }
        }

        /// <summary>
        /// Gets and sets the Quantity for an Item
        /// </summary>
        public int Quantity
        {
            get
            {
                return quantity;
            }
            set
            {
                quantity = value;
            }
        }

        /// <summary>
        /// Gets and sets the Justification for an Item
        /// </summary>
        public string Justification
        {
            get
            {
                return justification;
            }
            set
            {
                justification = value;
            }
        }

        /// <summary>
        /// Gets and sets the ModificationReason for an Item
        /// </summary>
        public string ModificationReason
        {
            get
            {
                return modificationReason;
            }
            set
            {
                modificationReason = value;
            }
        }

        /// <summary>
        /// Gets and sets the OrderNumber for an Item
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
        /// Gets and sets the Status for an Item
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
        /// Gets and sets the Subtotal for an Item
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
        /// Gets and sets the Timestamp for an Item
        /// </summary>
        public object Timestamp
        {
            get
            {
                return timestamp;
            }
            set
            {
                timestamp = value;
            }
        }

        #endregion
    }
}
