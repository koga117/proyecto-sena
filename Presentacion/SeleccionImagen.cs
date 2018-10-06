using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO; //Nueva libreria a adicionar para permitir crear objetos MemoryStream
using Capadelogica;

namespace Presentacion
{
    public partial class SeleccionImagen : Form
    {
        public SeleccionImagen()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialogo = new OpenFileDialog(); //Se crea el nuevo objeto cuadro de dialogo
            DialogResult resultado = dialogo.ShowDialog(); //Se muestra esperando una acción del usuario
            if (resultado == DialogResult.OK) //Si selecciona un archivo, se muestra en el ptb1
            {
                ptb1.Image = Image.FromFile(dialogo.FileName);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MemoryStream memoria = new MemoryStream();  //Crea un objeto Stream como Buffer (Datos en un espacio de memoria)
            ptb1.Image.Save(memoria, System.Drawing.Imaging.ImageFormat.Jpeg); //Almacena la imagen en el Buffer
            byte[] memoria_imagen = memoria.ToArray();  //Se extrae la cadena para almacenarla en una variable tipo binario

            LImagen Instancia = new LImagen(); //Instancia de la clase
            string respuesta = Instancia.RecibirImagen(memoria_imagen); //Sobrecarga del dato binario al metodo RecibirImagen
            if (respuesta == "1")
            {
                MessageBox.Show("Inserción exitosa de la imagen");
                PLogin instancia = new PLogin();
                instancia.clsBotonCircular1.Image = ptb1.Image; 
            }
            else
            {
                MessageBox.Show(respuesta);
            }
        }
    }
}
