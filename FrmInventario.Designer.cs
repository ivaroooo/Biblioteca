namespace Biblioteca
{
	partial class FrmInventario
	{
		private System.ComponentModel.IContainer components = null;

		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			this.gbFormulario = new System.Windows.Forms.GroupBox();
			this.lblIsbn = new System.Windows.Forms.Label();
			this.txtIsbn = new System.Windows.Forms.TextBox();
			this.lblCodigo = new System.Windows.Forms.Label();
			this.txtCodigoBarras = new System.Windows.Forms.TextBox();
			this.lblNombre = new System.Windows.Forms.Label();
			this.txtNombre = new System.Windows.Forms.TextBox();
			this.lblAutor = new System.Windows.Forms.Label();
			this.txtAutor = new System.Windows.Forms.TextBox();
			this.lblCategoria = new System.Windows.Forms.Label();
			this.txtCategoria = new System.Windows.Forms.TextBox();
			this.lblStock = new System.Windows.Forms.Label();
			this.numStock = new System.Windows.Forms.NumericUpDown();
			this.btnAgregar = new System.Windows.Forms.Button();
			this.btnActualizarStock = new System.Windows.Forms.Button();
			this.btnEliminar = new System.Windows.Forms.Button();
			this.btnLimpiar = new System.Windows.Forms.Button();
			this.txtBuscar = new System.Windows.Forms.TextBox();
			this.lblBuscar = new System.Windows.Forms.Label();
			this.dgvLibros = new System.Windows.Forms.DataGridView();
			this.gbFormulario.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numStock)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvLibros)).BeginInit();
			this.SuspendLayout();
			// 
			// gbFormulario
			// 
			this.gbFormulario.Controls.Add(this.btnLimpiar);
			this.gbFormulario.Controls.Add(this.btnEliminar);
			this.gbFormulario.Controls.Add(this.btnActualizarStock);
			this.gbFormulario.Controls.Add(this.btnAgregar);
			this.gbFormulario.Controls.Add(this.numStock);
			this.gbFormulario.Controls.Add(this.lblStock);
			this.gbFormulario.Controls.Add(this.txtCategoria);
			this.gbFormulario.Controls.Add(this.lblCategoria);
			this.gbFormulario.Controls.Add(this.txtAutor);
			this.gbFormulario.Controls.Add(this.lblAutor);
			this.gbFormulario.Controls.Add(this.txtNombre);
			this.gbFormulario.Controls.Add(this.lblNombre);
			this.gbFormulario.Controls.Add(this.txtCodigoBarras);
			this.gbFormulario.Controls.Add(this.lblCodigo);
			this.gbFormulario.Controls.Add(this.txtIsbn);
			this.gbFormulario.Controls.Add(this.lblIsbn);
			this.gbFormulario.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
			this.gbFormulario.Location = new System.Drawing.Point(12, 12);
			this.gbFormulario.Name = "gbFormulario";
			this.gbFormulario.Size = new System.Drawing.Size(320, 460);
			this.gbFormulario.TabIndex = 0;
			this.gbFormulario.TabStop = false;
			this.gbFormulario.Text = "Gestión de Libros y Stock";
			// 
			// lblIsbn
			// 
			this.lblIsbn.AutoSize = true;
			this.lblIsbn.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.lblIsbn.Location = new System.Drawing.Point(15, 28);
			this.lblIsbn.Name = "lblIsbn";
			this.lblIsbn.Size = new System.Drawing.Size(36, 15);
			this.lblIsbn.TabIndex = 0;
			this.lblIsbn.Text = "ISBN:";
			// 
			// txtIsbn
			// 
			this.txtIsbn.Font = new System.Drawing.Font("Segoe UI", 9.75F);
			this.txtIsbn.Location = new System.Drawing.Point(15, 46);
			this.txtIsbn.Name = "txtIsbn";
			this.txtIsbn.Size = new System.Drawing.Size(285, 25);
			this.txtIsbn.TabIndex = 1;
			// 
			// lblCodigo
			// 
			this.lblCodigo.AutoSize = true;
			this.lblCodigo.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.lblCodigo.Location = new System.Drawing.Point(15, 78);
			this.lblCodigo.Name = "lblCodigo";
			this.lblCodigo.Size = new System.Drawing.Size(156, 15);
			this.lblCodigo.TabIndex = 2;
			this.lblCodigo.Text = "Código de Barras (Escáner):";
			// 
			// txtCodigoBarras
			// 
			this.txtCodigoBarras.Font = new System.Drawing.Font("Segoe UI", 9.75F);
			this.txtCodigoBarras.Location = new System.Drawing.Point(15, 96);
			this.txtCodigoBarras.Name = "txtCodigoBarras";
			this.txtCodigoBarras.Size = new System.Drawing.Size(285, 25);
			this.txtCodigoBarras.TabIndex = 3;
			// 
			// lblNombre
			// 
			this.lblNombre.AutoSize = true;
			this.lblNombre.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.lblNombre.Location = new System.Drawing.Point(15, 128);
			this.lblNombre.Name = "lblNombre";
			this.lblNombre.Size = new System.Drawing.Size(93, 15);
			this.lblNombre.TabIndex = 4;
			this.lblNombre.Text = "Título del Libro:";
			// 
			// txtNombre
			// 
			this.txtNombre.Font = new System.Drawing.Font("Segoe UI", 9.75F);
			this.txtNombre.Location = new System.Drawing.Point(15, 146);
			this.txtNombre.Name = "txtNombre";
			this.txtNombre.Size = new System.Drawing.Size(285, 25);
			this.txtNombre.TabIndex = 5;
			// 
			// lblAutor
			// 
			this.lblAutor.AutoSize = true;
			this.lblAutor.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.lblAutor.Location = new System.Drawing.Point(15, 178);
			this.lblAutor.Name = "lblAutor";
			this.lblAutor.Size = new System.Drawing.Size(40, 15);
			this.lblAutor.TabIndex = 6;
			this.lblAutor.Text = "Autor:";
			// 
			// txtAutor
			// 
			this.txtAutor.Font = new System.Drawing.Font("Segoe UI", 9.75F);
			this.txtAutor.Location = new System.Drawing.Point(15, 196);
			this.txtAutor.Name = "txtAutor";
			this.txtAutor.Size = new System.Drawing.Size(285, 25);
			this.txtAutor.TabIndex = 7;
			// 
			// lblCategoria
			// 
			this.lblCategoria.AutoSize = true;
			this.lblCategoria.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.lblCategoria.Location = new System.Drawing.Point(15, 228);
			this.lblCategoria.Name = "lblCategoria";
			this.lblCategoria.Size = new System.Drawing.Size(61, 15);
			this.lblCategoria.TabIndex = 8;
			this.lblCategoria.Text = "Categoría:";
			// 
			// txtCategoria
			// 
			this.txtCategoria.Font = new System.Drawing.Font("Segoe UI", 9.75F);
			this.txtCategoria.Location = new System.Drawing.Point(15, 246);
			this.txtCategoria.Name = "txtCategoria";
			this.txtCategoria.Size = new System.Drawing.Size(285, 25);
			this.txtCategoria.TabIndex = 9;
			// 
			// lblStock
			// 
			this.lblStock.AutoSize = true;
			this.lblStock.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
			this.lblStock.Location = new System.Drawing.Point(15, 282);
			this.lblStock.Name = "lblStock";
			this.lblStock.Size = new System.Drawing.Size(156, 15);
			this.lblStock.TabIndex = 10;
			this.lblStock.Text = "Stock / Copias Disponibles:";
			// 
			// numStock
			// 
			this.numStock.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
			this.numStock.Location = new System.Drawing.Point(180, 278);
			this.numStock.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
			this.numStock.Name = "numStock";
			this.numStock.Size = new System.Drawing.Size(120, 26);
			this.numStock.TabIndex = 11;
			this.numStock.Value = new decimal(new int[] { 1, 0, 0, 0 });
			// 
			// btnAgregar
			// 
			this.btnAgregar.BackColor = System.Drawing.Color.SeaGreen;
			this.btnAgregar.ForeColor = System.Drawing.Color.White;
			this.btnAgregar.Location = new System.Drawing.Point(15, 320);
			this.btnAgregar.Name = "btnAgregar";
			this.btnAgregar.Size = new System.Drawing.Size(138, 38);
			this.btnAgregar.TabIndex = 12;
			this.btnAgregar.Text = "Insertar Libro";
			this.btnAgregar.UseVisualStyleBackColor = false;
			this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
			// 
			// btnActualizarStock
			// 
			this.btnActualizarStock.BackColor = System.Drawing.Color.SteelBlue;
			this.btnActualizarStock.ForeColor = System.Drawing.Color.White;
			this.btnActualizarStock.Location = new System.Drawing.Point(162, 320);
			this.btnActualizarStock.Name = "btnActualizarStock";
			this.btnActualizarStock.Size = new System.Drawing.Size(138, 38);
			this.btnActualizarStock.TabIndex = 13;
			this.btnActualizarStock.Text = "Actualizar Stock";
			this.btnActualizarStock.UseVisualStyleBackColor = false;
			this.btnActualizarStock.Click += new System.EventHandler(this.btnActualizarStock_Click);
			// 
			// btnEliminar
			// 
			this.btnEliminar.BackColor = System.Drawing.Color.Firebrick;
			this.btnEliminar.ForeColor = System.Drawing.Color.White;
			this.btnEliminar.Location = new System.Drawing.Point(15, 368);
			this.btnEliminar.Name = "btnEliminar";
			this.btnEliminar.Size = new System.Drawing.Size(138, 38);
			this.btnEliminar.TabIndex = 14;
			this.btnEliminar.Text = "Eliminar Libro";
			this.btnEliminar.UseVisualStyleBackColor = false;
			this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
			// 
			// btnLimpiar
			// 
			this.btnLimpiar.BackColor = System.Drawing.Color.DimGray;
			this.btnLimpiar.ForeColor = System.Drawing.Color.White;
			this.btnLimpiar.Location = new System.Drawing.Point(162, 368);
			this.btnLimpiar.Name = "btnLimpiar";
			this.btnLimpiar.Size = new System.Drawing.Size(138, 38);
			this.btnLimpiar.TabIndex = 15;
			this.btnLimpiar.Text = "Limpiar Campos";
			this.btnLimpiar.UseVisualStyleBackColor = false;
			this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
			// 
			// lblBuscar
			// 
			this.lblBuscar.AutoSize = true;
			this.lblBuscar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
			this.lblBuscar.Location = new System.Drawing.Point(345, 22);
			this.lblBuscar.Name = "lblBuscar";
			this.lblBuscar.Size = new System.Drawing.Size(212, 17);
			this.lblBuscar.TabIndex = 1;
			this.lblBuscar.Text = "Buscar (Título, ISBN o Código):";
			// 
			// txtBuscar
			// 
			this.txtBuscar.Font = new System.Drawing.Font("Segoe UI", 10F);
			this.txtBuscar.Location = new System.Drawing.Point(565, 19);
			this.txtBuscar.Name = "txtBuscar";
			this.txtBuscar.Size = new System.Drawing.Size(340, 25);
			this.txtBuscar.TabIndex = 2;
			this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
			// 
			// dgvLibros
			// 
			this.dgvLibros.AllowUserToAddRows = false;
			this.dgvLibros.AllowUserToDeleteRows = false;
			this.dgvLibros.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dgvLibros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvLibros.Location = new System.Drawing.Point(348, 55);
			this.dgvLibros.MultiSelect = false;
			this.dgvLibros.Name = "dgvLibros";
			this.dgvLibros.ReadOnly = true;
			this.dgvLibros.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvLibros.Size = new System.Drawing.Size(557, 417);
			this.dgvLibros.TabIndex = 3;
			this.dgvLibros.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLibros_CellClick);
			// 
			// FrmInventario
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(920, 488);
			this.Controls.Add(this.dgvLibros);
			this.Controls.Add(this.txtBuscar);
			this.Controls.Add(this.lblBuscar);
			this.Controls.Add(this.gbFormulario);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.Name = "FrmInventario";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Control de Inventario y Catálogo";
			this.Load += new System.EventHandler(this.FrmInventario_Load);
			this.gbFormulario.ResumeLayout(false);
			this.gbFormulario.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numStock)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvLibros)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();
		}

		private System.Windows.Forms.GroupBox gbFormulario;
		private System.Windows.Forms.Label lblIsbn;
		private System.Windows.Forms.TextBox txtIsbn;
		private System.Windows.Forms.Label lblCodigo;
		private System.Windows.Forms.TextBox txtCodigoBarras;
		private System.Windows.Forms.Label lblNombre;
		private System.Windows.Forms.TextBox txtNombre;
		private System.Windows.Forms.Label lblAutor;
		private System.Windows.Forms.TextBox txtAutor;
		private System.Windows.Forms.Label lblCategoria;
		private System.Windows.Forms.TextBox txtCategoria;
		private System.Windows.Forms.Label lblStock;
		private System.Windows.Forms.NumericUpDown numStock;
		private System.Windows.Forms.Button btnAgregar;
		private System.Windows.Forms.Button btnActualizarStock;
		private System.Windows.Forms.Button btnEliminar;
		private System.Windows.Forms.Button btnLimpiar;
		private System.Windows.Forms.Label lblBuscar;
		private System.Windows.Forms.TextBox txtBuscar;
		private System.Windows.Forms.DataGridView dgvLibros;
	}
}