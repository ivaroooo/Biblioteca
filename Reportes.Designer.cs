/*
 * Created by SharpDevelop.
 * User: Miguel Rico
 * Date: 26/11/2026
 * Time: 10:36 p. m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace Biblioteca
{
	partial class Reportes
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
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.dgvReportes = new System.Windows.Forms.DataGridView();
			this.lblTotal = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.dgvReportes)).BeginInit();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
			this.button1.Location = new System.Drawing.Point(275, 12);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(188, 33);
			this.button1.TabIndex = 0;
			this.button1.Text = "Libros Más Prestados";
			this.button1.UseVisualStyleBackColor = false;
			this.button1.Click += new System.EventHandler(this.BtnMasPrestadosClick);
			// 
			// button2
			// 
			this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
			this.button2.Location = new System.Drawing.Point(537, 12);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(200, 33);
			this.button2.TabIndex = 1;
			this.button2.Text = "Préstamos con Retraso";
			this.button2.UseVisualStyleBackColor = false;
			this.button2.Click += new System.EventHandler(this.BtnPrestamosVencidosClick);
			// 
			// button3
			// 
			this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
			this.button3.Location = new System.Drawing.Point(459, 445);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(90, 31);
			this.button3.TabIndex = 2;
			this.button3.Text = "Volver";
			this.button3.UseVisualStyleBackColor = false;
			this.button3.Click += new System.EventHandler(this.BtnCerrarClick);
			// 
			// dgvReportes
			// 
			this.dgvReportes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvReportes.Location = new System.Drawing.Point(31, 47);
			this.dgvReportes.Name = "dgvReportes";
			this.dgvReportes.RowTemplate.Height = 24;
			this.dgvReportes.Size = new System.Drawing.Size(940, 392);
			this.dgvReportes.TabIndex = 3;
			// 
			// lblTotal
			// 
			this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTotal.Location = new System.Drawing.Point(31, 20);
			this.lblTotal.Name = "lblTotal";
			this.lblTotal.Size = new System.Drawing.Size(183, 23);
			this.lblTotal.TabIndex = 4;
			this.lblTotal.Text = "label1";
			// 
			// Reportes
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
			this.ClientSize = new System.Drawing.Size(1006, 488);
			this.Controls.Add(this.lblTotal);
			this.Controls.Add(this.dgvReportes);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Name = "Reportes";
			this.Text = "Reportes";
			this.Click += new System.EventHandler(this.ReportesLoad);
			((System.ComponentModel.ISupportInitialize)(this.dgvReportes)).EndInit();
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.Label lblTotal;
		private System.Windows.Forms.DataGridView dgvReportes;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button1;
	}
}
