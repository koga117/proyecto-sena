using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Capadedatos;

namespace Capadedatos
{
    public class DGestionFactura : Dconexion
    {
        public DataTable ConsultaDetalle_factura(string a)
        {
            SqlDataAdapter consultaEs = new SqlDataAdapter("detalle_servicioF", CadenaConexion());
            consultaEs.SelectCommand.CommandType = CommandType.StoredProcedure;
            consultaEs.SelectCommand.Parameters.Add("@codigo_factura", SqlDbType.BigInt).Value = (a);
            DataTable tabla = new DataTable();
            consultaEs.Fill(tabla);
            return tabla;
        }
        public string[] DConsultarCliente(string a)
        {
            try
            {
                SqlDataAdapter Consultar = new SqlDataAdapter("ConsultarNombreCliente", CadenaConexion());
                Consultar.SelectCommand.CommandType = CommandType.StoredProcedure;
                Consultar.SelectCommand.Parameters.Add("@cedula_cliente", SqlDbType.BigInt).Value = Convert.ToInt32(a);
                DataTable tabla = new DataTable();
                Consultar.Fill(tabla);
                string[] resultado = { tabla.Rows[0][0].ToString(), tabla.Rows[0][1].ToString() };
                return resultado;
            }
            catch
            {
                string[] resultado = { "Cliente no registrado", "Cliente no registrado" };
                return resultado;
            }
        }
        public DataTable DConsultaArticulo(string a)
        {
            try
            {
                SqlDataAdapter adaptador = new SqlDataAdapter("ConsultaArticulo", CadenaConexion());
                adaptador.SelectCommand.CommandType = CommandType.StoredProcedure;
                adaptador.SelectCommand.Parameters.Add("@codigo_cliente", SqlDbType.BigInt).Value = Convert.ToInt32(a);
                DataTable ds = new DataTable();
                adaptador.Fill(ds);
                return ds;
            }
            catch
            {
                return null;
            }
        }

        public DataTable DDatosPorArticulo(string b)
        {
            SqlDataAdapter adaptador = new SqlDataAdapter("DatosporArticulo", CadenaConexion());
            adaptador.SelectCommand.CommandType = CommandType.StoredProcedure;
            adaptador.SelectCommand.Parameters.Add("@codigo_articulo", SqlDbType.BigInt).Value = Convert.ToInt32(b);
            DataTable ds = new DataTable();
            adaptador.Fill(ds);
            return ds;
        }
        public DataTable DConsultaServicios()
        {
            SqlDataAdapter adaptador = new SqlDataAdapter("ConsultaServicio", CadenaConexion());
            adaptador.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable ds = new DataTable();
            adaptador.Fill(ds);
            return ds;
        }
        public DataTable DDatosPorServicio(string b)
        {
            SqlDataAdapter adaptador = new SqlDataAdapter("DatosporServicio", CadenaConexion());
            adaptador.SelectCommand.CommandType = CommandType.StoredProcedure;
            adaptador.SelectCommand.Parameters.Add("@codigo_servicio", SqlDbType.BigInt).Value = Convert.ToInt32(b);
            DataTable ds = new DataTable();
            adaptador.Fill(ds);
            return ds;
        }
        public string recibido;
        //public string DRegistrar(string a, string b, string c, string d, string e, string f, string g)
        //{
        //    //try
        //    //{
        //    SqlCommand insertar = new SqlCommand("Insertarfactura", CadenaConexion());
        //    insertar.CommandType = CommandType.StoredProcedure;
        //    insertar.Parameters.Add("@Nombre", SqlDbType.VarChar, 50).Value = a;
        //    insertar.Parameters.Add("@Articulo", SqlDbType.VarChar, 50).Value = b;
        //    insertar.Parameters.Add("@Valor_servicio", SqlDbType.Real).Value = c;
        //    insertar.Parameters.Add("@fecha_entrega", SqlDbType.Date).Value = d;
        //    insertar.Parameters.Add("@Paga", SqlDbType.Real).Value = e;
        //    insertar.Parameters.Add("@registro", SqlDbType.BigInt).Value = f;
        //    insertar.Parameters.Add("@Codigo_cliente", SqlDbType.BigInt).Value = g;
        //    insertar.Connection.Open();
        //    insertar.ExecuteNonQuery();
        //    return "1";
        //    //}
        //    //catch (Exception x)
        //    //{
        //    //    return x.ToString();
        //    //}
        //}
        public string DregistrarF(string a, string b)
        {
            SqlCommand insertarf = new SqlCommand("InsertarfacturaSimple", CadenaConexion());
            insertarf.CommandType = CommandType.StoredProcedure;
            insertarf.Parameters.Add("@codigo_cliente", SqlDbType.BigInt).Value = a;
            insertarf.Parameters.Add("@registro", SqlDbType.BigInt).Value = b;
            insertarf.Parameters.Add("@codigo_factura", SqlDbType.BigInt).Direction = ParameterDirection.Output;
            insertarf.Connection.Open();
            insertarf.ExecuteNonQuery();
            string Codigo_factura = insertarf.Parameters["@codigo_factura"].Value.ToString();
            return Codigo_factura;

        }
        public DataTable Dconsultar()
        {
            try
            {
                SqlDataAdapter Cgeneral = new SqlDataAdapter("CGF", CadenaConexion());
                Cgeneral.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable tabla = new DataTable();
                Cgeneral.Fill(tabla);
                return tabla;
            }
            catch
            {
                DataTable tabla = new DataTable();
                return tabla;
            }
        }
        public DataTable ConsultaEspecificaCodigo_factura()
        {
            SqlDataAdapter consultaEn = new SqlDataAdapter("CEF", CadenaConexion());
            consultaEn.SelectCommand.CommandType = CommandType.StoredProcedure;
            consultaEn.SelectCommand.Parameters.Add("@Codigo_factura", SqlDbType.VarChar, 120).Value = recibido;
            //consultaEn.SelectCommand.Parameters.Add("@Registro", SqlDbType.BigInt).Value = recibido;
            //consultaEn.SelectCommand.Parameters.Add("@Codigo_cliente", SqlDbType.BigInt).Value = recibido;
            DataTable tabla = new DataTable();
            consultaEn.Fill(tabla);
            return tabla;
        }
        public bool Detalle_servicio(string a, string b, string c)
        {

            SqlCommand insertar = new SqlCommand("Insertar_detalle_servicio", CadenaConexion());
            insertar.CommandType = CommandType.StoredProcedure;
            insertar.Parameters.Add("@codigo_articulo", SqlDbType.BigInt).Value = a;
            insertar.Parameters.Add("@codigo_servicio", SqlDbType.BigInt).Value = b;
            insertar.Parameters.Add("@codigo_factura", SqlDbType.BigInt).Value = c;
            insertar.Connection.Open();
            insertar.ExecuteNonQuery();
            return true;


        }
        public string[] DValor_total(string a)
        {
            SqlCommand insertarv = new SqlCommand("Valor_total", CadenaConexion());
            insertarv.CommandType = CommandType.StoredProcedure;
            insertarv.Parameters.Add("@codigo_factura", SqlDbType.BigInt).Value = a;
            insertarv.Parameters.Add("@valor_total", SqlDbType.Real).Direction = ParameterDirection.Output;
            insertarv.Parameters.Add("@horas_trabajadas", SqlDbType.Decimal).Direction = ParameterDirection.Output;
            insertarv.Connection.Open();
            insertarv.ExecuteNonQuery();
            string Valor_total = insertarv.Parameters["@valor_total"].Value.ToString();
            string Horas_trabajadas = insertarv.Parameters["@horas_trabajadas"].Value.ToString();
            string[] resultado = { Valor_total, Horas_trabajadas };
            return resultado;

        }
    }
}
