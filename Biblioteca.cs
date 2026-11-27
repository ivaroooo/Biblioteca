using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Biblioteca
{
	public partial class VentanaPrincipal : Form
	{
		public VentanaPrincipal()
		{
			InitializeComponent();

			this.Text = "Biblioteca - Usuario: " + SesionActual.NombreCompleto + " | Rol: " + SesionActual.Rol;

			dataGridView1.ReadOnly = true;
			dataGridView1.AllowUserToAddRows = false;
			dataGridView1.AllowUserToDeleteRows = false;
			dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

			AplicarPermisosPorRol();
			CargarCatalogo("");
		}

		private void AplicarPermisosPorRol()
		{
			switch (SesionActual.Rol)
			{
				case "Bibliotecario":
					btnPrestamos.Enabled = true;
					btnStock.Enabled = true;
					btnReporte.Enabled = true;
					btnUsuarios.Enabled = true;
					break;

				case "Administrador":
					btnPrestamos.Enabled = true;
					btnStock.Enabled = false;
					btnReporte.Enabled = true;
					btnUsuarios.Enabled = true;
					break;

				case "Consulta":
					btnPrestamos.Enabled = false;
					btnStock.Enabled = false;
					btnReporte.Enabled = false;
					btnUsuarios.Enabled = false;
					break;

				default:
					btnPrestamos.Enabled = false;
					btnStock.Enabled = false;
					btnReporte.Enabled = false;
					btnUsuarios.Enabled = false;
					break;
			}
		}

		public void CargarCatalogo(string filtro)
		{
			try
			{
				using (MySqlConnection conn = ConexionDB.ObtenerConexion())
				{
					string query = @"SELECT isbn AS 'ISBN', 
					                        codigo_barras AS 'Código de Barras', 
					                        nombre AS 'Título', 
					                        autor AS 'Autor', 
					                        categoria AS 'Categoría', 
					                        disponibilidad AS 'Disponibles'
					                 FROM libro
					                 WHERE nombre LIKE @filtro 
					                    OR autor LIKE @filtro 
					                    OR codigo_barras LIKE @filtro 
					                    OR categoria LIKE @filtro;";

					using (MySqlCommand cmd = new MySqlCommand(query, conn))
					{
						cmd.Parameters.AddWithValue("@filtro", "%" + filtro + "%");

						using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
						{
							DataTable dt = new DataTable();
							da.Fill(dt);
							dataGridView1.DataSource = dt;
						}
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error al cargar el catálogo: " + ex.Message,
				                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		void TextBox1TextChanged(object sender, EventArgs e)
		{
			TextBox caja = sender as TextBox;
			if (caja != null)
			{
				CargarCatalogo(caja.Text.Trim());
			}
		}

		void BtnCerrarSesionClick(object sender, EventArgs e)
		{
			SesionActual.Cerrar();
			MainForm login = new MainForm();
			login.Show();
			this.Hide();
		}

		void BtnUsuariosClick(object sender, EventArgs e)
		{
			UsuariosVer usuarisvista = new UsuariosVer();
			usuarisvista.ShowDialog();
		}

		void BtnReporteClick(object sender, EventArgs e)
		{
			Reportes ventanaReportes = new Reportes();
			ventanaReportes.ShowDialog();
		}

		void BtnPrestamosClick(object sender, EventArgs e)
		{
			FrmMostrador mostrador = new FrmMostrador();
			mostrador.ShowDialog();
			CargarCatalogo(dataGridView1.Text.Trim());
		}
		void BtnStockClick(object sender, EventArgs e)
		{
    		FrmInventario inventario = new FrmInventario();
    		inventario.ShowDialog();
    		CargarCatalogo(txtBuscar.Text.Trim());
		}
	}
}