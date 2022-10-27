namespace Sol_Minimarket.Presentacion
{
    partial class Frm_Login
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Login));
            this.Pnl_titulo_form = new System.Windows.Forms.Panel();
            this.label21 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Txt_login_us = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Txt_password_us = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Btn_iniciar = new System.Windows.Forms.Button();
            this.Btn_salir = new System.Windows.Forms.Button();
            this.Pnl_titulo_form.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Pnl_titulo_form
            // 
            this.Pnl_titulo_form.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(185)))), ((int)(((byte)(51)))));
            this.Pnl_titulo_form.Controls.Add(this.label21);
            this.Pnl_titulo_form.Dock = System.Windows.Forms.DockStyle.Top;
            this.Pnl_titulo_form.Location = new System.Drawing.Point(0, 0);
            this.Pnl_titulo_form.Name = "Pnl_titulo_form";
            this.Pnl_titulo_form.Size = new System.Drawing.Size(634, 29);
            this.Pnl_titulo_form.TabIndex = 9;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.Color.White;
            this.label21.Location = new System.Drawing.Point(3, 6);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(144, 18);
            this.label21.TabIndex = 0;
            this.label21.Text = "Inicio de Sesión";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(57, 52);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(103, 106);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(24, 161);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(168, 45);
            this.label1.TabIndex = 11;
            this.label1.Text = "Sistema de Minimarket\r\n\r\nversión 1.0";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Txt_login_us
            // 
            this.Txt_login_us.Location = new System.Drawing.Point(340, 68);
            this.Txt_login_us.MaxLength = 20;
            this.Txt_login_us.Name = "Txt_login_us";
            this.Txt_login_us.Size = new System.Drawing.Size(194, 20);
            this.Txt_login_us.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(285, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Login: (*)";
            // 
            // Txt_password_us
            // 
            this.Txt_password_us.Location = new System.Drawing.Point(340, 101);
            this.Txt_password_us.MaxLength = 20;
            this.Txt_password_us.Name = "Txt_password_us";
            this.Txt_password_us.PasswordChar = '*';
            this.Txt_password_us.Size = new System.Drawing.Size(194, 20);
            this.Txt_password_us.TabIndex = 14;
            this.Txt_password_us.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Txt_password_us_KeyUp);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(265, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Password: (*)";
            // 
            // Btn_iniciar
            // 
            this.Btn_iniciar.BackColor = System.Drawing.Color.LightBlue;
            this.Btn_iniciar.Location = new System.Drawing.Point(289, 142);
            this.Btn_iniciar.Name = "Btn_iniciar";
            this.Btn_iniciar.Size = new System.Drawing.Size(89, 42);
            this.Btn_iniciar.TabIndex = 16;
            this.Btn_iniciar.Text = "Iniciar";
            this.Btn_iniciar.UseVisualStyleBackColor = false;
            this.Btn_iniciar.Click += new System.EventHandler(this.Btn_iniciar_Click);
            // 
            // Btn_salir
            // 
            this.Btn_salir.BackColor = System.Drawing.Color.Gainsboro;
            this.Btn_salir.Location = new System.Drawing.Point(399, 142);
            this.Btn_salir.Name = "Btn_salir";
            this.Btn_salir.Size = new System.Drawing.Size(89, 42);
            this.Btn_salir.TabIndex = 17;
            this.Btn_salir.Text = "Salir";
            this.Btn_salir.UseVisualStyleBackColor = false;
            this.Btn_salir.Click += new System.EventHandler(this.Btn_salir_Click);
            // 
            // Frm_Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 241);
            this.Controls.Add(this.Btn_salir);
            this.Controls.Add(this.Btn_iniciar);
            this.Controls.Add(this.Txt_login_us);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Txt_password_us);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.Pnl_titulo_form);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Iniciar Sesión";
            this.Pnl_titulo_form.ResumeLayout(false);
            this.Pnl_titulo_form.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel Pnl_titulo_form;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Txt_login_us;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Txt_password_us;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Btn_iniciar;
        private System.Windows.Forms.Button Btn_salir;
    }
}