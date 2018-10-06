using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
namespace Capadedatos
{
    public class DatosdeConsultaRegistradoPor : Dconexion
    {
        public string Consultar(string a)
        {
            SqlDataAdapter ConsultarDatos = new SqlDataAdapter("ConsultarRegistrado", CadenaConexion());
            ConsultarDatos.SelectCommand.CommandType = CommandType.StoredProcedure;
            ConsultarDatos.SelectCommand.Parameters.Add("@nombreusuario", SqlDbType.VarChar, 120).Value = a;
            DataTable Tabla = new DataTable();
            ConsultarDatos.Fill(Tabla);
            string cedula = Tabla.Rows[0][0].ToString();
            return cedula;

        }
        public string ConsultarC(string a)
        {
            SqlDataAdapter ConsultarDatos = new SqlDataAdapter("ConsultarRegistradoC", CadenaConexion());
            ConsultarDatos.SelectCommand.CommandType = CommandType.StoredProcedure;
            ConsultarDatos.SelectCommand.Parameters.Add("@nombreusuario", SqlDbType.VarChar, 120).Value = a;
            DataTable Tabla = new DataTable();
            ConsultarDatos.Fill(Tabla);
            string Cargo = Tabla.Rows[0][0].ToString();
            return Cargo;

        }
        public string ConsultarCodigo_cliente(string a)
        {
            SqlDataAdapter ConsultarDatos = new SqlDataAdapter("ConsultarCodigo_cliente", CadenaConexion());
            ConsultarDatos.SelectCommand.CommandType = CommandType.StoredProcedure;
            ConsultarDatos.SelectCommand.Parameters.Add("@codigo_cliente", SqlDbType.BigInt).Value = a;
            DataTable Tabla = new DataTable();
            ConsultarDatos.Fill(Tabla);
            string codigo_cliente = Tabla.Rows[0][0].ToString();
            return codigo_cliente;
        }
    }

}
