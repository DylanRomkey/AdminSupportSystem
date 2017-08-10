using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BOL;

namespace FrontEndWeb
{
    public partial class CalculatePension : System.Web.UI.Page
    {
        #region Load

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["EmployeeInfo"] != null)
                {
                    try
                    {
                        Employee currEmp = (Employee)Session["EmployeeInfo"];
                        lblId.Text = currEmp.Id.ToString();
                        lblEmployee.Text = currEmp.FirstName + (currEmp.MiddleName == "" ? "" : " " + currEmp.MiddleName + " ") + currEmp.LastName;
                        lblDob.Text = currEmp.DOB.ToShortDateString();
                        lblSenDate.Text = currEmp.SeniorityDate.ToShortDateString();

                        Pension currPen = PensionFactory.Retrieve(currEmp.Id);
                        lblPenDate.Text = currPen.FullRetire.ToShortDateString();
                        lblPension.Text = currPen.FullPension.ToString("C");

                        lbl55.Text = "";
                        lbl56.Text = "";
                        lbl57.Text = "";
                        lbl58.Text = "";
                        lbl59.Text = "";
                        if (currEmp.DOB.AddYears(55) > DateTime.Today)
                        {
                            lbl55.Text = currPen.At55.ToString("C");
                        }
                        if (currEmp.DOB.AddYears(56) > DateTime.Today)
                        {
                            lbl56.Text = currPen.At56.ToString("C");
                        }
                        if (currEmp.DOB.AddYears(57) > DateTime.Today)
                        {
                            lbl57.Text = currPen.At57.ToString("C");
                        }
                        if (currEmp.DOB.AddYears(58) > DateTime.Today)
                        {
                            lbl58.Text = currPen.At58.ToString("C");
                        }
                        if (currEmp.DOB.AddYears(59) > DateTime.Today)
                        {
                            lbl59.Text = currPen.At59.ToString("C");
                        }

                        lblYear1.Text = currPen.Year[0].ToString();
                        lblYear2.Text = currPen.Year[1].ToString();
                        lblYear3.Text = currPen.Year[2].ToString();
                        lblYear4.Text = currPen.Year[3].ToString();
                        lblYear5.Text = currPen.Year[4].ToString();

                        lblYear1G.Text = currPen.Gross[0].ToString("C");
                        lblYear2G.Text = currPen.Gross[1].ToString("C");
                        lblYear3G.Text = currPen.Gross[2].ToString("C");
                        lblYear4G.Text = currPen.Gross[3].ToString("C");
                        lblYear5G.Text = currPen.Gross[4].ToString("C");

                        chk5.Checked = currPen.Is5YearsIn;
                        chk55.Checked = currPen.IsOver55;
                    }
                    catch (Exception ex)
                    {
                        lblMessage.Text = ex.Message;
                        confirmation.Attributes.Add("style", "display:none");
                    }
                }
                else
                {
                    throw new Exception();
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("Login.aspx?message=1", false);
            }
        }

        #endregion

        #region Houskeeping

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session["auth"] = false;
            Session["EmployeeName"] = null;
            Session["AccessLevel"] = null;
            Session["EmployeeInfo"] = null;
            Response.Redirect("Login.aspx", false);
        }

        #endregion
    }
}