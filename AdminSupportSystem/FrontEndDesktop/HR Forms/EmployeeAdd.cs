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
using UDT;
using BOL;

namespace FrontEndDesktop.HR_Forms
{
    public partial class EmployeeAdd : Form
    {
        public EmployeeAdd()
        {
            InitializeComponent();
        }

        private void EmployeeAdd_Load(object sender, EventArgs e)
        {
            ddlDepartments.DataSource = LookupFactory.Create(dbTable.department);
            ddlDepartments.DisplayMember = "title";
            ddlDepartments.ValueMember = "id";
            ddlDepartments.SelectedValue = -1;

            ddlJobs.DataSource = LookupFactory.Create(dbTable.job);
            ddlJobs.DisplayMember = "title";
            ddlJobs.ValueMember = "id";
            ddlJobs.SelectedValue = -1;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            frmClear();
        }

        private void frmClear()
        {
            foreach (Control x in groupBox1.Controls)
            {
                if (x is TextBox)
                {
                    ((TextBox)x).Text = String.Empty;
                }
            }
            foreach (Control x in groupBox2.Controls)
            {
                if (x is TextBox)
                {
                    ((TextBox)x).Text = String.Empty;
                }
            }
            ddlDepartments.SelectedIndex = -1;
            ddlJobs.SelectedIndex = -1;
            dtpDob.Value = DateTime.Today;
            dtpJobStart.Value = DateTime.Today;
            dtpSenStart.Value = DateTime.Today;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtLname.Text == "" || txtFname.Text == "" ||
                    txtStreet.Text == "" ||
                    txtCity.Text == "" || txtPC.Text == "" ||
                    txtSIN.Text == "" || ddlJobs.SelectedIndex == -1 ||
                    ddlDepartments.SelectedIndex == -1 || txtPayrate.Text == "" ||
                    txtWorkPhone.Text == "" || txtCellPhone.Text == "" ||
                    txtEmail.Text == "" ||
                    !VAL.Validate.checkPhone(txtWorkPhone.Text) ||
                    !VAL.Validate.checkPhone(txtCellPhone.Text) ||
                    !VAL.Validate.checkEmail(txtEmail.Text) ||
                    !VAL.Validate.checkPostal(txtPC.Text))
                {
                    MessageBox.Show("You must fill all fields", "Invalid");
                }
                else
                {

                    Employee emp = EmployeeFactory.Create();
                    emp.LastName = txtLname.Text;
                    emp.FirstName = txtFname.Text;
                    emp.MiddleName = txtMinit.Text;
                    emp.DOB = dtpDob.Value;
                    emp.Street = txtStreet.Text;
                    emp.City = txtCity.Text;
                    emp.PostalCode = txtPC.Text;

                    emp.SIN = Convert.ToInt32(txtSIN.Text);
                    emp.SeniorityDate = dtpSenStart.Value;
                    emp.JobStartDate = dtpJobStart.Value;
                    emp.Job = Convert.ToInt32(ddlJobs.SelectedValue);
                    emp.Department = Convert.ToInt32(ddlDepartments.SelectedValue);
                    emp.PayRate = Convert.ToDouble(txtPayrate.Text);
                    emp.WorkPhone = Convert.ToInt64(txtWorkPhone.Text);
                    emp.CellPhone = Convert.ToInt64(txtCellPhone.Text);
                    emp.Email = txtEmail.Text;
                    if (txtPayrollEmail.Text != "")
                    {
                        VAL.Validate.checkEmail(txtPayrollEmail.Text);
                        emp.PayrollNotifyEmail = txtPayrollEmail.Text;
                    }

                    int id = EmployeeFactory.Insert(emp);
                    MessageBox.Show("Your employee has been added with the id: " + id, "Success");
                    frmClear();
                }
            }
            catch (InvalidCastException ex)
            {
                MessageBox.Show("SIN, Payrate and Work/Cell phone must be numbers", "Invalid");
            }
            catch (ConstraintException ex)
            {
                MessageBox.Show("One or more fields are invalid", "Invalid");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Was unable to save recored\n" + ex.Message, "Invalid");
            }           
        }
    }
}
