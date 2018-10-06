using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Capadelogica;

namespace Presentacion
{
    public partial class PRegistroempleado : Form
    {
        public PRegistroempleado()
        {
            InitializeComponent();
        }
        PMenu m = new PMenu();
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox7.Text == "" || textBox8.Text == "" || textBox9.Text == "" || textBox10.Text == "" || textBox11.Text == "")
            {
                MessageBox.Show("Verifique, valores incompletos", "Validacion de campos vacios", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                LGestionUsuario instancia = new LGestionUsuario();
                instancia.a = textBox1.Text;
                instancia.b = textBox2.Text;
                instancia.c = textBox3.Text;
                instancia.d = textBox4.Text;
                instancia.e = textBox5.Text;
                instancia.f = textBox7.Text;
                instancia.g = textBox8.Text;
                instancia.h = textBox9.Text;
                instancia.i = textBox10.Text;
                instancia.j = textBox11.Text;
                instancia.k = label13.Text;
                string respuesta = instancia.Lregistrar();
                if (respuesta == "1")
                {
                    MessageBox.Show("Registro exitoso", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show("No se pudo registrar el nuevo usuario,vuelva a intentarlo", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            LGestionUsuario instancia3 = new LGestionUsuario();
            DataTable tabla = new DataTable();
            tabla = instancia3.Lconsultar();//invocacion 
            dgb1.DataSource = tabla;
        }



        private void PRegistroempleado_Load(object sender, EventArgs e)
        {
            PPerfil instancia1 = new PPerfil();
            label12.Text = instancia1.devolverPerfil();

            PCedula instancia2 = new PCedula();
            label13.Text = instancia2.compartir();

            LGestionUsuario instancia3 = new LGestionUsuario();
            DataTable tabla = new DataTable();
            tabla = instancia3.Lconsultar();//invocacion 
            dgb1.DataSource = tabla;
            if (tabla.Rows.Count == 0)
            {
                MessageBox.Show("Sin datos de consulta");
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            if (textBox12.Text == "")
            {
                MessageBox.Show("Debe ingresar un dato a consultar");
            }
            else
            {
                LGestionUsuario instancia = new LGestionUsuario();
                instancia.valor = textBox12.Text;
                //instancia.valor = textBox6.Text;
                instancia.ConsultaEspecificaNombre();
                DataTable tabla = new DataTable();
                tabla = instancia.ConsultaEspecificaNombre();
                dgb1.DataSource = tabla;
            }
        }

        private void dgb1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox14.Text = dgb1.CurrentRow.Cells[0].Value.ToString();
            textBox15.Text = dgb1.CurrentRow.Cells[5].Value.ToString();
            textBox16.Text = dgb1.CurrentRow.Cells[4].Value.ToString();
            textBox17.Text = dgb1.CurrentRow.Cells[7].Value.ToString();
            textBox18.Text = dgb1.CurrentRow.Cells[8].Value.ToString();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            LGestionUsuario instancia = new LGestionUsuario();
            //string respuesta = instancia.Lactualizar(textBox14.Text,textBox15.Text,textBox16.Text,textBox17.Text,textBox18.Text);
            LGestionUsuario comdatos = new LGestionUsuario();
            comdatos.a = textBox14.Text;
            comdatos.b = textBox15.Text;
            comdatos.c = textBox16.Text;
            comdatos.d = textBox17.Text;
            comdatos.e = textBox18.Text;
            string respuesta = comdatos.Lactualizar();
            if (respuesta == "1")
            {
                MessageBox.Show("Actualizacion exitosa");
            }
            else
            {
                MessageBox.Show("Vuelva a intentarlo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            LGestionUsuario instancia3 = new LGestionUsuario();
            DataTable tabla = new DataTable();
            tabla = instancia3.Lconsultar();//invocacion 
            dgb1.DataSource = tabla;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            string Cedula = dgb1.CurrentRow.Cells[0].Value.ToString();
            LGestionUsuario instancia = new LGestionUsuario();
            instancia.Leliminar(Cedula);
            string respuesta = instancia.Leliminar(Cedula);
            if (respuesta == "1")
            {
                MessageBox.Show("Eliminacion exitosa");
            }
            else
            {
                MessageBox.Show("No se elimino el usuario");
            }

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoloNumeros(e);
        }
        public void SoloNumeros(KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = true;
            }
            else if (Char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (Char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsLetter(e.KeyChar))
            {
                e.Handled = false;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsLetter(e.KeyChar))
            {
                e.Handled = false;
            }

        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsLetter(e.KeyChar))
            {
                e.Handled = false;
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoloNumeros(e);
        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsLetter(e.KeyChar))
            {
                e.Handled = false;
            }
        }

        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoloNumeros(e);
        }

        private void textBox12_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsLetter(e.KeyChar))
            {
                e.Handled = false;
            }
        }

        private void textBox14_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoloNumeros(e);
        }

        private void textBox16_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoloNumeros(e);
        }

        private void textBox17_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoloNumeros(e);
        }

        private void textBox18_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsLetter(e.KeyChar))
            {
                e.Handled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LGestionUsuario instancia = new LGestionUsuario();
            instancia.a = textBox1.Text;
            instancia.b = textBox2.Text;
            instancia.j = textBox10.Text;
            instancia.k = textBox11.Text;
            instancia.Lregistrar(false);

            textBox10.Text = instancia.i;
            textBox11.Text = instancia.j;

        }


    }
}

