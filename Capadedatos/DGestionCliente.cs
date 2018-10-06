using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Capadedatos;


namespace Capadedatos
{
    public class DGestionCliente : Dconexion
    {
        public string recibido;
        public string DRegistrar(string a, string b, string c, string d, string e)
        {
            try
            {
                SqlCommand insertar = new SqlCommand("creacioncliente", CadenaConexion());
                insertar.CommandType = CommandType.StoredProcedure;
                insertar.Parameters.Add("@cedula_cliente", SqlDbType.BigInt).Value = a;
                insertar.Parameters.Add("@Nombre", SqlDbType.VarChar, 120).Value = b;
                insertar.Parameters.Add("@Tel_fijo", SqlDbType.Int).Value = c;
                insertar.Parameters.Add("@Direccion", SqlDbType.VarChar, 120).Value = d;
                insertar.Parameters.Add("@Registro", SqlDbType.BigInt).Value = e;
                insertar.Connection.Open();
                insertar.ExecuteNonQuery();
                return "1";
            }
            catch (Exception)
            {
                throw;
            }
        }
        public DataTable Dconsultar()
        {
            try
            {
                SqlDataAdapter Cgeneral = new SqlDataAdapter("Consultarcliente", CadenaConexion());
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
        public DataTable DConsultaEspecificaCodigo_cliente()
        {
            SqlDataAdapter consultaEs = new SqlDataAdapter("CEC", CadenaConexion());
            consultaEs.SelectCommand.CommandType = CommandType.StoredProcedure;
            consultaEs.SelectCommand.Parameters.Add("@Codigo_cliente", SqlDbType.BigInt).Value = recibido;
            DataTable tabla = new DataTable();
            consultaEs.Fill(tabla);
            return tabla;
        }
        public string Dactualizar(string a, string b, string c, string d,string e)
        {
            SqlCommand ActualizarDatos = new SqlCommand("Actualizarcliente", CadenaConexion());
            ActualizarDatos.CommandType = CommandType.StoredProcedure;
            ActualizarDatos.Parameters.Add("@Codigo_cliente", SqlDbType.BigInt).Value = a;
            ActualizarDatos.Parameters.Add("@Cedula_cliente", SqlDbType.BigInt).Value = b;
            ActualizarDatos.Parameters.Add("@Nombre_cliente", SqlDbType.VarChar, 50).Value = c;
            ActualizarDatos.Parameters.Add("@tel_fijo", SqlDbType.Int).Value = d;
            ActualizarDatos.Parameters.Add("@direccion", SqlDbType.VarChar, 50).Value = e;
            ActualizarDatos.Connection.Open();
            ActualizarDatos.ExecuteNonQuery();
            return "1";

        }
        public string Deliminar(string a)
        {
            //try
            //{
                SqlCommand Camestado = new SqlCommand("eliminarcliente", CadenaConexion());
                Camestado.CommandType = CommandType.StoredProcedure;// establece el procedimiento almacenado
                Camestado.Parameters.Add("@Codigo_cliente", SqlDbType.BigInt).Value = a;
                Camestado.Connection.Open();//abre la conexion
                Camestado.ExecuteNonQuery();
                return "1";
            }
            //catch
            //{
            //    return "2";
            //}
        }
    }
//}