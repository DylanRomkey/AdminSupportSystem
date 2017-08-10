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
using System.Net.Mail;

namespace FrontEndDesktop.HR_Forms
{
    public partial class GeneratePay : Form
    {
        public GeneratePay()
        {
            InitializeComponent();
        }

        private void GeneratePay_Load(object sender, EventArgs e)
        {
            try
            {
                //String pc = HRUser.isPaydate();
                PerformPayroll("pass3");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + ex.InnerException, "Error");
            }
        }

        public void PerformPayroll(String pc)
        {
            Passcode frmPasscode = new Passcode();
            frmPasscode.ShowDialog();

            if (frmPasscode.DialogResult == DialogResult.OK)
            {
                if (frmPasscode.InPass == pc)
                {
                    DataTable currData = HRUser.generatePay();
                    dgvPayStubs.DataSource = currData;
                    frmPasscode.Close();

                    //personal info
                    txtId.DataBindings.Add(new Binding("Text", currData, "Employee ID"));
                    txtName.DataBindings.Add(new Binding("Text", currData, "Name"));
                    txtDob.DataBindings.Add(new Binding("Text", currData, "Birthday"));
                    txtAddress.DataBindings.Add(new Binding("Text", currData, "Address"));
                    txtPayrate.DataBindings.Add(new Binding("Text", currData, "Payrate"));

                    //current pay
                    txtGross.DataBindings.Add(new Binding("Text", currData, "Gross pay"));
                    txtTax.DataBindings.Add(new Binding("Text", currData, "Tax"));
                    txtCPP.DataBindings.Add(new Binding("Text", currData, "CPP"));
                    txtEi.DataBindings.Add(new Binding("Text", currData, "EI"));
                    txtPension.DataBindings.Add(new Binding("Text", currData, "Pension"));
                    txtNet.DataBindings.Add(new Binding("Text", currData, "Net pay"));

                    //YTD pay
                    txtYTDGross.DataBindings.Add(new Binding("Text", currData, "YTD Gross pay")); 
                    txtYTDTax.DataBindings.Add(new Binding("Text", currData, "YTD Tax"));
                    txtYTDCPP.DataBindings.Add(new Binding("Text", currData, "YTD CPP"));
                    txtYTDEI.DataBindings.Add(new Binding("Text", currData, "YTD EI"));
                    txtYTDPension.DataBindings.Add(new Binding("Text", currData, "YTD Pension"));
                    txtYTDNet.DataBindings.Add(new Binding("Text", currData, "YTD Pay"));

                    //emails
                    List<String> emails = HRUser.PayrollEmails();
                    foreach (String e in emails)
                    {
                        MailMessage mail = new MailMessage();
                        mail.To.Add(e);
                        mail.From = new MailAddress("Info@GearWorks.com");
                        SmtpClient client = new SmtpClient();
                        client.Port = 25;
                        client.EnableSsl = false;
                        client.DeliveryMethod = SmtpDeliveryMethod.Network;
                        client.UseDefaultCredentials = true;
                        client.Host = "localhost";
                        mail.Subject = "Payroll has been processed.";
                        mail.Body = "You have been payed for working during the latest pay period for GearWorks, check your bank.";
                        client.Send(mail);

                    }

                }
                else
                {
                    MessageBox.Show("You must enter the correct code to generate pay", "Invalid");
                }
            }

            frmPasscode.Dispose();
        }

        private void txtFormat(object sender, EventArgs e)
        {
            try
            {
                TextBox tb = (TextBox)sender;
                if (tb.Text != "")
                {
                    decimal val = Convert.ToDecimal(tb.Text);
                    tb.Text = String.Format("{0:C}", val);
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void dateFormat(object sender, EventArgs e)
        {
            try
            {
                TextBox tb = (TextBox)sender;
                if (tb.Text != "")
                {
                    DateTime val = Convert.ToDateTime(tb.Text);
                    tb.Text = val.ToShortDateString();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
    }
}
