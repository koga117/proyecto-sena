using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Capadelogica;
using System.IO;

namespace Presentacion
{
    public partial class PLogin : Form
    {
        public PLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void FormLogin_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox2_MouseHover(object sender, EventArgs e)
        {
            pictureBox2.Size = new Size(56, 59);
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.Size = new Size(52, 50);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }


        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                textBox2.UseSystemPasswordChar = false;
            }
            else
            {
                textBox2.UseSystemPasswordChar = true;

            }
        }
        private void pictureBox2_Click(object sender, EventArgs e)//Metodo
        {
            string nombreusuario = textBox1.Text;
            string contraseña = textBox2.Text;
            string tipo;
            if (radioButton1.Checked == true)
            {
                tipo = "Administrador";
            }
            else
                if (radioButton2.Checked == true)
                {
                    tipo = "Secretaria";
                }
                else
                {
                    tipo = "Cajero";
                }


            if (radioButton1.Checked == false && radioButton2.Checked == false && radioButton3.Checked == false || textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("no se pueden dejar espacios en blanco por favor verifique que todos estén diligenciados", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Llogin Enviodedatos = new Llogin();//Define un objeto,instancicacion
                string valor = Enviodedatos.Validacion(tipo, nombreusuario, contraseña);//Sobrecarga al metodo
                if (valor == "2")
                {
                    MessageBox.Show("Intente de nuevo", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (valor == "1")
                {

                    MessageBoxButtons botones = MessageBoxButtons.YesNoCancel;
                    DialogResult respuesta = MessageBox.Show("Desea seleccionar una imagen para su perfil", "Modisteria y sastreria", botones, MessageBoxIcon.Question);
                    if (respuesta == DialogResult.No)
                    {
                        MessageBox.Show("Se le proporcionara una imagen general");
                    }
                    else if (respuesta == DialogResult.Yes)
                    {
                        MessageBox.Show("Por favor seleccione la imagen");
                        SeleccionImagen I = new SeleccionImagen();
                        this.Hide();
                        I.Show();
                        MemoryStream memoria = new MemoryStream();
                        byte[] memoria_imagen = memoria.ToArray();
                        LImagen instancia2 = new LImagen();
                        string imagen = instancia2.RecibirImagen(memoria_imagen);

                    }
                    PMenu m = new PMenu();//instanciando la clase PMenu
                    m.perfil = tipo;
                    m.Show();//Muestra el objeto
                    ConsultaRegistradoPor instancia = new ConsultaRegistradoPor();
                    string cargo = instancia.LConsultaCargo(textBox1.Text);
                    MessageBox.Show(cargo);
                    PPerfil instancia1 = new PPerfil();
                    instancia1.recibir(cargo);
                    //este codigo consulta la cedula para el registrado por instancia 
                    ConsultaRegistradoPor Instancia = new ConsultaRegistradoPor();
                    string cedula = Instancia.LConsultaCCL(textBox1.Text);
                    MessageBox.Show(cedula);
                    //Comunico el dato de cedula a una clase accesible para 
                    PCedula miinstancia = new PCedula();
                    miinstancia.recibir(cedula);
                    m.Show();//Mostrando un objeto
                    this.Hide();//el form actual es ocultado
                }
                else 
                {
                    MessageBox.Show(valor, "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
            }
       


        




    

