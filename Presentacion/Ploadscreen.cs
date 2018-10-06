using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Presentacion
{
    
    public partial class Ploadscreen : Form
    {

        public Ploadscreen()
        {
            InitializeComponent();
            timer1.Start();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Value = progressBar1.Value + 2;
        // progressBar1.Value = progressBar1.Value + 2;
           // progressBar1.Style = ProgressBarStyle.Continuous;
             if (Convert.ToInt32(progressBar1.Value) == 100)
            {
                timer1.Stop();
                timer1.Enabled = false;
                this.Hide();
                PLogin da = new PLogin();
                da.Show();
            } 
        }

}
    }


