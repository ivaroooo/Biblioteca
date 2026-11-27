using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Biblioteca
{
	public partial class UsuariosVer : Form
	{
		public UsuariosVer()
		{
			InitializeComponent();

			dataGridView1.ReadOnly = true;
			dataGridView1.AllowUserToAddRows = false;
			dataGridView1.AllowUserToDeleteRows = false;
			dataGridView1.MultiSelect = false;
			dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

			if (cboTipoUsuario.Items.Count > 0)
			{
				cboTipoUsuario.SelectedIndex = 0;
			}
		}

		void CboTipoUsuarioSelectedIndexChanged(object sender, EventArgs e)
		{
			CargarDatosTipo();
		}

		public void CargarDatosTipo()
		{
			string tipoSeleccionado = cboTipoUsuario.Text.Trim();
			string query = "";

			if (tipoSeleccionado == "Usuario de plataforma")
			{
				query = @"SELECT idUsuario AS 'ID', 
				                 nombre_completo AS 'Nombre Completo', 
				                 username AS 'Usuario', 
				                 rol AS 'Rol', 
				                 estado AS 'Estado' 
				          FROM usuarios_sistema;";
			}
			else if (tipoSeleccionado == "Lector")
			{
				query = @"SELECT idLector AS 'ID', 
				                 nombre AS 'Nombre', 
				                 apellido AS 'Apellido', 
				                 credencial AS 'Credencial', 
				                 correo AS 'Correo' 
				          FROM lector;";
			}
			else
			{
				return;
			}

			try
			{
				using (MySqlConnection conn = ConexionDB.ObtenerConexion())
				{
					using (MySqlDataAdapter da = new MySqlDataAdapter(query, conn))
					{
						DataTable dt = new DataTable();
						da.Fill(dt);
						dataGridView1.DataSource = dt;
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error al cargar los datos: " + ex.Message,
				                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		void BtnEliminarClick(object sender, EventArgs e)
		{
			if (dataGridView1.CurrentRow == null || dataGridView1.SelectedRows.Count == 0)
			{
				MessageBox.Show("Selecciona primero una fila de la tabla para eliminar.",
				                "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			string tipoSeleccionado = cboTipoUsuario.Text.Trim();
			int idSeleccionado = Convert.ToInt32(dataGridView1.CurrentRow.Cells["ID"].Value);

			
			if (tipoSeleccionado == "Usuario de plataforma" && idSeleccionado == SesionActual.IdUsuario)
			{
				MessageBox.Show("No puedes eliminar tu propio usuario mientras tienes la sesión abierta.",
				                "Acción no permitida", MessageBoxButtons.OK, MessageBoxIcon.Stop);
				return;
			}

			DialogResult confirmar = MessageBox.Show(
				"¿Estás segura de eliminar este registro de forma permanente?",
				"Confirmar eliminación",
				MessageBoxButtons.YesNo,
				MessageBoxIcon.Question);

			if (confirmar != DialogResult.Yes)
			{
				return;
			}

			string queryDelete = "";
			if (tipoSeleccionado == "Usuario de plataforma")
			{
				queryDelete = "DELETE FROM usuarios_sistema WHERE idUsuario = @id;";
			}
			else if (tipoSeleccionado == "Lector")
			{
				queryDelete = "DELETE FROM lector WHERE idLector = @id;";
			}

			try
			{
				using (MySqlConnection conn = ConexionDB.ObtenerConexionConUsuario())
				{
					using (MySqlCommand cmd = new MySqlCommand(queryDelete, conn))
					{
						cmd.Parameters.AddWithValue("@id", idSeleccionado);
						cmd.ExecuteNonQuery();
					}
				}

				MessageBox.Show("Registro eliminado correctamente.",
				                "Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);

				CargarDatosTipo();
			}
			catch (MySqlException ex)
			{
				if (ex.Number == 1451)
				{
					MessageBox.Show("No se puede eliminar este registro porque tiene préstamos asociados en el historial.",
					                "Restricción de integridad", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				}
				else
				{
					MessageBox.Show("Error en la base de datos: " + ex.Message,
					                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}

		void BtnRegresarClick(object sender, EventArgs e)
		{
			this.Close();
			VentanaPrincipal vp = new VentanaPrincipal();
			vp.Show();
		}
		
		void BtnRegistrarClick(object sender, EventArgs e)
		{
			RegistroUsuarios registrar = new RegistroUsuarios();
			registrar.Show();
			
		}
	}
}
