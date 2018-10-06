using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Capadedatos;


namespace Capadelogica
{
    public class Llogin
    {
        public string Validacion(string tipo,string nombre,string contraseña)
        {
            Dlogin enviovalidacion=new Dlogin();
            return enviovalidacion.Dvalidacion(tipo,nombre,contraseña);
        }
    }
}
