using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DRtail
{
    class ConsultasBD
    {
        public static DataTable EjecutaQueryDT(string query)
        {
            DataTable dt_Consulta = new DataTable();
            try
            {                
                SqlConnection conexion = ConexionBD.ObtenerConexion();
                SqlDataAdapter adapter = new SqlDataAdapter(query, conexion);
                adapter.Fill(dt_Consulta);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Consulta:" + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dt_Consulta;
        }

        public static List<DatosUsuario> LlenarCombo(string query)
        {
            List<DatosUsuario> listaEstilos = new List<DatosUsuario>();
            SqlConnection conexion = ConexionBD.ObtenerConexion();

            SqlCommand consulta = new SqlCommand(query, conexion);
            SqlDataReader rd = consulta.ExecuteReader();
            while (rd.Read())
            {
                DatosUsuario dtos = new DatosUsuario();
                dtos.value = rd.GetInt32(0);
                dtos.display = rd.GetString(1);
                listaEstilos.Add(dtos);
            }
            return listaEstilos;
        }
    }
}
