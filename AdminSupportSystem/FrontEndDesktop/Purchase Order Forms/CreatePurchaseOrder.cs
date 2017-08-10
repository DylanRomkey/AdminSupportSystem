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
using UDT;
using VAL;

namespace FrontEndDesktop
{
    public partial class CreatePurchaseOrder : Form
    {
        List<Item> ItemList = ItemFactory.CreateList();
        Employee tmpEmployee = EmployeeFactory.Create();
        Department tmpDepartment = DepartmentFactory.Create();

        #region Form Load

        public CreatePurchaseOrder()
        {
            InitializeComponent();
        }

        private void CreatePurchaseOrder_Load(object sender, EventArgs e)
        {
            try
            {
                loadDataGridColumns();
                SetupItemDataGrid();
                dgvItems.Visible = false;
                pnlTotals.Visible = false;
                txtDate.Text = DateTime.Now.ToShortDateString();
                LoadEmployee();
                txtName.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "An error has occurred");
            }
        }

        #endregion

        #region Buttons

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtName.Text != string.Empty && txtDescription.Text != string.Empty && txtPrice.Text != string.Empty &&
                    IsNumeric(txtPrice.Text) && txtPurchaseLocation.Text != string.Empty && txtQuantity.Text != string.Empty &&
                    IsNumeric(txtQuantity.Text) && txtJustification.Text != string.Empty)
                {
                    Item tmpItem = ItemFactory.Create();
                    tmpItem.Name = txtName.Text;
                    tmpItem.Description = txtDescription.Text;
                    tmpItem.Price = Convert.ToDouble(txtPrice.Text);
                    tmpItem.PurchaseLocation = txtPurchaseLocation.Text;
                    tmpItem.Quantity = Convert.ToInt16(txtQuantity.Text);
                    tmpItem.Justification = txtJustification.Text;
                    tmpItem.Status = "Pending";
                    tmpItem.Subtotal = tmpItem.Price * tmpItem.Quantity;

                    if (VAL.Validate.cleanItem(tmpItem))
                    {
                        if (ItemList.Count > 0)
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
                                        item.Subtotal = item.Price * item.Quantity;
                                        dgvItems.Visible = true;
                                        int rowIndex = ItemList.IndexOf(item);
                                        dgvItems.Rows[rowIndex].Cells["Quantity"].Value = item.Quantity;
                                        dgvItems.Rows[rowIndex].Cells["Subtotal"].Value = String.Format("{0:C}", item.Subtotal);
                                        pnlTotals.Visible = true;
                                        ClearInputs();
                                        txtName.Focus();

                                        CalculateTotals();
                                    }
                                }
                            }
                            else
                            {
                                dgvItems.Visible = true;
                                pnlTotals.Visible = true;
                                ItemList.Add(tmpItem);
                                dgvItems.Rows.Add(tmpItem.Name, tmpItem.Quantity, String.Format("{0:C}", tmpItem.Subtotal));
                                ClearInputs();
                                txtName.Focus();

                                CalculateTotals();
                            }
                        }
                        else
                        {
                            dgvItems.Visible = true;
                            pnlTotals.Visible = true;
                            ItemList.Add(tmpItem);
                            dgvItems.Rows.Add(tmpItem.Name, tmpItem.Quantity, String.Format("{0:C}", tmpItem.Subtotal));
                            ClearInputs();
                            txtName.Focus();

                            CalculateTotals();
                        } 
                    }
                }
                else
                {
                    MessageBox.Show("Item addition was unsuccessful. Please make sure all fields are filled in properly and resubmit.");
                }                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "An error has occurred");
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ItemList.Clear();
            dgvItems.Rows.Clear();
            ClearInputs();
            dgvItems.Visible = false;
            ClearTotals();
            pnlTotals.Visible = false;
            txtName.Focus();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                if (ItemList.Count > 0)
                {
                    ItemList.RemoveAt(dgvItems.CurrentRow.Index);
                    dgvItems.Rows.RemoveAt(dgvItems.CurrentRow.Index);
                    CalculateTotals();
                    txtName.Focus();
                }

                if (dgvItems.Rows.Count == 0)
                {
                    ClearTotals();
                    pnlTotals.Visible = false;
                    dgvItems.Visible = false;
                    txtName.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "An error has occurred");
            }
        }

        private void btnComplete_Click(object sender, EventArgs e)
        {
            try
            {
                if (ItemList.Count > 0)
                {
                    PurchaseOrder tmpOrder = PurchaseOrderFactory.Create();

                    foreach (Item tmpItem in ItemList)
                    {
                        tmpOrder.Subtotal += tmpItem.Subtotal;
                        tmpOrder.Taxes += (tmpItem.Subtotal * 0.15);
                        tmpOrder.PurchaseOrderItemList.Add(tmpItem);
                    }

                    tmpOrder.Total = tmpOrder.Subtotal + tmpOrder.Taxes;
                    tmpOrder.Status = "Pending";
                    tmpOrder.EmployeeId = tmpEmployee.Id;
                    tmpOrder.OrderDate = DateTime.Now;

                    if (VAL.Validate.cleanPurchaseOrder(tmpOrder))
                    {
                        int OrderNumber = PurchaseOrderFactory.Submit(tmpOrder);
                        MessageBox.Show("Purchase Order successfully submitted. Agreement ID is " + OrderNumber + ".");
                        ClearInputs();
                        ItemList.Clear();
                        dgvItems.Rows.Clear();
                        ClearTotals();
                        pnlTotals.Visible = false;
                        dgvItems.Visible = false;
                        txtName.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Please add items to Purchase Order before submitting.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "An error has occurred");
            }
        }

        #endregion

        #region Housekeeping

        private void ClearInputs()
        {
            txtName.Clear();
            txtDescription.Clear();
            txtPrice.Clear();
            txtPurchaseLocation.Clear();
            txtQuantity.Clear();
            txtJustification.Clear();
        }

        private void ClearTotals()
        {
            txtSubtotal.Clear();
            txtTaxes.Clear();
            txtTotal.Clear();
        }

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

        private void LoadEmployee()
        {
            string[] names = Settings.Default.EmployeeName.ToString().Split(' ');
            string firstName = names[0];
            string lastName = names[1];
            tmpEmployee = EmployeeFactory.RetrieveByName(firstName, lastName);
            tmpDepartment = DepartmentFactory.RetrieveByEmployeeId(tmpEmployee.Id);

            txtEmployeeName.Text = tmpEmployee.FirstName + " " + tmpEmployee.LastName;
            txtDepartment.Text = tmpDepartment.Title;
            txtSupervisor.Text = tmpDepartment.SupervisorName;
        }

        private void loadDataGridColumns()
        {
            dgvItems.Columns.Add("Name", "Name");
            dgvItems.Columns.Add("Quantity", "Quantity");
            dgvItems.Columns.Add("Subtotal", "Subtotal");
        }

        private void SetupItemDataGrid()
        {
            dgvItems.ReadOnly = true;
            dgvItems.RowHeadersVisible = false;
            dgvItems.AllowUserToAddRows = false;
            dgvItems.AllowUserToResizeColumns = false;
            dgvItems.AllowUserToResizeRows = false;
            dgvItems.AllowUserToDeleteRows = false;
            dgvItems.AllowUserToOrderColumns = false;
            dgvItems.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvItems.MultiSelect = false;
            dgvItems.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvItems.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvItems.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;

            foreach (DataGridViewColumn column in dgvItems.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        public static bool IsNumeric(string input)
        {
            int test;
            return int.TryParse(input, out test);
        }

        private void txtName_Enter(object sender, EventArgs e)
        {
            if (sender is TextBox)
            {
                TextBox tb = (TextBox)sender;
                tb.SelectAll();
            }
        }

        private void btnClearItem_Click(object sender, EventArgs e)
        {
            txtName.Clear();
            txtDescription.Clear();
            txtPurchaseLocation.Clear();
            txtJustification.Clear();
            txtPrice.Clear();
            txtQuantity.Clear();
            txtName.Focus();
        }

        #endregion

    }
}
