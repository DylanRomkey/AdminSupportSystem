using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UDT;
using FrontEndDesktop.Properties;
using BOL;

namespace FrontEndDesktop.HR_Forms
{
    public partial class EmployeeModification : Form
    {
        private Main parent;

        #region FormControl

        public EmployeeModification(Main p)
        {
            this.parent = p;
            InitializeComponent();
        }

        private void EmployeeModification_Load(object sender, EventArgs e)
        {

            ddlStatus.Items.Add("Retired");
            ddlStatus.Items.Add("Terminated");

            ddlDepartments.DataSource = LookupFactory.Create(dbTable.department);
            ddlDepartments.DisplayMember = "title";
            ddlDepartments.ValueMember = "id";
            ddlDepartments.SelectedValue = -1;

            ddlJobs.DataSource = LookupFactory.Create(dbTable.job);
            ddlJobs.DisplayMember = "title";
            ddlJobs.ValueMember = "id";
            ddlJobs.SelectedValue = -1;

            ddlDepartments.SelectedIndexChanged += new EventHandler(ddlDepartments_SelectedIndexChanged);
            LoadEmp();
        }

        private void LoadEmp()
        {
            if (Main.currEmp != null)
            {
                if (ddlSections.Items.Count == 0)
                {
                    ddlSections.Items.Add("Personal Info");
                    ddlSections.Items.Add("Job Info");
                    ddlSections.Items.Add("Status");
                }
                
                txtLname.Text = Main.currEmp.LastName;
                txtFname.Text = Main.currEmp.FirstName;
                txtMinit.Text = Main.currEmp.MiddleName;
                dtpDob.Value = Main.currEmp.DOB;
                txtStreet.Text = Main.currEmp.Street;
                txtCity.Text = Main.currEmp.City;
                txtPC.Text = Main.currEmp.PostalCode;

                txtSIN.Text = Main.currEmp.SIN.ToString();
                dtpJobStart.Value = Main.currEmp.JobStartDate;
                ddlJobs.SelectedValue = Main.currEmp.Job.ToString();
                ddlDepartments.SelectedValue = Main.currEmp.Department.ToString();
                txtPayrate.Text = Math.Round(Main.currEmp.PayRate, 2).ToString();

                txtSIN2.Text = Main.currEmp.SIN.ToString();
                txtSen.Text = Main.currEmp.SeniorityDate.ToShortDateString();

                ddlStatus.Enabled = true;
                dtpAffDate.Enabled = true;
                txtPayrate.Enabled = true;
                ddlJobs.Enabled = true;

                if (Main.currEmp.Status == "Retired")
                {
                    ddlStatus.SelectedIndex = 0;
                    ddlStatus.Enabled = false;
                    dtpAffDate.Value = Main.currEmp.StatusApplied;
                    dtpAffDate.Enabled = false;
                }
                if (Settings.Default.EmployeeId == Main.currEmp.Id)
                {
                    ddlStatus.SelectedIndex = -1;
                    txtPayrate.Enabled = false;
                    ddlJobs.Enabled = false;
                    ddlStatus.Enabled = false;
                }
            }
        }
        private void EmployeeModification_Enter(object sender, EventArgs e)
        {
            LoadEmp();
        }
        private void ddlSections_SelectedIndexChanged(object sender, EventArgs e)
        {
            pnlJob.Enabled = false;
            pnlPer.Enabled = false;
            pnlStatus.Enabled = false;
            switch (ddlSections.SelectedIndex)
            {
                case 0:
                    pnlPer.Enabled = true;
                    break;
                case 1:
                    pnlJob.Enabled = true;
                    break;
                case 2:
                    pnlStatus.Enabled = true;
                    break;
            }
        }

        private void ddlDepartments_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txtSup.Text = DepartmentFactory.Retrieve(Convert.ToInt32(ddlDepartments.SelectedValue)).SupervisorName;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
        #endregion

        #region Buttons


        private void btnSearch_Click(object sender, EventArgs e)
        {
            EmployeeSearch frmSearch = new EmployeeSearch(parent);
            parent.DisplayForm(frmSearch);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddlSections.SelectedIndex != -1)
                {
                    switch (ddlSections.SelectedIndex)
                    {
                        case 0:
                            if (txtLname.Text == "" || txtFname.Text == "" || txtMinit.Text == "" ||
                                dtpDob.Value <= DateTime.Today || txtStreet.Text == "" ||
                                txtCity.Text == "" || txtPC.Text == "" ||
                                txtSIN.Text == "" || ddlJobs.SelectedIndex == -1 ||
                                ddlDepartments.SelectedIndex == -1 || txtPayrate.Text == "" ||
                                !VAL.Validate.checkPostal(txtPC.Text))
                            {
                                Main.currEmp.LastName = txtLname.Text;
                                Main.currEmp.FirstName = txtFname.Text;
                                Main.currEmp.MiddleName = txtMinit.Text;
                                Main.currEmp.DOB = dtpDob.Value;
                                Main.currEmp.Street = txtStreet.Text;
                                Main.currEmp.City = txtCity.Text;
                                Main.currEmp.PostalCode = txtPC.Text;

                                EmployeeFactory.Modify(Main.currEmp, updateType.winPersonal);
                            }
                            else
                            {
                                MessageBox.Show("Must fill every field", "Error");
                                return;
                            }
                            break;

                        case 1:
                            Main.currEmp.JobStartDate = dtpJobStart.Value;
                            Main.currEmp.Job = Convert.ToInt32(ddlJobs.SelectedValue);
                            Main.currEmp.Department = Convert.ToInt32(ddlDepartments.SelectedValue);
                            Main.currEmp.PayRate = Convert.ToDouble(txtPayrate.Text);
                            EmployeeFactory.Modify(Main.currEmp, updateType.job);
                            break;
                        case 2:
                            if (ddlStatus.Enabled)
                            {
                                Main.currEmp.Status = ddlStatus.Text;
                                Main.currEmp.StatusApplied = dtpAffDate.Value;
                                EmployeeFactory.Modify(Main.currEmp, updateType.status);
                            }
                            else
                            {
                                MessageBox.Show("Cannot change status", "Error");
                                return;
                            }

                            break;
                    }
                    MessageBox.Show("The record has been saved", "Success");
                }
                else
                {
                    MessageBox.Show("Must select a section to mod", "Invalid");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        #endregion

        private void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlStatus.SelectedIndex == 0)
            {
                dtpAffDate.Value = HRUser.nextPaydate();
                dtpAffDate.Enabled = false;
            }
            else if (ddlStatus.SelectedIndex == 1)
            {
                dtpAffDate.Enabled = true;
            }
        }

        private void dtpAffDate_ValueChanged(object sender, EventArgs e)
        {
            if (ddlStatus.SelectedIndex == 1)
            {
                DateTime nextPay = HRUser.nextPaydate();
                if (dtpAffDate.Value < nextPay.AddDays(-14) || dtpAffDate.Value > nextPay)
                {
                    dtpAffDate.Value = nextPay;
                    MessageBox.Show("Must terminate within this pay period: " + nextPay.AddDays(-14).ToShortDateString() + " to " + nextPay.ToShortDateString(), "Invalid");
                }
            }
        }
    }
}
