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
    public partial class PinventarioPren : Form
    {
        public PinventarioPren()
        {
            InitializeComponent();
        }
        PMenu m = new PMenu();
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            m.Show();
            this.Hide();
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Verifique, valores incompletos", "Validacion de campos vacios", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                LGestionArticulo instancia = new LGestionArticulo();
                string respuesta = instancia.LRegistrar(comboBox1.Text,textBox1.Text,Convert.ToString(dateTimePicker1.Value),label4.Text);
                if (respuesta == "1")
                {
                    MessageBox.Show("Registro exitoso", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No se pudo registrar la nueva prenda,vuelva a intentarlo", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            LGestionArticulo instancia3 = new LGestionArticulo();
            DataTable tabla = new DataTable();
            tabla = instancia3.LConsultar();//invocacion 
            dataGridView2.DataSource = tabla;
        }
        private void PinventarioPren_Load(object sender, EventArgs e)
        {
            PPerfil instancia1 = new PPerfil();
            label5.Text = instancia1.devolverPerfil();

            PCedula instancia2 = new PCedula();
            label4.Text = instancia2.compartir();

            LGestionArticulo instancia3 = new LGestionArticulo();
            DataTable tabla = new DataTable();
            tabla = instancia3.LConsultar();//invocacion 
            dataGridView2.DataSource = tabla; 
            if (tabla.Rows.Count == 0)
            {
                MessageBox.Show("Sin datos de consulta");
            }
        }
        private void pictureBox5_Click(object sender, EventArgs e)
        {
            if (textBox4.Text == "")
            {
                MessageBox.Show("Debe ingresar un dato a consultar");
            }
            else
            {
                LGestionArticulo instancia = new LGestionArticulo();
                instancia.valor = textBox4.Text;
                instancia.ConsultaEspecificaCodigo_articulo();
                DataTable tabla = new DataTable();
                tabla = instancia.ConsultaEspecificaCodigo_articulo();
                dataGridView2.DataSource = tabla;

            }
        }
        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox5.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
            textBox6.Text = dataGridView2.CurrentRow.Cells[2].Value.ToString();
            dateTimePicker2.Text = dataGridView2.CurrentRow.Cells[3].Value.ToString();
        }
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            LGestionArticulo instancia = new LGestionArticulo();
            LGestionArticulo comdatos = new LGestionArticulo();
            string respuesta = comdatos.Lactualizar(textBox5.Text, textBox6.Text, Convert.ToString(dateTimePicker2.Value));
            if (respuesta == "1")
            {
                MessageBox.Show("Actualizacion exitosa");
            }
            else
            {
                MessageBox.Show("Vuelva a intentarlo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            string Codigo_articulo = dataGridView2.CurrentRow.Cells[0].Value.ToString();
            LGestionArticulo instancia = new LGestionArticulo();
            instancia.Leliminar(Codigo_articulo);
            string respuesta = instancia.Leliminar(Codigo_articulo);
            if (respuesta == "1")
            {
                MessageBox.Show("Eliminacion exitosa");
            }
            else
            {
                MessageBox.Show("No se elimino la prenda");
            }
        }

        private void comboBox1_Enter(object sender, EventArgs e)
        {
            LGestionArticulo Instancia = new LGestionArticulo();
            DataTable tabla = new DataTable();
            tabla = Instancia.LConsultarCliente();
            comboBox1.DataSource = tabla;
            comboBox1.ValueMember = "Cedula_cliente";
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoloLetras(e);
        }
        public void SoloLetras(KeyPressEventArgs e)
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
            SoloNumeros(e);
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoloNumeros(e);
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoloLetras(e);
        }
 
    }
}