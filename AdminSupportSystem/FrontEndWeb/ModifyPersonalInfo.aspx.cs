using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BOL;
using UDT;

namespace FrontEndWeb
{
    public partial class ModifyPersonalInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["EmployeeInfo"] != null)
                {
                    Employee currEmp = (Employee)Session["EmployeeInfo"];
                    ShowInfo(currEmp);
                }
                else
                {
                    throw new Exception();
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("Login.aspx", false);
            }
        }

        #region Houskeeping
        private void ShowInfo(Employee currEmp)
        {
            lblEmployee.Text = currEmp.FirstName + (currEmp.MiddleName == "" ? "" : " " + currEmp.MiddleName + " ") + currEmp.LastName;
            lblDob.Text = currEmp.DOB.ToShortDateString();
            lblAddress.Text = currEmp.Street + ", " + currEmp.City + " " + currEmp.PostalCode;
            lblWorkPhone.Text = String.Format("{0:(###)###-####}", currEmp.WorkPhone);
            lblCellPhone.Text = String.Format("{0:(###)###-####}", currEmp.CellPhone);
        }
        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session["auth"] = false;
            Session["EmployeeName"] = null;
            Session["AccessLevel"] = null;
            Response.Redirect("Login.aspx", false);
        }
        #endregion

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                String strWp = txtWorkPhone.Text;
                String strCp = txtCellPhone.Text;
                String street = txtStreet.Text;
                String city = txtCity.Text;
                String pc = txtPC.Text;

                if (strWp == "" && strCp == "" && street == "" && city == "" && pc == "")
                {
                    lblMessage.Text = "You must fill at least one field";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    Employee currEmp = (Employee)Session["EmployeeInfo"];
                    if (strWp != "")
                    {
                        VAL.Validate.checkPhone(strWp);
                        currEmp.WorkPhone = Convert.ToInt64(strWp);
                    }
                    if (strCp != "")
                    {
                        VAL.Validate.checkPhone(strCp);
                        currEmp.CellPhone = Convert.ToInt64(strCp);
                    }
                    if (street != "")
                    {
                        currEmp.Street = street;
                    }
                    if (city != "")
                    {
                        currEmp.City = city;
                    }
                    if (pc != "")
                    {
                        VAL.Validate.checkPostal(pc);
                        currEmp.PostalCode = pc;
                    }

                    EmployeeFactory.Modify(currEmp, updateType.webPersonal);
                    Session["EmployeeInfo"] = EmployeeFactory.Retrieve(currEmp.Id);
                    ShowInfo(currEmp);
                    lblMessage.Text = "Your data has been updated";
                    lblMessage.ForeColor = System.Drawing.Color.Aqua;
                }

            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }

        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            Response.Redirect("ModifyPersonalInfo.aspx", false);
        }


        protected void txtChange(object sender, EventArgs e)
        {
            try
            {
                lblMessage.ForeColor = System.Drawing.Color.Black;
                lblMessage.Text = "Form is clean";

                if (sender == txtWorkPhone)
                {
                    if (txtWorkPhone.Text.Length != 0 && txtWorkPhone.Text.Length != 10)
                    {
                        lblMessage.ForeColor = System.Drawing.Color.Red;
                        lblMessage.Text = "Work phone must be 10 digits";
                    }
                    else
                    {
                        VAL.Validate.checkPhone(txtWorkPhone.Text);
                    }
                }
                else if (sender == txtCellPhone)
                {
                    if (txtCellPhone.Text.Length != 0 && txtCellPhone.Text.Length != 10)
                    {
                        lblMessage.ForeColor = System.Drawing.Color.Red;
                        lblMessage.Text = "Cell phone must be 10 digits";
                    }
                    else
                    {
                        VAL.Validate.checkPhone(txtCellPhone.Text);
                    }
                }
                else if (sender == txtPC)
                {
                    VAL.Validate.checkPostal(txtPC.Text);
                }
            }
            catch (Exception ex)
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = ex.Message;
            }
        }
    }
}