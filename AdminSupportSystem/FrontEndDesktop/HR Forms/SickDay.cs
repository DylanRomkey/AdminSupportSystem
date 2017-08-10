using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BOL;

namespace FrontEndDesktop.HR_Forms
{
    public partial class SickDay : Form
    {
        private Main parent;

        #region FormControl
        public SickDay(Main p)
        {
            this.parent = p;
            InitializeComponent();
        }

        private void SickDay_Load(object sender, EventArgs e)
        {
            dtpSickdayEnd.Enabled = false;
            chkMulti.Checked = false;
            chkFullday.Checked = true;
            LoadEmp();

        }
        private void SickDay_Enter(object sender, EventArgs e)
        {
            LoadEmp();
        }

        private void LoadEmp()
        {
            if (Main.currEmp != null)
            {
                pnlSick.Enabled = true;
                txtLname.Text = Main.currEmp.LastName;
                txtFname.Text = Main.currEmp.FirstName;
                txtMinit.Text = Main.currEmp.MiddleName;
                dtpDob.Text = Main.currEmp.DOB.ToShortDateString();
                txtStreet.Text = Main.currEmp.Street;
                txtCity.Text = Main.currEmp.City;
                txtPC.Text = Main.currEmp.PostalCode;
            }
            else
            {
                pnlSick.Enabled = false;
            }
        }
        #endregion

        #region Buttons
        private void btnSearch_Click(object sender, EventArgs e)
        {
            EmployeeSearch frmSearch = new EmployeeSearch(parent);
            parent.DisplayForm(frmSearch);
        }

        private void chkMulti_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMulti.Checked)
            {
                dtpSickdayEnd.Enabled = true;
            }
            else
            {
                dtpSickdayEnd.Enabled = false;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtDescription.Text == "")
                {
                    MessageBox.Show("A description is required", "Invalid");
                }
                else
                {
                    Sickday currSick = SickdayFactory.Create();
                    currSick.EmployeeId = Main.currEmp.Id;
                    currSick.FullDay = chkFullday.Checked;
                    currSick.Description = txtDescription.Text;

                    if (chkMulti.Checked)
                    {
                        int days = (dtpSickdayEnd.Value - dtpSickdayStart.Value).Days + 2;
                        int total = 0;
                        for (int i = 0; i < days; i++)
                        {
                            currSick.SickDate = dtpSickdayStart.Value.AddDays(i);
                            total = SickdayFactory.Insert(currSick);
                        }
                        MessageBox.Show("The " + days.ToString() + " sick days have been added, the new total is: " + total, "Success");
                    }
                    else
                    {
                        currSick.SickDate = dtpSickdayStart.Value;
                        int total = SickdayFactory.Insert(currSick);
                        MessageBox.Show("The sick day has been added, the new total is: " + total, "Success");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }

        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            chkFullday.Checked = true;
            chkMulti.Checked = false;
            dtpSickdayStart.Value = DateTime.Today;
            dtpSickdayEnd.Value = DateTime.Today;
            txtDescription.Text = "";
        }

        #endregion

        #region Validation    
        private void dtpSickdayStart_ValueChanged(object sender, EventArgs e)
        {
            if (dtpSickdayStart.Value > DateTime.Today)
            {
                //Sick date cant be in the future (biz 221)
                MessageBox.Show("Cannot record sick days in the future", "Invalid");
                dtpSickdayStart.Value = DateTime.Today;
                dtpSickdayEnd.Value = DateTime.Today;
            }
        }

        private void dtpSickdayEnd_ValueChanged(object sender, EventArgs e)
        {
            if (dtpSickdayEnd.Value < dtpSickdayStart.Value)
            {
                MessageBox.Show("Cannot have an end date thats before your start date", "Invalid");
                dtpSickdayEnd.Value = dtpSickdayStart.Value;
            }
        }
        #endregion
    }
}
