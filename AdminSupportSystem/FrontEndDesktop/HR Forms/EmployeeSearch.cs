using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FrontEndDesktop.Properties;
using VAL;
using BOL;

namespace FrontEndDesktop.HR_Forms
{
    public partial class EmployeeSearch : Form
    {
        private Main parent;

        #region FormControl

        public EmployeeSearch(Main p)
        {
            this.parent = p;
            InitializeComponent();
        }

        private void EmployeeSearch_Load(object sender, EventArgs e)
        {
            rdoId.Checked = true;

            if (!Settings.Default.AccessLevel.Equals("H"))
            {
                btnRaise.Enabled = false;
                btnSick.Enabled = false;
                btnMod.Enabled = false;
            }
            else
            {
                btnRaise.Enabled = true;
                btnSick.Enabled = true;
                btnMod.Enabled = true;
            }
        }

        private void SelectingEmployee(object sender, EventArgs e)
        {
            LoadEmp();
        }
        private void LoadEmp()
        {
            try
            {
                Main.currEmp = EmployeeFactory.Retrieve(Convert.ToInt32(lstEmps.SelectedValue));
                txtLname.Text = Main.currEmp.LastName;
                txtFname.Text = Main.currEmp.FirstName;
                txtMinit.Text = Main.currEmp.MiddleName;
                dtpDob.Text = Main.currEmp.DOB.ToString();
                txtStreet.Text = Main.currEmp.Street;
                txtCity.Text = Main.currEmp.City;
                txtPC.Text = Main.currEmp.PostalCode;

                pnlInfo.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Invalid");
            }
        }

        #endregion

        #region Button

        private void btn_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstEmps.SelectedIndex > -1)
                {
                    Button s = (Button)sender;
                    switch (s.Name)
                    {
                        case "btnRaise":
                            ApplySalary frmRaise = new ApplySalary(parent);
                            parent.DisplayForm(frmRaise);
                            break;
                        case "btnSick":
                            SickDay frmSick = new SickDay(parent);
                            parent.DisplayForm(frmSick);
                            break;
                        case "btnMod":
                            EmployeeModification frmMod = new EmployeeModification(parent);
                            parent.DisplayForm(frmMod);
                            break;
                    }
                }
                else
                {
                    MessageBox.Show("You must first select an employee", "Invalid");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Occured");
            }
        }

        

        private void btnSearch_Click_1(object sender, EventArgs e)
        {
            try
            {
                String info = txtInfo.Text;
                if (info == "")
                {
                    MessageBox.Show("Must enter a search peramater", "Invalid");
                }
                else
                {
                    if (rdoId.Checked)
                    {

                        int id = Convert.ToInt32(info);
                        if (VAL.Validate.checkId(id))
                        {
                            lstEmps.DataSource = EmployeeFactory.Search(id);
                        }
                        else
                        {
                            MessageBox.Show("Not a valid id", "Invalid");
                            return;
                        }

                    }
                    else
                    {
                        lstEmps.DataSource = EmployeeFactory.Search(0, info);
                    }
                    lstEmps.DisplayMember = "title";
                    lstEmps.ValueMember = "id";

                    lstEmps.SelectedIndexChanged += new EventHandler(SelectingEmployee);
                    LoadEmp();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Invalid");
            }
        }

    #endregion
    }
}
