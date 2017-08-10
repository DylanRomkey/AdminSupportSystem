using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BOL;
using UDT;
using VAL;

namespace FrontEndWeb
{
    public partial class CreatePurchaseOrder : System.Web.UI.Page
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
                    if (ItemList.Count > 0)
                    {
                        grdItems.Visible = true;
                        totals.Visible = true;
                    }
                    else
                    {
                        grdItems.Visible = false;
                        totals.Visible = false;
                    }

                    grdItems.DataSource = ItemList;
                    grdItems.DataBind();
                    txtDate.Text = DateTime.Now.ToShortDateString();
                    LoadEmployee();
                    confirmation.Attributes.Add("style", "display:none");
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

        #region Buttons

        protected void btnAdd_Click(object sender, EventArgs e)
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
                                        grdItems.Visible = true;
                                        grdItems.DataBind();
                                        totals.Visible = true;
                                        ClearInputs();
                                        txtName.Focus();

                                        CalculateTotals();
                                    }
                                }
                            }
                            else
                            {
                                grdItems.Visible = true;
                                totals.Visible = true;
                                ItemList.Add(tmpItem);
                                grdItems.DataBind();
                                ClearInputs();
                                txtName.Focus();

                                CalculateTotals();
                            }
                        }
                        else
                        {
                            grdItems.Visible = true;
                            totals.Visible = true;
                            ItemList.Add(tmpItem);
                            grdItems.DataBind();
                            ClearInputs();
                            txtName.Focus();

                            CalculateTotals();
                        }
                    }
                    confirmation.Attributes.Add("style", "display:none");
                    lblMessage.Text = "";
                }
                else
                {
                    confirmation.Attributes.Add("style", "display:block");
                    lblMessage.Text = "Item addition was unsuccessful. Please make sure all fields are filled in properly and resubmit";
                }
            }
            catch (Exception ex)
            {
                confirmation.Attributes.Add("style", "display:block");
                lblMessage.Text = "An error has occurred. " + ex.Message;
            }
        }

        protected void btnComplete_Click(object sender, EventArgs e)
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
                        confirmation.Attributes.Add("style", "display:block");
                        lblMessage.Text = "Purchase Order successfully submitted. Agreement ID is " + OrderNumber;
                        ClearInputs();
                        ItemList.Clear();
                        grdItems.DataSource = null;
                        ClearTotals();
                        totals.Visible = false;
                        grdItems.Visible = false;
                        txtName.Focus();
                    }
                }
                else
                {
                    confirmation.Attributes.Add("style", "display:block");
                    lblMessage.Text = "Please add items to Purchase Order before submitting";
                }
            }
            catch (Exception ex)
            {
                confirmation.Attributes.Add("style", "display:block");
                lblMessage.Text = "An error has occurred. " + ex.Message;
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            ItemList.Clear();
            grdItems.DataBind();
            ClearInputs();
            grdItems.Visible = false;
            ClearTotals();
            totals.Visible = false;
            confirmation.Attributes.Add("style", "display:none");
            lblMessage.Text = "";
            txtName.Focus();
        }

        #endregion

        #region GridView Events

        protected void grdItems_RowCreated(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[1].Visible = false;
            e.Row.Cells[3].Visible = false;
            e.Row.Cells[4].Visible = false;
            e.Row.Cells[5].Visible = false;
            e.Row.Cells[7].Visible = false;
            e.Row.Cells[8].Visible = false;
            e.Row.Cells[9].Visible = false;
            e.Row.Cells[10].Visible = false;
        }

        protected void grdItems_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            if (ItemList.Count > 0)
            {
                ItemList.RemoveAt(e.RowIndex);
                grdItems.DataBind();
                CalculateTotals();
                txtName.Focus();
            }

            if (grdItems.Rows.Count == 0)
            {
                ClearTotals();
                totals.Visible = false;
                grdItems.Visible = false;
                txtName.Focus();
            }
            lblMessage.Text = "";
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

        private void LoadEmployee()
        {
            string[] names = Session["EmployeeName"].ToString().Split(' ');
            string firstName = names[0];
            string lastName = names[1];
            tmpEmployee = EmployeeFactory.RetrieveByName(firstName, lastName);
            tmpDepartment = DepartmentFactory.RetrieveByEmployeeId(tmpEmployee.Id);

            txtEmployee.Text = tmpEmployee.FirstName + " " + tmpEmployee.LastName;
            txtDepartment.Text = tmpDepartment.Title;
            txtSupervisor.Text = tmpDepartment.SupervisorName;
        }

        public List<Item> ItemList
        {
            get
            {
                String PersistentName = "List_ItemList";
                if (ViewState[PersistentName] == null || !(ViewState[PersistentName] is List<Item>))
                {
                    ViewState[PersistentName] = new List<Item>();
                }
                return ViewState[PersistentName] as List<Item>;
            }
        }

        public List<Item> ListView_ItemList_GetData()
        {
            return ItemList;
        }

        private void ClearInputs()
        {
            txtName.Text = "";
            txtDescription.Text = "";
            txtPrice.Text = "";
            txtPurchaseLocation.Text = "";
            txtQuantity.Text = "";
            txtJustification.Text = "";
        }

        private void ClearTotals()
        {
            txtSubtotal.Text = "";
            txtTaxes.Text = "";
            txtTotal.Text = "";
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

        protected void btnClearItem_Click(object sender, EventArgs e)
        {
            txtName.Text = "";
            txtDescription.Text = "";
            txtPurchaseLocation.Text = "";
            txtJustification.Text = "";
            txtPrice.Text = "";
            txtQuantity.Text = "";
            txtName.Focus();
        }

        #endregion

    }
}