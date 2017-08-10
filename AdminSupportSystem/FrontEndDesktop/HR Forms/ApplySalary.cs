using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VAL;
using BOL;
using FrontEndDesktop.Properties;

namespace FrontEndDesktop.HR_Forms
{
    public partial class ApplySalary : Form
    {
        private Main parent;

        public ApplySalary(Main p)
        {
            this.parent = p;
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            clear();
            EmployeeSearch frmSearch = new EmployeeSearch(parent);
            parent.DisplayForm(frmSearch);
        }

        private void rdoLive_CheckedChanged(object sender, EventArgs e)
        {
            clear();
            if (rdoLive.Checked)
            {
                btnSearch.Enabled = false;
                pnlEmployee.Enabled = false;
                btnApply.Enabled = true;
            }
            else
            {
                LoadCurrEmp();
                btnSearch.Enabled = true;
                pnlEmployee.Enabled = true;
                btnApply.Enabled = false;
            }
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            String strRaise = txtPercent.Text;
            DateTime affectDate = dtpAffDate.Value;
            if (strRaise == "" && affectDate < DateTime.Today)
            {
                MessageBox.Show("You must enter a raise percent and a date earlier than today", "Invalid");
            }
            else
            {
                try
                {
                    double raise = Convert.ToDouble(strRaise);

                    PayRaise payRaise = PayFactory.Create();
                    payRaise.payIn = raise;
                    payRaise.newAffDate = dtpAffDate.Value;
                    

                    if (rdoPer.Checked)
                    {
                        payRaise.empId = Main.currEmp.Id;
                        payRaise.selfCheck(Settings.Default.EmployeeId);
                        payRaise = HRUser.UpdateRaise(payRaise);
                        pnlPayInfo.Visible = true;
                        txtNewPay.Text = payRaise.newPay.ToString("C");
                        txtOldPay.Text = payRaise.oldPay.ToString("C");
                        txtOldDate.Text = payRaise.oldAffDate.ToShortDateString();
                    }
                    else
                    {
                        HRUser.UpdateAllRaises(payRaise);
                    }
                    lblSaved.Visible = true;
                }
                catch (InvalidCastException exCast)
                {
                    MessageBox.Show("Raise must be a number", "Invalid");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void ApplySalary_Load(object sender, EventArgs e)
        {
            LoadCurrEmp();
        }

        private void LoadCurrEmp()
        {
            if (Main.currEmp != null)
            {
                btnApply.Enabled = true;
                txtLname.Text = Main.currEmp.LastName;
                txtFname.Text = Main.currEmp.FirstName;
                txtMinit.Text = Main.currEmp.MiddleName;
                txtDob.Text = Main.currEmp.DOB.ToShortDateString();
                txtStreet.Text = Main.currEmp.Street;
                txtCity.Text = Main.currEmp.City;
                txtPC.Text = Main.currEmp.PostalCode;

                txtSIN.Text = Main.currEmp.SIN.ToString();
                txtSenStart.Text = Main.currEmp.SeniorityDate.ToShortDateString();
                txtJobStart.Text = Main.currEmp.JobStartDate.ToShortDateString();
                txtJob.Text = Main.currEmp.Job.ToString();
                txtDepartments.Text = Main.currEmp.Department.ToString();
                txtPayrate.Text = Main.currEmp.PayRate.ToString("C");
                txtWorkPhone.Text = Main.currEmp.WorkPhone.ToString();
                txtCellPhone.Text = Main.currEmp.CellPhone.ToString();
                txtEmail.Text = Main.currEmp.Email;
                txtPayrollEmail.Text = Main.currEmp.PayrollNotifyEmail;

                dtpAffDate.Value = DateTime.Today;
            }
            else
            {
                btnApply.Enabled = false;
            }
}

        private void btnClear_Click(object sender, EventArgs e)
        {
            clear();
            pnlEmployee.Enabled = false;
            pnlPayInfo.Visible = false;
            if (rdoPer.Checked)
            {
                btnApply.Enabled = false;
            }
            else
            {
                btnApply.Enabled = true;
            }
            lblSaved.Visible = false;
        }

        private void clear()
        {
            foreach (Control x in pnlPayInfo.Controls)
            {
                if (x is TextBox)
                {
                    ((TextBox)x).Text = String.Empty;
                }
            }
            dtpAffDate.Value = DateTime.Today;
            txtPercent.Text = "";           
            btnApply.Enabled = false;
            pnlPayInfo.Visible = false;
            lblSaved.Visible = false;
        }


        private void ApplySalary_Enter(object sender, EventArgs e)
        {
            LoadCurrEmp();
        }

        private void ApplySalary_Activated(object sender, EventArgs e)
        {
            LoadCurrEmp();
        }
    }
}
