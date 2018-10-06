using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using Capadedatos;

namespace Capadelogica
{
    public class ConsultaRegistradoPor
    {
        public string LConsultaRP(string a)
        {
            DatosdeConsultaRegistradoPor Insatancia = new DatosdeConsultaRegistradoPor();
            return Insatancia.Consultar(a);
        }
        public string LConsultaCCL(string a)
        {
            DatosdeConsultaRegistradoPor Insatancia = new DatosdeConsultaRegistradoPor();
            return Insatancia.Consultar(a);
        }
        public string LConsultaRPC(string a)
        {
            DatosdeConsultaRegistradoPor Insatancia = new DatosdeConsultaRegistradoPor();
            return Insatancia.ConsultarC(a);
        }
        public string LConsultaCargo(string a)
        {
            DatosdeConsultaRegistradoPor Insatancia = new DatosdeConsultaRegistradoPor();
            return Insatancia.ConsultarC(a);
        }
    }
}
