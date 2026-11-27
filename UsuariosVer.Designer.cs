/*
 * Created by SharpDevelop.
 * User: dulma
 * Date: 26/11/2026
 * Time: 11:12 p. m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace Biblioteca
{
	partial class UsuariosVer
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
			this.btnRegistrar = new System.Windows.Forms.Button();
			this.btnRegresar = new System.Windows.Forms.Button();
			this.cboTipoUsuario = new System.Windows.Forms.ComboBox();
			this.btnEliminar = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.SuspendLayout();
			// 
			// dataGridView1
			// 
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Location = new System.Drawing.Point(12, 66);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.RowTemplate.Height = 24;
			this.dataGridView1.Size = new System.Drawing.Size(894, 430);
			this.dataGridView1.TabIndex = 0;
			// 
			// btnRegistrar
			// 
			this.btnRegistrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
			this.btnRegistrar.Location = new System.Drawing.Point(924, 344);
			this.btnRegistrar.Name = "btnRegistrar";
			this.btnRegistrar.Size = new System.Drawing.Size(94, 28);
			this.btnRegistrar.TabIndex = 1;
			this.btnRegistrar.Text = "Registrar";
			this.btnRegistrar.UseVisualStyleBackColor = false;
			this.btnRegistrar.Click += new System.EventHandler(this.BtnRegistrarClick);
			// 
			// btnRegresar
			// 
			this.btnRegresar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
			this.btnRegresar.Location = new System.Drawing.Point(924, 443);
			this.btnRegresar.Name = "btnRegresar";
			this.btnRegresar.Size = new System.Drawing.Size(94, 28);
			this.btnRegresar.TabIndex = 2;
			this.btnRegresar.Text = "Regresar";
			this.btnRegresar.UseVisualStyleBackColor = false;
			this.btnRegresar.Click += new System.EventHandler(this.BtnRegresarClick);
			// 
			// cboTipoUsuario
			// 
			this.cboTipoUsuario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboTipoUsuario.FormattingEnabled = true;
			this.cboTipoUsuario.Items.AddRange(new object[] {
									"Lector",
									"Usuario de plataforma"});
			this.cboTipoUsuario.Location = new System.Drawing.Point(12, 25);
			this.cboTipoUsuario.Name = "cboTipoUsuario";
			this.cboTipoUsuario.Size = new System.Drawing.Size(155, 24);
			this.cboTipoUsuario.TabIndex = 3;
			this.cboTipoUsuario.SelectedIndexChanged += new System.EventHandler(this.CboTipoUsuarioSelectedIndexChanged);
			// 
			// btnEliminar
			// 
			this.btnEliminar.BackColor = System.Drawing.Color.Red;
			this.btnEliminar.Location = new System.Drawing.Point(924, 397);
			this.btnEliminar.Name = "btnEliminar";
			this.btnEliminar.Size = new System.Drawing.Size(94, 27);
			this.btnEliminar.TabIndex = 4;
			this.btnEliminar.Text = "Eliminar";
			this.btnEliminar.UseVisualStyleBackColor = false;
			this.btnEliminar.Click += new System.EventHandler(this.BtnEliminarClick);
			// 
			// UsuariosVer
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
			this.ClientSize = new System.Drawing.Size(1057, 508);
			this.Controls.Add(this.btnEliminar);
			this.Controls.Add(this.cboTipoUsuario);
			this.Controls.Add(this.btnRegresar);
			this.Controls.Add(this.btnRegistrar);
			this.Controls.Add(this.dataGridView1);
			this.Name = "UsuariosVer";
			this.Text = "UsuariosVer";
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.Button btnEliminar;
		private System.Windows.Forms.ComboBox cboTipoUsuario;
		private System.Windows.Forms.Button btnRegresar;
		private System.Windows.Forms.Button btnRegistrar;
		private System.Windows.Forms.DataGridView dataGridView1;
	}
}
