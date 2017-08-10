using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using FrontEndDesktop.Properties;
using BOL;

namespace FrontEndDesktop
{
    public partial class ProcessPurchaseOrder : Form
    {
        List<OrdersForProcessing> OrderList = PurchaseOrderFactory.CreateListForProcessing();
        PurchaseOrder Order = PurchaseOrderFactory.Create();
        List<Item> ItemList = ItemFactory.CreateList();
        Item tmpItem = ItemFactory.Create();
        Employee tmpEmployee = EmployeeFactory.Create();
        Department tmpDepartment = DepartmentFactory.Create();
        int selectedOrderIndex = 0;
        bool startDateChanged = false;
        bool endDateChanged = false;

        #region Form Load

        public ProcessPurchaseOrder()
        {
            InitializeComponent();
        }

        private void ProcessPurchaseOrder_Load(object sender, EventArgs e)
        {
            txtFilter.Visible = false;
            rdoPending.Checked = true;
            dgvOrders.Visible = false;
            lblPurchaseOrders.Visible = false;
            btnSelect.Visible = false;
            btnCancelSearch.Visible = false;
            txtFilter.Text = "P";
            SetupDataGrid(dgvOrders);
            SetupDataGrid(dgvItems);
            grpOrder.Visible = false;
            lblItems.Visible = false;
            dgvItems.Visible = false;
            btnCancelItems.Visible = false;
            btnApprove.Visible = false;
            btnDeny.Visible = false;
            pnlDeny.Visible = false;
            btnPending.Visible = false;
            btnClose.Visible = false;

            dtpStartDate.CustomFormat = " ";
            dtpStartDate.Format = DateTimePickerFormat.Custom;
            dtpEndDate.CustomFormat = " ";
            dtpEndDate.Format = DateTimePickerFormat.Custom;
        }

        #endregion

        #region Search Purchase Order

        private void btnSearchDates_Click(object sender, EventArgs e)
        {
            try
            {
                OrderList.Clear();

                string[] names = Settings.Default.EmployeeName.ToString().Split(' ');
                string firstName = names[0];
                string lastName = names[1];

                Employee OrderEmployee = EmployeeFactory.RetrieveByName(firstName, lastName);

                if (Settings.Default.AccessLevel.Equals("C"))
                {
                    if (startDateChanged == false && endDateChanged == false)
                    {
                        OrderList = PurchaseOrderFactory.RetrieveOrdersForProcessing(DateTime.MinValue, DateTime.MinValue, OrderEmployee.Id, txtFilter.Text, txtEmployeeName.Text, "C");
                    }
                    else if (startDateChanged == false && endDateChanged == true)
                    {
                        OrderList = PurchaseOrderFactory.RetrieveOrdersForProcessing(DateTime.MinValue, dtpEndDate.Value, OrderEmployee.Id, txtFilter.Text, txtEmployeeName.Text, "C");
                    }
                    else if (startDateChanged == true && endDateChanged == false)
                    {
                        OrderList = PurchaseOrderFactory.RetrieveOrdersForProcessing(dtpStartDate.Value, DateTime.MinValue, OrderEmployee.Id, txtFilter.Text, txtEmployeeName.Text, "C");
                    }
                    else if (startDateChanged == true && endDateChanged == true)
                    {
                        OrderList = PurchaseOrderFactory.RetrieveOrdersForProcessing(dtpStartDate.Value, dtpEndDate.Value, OrderEmployee.Id, txtFilter.Text, txtEmployeeName.Text, "C");
                    }
                }
                else
                {
                    if (startDateChanged == false && endDateChanged == false)
                    {
                        OrderList = PurchaseOrderFactory.RetrieveOrdersForProcessing(DateTime.MinValue, DateTime.MinValue, OrderEmployee.Id, txtFilter.Text, txtEmployeeName.Text, "S");
                    }
                    else if (startDateChanged == false && endDateChanged == true)
                    {
                        OrderList = PurchaseOrderFactory.RetrieveOrdersForProcessing(DateTime.MinValue, dtpEndDate.Value, OrderEmployee.Id, txtFilter.Text, txtEmployeeName.Text, "S");
                    }
                    else if (startDateChanged == true && endDateChanged == false)
                    {
                        OrderList = PurchaseOrderFactory.RetrieveOrdersForProcessing(dtpStartDate.Value, DateTime.MinValue, OrderEmployee.Id, txtFilter.Text, txtEmployeeName.Text, "S");
                    }
                    else if (startDateChanged == true && endDateChanged == true)
                    {
                        OrderList = PurchaseOrderFactory.RetrieveOrdersForProcessing(dtpStartDate.Value, dtpEndDate.Value, OrderEmployee.Id, txtFilter.Text, txtEmployeeName.Text, "S");
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
                    grpSearchOther.Enabled = false;
                    grpSearchOther.Enabled = false;

                    for (int i = 0; i < OrderList.Count; i++)
                    {
                        OrdersForProcessing tmpOrder = OrderList[i];

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

        private void btnReset_Click(object sender, EventArgs e)
        {
            dtpStartDate.CustomFormat = " ";
            dtpStartDate.Format = DateTimePickerFormat.Custom;
            dtpEndDate.CustomFormat = " ";
            dtpEndDate.Format = DateTimePickerFormat.Custom;
            startDateChanged = false;
            endDateChanged = false;
        }

        #endregion

        #region Browse Purchase Orders

        private void btnSelect_Click(object sender, EventArgs e)
        {
            try
            {
                string Status = dgvOrders.CurrentRow.Cells["status"].Value.ToString();
                selectedOrderIndex = dgvOrders.SelectedRows[0].Index;

                ItemList.Clear();
                ItemList = ItemFactory.RetrieveByOrderNumber((int)dgvOrders.SelectedRows[0].Cells[0].Value);

                Employee OrderEmployee = EmployeeFactory.RetrieveByOrderNumber((int)dgvOrders.SelectedRows[0].Cells[0].Value);
                txtEmployee.Text = OrderEmployee.FirstName + " " + OrderEmployee.LastName;

                Order = PurchaseOrderFactory.RetrieveByNumber((int)dgvOrders.SelectedRows[0].Cells[0].Value, OrderEmployee.Id);
                dgvItems.DataSource = ItemList;

                foreach (Item item in ItemList)
                {
                    if (item.Status.Equals("Pending"))
                    {
                        dgvItems.Rows[ItemList.IndexOf(item)].DefaultCellStyle.BackColor = Color.White;
                    }
                    else if (item.Status.Equals("Approved"))
                    {
                        dgvItems.Rows[ItemList.IndexOf(item)].DefaultCellStyle.BackColor = Color.LightGreen;
                    }
                    else if (item.Status.Equals("Denied"))
                    {
                        dgvItems.Rows[ItemList.IndexOf(item)].DefaultCellStyle.BackColor = Color.Red;
                    }
                }

                txtPONumber.Text = Order.OrderNumber.ToString();
                txtCreationDate.Text = Order.OrderDate.ToShortDateString();
                txtStatus.Text = Order.Status;
                txtSubtotal.Text = String.Format("{0:C}", Order.Subtotal);
                txtTaxes.Text = String.Format("{0:C}", Order.Taxes);
                txtTotal.Text = String.Format("{0:C}", Order.Total);

                grpOrder.Visible = true;
                dgvItems.Visible = true;
                ModifyItemDataGrid();
                lblItems.Visible = true;
                btnApprove.Visible = true;
                btnDeny.Visible = true;
                btnCancelItems.Visible = true;
                dgvOrders.Enabled = false;
                dgvOrders.DefaultCellStyle.BackColor = Color.Gray;
                dgvOrders.DefaultCellStyle.SelectionBackColor = Color.Gray;
                dgvOrders.DefaultCellStyle.SelectionForeColor = Color.Black;
                btnSelect.Enabled = false;
                btnCancelSearch.Enabled = false;
                btnPending.Visible = true;
                btnClose.Visible = true;

                if (Order.Status.Equals("Closed"))
                {
                    btnApprove.Enabled = false;
                    btnDeny.Enabled = false;
                    btnPending.Enabled = false;
                    btnClose.Enabled = false;
                }
                else if (txtEmployee.Text == Settings.Default.EmployeeName)
                {
                    btnApprove.Enabled = false;
                    btnDeny.Enabled = false;
                    btnPending.Enabled = false;
                    btnClose.Enabled = false;
                    MessageBox.Show("Supervisors are unable to process their own purchase orders. Please contact your " +
                        "superior to process the order for you. You are able to view the items that you have requested.");
                }
                else
                {
                    btnApprove.Enabled = true;
                    btnDeny.Enabled = true;
                    btnPending.Enabled = true;
                    btnClose.Enabled = true;
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
            grpSearchOther.Enabled = true;
            dtpStartDate.CustomFormat = " ";
            dtpStartDate.Format = DateTimePickerFormat.Custom;
            dtpEndDate.CustomFormat = " ";
            dtpEndDate.Format = DateTimePickerFormat.Custom;
            startDateChanged = false;
            endDateChanged = false;
            rdoPending.Checked = true;
            txtEmployeeName.Clear();
        }

        #endregion

        #region Process Items

        private void btnApprove_Click(object sender, EventArgs e)
        {
            try
            {
                int gridItemIndex = dgvItems.SelectedRows[0].Index;
                Item listItem = ItemList[gridItemIndex];

                if (listItem.Status.Equals("Approved"))
                {
                    MessageBox.Show("Item status is already set to Approved.");
                }
                else if (listItem.Description.Equals("No longer needed"))
                {
                    MessageBox.Show("Item has been marked as no longer needed by the employee. Unable to process.");
                }
                else
                {
                    listItem.Status = "Approved";
                    Order.Status = "Under Review";
                    int itemIndex = ItemList.IndexOf(listItem);
                    ItemList[itemIndex] = listItem;

                    string[] names = Settings.Default.EmployeeName.ToString().Split(' ');
                    string firstName = names[0];
                    string lastName = names[1];

                    Employee CurrentEmployee = EmployeeFactory.RetrieveByName(firstName, lastName);

                    bool result = ItemFactory.ApproveItem(listItem, CurrentEmployee.Id);

                    if (result == true)
                    {
                        MessageBox.Show("Item status has been successfully updated to Approved.");
                        dgvItems.Rows[itemIndex].Cells["Status"].Value = listItem.Status;
                        dgvItems.Rows[itemIndex].DefaultCellStyle.BackColor = Color.LightGreen;
                        dgvOrders.Rows[selectedOrderIndex].Cells["Status"].Value = Order.Status;

                        int itemCount = 0;

                        foreach (Item item in ItemList)
                        {
                            if (item.Status.Equals("Approved") || item.Status.Equals("Denied"))
                            {
                                itemCount += 1;
                            }
                        }

                        if (itemCount == ItemList.Count)
                        {
                            DialogResult dialogResult = MessageBox.Show("All Items Have Been Processed. Do you wish to close the purchase order now?", "", MessageBoxButtons.YesNo);
                            if (dialogResult == DialogResult.Yes)
                            {
                                PurchaseOrderFactory.ClosePurchaseOrder(Order);
                                Order.Status = "Closed";
                                dgvOrders.Rows[selectedOrderIndex].Cells["Status"].Value = Order.Status;
                                dgvOrders.Rows[selectedOrderIndex].DefaultCellStyle.BackColor = Color.Gray;
                                btnCancelItems.PerformClick();

                                Employee OrderEmployee = EmployeeFactory.RetrieveByOrderNumber((int)dgvOrders.SelectedRows[0].Cells[0].Value);
                                PurchaseOrderFactory.EmailEmployee(OrderEmployee.Id, OrderEmployee.Email, Order.OrderNumber, Order.Total, ItemList);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "An error has occurred");
            }
        }

        private void btnDeny_Click(object sender, EventArgs e)
        {
            try
            {
                int gridItemIndex = dgvItems.SelectedRows[0].Index;
                Item listItem = ItemList[gridItemIndex];

                if (listItem.Description.Equals("No longer needed"))
                {
                    MessageBox.Show("Item has been marked as no longer needed by the employee. Unable to process.");
                }
                else if (listItem.Status.Equals("Denied"))
                {
                    MessageBox.Show("Item status is already set to Denied.");
                }
                else
                {
                    pnlDeny.Visible = true;
                    btnApprove.Enabled = false;
                    btnDeny.Enabled = false;
                    btnPending.Enabled = false;
                    btnCancelItems.Enabled = false;
                    dgvItems.Enabled = false;
                    btnClose.Enabled = false;
                    dgvItems.DefaultCellStyle.BackColor = Color.Gray;
                    dgvItems.DefaultCellStyle.SelectionBackColor = Color.Gray;
                    dgvItems.DefaultCellStyle.SelectionForeColor = Color.Black;
                    txtDeny.Focus();
                }
            }    
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "An error has occurred");
            }
        }

        private void btnDenyFinal_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtDeny.Text != string.Empty)
                {
                    int gridItemIndex = dgvItems.SelectedRows[0].Index;
                    Item listItem = ItemList[gridItemIndex];

                    if (listItem.Description.Equals("No longer needed"))
                    {
                        MessageBox.Show("Item has been marked as no longer needed by the employee. Unable to process.");
                    }
                    else if (listItem.Status.Equals("Denied"))
                    {
                        MessageBox.Show("Item status is already set to Denied.");
                    }
                    else
                    {
                        listItem.Status = "Denied";
                        Order.Status = "Under Review";
                        listItem.ModificationReason = txtDeny.Text;
                        int itemIndex = ItemList.IndexOf(listItem);
                        ItemList[itemIndex] = listItem;

                        string[] names = Settings.Default.EmployeeName.ToString().Split(' ');
                        string firstName = names[0];
                        string lastName = names[1];

                        Employee CurrentEmployee = EmployeeFactory.RetrieveByName(firstName, lastName);

                        bool result = ItemFactory.DenyItem(listItem, CurrentEmployee.Id, listItem.ModificationReason);

                        if (result == true)
                        {
                            MessageBox.Show("Item status has been successfully updated to Denied.");
                            dgvItems.Rows[itemIndex].Cells["Status"].Value = listItem.Status;
                            dgvItems.Rows[itemIndex].Cells["description"].Value = listItem.Description;
                            dgvItems.Rows[itemIndex].Cells["modificationReason"].Value = listItem.ModificationReason;
                            dgvItems.Rows[itemIndex].DefaultCellStyle.BackColor = Color.Red;
                            dgvOrders.Rows[selectedOrderIndex].Cells["Status"].Value = Order.Status;
                            btnCancelDeny.PerformClick();

                            int itemCount = 0;

                            foreach (Item item in ItemList)
                            {
                                if (item.Status.Equals("Approved") || item.Status.Equals("Denied"))
                                {
                                    itemCount += 1;
                                }
                            }

                            if (itemCount == ItemList.Count)
                            {
                                DialogResult dialogResult = MessageBox.Show("All Items Have Been Processed. Do you wish to close the purchase order now?", "", MessageBoxButtons.YesNo);
                                if (dialogResult == DialogResult.Yes)
                                {
                                    
                                    PurchaseOrderFactory.ClosePurchaseOrder(Order);
                                    Order.Status = "Closed";
                                    dgvOrders.Rows[selectedOrderIndex].Cells["Status"].Value = Order.Status;
                                    dgvOrders.Rows[selectedOrderIndex].DefaultCellStyle.BackColor = Color.Gray;
                                    btnCancelDeny.PerformClick();
                                    btnCancelItems.PerformClick();

                                    Employee OrderEmployee = EmployeeFactory.RetrieveByOrderNumber((int)dgvOrders.SelectedRows[0].Cells[0].Value);
                                    PurchaseOrderFactory.EmailEmployee(OrderEmployee.Id, OrderEmployee.Email, Order.OrderNumber, Order.Total, ItemList);
                                }
                                else if (dialogResult == DialogResult.No)
                                {
                                    btnCancelDeny.PerformClick();
                                }
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please enter a reason for item denial.");
                }         
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "An error has occurred");
            }
        }

        private void btnPending_Click(object sender, EventArgs e)
        {
            try
            {
                int gridItemIndex = dgvItems.SelectedRows[0].Index;
                Item listItem = ItemList[gridItemIndex];

                if (listItem.Status.Equals("Pending"))
                {
                    MessageBox.Show("Item status is already set to Pending.");
                }
                else if (listItem.Description.Equals("No longer needed"))
                {
                    MessageBox.Show("Item has been marked as no longer needed by the employee. Unable to process.");
                }
                else
                {
                    listItem.Status = "Pending";
                    int itemIndex = ItemList.IndexOf(listItem);
                    ItemList[itemIndex] = listItem;

                    string[] names = Settings.Default.EmployeeName.ToString().Split(' ');
                    string firstName = names[0];
                    string lastName = names[1];

                    Employee CurrentEmployee = EmployeeFactory.RetrieveByName(firstName, lastName);

                    bool result = ItemFactory.PendingItem(listItem, CurrentEmployee.Id);

                    if (result == true)
                    {
                        MessageBox.Show("Item status has been successfully updated to Pending.");
                        dgvItems.Rows[itemIndex].Cells["Status"].Value = listItem.Status;
                        dgvItems.Rows[itemIndex].DefaultCellStyle.BackColor = Color.White;

                        int itemCount = 0;

                        foreach (Item item in ItemList)
                        {
                            if (item.Status.Equals("Pending"))
                            {
                                itemCount += 1;
                            }
                        }

                        if (itemCount == ItemList.Count)
                        {
                            Order.Status = "Pending";
                            dgvOrders.Rows[selectedOrderIndex].Cells["Status"].Value = Order.Status;
                            dgvOrders.Rows[selectedOrderIndex].DefaultCellStyle.BackColor = Color.White;
                            MessageBox.Show("All items have a Pending status. Purchase order status has been set back to Pending.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "An error has occurred");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("Do you wish to close the purchase order now?", "", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    PurchaseOrderFactory.ClosePurchaseOrder(Order);
                    Order.Status = "Closed";
                    dgvOrders.Rows[selectedOrderIndex].Cells["Status"].Value = Order.Status;
                    dgvOrders.Rows[selectedOrderIndex].DefaultCellStyle.BackColor = Color.Gray;
                    btnCancelDeny.PerformClick();
                    btnCancelItems.PerformClick();

                    Employee OrderEmployee = EmployeeFactory.RetrieveByOrderNumber((int)dgvOrders.SelectedRows[0].Cells[0].Value);
                    PurchaseOrderFactory.EmailEmployee(OrderEmployee.Id, OrderEmployee.Email, Order.OrderNumber, Order.Total, ItemList);
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
            btnCancelItems.Visible = false;
            lblItems.Visible = false;
            grpOrder.Visible = false;
            btnSelect.Enabled = true;
            btnCancelSearch.Enabled = true;
            dgvOrders.Enabled = true;
            btnApprove.Visible = false;
            btnDeny.Visible = false;
            btnPending.Visible = false;
            btnClose.Enabled = true;
            btnClose.Visible = false;
            dgvOrders.DefaultCellStyle.BackColor = Color.White;
            dgvOrders.DefaultCellStyle.SelectionBackColor = SystemColors.Highlight;
            dgvOrders.DefaultCellStyle.SelectionForeColor = Color.White;
        }

        private void btnCancelDeny_Click(object sender, EventArgs e)
        {
            txtDeny.Clear();
            pnlDeny.Visible = false;
            dgvItems.Enabled = true;
            dgvItems.DefaultCellStyle.BackColor = Color.White;
            dgvItems.DefaultCellStyle.SelectionBackColor = SystemColors.Highlight;
            dgvItems.DefaultCellStyle.SelectionForeColor = Color.White;
            btnApprove.Enabled = true;
            btnDeny.Enabled = true;
            btnPending.Enabled = true;
            btnCancelItems.Enabled = true;
            btnClose.Enabled = true;
        }

        #endregion

        #region Housekeeping

        private void ModifyPODataGrid()
        {
            dgvOrders.Columns["total"].DefaultCellStyle.Format = "C2";
            dgvOrders.Columns["orderNumber"].HeaderText = "Order Number";
            dgvOrders.Columns["orderDate"].HeaderText = "Order Date";
            dgvOrders.Columns["EmployeeName"].HeaderText = "Employee Name";
        }

        private void ModifyItemDataGrid()
        {
            dgvItems.Columns["orderNumber"].Visible = false;
            dgvItems.Columns["Timestamp"].Visible = false;
            dgvItems.Columns["itemId"].HeaderText = "Item ID";
            dgvItems.Columns["purchaseLocation"].HeaderText = "Purchase Location";
            dgvItems.Columns["modificationReason"].HeaderText = "Modification Reason";
            ((DataGridViewTextBoxColumn)dgvItems.Columns["name"]).MaxInputLength = 10;
            ((DataGridViewTextBoxColumn)dgvItems.Columns["description"]).MaxInputLength = 10;
            ((DataGridViewTextBoxColumn)dgvItems.Columns["purchaseLocation"]).MaxInputLength = 10;
            ((DataGridViewTextBoxColumn)dgvItems.Columns["justification"]).MaxInputLength = 10;
            dgvItems.Columns["price"].DefaultCellStyle.Format = "C2";
            dgvItems.Columns["subtotal"].DefaultCellStyle.Format = "C2";
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

        public static bool IsNumeric(string input)
        {
            int test;
            return int.TryParse(input, out test);
        }

        #endregion
       
    }    
}
