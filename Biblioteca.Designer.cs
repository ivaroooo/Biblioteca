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
	partial class Administrador
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
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.SuspendLayout();
			// 
			// dataGridView1
			// 
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Location = new System.Drawing.Point(12, 12);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.RowTemplate.Height = 24;
			this.dataGridView1.Size = new System.Drawing.Size(693, 417);
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
			// 
			// btnStock
			// 
			this.btnStock.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
			this.btnStock.Location = new System.Drawing.Point(799, 127);
			this.btnStock.Name = "btnStock";
			this.btnStock.Size = new System.Drawing.Size(157, 38);
			this.btnStock.TabIndex = 2;
			this.btnStock.Text = "Stock";
			this.btnStock.UseVisualStyleBackColor = false;
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
			// 
			// Administrador
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
			this.ClientSize = new System.Drawing.Size(1029, 505);
			this.Controls.Add(this.btnReporte);
			this.Controls.Add(this.btnStock);
			this.Controls.Add(this.btnPrestamos);
			this.Controls.Add(this.dataGridView1);
			this.Name = "Administrador";
			this.Text = "Administrador";
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.Button btnReporte;
		private System.Windows.Forms.Button btnStock;
		private System.Windows.Forms.Button btnPrestamos;
		private System.Windows.Forms.DataGridView dataGridView1;
	}
}
