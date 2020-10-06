namespace Export_Import
{
    partial class LoginForm
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
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.lblErrorEmail = new System.Windows.Forms.Label();
            this.lblErrorPassword = new System.Windows.Forms.Label();
            this.lblErrorInput = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtEmail
            // 
            this.txtEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.ForeColor = System.Drawing.SystemColors.GrayText;
            this.txtEmail.Location = new System.Drawing.Point(166, 181);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(377, 53);
            this.txtEmail.TabIndex = 0;
            this.txtEmail.Text = "Email :";
            this.txtEmail.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtEmail_MouseClick);
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.ForeColor = System.Drawing.SystemColors.GrayText;
            this.txtPassword.Location = new System.Drawing.Point(166, 249);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(377, 53);
            this.txtPassword.TabIndex = 1;
            this.txtPassword.Text = "Password :";
            this.txtPassword.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtPassword_MouseClick);
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.SkyBlue;
            this.btnLogin.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.Location = new System.Drawing.Point(228, 322);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(253, 41);
            this.btnLogin.TabIndex = 2;
            this.btnLogin.Text = "Log In";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // lblErrorEmail
            // 
            this.lblErrorEmail.AutoSize = true;
            this.lblErrorEmail.BackColor = System.Drawing.Color.Transparent;
            this.lblErrorEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrorEmail.ForeColor = System.Drawing.Color.Red;
            this.lblErrorEmail.Location = new System.Drawing.Point(550, 201);
            this.lblErrorEmail.Name = "lblErrorEmail";
            this.lblErrorEmail.Size = new System.Drawing.Size(91, 16);
            this.lblErrorEmail.TabIndex = 3;
            this.lblErrorEmail.Text = "Email Kosong";
            this.lblErrorEmail.Visible = false;
            // 
            // lblErrorPassword
            // 
            this.lblErrorPassword.AutoSize = true;
            this.lblErrorPassword.BackColor = System.Drawing.Color.Transparent;
            this.lblErrorPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrorPassword.ForeColor = System.Drawing.Color.Red;
            this.lblErrorPassword.Location = new System.Drawing.Point(553, 266);
            this.lblErrorPassword.Name = "lblErrorPassword";
            this.lblErrorPassword.Size = new System.Drawing.Size(117, 16);
            this.lblErrorPassword.TabIndex = 4;
            this.lblErrorPassword.Text = "Password Kosong";
            this.lblErrorPassword.Visible = false;
            // 
            // lblErrorInput
            // 
            this.lblErrorInput.AutoSize = true;
            this.lblErrorInput.BackColor = System.Drawing.Color.Transparent;
            this.lblErrorInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrorInput.ForeColor = System.Drawing.Color.Red;
            this.lblErrorInput.Location = new System.Drawing.Point(282, 366);
            this.lblErrorInput.Name = "lblErrorInput";
            this.lblErrorInput.Size = new System.Drawing.Size(144, 16);
            this.lblErrorInput.TabIndex = 5;
            this.lblErrorInput.Text = "Email/Password Salah";
            this.lblErrorInput.Visible = false;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Export_Import.Properties.Resources.Login;
            this.ClientSize = new System.Drawing.Size(720, 450);
            this.Controls.Add(this.lblErrorInput);
            this.Controls.Add(this.lblErrorPassword);
            this.Controls.Add(this.lblErrorEmail);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtEmail);
            this.Name = "LoginForm";
            this.ShowInTaskbar = false;
            this.Text = "Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Label lblErrorEmail;
        private System.Windows.Forms.Label lblErrorPassword;
        private System.Windows.Forms.Label lblErrorInput;
    }
}

