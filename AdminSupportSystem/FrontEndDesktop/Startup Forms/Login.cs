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
using BOL;

namespace FrontEndDesktop.Startup_Forms
{
    public partial class Login : Form
    {
        List<Employee> employeeList = EmployeeFactory.RetrieveList();

        #region Form Load

        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            foreach(Employee tmpEmployee in employeeList)
            {
                cmbName.Items.Add(tmpEmployee.FirstName + " " + tmpEmployee.LastName);
            }
            
            txtPassword.Text = "password";
            cmbName.SelectedIndex = 1;      
        }

        #endregion

        #region Buttons

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                Settings.Default.EmployeeName = cmbName.SelectedItem.ToString();

                string[] names = cmbName.SelectedItem.ToString().Split(' ');
                string firstName = names[0];
                string lastName = names[1];

                Settings.Default.AccessLevel = EmployeeFactory.RetrieveAccessLevel(firstName, lastName);
                Settings.Default.EmployeeId = EmployeeFactory.RetrieveByName(firstName, lastName).Id;

                DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        #endregion

    }
}
