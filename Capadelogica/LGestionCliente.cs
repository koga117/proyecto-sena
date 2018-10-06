using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Capadedatos;
using Capadelogica;
using System.Data;

namespace Capadelogica
{
    public class LGestionCliente
    {
        public string valor;
        public string LRegistrar(string a, string b, string c, string d, string e)
        {
            DGestionCliente instancia = new DGestionCliente();
            return instancia.DRegistrar(a, b, c, d, e);
        }
        public DataTable LConsultar()
        {
            DGestionCliente instancia = new DGestionCliente();
            return instancia.Dconsultar();
        }
        public DataTable LConsultaEspecificacodigo_cliente()
        {
            DGestionCliente instancia = new DGestionCliente();
            instancia.recibido = valor;
            return instancia.DConsultaEspecificaCodigo_cliente();
        }
        public string Lactualizar(string a, string b, string c, string d,string e)
        {
            DGestionCliente instancia = new DGestionCliente();
            return instancia.Dactualizar(a, b, c, d,e);
        }
        public string Leliminar(string a)
        {
            DGestionUsuario instancia = new DGestionUsuario();
            return instancia.Deliminar(a);
        }
    }
}
