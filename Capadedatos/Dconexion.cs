using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace Capadedatos
{
    public class Dconexion
    {
        public SqlConnection CadenaConexion()
        {
            SqlConnection conexion = new SqlConnection("Data Source=DESKTOP-8V0F2FN\\SQLEXPRESS;Initial Catalog=Modisteria_Elsa;Integrated Security=True");
            return conexion;
        }
    }
}
