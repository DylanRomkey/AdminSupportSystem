using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FrontEndDesktop.Startup_Forms;
using FrontEndDesktop.HR_Forms;
using FrontEndDesktop.Properties;
using BOL;

namespace FrontEndDesktop
{
    public partial class Main : Form
    {
        public static Employee currEmp;

        #region Form Load

        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            Form frmLogin = new Login();
            frmLogin.ShowDialog();

            if (frmLogin.DialogResult != DialogResult.OK)
            {
                this.Close();
            }

            SetUpStatusStrip();
            mnuLogin.Enabled = false;
            tlsCreateEmployee.Enabled = false;
            mnuCreateEmployee.Enabled = false;
            tlsModifyEmployee.Enabled = false;
            mnuModifyEmployee.Enabled = false;
            tlsApplySalary.Enabled = false;
            mnuApplySalary.Enabled = false;
            tlsGeneratePay.Enabled = false;
            mnuGeneratePay.Enabled = false;
            tlsSickDay.Enabled = false;
            mnuSickDay.Enabled = false;

            if (!Settings.Default.AccessLevel.Equals("S"))
            {
                tlsProcessPO.Enabled = false;
                mnuProcessPO.Enabled = false;
            }

            if (Settings.Default.AccessLevel.Equals("H"))
            {
                tlsCreateEmployee.Enabled = true;
                mnuCreateEmployee.Enabled = true;
                tlsModifyEmployee.Enabled = true;
                mnuModifyEmployee.Enabled = true;
                tlsApplySalary.Enabled = true;
                mnuApplySalary.Enabled = true;
                tlsGeneratePay.Enabled = true;
                mnuGeneratePay.Enabled = true;
                tlsSickDay.Enabled = true;
                mnuSickDay.Enabled = true;
            }

            if (Settings.Default.AccessLevel.Equals("C"))
            {
                tlsCreatePO.Enabled = false;
                mnuCreatePO.Enabled = false;
                tlsProcessPO.Enabled = true;
                mnuProcessPO.Enabled = true;
                tlsModifyPO.Enabled = false;
                mnuModifyPO.Enabled = false;
            }
        }

        #endregion

        #region Buttons

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            statusStrip1.Items[2].ForeColor = Color.Black;
            statusStrip1.Items[2].Text = "OK";

            if (sender == tlsCreatePO || sender == mnuCreatePO)
            {
                DisplayForm(new CreatePurchaseOrder());
            }
            else if (sender == tlsModifyPO || sender == mnuModifyPO)
            {
                DisplayForm(new ModifyPurchaseOrder());
            }
            else if (sender == tlsProcessPO || sender == mnuProcessPO)
            {
                DisplayForm(new ProcessPurchaseOrder());
            }
            else if (sender == tlsCreateEmployee || sender == mnuCreateEmployee)
            {
                DisplayForm(new EmployeeAdd());
            }
            else if (sender == tlsSearchEmployee || sender == mnuSearchEmployee)
            {
                DisplayForm(new EmployeeSearch(this));
            }
            else if (sender == tlsApplySalary || sender == mnuApplySalary)
            {
                DisplayForm(new ApplySalary(this));
            }
            else if (sender == tlsGeneratePay || sender == mnuGeneratePay)
            {
                DisplayForm(new GeneratePay());
            }
            else if (sender == tlsSickDay || sender == mnuSickDay)
            {
                DisplayForm(new SickDay(this));
            }
            else if (sender == tlsModifyEmployee || sender == mnuModifyEmployee)
            {
                DisplayForm(new EmployeeModification(this));
            }
            else if (sender == mnuAbout)
            {
                Form about = new About();
                about.ShowDialog();
            }
            else if (sender == mnuLogin)
            {
                Form frmLogin = new Login();
                frmLogin.ShowDialog();

                if (frmLogin.DialogResult != DialogResult.OK)
                {
                    this.Close();
                }

                LoginForm();

                if (!Settings.Default.AccessLevel.Equals("S"))
                {
                    tlsProcessPO.Enabled = false;
                    mnuProcessPO.Enabled = false;
                }

                if (Settings.Default.AccessLevel.Equals("H"))
                {
                    tlsCreateEmployee.Enabled = true;
                    mnuCreateEmployee.Enabled = true;
                    tlsModifyEmployee.Enabled = true;
                    mnuModifyEmployee.Enabled = true;
                    tlsApplySalary.Enabled = true;
                    mnuApplySalary.Enabled = true;
                    tlsGeneratePay.Enabled = true;
                    mnuGeneratePay.Enabled = true;
                    tlsSickDay.Enabled = true;
                    mnuSickDay.Enabled = true;
                }

                if (Settings.Default.AccessLevel.Equals("C"))
                {
                    tlsCreatePO.Enabled = false;
                    mnuCreatePO.Enabled = false;
                    tlsProcessPO.Enabled = true;
                    mnuProcessPO.Enabled = true;
                    tlsModifyPO.Enabled = false;
                    mnuModifyPO.Enabled = false;
                }

                statusStrip1.Items.Clear();
                SetUpStatusStrip();
            }
            else if (sender == mnuLogout)
            {
                LogoutForm();
                Settings.Default.EmployeeName = "";
                Settings.Default.AccessLevel = "";
                Settings.Default.EmployeeId = 0;
            }
            else if(sender == mnuExit)
            {
                this.Close();
            }
        }

        public void DisplayForm(Form myForm)
        {
            Boolean hasPage = false;
            foreach (MdiTabControl.TabPage x in tabControl1.TabPages)
            {
                if (x.Form.GetType() == myForm.GetType())
                {
                    hasPage = true;
                    x.Select();
                    break;
                }
            }

            if (!hasPage)
            {
                tabControl1.TabPages.Add(myForm);
                tabControl1.TabPages[0].Select();
            }
        }

        #endregion

        #region Status Strip

        private void SetUpStatusStrip()
        {
            ToolStripStatusLabel stsLabel0 = new ToolStripStatusLabel();
            ToolStripStatusLabel stsLabel1 = new ToolStripStatusLabel();
            ToolStripStatusLabel stsLabel2 = new ToolStripStatusLabel();

            statusStrip1.Items.AddRange(new ToolStripItem[] { stsLabel0, stsLabel1, stsLabel2 });
            statusStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Table;

            stsLabel0.Text = DateTime.Now.ToShortTimeString();
            stsLabel0.Spring = false;
            stsLabel0.TextAlign = ContentAlignment.MiddleRight;
            stsLabel0.BorderSides = ToolStripStatusLabelBorderSides.Right;

            stsLabel1.Text = Settings.Default.EmployeeName;
            stsLabel1.Spring = false;
            stsLabel1.TextAlign = ContentAlignment.MiddleRight;

            stsLabel2.Spring = true;
            stsLabel2.BorderSides = ToolStripStatusLabelBorderSides.All;
            stsLabel2.TextAlign = ContentAlignment.MiddleRight;
            stsLabel2.BorderStyle = Border3DStyle.SunkenInner;
            statusStrip1.Items[2].Text = "Login Successful";
            statusStrip1.Items[2].ForeColor = Color.Green;
        }

        #endregion

        #region Housekeeping

        private void LoginForm()
        {
            mnuLogout.Enabled = true;
            mnuLogin.Enabled = false;
            mnuCreatePO.Enabled = true;
            mnuModifyPO.Enabled = true;
            mnuProcessPO.Enabled = true;
            mnuSearchEmployee.Enabled = true;
            tlsCreatePO.Enabled = true;
            tlsModifyPO.Enabled = true;
            tlsProcessPO.Enabled = true;
            tlsSearchEmployee.Enabled = true;
            tlsCreateEmployee.Enabled = false;
            mnuCreateEmployee.Enabled = false;
            tlsModifyEmployee.Enabled = false;
            mnuModifyEmployee.Enabled = false;
            tlsApplySalary.Enabled = false;
            mnuApplySalary.Enabled = false;
            tlsGeneratePay.Enabled = false;
            mnuGeneratePay.Enabled = false;
            tlsSickDay.Enabled = false;
            mnuSickDay.Enabled = false;
        }

        private void LogoutForm()
        {
            mnuLogout.Enabled = false;
            mnuLogin.Enabled = true;
            mnuCreatePO.Enabled = false;
            mnuModifyPO.Enabled = false;
            mnuProcessPO.Enabled = false;
            mnuCreateEmployee.Enabled = false;
            mnuSearchEmployee.Enabled = false;
            mnuModifyEmployee.Enabled = false;
            tlsCreatePO.Enabled = false;
            tlsModifyPO.Enabled = false;
            tlsProcessPO.Enabled = false;
            tlsCreateEmployee.Enabled = false;
            tlsSearchEmployee.Enabled = false;
            tlsModifyEmployee.Enabled = false;
            tlsApplySalary.Enabled = false;
            mnuApplySalary.Enabled = false;
            tlsGeneratePay.Enabled = false;
            mnuGeneratePay.Enabled = false;
            tlsSickDay.Enabled = false;
            mnuSickDay.Enabled = false;
            statusStrip1.Items[1].Text = "";
            statusStrip1.Items[2].Text = "Logout Successful";
            statusStrip1.Items[2].ForeColor = Color.Green;
            tabControl1.TabPages.Clear();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            statusStrip1.Items[0].Text = DateTime.Now.ToShortTimeString();
        }

        #endregion

    }
}