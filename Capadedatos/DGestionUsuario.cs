using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Capadedatos
{
    public class DGestionUsuario : Dconexion
    {
        public string recibido { get; set; }
        public string Dregistrar(string a, string b, string c, string d, string e, string f, string g, string h, string i, string j, string k)
        {
        //    try
        //    {
                SqlCommand insertar = new SqlCommand("creacionusuario", CadenaConexion());
                insertar.CommandType = CommandType.StoredProcedure;
                insertar.Parameters.Add("@cedula", SqlDbType.BigInt).Value = a;
                insertar.Parameters.Add("@nombre", SqlDbType.VarChar, 120).Value = b;
                insertar.Parameters.Add("@genero", SqlDbType.Char, 1).Value = c;
                insertar.Parameters.Add("@cargo", SqlDbType.Char, 1).Value = d;
                insertar.Parameters.Add("@tel_fijo", SqlDbType.Int).Value = e;
                insertar.Parameters.Add("@direccion", SqlDbType.VarChar, 50).Value = f;
                insertar.Parameters.Add("@Eps", SqlDbType.VarChar, 50).Value = g;
                insertar.Parameters.Add("@celular", SqlDbType.BigInt).Value = h;
                insertar.Parameters.Add("@usuario", SqlDbType.VarChar, 50).Value = i;
                insertar.Parameters.Add("@contrasena", SqlDbType.VarChar, 50).Value = j;
                insertar.Parameters.Add("@registro", SqlDbType.BigInt).Value = k;
                insertar.Connection.Open();
                insertar.ExecuteNonQuery();
                return "1";
            } 
            //catch (Exception x)
            //{
            //    return x.ToString();
            //}
        //}
        public DataTable Dconsultar()
        {
            try
            {
                SqlDataAdapter Cgeneral = new SqlDataAdapter("CGU", CadenaConexion());
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
        public DataTable ConsultaEspecificaNombre()
        {
            SqlDataAdapter consultaEn = new SqlDataAdapter("CEN", CadenaConexion());
            consultaEn.SelectCommand.CommandType = CommandType.StoredProcedure;
            consultaEn.SelectCommand.Parameters.Add("@Nombre", SqlDbType.VarChar, 120).Value = recibido;
            //consultaEn.SelectCommand.Parameters.Add("@Cedula", SqlDbType.BigInt).Value = recibido;
            DataTable tabla = new DataTable();
            consultaEn.Fill(tabla);
            return tabla;
        }
        public string Dactualizar(string a, string b, string c, string d,string e)
        {
            SqlCommand ActualizarDatos = new SqlCommand("actualizarusuario", CadenaConexion());
            ActualizarDatos.CommandType = CommandType.StoredProcedure;
            ActualizarDatos.Parameters.Add("@Cedula", SqlDbType.BigInt).Value = a;
            ActualizarDatos.Parameters.Add("@direccion", SqlDbType.VarChar, 120).Value = b;
            ActualizarDatos.Parameters.Add("@tel_fijo", SqlDbType.BigInt).Value = c;
            ActualizarDatos.Parameters.Add("@celular", SqlDbType.BigInt).Value = d;
            ActualizarDatos.Parameters.Add("@estado", SqlDbType.Char,1).Value = e;
            ActualizarDatos.Connection.Open();
            ActualizarDatos.ExecuteNonQuery();
            return "1";

        }
        public string Deliminar(string a)
        {
            try
            {
                SqlCommand Camestado = new SqlCommand("eliminarusuario", CadenaConexion());
                Camestado.CommandType = CommandType.StoredProcedure;// establece el procedimiento almacenado
                Camestado.Parameters.Add("@Cedula", SqlDbType.BigInt).Value = a;
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
    