using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Capadedatos;
using Capadelogica;
using System.Data;

namespace Capadelogica
{
    public class LGestionFactura
    {
        public string[] LConsultarCliente(string a)
        {
            DGestionFactura Instancia = new DGestionFactura();
            return Instancia.DConsultarCliente(a);
        }
        public DataTable ConsultaDetalle_factura(string a)
        {
            DGestionFactura instancia = new DGestionFactura();
            instancia.recibido = valor;
            return instancia.ConsultaDetalle_factura(a);
        }
        public DataTable LConsultaArticulo(string a)
        {
            DGestionFactura Instancia = new DGestionFactura();
            return Instancia.DConsultaArticulo(a);
        }

        public DataTable LDatosArticulo(string a)
        {
            DGestionFactura Instancia = new DGestionFactura();
            return Instancia.DDatosPorArticulo(a);
        }
        public DataTable LConsultaServicios()
        {
            DGestionFactura Instancia = new DGestionFactura();
            return Instancia.DConsultaServicios();
        }

        public DataTable LDatosServicio(string a)
        {
            DGestionFactura Instancia = new DGestionFactura();
            return Instancia.DDatosPorServicio(a);
        }
        public string valor;
        public string LRegistrar(string a, string b, string c, string d, string e, string f)
        {
            DGestionFactura instancia = new DGestionFactura();
            return instancia.DRegistrar(a, b, c, d, e, f);
        }
        public string LRegistrarF(string a, string b)
        {
            DGestionFactura instancia = new DGestionFactura();
            return instancia.DregistrarF(a, b);
        }
        public DataTable Lconsultar()
        {
            DGestionFactura instancia = new DGestionFactura();
            return instancia.Dconsultar();
        }
        public DataTable LconsultaEspecificaCodigo_factura()
        {
            DGestionFactura instancia = new DGestionFactura();
            instancia.recibido = valor;
            return instancia.ConsultaEspecificaCodigo_factura();
        }
        public bool LconsultaDetalleServicio(string a, string b, string c)
        {
            DGestionFactura instancia = new DGestionFactura();
            return instancia.Detalle_servicio(a, b, c);
        }
        public string[] LValor_total(string a)
        {
            DGestionFactura instanciav = new DGestionFactura();
            return instanciav.DValor_total(a);

        }
        public int LCambio(int paga, int valor_total)
        {
            int cambio = 0;
            cambio = paga - valor_total  ;
            return cambio;
        }
        public int promedio_horas(int horas_trabajadas,int paga)
        {
            int cambio=0;
            cambio = paga / horas_trabajadas;
            return cambio;

        }
    }
}
