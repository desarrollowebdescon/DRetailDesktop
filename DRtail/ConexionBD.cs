using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DRtail
{
    class ConexionBD
    {
        public static SqlConnection ObtenerConexion()
        {
            SqlConnection con = new SqlConnection("Data Source=WIN-2IP0O7MLKO7\\SAPSERVER2016;Initial Catalog=DRtail;Persist Security Info=True;User ID=sa;Password=SAPB1Admin");
            con.Open();
            return con;
        }

    }
}
