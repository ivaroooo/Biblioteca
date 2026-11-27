using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Biblioteca
{
	public partial class FrmInventario : Form
	{
		public FrmInventario()
		{
			InitializeComponent();
		}

		private void FrmInventario_Load(object sender, EventArgs e)
		{
			CargarLibros("");
			txtIsbn.Focus();
		}

		private void CargarLibros(string filtro)
		{
			try
			{
				using (MySqlConnection conn = ConexionDB.ObtenerConexion())
				{
					string query = @"
						SELECT 
							isbn AS 'ISBN',
							codigo_barras AS 'Código Barras',
							nombre AS 'Título',
							autor AS 'Autor',
							categoria AS 'Categoría',
							disponibilidad AS 'Stock'
						FROM libro
						WHERE isbn LIKE @filtro
						   OR codigo_barras LIKE @filtro
						   OR nombre LIKE @filtro
						   OR autor LIKE @filtro
						   OR categoria LIKE @filtro
						ORDER BY nombre ASC;";

					using (MySqlCommand cmd = new MySqlCommand(query, conn))
					{
						cmd.Parameters.AddWithValue("@filtro", "%" + filtro + "%");
						MySqlDataAdapter da = new MySqlDataAdapter(cmd);
						DataTable dt = new DataTable();
						da.Fill(dt);
						dgvLibros.DataSource = dt;
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error al cargar inventario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void txtBuscar_TextChanged(object sender, EventArgs e)
		{
			CargarLibros(txtBuscar.Text.Trim());
		}

		private void dgvLibros_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex >= 0)
			{
				DataGridViewRow row = dgvLibros.Rows[e.RowIndex];
				txtIsbn.Text = row.Cells["ISBN"].Value.ToString();
				txtCodigoBarras.Text = row.Cells["Código Barras"].Value.ToString();
				txtNombre.Text = row.Cells["Título"].Value.ToString();
				txtAutor.Text = row.Cells["Autor"].Value.ToString();
				txtCategoria.Text = row.Cells["Categoría"].Value.ToString();
				numStock.Value = Convert.ToDecimal(row.Cells["Stock"].Value);
				txtIsbn.ReadOnly = true;
			}
		}

		// 1. INSERTAR NUEVO LIBRO
		private void btnAgregar_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrWhiteSpace(txtIsbn.Text) ||
			    string.IsNullOrWhiteSpace(txtCodigoBarras.Text) ||
			    string.IsNullOrWhiteSpace(txtNombre.Text) ||
			    string.IsNullOrWhiteSpace(txtAutor.Text) ||
			    string.IsNullOrWhiteSpace(txtCategoria.Text))
			{
				MessageBox.Show("Completa todos los campos antes de insertar el libro.", "Campos vacíos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			try
			{
				using (MySqlConnection conn = ConexionDB.ObtenerConexion())
				{
					string query = @"
						INSERT INTO libro (isbn, codigo_barras, nombre, autor, categoria, disponibilidad)
						VALUES (@isbn, @codigo, @nombre, @autor, @categoria, @stock);";

					using (MySqlCommand cmd = new MySqlCommand(query, conn))
					{
						cmd.Parameters.AddWithValue("@isbn", txtIsbn.Text.Trim());
						cmd.Parameters.AddWithValue("@codigo", txtCodigoBarras.Text.Trim());
						cmd.Parameters.AddWithValue("@nombre", txtNombre.Text.Trim());
						cmd.Parameters.AddWithValue("@autor", txtAutor.Text.Trim());
						cmd.Parameters.AddWithValue("@categoria", txtCategoria.Text.Trim());
						cmd.Parameters.AddWithValue("@stock", (int)numStock.Value);

						cmd.ExecuteNonQuery();
					}
				}

				MessageBox.Show("Libro agregado correctamente al catálogo.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
				LimpiarCampos();
				CargarLibros(txtBuscar.Text.Trim());
			}
			catch (MySqlException sqlEx)
			{
				MessageBox.Show("Error de Base de Datos (verifica que el ISBN o Código de Barras no estén repetidos):\n" + sqlEx.Message,
				                "Error SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error inesperado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		// 2. ALTERAR STOCK (Y datos generales del libro seleccionado)
		private void btnActualizarStock_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrWhiteSpace(txtIsbn.Text))
			{
				MessageBox.Show("Selecciona un libro de la tabla para modificar su stock.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			try
			{
				using (MySqlConnection conn = ConexionDB.ObtenerConexion())
				{
					string query = @"
						UPDATE libro 
						SET codigo_barras = @codigo,
						    nombre = @nombre,
						    autor = @autor,
						    categoria = @categoria,
						    disponibilidad = @stock
						WHERE isbn = @isbn;";

					using (MySqlCommand cmd = new MySqlCommand(query, conn))
					{
						cmd.Parameters.AddWithValue("@isbn", txtIsbn.Text.Trim());
						cmd.Parameters.AddWithValue("@codigo", txtCodigoBarras.Text.Trim());
						cmd.Parameters.AddWithValue("@nombre", txtNombre.Text.Trim());
						cmd.Parameters.AddWithValue("@autor", txtAutor.Text.Trim());
						cmd.Parameters.AddWithValue("@categoria", txtCategoria.Text.Trim());
						cmd.Parameters.AddWithValue("@stock", (int)numStock.Value);

						int filas = cmd.ExecuteNonQuery();
						if (filas > 0)
						{
							MessageBox.Show("Stock y datos del libro actualizados correctamente.", "Actualizado", MessageBoxButtons.OK, MessageBoxIcon.Information);
							LimpiarCampos();
							CargarLibros(txtBuscar.Text.Trim());
						}
						else
						{
							MessageBox.Show("No se encontró un libro con ese ISBN para actualizar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
						}
					}
				}
			}
			catch (MySqlException sqlEx)
			{
				MessageBox.Show("Error al actualizar el libro:\n" + sqlEx.Message, "Error SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		// 3. ELIMINAR LIBRO
		private void btnEliminar_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrWhiteSpace(txtIsbn.Text))
			{
				MessageBox.Show("Selecciona un libro de la tabla para eliminar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			DialogResult resp = MessageBox.Show("¿Seguro que deseas eliminar '" + txtNombre.Text + "' (ISBN: " + txtIsbn.Text + ") del catálogo?",
			                                    "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
			if (resp != DialogResult.Yes) return;

			try
			{
				using (MySqlConnection conn = ConexionDB.ObtenerConexion())
				{
					string query = "DELETE FROM libro WHERE isbn = @isbn;";

					using (MySqlCommand cmd = new MySqlCommand(query, conn))
					{
						cmd.Parameters.AddWithValue("@isbn", txtIsbn.Text.Trim());
						cmd.ExecuteNonQuery();
					}
				}

				MessageBox.Show("Libro eliminado del catálogo.", "Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
				LimpiarCampos();
				CargarLibros(txtBuscar.Text.Trim());
			}
			catch (MySqlException sqlEx)
			{
				MessageBox.Show("No se puede eliminar este libro porque ya tiene préstamos registrados en el historial.\n(" + sqlEx.Message + ")",
				                "Restricción de Integridad", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void btnLimpiar_Click(object sender, EventArgs e)
		{
			LimpiarCampos();
		}

		private void LimpiarCampos()
		{
			txtIsbn.ReadOnly = false;
			txtIsbn.Clear();
			txtCodigoBarras.Clear();
			txtNombre.Clear();
			txtAutor.Clear();
			txtCategoria.Clear();
			numStock.Value = 1;
			txtIsbn.Focus();
		}
	}
}