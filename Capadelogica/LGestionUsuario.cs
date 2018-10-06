using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Capadedatos;
using Capadelogica;
using System.Data;
using System.Net.Mail;
namespace Presentacion
{
    public class LGestionUsuario
    {
        public string a{get;set;}
        public string b{get;set;}
        public string c{get;set;}
        public string d{get;set;}
        public string e{get;set;}
        public string f{get;set;}
        public string g{get;set;}
        public string h{get;set;}
        public string i{get;set;}
        public string j{get;set;}
        public string k{get;set;}
        public string valor{get;set;}
        public string correo;

        public string Lregistrar(bool Guardar = true)
        {

            if (b.Length >= 10)
                i = b.Replace(' ', '.').Substring(0, 9);
            else
                i = b.Replace(' ', '.');

            i = i + a.Substring(a.Length - 4);
            i = i.ToLower();


            Random aleatorio = new Random();
            string contrasena = "";
            string[] vals = new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9"};
            for (int i3 = 1; i3 <= 5; i3++)
            {
                contrasena = contrasena + vals[aleatorio.Next(vals.GetUpperBound(0) + 1)];
            }
            j = contrasena;

            //MailMessage mail = new MailMessage();
            //mail.To.Add(new MailAddress(correo));
            //mail.From = new MailAddress("ejerciciosigem@hotmail.com");
            //mail.Subject = " Registro Exitoso";
            //mail.Body = "Bienvenido su usuario es: " +i+ correo + " y su contraseña es: " + j;
            //mail.IsBodyHtml = false;
            //SmtpClient cl = new SmtpClient("smtp.live.com", 587);
            //using (cl)
            //{
            //    cl.Credentials = new System.Net.NetworkCredential("ejerciciosigem@hotmail.com", "Ejemplo1");
            //    cl.EnableSsl = true;
            //    cl.Send(mail);
            //}
            if (Guardar)
            {
                DGestionUsuario instancia = new DGestionUsuario();
                return instancia.Dregistrar(a, b, c, d, e, f, g, h, i, contrasena, k);
            }
            else {
                return "Datos generados correctamente";
            }
        }
        public DataTable Lconsultar()
        {
            DGestionUsuario instancia = new DGestionUsuario();
            return instancia.Dconsultar();
        }
        public DataTable ConsultaEspecificaNombre()
    {
        DGestionUsuario instancia = new DGestionUsuario();
        instancia.recibido=valor;
        return instancia.ConsultaEspecificaNombre();
    }
        public string Lactualizar()
        {
            DGestionUsuario instancia = new DGestionUsuario();
            return instancia.Dactualizar(a, b, c, d, e);
        }
        public string Leliminar(string a )
        {
            DGestionUsuario instancia = new DGestionUsuario();
            return instancia.Deliminar(a);
        }
    }
}
