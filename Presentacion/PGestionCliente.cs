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
    public partial class PGestionCliente : Form
    {
        public PGestionCliente()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            PMenu m = new PMenu();
            m.Show();
            this.Hide();
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox5.Text=="" )
            {
                MessageBox.Show("Verifique, valores incompletos", "Validacion de campos vacios", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    LGestionCliente instancia = new LGestionCliente();
                    string respuesta = instancia.LRegistrar(textBox1.Text, textBox2.Text, textBox3.Text, textBox5.Text, label6.Text);
                    if (respuesta == "1")
                    {
                        MessageBox.Show("Registro exitoso", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No se pudo registrar el nuevo cliente,vuelva a intentarlo", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception)
                {

                    MessageBox.Show("La cedula que intenta registrar ya existe");
                }
                

            }
            LGestionCliente instancia3 = new LGestionCliente();
            DataTable tabla = new DataTable();
            tabla = instancia3.LConsultar();//invocacion 
            dataGridView1.DataSource = tabla;
            
        }
        private void PGestionCliente_Load(object sender, EventArgs e)
        {
            PPerfil instancia1= new PPerfil();
            label12.Text=instancia1.devolverPerfil();


            PCedula instancia2 = new PCedula();
            label6.Text = instancia2.compartir();

            LGestionCliente instancia3 = new LGestionCliente();
            DataTable tabla = new DataTable();
            tabla = instancia3.LConsultar();//invocacion 
            dataGridView1.DataSource = tabla;
            if (tabla.Rows.Count == 0)
            {
                MessageBox.Show("Sin datos de consulta");
            }
        }
        private void pictureBox5_Click(object sender, EventArgs e)
        {
                if (textBox8.Text == "")
                {
                    MessageBox.Show("Debe ingresar un dato a consultar");
                }
                else
                {
                    LGestionCliente instancia = new LGestionCliente();
                    instancia.valor = textBox8.Text;
                    DataTable tabla = new DataTable();
                    tabla = instancia.LConsultaEspecificacodigo_cliente();
                    dataGridView1.DataSource = tabla;
                }
            }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox4.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox7.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox9.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox10.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
        }
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            LGestionCliente instancia = new LGestionCliente();
            //string respuesta = instancia.Lactualizar(textBox14.Text,textBox15.Text,textBox16.Text,textBox17.Text,textBox18.Text);
            LGestionCliente comdatos = new LGestionCliente();
            //comdatos.a = textBox4.Text;
            //comdatos.b = textBox6.Text;
            //comdatos.c = textBox7.Text;
            //comdatos.d = dateTimePicker2.Text;
            string respuesta = comdatos.Lactualizar(textBox4.Text, textBox6.Text, textBox7.Text,textBox9.Text,textBox10.Text);
            if (respuesta == "1")
            {
                MessageBox.Show("Actualizacion exitosa");
            }
            else
            {
                MessageBox.Show("Vuelva a intentarlo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            string Codigo_cliente = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            LGestionUsuario instancia = new LGestionUsuario();
            instancia.Leliminar(Codigo_cliente);
            string respuesta = instancia.Leliminar(Codigo_cliente);
            if (respuesta == "1")
            {
                MessageBox.Show("Eliminacion exitosa");
            }
            else
            {
                MessageBox.Show("No se elimino el cliente");
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

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoloNumeros(e);
        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoloNumeros(e);
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoloNumeros(e);
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoloNumeros(e);
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoloLetras(e);
        }

        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoloNumeros(e);
        }
    }
    }

