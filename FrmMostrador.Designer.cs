namespace Biblioteca
{
	partial class FrmMostrador
	{
		private System.ComponentModel.IContainer components = null;
		
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		private void InitializeComponent()
		{
			this.tabControlMostrador = new System.Windows.Forms.TabControl();
			this.tabPrestamos = new System.Windows.Forms.TabPage();
			this.btnConfirmarPrestamo = new System.Windows.Forms.Button();
			this.btnQuitarLibro = new System.Windows.Forms.Button();
			this.dgvCarritoLibros = new System.Windows.Forms.DataGridView();
			this.colISBN = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colCodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colTitulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.lblInfoLibro = new System.Windows.Forms.Label();
			this.btnBuscarManual = new System.Windows.Forms.Button();
			this.txtCodigoBarras = new System.Windows.Forms.TextBox();
			this.lblEscaner = new System.Windows.Forms.Label();
			this.dtpFechaDevolucion = new System.Windows.Forms.DateTimePicker();
			this.lblFechaDev = new System.Windows.Forms.Label();
			this.cmbLector = new System.Windows.Forms.ComboBox();
			this.lblLector = new System.Windows.Forms.Label();
			this.lblTituloPrestamo = new System.Windows.Forms.Label();
			this.tabDevoluciones = new System.Windows.Forms.TabPage();
			this.btnRegistrarDevolucion = new System.Windows.Forms.Button();
			this.dgvPrestamosActivos = new System.Windows.Forms.DataGridView();
			this.txtBuscarDevolucion = new System.Windows.Forms.TextBox();
			this.lblBuscarDev = new System.Windows.Forms.Label();
			this.lblTituloDev = new System.Windows.Forms.Label();
			this.tabControlMostrador.SuspendLayout();
			this.tabPrestamos.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvCarritoLibros)).BeginInit();
			this.tabDevoluciones.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvPrestamosActivos)).BeginInit();
			this.SuspendLayout();
			// 
			// tabControlMostrador
			// 
			this.tabControlMostrador.Controls.Add(this.tabPrestamos);
			this.tabControlMostrador.Controls.Add(this.tabDevoluciones);
			this.tabControlMostrador.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControlMostrador.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tabControlMostrador.Location = new System.Drawing.Point(0, 0);
			this.tabControlMostrador.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.tabControlMostrador.Name = "tabControlMostrador";
			this.tabControlMostrador.SelectedIndex = 0;
			this.tabControlMostrador.Size = new System.Drawing.Size(1112, 641);
			this.tabControlMostrador.TabIndex = 0;
			// 
			// tabPrestamos
			// 
			this.tabPrestamos.BackColor = System.Drawing.Color.WhiteSmoke;
			this.tabPrestamos.Controls.Add(this.btnConfirmarPrestamo);
			this.tabPrestamos.Controls.Add(this.btnQuitarLibro);
			this.tabPrestamos.Controls.Add(this.dgvCarritoLibros);
			this.tabPrestamos.Controls.Add(this.lblInfoLibro);
			this.tabPrestamos.Controls.Add(this.btnBuscarManual);
			this.tabPrestamos.Controls.Add(this.txtCodigoBarras);
			this.tabPrestamos.Controls.Add(this.lblEscaner);
			this.tabPrestamos.Controls.Add(this.dtpFechaDevolucion);
			this.tabPrestamos.Controls.Add(this.lblFechaDev);
			this.tabPrestamos.Controls.Add(this.cmbLector);
			this.tabPrestamos.Controls.Add(this.lblLector);
			this.tabPrestamos.Controls.Add(this.lblTituloPrestamo);
			this.tabPrestamos.Location = new System.Drawing.Point(4, 30);
			this.tabPrestamos.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.tabPrestamos.Name = "tabPrestamos";
			this.tabPrestamos.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.tabPrestamos.Size = new System.Drawing.Size(1104, 607);
			this.tabPrestamos.TabIndex = 0;
			this.tabPrestamos.Text = "Nuevo Préstamo";
			// 
			// btnConfirmarPrestamo
			// 
			this.btnConfirmarPrestamo.BackColor = System.Drawing.Color.SeaGreen;
			this.btnConfirmarPrestamo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnConfirmarPrestamo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnConfirmarPrestamo.ForeColor = System.Drawing.Color.White;
			this.btnConfirmarPrestamo.Location = new System.Drawing.Point(800, 535);
			this.btnConfirmarPrestamo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.btnConfirmarPrestamo.Name = "btnConfirmarPrestamo";
			this.btnConfirmarPrestamo.Size = new System.Drawing.Size(267, 43);
			this.btnConfirmarPrestamo.TabIndex = 11;
			this.btnConfirmarPrestamo.Text = "Confirmar Préstamo";
			this.btnConfirmarPrestamo.UseVisualStyleBackColor = false;
			this.btnConfirmarPrestamo.Click += new System.EventHandler(this.btnConfirmarPrestamo_Click);
			// 
			// btnQuitarLibro
			// 
			this.btnQuitarLibro.BackColor = System.Drawing.Color.IndianRed;
			this.btnQuitarLibro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnQuitarLibro.ForeColor = System.Drawing.Color.White;
			this.btnQuitarLibro.Location = new System.Drawing.Point(27, 535);
			this.btnQuitarLibro.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.btnQuitarLibro.Name = "btnQuitarLibro";
			this.btnQuitarLibro.Size = new System.Drawing.Size(213, 43);
			this.btnQuitarLibro.TabIndex = 10;
			this.btnQuitarLibro.Text = "Quitar Seleccionado";
			this.btnQuitarLibro.UseVisualStyleBackColor = false;
			this.btnQuitarLibro.Click += new System.EventHandler(this.btnQuitarLibro_Click);
			// 
			// dgvCarritoLibros
			// 
			this.dgvCarritoLibros.AllowUserToAddRows = false;
			this.dgvCarritoLibros.AllowUserToDeleteRows = false;
			this.dgvCarritoLibros.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dgvCarritoLibros.BackgroundColor = System.Drawing.Color.White;
			this.dgvCarritoLibros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvCarritoLibros.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
									this.colISBN,
									this.colCodigo,
									this.colTitulo,
									this.colCantidad});
			this.dgvCarritoLibros.Location = new System.Drawing.Point(27, 252);
			this.dgvCarritoLibros.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.dgvCarritoLibros.MultiSelect = false;
			this.dgvCarritoLibros.Name = "dgvCarritoLibros";
			this.dgvCarritoLibros.ReadOnly = true;
			this.dgvCarritoLibros.RowHeadersVisible = false;
			this.dgvCarritoLibros.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvCarritoLibros.Size = new System.Drawing.Size(1040, 265);
			this.dgvCarritoLibros.TabIndex = 9;
			// 
			// colISBN
			// 
			this.colISBN.FillWeight = 80F;
			this.colISBN.HeaderText = "ISBN";
			this.colISBN.Name = "colISBN";
			this.colISBN.ReadOnly = true;
			// 
			// colCodigo
			// 
			this.colCodigo.FillWeight = 80F;
			this.colCodigo.HeaderText = "Código de Barras";
			this.colCodigo.Name = "colCodigo";
			this.colCodigo.ReadOnly = true;
			// 
			// colTitulo
			// 
			this.colTitulo.FillWeight = 160F;
			this.colTitulo.HeaderText = "Título del Libro";
			this.colTitulo.Name = "colTitulo";
			this.colTitulo.ReadOnly = true;
			// 
			// colCantidad
			// 
			this.colCantidad.FillWeight = 50F;
			this.colCantidad.HeaderText = "Cantidad";
			this.colCantidad.Name = "colCantidad";
			this.colCantidad.ReadOnly = true;
			// 
			// lblInfoLibro
			// 
			this.lblInfoLibro.AutoSize = true;
			this.lblInfoLibro.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblInfoLibro.ForeColor = System.Drawing.Color.DimGray;
			this.lblInfoLibro.Location = new System.Drawing.Point(27, 219);
			this.lblInfoLibro.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblInfoLibro.Name = "lblInfoLibro";
			this.lblInfoLibro.Size = new System.Drawing.Size(163, 23);
			this.lblInfoLibro.TabIndex = 8;
			this.lblInfoLibro.Text = "Listo para escanear...";
			// 
			// btnBuscarManual
			// 
			this.btnBuscarManual.BackColor = System.Drawing.Color.SteelBlue;
			this.btnBuscarManual.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnBuscarManual.ForeColor = System.Drawing.Color.White;
			this.btnBuscarManual.Location = new System.Drawing.Point(647, 172);
			this.btnBuscarManual.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.btnBuscarManual.Name = "btnBuscarManual";
			this.btnBuscarManual.Size = new System.Drawing.Size(187, 37);
			this.btnBuscarManual.TabIndex = 7;
			this.btnBuscarManual.Text = "Buscar / Agregar";
			this.btnBuscarManual.UseVisualStyleBackColor = false;
			this.btnBuscarManual.Click += new System.EventHandler(this.btnBuscarManual_Click);
			// 
			// txtCodigoBarras
			// 
			this.txtCodigoBarras.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtCodigoBarras.Location = new System.Drawing.Point(27, 175);
			this.txtCodigoBarras.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.txtCodigoBarras.Name = "txtCodigoBarras";
			this.txtCodigoBarras.Size = new System.Drawing.Size(599, 31);
			this.txtCodigoBarras.TabIndex = 0;
			this.txtCodigoBarras.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodigoBarras_KeyDown);
			this.txtCodigoBarras.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigoBarras_KeyPress);
			// 
			// lblEscaner
			// 
			this.lblEscaner.AutoSize = true;
			this.lblEscaner.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblEscaner.Location = new System.Drawing.Point(27, 148);
			this.lblEscaner.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblEscaner.Name = "lblEscaner";
			this.lblEscaner.Size = new System.Drawing.Size(356, 23);
			this.lblEscaner.TabIndex = 5;
			this.lblEscaner.Text = "Escanear Código de Barras (o teclear ISBN):";
			// 
			// dtpFechaDevolucion
			// 
			this.dtpFechaDevolucion.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtpFechaDevolucion.Location = new System.Drawing.Point(667, 96);
			this.dtpFechaDevolucion.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.dtpFechaDevolucion.Name = "dtpFechaDevolucion";
			this.dtpFechaDevolucion.Size = new System.Drawing.Size(239, 29);
			this.dtpFechaDevolucion.TabIndex = 4;
			// 
			// lblFechaDev
			// 
			this.lblFechaDev.AutoSize = true;
			this.lblFechaDev.Location = new System.Drawing.Point(667, 71);
			this.lblFechaDev.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblFechaDev.Name = "lblFechaDev";
			this.lblFechaDev.Size = new System.Drawing.Size(217, 23);
			this.lblFechaDev.TabIndex = 3;
			this.lblFechaDev.Text = "Fecha límite de devolución:";
			// 
			// cmbLector
			// 
			this.cmbLector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbLector.FormattingEnabled = true;
			this.cmbLector.Location = new System.Drawing.Point(27, 96);
			this.cmbLector.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.cmbLector.Name = "cmbLector";
			this.cmbLector.Size = new System.Drawing.Size(599, 29);
			this.cmbLector.TabIndex = 2;
			// 
			// lblLector
			// 
			this.lblLector.AutoSize = true;
			this.lblLector.Location = new System.Drawing.Point(27, 71);
			this.lblLector.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblLector.Name = "lblLector";
			this.lblLector.Size = new System.Drawing.Size(138, 23);
			this.lblLector.TabIndex = 1;
			this.lblLector.Text = "Lector / Alumno:";
			// 
			// lblTituloPrestamo
			// 
			this.lblTituloPrestamo.AutoSize = true;
			this.lblTituloPrestamo.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTituloPrestamo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
			this.lblTituloPrestamo.Location = new System.Drawing.Point(27, 18);
			this.lblTituloPrestamo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblTituloPrestamo.Name = "lblTituloPrestamo";
			this.lblTituloPrestamo.Size = new System.Drawing.Size(405, 32);
			this.lblTituloPrestamo.TabIndex = 6;
			this.lblTituloPrestamo.Text = "Mostrador - Registro de Préstamo";
			// 
			// tabDevoluciones
			// 
			this.tabDevoluciones.BackColor = System.Drawing.Color.WhiteSmoke;
			this.tabDevoluciones.Controls.Add(this.btnRegistrarDevolucion);
			this.tabDevoluciones.Controls.Add(this.dgvPrestamosActivos);
			this.tabDevoluciones.Controls.Add(this.txtBuscarDevolucion);
			this.tabDevoluciones.Controls.Add(this.lblBuscarDev);
			this.tabDevoluciones.Controls.Add(this.lblTituloDev);
			this.tabDevoluciones.Location = new System.Drawing.Point(4, 30);
			this.tabDevoluciones.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.tabDevoluciones.Name = "tabDevoluciones";
			this.tabDevoluciones.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.tabDevoluciones.Size = new System.Drawing.Size(1104, 607);
			this.tabDevoluciones.TabIndex = 1;
			this.tabDevoluciones.Text = "Control de Devoluciones";
			// 
			// btnRegistrarDevolucion
			// 
			this.btnRegistrarDevolucion.BackColor = System.Drawing.Color.RoyalBlue;
			this.btnRegistrarDevolucion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnRegistrarDevolucion.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnRegistrarDevolucion.ForeColor = System.Drawing.Color.White;
			this.btnRegistrarDevolucion.Location = new System.Drawing.Point(773, 535);
			this.btnRegistrarDevolucion.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.btnRegistrarDevolucion.Name = "btnRegistrarDevolucion";
			this.btnRegistrarDevolucion.Size = new System.Drawing.Size(293, 43);
			this.btnRegistrarDevolucion.TabIndex = 4;
			this.btnRegistrarDevolucion.Text = "Registrar Devolución";
			this.btnRegistrarDevolucion.UseVisualStyleBackColor = false;
			this.btnRegistrarDevolucion.Click += new System.EventHandler(this.btnRegistrarDevolucion_Click);
			// 
			// dgvPrestamosActivos
			// 
			this.dgvPrestamosActivos.AllowUserToAddRows = false;
			this.dgvPrestamosActivos.AllowUserToDeleteRows = false;
			this.dgvPrestamosActivos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dgvPrestamosActivos.BackgroundColor = System.Drawing.Color.White;
			this.dgvPrestamosActivos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvPrestamosActivos.Location = new System.Drawing.Point(27, 148);
			this.dgvPrestamosActivos.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.dgvPrestamosActivos.MultiSelect = false;
			this.dgvPrestamosActivos.Name = "dgvPrestamosActivos";
			this.dgvPrestamosActivos.ReadOnly = true;
			this.dgvPrestamosActivos.RowHeadersVisible = false;
			this.dgvPrestamosActivos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvPrestamosActivos.Size = new System.Drawing.Size(1040, 369);
			this.dgvPrestamosActivos.TabIndex = 3;
			// 
			// txtBuscarDevolucion
			// 
			this.txtBuscarDevolucion.Location = new System.Drawing.Point(27, 98);
			this.txtBuscarDevolucion.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.txtBuscarDevolucion.Name = "txtBuscarDevolucion";
			this.txtBuscarDevolucion.Size = new System.Drawing.Size(665, 29);
			this.txtBuscarDevolucion.TabIndex = 2;
			this.txtBuscarDevolucion.TextChanged += new System.EventHandler(this.txtBuscarDevolucion_TextChanged);
			// 
			// lblBuscarDev
			// 
			this.lblBuscarDev.AutoSize = true;
			this.lblBuscarDev.Location = new System.Drawing.Point(27, 71);
			this.lblBuscarDev.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblBuscarDev.Name = "lblBuscarDev";
			this.lblBuscarDev.Size = new System.Drawing.Size(582, 23);
			this.lblBuscarDev.TabIndex = 1;
			this.lblBuscarDev.Text = "Buscar préstamo activo (por Folio, Credencial, Alumno o Código de Barras):";
			// 
			// lblTituloDev
			// 
			this.lblTituloDev.AutoSize = true;
			this.lblTituloDev.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTituloDev.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
			this.lblTituloDev.Location = new System.Drawing.Point(27, 18);
			this.lblTituloDev.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblTituloDev.Name = "lblTituloDev";
			this.lblTituloDev.Size = new System.Drawing.Size(442, 32);
			this.lblTituloDev.TabIndex = 0;
			this.lblTituloDev.Text = "Mostrador - Control de Devoluciones";
			// 
			// FrmMostrador
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1112, 641);
			this.Controls.Add(this.tabControlMostrador);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.MaximizeBox = false;
			this.Name = "FrmMostrador";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Sistema de Biblioteca - Mostrador";
			this.Load += new System.EventHandler(this.FrmMostrador_Load);
			this.Shown += new System.EventHandler(this.FrmMostrador_Shown);
			this.tabControlMostrador.ResumeLayout(false);
			this.tabPrestamos.ResumeLayout(false);
			this.tabPrestamos.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvCarritoLibros)).EndInit();
			this.tabDevoluciones.ResumeLayout(false);
			this.tabDevoluciones.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvPrestamosActivos)).EndInit();
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.Button btnRegistrarDevolucion;
		private System.Windows.Forms.DataGridView dgvPrestamosActivos;
		private System.Windows.Forms.TextBox txtBuscarDevolucion;
		private System.Windows.Forms.Label lblBuscarDev;
		private System.Windows.Forms.Label lblTituloDev;
		private System.Windows.Forms.TabPage tabDevoluciones;
		private System.Windows.Forms.Button btnConfirmarPrestamo;
		private System.Windows.Forms.Button btnQuitarLibro;
		private System.Windows.Forms.DataGridViewTextBoxColumn colCantidad;
		private System.Windows.Forms.DataGridViewTextBoxColumn colTitulo;
		private System.Windows.Forms.DataGridViewTextBoxColumn colCodigo;
		private System.Windows.Forms.DataGridViewTextBoxColumn colISBN;
		private System.Windows.Forms.DataGridView dgvCarritoLibros;
		private System.Windows.Forms.Label lblInfoLibro;
		private System.Windows.Forms.Button btnBuscarManual;
		private System.Windows.Forms.TextBox txtCodigoBarras;
		private System.Windows.Forms.Label lblEscaner;
		private System.Windows.Forms.DateTimePicker dtpFechaDevolucion;
		private System.Windows.Forms.Label lblFechaDev;
		private System.Windows.Forms.ComboBox cmbLector;
		private System.Windows.Forms.Label lblLector;
		private System.Windows.Forms.Label lblTituloPrestamo;
		private System.Windows.Forms.TabPage tabPrestamos;
		private System.Windows.Forms.TabControl tabControlMostrador;
	}
}