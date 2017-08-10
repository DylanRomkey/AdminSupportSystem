using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using BOL;

namespace FrontEndWeb
{
    public partial class ModifyPurchaseOrder : System.Web.UI.Page
    {
        Employee tmpEmployee = EmployeeFactory.Create();
        Department tmpDepartment = DepartmentFactory.Create();

        #region Load

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["EmployeeName"] != null)
            {
                if (!Session["AccessLevel"].Equals("C"))
                {
                    btnCancelSearch.Visible = false;
                    orderDetails.Visible = false;
                    grdItems.Visible = false;
                    btnAdd.Visible = false;
                    btnCancelItems.Visible = false;
                    itemInformation.Visible = false;
                    confirmation.Attributes.Add("style", "display:none");

                    if (!Page.IsPostBack)
                    {
                        rblStatus.SelectedIndex = 1;
                        txtFilter.Text = "P";
                    }

                    if (Session["AccessLevel"].Equals("S"))
                    {
                        lblEmployeeName.Visible = true;
                        txtEmployeeName.Visible = true;
                    }
                    else
                    {
                        lblEmployeeName.Visible = false;
                        txtEmployeeName.Visible = false;
                    }
                }
                else
                {
                    Response.Redirect("Login.aspx?message=2", false);
                }
            }
            else
            {
                Response.Redirect("Login.aspx", false);
            }  
        }

        #endregion

        #region Search Purchase Orders

        protected void btnSearchNumber_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNumber.Text != string.Empty && IsNumeric(txtNumber.Text))
                {
                    OrderList.Clear();
                    Order = null;

                    String[] names = Session["EmployeeName"].ToString().Split(' ');
                    string firstName = names[0];
                    string lastName = names[1];

                    Employee OrderEmployee = EmployeeFactory.RetrieveByName(firstName, lastName);

                    if (Session["AccessLevel"].ToString().Equals("S"))
                    {
                        Order = PurchaseOrderFactory.RetrieveByNumberSupervisor(Convert.ToInt32(txtNumber.Text), OrderEmployee.Id);

                        if (Order == null)
                        {
                            confirmation.Attributes.Add("style", "display:block");
                            lblMessage.Text = "Purchase order cannot be found or Supervisor does not have permission to view order";
                            txtNumber.Focus();
                            return;
                        }
                    }
                    else
                    {
                        Order = PurchaseOrderFactory.RetrieveByNumber(Convert.ToInt32(txtNumber.Text), OrderEmployee.Id);

                        if (Order == null)
                        {
                            confirmation.Attributes.Add("style", "display:block");
                            lblMessage.Text = "Purchase order cannot be found or Employee does not have permission to view order";
                            txtNumber.Focus();
                            return;
                        }
                    }

                    List<PurchaseOrder> singleOrderList = new List<PurchaseOrder> { Order };
                    grdOrders.DataSource = singleOrderList;
                    grdOrders.DataBind();
                    grdOrders.Visible = true;
                    txtNumber.Text = "";
                    txtNumber.Focus();
                    searchPanel.Enabled = false;
                    btnCancelSearch.Visible = true;
                    lblMessage.Text = "";
                    confirmation.Attributes.Add("style", "display:none");

                    for (int i = 0; i < singleOrderList.Count; i++)
                    {
                        PurchaseOrder tmpOrder = singleOrderList[i];

                        if (!tmpOrder.Status.Equals("Pending"))
                        {
                            grdOrders.Rows[i].BackColor = System.Drawing.Color.Gray;
                        }
                    }
                }
                else
                {
                    confirmation.Attributes.Add("style", "display:block");
                    lblMessage.Text = "Please enter a valid purchase order number";
                }
            }
            catch (Exception ex)
            {
                confirmation.Attributes.Add("style", "display:block");
                lblMessage.Text = "An error has occurred. " + ex.Message;
                txtNumber.Focus();
            }
        }

        protected void btnSearchDates_Click(object sender, EventArgs e)
        {
            try
            {
                OrderList.Clear();

                String[] names = Session["EmployeeName"].ToString().Split(' ');
                string firstName = names[0];
                string lastName = names[1];

                Employee OrderEmployee = EmployeeFactory.RetrieveByName(firstName, lastName);

                if (Session["AccessLevel"].ToString().Equals("S"))
                {
                    if (dtpStartDate.SelectedDate.ToString().Equals("0001-01-01 12:00:00 AM") && dtpEndDate.SelectedDate.ToString().Equals("0001-01-01 12:00:00 AM"))
                    {
                        OrderList = PurchaseOrderFactory.RetrieveByOtherSupervisor(DateTime.MinValue, DateTime.MinValue, OrderEmployee.Id, txtFilter.Text, txtEmployeeName.Text);
                    }
                    else if (dtpStartDate.SelectedDate.ToString().Equals("0001-01-01 12:00:00 AM") && !dtpEndDate.SelectedDate.ToString().Equals("0001-01-01 12:00:00 AM"))
                    {
                        OrderList = PurchaseOrderFactory.RetrieveByOtherSupervisor(DateTime.MinValue, dtpEndDate.SelectedDate, OrderEmployee.Id, txtFilter.Text, txtEmployeeName.Text);
                    }
                    else if (!dtpStartDate.SelectedDate.ToString().Equals("0001-01-01 12:00:00 AM") && dtpEndDate.SelectedDate.ToString().Equals("0001-01-01 12:00:00 AM"))
                    {
                        OrderList = PurchaseOrderFactory.RetrieveByOtherSupervisor(dtpStartDate.SelectedDate, DateTime.MinValue, OrderEmployee.Id, txtFilter.Text, txtEmployeeName.Text);
                    }
                    else if (!dtpStartDate.SelectedDate.ToString().Equals("0001-01-01 12:00:00 AM") && !dtpEndDate.SelectedDate.ToString().Equals("0001-01-01 12:00:00 AM"))
                    {
                        OrderList = PurchaseOrderFactory.RetrieveByOtherSupervisor(dtpStartDate.SelectedDate, dtpEndDate.SelectedDate, OrderEmployee.Id, txtFilter.Text, txtEmployeeName.Text);
                    }    
                }
                else
                {
                    if (dtpStartDate.SelectedDate.ToString().Equals("0001-01-01 12:00:00 AM") && dtpEndDate.SelectedDate.ToString().Equals("0001-01-01 12:00:00 AM"))
                    {
                        OrderList = PurchaseOrderFactory.RetrieveByOther(DateTime.MinValue, DateTime.MinValue, OrderEmployee.Id, txtFilter.Text);
                    }
                    else if (dtpStartDate.SelectedDate.ToString().Equals("0001-01-01 12:00:00 AM") && !dtpEndDate.SelectedDate.ToString().Equals("0001-01-01 12:00:00 AM"))
                    {
                        OrderList = PurchaseOrderFactory.RetrieveByOther(DateTime.MinValue, dtpEndDate.SelectedDate, OrderEmployee.Id, txtFilter.Text);
                    }
                    else if (!dtpStartDate.SelectedDate.ToString().Equals("0001-01-01 12:00:00 AM") && dtpEndDate.SelectedDate.ToString().Equals("0001-01-01 12:00:00 AM"))
                    {
                        OrderList = PurchaseOrderFactory.RetrieveByOther(dtpStartDate.SelectedDate, DateTime.MinValue, OrderEmployee.Id, txtFilter.Text);
                    }
                    else if (!dtpStartDate.SelectedDate.ToString().Equals("0001-01-01 12:00:00 AM") && !dtpEndDate.SelectedDate.ToString().Equals("0001-01-01 12:00:00 AM"))
                    {
                        OrderList = PurchaseOrderFactory.RetrieveByOther(dtpStartDate.SelectedDate, dtpEndDate.SelectedDate, OrderEmployee.Id, txtFilter.Text);
                    }
                }

                if (OrderList.Count == 0)
                {
                    btnCancelSearch_Click(btnCancelSearch, EventArgs.Empty);
                    confirmation.Attributes.Add("style", "display:block");
                    lblMessage.Text = "No purchase orders were found for your search parameters";
                }
                else
                {
                    grdOrders.DataSource = OrderList;
                    grdOrders.DataBind();
                    grdOrders.Visible = true;
                    btnCancelSearch.Visible = true;
                    txtNumber.Text = "";
                    txtNumber.Focus();
                    searchPanel.Enabled = false;
                    lblMessage.Text = "";
                    confirmation.Attributes.Add("style", "display:none");

                    for (int i = 0; i < OrderList.Count; i++)
                    {
                        PurchaseOrder tmpOrder = OrderList[i];

                        if (!tmpOrder.Status.Equals("Pending"))
                        {
                            grdOrders.Rows[i].BackColor = System.Drawing.Color.Gray;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                confirmation.Attributes.Add("style", "display:block");
                lblMessage.Text = "An error has occurred. " + ex.Message;
            }
        }

        protected void btnCancelSearch_Click(object sender, EventArgs e)
        {
            Order = null;
            ItemList = null;
            grdOrders.DataSource = null;
            grdOrders.Visible = false;
            btnCancelSearch.Visible = false;
            searchPanel.Enabled = true;   
            dtpStartDate.SelectedValue = null;
            dtpEndDate.SelectedValue = null;
            txtEmployeeName.Text = "";
            rblStatus.SelectedValue = "P";
            txtFilter.Text = "P";
            txtNumber.Focus();
            lblMessage.Text = "";
            confirmation.Attributes.Add("style", "display:none");
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            txtEmployeeName.Text = "";
            dtpStartDate.SelectedValue = null;
            dtpEndDate.SelectedValue = null;
            txtFilter.Text = "P";
            rblStatus.SelectedValue = "P";
            txtNumber.Focus();
            lblMessage.Text = "";
            confirmation.Attributes.Add("style", "display:none");
        }

        protected void grdOrders_RowCreated(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[7].Visible = false;
        }

        #endregion      

        #region Browse Items

        protected void grdOrders_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                PurchaseOrder rowOrder = null;

                if (OrderList.Count <= 0)
                {
                    rowOrder = Order;
                }
                else
                {
                    int RowIndex = Convert.ToInt32(e.CommandArgument);
                    rowOrder = OrderList[RowIndex];
                }            

                string Status = rowOrder.Status;

                ItemList.Clear();
                ItemList = ItemFactory.RetrieveByOrderNumber(rowOrder.OrderNumber);

                Employee tmpEmployee = EmployeeFactory.RetrieveByOrderNumber(rowOrder.OrderNumber);
                tmpDepartment = DepartmentFactory.RetrieveByEmployeeId(tmpEmployee.Id);
                txtEmployee.Text = tmpEmployee.FirstName + " " + tmpEmployee.LastName;
                txtDepartment.Text = tmpDepartment.Title;
                txtSupervisor.Text = tmpDepartment.SupervisorName;

                Order = PurchaseOrderFactory.RetrieveByNumber(rowOrder.OrderNumber, tmpEmployee.Id);
                grdItems.DataSource = ItemList;
                grdItems.DataBind();
                orderDetails.Visible = true;
                searchPanel.Attributes.Add("style", "display:none");

                txtPONumber.Text = Order.OrderNumber.ToString();
                txtCreationDate.Text = Order.OrderDate.ToShortDateString();
                txtStatus.Text = Order.Status;
                txtSubtotal.Text = String.Format("{0:C}", Order.Subtotal);
                txtTaxes.Text = String.Format("{0:C}", Order.Taxes);
                txtTotal.Text = String.Format("{0:C}", Order.Total);

                grdItems.Visible = true;
                grdItems.SelectedIndex = -1;
                grdOrders.Visible = true;
                txtPONumber.Visible = true;
                lblPONumber.Visible = true;
                btnCancelItems.Visible = true;
                grdOrders.Enabled = false;
                btnCancelSearch.Enabled = false;
                btnAdd.Visible = true;           

                if (!txtEmployee.Text.Equals(Session["EmployeeName"]))
                {
                    btnAdd.Enabled = false;
                }
                else
                {
                    if (Order.Status.Equals("Closed"))
                    {
                        btnAdd.Enabled = false;
                    }
                    else
                    {
                        btnAdd.Enabled = true;
                    }
                }

                

                lblMessage.Text = "";
                confirmation.Attributes.Add("style", "display:none");
            }
            catch (Exception ex)
            {
                confirmation.Attributes.Add("style", "display:block");
                lblMessage.Text = "An error has occurred. " + ex.Message;
            }
        } 

        protected void btnCancelItems_Click(object sender, EventArgs e)
        {
            ItemList = null;
            Order = null;
            grdItems.DataSource = null;
            grdItems.Visible = false;
            orderDetails.Visible = false;
            btnCancelItems.Visible = false;
            btnCancelSearch.Visible = true;
            btnCancelSearch.Enabled = true;
            grdOrders.Enabled = true;
            btnAdd.Visible = false;
            grdOrders.SelectedIndex = -1;
            searchPanel.Enabled = false;
            searchPanel.Attributes.Add("style", "display:block");
            confirmation.Attributes.Add("style", "display:none");
            lblMessage.Text = "";
        }

        #endregion

        #region Item Information

        protected void grdItems_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                Item rowItem = null;

                if (ItemList.Count <= 0)
                {
                    rowItem = tmpItem;
                }
                else
                {
                    int RowIndex = Convert.ToInt32(e.CommandArgument);
                    rowItem = ItemList[RowIndex];
                }

                int itemId = rowItem.ItemId;
                tmpItem = ItemFactory.RetrieveByItemNumber(itemId);

                if (grdItems.Rows[Convert.ToInt32(e.CommandArgument)].Cells[11].Text.Equals("Pending"))
                {
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

                        itemInformation.Visible = true;
                        btnCancelItems.Enabled = false;
                        grdItems.Visible = true;
                        grdItems.Enabled = false;
                        btnAdd.Enabled = false;
                        btnModify.Visible = true;
                        orderDetails.Visible = true;
                        btnAddItem.Visible = false;

                        if (txtEmployee.Text != Session["EmployeeName"].ToString())
                        {
                            lblModReason.Visible = true;
                            txtModReason.Visible = true;
                            txtName.Enabled = false;
                            txtDescription.Enabled = false;
                            txtJustification.Enabled = false;
                            confirmation.Attributes.Add("style", "display:none");
                            lblMessage.Text = "";
                        }
                        else
                        {
                            lblModReason.Visible = false;
                            txtModReason.Visible = false;
                            txtName.Enabled = true;
                            txtDescription.Enabled = true;
                            txtJustification.Enabled = true;
                            confirmation.Attributes.Add("style", "display:none");
                            lblMessage.Text = "";
                        }
                    }
                    else
                    {
                        confirmation.Attributes.Add("style", "display:block");
                        lblMessage.Text = "Item is currently under review and cannot be modified";
                        itemInformation.Visible = false;
                        orderDetails.Visible = true;
                        grdItems.Visible = true;
                        grdItems.Enabled = true;
                        btnCancelItems.Visible = true;
                        btnCancelItems.Enabled = true;
                        btnAdd.Visible = true;
                        btnAdd.Enabled = true;
                    }
                }
                else
                {
                    confirmation.Attributes.Add("style", "display:block");
                    lblMessage.Text = "Cannot modify item if its status is not set to Pending";
                    itemInformation.Visible = false;
                    orderDetails.Visible = true;
                    grdItems.Visible = true;
                    grdItems.Enabled = true;
                    btnCancelItems.Visible = true;
                    btnCancelItems.Enabled = true;
                    btnAdd.Visible = true;
                    btnAdd.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                confirmation.Attributes.Add("style", "display:block");
                lblMessage.Text = "An error has occurred. " + ex.Message;
                itemInformation.Visible = false;
                orderDetails.Visible = true;
                grdItems.Visible = true;
                grdItems.Enabled = true;
                btnCancelItems.Visible = true;
                btnCancelItems.Enabled = true;
                btnAdd.Visible = true;
                btnAdd.Enabled = true;
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            itemInformation.Visible = true;
            btnCancelItems.Enabled = false;
            btnAdd.Enabled = false;
            grdItems.Visible = true;
            grdItems.Enabled = false;
            orderDetails.Visible = true;         
            btnAdd.Enabled = false;
            btnAddItem.Visible = true;
            btnModify.Visible = false;
            tmpItem = null;
            lblModReason.Visible = false;
            txtModReason.Visible = false;
        }

        protected void btnCancelEdit_Click(object sender, EventArgs e)
        {
            tmpItem = null;
            itemInformation.Visible = false;
            btnCancelItems.Enabled = true;
            grdItems.Enabled = true;
            btnAdd.Enabled = true;
            btnAddItem.Visible = false;
            grdItems.Visible = true;
            btnCancelItems.Visible = true;
            btnAdd.Visible = true;
            orderDetails.Visible = true;
            grdOrders.Visible = true;
            txtName.Text = "";
            txtDescription.Text = "";
            txtPurchaseLocation.Text = "";
            txtJustification.Text = "";
            txtPrice.Text = "";
            txtQuantity.Text = "";
            txtModReason.Text = "";
            grdItems.SelectedIndex = -1;
            lblMessage.Text = "";
            confirmation.Attributes.Add("style", "display:none");

            if (!txtEmployee.Text.Equals(Session["EmployeeName"]))
            {
                btnAdd.Enabled = false;
            }
            else
            {
                btnAdd.Enabled = true;
            }

            foreach (GridViewRow row in grdItems.Rows)
            {
                if (!row.Cells[11].Text.Equals("Pending"))
                {
                    grdItems.Rows[row.RowIndex].BackColor = System.Drawing.Color.Gray;
                }
            }
        }
      
        #endregion

        #region Add/Modify/Remove Items

        protected void btnAddItem_Click(object sender, EventArgs e)
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
                                    tmpItem = item;

                                    txtName.Focus();
                                }
                            }

                            if (!tmpItem.Status.Equals("Pending"))
                            {
                                confirmation.Attributes.Add("style", "display:block");
                                lblMessage.Text = "Cannot modify item if its status is not set to Pending";
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
                                    confirmation.Attributes.Add("style", "display:block");
                                    lblMessage.Text = "Item #" + tmpItem.ItemId + " successfully updated. Purchase Order totals have also been updated";

                                    grdOrders.Rows[grdOrders.SelectedRow.RowIndex].Cells[4].Text = Order.Subtotal.ToString();
                                    grdOrders.Rows[grdOrders.SelectedRow.RowIndex].Cells[5].Text = Order.Taxes.ToString();
                                    grdOrders.Rows[grdOrders.SelectedRow.RowIndex].Cells[6].Text = Order.Total.ToString();

                                    grdItems.DataSource = ItemList;
                                    grdItems.DataBind();
                                    grdItems.Visible = true;
                                    grdOrders.Visible = true;
                                    orderDetails.Visible = true;
                                    itemInformation.Visible = true;
                                    txtName.Text = "";
                                    txtDescription.Text = "";
                                    txtPurchaseLocation.Text = "";
                                    txtJustification.Text = "";
                                    txtPrice.Text = "";
                                    txtQuantity.Text = "";

                                    if (!Order.Status.Equals("Closed"))
                                    {
                                        foreach (Item item in ItemList)
                                        {
                                            if (!item.Description.Equals("No longer needed"))
                                            {
                                                grdItems.Rows[ItemList.IndexOf(item)].Cells[11].Text = "Pending";
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
                                confirmation.Attributes.Add("style", "display:block");
                                lblMessage.Text = "Item #" + itemId + " successfully added to Order #" + tmpItem.OrderNumber + ". Purchase Order totals have also been updated";

                                grdOrders.Rows[grdOrders.SelectedRow.RowIndex].Cells[4].Text = Order.Subtotal.ToString();
                                grdOrders.Rows[grdOrders.SelectedRow.RowIndex].Cells[5].Text = Order.Taxes.ToString();
                                grdOrders.Rows[grdOrders.SelectedRow.RowIndex].Cells[6].Text = Order.Total.ToString();

                                grdItems.DataSource = ItemList;
                                grdItems.DataBind();

                                grdItems.Visible = true;
                                grdOrders.Visible = true;
                                orderDetails.Visible = true;
                                itemInformation.Visible = true;
                                txtName.Text = "";
                                txtDescription.Text = "";
                                txtPurchaseLocation.Text = "";
                                txtJustification.Text = "";
                                txtPrice.Text = "";
                                txtQuantity.Text = "";
                            }
                        }
                    }
                    else
                    {
                        confirmation.Attributes.Add("style", "display:block");
                        lblMessage.Text = "Please fill in all fields properly before adding a new item";
                        grdItems.Visible = true;
                        grdOrders.Visible = true;
                        orderDetails.Visible = true;
                        itemInformation.Visible = true;
                    }
                }
                else
                {
                    confirmation.Attributes.Add("style", "display:block");
                    lblMessage.Text = "Please fill in all fields properly before adding a new item";
                    grdItems.Visible = true;
                    grdOrders.Visible = true;
                    orderDetails.Visible = true;
                    itemInformation.Visible = true;
                }
            }
            catch (Exception ex)
            {
                confirmation.Attributes.Add("style", "display:block");
                lblMessage.Text = ex.Message + ". An error has occurred";
            }
        }

        protected void btnModify_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtName.Text != string.Empty && txtDescription.Text != string.Empty && txtPurchaseLocation.Text != string.Empty &&
                    txtJustification.Text != string.Empty && txtPrice.Text != string.Empty && IsNumeric(txtPrice.Text) &&
                    txtQuantity.Text != string.Empty && Convert.ToInt32(txtQuantity.Text) > 0 && IsNumeric(txtQuantity.Text))
                {
                    int gridItemIndex = grdItems.SelectedRow.RowIndex;
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

                        bool result = false;

                        if (txtEmployee.Text != Session["EmployeeName"].ToString())
                        {
                            if (txtModReason.Text == string.Empty)
                            {
                                confirmation.Attributes.Add("style", "display:block");
                                lblMessage.Text = "Supervisor must supply a reason for modifying an employee's item";
                                grdItems.DataSource = ItemList;
                                grdItems.DataBind();
                                grdItems.Visible = true;
                                grdOrders.Visible = true;
                                orderDetails.Visible = true;
                                itemInformation.Visible = true;
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
                            confirmation.Attributes.Add("style", "display:block");
                            lblMessage.Text = "Item #" + listItem.ItemId + " successfully updated. Purchase Order totals have also been updated";

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

                            grdOrders.Rows[grdOrders.SelectedRow.RowIndex].Cells[4].Text = Order.Subtotal.ToString();
                            grdOrders.Rows[grdOrders.SelectedRow.RowIndex].Cells[5].Text = Order.Taxes.ToString();
                            grdOrders.Rows[grdOrders.SelectedRow.RowIndex].Cells[6].Text = Order.Total.ToString();

                            grdItems.DataSource = ItemList;
                            grdItems.DataBind();
                            grdItems.Visible = true;
                            grdOrders.Visible = true;
                            orderDetails.Visible = true;
                            itemInformation.Visible = true;
                        }
                    }
                }
                else
                {
                    confirmation.Attributes.Add("style", "display:block");
                    lblMessage.Text = "Error modifying item. Please make sure all fields are filled in properly";
                    grdItems.DataSource = ItemList;
                    grdItems.DataBind();
                    grdItems.Visible = true;
                    grdOrders.Visible = true;
                    orderDetails.Visible = true;
                    itemInformation.Visible = true;
                }
            }
            catch (Exception ex)
            {
                grdItems.Visible = true;
                grdOrders.Visible = true;
                orderDetails.Visible = true;
                itemInformation.Visible = true;
                confirmation.Attributes.Add("style", "display:block");
                lblMessage.Text = "Error modifying item. Please make sure all fields are filled in properly";
            }
        }

        protected void grdItems_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[9].Visible = false;
            e.Row.Cells[10].Visible = false;

            foreach (GridViewRow row in grdItems.Rows)
            {
                if (!Order.Status.Equals("Closed"))
                {
                    if (!row.Cells[11].Text.Equals("Pending"))
                    {
                        if (!row.Cells[4].Text.Equals("No longer needed"))
                        {
                            grdItems.Rows[row.RowIndex].Cells[11].Text = "Pending";
                            grdItems.Rows[row.RowIndex].BackColor = System.Drawing.Color.White;
                        }
                        else
                        {
                            grdItems.Rows[row.RowIndex].BackColor = System.Drawing.Color.Gray;
                        }
                    }

                    btnAdd.Enabled = true;
                }
                else
                {
                    if (!row.Cells[11].Text.Equals("Pending"))
                    {
                        grdItems.Rows[row.RowIndex].BackColor = System.Drawing.Color.Gray;
                    }

                    grdItems.Rows[row.RowIndex].Enabled = false; ;
                    btnAdd.Enabled = false;
                }
            }

        }

        protected void grdItems_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                int gridItemIndex = e.RowIndex;
                Item listItem = ItemList[gridItemIndex];

                if (!listItem.Status.Equals("Denied") && !listItem.Description.Equals("No longer needed"))
                {
                    if (grdItems.Rows[gridItemIndex].Cells[11].Text.Equals("Pending"))
                    {
                        if (tmpItem.Status.Equals("Pending"))
                        {
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

                            grdOrders.Rows[grdOrders.SelectedRow.RowIndex].Cells[4].Text = Order.Subtotal.ToString();
                            grdOrders.Rows[grdOrders.SelectedRow.RowIndex].Cells[5].Text = Order.Taxes.ToString();
                            grdOrders.Rows[grdOrders.SelectedRow.RowIndex].Cells[6].Text = Order.Total.ToString();

                            bool result = ItemFactory.EmployeeRemoveItem(listItem, Order);

                            if (result == true)
                            {
                                if (ItemList.Count > 0)
                                {
                                    ItemList = ItemFactory.RetrieveByOrderNumber(tmpItem.OrderNumber);
                                    grdItems.DataSource = ItemList;
                                    grdItems.DataBind();

                                    foreach (GridViewRow row in grdItems.Rows)
                                    {
                                        if (!Order.Status.Equals("Closed"))
                                        {
                                            if (!row.Cells[11].Text.Equals("Pending"))
                                            {
                                                if (!row.Cells[4].Text.Equals("No longer needed"))
                                                {
                                                    grdItems.Rows[row.RowIndex].Cells[11].Text = "Pending";
                                                    grdItems.Rows[row.RowIndex].BackColor = System.Drawing.Color.White;
                                                }
                                                else
                                                {
                                                    grdItems.Rows[row.RowIndex].BackColor = System.Drawing.Color.Gray;
                                                }
                                            }

                                            btnAdd.Enabled = true;
                                        }
                                        else
                                        {
                                            if (!row.Cells[11].Text.Equals("Pending"))
                                            {
                                                grdItems.Rows[row.RowIndex].BackColor = System.Drawing.Color.Gray;
                                            }

                                            grdItems.Rows[row.RowIndex].Enabled = false; ;
                                            btnAdd.Enabled = false;
                                        }
                                    }

                                    confirmation.Attributes.Add("style", "display:block");
                                    lblMessage.Text = "Item quantity successfully updated to zero";
                                    itemInformation.Visible = false;
                                    grdItems.Visible = true;
                                    grdItems.Enabled = true;
                                    btnCancelItems.Visible = true;
                                    btnCancelItems.Enabled = true;
                                    btnAdd.Visible = true;
                                    btnAdd.Enabled = true;
                                    txtNumber.Focus();
                                    txtName.Text = "";
                                    txtDescription.Text = "";
                                    txtPurchaseLocation.Text = "";
                                    txtJustification.Text = "";
                                    txtPrice.Text = "";
                                    txtQuantity.Text = "";
                                    txtModReason.Text = "";
                                }
                            }
                        }
                        else
                        {
                            confirmation.Attributes.Add("style", "display:block");
                            lblMessage.Text = "Item is currently under review and cannot be modified";
                            itemInformation.Visible = false;
                            orderDetails.Visible = true;
                            grdItems.Visible = true;
                            grdItems.Enabled = true;
                            btnCancelItems.Visible = true;
                            btnCancelItems.Enabled = true;
                            btnAdd.Visible = true;
                            btnAdd.Enabled = true;
                        }
                    }
                    else
                    {
                        confirmation.Attributes.Add("style", "display:block");
                        lblMessage.Text = "Cannot remove item if its status is not set to Pending";
                        itemInformation.Visible = false;
                        orderDetails.Visible = true;
                        grdItems.Visible = true;
                        grdItems.Enabled = true;
                        btnCancelItems.Visible = true;
                        btnCancelItems.Enabled = true;
                        btnAdd.Visible = true;
                        btnAdd.Enabled = true;
                    }       
                }
                else
                {
                    confirmation.Attributes.Add("style", "display:block");
                    lblMessage.Text = "Item has already been removed from the purchase order";
                    itemInformation.Visible = false;
                    grdItems.Visible = true;
                    grdItems.Enabled = true;
                    btnCancelItems.Visible = true;
                    btnCancelItems.Enabled = true;
                    btnAdd.Visible = true;
                    btnAdd.Enabled = true;
                }
                
            }
            catch (Exception ex)
            {
                confirmation.Attributes.Add("style", "display:block");
                lblMessage.Text = "An error has occurred. " + ex.Message;
                itemInformation.Visible = false;
                orderDetails.Visible = true;
                grdItems.Visible = true;
                grdItems.Enabled = true;
                btnCancelItems.Visible = true;
                btnCancelItems.Enabled = true;
                btnAdd.Visible = true;
                btnAdd.Enabled = true;
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

        public static bool IsNumeric(string input)
        {
            int test;
            return int.TryParse(input, out test);
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session["auth"] = false;
            Session["EmployeeName"] = null;
            Session["AccessLevel"] = null;
            Session["EmployeeInfo"] = null;
            Response.Redirect("Login.aspx", false);
        }

        protected void rblStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rblStatus.SelectedValue == "A")
            {
                txtFilter.Text = "A";
            }
            else if (rblStatus.SelectedValue == "P")
            {
                txtFilter.Text = "P";
            }
            else if (rblStatus.SelectedValue == "C")
            {
                txtFilter.Text = "C";
            }
        }

        #endregion

        #region Persist Data

        public List<PurchaseOrder> OrderList
        {
            get
            {
                String PersistentName = "List_OrderList";
                if (ViewState[PersistentName] == null || !(ViewState[PersistentName] is List<PurchaseOrder>))
                {
                    ViewState[PersistentName] = PurchaseOrderFactory.CreateList();
                }
                return ViewState[PersistentName] as List<PurchaseOrder>;
            }
            set
            {
                ViewState["List_OrderList"] = value;
            }
        }

        public List<PurchaseOrder> ListView_OrderList_GetData()
        {
            return OrderList;
        }

        public PurchaseOrder Order
        {
            get
            {
                String PersistentName = "Order";
                if (ViewState[PersistentName] == null || !(ViewState[PersistentName] is PurchaseOrder))
                {
                    ViewState[PersistentName] = PurchaseOrderFactory.Create();
                }
                return ViewState[PersistentName] as PurchaseOrder;
            }
            set
            {
                ViewState["Order"] = value;
            }
        }

        public PurchaseOrder Order_GetData()
        {
            return Order;
        }

        public List<Item> ItemList
        {
            get
            {
                String PersistentName = "List_ItemList";
                if (ViewState[PersistentName] == null || !(ViewState[PersistentName] is List<Item>))
                {
                    ViewState[PersistentName] = ItemFactory.CreateList();
                }
                return ViewState[PersistentName] as List<Item>;
            }
            set
            {
                ViewState["List_ItemList"] = value;
            }
        }

        public List<Item> ListView_ItemList_GetData()
        {
            return ItemList;
        }

        public Item tmpItem
        {
            get
            {
                String PersistentName = "Item";
                if (ViewState[PersistentName] == null || !(ViewState[PersistentName] is Item))
                {
                    ViewState[PersistentName] = ItemFactory.Create();
                }
                return ViewState[PersistentName] as Item;
            }
            set
            {
                ViewState["Item"] = value;
            }
        }

        public Item Item_GetData()
        {
            return tmpItem;
        }

        #endregion
  
    }
}