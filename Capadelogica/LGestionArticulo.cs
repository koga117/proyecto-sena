using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Capadedatos;
using Capadelogica;
using System.Data;
namespace Capadelogica
{
    public class LGestionArticulo
    {
            
        
        public DataTable LConsultarCliente()
        {
            DGestionArticulo Instancia = new DGestionArticulo();
            return Instancia.DConnsultarcliente();
        }
        public string valor;
        public string LRegistrar(string a, string b,string c,string d)
        {
            DGestionArticulo instancia = new DGestionArticulo();
            return instancia.DRegistrar(a,b,c,d);
        }
        public DataTable LConsultar()
        {
            DGestionArticulo instancia = new DGestionArticulo();
            instancia.recibido = valor;
            return instancia.Dconsultar();
        }
        public DataTable ConsultaEspecificaCodigo_articulo()
        {
            DGestionArticulo instancia = new DGestionArticulo();
            instancia.recibido = valor;
            return instancia.ConsultaEspecificaCodigo_articulo();
        }
        public string Lactualizar(string a, string b,string c)
        {
            DGestionArticulo instancia = new DGestionArticulo();
            return instancia.Dactualizar(a,b,c);
        }
        public string Leliminar(string a)
        {
            DGestionArticulo instancia = new DGestionArticulo();
            return instancia.Deliminar(a);
        }
    }
}
