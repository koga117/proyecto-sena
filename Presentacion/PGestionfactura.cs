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

    public partial class PGestionfactura : Form
    {
        public PGestionfactura()
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
        private void comboBox2_Enter(object sender, EventArgs e)
        {
            LGestionFactura Instancia = new LGestionFactura();
            DataTable ConjuntoDatos = new DataTable();
            ConjuntoDatos = Instancia.LConsultaServicios();
            comboBox2.DataSource = ConjuntoDatos;
            comboBox2.ValueMember = "Codigo_servicio";
            comboBox2.DisplayMember = "Descripcion";
        }
        private void comboBox2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            LGestionFactura Instancia = new LGestionFactura();
            DataTable ConjuntoDatos = new DataTable();
            ConjuntoDatos = Instancia.LDatosServicio(comboBox2.SelectedValue.ToString());
            textBox3.Text = ConjuntoDatos.Rows[0][1].ToString();
        }

        //private void pictureBox1_Click(object sender, EventArgs e)
        //{
        //    if (textBox1.Text == "" || comboBox1.Text == "" || textBox2.Text == "" || textBox3.Text=="" || dateTimePicker1.Text == ""|| textBox4.Text=="")
        //    {
        //        MessageBox.Show("Verifique, valores incompletos", "Validacion de campos vacios", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //    }
        //    else
        //    {
        //        LGestionFactura instancia = new LGestionFactura();
        //        //string respuesta = instancia.LRegistrar(textBox1.Text, comboBox1.Text, textBox2.Text, textBox3.Text, Convert.ToString(dateTimePicker1.Value),textBox4.Text, label4.Tex
        //        if (respuesta == "1")
        //        {
        //            MessageBox.Show("Registro exitoso", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        }
        //        else
        //        {
        //            MessageBox.Show("No se pudo registrar la nueva factura,vuelva a intentarlo", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        }

        //    }
        //    LGestionFactura instancia3 = new LGestionFactura();
        //    DataTable tabla = new DataTable();
        //    tabla = instancia3.Lconsultar();//invocacion 
        //    dataGridView1.DataSource = tabla;
        //}
        private void PGestionfactura_Load(object sender, EventArgs e)
        {


            PPerfil instancia1 = new PPerfil();
            label1.Text = instancia1.devolverPerfil();

            PCedula instancia2 = new PCedula();
            label4.Text = instancia2.compartir();

            LGestionFactura instancia4 = new LGestionFactura();
            DataTable tabla = new DataTable();
            tabla = instancia4.Lconsultar();//invocacion 
            dataGridView1.DataSource = tabla;
            if (tabla.Rows.Count == 0)
            {
                MessageBox.Show("Sin datos de consulta");
            }
        }
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (textBox10.Text == "")
            {
                MessageBox.Show("Debe ingresar un dato a consultar");
            }
            else
            {
                LGestionFactura instancia = new LGestionFactura();
                instancia.valor = textBox10.Text;
                DataTable tabla = new DataTable();
                tabla = instancia.LconsultaEspecificaCodigo_factura();
                dataGridView1.DataSource = tabla;
            }
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            LGestionFactura instancia = new LGestionFactura();
            DataTable ConjuntoDatos = new DataTable();
            ConjuntoDatos = instancia.LDatosArticulo(comboBox1.SelectedValue.ToString());
            textBox2.Text = ConjuntoDatos.Rows[0][2].ToString();
        }

        private void comboBox1_Enter(object sender, EventArgs e)
        {

        }

        //private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    SoloLetras(e);

        //}


        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
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
        private void comboBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoloLetras(e);
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoloLetras(e);
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoloLetras(e);
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoloNumeros(e);
        }

        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoloNumeros(e);
        }

        private void textBox11_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoloNumeros(e);
        }

        private void textBox10_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoloNumeros(e);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            LGestionFactura Instancia = new LGestionFactura();
            Instancia.LconsultaDetalleServicio(comboBox1.SelectedValue.ToString(), comboBox2.SelectedValue.ToString(), llcodigo_factura.Text);

            LGestionFactura instancia = new LGestionFactura();
            DataTable tabla1 = new DataTable();
            tabla1 = instancia.ConsultaDetalle_factura(llcodigo_factura.Text);//invocacion 
            dataGridView2.DataSource = tabla1;
            dataGridView2.Visible = true;

            LGestionFactura instanciav = new LGestionFactura();
            string[] resultado = instanciav.LValor_total(llcodigo_factura.Text);
            label21.Text = resultado[0];
            label17.Text = resultado[1];
            LGestionFactura instancia1 = new LGestionFactura();
            if (textBox5.Text != "" && label21.Text != "")
            {
                label22.Text = instancia1.LCambio(Convert.ToInt32(textBox5.Text), Convert.ToInt32(label21.Text)).ToString();
            }
            label23.Text = instancia.promedio_horas(Convert.ToInt32(label17.Text), Convert.ToInt32(label21.Text)).ToString();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            LGestionFactura instancia = new LGestionFactura();
            if (textBox5.Text != "" && label21.Text != "")
            {
                label22.Text = instancia.LCambio(Convert.ToInt32(textBox5.Text), Convert.ToInt32(label21.Text)).ToString();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            LGestionFactura InstanciaRegistrar_articulo = new LGestionFactura();
            string[] resultado = InstanciaRegistrar_articulo.LConsultarCliente(textBox1.Text);
            label7.Text = resultado[1];

            LGestionFactura instancia_articulo = new LGestionFactura();
            DataTable ConjuntoDatos = new DataTable();
            label20.Text = resultado[0];
            ConjuntoDatos = instancia_articulo.LConsultaArticulo(resultado[0]);
            comboBox1.DataSource = ConjuntoDatos;
            comboBox1.ValueMember = "Codigo_articulo";
            comboBox1.DisplayMember = "Tipo_prenda";

            LGestionFactura instanciaRegistrar_factura = new LGestionFactura();
            llcodigo_factura.Text = instanciaRegistrar_factura.LRegistrarF(label20.Text, label4.Text);
        }
    }

}
