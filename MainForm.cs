/*
 * Created by SharpDevelop.
 * User: dulma
 * Date: 19/11/2026
 * Time: 10:31 a. m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Biblioteca
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
			
			if (cboRol.Items.Count > 0)
			{
				cboRol.SelectedIndex = 0;
			}
			this.AcceptButton = btnLogin;
		}
		
		private string GenerarSha256(string texto)
		{
			using (SHA256 sha256 = SHA256.Create())
			{
				byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(texto));
				StringBuilder sb = new StringBuilder();
				for (int i = 0; i < bytes.Length; i++)
				{
					sb.Append(bytes[i].ToString("x2"));
				}
				return sb.ToString();
			}
		}
		
		void BtnLoginClick(object sender, EventArgs e)
		{
			string rolSeleccionado = cboRol.Text.Trim();
			string usuario = txtUsuario.Text.Trim();
			string password = txtContraseña.Text;


			if (string.IsNullOrEmpty(rolSeleccionado) || string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(password))
			{
				MessageBox.Show("Por favor, selecciona un rol e ingresa usuario y contraseña.",
				                "Campos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			string passwordHash = GenerarSha256(password);

			try
			{
				using (MySqlConnection conn = ConexionDB.ObtenerConexion())
				{
					using (MySqlCommand cmd = new MySqlCommand("iniciar_sesion", conn))
					{
						cmd.CommandType = CommandType.StoredProcedure;
						cmd.Parameters.AddWithValue("p_username", usuario);
						cmd.Parameters.AddWithValue("p_password_hash", passwordHash);
						cmd.Parameters.AddWithValue("p_rol", rolSeleccionado);

						using (MySqlDataReader reader = cmd.ExecuteReader())
						{
							if (reader.Read())
							{
								string estado = reader["estado"].ToString();

								if (estado != "Activo")
								{
									MessageBox.Show("Esta cuenta se encuentra INACTIVA. Contacta al administrador.",
									                "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Stop);
									return;
								}

								SesionActual.IdUsuario = Convert.ToInt32(reader["idUsuario"]);
								SesionActual.NombreCompleto = reader["nombre_completo"].ToString();
								SesionActual.Username = reader["username"].ToString();
								SesionActual.Rol = reader["rol"].ToString();

								MessageBox.Show("Bienvenido(a), " + SesionActual.NombreCompleto + "\nRol: " + SesionActual.Rol,
								                "Acceso correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);

								VentanaPrincipal ventanaPrincipal = new VentanaPrincipal();
								ventanaPrincipal.FormClosed += (s, args) => this.Close();
								ventanaPrincipal.Show();
								this.Hide();
							}
							else
							{
								MessageBox.Show("Usuario, contraseña o rol incorrectos.",
								                "Error de autenticación", MessageBoxButtons.OK, MessageBoxIcon.Error);
								txtContraseña.Clear();
								txtContraseña.Focus();
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error al conectar con la base de datos:\n" + ex.Message,
				                "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
		
		void Label4Click(object sender, EventArgs e)
		{
			
		}
	}
}