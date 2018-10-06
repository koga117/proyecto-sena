using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Capadedatos
{
    public class DImagen
    {
        public string InsertarImagen(byte[] a)
        {
            try
            {
                SqlConnection conexion = new SqlConnection("Data source=DESKTOP-8V0F2FN\\SQLEXPRESS;Initial catalog=Modisteria_Elsa;Integrated security=true");
                SqlCommand Insertar_Imagen = new SqlCommand("InsertImagen", conexion);
                Insertar_Imagen.CommandType = CommandType.StoredProcedure;
                Insertar_Imagen.Parameters.Add("@Ima", SqlDbType.VarBinary, 8000).Value = a;
                Insertar_Imagen.Connection.Open();
                Insertar_Imagen.ExecuteNonQuery();
                return "1";
            }
            catch (Exception x)
            {
                return x.ToString();
            }
        }
    }
}
