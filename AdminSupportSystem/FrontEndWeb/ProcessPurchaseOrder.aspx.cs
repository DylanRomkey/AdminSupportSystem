using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BOL;
using System.Net.Mail;

namespace FrontEndWeb
{
    public partial class ProcessPurchaseOrder : System.Web.UI.Page
    {
        #region Load

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["EmployeeName"] != null)
            {
                if (Session["AccessLevel"].Equals("S") || Session["AccessLevel"].Equals("C"))
                {
                    btnCancelSearch.Visible = false;
                    orderDetails.Visible = false;
                    grdItems.Visible = false;
                    grdOrders.Visible = false;
                    items.Visible = false;
                    pnlDeny.Visible = false;
                    pnlClose.Attributes.Add("style", "display:none");
                    confirmation.Attributes.Add("style", "display:none");

                    if (!Page.IsPostBack)
                    {
                        rblStatus.SelectedIndex = 1;
                        txtFilter.Text = "P";
                    }
                }
                else
                {
                    Response.Redirect("Login.aspx?message=1", false);
                }
            }
            else
            {
                Response.Redirect("Login.aspx", false);
            }
        }

        #endregion

        #region Search Purchase Orders

        protected void btnSearchDates_Click(object sender, EventArgs e)
        {
            try
            {
                OrderList.Clear();

                String[] names = Session["EmployeeName"].ToString().Split(' ');
                string firstName = names[0];
                string lastName = names[1];

                Employee OrderEmployee = EmployeeFactory.RetrieveByName(firstName, lastName);

                if (Session["AccessLevel"].ToString().Equals("C"))
                {
                    if (dtpStartDate.SelectedDate.ToString().Equals("0001-01-01 12:00:00 AM") && dtpEndDate.SelectedDate.ToString().Equals("0001-01-01 12:00:00 AM"))
                    {
                        OrderList = PurchaseOrderFactory.RetrieveOrdersForProcessing(DateTime.MinValue, DateTime.MinValue, OrderEmployee.Id, txtFilter.Text, txtEmployeeName.Text, "C");
                    }
                    else if (dtpStartDate.SelectedDate.ToString().Equals("0001-01-01 12:00:00 AM") && !dtpEndDate.SelectedDate.ToString().Equals("0001-01-01 12:00:00 AM"))
                    {
                        OrderList = PurchaseOrderFactory.RetrieveOrdersForProcessing(DateTime.MinValue, dtpEndDate.SelectedDate, OrderEmployee.Id, txtFilter.Text, txtEmployeeName.Text, "C");
                    }
                    else if (!dtpStartDate.SelectedDate.ToString().Equals("0001-01-01 12:00:00 AM") && dtpEndDate.SelectedDate.ToString().Equals("0001-01-01 12:00:00 AM"))
                    {
                        OrderList = PurchaseOrderFactory.RetrieveOrdersForProcessing(dtpStartDate.SelectedDate, DateTime.MinValue, OrderEmployee.Id, txtFilter.Text, txtEmployeeName.Text, "C");
                    }
                    else if (!dtpStartDate.SelectedDate.ToString().Equals("0001-01-01 12:00:00 AM") && !dtpEndDate.SelectedDate.ToString().Equals("0001-01-01 12:00:00 AM"))
                    {
                        OrderList = OrderList = PurchaseOrderFactory.RetrieveOrdersForProcessing(dtpStartDate.SelectedDate, dtpEndDate.SelectedDate, OrderEmployee.Id, txtFilter.Text, txtEmployeeName.Text, "C");
                    }
                }
                else
                {
                    if (dtpStartDate.SelectedDate.ToString().Equals("0001-01-01 12:00:00 AM") && dtpEndDate.SelectedDate.ToString().Equals("0001-01-01 12:00:00 AM"))
                    {
                        OrderList = PurchaseOrderFactory.RetrieveOrdersForProcessing(DateTime.MinValue, DateTime.MinValue, OrderEmployee.Id, txtFilter.Text, txtEmployeeName.Text, "S");
                    }
                    else if (dtpStartDate.SelectedDate.ToString().Equals("0001-01-01 12:00:00 AM") && !dtpEndDate.SelectedDate.ToString().Equals("0001-01-01 12:00:00 AM"))
                    {
                        OrderList = PurchaseOrderFactory.RetrieveOrdersForProcessing(DateTime.MinValue, dtpEndDate.SelectedDate, OrderEmployee.Id, txtFilter.Text, txtEmployeeName.Text, "S");
                    }
                    else if (!dtpStartDate.SelectedDate.ToString().Equals("0001-01-01 12:00:00 AM") && dtpEndDate.SelectedDate.ToString().Equals("0001-01-01 12:00:00 AM"))
                    {
                        OrderList = PurchaseOrderFactory.RetrieveOrdersForProcessing(dtpStartDate.SelectedDate, DateTime.MinValue, OrderEmployee.Id, txtFilter.Text, txtEmployeeName.Text, "S");
                    }
                    else if (!dtpStartDate.SelectedDate.ToString().Equals("0001-01-01 12:00:00 AM") && !dtpEndDate.SelectedDate.ToString().Equals("0001-01-01 12:00:00 AM"))
                    {
                        OrderList = PurchaseOrderFactory.RetrieveOrdersForProcessing(dtpStartDate.SelectedDate, dtpEndDate.SelectedDate, OrderEmployee.Id, txtFilter.Text, txtEmployeeName.Text, "S");
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
                    searchPanel.Enabled = false;
                    lblMessage.Text = "";
                    confirmation.Attributes.Add("style", "display:none");

                    for (int i = 0; i < OrderList.Count; i++)
                    {
                        OrdersForProcessing tmpOrder = OrderList[i];

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

        protected void grdOrders_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                OrdersForProcessing rowOrder = null;
                int RowIndex = Convert.ToInt32(e.CommandArgument);
                rowOrder = OrderList[RowIndex];
                
                ItemList.Clear();
                ItemList = ItemFactory.RetrieveByOrderNumber(rowOrder.OrderNumber);

                Employee OrderEmployee = EmployeeFactory.RetrieveByOrderNumber(rowOrder.OrderNumber);
                txtEmployee.Text = OrderEmployee.FirstName + " " + OrderEmployee.LastName;

                Order = PurchaseOrderFactory.RetrieveByNumber(rowOrder.OrderNumber, OrderEmployee.Id);
                grdItems.DataSource = ItemList;
                grdItems.DataBind();
                orderDetails.Visible = true;
                searchPanel.Attributes.Add("style", "display:none");

                foreach (Item item in ItemList)
                {
                    if (item.Status.Equals("Pending"))
                    {
                        grdItems.Rows[ItemList.IndexOf(item)].BackColor = System.Drawing.Color.White;
                    }
                    else if (item.Status.Equals("Approved"))
                    {
                        grdItems.Rows[ItemList.IndexOf(item)].BackColor = System.Drawing.Color.LightGreen;
                    }
                    else if (item.Status.Equals("Denied"))
                    {
                        grdItems.Rows[ItemList.IndexOf(item)].BackColor = System.Drawing.Color.Red;
                    }
                }

                txtPONumber.Text = Order.OrderNumber.ToString();
                txtCreationDate.Text = Order.OrderDate.ToShortDateString();
                txtStatus.Text = Order.Status;
                txtSubtotal.Text = String.Format("{0:C}", Order.Subtotal);
                txtTaxes.Text = String.Format("{0:C}", Order.Taxes);
                txtTotal.Text = String.Format("{0:C}", Order.Total);

                grdItems.Visible = true;
                items.Visible = true;
                grdItems.SelectedIndex = -1;
                grdOrders.Visible = true;
                txtPONumber.Visible = true;
                lblPONumber.Visible = true;
                btnCancelItems.Visible = true;
                btnClose.Visible = true;
                grdOrders.Enabled = false;
                btnCancelSearch.Enabled = false;

                if (Order.Status.Equals("Closed"))
                {
                    foreach (GridViewRow row in grdItems.Rows)
                    {
                        grdItems.Rows[row.RowIndex].Enabled = false;
                    }

                    btnClose.Enabled = false;
                }
                else if (txtEmployee.Text.Equals(Session["EmployeeName"]))
                {
                    foreach (GridViewRow row in grdItems.Rows)
                    {
                        grdItems.Rows[row.RowIndex].Enabled = false;
                    }

                    btnClose.Enabled = false;

                    confirmation.Attributes.Add("style", "display:block");
                    lblMessage.Text = "Supervisors are unable to process their own purchase orders. Please contact your " +
                        "superior to process the order for you. You are able to view the items that you have requested";
                }
                else
                {
                    foreach (GridViewRow row in grdItems.Rows)
                    {
                        grdItems.Rows[row.RowIndex].Enabled = true;
                    }

                    btnClose.Enabled = true;
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
            grdOrders.DataSource = null;
            grdOrders.Visible = false;
            btnCancelSearch.Visible = false;
            searchPanel.Enabled = true;
            dtpStartDate.SelectedValue = null;
            dtpEndDate.SelectedValue = null;
            txtEmployeeName.Text = "";
            rblStatus.SelectedValue = "P";
            txtFilter.Text = "P";
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
            lblMessage.Text = "";
            confirmation.Attributes.Add("style", "display:none");
        }

        protected void grdItems_RowCreated(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[11].Visible = false;
        }

        #endregion

        #region Process Items

        protected void grdItems_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int RowIndex = Convert.ToInt32(e.CommandArgument);
            grdItems.SelectedIndex = RowIndex;

            string[] names = Session["EmployeeName"].ToString().Split(' ');
            string firstName = names[0];
            string lastName = names[1];

            Employee OrderEmployee = EmployeeFactory.RetrieveByName(firstName, lastName);

            if (e.CommandName == "Approve")
            {
                try
                {
                    int gridItemIndex = Convert.ToInt32(e.CommandArgument);
                    Item listItem = ItemList[gridItemIndex];

                    if (listItem.Status.Equals("Approved"))
                    {
                        confirmation.Attributes.Add("style", "display:block");
                        lblMessage.Text = "Item status is already set to Approved";
                        orderDetails.Visible = true;
                        items.Visible = true;
                        grdItems.Visible = true;
                        grdItems.Enabled = true;
                        grdOrders.Visible = true;
                        grdItems.SelectedIndex = -1;
                    }
                    else if (listItem.Description.Equals("No longer needed"))
                    {
                        confirmation.Attributes.Add("style", "display:block");
                        lblMessage.Text = "Item has been marked as no longer needed by the employee. Unable to process";
                        orderDetails.Visible = true;
                        items.Visible = true;
                        grdItems.Visible = true;
                        grdItems.Enabled = true;
                        grdOrders.Visible = true;
                        grdItems.SelectedIndex = -1;
                    }
                    else
                    {
                        listItem.Status = "Approved";
                        Order.Status = "Under Review";
                        int itemIndex = ItemList.IndexOf(listItem);
                        ItemList[itemIndex] = listItem;

                        bool result = ItemFactory.ApproveItem(listItem, OrderEmployee.Id);

                        if (result == true)
                        {
                            confirmation.Attributes.Add("style", "display:block");
                            lblMessage.Text = "Item status has been successfully updated to Approved";
                            orderDetails.Visible = true;
                            items.Visible = true;
                            grdItems.Visible = true;
                            grdItems.Enabled = true;
                            grdOrders.Visible = true;
                            grdItems.Rows[itemIndex].Cells[12].Text = listItem.Status;
                            grdItems.Rows[itemIndex].BackColor = System.Drawing.Color.LightGreen;
                            grdOrders.Rows[grdOrders.SelectedRow.RowIndex].Cells[5].Text = Order.Status;
                            grdItems.SelectedIndex = -1;

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
                                pnlClose.Attributes.Add("style", "display:block");
                                orderDetails.Visible = false;
                                items.Visible = false;
                                grdItems.Visible = false;
                                grdItems.Enabled = false;
                                grdOrders.Visible = false;
                                grdItems.SelectedIndex = -1;
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
            else if (e.CommandName == "Deny")
            {
                try
                {
                    Item listItem = ItemList[RowIndex];

                    if (listItem.Description.Equals("No longer needed"))
                    {
                        confirmation.Attributes.Add("style", "display:block");
                        lblMessage.Text = "Item has been marked as no longer needed by the employee. Unable to process";
                        orderDetails.Visible = true;
                        items.Visible = true;
                        grdItems.Visible = true;
                        grdItems.Enabled = true;
                        grdOrders.Visible = true;
                        grdItems.SelectedIndex = -1;
                    }
                    else if (listItem.Status.Equals("Denied"))
                    {
                        confirmation.Attributes.Add("style", "display:block");
                        lblMessage.Text = "Item status is already set to Denied";
                        orderDetails.Visible = true;
                        items.Visible = true;
                        grdItems.Visible = true;
                        grdItems.Enabled = true;
                        grdOrders.Visible = true;
                        grdItems.SelectedIndex = -1;
                    }
                    else
                    {
                        pnlDeny.Visible = true;
                        grdItems.Enabled = false;
                        btnCancelItems.Enabled = false;
                        grdItems.Enabled = false;
                        btnClose.Enabled = false;
                        items.Visible = true;
                        grdItems.Visible = true;
                        grdOrders.Visible = true;
                        items.Enabled = false;
                        orderDetails.Visible = true;
                        txtDeny.Focus();
                    }
                }
                catch (Exception ex)
                {
                    confirmation.Attributes.Add("style", "display:block");
                    lblMessage.Text = "An error has occurred. " + ex.Message;
                } 
            }
            else if (e.CommandName == "Pending")
            {
                try
                {
                    int gridItemIndex = Convert.ToInt32(e.CommandArgument);
                    Item listItem = ItemList[gridItemIndex];

                    if (listItem.Status.Equals("Pending"))
                    {
                        confirmation.Attributes.Add("style", "display:block");
                        lblMessage.Text = "Item status is already set to Pending";
                        orderDetails.Visible = true;
                        items.Visible = true;
                        grdItems.Visible = true;
                        grdItems.Enabled = true;
                        grdOrders.Visible = true;
                        grdItems.SelectedIndex = -1;
                    }
                    else if (listItem.Description.Equals("No longer needed"))
                    {
                        confirmation.Attributes.Add("style", "display:block");
                        lblMessage.Text = "Item has been marked as no longer needed by the employee. Unable to process";
                        orderDetails.Visible = true;
                        items.Visible = true;
                        grdItems.Visible = true;
                        grdItems.Enabled = true;
                        grdOrders.Visible = true;
                        grdItems.SelectedIndex = -1;
                    }
                    else
                    {
                        listItem.Status = "Pending";
                        int itemIndex = ItemList.IndexOf(listItem);
                        ItemList[itemIndex] = listItem;

                        bool result = ItemFactory.PendingItem(listItem, OrderEmployee.Id);

                        if (result == true)
                        {
                            confirmation.Attributes.Add("style", "display:block");
                            lblMessage.Text = "Item status has been successfully updated to Pending";
                            grdItems.Rows[itemIndex].Cells[12].Text = listItem.Status;
                            grdItems.Rows[itemIndex].BackColor = System.Drawing.Color.White;
                            orderDetails.Visible = true;
                            items.Visible = true;
                            grdItems.Visible = true;
                            grdItems.Enabled = true;
                            grdOrders.Visible = true;
                            grdItems.SelectedIndex = -1;

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
                                grdOrders.Rows[grdOrders.SelectedRow.RowIndex].Cells[5].Text = Order.Status;
                                grdOrders.Rows[grdOrders.SelectedRow.RowIndex].BackColor = System.Drawing.Color.White;
                                confirmation.Attributes.Add("style", "display:block");
                                lblMessage.Text = "All items have a Pending status. Purchase order status has been set back to Pending";
                                orderDetails.Visible = true;
                                items.Visible = true;
                                grdItems.Visible = true;
                                grdItems.Enabled = true;
                                grdOrders.Visible = true;
                                grdItems.SelectedIndex = -1;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    confirmation.Attributes.Add("style", "display:block");
                    lblMessage.Text = "An error has occurred. " + ex.Message;
                    orderDetails.Visible = true;
                    items.Visible = true;
                    grdItems.Visible = true;
                    grdItems.Enabled = true;
                    grdOrders.Visible = true;
                }
            }
        }

        protected void btnDenyFinal_Click(object sender, EventArgs e)
        {
            try
            {
                string[] names = Session["EmployeeName"].ToString().Split(' ');
                string firstName = names[0];
                string lastName = names[1];

                Employee OrderEmployee = EmployeeFactory.RetrieveByName(firstName, lastName);

                if (txtDeny.Text != string.Empty)
                {
                    int gridItemIndex = grdItems.SelectedRow.RowIndex;
                    Item listItem = ItemList[gridItemIndex];

                    if (listItem.Description.Equals("No longer needed"))
                    {
                        confirmation.Attributes.Add("style", "display:block");
                        lblMessage.Text = "Item has been marked as no longer needed by the employee. Unable to process";
                        grdItems.SelectedIndex = -1;
                    }
                    else if (listItem.Status.Equals("Denied"))
                    {
                        confirmation.Attributes.Add("style", "display:block");
                        lblMessage.Text = "Item status is already set to Denied";
                        grdItems.SelectedIndex = -1;
                    }
                    else
                    {
                        listItem.Status = "Denied";
                        Order.Status = "Under Review";
                        listItem.ModificationReason = txtDeny.Text;
                        int itemIndex = ItemList.IndexOf(listItem);
                        ItemList[itemIndex] = listItem;

                        bool result = ItemFactory.DenyItem(listItem, OrderEmployee.Id, listItem.ModificationReason);

                        if (result == true)
                        {
                            confirmation.Attributes.Add("style", "display:block");
                            lblMessage.Text = "Item status has been successfully updated to Denied";
                            orderDetails.Visible = true;
                            items.Visible = true;
                            grdItems.Visible = true;
                            grdItems.Enabled = true;
                            grdOrders.Visible = true;
                            grdItems.SelectedIndex = -1;
                            grdItems.Rows[itemIndex].Cells[12].Text = listItem.Status;
                            grdItems.Rows[itemIndex].Cells[5].Text = listItem.Description;
                            grdItems.Rows[itemIndex].Cells[10].Text = listItem.ModificationReason;
                            grdItems.Rows[itemIndex].BackColor = System.Drawing.Color.Red;
                            grdOrders.Rows[grdOrders.SelectedRow.RowIndex].Cells[5].Text = Order.Status;
                            btnCancelDeny_Click(btnCancelDeny, EventArgs.Empty);

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
                                pnlClose.Attributes.Add("style", "display:block");
                                orderDetails.Visible = false;
                                items.Visible = false;
                                grdItems.Visible = false;
                                grdItems.Enabled = false;
                                grdOrders.Visible = false;
                                grdItems.SelectedIndex = -1;
                            }
                        }
                    }
                }
                else
                {
                    confirmation.Attributes.Add("style", "display:block");
                    lblMessage.Text = "Please enter a reason for item denial";
                    orderDetails.Visible = true;
                    items.Visible = true;
                    grdItems.Visible = true;
                    grdItems.Enabled = true;
                    grdOrders.Visible = true;
                }
            }
            catch (Exception ex)
            {
                confirmation.Attributes.Add("style", "display:block");
                lblMessage.Text = "An error has occurred. " + ex.Message;
                orderDetails.Visible = true;
                items.Visible = true;
                grdItems.Visible = true;
                grdItems.Enabled = true;
                grdOrders.Visible = true;
            }
        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
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
                    pnlClose.Attributes.Add("style", "display:block");
                    orderDetails.Visible = false;
                    items.Visible = false;
                    grdItems.Visible = false;
                    grdItems.Enabled = false;
                    grdOrders.Visible = false;
                }
                else
                {
                    confirmation.Attributes.Add("style", "display:block");
                    lblMessage.Text = "All items have not yet been processed. Unable to close purchase order";
                    orderDetails.Visible = true;
                    items.Visible = true;
                    grdItems.Visible = true;
                    grdItems.Enabled = true;
                    grdOrders.Visible = true;
                }
            }
            catch (Exception ex)
            {
                confirmation.Attributes.Add("style", "display:block");
                lblMessage.Text = "An error has occurred. " + ex.Message;
                orderDetails.Visible = true;
                items.Visible = true;
                grdItems.Visible = true;
                grdItems.Enabled = true;
                grdOrders.Visible = true;
            }
        }

        protected void btnCloseYes_Click(object sender, EventArgs e)
        {
            try
            {
                PurchaseOrderFactory.ClosePurchaseOrder(Order);
                Order.Status = "Closed";
                grdOrders.Rows[grdOrders.SelectedRow.RowIndex].Cells[5].Text = Order.Status;
                grdOrders.Rows[grdOrders.SelectedRow.RowIndex].BackColor = System.Drawing.Color.Gray;
                pnlClose.Attributes.Add("style", "display:none");
                btnCancelItems_Click(btnCancelItems, EventArgs.Empty);

                Employee OrderEmployee = EmployeeFactory.RetrieveByOrderNumber(Order.OrderNumber);
                PurchaseOrderFactory.EmailEmployee(OrderEmployee.Id, OrderEmployee.Email, Order.OrderNumber, Order.Total, ItemList);
                grdItems.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                btnCancelItems_Click(btnCancelItems, EventArgs.Empty);
                confirmation.Attributes.Add("style", "display:block");
                lblMessage.Text = "An error has occurred. " + ex.Message + " Order status still updated to Closed";
            }
        }

        protected void btnCloseNo_Click(object sender, EventArgs e)
        {
            orderDetails.Visible = true;
            items.Visible = true;
            grdItems.Visible = true;
            grdItems.Enabled = true;
            grdOrders.Visible = true;
            pnlClose.Attributes.Add("style", "display:none");
        }

        protected void btnCancelDeny_Click(object sender, EventArgs e)
        {
            txtDeny.Text = "";
            pnlDeny.Visible = false;
            items.Enabled = true;
            btnClose.Enabled = true;
            btnCancelItems.Enabled = true;
            orderDetails.Visible = true;
            items.Visible = true;
            grdItems.Visible = true;
            grdItems.Enabled = true;
            grdOrders.Visible = true;
            grdItems.Enabled = true;
            grdItems.SelectedIndex = -1;
        }

        protected void btnCancelItems_Click(object sender, EventArgs e)
        {
            grdItems.DataSource = null;
            grdItems.Visible = false;
            btnCancelItems.Visible = false;
            orderDetails.Visible = false;   
            btnCancelSearch.Visible = true;
            btnCancelSearch.Enabled = true;
            grdOrders.Enabled = true;
            grdOrders.Visible = true;
            btnClose.Visible = false;
            grdOrders.SelectedIndex = -1;
            searchPanel.Enabled = false;
            grdItems.SelectedIndex = -1;
            searchPanel.Attributes.Add("style", "display:block");
            confirmation.Attributes.Add("style", "display:none");
            lblMessage.Text = "";
        }

        #endregion

        #region Housekeeping

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

        public List<OrdersForProcessing> OrderList
        {
            get
            {
                String PersistentName = "List_OrderList";
                if (ViewState[PersistentName] == null || !(ViewState[PersistentName] is List<OrdersForProcessing>))
                {
                    ViewState[PersistentName] = PurchaseOrderFactory.CreateListForProcessing();
                }
                return ViewState[PersistentName] as List<OrdersForProcessing>;
            }
            set
            {
                ViewState["List_OrderList"] = value;
            }
        }

        public List<OrdersForProcessing> ListView_OrderList_GetData()
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