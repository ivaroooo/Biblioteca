using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Biblioteca
{
    public partial class FrmMostrador : Form
    {
        private int idUsuarioActual
        {
            get { return SesionActual.IdUsuario > 0 ? SesionActual.IdUsuario : 2; }
        }

        private string usernameActual
        {
            get { return !string.IsNullOrEmpty(SesionActual.Username) ? SesionActual.Username : "bibliotecario"; }
        }

        public FrmMostrador()
        {
            InitializeComponent();
        }

        private void FrmMostrador_Load(object sender, EventArgs e)
        {
            dtpFechaDevolucion.MinDate = DateTime.Today;
            dtpFechaDevolucion.Value = DateTime.Today.AddDays(7);

            CargarLectores();
            CargarPrestamosActivos("");
        }

        // Asegura que el cursor esté listo en la caja del escáner apenas abre la ventana
        private void FrmMostrador_Shown(object sender, EventArgs e)
        {
            txtCodigoBarras.Focus();
        }

        private void CargarLectores()
        {
            try
            {
                using (MySqlConnection conn = ConexionDB.ObtenerConexion())
                {
                    string query = "SELECT idLector, CONCAT(credencial, ' - ', nombre, ' ', apellido) AS datos FROM lector ORDER BY nombre;";
                    MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    cmbLector.DisplayMember = "datos";
                    cmbLector.ValueMember = "idLector";
                    cmbLector.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar lectores: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtCodigoBarras_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
                BuscarYAgregarLibro(txtCodigoBarras.Text);
            }
        }

        private void txtCodigoBarras_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r' || e.KeyChar == '\n')
            {
                e.Handled = true;
                BuscarYAgregarLibro(txtCodigoBarras.Text);
            }
        }

        private void btnBuscarManual_Click(object sender, EventArgs e)
        {
            BuscarYAgregarLibro(txtCodigoBarras.Text);
        }

        private void BuscarYAgregarLibro(string codigoCrudo)
        {
            string codigo = codigoCrudo.Replace("\r", "").Replace("\n", "").Replace("'", "-").Trim();
            if (string.IsNullOrEmpty(codigo)) return;

            try
            {
                using (MySqlConnection conn = ConexionDB.ObtenerConexion())
                {
                    using (MySqlCommand cmd = new MySqlCommand("sp_buscar_ejemplar_por_codigo", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@p_codigo_barras", codigo);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string isbn = reader["isbn"].ToString();
                                string codBarras = reader["codigo_barras"].ToString();
                                string titulo = reader["titulo"].ToString();
                                int stockDisponible = Convert.ToInt32(reader["disponibilidad"]);

                                if (stockDisponible <= 0)
                                {
                                    lblInfoLibro.ForeColor = Color.Red;
                                    lblInfoLibro.Text = "SIN STOCK: " + titulo;
                                    MessageBox.Show("No quedan copias disponibles de '" + titulo + "'.", "Sin Inventario", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }

                                bool yaExiste = false;
                                foreach (DataGridViewRow row in dgvCarritoLibros.Rows)
                                {
                                    if (row.Cells["colISBN"].Value.ToString() == isbn)
                                    {
                                        int cantActual = Convert.ToInt32(row.Cells["colCantidad"].Value);
                                        if (cantActual + 1 > stockDisponible)
                                        {
                                            MessageBox.Show("Solo hay " + stockDisponible + " copias disponibles en total.", "Límite de Stock", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                            return;
                                        }
                                        row.Cells["colCantidad"].Value = cantActual + 1;
                                        yaExiste = true;
                                        break;
                                    }
                                }

                                if (!yaExiste)
                                {
                                    dgvCarritoLibros.Rows.Add(isbn, codBarras, titulo, 1);
                                }

                                int copiasLibres = ConsultarCopiasDisponiblesOUT(isbn);

                                lblInfoLibro.ForeColor = Color.DarkGreen;
                                lblInfoLibro.Text = string.Format("Detectado: {0} | Disponibles en catálogo: {1}", titulo, copiasLibres);
                            }
                            else
                            {
                                lblInfoLibro.ForeColor = Color.Red;
                                lblInfoLibro.Text = "Código no encontrado: " + codigo;
                                MessageBox.Show("No se encontró ningún libro con el código o ISBN: " + codigo, "No encontrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar libro: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                txtCodigoBarras.Clear();
                txtCodigoBarras.Focus();
            }
        }

        private int ConsultarCopiasDisponiblesOUT(string isbn)
        {
            using (MySqlConnection conn = ConexionDB.ObtenerConexion())
            {
                using (MySqlCommand cmd = new MySqlCommand("sp_contar_copias_disponibles", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@p_isbn", isbn);

                    MySqlParameter outParam = new MySqlParameter("@p_disponibles", MySqlDbType.Int32);
                    outParam.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(outParam);

                    cmd.ExecuteNonQuery();
                    return Convert.ToInt32(outParam.Value);
                }
            }
        }

        private void btnQuitarLibro_Click(object sender, EventArgs e)
        {
            if (dgvCarritoLibros.SelectedRows.Count > 0)
            {
                dgvCarritoLibros.Rows.RemoveAt(dgvCarritoLibros.SelectedRows[0].Index);
                txtCodigoBarras.Focus();
            }
        }

        private void btnConfirmarPrestamo_Click(object sender, EventArgs e)
        {
            if (cmbLector.SelectedValue == null)
            {
                MessageBox.Show("Selecciona un lector/alumno.", "Faltan datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dgvCarritoLibros.Rows.Count == 0)
            {
                MessageBox.Show("Escanea al menos un libro antes de confirmar.", "Tabla vacía", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idLector = Convert.ToInt32(cmbLector.SelectedValue);
            DateTime fechaDev = dtpFechaDevolucion.Value.Date;

            using (MySqlConnection conn = ConexionDB.ObtenerConexion())
            {
                MySqlTransaction transaccion = conn.BeginTransaction();

                try
                {
                    int idPrestamoGenerado = 0;

                    using (MySqlCommand cmdCabecera = new MySqlCommand("sp_crear_cabecera_prestamo", conn, transaccion))
                    {
                        cmdCabecera.CommandType = CommandType.StoredProcedure;
                        cmdCabecera.Parameters.AddWithValue("@p_id_lector", idLector);
                        cmdCabecera.Parameters.AddWithValue("@p_id_usuario_sistema", idUsuarioActual);
                        cmdCabecera.Parameters.AddWithValue("@p_fecha_devolucion", fechaDev);
                        cmdCabecera.Parameters.AddWithValue("@p_usuario_auditoria", usernameActual);

                        MySqlParameter outId = new MySqlParameter("@p_id_prestamo_generado", MySqlDbType.Int32);
                        outId.Direction = ParameterDirection.Output;
                        cmdCabecera.Parameters.Add(outId);

                        cmdCabecera.ExecuteNonQuery();
                        idPrestamoGenerado = Convert.ToInt32(outId.Value);
                    }

                    foreach (DataGridViewRow row in dgvCarritoLibros.Rows)
                    {
                        string codigoBarras = row.Cells["colCodigo"].Value.ToString();
                        int cantidad = Convert.ToInt32(row.Cells["colCantidad"].Value);

                        using (MySqlCommand cmdDetalle = new MySqlCommand("sp_agregar_detalle_prestamo", conn, transaccion))
                        {
                            cmdDetalle.CommandType = CommandType.StoredProcedure;
                            cmdDetalle.Parameters.AddWithValue("@p_id_prestamo", idPrestamoGenerado);
                            cmdDetalle.Parameters.AddWithValue("@p_codigo_barras", codigoBarras);
                            cmdDetalle.Parameters.AddWithValue("@p_cantidad", cantidad);
                            cmdDetalle.Parameters.AddWithValue("@p_usuario_auditoria", usernameActual);

                            cmdDetalle.ExecuteNonQuery();
                        }
                    }

                    transaccion.Commit();

                    MessageBox.Show("Préstamo #" + idPrestamoGenerado + " registrado correctamente.\nFecha límite de entrega: " + fechaDev.ToShortDateString(),
                                    "Préstamo Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    dgvCarritoLibros.Rows.Clear();
                    lblInfoLibro.Text = "Listo para escanear...";
                    CargarPrestamosActivos("");
                    txtCodigoBarras.Focus();
                }
                catch (MySqlException sqlEx)
                {
                    try { transaccion.Rollback(); } catch { }
                    MessageBox.Show("Error de Base de Datos al registrar préstamo (Transacción revertida):\n" + sqlEx.Message,
                                    "Transacción Cancelada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    try { transaccion.Rollback(); } catch { }
                    MessageBox.Show("Error inesperado (Transacción revertida): " + ex.Message,
                                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void CargarPrestamosActivos(string filtro)
        {
            try
            {
                using (MySqlConnection conn = ConexionDB.ObtenerConexion())
                {
                    string query = @"
                        SELECT 
                            p.idPrestamo AS 'Folio',
                            l.credencial AS 'Credencial',
                            CONCAT(l.nombre, ' ', l.apellido) AS 'Alumno',
                            GROUP_CONCAT(CONCAT(lib.nombre, ' (x', dp.cantidad, ')') SEPARATOR ', ') AS 'Libros Prestados',
                            p.fechaPrestamo AS 'Fecha Salida',
                            p.fechaDevolucion AS 'Fecha Límite',
                            IF(CURDATE() > p.fechaDevolucion, 'RETRASADO', 'A tiempo') AS 'Estatus'
                        FROM prestamo p
                        INNER JOIN lector l ON p.idLector = l.idLector
                        INNER JOIN detallesPrestamo dp ON p.idPrestamo = dp.idPrestamo
                        INNER JOIN libro lib ON dp.isbn = lib.isbn
                        WHERE p.estado = 'Activo'
                          AND (l.credencial LIKE @filtro 
                               OR l.nombre LIKE @filtro 
                               OR l.apellido LIKE @filtro
                               OR lib.codigo_barras LIKE @filtro
                               OR p.idPrestamo LIKE @filtro)
                        GROUP BY p.idPrestamo
                        ORDER BY p.fechaDevolucion ASC;";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@filtro", "%" + filtro + "%");
                        MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        dgvPrestamosActivos.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar préstamos activos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtBuscarDevolucion_TextChanged(object sender, EventArgs e)
        {
            CargarPrestamosActivos(txtBuscarDevolucion.Text.Trim());
        }

        private void btnRegistrarDevolucion_Click(object sender, EventArgs e)
        {
            if (dgvPrestamosActivos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona un préstamo de la tabla para devolver.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idPrestamo = Convert.ToInt32(dgvPrestamosActivos.SelectedRows[0].Cells["Folio"].Value);
            string alumno = dgvPrestamosActivos.SelectedRows[0].Cells["Alumno"].Value.ToString();
            string estatus = dgvPrestamosActivos.SelectedRows[0].Cells["Estatus"].Value.ToString();

            string mensajeConfirmacion = string.Format("¿Confirmar la devolución del Préstamo #{0} de {1}?", idPrestamo, alumno);
            if (estatus == "RETRASADO")
            {
                mensajeConfirmacion += "\n\nNOTA: Este préstamo tiene fecha vencida.";
            }

            DialogResult resp = MessageBox.Show(mensajeConfirmacion, "Confirmar Devolución", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resp != DialogResult.Yes) return;

            using (MySqlConnection conn = ConexionDB.ObtenerConexion())
            {
                MySqlTransaction transaccion = conn.BeginTransaction();

                try
                {
                    using (MySqlCommand cmd = new MySqlCommand("sp_registrar_devolucion", conn, transaccion))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@p_id_prestamo", idPrestamo);
                        cmd.Parameters.AddWithValue("@p_usuario_auditoria", usernameActual);

                        cmd.ExecuteNonQuery();
                    }

                    transaccion.Commit();

                    MessageBox.Show("Devolución registrada con éxito. El inventario de los libros ha sido restaurado.", "Devolución Completa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarPrestamosActivos(txtBuscarDevolucion.Text.Trim());
                }
                catch (MySqlException sqlEx)
                {
                    try { transaccion.Rollback(); } catch { }
                    MessageBox.Show("Error al procesar devolución (Transacción revertida):\n" + sqlEx.Message, "Error SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    try { transaccion.Rollback(); } catch { }
                    MessageBox.Show("Error inesperado (Transacción revertida): " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}