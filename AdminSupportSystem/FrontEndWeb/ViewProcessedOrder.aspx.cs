using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BOL;

namespace FrontEndWeb
{
    public partial class ViewProcessedOrder : System.Web.UI.Page
    {
        Employee tmpEmployee = EmployeeFactory.Create();
        Department tmpDepartment = DepartmentFactory.Create();

        #region Load

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Request.QueryString["employeeId"] != null && Request.QueryString["orderNumber"] != null)
                {
                    int employeeId = Convert.ToInt32(Request.QueryString["employeeId"]);
                    int orderNumber = Convert.ToInt32(Request.QueryString["orderNumber"]);
                    confirmation.Attributes.Add("style", "display:none");
                    login.Attributes.Add("style", "display:block");
                    processedDetails.Attributes.Add("style", "display:none");
                    orderDetails.Attributes.Add("style", "display:none");

                    if (!IsPostBack)
                    {
                        Employee orderEmployee = EmployeeFactory.RetrieveByOrderNumber(orderNumber);
                        ddlUser.Items.Add(orderEmployee.FirstName + " " + orderEmployee.LastName);
                        txtPassword.Text = "********";
                        Session["auth"] = false;
                        Session["EmployeeName"] = null;
                        Session["AccessLevel"] = null;
                    }        
                }
                else
                {
                    confirmation.Attributes.Add("style", "display:block");
                    lblMessage.Text = "Error retrieving Employee ID or Purchase Order Number. Please try again";
                    login.Attributes.Add("style", "display:none");
                    processedDetails.Attributes.Add("style", "display:none");
                    orderDetails.Attributes.Add("style", "display:none");
                    Session["auth"] = false;
                    Session["EmployeeName"] = null;
                    Session["AccessLevel"] = null;
                }
            }
            catch (Exception ex)
            {
                confirmation.Attributes.Add("style", "display:block");
                lblMessage.Text = "Error retrieving Employee ID or Purchase Order Number. Please try again";
                login.Attributes.Add("style", "display:none");
                processedDetails.Attributes.Add("style", "display:none");
                orderDetails.Attributes.Add("style", "display:none");
                Session["auth"] = false;
                Session["EmployeeName"] = null;
                Session["AccessLevel"] = null;
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                Session["auth"] = true;
                Session["EmployeeName"] = ddlUser.Text;

                string[] names = ddlUser.SelectedItem.ToString().Split(' ');
                string firstName = names[0];
                string lastName = names[1];

                Session["AccessLevel"] = EmployeeFactory.RetrieveAccessLevel(firstName, lastName);

                login.Attributes.Add("style", "display:none");
                processedDetails.Attributes.Add("style", "display:block");
                RetrieveItems(Convert.ToInt32(Request.QueryString["orderNumber"]));
            }
            catch (Exception ex)
            {
                confirmation.Attributes.Add("style", "display:block");
                lblMessage.Text = ex.Message + " " + ex.GetType().ToString();
            }
        }

        #endregion

        #region Items

        private void RetrieveItems(int orderNumber)
        {
            try
            {
                ItemList.Clear();
                ItemList = ItemFactory.RetrieveByOrderNumber(orderNumber);

                Employee tmpEmployee = EmployeeFactory.RetrieveByOrderNumber(orderNumber);
                tmpDepartment = DepartmentFactory.RetrieveByEmployeeId(tmpEmployee.Id);
                txtEmployee.Text = tmpEmployee.FirstName + " " + tmpEmployee.LastName;
                txtDepartment.Text = tmpDepartment.Title;
                txtSupervisor.Text = tmpDepartment.SupervisorName;

                Order = PurchaseOrderFactory.RetrieveByNumber(orderNumber, tmpEmployee.Id);
                grdItems.DataSource = ItemList;
                grdItems.DataBind();

                txtPONumber.Text = Order.OrderNumber.ToString();
                txtCreationDate.Text = Order.OrderDate.ToShortDateString();
                txtStatus.Text = Order.Status;
                txtSubtotal.Text = String.Format("{0:C}", Order.Subtotal);
                txtTaxes.Text = String.Format("{0:C}", Order.Taxes);
                txtTotal.Text = String.Format("{0:C}", Order.Total);

                orderDetails.Attributes.Add("style", "display:block");
                confirmation.Attributes.Add("style", "display:none");
                lblMessage.Text = "";
            }
            catch (Exception ex)
            {
                confirmation.Attributes.Add("style", "display:block");
                lblMessage.Text = ex.Message + " " + ex.GetType().ToString();
            }
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

        protected void grdItems_RowCreated(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[8].Visible = false;
        }

        #endregion

        #region Persist Data

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

        #endregion
        
    }
}