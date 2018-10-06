using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Presentacion
{
    public class Pfactura
    {
        static string dato;
        public void recibir(string codigoC)
        {
            dato = codigoC;
        }
        public string devolverCodigo_cliente()
        {
            return dato;
        }
    }
}
