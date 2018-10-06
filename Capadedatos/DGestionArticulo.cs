using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Capadedatos
{
    public class DGestionArticulo:Dconexion
    {
        public string recibido;
        public string DRegistrar(string a, string b, string c, string d)
        {
        //    try
        //    {
            SqlDataAdapter insertar1 = new SqlDataAdapter("ConsultarCodigocliente", CadenaConexion());
            insertar1.SelectCommand.CommandType = CommandType.StoredProcedure;
            insertar1.SelectCommand.Parameters.Add("@Cedula_cliente", SqlDbType.BigInt).Value = a;  
            DataTable tabla = new DataTable();
            insertar1.Fill(tabla);
            String r = tabla.Rows[0][0].ToString();
            //a = Convert.ToString(tabla);
            //string r = tabla[0][0];

                SqlCommand insertar = new SqlCommand("Insertararticulo", CadenaConexion());
                insertar.CommandType = CommandType.StoredProcedure;
                insertar.Parameters.Add("@Codigo_cliente", SqlDbType.BigInt).Value = r;
                insertar.Parameters.Add("@tipo_prenda", SqlDbType.VarChar, 50).Value = b;
                insertar.Parameters.Add("@fecha_registro", SqlDbType.Date).Value = c;
                insertar.Parameters.Add("@Registro", SqlDbType.BigInt).Value = d;
                insertar.Connection.Open();
                insertar.ExecuteNonQuery();
                return "1";
            //}
            //catch (Exception x)
            //{
            //    return x.ToString();
            //}
        }
          public DataTable DConnsultarcliente ()
            {
                SqlDataAdapter MyClient = new SqlDataAdapter("ConsultarClientesCC",CadenaConexion());
                MyClient.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable tabla = new DataTable();
                MyClient.Fill(tabla);
                return tabla;
            }
        public DataTable Dconsultar()
        {
            try
            {
                SqlDataAdapter Cgeneral = new SqlDataAdapter("CGA", CadenaConexion());
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
        public DataTable ConsultaEspecificaCodigo_articulo()
        {
            SqlDataAdapter consultaEs = new SqlDataAdapter("CEA", CadenaConexion());
            consultaEs.SelectCommand.CommandType = CommandType.StoredProcedure;
            consultaEs.SelectCommand.Parameters.Add("@Codigo_articulo",SqlDbType.BigInt).Value = recibido;
            //consultaEs.SelectCommand.Parameters.Add("Codigo_cliente Bigint ", SqlDbType.BigInt).Value = recibido;
            DataTable tabla = new DataTable();
            consultaEs.Fill(tabla);
            return tabla;
        }
        public string Dactualizar(string a, string b,string c)
        {
            SqlCommand ActualizarDatos = new SqlCommand("Actualizararticulo", CadenaConexion());
            ActualizarDatos.CommandType = CommandType.StoredProcedure;
            ActualizarDatos.Parameters.Add("@Codigo_articulo", SqlDbType.BigInt).Value = a;
            ActualizarDatos.Parameters.Add("@Tipo_prenda", SqlDbType.VarChar,50).Value = b;
            ActualizarDatos.Parameters.Add("@fecha_registro", SqlDbType.Date).Value = c;
            ActualizarDatos.Connection.Open();
            ActualizarDatos.ExecuteNonQuery();
            return "1";

        }
        public string Deliminar(string a)
        {
            try
            {
                SqlCommand Camestado = new SqlCommand("eliminararticulo", CadenaConexion());
                Camestado.CommandType = CommandType.StoredProcedure;// establece el procedimiento almacenado
                Camestado.Parameters.Add("Codigo_articulo", SqlDbType.BigInt).Value = a;
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

