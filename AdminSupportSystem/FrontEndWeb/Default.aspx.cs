using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FrontEndWeb
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["EmployeeName"] == null)
            {
                Response.Redirect("Login.aspx", false);
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session["auth"] = false;
            Session["EmployeeName"] = null;
            Session["AccessLevel"] = null;
            Session["EmployeeInfo"] = null;
            Response.Redirect("Login.aspx", false);
        }
    }
}