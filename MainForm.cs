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
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			if (comboBox1.Items.Count > 0)
			{
				comboBox1.SelectedIndex = 0;
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
			string rolSeleccionado = comboBox1.Text.Trim();
			string usuario = textBox1.Text.Trim();
			string password = textBox2.Text;

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
					using (MySqlCommand cmd = new MySqlCommand("SP_INICIAR_SESION", conn))
					{
						cmd.CommandType = CommandType.StoredProcedure;
						cmd.Parameters.AddWithValue("p_username", usuario);
						cmd.Parameters.AddWithValue("p_password_hash", passwordHash);
						cmd.Parameters.AddWithValue("p_rol", rolSeleccionado);

						using (MySqlDataReader reader = cmd.ExecuteReader())
						{
							if (reader.Read())
							{
								string estado = reader["ESTADO"].ToString();

								if (estado != "Activo")
								{
									MessageBox.Show("Esta cuenta se encuentra INACTIVA. Contacta al administrador.",
									                "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Stop);
									return;
								}

								SesionActual.IdUsuario = Convert.ToInt32(reader["ID_USUARIO"]);
								SesionActual.NombreCompleto = reader["NOMBRE_COMPLETO"].ToString();
								SesionActual.Username = reader["USERNAME"].ToString();
								SesionActual.Rol = reader["ROL"].ToString();

								MessageBox.Show("Bienvenido(a), " + SesionActual.NombreCompleto + "\nRol: " + SesionActual.Rol,
								                "Acceso correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);

								Administrador ventanaPrincipal = new Administrador();
								ventanaPrincipal.FormClosed += (s, args) => this.Close();
								ventanaPrincipal.Show();
								this.Hide();
							}
							else
							{
								MessageBox.Show("Usuario, contraseña o rol incorrectos.",
								                "Error de autenticación", MessageBoxButtons.OK, MessageBoxIcon.Error);
								textBox2.Clear();
								textBox2.Focus();
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
