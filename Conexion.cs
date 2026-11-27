using System;
using MySql.Data.MySqlClient;

namespace Biblioteca
{
	public static class SesionActual
	{
		public static int IdUsuario { get; set; }
		public static string NombreCompleto { get; set; }
		public static string Username { get; set; }
		public static string Rol { get; set; }

		public static void Cerrar()
		{
			IdUsuario = 0;
			NombreCompleto = string.Empty;
			Username = string.Empty;
			Rol = string.Empty;
		}
	}

	public static class ConexionDB
	{
		private static string cadenaConexion = "Server=localhost;Database=biblioteca;Uid=root;Pwd=13579135ca;Allow User Variables=True;";

		public static MySqlConnection ObtenerConexion()
		{
			MySqlConnection conn = new MySqlConnection(cadenaConexion);
			conn.Open();
			return conn;
		}

		public static MySqlConnection ObtenerConexionConUsuario()
		{
			MySqlConnection conn = new MySqlConnection(cadenaConexion);
			conn.Open();

			if (!string.IsNullOrEmpty(SesionActual.Username))
			{
				using (MySqlCommand cmd = new MySqlCommand("SET @usuario_actual = @user;", conn))
				{
					cmd.Parameters.AddWithValue("@user", SesionActual.Username);
					cmd.ExecuteNonQuery();
				}
			}
			return conn;
		}
	}
}