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
    public partial class PMenu : Form
    {
        public string perfil;
        public PMenu()
        {
            InitializeComponent();
        }
       
        private void pictureBox1_Click(object sender, EventArgs e)
        {
			PGestionCliente Reg = new PGestionCliente();
			Reg.Show();
            //this.Hide(); 

        }

        
        private void pictureBox3_Click(object sender, EventArgs e)
        {
			PGestionfactura Fa = new PGestionfactura();
			Fa.Show();
            //this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
			PinventarioPren Pren = new PinventarioPren();
			Pren.Show();
            //this.Hide();
        }
        private void FormMenu_Load(object sender, EventArgs e)
        {

            if (perfil == "Administrador")
            {
                pictureBox6.Visible = true;
                label6.Visible = true;
                pictureBox1.Visible = true;
                label1.Visible = true;
                pictureBox2.Visible = true;
                label2.Visible = true;
                pictureBox5.Visible = true;
                label5.Visible = true;
                pictureBox3.Visible = true;
                label3.Visible = true;
               
            }
            if (perfil == "Secretaria")
            {
                pictureBox6.Visible = true;
                label6.Visible = true;
                pictureBox1.Visible = true;
                label1.Visible = true;
                pictureBox2.Visible = true;
                label2.Visible = true;
                pictureBox3.Visible = false;
                label3.Visible = false;
                pictureBox5.Visible = false;
                label5.Visible = false;
                pictureBox1.Location = new Point(74, 90);
                label1.Location = new Point(80, 67);
                pictureBox2.Location = new Point(427, 90);
                label2.Location = new Point(446, 67);
                this.Size = new Size(577, 337);
            }
            if (perfil == "Cajero")
            {

                pictureBox6.Visible = true;
                label6.Visible = true;
                pictureBox1.Visible = true;
                label1.Visible = true;
                pictureBox2.Visible = true;
                label2.Visible = true;
                pictureBox3.Visible = true;
                label5.Visible = false;
                pictureBox3.Location=new Point(74, 90);
                label3.Location = new Point(80, 67);
                this.Size=new Size(418,421);
            }
            PPerfil instancia = new PPerfil();
            label4.Text = instancia.devolverPerfil();

            PCedula instancia22 = new PCedula();
            label7.Text = instancia22.compartir();
        }
        private void pictureBox4_Click_1(object sender, EventArgs e)
        {
            PLogin L = new PLogin();
            L.Show();
            this.Hide();
        }

        private void pictureBox6_Click_1(object sender, EventArgs e)
        {
            PGestionservicio servicio = new PGestionservicio();
            servicio.Show();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            PRegistroempleado empleado = new PRegistroempleado();
            empleado.Show();
        }
        
    }
}
