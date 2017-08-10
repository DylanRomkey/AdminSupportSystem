using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FrontEndWeb.Properties;
using BOL;

namespace FrontEndWeb
{
    public partial class Login : System.Web.UI.Page
    {
        List<Employee> employeeList = EmployeeFactory.RetrieveList();

        #region Form Load

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Convert.ToInt32(Request.QueryString["message"]) == 1)
            {
                lblMessage.Text = "You do not have access to the page your are requesting. Please login as an authorized user and try again";
            }
            else if (Convert.ToInt32(Request.QueryString["message"]) == 2)
            {
                lblMessage.Text = "The company's CEO cannot create or make modifications to purchase orders. Please inform your assistant of your needs";
            }
            else
            {
                lblMessage.Text = string.Empty;
            }

            if (!IsPostBack)
            {
                foreach (Employee tmpEmployee in employeeList)
                {
                    ddlUser.Items.Add(tmpEmployee.FirstName + " " + tmpEmployee.LastName);
                }

                txtPassword.Text = "********";
                ddlUser.SelectedIndex = 0;
                Session["auth"] = false;  
            }        
        }

        #endregion

        #region Buttons

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
                Session["EmployeeInfo"] = EmployeeFactory.RetrieveByName(firstName, lastName);

                Response.Redirect("Default.aspx", false);
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message + " " + ex.GetType().ToString();
            }
        }

        #endregion

    }
}