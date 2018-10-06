using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Presentacion
{
    public class PPerfil
    {
        static string Cargo;
        public void recibir(string nombre)
        {
            Cargo = nombre;
        }
        public string devolverPerfil()
        {
            return Cargo;
        }
    }
}
