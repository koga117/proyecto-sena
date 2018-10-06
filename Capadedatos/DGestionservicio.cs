using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Capadedatos;

namespace Capadedatos
{
    public class DGestionservicio : Dconexion
    {
        public string recibido;
        public string DRegistrar(string a, string b, string c, string d,string e,string f)
        {
        //    try
        //    {
                SqlCommand insertar = new SqlCommand("Insertarservicio", CadenaConexion());
                insertar.CommandType = CommandType.StoredProcedure;
                insertar.Parameters.Add("@descripcion", SqlDbType.VarChar, 120).Value = a;
                insertar.Parameters.Add("@tipo_servicio", SqlDbType.Char, 1).Value = b;
                insertar.Parameters.Add("@horas_trabajadas", SqlDbType.Decimal).Value = c;
                insertar.Parameters.Add("@valor_servicio", SqlDbType.Real).Value = d;
                insertar.Parameters.Add("@fecha_inicio", SqlDbType.Date).Value = e;
                insertar.Parameters.Add("@registro", SqlDbType.BigInt).Value = f;
                insertar.Connection.Open();
                insertar.ExecuteNonQuery();
                return "1";
            //}
            //catch (Exception x)
            //{
            //    return x.ToString();
            //}
        }
        public DataTable Dconsultar()
        {
            //try
            //{
                SqlDataAdapter Cgeneral = new SqlDataAdapter("CGS", CadenaConexion());
                Cgeneral.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable tabla = new DataTable();
                Cgeneral.Fill(tabla);
                return tabla;
            }
        //    catch
        //    {
        //        DataTable tabla = new DataTable();
        //        return tabla;
        //    }

        public DataTable ConsultaEspecificaCodigo_servicio()
        {
            SqlDataAdapter consultaEs = new SqlDataAdapter("CES", CadenaConexion());
            consultaEs.SelectCommand.CommandType = CommandType.StoredProcedure;
            consultaEs.SelectCommand.Parameters.Add("@Codigo_servicio", SqlDbType.BigInt).Value = recibido;
            DataTable tabla = new DataTable();
            consultaEs.Fill(tabla);
            return tabla;
        }
        public string Dactualizar(string a, string b, string c, string d, string e , string f)
        {
            SqlCommand ActualizarDatos = new SqlCommand("actualizarservicio", CadenaConexion());
            ActualizarDatos.CommandType = CommandType.StoredProcedure;
            ActualizarDatos.Parameters.Add("@Codigo_servicio", SqlDbType.BigInt).Value = a;
            ActualizarDatos.Parameters.Add("@descripcion", SqlDbType.VarChar,120).Value = b;
            ActualizarDatos.Parameters.Add("@tipo_servicio", SqlDbType.Char, 1).Value = c;
            ActualizarDatos.Parameters.Add("@horas_trabajadas", SqlDbType.VarChar,50).Value = d;
            ActualizarDatos.Parameters.Add("@valor_servicio", SqlDbType.Real).Value = e;
            ActualizarDatos.Parameters.Add("@fecha_inicio", SqlDbType.Date).Value = f;
            ActualizarDatos.Connection.Open();
            ActualizarDatos.ExecuteNonQuery();
            return "1";
        }
        public string Deliminar(string a)
        {
            try
            {
                SqlCommand Camestado = new SqlCommand("Eliminarservicio", CadenaConexion());
                Camestado.CommandType = CommandType.StoredProcedure;// establece el procedimiento almacenado
                Camestado.Parameters.Add("@Codigo_servicio", SqlDbType.BigInt).Value = a;
                Camestado.Connection.Open();//abre la conexion
                Camestado.ExecuteNonQuery();
                return "1";
            }
            catch
            {
                return "2";
            }
        }
    }
}
