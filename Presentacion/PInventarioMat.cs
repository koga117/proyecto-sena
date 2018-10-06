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
    public partial class PInventarioMat : Form
    {
        public PInventarioMat()
        {
            InitializeComponent();
        }
        PMenu m = new PMenu();
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            
            m.Show();
            this.Hide();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void FormInventarioMat_Load(object sender, EventArgs e)
        {

        }

       
       
    }
}
