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
    public partial class PMenusecre : Form
    {
        public PMenusecre()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            PRegCliente Reg = new PRegCliente();
            Reg.Show();
            this.Hide(); 
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Pfactura Fa = new Pfactura();
            Fa.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            PinventarioPren Pren = new PinventarioPren();
            Pren.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            PGestionservicio Gesserv = new PGestionservicio();
            Gesserv.Show();
            this.Hide();
        }

        private void pictureBox3_Click_1(object sender, EventArgs e)
        {
            Pfactura Fa = new Pfactura();
            Fa.Show();
            this.Hide();
        }

        private void pictureBox4_Click_1(object sender, EventArgs e)
        {
            PLogin L = new PLogin();
            L.Show();
            this.Hide();
        }
    }
}
