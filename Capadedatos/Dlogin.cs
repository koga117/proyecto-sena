using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Capadedatos
{
    public class Dlogin : Dconexion//herencia
    {
        public string Dvalidacion(string cargo, string Nu, string c)
        {
            try
            {
                
                SqlCommand consulta = new SqlCommand("validacionusuario", CadenaConexion());
                consulta.CommandType = CommandType.StoredProcedure;
                consulta.Parameters.Add("@var_tipousuario", SqlDbType.Char, 1).Value = cargo;
                consulta.Parameters.Add("@var_usuario", SqlDbType.VarChar, 50).Value = Nu;
                consulta.Parameters.Add("@var_contrasena", SqlDbType.VarChar, 50).Value = c;
                consulta.Connection.Open();
                SqlDataReader validar = consulta.ExecuteReader();
                if (validar.Read() == true)
                {
                    return "1";
                }
                else
                {
                    return "2";
                }
            }
            catch(Exception error)
            {
                return error.ToString();
            }
        }
    }
}
        