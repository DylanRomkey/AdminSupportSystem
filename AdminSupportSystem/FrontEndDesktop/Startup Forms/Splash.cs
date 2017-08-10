using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrontEndDesktop.Startup_Forms
{   
    public partial class Splash : Form
    {
        private Timer closeTimer = new Timer();

        public Splash()
        {
            InitializeComponent();
            closeTimer.Interval = 2000; //5 seconds
            closeTimer.Tick += new EventHandler(closeTimer_Tick);
            closeTimer.Start();
        }

        private void closeTimer_Tick(object sender, EventArgs e)
        {
            closeTimer.Stop();
            this.Close();
        }
    }
}
