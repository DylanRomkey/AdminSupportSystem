using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrontEndDesktop.HR_Forms
{
    public partial class Passcode : Form
    {


        public String InPass;

        public Passcode()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnOk_Click_1(object sender, EventArgs e)
        {
            InPass = txtPass.Text;
            DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
