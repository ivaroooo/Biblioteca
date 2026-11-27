using System;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Biblioteca
{
	public partial class RegistroUsuarios : Form
	{
		public RegistroUsuarios()
		{
			InitializeComponent();

			grpBLector.Visible = false;
			grpBLector.Enabled = true;

			grpBUsuario.Visible = false;
			grpBUsuario.Enabled = true;

			if (cboTipoUser.Items.Count > 0)
				cboTipoUser.SelectedIndex = 0;

			if (cmbSisRol.Items.Count > 0)
				cmbSisRol.SelectedIndex = 0;

			if (cmbSisEstado.Items.Count > 0)
				cmbSisEstado.SelectedIndex = 0;
		}


		void BtnMostrarClick(object sender, EventArgs e)
		{
			string seleccion = cboTipoUser.Text.Trim();

			if (seleccion == "Lector")
			{
				grpBUsuario.Visible = false;
				grpBLector.Visible = true;
				grpBLector.BringToFront(); 
				txtLectorNombre.Focus();
			}
			else if (seleccion == "Usuario de plataforma")
			{
				grpBLector.Visible = false;
				grpBUsuario.Visible = true;
				grpBUsuario.BringToFront();
				txtSisNombre.Focus();
			}
			else
			{
				MessageBox.Show("Selecciona primero qué tipo de usuario deseas ingresar.",
				                "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}

		void BtnRegistrarLectorClick(object sender, EventArgs e)
		{
			if (string.IsNullOrWhiteSpace(txtLectorNombre.Text) ||
			    string.IsNullOrWhiteSpace(txtLectorApellido.Text) ||
			    string.IsNullOrWhiteSpace(txtLectorCredencial.Text))
			{
				MessageBox.Show("Nombre, apellido y credencial son obligatorios.",
				                "Campos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			try
			{
				using (MySqlConnection conn = ConexionDB.ObtenerConexionConUsuario())
				{
					string query = @"INSERT INTO lector (nombre, apellido, credencial, correo) 
					                 VALUES (@nombre, @apellido, @credencial, @correo);";

					using (MySqlCommand cmd = new MySqlCommand(query, conn))
					{
						cmd.Parameters.AddWithValue("@nombre", txtLectorNombre.Text.Trim());
						cmd.Parameters.AddWithValue("@apellido", txtLectorApellido.Text.Trim());
						cmd.Parameters.AddWithValue("@credencial", txtLectorCredencial.Text.Trim());
						cmd.Parameters.AddWithValue("@correo", txtLectorCorreo.Text.Trim());
						cmd.ExecuteNonQuery();
					}
				}

				MessageBox.Show("Lector registrado correctamente.",
				                "Registro exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);

				
				txtLectorNombre.Clear();
				txtLectorApellido.Clear();
				txtLectorCredencial.Clear();
				txtLectorCorreo.Clear();
				grpBLector.Visible = false;
			}
			catch (MySqlException ex)
			{
				if (ex.Number == 1062)
				{
					MessageBox.Show("Ya existe un lector registrado con esa credencial.",
					                "Credencial duplicada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				}
				else
				{
					MessageBox.Show("Error en la base de datos: " + ex.Message,
					                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
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

		void BtnRegistrarUsuarioClick(object sender, EventArgs e)
		{
			if (string.IsNullOrWhiteSpace(txtSisNombre.Text) ||
			    string.IsNullOrWhiteSpace(txtSisUsuario.Text) ||
			    string.IsNullOrWhiteSpace(txtSisContraseña.Text))
			{
				MessageBox.Show("Completa nombre completo, usuario y contraseña.",
				                "Campos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			string passwordHash = GenerarSha256(txtSisContraseña.Text);

			try
			{
				using (MySqlConnection conn = ConexionDB.ObtenerConexionConUsuario())
				{
					string query = @"INSERT INTO usuarios_sistema (nombre_completo, username, password_hash, rol, estado) 
					                 VALUES (@nombre, @username, @hash, @rol, @estado);";

					using (MySqlCommand cmd = new MySqlCommand(query, conn))
					{
						cmd.Parameters.AddWithValue("@nombre", txtSisNombre.Text.Trim());
						cmd.Parameters.AddWithValue("@username", txtSisUsuario.Text.Trim());
						cmd.Parameters.AddWithValue("@hash", passwordHash);
						cmd.Parameters.AddWithValue("@rol", cmbSisRol.Text.Trim());
						cmd.Parameters.AddWithValue("@estado", cmbSisEstado.Text.Trim());
						cmd.ExecuteNonQuery();
					}
				}

				MessageBox.Show("Usuario de plataforma registrado correctamente.",
				                "Registro exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);

				
				txtSisNombre.Clear();
				txtSisUsuario.Clear();
				txtSisContraseña.Clear();
				grpBUsuario.Visible = false;
			}
			catch (MySqlException ex)
			{
				if (ex.Number == 1062)
				{
					MessageBox.Show("Ese nombre de usuario ya está ocupado. Elige otro.",
					                "Usuario duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				}
				else
				{
					MessageBox.Show("Error en la base de datos: " + ex.Message,
					                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}
		
		void BtnRegresarVerClick(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}