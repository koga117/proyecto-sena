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
    public partial class PGestionservicio : Form
    {
        public PGestionservicio()
        {
            InitializeComponent();
        }
        
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (textBox5.Text=="" ||textBox1.Text == "" || comboBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || dateTimePicker1.Text == "")
            {
                MessageBox.Show("Verifique, valores incompletos", "Validacion de campos vacios", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                LGestionservicio instancia = new LGestionservicio();
                string respuesta = instancia.LRegistrar( textBox1.Text, comboBox1.Text, textBox2.Text, textBox3.Text, Convert.ToString(dateTimePicker1.Value), label6.Text);
                if (respuesta == "1")
                {
                    MessageBox.Show("Registro exitoso", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No se pudo registrar el nuevo servicio,vuelva a intentarlo", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            LGestionservicio instancia3 = new LGestionservicio();
            DataTable tabla = new DataTable();
            tabla = instancia3.LConsultar();//invocacion 
            dataGridView1.DataSource = tabla;

        }

        private void PGestionservicio_Load(object sender, EventArgs e)
        {
            PPerfil instancia1 = new PPerfil();
            label3.Text = instancia1.devolverPerfil();


            PCedula instancia2 = new PCedula();
            label6.Text = instancia2.compartir();

            LGestionservicio instancia3 = new LGestionservicio();
            DataTable tabla = new DataTable();
            tabla = instancia3.LConsultar();//invocacion 
            dataGridView1.DataSource = tabla;
            if (tabla.Rows.Count == 1)
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
                LGestionservicio instancia = new LGestionservicio();
                instancia.valor = textBox4.Text;
                instancia.ConsultaEspecificaCodigo_servicio();
                DataTable tabla = new DataTable();
                tabla = instancia.ConsultaEspecificaCodigo_servicio();
                dataGridView1.DataSource = tabla;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox7.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox8.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            comboBox2.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox9.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox10.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            dateTimePicker1.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
           
            
        }
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            LGestionservicio instancia = new LGestionservicio();
            LGestionservicio comdatos = new LGestionservicio();
            string respuesta = comdatos.Lactualizar(textBox7.Text, textBox8.Text,comboBox2.Text, textBox9.Text,textBox10.Text, Convert.ToString(dateTimePicker2.Value));
            if (respuesta == "1")
            {
                MessageBox.Show("Actualizacion exitosa");
            }
            else
            {
                MessageBox.Show("Vuelva a intentarlo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            string Codigo_servicio = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            LGestionservicio instancia = new LGestionservicio();
            instancia.Leliminar(Codigo_servicio);
            string respuesta = instancia.Leliminar(Codigo_servicio);
            if (respuesta == "1")
            {
                MessageBox.Show("Eliminacion exitosa");
            }
            else
            {
                MessageBox.Show("No se elimino el servicio");
            }
        }

        private void textBox5_Click(object sender, EventArgs e)
        {
            LGestionArticulo instancia = new LGestionArticulo();
            DataTable tabla = new DataTable();
            tabla = instancia.LConsultar();//invocacion 
            dataGridView2.DataSource = tabla;
            dataGridView2.Visible = true;
           
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox5.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
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

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoloLetras(e);
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoloNumeros(e);
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoloNumeros(e);
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoloNumeros(e);
        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoloLetras(e);
        }

        private void comboBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoloLetras(e);
        }

        private void textBox10_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoloNumeros(e);
        }

      
    }
}
