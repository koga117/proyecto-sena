using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Presentacion
{
    public class PCedula
    {
        static string cedula;
        public void recibir(string a)
        {
            cedula = a;
        }
        public string compartir()
        {
            return cedula;
        }
    }
    public class Numero_identificacion
    {
        static string CedulaC;
        public void recibirc(string b)
        {
            CedulaC = b;
        }
    }

}

