
using System.Data.SqlClient;

namespace ApiWebRamo
{
    public class ClsConexion
    {
        public static SqlCommand CrearConexion()
        {
            SqlConnection conexion = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DB"].ConnectionString);

            conexion.Open();
            return conexion.CreateCommand();
        }
    }
}