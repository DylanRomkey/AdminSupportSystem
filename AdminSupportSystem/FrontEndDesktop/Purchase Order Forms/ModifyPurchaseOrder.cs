using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FrontEndDesktop.Properties;
using BOL;

namespace FrontEndDesktop
{
    public partial class ModifyPurchaseOrder : Form
    {
        List<PurchaseOrder> OrderList = PurchaseOrderFactory.CreateList();
        PurchaseOrder Order = PurchaseOrderFactory.Create();
        List<Item> ItemList = ItemFactory.CreateList();
        Item tmpItem = ItemFactory.Create();
        Employee tmpEmployee = EmployeeFactory.Create();
        Department tmpDepartment = DepartmentFactory.Create();
        int selectedItemIndex = 0;
        int selectedOrderIndex = 0;
        bool startDateChanged = false;
        bool endDateChanged = false;

        #region Form Load

        public ModifyPurchaseOrder()
        {
            InitializeComponent(); 
        }

        private void ModifyPurchaseOrder_Load(object sender, EventArgs e)
        {
            SetupDataGrid(dgvOrders);
            SetupDataGrid(dgvItems);
            dgvOrders.Visible = false;
            btnSelect.Visible = false;
            btnCancelSearch.Visible = false;
            lblItems.Visible = false;
            dgvItems.Visible = false;
            lblPurchaseOrders.Visible = false;
            btnSelectItem.Visible = false;
            pnlItem.Visible = false;
            grpOrder.Visible = false;
            txtPONumber.Visible = false;
            lblPONumber.Visible = false;
            btnCancelItems.Visible = false;
            btnAdd.Visible = false;
            btnAddItem.Visible = false;
            startDateChanged = false;
            endDateChanged = false;
            txtFilter.Visible = false;
            rdoPending.Checked = true;
            txtFilter.Text = "P";

            dtpStartDate.CustomFormat = " ";
            dtpStartDate.Format = DateTimePickerFormat.Custom;
            dtpEndDate.CustomFormat = " ";
            dtpEndDate.Format = DateTimePickerFormat.Custom;

            if (Settings.Default.AccessLevel.Equals("S"))
            {
                grpFilter.Visible = true;
            }
            else
            {
                grpFilter.Visible = false;
            }
        }

        #endregion

        #region Search Purchase Orders

        private void btnSearchNumber_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNumber.Text != string.Empty && IsNumeric(txtNumber.Text))
                {
                    OrderList.Clear();
                    Order = null;

                    string[] names = Settings.Default.EmployeeName.ToString().Split(' ');
                    string firstName = names[0];
                    string lastName = names[1];

                    Employee OrderEmployee = EmployeeFactory.RetrieveByName(firstName, lastName);

                    if (Settings.Default.AccessLevel.Equals("S"))
                    {
                        Order = PurchaseOrderFactory.RetrieveByNumberSupervisor(Convert.ToInt32(txtNumber.Text), OrderEmployee.Id);

                        if (Order == null)
                        {
                            MessageBox.Show("Purchase order cannot be found or Supervisor does not have permission to view order.");
                            txtNumber.Focus();
                            txtNumber.SelectAll();
                            return;   
                        }
                    }
                    else
                    {
                        Order = PurchaseOrderFactory.RetrieveByNumber(Convert.ToInt32(txtNumber.Text), OrderEmployee.Id);

                        if (Order == null)
                        {
                            MessageBox.Show("Purchase order cannot be found or Employee does not have permission to view order.");
                            txtNumber.Focus();
                            txtNumber.SelectAll();
                            return;
                        }
                    }

                    List<PurchaseOrder> singleOrderList = new List<PurchaseOrder> { Order };
                    dgvOrders.DataSource = singleOrderList;
                    ModifyPODataGrid();
                    dgvOrders.Visible = true;
                    btnSelect.Visible = true;
                    btnCancelSearch.Visible = true;
                    lblPurchaseOrders.Visible = true;
                    txtNumber.Clear();
                    txtNumber.Focus();
                    grpSearchOther.Enabled = false;
                    grpSearchNumber.Enabled = false;

                    for (int i = 0; i < singleOrderList.Count; i++)
                    {
                        PurchaseOrder tmpOrder = singleOrderList[i];

                        if (!tmpOrder.Status.Equals("Pending"))
                        {
                            dgvOrders.Rows[i].DefaultCellStyle.BackColor = Color.Gray;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please enter a valid purchase order number.");
                    txtNumber.Focus();
                    txtNumber.SelectAll();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "An error has occurred");
                txtNumber.Focus();
                txtNumber.SelectAll();
            }
        }

        private void btnSearchDates_Click(object sender, EventArgs e)
        {
            try
            {
                OrderList.Clear();

                string[] names = Settings.Default.EmployeeName.ToString().Split(' ');
                string firstName = names[0];
                string lastName = names[1];

                Employee OrderEmployee = EmployeeFactory.RetrieveByName(firstName, lastName);

                if (Settings.Default.AccessLevel.Equals("S"))
                {
                    if (startDateChanged == false && endDateChanged == false)
                    {
                        OrderList = PurchaseOrderFactory.RetrieveByOtherSupervisor(DateTime.MinValue, DateTime.MinValue, OrderEmployee.Id, txtFilter.Text, txtEmployeeName.Text);
                    }
                    else if (startDateChanged == false && endDateChanged == true)
                    {
                        OrderList = PurchaseOrderFactory.RetrieveByOtherSupervisor(DateTime.MinValue, dtpEndDate.Value, OrderEmployee.Id, txtFilter.Text, txtEmployeeName.Text);
                    }
                    else if (startDateChanged == true && endDateChanged == false)
                    {
                        OrderList = PurchaseOrderFactory.RetrieveByOtherSupervisor(dtpStartDate.Value, DateTime.MinValue, OrderEmployee.Id, txtFilter.Text, txtEmployeeName.Text);
                    }
                    else if (startDateChanged == true && endDateChanged == true)
                    {
                        OrderList = PurchaseOrderFactory.RetrieveByOtherSupervisor(dtpStartDate.Value, dtpEndDate.Value, OrderEmployee.Id, txtFilter.Text, txtEmployeeName.Text);
                    }
                }
                else
                {
                    if (startDateChanged == false && endDateChanged == false)
                    {
                        OrderList = PurchaseOrderFactory.RetrieveByOther(DateTime.MinValue, DateTime.MinValue, OrderEmployee.Id, txtFilter.Text);
                    }
                    else if (startDateChanged == false && endDateChanged == true)
                    {
                        OrderList = PurchaseOrderFactory.RetrieveByOther(DateTime.MinValue, dtpEndDate.Value, OrderEmployee.Id, txtFilter.Text);
                    }
                    else if (startDateChanged == true && endDateChanged == false)
                    {
                        OrderList = PurchaseOrderFactory.RetrieveByOther(dtpStartDate.Value, DateTime.MinValue, OrderEmployee.Id, txtFilter.Text);
                    }
                    else if (startDateChanged == true && endDateChanged == true)
                    {
                        OrderList = PurchaseOrderFactory.RetrieveByOther(dtpStartDate.Value, dtpEndDate.Value, OrderEmployee.Id, txtFilter.Text);
                    }
                }

                if (OrderList.Count == 0)
                {
                    btnCancelSearch.PerformClick();
                    MessageBox.Show("No purchase orders were found for your search parameters.");
                }
                else
                {
                    dgvOrders.DataSource = OrderList;
                    ModifyPODataGrid();
                    dgvOrders.Visible = true;
                    btnSelect.Visible = true;
                    btnCancelSearch.Visible = true;
                    lblPurchaseOrders.Visible = true;
                    txtNumber.Clear();
                    txtNumber.Focus();
                    grpSearchOther.Enabled = false;
                    grpSearchNumber.Enabled = false;
                    grpFilter.Enabled = false;

                    for (int i = 0; i < OrderList.Count; i++)
                    {
                        PurchaseOrder tmpOrder = OrderList[i];

                        if (!tmpOrder.Status.Equals("Pending"))
                        {
                            dgvOrders.Rows[i].DefaultCellStyle.BackColor = Color.Gray;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "An error has occurred");
            }
        }

        private void btnCancelSearch_Click(object sender, EventArgs e)
        {
            dgvOrders.DataSource = null;
            dgvOrders.Visible = false;
            btnSelect.Visible = false;
            btnCancelSearch.Visible = false;
            lblPurchaseOrders.Visible = false;
            btnSelectItem.Visible = false;
            grpSearchOther.Enabled = true;
            grpSearchNumber.Enabled = true;
            dtpStartDate.CustomFormat = " ";
            dtpStartDate.Format = DateTimePickerFormat.Custom;
            dtpEndDate.CustomFormat = " ";
            dtpEndDate.Format = DateTimePickerFormat.Custom;
            startDateChanged = false;
            endDateChanged = false;
            grpFilter.Enabled = true;
            rdoPending.Checked = true;
            txtEmployeeName.Clear();
            txtNumber.Focus();
        }

        #endregion

        #region Browse Items

        private void btnSelect_Click(object sender, EventArgs e)
        {
            try
            {
                string Status = dgvOrders.CurrentRow.Cells["status"].Value.ToString();

                selectedOrderIndex = dgvOrders.SelectedRows[0].Index;

                ItemList.Clear();
                ItemList = ItemFactory.RetrieveByOrderNumber((int)dgvOrders.SelectedRows[0].Cells[0].Value);                         
                      
                Employee OrderEmployee = EmployeeFactory.RetrieveByOrderNumber((int)dgvOrders.SelectedRows[0].Cells[0].Value);
                tmpDepartment = DepartmentFactory.RetrieveByEmployeeId(OrderEmployee.Id);
                txtEmployee.Text = OrderEmployee.FirstName + " " + OrderEmployee.LastName;
                txtDepartment.Text = tmpDepartment.Title;
                txtSupervisor.Text = tmpDepartment.SupervisorName;

                Order = PurchaseOrderFactory.RetrieveByNumber((int)dgvOrders.SelectedRows[0].Cells[0].Value, OrderEmployee.Id);
                dgvItems.DataSource = ItemList;

                foreach (Item item in ItemList)
                {
                    if (!Order.Status.Equals("Closed"))
                    {
                        if (!item.Status.Equals("Pending"))
                        {
                            if (!item.Description.Equals("No longer needed"))
                            {
                                dgvItems.Rows[ItemList.IndexOf(item)].DefaultCellStyle.BackColor = Color.White;
                                dgvItems.Rows[ItemList.IndexOf(item)].Cells["status"].Value = "Pending";
                            }
                            else
                            {
                                dgvItems.Rows[ItemList.IndexOf(item)].DefaultCellStyle.BackColor = Color.Gray;
                            }
                        }

                        btnAdd.Enabled = true;
                        btnSelectItem.Enabled = true;
                    }
                    else
                    {
                        if (!item.Status.Equals("Pending"))
                        {
                            dgvItems.Rows[ItemList.IndexOf(item)].DefaultCellStyle.BackColor = Color.Gray;
                        }

                        btnSelectItem.Enabled = false;
                        btnAdd.Enabled = false;
                    }
                }

                txtPONumber.Text = Order.OrderNumber.ToString();
                txtCreationDate.Text = Order.OrderDate.ToShortDateString();
                txtStatus.Text = Order.Status;
                txtSubtotal.Text = String.Format("{0:C}", Order.Subtotal);
                txtTaxes.Text = String.Format("{0:C}", Order.Taxes);
                txtTotal.Text = String.Format("{0:C}", Order.Total);

                dgvItems.Visible = true;
                lblItems.Visible = true;
                btnSelectItem.Visible = true;
                ModifyItemDataGrid();
                grpOrder.Visible = true;
                txtPONumber.Visible = true;
                lblPONumber.Visible = true;
                btnCancelItems.Visible = true;
                dgvOrders.Enabled = false;
                dgvOrders.DefaultCellStyle.BackColor = Color.Gray;
                dgvOrders.DefaultCellStyle.SelectionBackColor = Color.Gray;
                dgvOrders.DefaultCellStyle.SelectionForeColor = Color.Black;
                btnSelect.Enabled = false;
                btnCancelSearch.Enabled = false;
                btnAdd.Visible = true;

                if (!txtEmployee.Text.Equals(Settings.Default.EmployeeName))
                {
                    btnAdd.Enabled = false;
                }
                else
                {
                    btnAdd.Enabled = true;
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "An error has occurred");
            }
        }

        private void btnSelectItem_Click(object sender, EventArgs e)
        {
            try
            {
                tmpItem = ItemFactory.RetrieveByItemNumber((int)dgvItems.SelectedRows[0].Cells[0].Value);

                if (dgvItems.SelectedRows[0].Cells["status"].Value.Equals("Pending")) { 
                    if (tmpItem.Status.Equals("Pending"))
                    {
                        txtName.Text = tmpItem.Name;
                        txtDescription.Text = tmpItem.Description;
                        txtPurchaseLocation.Text = tmpItem.PurchaseLocation;
                        txtJustification.Text = tmpItem.Justification;
                        txtPrice.Text = tmpItem.Price.ToString();
                        txtQuantity.Text = tmpItem.Quantity.ToString();

                        if (tmpItem.ModificationReason != null)
                        {
                            txtModReason.Text = tmpItem.ModificationReason;
                        }

                        pnlItem.Visible = true;
                        btnSelectItem.Enabled = false;
                        btnCancelItems.Enabled = false;
                        dgvItems.Enabled = false;
                        btnAdd.Enabled = false;
                        btnModify.Visible = true;
                        btnRemove.Visible = true;
                        dgvItems.DefaultCellStyle.BackColor = Color.Gray;
                        dgvItems.DefaultCellStyle.SelectionBackColor = Color.Gray;
                        dgvItems.DefaultCellStyle.SelectionForeColor = Color.Black;

                        if (txtEmployee.Text != Settings.Default.EmployeeName.ToString())
                        {
                            lblModReason.Visible = true;
                            txtModReason.Visible = true;
                            txtName.Enabled = false;
                            txtDescription.Enabled = false;
                            txtJustification.Enabled = false;
                        }
                        else
                        {
                            lblModReason.Visible = false;
                            txtModReason.Visible = false;
                            txtName.Enabled = true;
                            txtDescription.Enabled = true;
                            txtJustification.Enabled = true;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Item is currently under review and cannot be modified.");
                    }
                }
                else
                {
                    MessageBox.Show("Cannot modify item if its status is not set to Pending.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "An error has occurred");
            }
        }

        private void btnCancelItems_Click(object sender, EventArgs e)
        {
            dgvItems.DataSource = null;
            dgvItems.Visible = false;
            dgvItems.Visible = false;
            btnCancelItems.Visible = false;
            btnSelectItem.Visible = false;
            lblItems.Visible = false;
            grpOrder.Visible = false;
            btnSelect.Enabled = true;
            btnCancelSearch.Enabled = true;
            dgvOrders.Enabled = true;
            btnAdd.Visible = false;
            rdoPending.Checked = true;
            dgvOrders.DefaultCellStyle.BackColor = Color.White;
            dgvOrders.DefaultCellStyle.SelectionBackColor = SystemColors.Highlight;
            dgvOrders.DefaultCellStyle.SelectionForeColor = Color.White;
        }

        #endregion

        #region Modify Item

        private void btnModify_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtName.Text != string.Empty && txtDescription.Text != string.Empty && txtPurchaseLocation.Text != string.Empty &&
                    txtJustification.Text != string.Empty && txtPrice.Text != string.Empty && IsNumeric(txtPrice.Text) && 
                    txtQuantity.Text != string.Empty && Convert.ToInt32(txtQuantity.Text) > 0 && IsNumeric(txtQuantity.Text))
                {
                    int gridItemIndex = dgvItems.SelectedRows[0].Index;         
                    Item listItem = ItemList[gridItemIndex];
                    listItem.Name = txtName.Text;
                    listItem.Description = txtDescription.Text;
                    listItem.PurchaseLocation = txtPurchaseLocation.Text;
                    listItem.Justification = txtJustification.Text;
                    listItem.Price = Convert.ToDouble(txtPrice.Text);
                    listItem.Quantity = Convert.ToInt32(txtQuantity.Text);
                    listItem.Subtotal = listItem.Price * listItem.Quantity;   
                    
                    if (txtModReason.Text != string.Empty)
                    {
                        listItem.ModificationReason = txtModReason.Text;
                    }         

                    if (VAL.Validate.cleanItem(listItem))
                    {
                        int itemIndex = ItemList.IndexOf(listItem);
                        ItemList[itemIndex] = listItem;

                        dgvItems.Rows[itemIndex].Cells["Name"].Value = listItem.Name;
                        dgvItems.Rows[itemIndex].Cells["Description"].Value = listItem.Description;
                        dgvItems.Rows[itemIndex].Cells["PurchaseLocation"].Value = listItem.PurchaseLocation;
                        dgvItems.Rows[itemIndex].Cells["Justification"].Value = listItem.Justification;
                        dgvItems.Rows[itemIndex].Cells["Price"].Value = listItem.Price;
                        dgvItems.Rows[itemIndex].Cells["Quantity"].Value = listItem.Quantity;
                        dgvItems.Rows[itemIndex].Cells["Subtotal"].Value = listItem.Subtotal;

                        bool result = false;

                        if (txtEmployee.Text != Settings.Default.EmployeeName.ToString())
                        {
                            if (txtModReason.Text == string.Empty)
                            {
                                MessageBox.Show("Supervisor must supply a reason for modifying an employee's item.");
                            }
                            else
                            {
                                result = ItemFactory.EmployeeModifyItem(listItem);
                            }
                        }
                        else
                        {
                            result = ItemFactory.EmployeeModifyItem(listItem);
                        }                            

                        if (result == true)
                        {
                            CalculateTotals();

                            double subtotal = Convert.ToDouble((txtSubtotal.Text as string).Trim('$'));
                            double taxes = Convert.ToDouble((txtTaxes.Text as string).Trim('$'));
                            double total = Convert.ToDouble((txtTotal.Text as string).Trim('$'));

                            Order.Subtotal = subtotal;
                            Order.Taxes = taxes;
                            Order.Total = total;

                            PurchaseOrderFactory.EmployeeUpdateTotals(Order);
                            ItemList = ItemFactory.RetrieveByOrderNumber(listItem.OrderNumber);
                            MessageBox.Show("Item #" + listItem.ItemId + " successfully updated. Purchase Order totals have also been updated.");

                            txtName.Text = listItem.Name;
                            txtDescription.Text = listItem.Description;
                            txtPurchaseLocation.Text = listItem.PurchaseLocation;
                            txtJustification.Text = listItem.Justification;
                            txtPrice.Text = listItem.Price.ToString();
                            txtQuantity.Text = listItem.Quantity.ToString();

                            if (listItem.ModificationReason != null)
                            {
                                txtModReason.Text = listItem.ModificationReason;
                            }

                            dgvOrders.Rows[selectedOrderIndex].Cells["Subtotal"].Value = Order.Subtotal;
                            dgvOrders.Rows[selectedOrderIndex].Cells["Taxes"].Value = Order.Taxes;
                            dgvOrders.Rows[selectedOrderIndex].Cells["Total"].Value = Order.Total;

                            dgvItems.DataSource = ItemList;
                            dgvItems.Rows[selectedItemIndex].Selected = true;

                            if (!Order.Status.Equals("Closed"))
                            {
                                foreach (Item item in ItemList)
                                {
                                    if (!item.Description.Equals("No longer needed"))
                                    {
                                        dgvItems.Rows[ItemList.IndexOf(item)].Cells["status"].Value = "Pending";
                                    }
                                }
                            }
                        }

                        dgvItems.Rows[itemIndex].Selected = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "An error has occurred");
                btnCancelEdit.PerformClick();
                btnCancelItems.PerformClick();
                btnCancelSearch.PerformClick();
            }
        }

        private void btnCancelEdit_Click(object sender, EventArgs e)
        {
            tmpItem = null;
            pnlItem.Visible = false;
            btnSelectItem.Enabled = true;
            btnCancelItems.Enabled = true;
            dgvItems.Enabled = true;
            btnAdd.Enabled = true;
            btnAddItem.Visible = false;
            lblModReason.Visible = false;
            txtModReason.Visible = false;
            dgvItems.DefaultCellStyle.BackColor = Color.White;
            dgvItems.DefaultCellStyle.SelectionBackColor = SystemColors.Highlight;
            dgvItems.DefaultCellStyle.SelectionForeColor = Color.White;
            txtName.Clear();
            txtDescription.Clear();
            txtPurchaseLocation.Clear();
            txtJustification.Clear();
            txtPrice.Clear();
            txtQuantity.Clear();
            txtModReason.Clear();

            if (!txtEmployee.Text.Equals(Settings.Default.EmployeeName))
            {
                btnAdd.Enabled = false;
            }
            else
            {
                btnAdd.Enabled = true;
            }

            foreach (Item item in ItemList)
            {
                if (!item.Status.Equals("Pending"))
                {
                    dgvItems.Rows[ItemList.IndexOf(item)].DefaultCellStyle.BackColor = Color.Gray;
                }
            }
        }

        #endregion

        #region Add/Remove Item

        private void btnAdd_Click(object sender, EventArgs e)
        {
            pnlItem.Visible = true;
            btnSelectItem.Enabled = false;
            btnCancelItems.Enabled = false;
            btnAdd.Enabled = false;     
            dgvItems.Enabled = false;
            btnAdd.Enabled = false;
            btnRemove.Visible = false;
            btnAddItem.Visible = true;
            btnModify.Visible = false;
            dgvItems.DefaultCellStyle.BackColor = Color.Gray;
            dgvItems.DefaultCellStyle.SelectionBackColor = Color.Gray;
            dgvItems.DefaultCellStyle.SelectionForeColor = Color.Black;
            tmpItem = null;
            lblModReason.Visible = false;
            txtModReason.Visible = false;   
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtName.Text != string.Empty && txtDescription.Text != string.Empty && txtPurchaseLocation.Text != string.Empty &&
                    txtJustification.Text != string.Empty && txtPrice.Text != string.Empty && IsNumeric(txtPrice.Text) &&
                    txtQuantity.Text != string.Empty && Convert.ToInt32(txtQuantity.Text) > 0 && IsNumeric(txtQuantity.Text))
                {
                    Item tmpItem = ItemFactory.Create();
                    tmpItem.Name = txtName.Text;
                    tmpItem.Description = txtDescription.Text;
                    tmpItem.PurchaseLocation = txtPurchaseLocation.Text;
                    tmpItem.Justification = txtJustification.Text;
                    tmpItem.Price = Convert.ToDouble(txtPrice.Text);
                    tmpItem.Quantity = Convert.ToInt32(txtQuantity.Text);
                    tmpItem.Subtotal = tmpItem.Price * tmpItem.Quantity;
                    tmpItem.OrderNumber = Order.OrderNumber;

                    if (VAL.Validate.cleanItem(tmpItem))
                    {
                        if (ItemList.Any(Item => Item.Name == tmpItem.Name) && ItemList.Any(Item => Item.Description == tmpItem.Description) &&
                            ItemList.Any(Item => Item.Price == tmpItem.Price) && ItemList.Any(Item => Item.PurchaseLocation == tmpItem.PurchaseLocation) &&
                            ItemList.Any(Item => Item.Justification == tmpItem.Justification))
                        {
                            foreach (Item item in ItemList)
                            {
                                if (tmpItem.Name.Equals(item.Name) && tmpItem.Description.Equals(item.Description) &&
                                    tmpItem.Price == item.Price && tmpItem.PurchaseLocation.Equals(item.PurchaseLocation) &&
                                    tmpItem.Justification.Equals(item.Justification))
                                {
                                    item.Quantity += tmpItem.Quantity;
                                    item.Subtotal += tmpItem.Price * tmpItem.Quantity;
                                    int rowIndex = ItemList.IndexOf(item);
                                    dgvItems.Rows[rowIndex].Cells["Quantity"].Value = item.Quantity;
                                    dgvItems.Rows[rowIndex].Cells["Subtotal"].Value = item.Subtotal;
                                    tmpItem = item;

                                    txtName.Focus();
                                }
                            }

                            if (!tmpItem.Status.Equals("Pending"))
                            {
                                MessageBox.Show("Cannot modify item if its status is not set to Pending.");
                            }
                            else
                            {
                                bool result = ItemFactory.EmployeeModifyItem(tmpItem);

                                if (result == true)
                                {
                                    CalculateTotals();

                                    double subtotal = Convert.ToDouble((txtSubtotal.Text as string).Trim('$'));
                                    double taxes = Convert.ToDouble((txtTaxes.Text as string).Trim('$'));
                                    double total = Convert.ToDouble((txtTotal.Text as string).Trim('$'));

                                    Order.Subtotal = subtotal;
                                    Order.Taxes = taxes;
                                    Order.Total = total;

                                    PurchaseOrderFactory.EmployeeUpdateTotals(Order);
                                    ItemList = ItemFactory.RetrieveByOrderNumber(tmpItem.OrderNumber);
                                    MessageBox.Show("Item #" + tmpItem.ItemId + " successfully updated. Purchase Order totals have also been updated.");

                                    dgvOrders.Rows[selectedOrderIndex].Cells["Subtotal"].Value = Order.Subtotal;
                                    dgvOrders.Rows[selectedOrderIndex].Cells["Taxes"].Value = Order.Taxes;
                                    dgvOrders.Rows[selectedOrderIndex].Cells["Total"].Value = Order.Total;

                                    dgvItems.DataSource = ItemList;

                                    if (!Order.Status.Equals("Closed"))
                                    {
                                        foreach (Item item in ItemList)
                                        {
                                            if (!item.Description.Equals("No longer needed"))
                                            {
                                                dgvItems.Rows[ItemList.IndexOf(item)].Cells["status"].Value = "Pending";
                                            }
                                        }
                                    }
                                }
                            }                           
                        }
                        else
                        {       
                            int itemId = ItemFactory.EmployeeAddItem(tmpItem, Order);

                            if (itemId != 0)
                            {
                                ItemList.Add(tmpItem);
                                CalculateTotals();

                                double subtotal = Convert.ToDouble((txtSubtotal.Text as string).Trim('$'));
                                double taxes = Convert.ToDouble((txtTaxes.Text as string).Trim('$'));
                                double total = Convert.ToDouble((txtTotal.Text as string).Trim('$'));

                                Order.Subtotal = subtotal;
                                Order.Taxes = taxes;
                                Order.Total = total;

                                PurchaseOrderFactory.EmployeeUpdateTotals(Order);
                                ItemList = ItemFactory.RetrieveByOrderNumber(tmpItem.OrderNumber);
                                MessageBox.Show("Item #" + itemId + " successfully added to Order #" + tmpItem.OrderNumber + ". Purchase Order totals have also been updated.");

                                dgvOrders.Rows[selectedOrderIndex].Cells["Subtotal"].Value = Order.Subtotal;
                                dgvOrders.Rows[selectedOrderIndex].Cells["Taxes"].Value = Order.Taxes;
                                dgvOrders.Rows[selectedOrderIndex].Cells["Total"].Value = Order.Total;

                                dgvItems.DataSource = ItemList;

                                if (!Order.Status.Equals("Closed"))
                                {
                                    foreach (Item item in ItemList)
                                    {
                                        if (!item.Description.Equals("No longer needed"))
                                        {
                                            dgvItems.Rows[ItemList.IndexOf(item)].Cells["status"].Value = "Pending";
                                        }
                                    }
                                }
                            }
                        }                          
                    }
                }
                else
                {
                    MessageBox.Show("Please fill in all fields before adding a new item.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "An error has occurred");
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                int gridItemIndex = dgvItems.SelectedRows[0].Index;
                Item listItem = ItemList[gridItemIndex];

                listItem.Quantity = 0;
                listItem.Price = 0;
                listItem.Subtotal = 0;
                listItem.Description = "No longer needed";
                listItem.Status = "Denied";
                ItemList[gridItemIndex] = listItem;

                CalculateTotals();

                double subtotal = Convert.ToDouble((txtSubtotal.Text as string).Trim('$'));
                double taxes = Convert.ToDouble((txtTaxes.Text as string).Trim('$'));
                double total = Convert.ToDouble((txtTotal.Text as string).Trim('$'));

                Order.Subtotal = subtotal;
                Order.Taxes = taxes;
                Order.Total = total;

                dgvOrders.Rows[selectedOrderIndex].Cells["Subtotal"].Value = Order.Subtotal;
                dgvOrders.Rows[selectedOrderIndex].Cells["Taxes"].Value = Order.Taxes;
                dgvOrders.Rows[selectedOrderIndex].Cells["Total"].Value = Order.Total;

                bool result = ItemFactory.EmployeeRemoveItem(listItem, Order);

                if (result == true)
                {
                    ItemList = ItemFactory.RetrieveByOrderNumber(tmpItem.OrderNumber);
                    dgvItems.DataSource = ItemList;

                    if (!Order.Status.Equals("Closed"))
                    {
                        foreach (Item item in ItemList)
                        {
                            if (!item.Description.Equals("No longer needed"))
                            {
                                dgvItems.Rows[ItemList.IndexOf(item)].Cells["status"].Value = "Pending";
                            }
                        }
                    }

                    txtName.Clear();
                    txtDescription.Clear();
                    txtPurchaseLocation.Clear();
                    txtJustification.Clear();
                    txtPrice.Clear();
                    txtQuantity.Clear();
                    txtModReason.Clear();
                    btnCancelEdit.PerformClick();

                    MessageBox.Show("Item quantity successfully updated to zero.");
                }                                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "An error has occurred");
            }
        }

        #endregion

        #region Housekeeping

        private void CalculateTotals()
        {
            double subtotal = 0;
            double taxes = 0;
            double total = 0;

            foreach (Item item in ItemList)
            {
                subtotal += item.Subtotal;     
            }
            taxes = subtotal * 0.15;
            total = subtotal + taxes;

            txtSubtotal.Text = String.Format("{0:C}", subtotal);
            txtTaxes.Text = String.Format("{0:C}", taxes);
            txtTotal.Text = String.Format("{0:C}", total);
        }

        private void SetupDataGrid(DataGridView dgvGrid)
        {
            dgvGrid.ReadOnly = true;
            dgvGrid.RowHeadersVisible = false;
            dgvGrid.AllowUserToAddRows = false;
            dgvGrid.AllowUserToResizeColumns = false;
            dgvGrid.AllowUserToResizeRows = false;
            dgvGrid.AllowUserToDeleteRows = false;
            dgvGrid.AllowUserToOrderColumns = false;
            dgvGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvGrid.MultiSelect = false;
            dgvGrid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvGrid.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvGrid.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;
            dgvGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            foreach (DataGridViewColumn column in dgvGrid.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void ModifyPODataGrid()
        {
            dgvOrders.Columns["employeeId"].Visible = false;
            dgvOrders.Columns["subtotal"].DefaultCellStyle.Format = "C2";
            dgvOrders.Columns["taxes"].DefaultCellStyle.Format = "C2";
            dgvOrders.Columns["total"].DefaultCellStyle.Format = "C2";
            dgvOrders.Columns["orderNumber"].HeaderText = "Order Number";
            dgvOrders.Columns["orderDate"].HeaderText = "Order Date";
        }

        private void ModifyItemDataGrid()
        {
            dgvItems.Columns["modificationReason"].Visible = false;
            dgvItems.Columns["orderNumber"].Visible = false;
            dgvItems.Columns["Timestamp"].Visible = false;
            dgvItems.Columns["itemId"].HeaderText = "Item ID";
            dgvItems.Columns["purchaseLocation"].HeaderText = "Purchase Location";
            ((DataGridViewTextBoxColumn)dgvItems.Columns["name"]).MaxInputLength = 10;
            ((DataGridViewTextBoxColumn)dgvItems.Columns["description"]).MaxInputLength = 10;
            ((DataGridViewTextBoxColumn)dgvItems.Columns["purchaseLocation"]).MaxInputLength = 10;
            ((DataGridViewTextBoxColumn)dgvItems.Columns["justification"]).MaxInputLength = 10;
            dgvItems.Columns["price"].DefaultCellStyle.Format = "C2";
            dgvItems.Columns["subtotal"].DefaultCellStyle.Format = "C2";
        }

        private void dtpStartDate_ValueChanged(object sender, EventArgs e)
        {
            dtpStartDate.Format = DateTimePickerFormat.Short;
            startDateChanged = true;
        }

        private void dtpEndDate_ValueChanged(object sender, EventArgs e)
        {
            dtpEndDate.Format = DateTimePickerFormat.Short;
            endDateChanged = true;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            dtpStartDate.CustomFormat = " ";
            dtpStartDate.Format = DateTimePickerFormat.Custom;
            dtpEndDate.CustomFormat = " ";
            dtpEndDate.Format = DateTimePickerFormat.Custom;
            startDateChanged = false;
            endDateChanged = false;
            txtEmployeeName.Clear();
        }

        private void rdoAll_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoAll.Checked == true)
            {
                txtFilter.Text = "A";
            }
            else if (rdoPending.Checked == true)
            {
                txtFilter.Text = "P";
            }
            else if (rdoClosed.Checked == true)
            {
                txtFilter.Text = "C";
            }
        }

        private void txtName_Enter(object sender, EventArgs e)
        {
            if (sender is TextBox)
            {
                TextBox tb = (TextBox)sender;
                tb.SelectAll();
            }
        }

        public static bool IsNumeric(string input)
        {
            int test;
            return int.TryParse(input, out test);
        }

        #endregion

    }
}
