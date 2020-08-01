using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;



namespace EntidadesCorreo
{
    public static class PaqueteDAO
    {
        private static SqlCommand comando; 
        private static SqlConnection conexion;

        /// <summary>
        /// Constructo estatico, instancia conexion a SQL
        /// </summary>
        static PaqueteDAO()
        {
           PaqueteDAO.conexion = new SqlConnection("Data source = .; DataBase = correo-sp-2017;  Trusted_Connection=true;");
           PaqueteDAO.comando = new SqlCommand();
           PaqueteDAO.comando.Connection = PaqueteDAO.conexion;
        }

        /// <summary>
        /// Metodo para agregar paquete a base de datos
        /// </summary>
        /// <param name="p">Paquete a agregar</param>
        /// <returns>True, en caso de cargar. False si no establece conexion</returns>
        public static bool Insertar(Paquete p)
        {          
            if (conexion.State != System.Data.ConnectionState.Open)
            {
                PaqueteDAO.conexion.Open();
            }

            PaqueteDAO.comando.CommandText = "INSERT INTO dbo.Paquetes (direccionEntrega, trackingID, alumno) VALUES(@direccionEntrega, @trackingID, @alumno);";
            PaqueteDAO.comando.Parameters.Clear();
            PaqueteDAO.comando.Parameters.AddWithValue("@direccionEntrega", p.DireccionEntrega);
            PaqueteDAO.comando.Parameters.AddWithValue("@trackingID", p.TrackingID);
            PaqueteDAO.comando.Parameters.AddWithValue("@alumno", "Marcos Delgado");

            comando.ExecuteNonQuery();
                      
            if (conexion.State == System.Data.ConnectionState.Open)
            {
                conexion.Close();
            }

            return true;
        }
    }
}
