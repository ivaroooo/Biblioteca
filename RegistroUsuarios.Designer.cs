/*
 * Created by SharpDevelop.
 * User: dulma
 * Date: 26/11/2026
 * Time: 10:44 p. m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace Biblioteca
{
	partial class RegistroUsuarios
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
			this.btnMostrar = new System.Windows.Forms.Button();
			this.cboTipoUser = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.grpBLector = new System.Windows.Forms.GroupBox();
			this.btnRegistrarLector = new System.Windows.Forms.Button();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.txtLectorCorreo = new System.Windows.Forms.TextBox();
			this.txtLectorCredencial = new System.Windows.Forms.TextBox();
			this.txtLectorApellido = new System.Windows.Forms.TextBox();
			this.txtLectorNombre = new System.Windows.Forms.TextBox();
			this.grpBUsuario = new System.Windows.Forms.GroupBox();
			this.cmbSisRol = new System.Windows.Forms.ComboBox();
			this.label10 = new System.Windows.Forms.Label();
			this.cmbSisEstado = new System.Windows.Forms.ComboBox();
			this.btnRegistrarUsuario = new System.Windows.Forms.Button();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.txtSisContraseña = new System.Windows.Forms.TextBox();
			this.txtSisUsuario = new System.Windows.Forms.TextBox();
			this.txtSisNombre = new System.Windows.Forms.TextBox();
			this.btnRegresarVer = new System.Windows.Forms.Button();
			this.grpBLector.SuspendLayout();
			this.grpBUsuario.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnMostrar
			// 
			this.btnMostrar.Location = new System.Drawing.Point(376, 278);
			this.btnMostrar.Name = "btnMostrar";
			this.btnMostrar.Size = new System.Drawing.Size(148, 32);
			this.btnMostrar.TabIndex = 0;
			this.btnMostrar.Text = "Registrar";
			this.btnMostrar.UseVisualStyleBackColor = true;
			this.btnMostrar.Click += new System.EventHandler(this.BtnMostrarClick);
			// 
			// cboTipoUser
			// 
			this.cboTipoUser.FormattingEnabled = true;
			this.cboTipoUser.Items.AddRange(new object[] {
									"Lector",
									"Usuario de plataforma"});
			this.cboTipoUser.Location = new System.Drawing.Point(319, 202);
			this.cboTipoUser.Name = "cboTipoUser";
			this.cboTipoUser.Size = new System.Drawing.Size(269, 24);
			this.cboTipoUser.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(274, 99);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(392, 48);
			this.label1.TabIndex = 2;
			this.label1.Text = "¿Qué tipo de usuario desea ingresar?";
			// 
			// grpBLector
			// 
			this.grpBLector.Controls.Add(this.btnRegistrarLector);
			this.grpBLector.Controls.Add(this.label5);
			this.grpBLector.Controls.Add(this.label4);
			this.grpBLector.Controls.Add(this.label3);
			this.grpBLector.Controls.Add(this.label2);
			this.grpBLector.Controls.Add(this.txtLectorCorreo);
			this.grpBLector.Controls.Add(this.txtLectorCredencial);
			this.grpBLector.Controls.Add(this.txtLectorApellido);
			this.grpBLector.Controls.Add(this.txtLectorNombre);
			this.grpBLector.Location = new System.Drawing.Point(12, 12);
			this.grpBLector.Name = "grpBLector";
			this.grpBLector.Size = new System.Drawing.Size(576, 485);
			this.grpBLector.TabIndex = 3;
			this.grpBLector.TabStop = false;
			this.grpBLector.Text = "Registrar Lector";
			// 
			// btnRegistrarLector
			// 
			this.btnRegistrarLector.Location = new System.Drawing.Point(405, 444);
			this.btnRegistrarLector.Name = "btnRegistrarLector";
			this.btnRegistrarLector.Size = new System.Drawing.Size(95, 23);
			this.btnRegistrarLector.TabIndex = 8;
			this.btnRegistrarLector.Text = "Registrar";
			this.btnRegistrarLector.UseVisualStyleBackColor = true;
			this.btnRegistrarLector.Click += new System.EventHandler(this.BtnRegistrarLectorClick);
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(19, 410);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(100, 23);
			this.label5.TabIndex = 7;
			this.label5.Text = "Correo:";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(19, 309);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(100, 23);
			this.label4.TabIndex = 6;
			this.label4.Text = "Credencial:";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(19, 204);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(100, 23);
			this.label3.TabIndex = 5;
			this.label3.Text = "Apellido:";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(19, 112);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(130, 23);
			this.label2.TabIndex = 4;
			this.label2.Text = "Nombre:";
			// 
			// txtLectorCorreo
			// 
			this.txtLectorCorreo.Location = new System.Drawing.Point(19, 436);
			this.txtLectorCorreo.Name = "txtLectorCorreo";
			this.txtLectorCorreo.Size = new System.Drawing.Size(301, 22);
			this.txtLectorCorreo.TabIndex = 3;
			// 
			// txtLectorCredencial
			// 
			this.txtLectorCredencial.Location = new System.Drawing.Point(19, 335);
			this.txtLectorCredencial.Name = "txtLectorCredencial";
			this.txtLectorCredencial.Size = new System.Drawing.Size(301, 22);
			this.txtLectorCredencial.TabIndex = 2;
			// 
			// txtLectorApellido
			// 
			this.txtLectorApellido.Location = new System.Drawing.Point(19, 230);
			this.txtLectorApellido.Name = "txtLectorApellido";
			this.txtLectorApellido.Size = new System.Drawing.Size(301, 22);
			this.txtLectorApellido.TabIndex = 1;
			// 
			// txtLectorNombre
			// 
			this.txtLectorNombre.Location = new System.Drawing.Point(19, 138);
			this.txtLectorNombre.Name = "txtLectorNombre";
			this.txtLectorNombre.Size = new System.Drawing.Size(301, 22);
			this.txtLectorNombre.TabIndex = 0;
			// 
			// grpBUsuario
			// 
			this.grpBUsuario.Controls.Add(this.cmbSisRol);
			this.grpBUsuario.Controls.Add(this.label10);
			this.grpBUsuario.Controls.Add(this.cmbSisEstado);
			this.grpBUsuario.Controls.Add(this.btnRegistrarUsuario);
			this.grpBUsuario.Controls.Add(this.label6);
			this.grpBUsuario.Controls.Add(this.label7);
			this.grpBUsuario.Controls.Add(this.label8);
			this.grpBUsuario.Controls.Add(this.label9);
			this.grpBUsuario.Controls.Add(this.txtSisContraseña);
			this.grpBUsuario.Controls.Add(this.txtSisUsuario);
			this.grpBUsuario.Controls.Add(this.txtSisNombre);
			this.grpBUsuario.Location = new System.Drawing.Point(308, 2);
			this.grpBUsuario.Name = "grpBUsuario";
			this.grpBUsuario.Size = new System.Drawing.Size(455, 495);
			this.grpBUsuario.TabIndex = 9;
			this.grpBUsuario.TabStop = false;
			this.grpBUsuario.Text = "Registrar usuario de plataforma";
			// 
			// cmbSisRol
			// 
			this.cmbSisRol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbSisRol.FormattingEnabled = true;
			this.cmbSisRol.Items.AddRange(new object[] {
									"Bibliotecario",
									"Administrador",
									"Consulta"});
			this.cmbSisRol.Location = new System.Drawing.Point(35, 364);
			this.cmbSisRol.Name = "cmbSisRol";
			this.cmbSisRol.Size = new System.Drawing.Size(121, 24);
			this.cmbSisRol.TabIndex = 18;
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(35, 338);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(100, 23);
			this.label10.TabIndex = 17;
			this.label10.Text = "Rol:";
			// 
			// cmbSisEstado
			// 
			this.cmbSisEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbSisEstado.FormattingEnabled = true;
			this.cmbSisEstado.Items.AddRange(new object[] {
									"Activo",
									"Inactivo"});
			this.cmbSisEstado.Location = new System.Drawing.Point(35, 445);
			this.cmbSisEstado.Name = "cmbSisEstado";
			this.cmbSisEstado.Size = new System.Drawing.Size(227, 24);
			this.cmbSisEstado.TabIndex = 16;
			// 
			// btnRegistrarUsuario
			// 
			this.btnRegistrarUsuario.Location = new System.Drawing.Point(337, 445);
			this.btnRegistrarUsuario.Name = "btnRegistrarUsuario";
			this.btnRegistrarUsuario.Size = new System.Drawing.Size(75, 23);
			this.btnRegistrarUsuario.TabIndex = 4;
			this.btnRegistrarUsuario.Text = "Registrar";
			this.btnRegistrarUsuario.UseVisualStyleBackColor = true;
			this.btnRegistrarUsuario.Click += new System.EventHandler(this.BtnRegistrarUsuarioClick);
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(35, 419);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(100, 23);
			this.label6.TabIndex = 15;
			this.label6.Text = "Estado:";
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(35, 258);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(100, 23);
			this.label7.TabIndex = 14;
			this.label7.Text = "Contraseña:";
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(35, 153);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(100, 23);
			this.label8.TabIndex = 13;
			this.label8.Text = "Usuario:";
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(35, 61);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(130, 23);
			this.label9.TabIndex = 12;
			this.label9.Text = "Nombre completo:";
			// 
			// txtSisContraseña
			// 
			this.txtSisContraseña.Location = new System.Drawing.Point(35, 284);
			this.txtSisContraseña.Name = "txtSisContraseña";
			this.txtSisContraseña.Size = new System.Drawing.Size(301, 22);
			this.txtSisContraseña.TabIndex = 10;
			// 
			// txtSisUsuario
			// 
			this.txtSisUsuario.Location = new System.Drawing.Point(35, 179);
			this.txtSisUsuario.Name = "txtSisUsuario";
			this.txtSisUsuario.Size = new System.Drawing.Size(301, 22);
			this.txtSisUsuario.TabIndex = 9;
			// 
			// txtSisNombre
			// 
			this.txtSisNombre.Location = new System.Drawing.Point(35, 87);
			this.txtSisNombre.Name = "txtSisNombre";
			this.txtSisNombre.Size = new System.Drawing.Size(301, 22);
			this.txtSisNombre.TabIndex = 8;
			// 
			// btnRegresarVer
			// 
			this.btnRegresarVer.Location = new System.Drawing.Point(785, 456);
			this.btnRegresarVer.Name = "btnRegresarVer";
			this.btnRegresarVer.Size = new System.Drawing.Size(100, 23);
			this.btnRegresarVer.TabIndex = 10;
			this.btnRegresarVer.Text = "Regresar";
			this.btnRegresarVer.UseVisualStyleBackColor = true;
			this.btnRegresarVer.Click += new System.EventHandler(this.BtnRegresarVerClick);
			// 
			// RegistroUsuarios
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
			this.ClientSize = new System.Drawing.Size(897, 509);
			this.Controls.Add(this.btnRegresarVer);
			this.Controls.Add(this.grpBUsuario);
			this.Controls.Add(this.grpBLector);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.cboTipoUser);
			this.Controls.Add(this.btnMostrar);
			this.Name = "RegistroUsuarios";
			this.Text = "RegistroUsuarios";
			this.grpBLector.ResumeLayout(false);
			this.grpBLector.PerformLayout();
			this.grpBUsuario.ResumeLayout(false);
			this.grpBUsuario.PerformLayout();
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.Button btnRegresarVer;
		private System.Windows.Forms.Button btnRegistrarUsuario;
		private System.Windows.Forms.TextBox txtSisNombre;
		private System.Windows.Forms.TextBox txtSisUsuario;
		private System.Windows.Forms.TextBox txtSisContraseña;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.ComboBox cmbSisEstado;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.ComboBox cmbSisRol;
		private System.Windows.Forms.GroupBox grpBUsuario;
		private System.Windows.Forms.TextBox txtLectorNombre;
		private System.Windows.Forms.TextBox txtLectorApellido;
		private System.Windows.Forms.TextBox txtLectorCredencial;
		private System.Windows.Forms.TextBox txtLectorCorreo;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Button btnRegistrarLector;
		private System.Windows.Forms.GroupBox grpBLector;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox cboTipoUser;
		private System.Windows.Forms.Button btnMostrar;
	}
}
