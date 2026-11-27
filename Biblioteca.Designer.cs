/*
 * Created by SharpDevelop.
 * User: dulma
 * Date: 19/11/2026
 * Time: 10:40 a. m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace Biblioteca
{
	partial class VentanaPrincipal
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.btnPrestamos = new System.Windows.Forms.Button();
			this.btnStock = new System.Windows.Forms.Button();
			this.btnReporte = new System.Windows.Forms.Button();
			this.btnCerrarSesion = new System.Windows.Forms.Button();
			this.btnUsuarios = new System.Windows.Forms.Button();
			this.txtBuscar = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.SuspendLayout();
			// 
			// dataGridView1
			// 
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Location = new System.Drawing.Point(12, 42);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.RowTemplate.Height = 24;
			this.dataGridView1.Size = new System.Drawing.Size(715, 451);
			this.dataGridView1.TabIndex = 0;
			// 
			// btnPrestamos
			// 
			this.btnPrestamos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
			this.btnPrestamos.Location = new System.Drawing.Point(799, 42);
			this.btnPrestamos.Name = "btnPrestamos";
			this.btnPrestamos.Size = new System.Drawing.Size(157, 38);
			this.btnPrestamos.TabIndex = 1;
			this.btnPrestamos.Text = "Prestamos";
			this.btnPrestamos.UseVisualStyleBackColor = false;
			this.btnPrestamos.Click += new System.EventHandler(this.BtnPrestamosClick);
			// btnStock
			// 
			this.btnStock.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
			this.btnStock.Location = new System.Drawing.Point(799, 127);
			this.btnStock.Name = "btnStock";
			this.btnStock.Size = new System.Drawing.Size(157, 38);
			this.btnStock.TabIndex = 2;
			this.btnStock.Text = "Stock";
			this.btnStock.UseVisualStyleBackColor = false;
			this.btnStock.Click += new System.EventHandler(this.BtnStockClick);
			// 
			// btnReporte
			// 
			this.btnReporte.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
			this.btnReporte.Location = new System.Drawing.Point(799, 217);
			this.btnReporte.Name = "btnReporte";
			this.btnReporte.Size = new System.Drawing.Size(157, 38);
			this.btnReporte.TabIndex = 3;
			this.btnReporte.Text = "Reportes";
			this.btnReporte.UseVisualStyleBackColor = false;
			this.btnReporte.Click += new System.EventHandler(this.BtnReporteClick);
			// 
			// btnCerrarSesion
			// 
			this.btnCerrarSesion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
			this.btnCerrarSesion.Location = new System.Drawing.Point(799, 444);
			this.btnCerrarSesion.Name = "btnCerrarSesion";
			this.btnCerrarSesion.Size = new System.Drawing.Size(157, 38);
			this.btnCerrarSesion.TabIndex = 4;
			this.btnCerrarSesion.Text = "Cerrar sesión";
			this.btnCerrarSesion.UseVisualStyleBackColor = false;
			this.btnCerrarSesion.Click += new System.EventHandler(this.BtnCerrarSesionClick);
			// 
			// btnUsuarios
			// 
			this.btnUsuarios.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
			this.btnUsuarios.Location = new System.Drawing.Point(799, 302);
			this.btnUsuarios.Name = "btnUsuarios";
			this.btnUsuarios.Size = new System.Drawing.Size(157, 38);
			this.btnUsuarios.TabIndex = 5;
			this.btnUsuarios.Text = "Usuarios";
			this.btnUsuarios.UseVisualStyleBackColor = false;
			this.btnUsuarios.Click += new System.EventHandler(this.BtnUsuariosClick);
			// 
			// txtBuscar
			// 
			this.txtBuscar.Location = new System.Drawing.Point(12, 18);
			this.txtBuscar.Name = "txtBuscar";
			this.txtBuscar.Size = new System.Drawing.Size(715, 22);
			this.txtBuscar.TabIndex = 6;
			// 
			// VentanaPrincipal
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
			this.ClientSize = new System.Drawing.Size(1029, 505);
			this.Controls.Add(this.txtBuscar);
			this.Controls.Add(this.btnUsuarios);
			this.Controls.Add(this.btnCerrarSesion);
			this.Controls.Add(this.btnReporte);
			this.Controls.Add(this.btnStock);
			this.Controls.Add(this.btnPrestamos);
			this.Controls.Add(this.dataGridView1);
			this.Name = "VentanaPrincipal";
			this.Text = "VentanaPrincipal";
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.TextBox txtBuscar;
		private System.Windows.Forms.Button btnUsuarios;
		private System.Windows.Forms.Button btnCerrarSesion;
		private System.Windows.Forms.Button btnReporte;
		private System.Windows.Forms.Button btnStock;
		private System.Windows.Forms.Button btnPrestamos;
		private System.Windows.Forms.DataGridView dataGridView1;
	}
}
