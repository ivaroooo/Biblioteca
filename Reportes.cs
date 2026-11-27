using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Biblioteca
{
	public partial class Reportes : Form
	{
		public Reportes()
		{
			InitializeComponent();
		}

		void ReportesLoad(object sender, EventArgs e)
		{
			this.Text = "Reportes del Sistema - Usuario: " + SesionActual.NombreCompleto;

			dgvReportes.ReadOnly = true;
			dgvReportes.AllowUserToAddRows = false;
			dgvReportes.AllowUserToDeleteRows = false;
			dgvReportes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dgvReportes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

			// Carga el primer reporte por defecto al abrir
			CargarVista("vw_libros_mas_prestados", "Libros más prestados");
		}

		private void CargarVista(string nombreVista, string tituloReporte)
		{
			try
			{
				using (MySqlConnection conn = ConexionDB.ObtenerConexion())
				{
					string query = "SELECT * FROM " + nombreVista + ";";

					using (MySqlDataAdapter da = new MySqlDataAdapter(query, conn))
					{
						DataTable dt = new DataTable();
						da.Fill(dt);
						dgvReportes.DataSource = dt;

						lblTotal.Text = tituloReporte + " | Registros encontrados: " + dt.Rows.Count;
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error al cargar el reporte: " + ex.Message,
				                "Error de Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		void BtnMasPrestadosClick(object sender, EventArgs e)
		{
			CargarVista("vw_libros_mas_prestados", "Libros más prestados");
		}

		void BtnPrestamosVencidosClick(object sender, EventArgs e)
		{
			CargarVista("vw_prestamos_vencidos", "Préstamos con retraso");
		}

		void BtnCerrarClick(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}