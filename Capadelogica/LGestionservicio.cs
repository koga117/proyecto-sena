using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Capadedatos;
using Capadelogica;
using System.Data;

namespace Capadelogica
{
    public class LGestionservicio
    {
        public string valor;
        public string LRegistrar(string a, string b, string c, string d, string e,string f )
        {
            DGestionservicio instancia = new DGestionservicio();
            return instancia.DRegistrar(a, b, c, d, e,f);
        }
        public DataTable LConsultar()
        {
            DGestionservicio instancia = new DGestionservicio();
            return instancia.Dconsultar();
        }
        public DataTable ConsultaEspecificaCodigo_servicio()
        {
            DGestionservicio instancia = new DGestionservicio();
            instancia.recibido = valor;
            return instancia.ConsultaEspecificaCodigo_servicio();
        }
        public string Lactualizar(string a, string b, string c, string d, string e, string f)
        {
            DGestionservicio instancia = new DGestionservicio();
            return instancia.Dactualizar(a, b, c, d,e,f);
        }
        public string Leliminar(string a)
        {
            DGestionservicio instancia = new DGestionservicio();
            return instancia.Deliminar(a);
        }
    }
}
