namespace Export_Import
{
    partial class formMasterPembelian
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.lblSupplier = new System.Windows.Forms.Label();
            this.btnPO = new System.Windows.Forms.Button();
            this.btnPI = new System.Windows.Forms.Button();
            this.btnLaporanPembelian = new System.Windows.Forms.Button();
            this.lblSignOut = new System.Windows.Forms.LinkLabel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(722, 95);
            this.panel1.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Honeydew;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(120, 21);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(466, 54);
            this.panel2.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(38, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(395, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "PT. EXPORT IMPORT INDONESIA";
            // 
            // lblSupplier
            // 
            this.lblSupplier.AutoSize = true;
            this.lblSupplier.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSupplier.Location = new System.Drawing.Point(12, 98);
            this.lblSupplier.Name = "lblSupplier";
            this.lblSupplier.Size = new System.Drawing.Size(67, 20);
            this.lblSupplier.TabIndex = 4;
            this.lblSupplier.Text = "Supplier";
            this.lblSupplier.Click += new System.EventHandler(this.lblSupplier_Click);
            // 
            // btnPO
            // 
            this.btnPO.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnPO.Font = new System.Drawing.Font("Calibri", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPO.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnPO.Location = new System.Drawing.Point(186, 145);
            this.btnPO.Name = "btnPO";
            this.btnPO.Size = new System.Drawing.Size(330, 62);
            this.btnPO.TabIndex = 5;
            this.btnPO.Text = "Purchase Order";
            this.btnPO.UseVisualStyleBackColor = false;
            this.btnPO.Click += new System.EventHandler(this.btnPO_Click);
            // 
            // btnPI
            // 
            this.btnPI.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnPI.Font = new System.Drawing.Font("Calibri", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPI.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnPI.Location = new System.Drawing.Point(186, 222);
            this.btnPI.Name = "btnPI";
            this.btnPI.Size = new System.Drawing.Size(330, 62);
            this.btnPI.TabIndex = 6;
            this.btnPI.Text = "Purchase Invoice";
            this.btnPI.UseVisualStyleBackColor = false;
            this.btnPI.Click += new System.EventHandler(this.btnPI_Click);
            // 
            // btnLaporanPembelian
            // 
            this.btnLaporanPembelian.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnLaporanPembelian.Font = new System.Drawing.Font("Calibri", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLaporanPembelian.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnLaporanPembelian.Location = new System.Drawing.Point(186, 299);
            this.btnLaporanPembelian.Name = "btnLaporanPembelian";
            this.btnLaporanPembelian.Size = new System.Drawing.Size(330, 62);
            this.btnLaporanPembelian.TabIndex = 7;
            this.btnLaporanPembelian.Text = "Laporan Pembelian";
            this.btnLaporanPembelian.UseVisualStyleBackColor = false;
            this.btnLaporanPembelian.Click += new System.EventHandler(this.btnLaporanPembelian_Click);
            // 
            // lblSignOut
            // 
            this.lblSignOut.AutoSize = true;
            this.lblSignOut.Location = new System.Drawing.Point(16, 425);
            this.lblSignOut.Name = "lblSignOut";
            this.lblSignOut.Size = new System.Drawing.Size(48, 13);
            this.lblSignOut.TabIndex = 8;
            this.lblSignOut.TabStop = true;
            this.lblSignOut.Text = "Sign Out";
            this.lblSignOut.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblSignOut_LinkClicked);
            // 
            // formMasterPembelian
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Honeydew;
            this.ClientSize = new System.Drawing.Size(720, 450);
            this.Controls.Add(this.lblSignOut);
            this.Controls.Add(this.btnLaporanPembelian);
            this.Controls.Add(this.btnPI);
            this.Controls.Add(this.btnPO);
            this.Controls.Add(this.lblSupplier);
            this.Controls.Add(this.panel1);
            this.Name = "formMasterPembelian";
            this.Text = "Admin Pembelian : ";
            this.Load += new System.EventHandler(this.formMasterPembelian_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblSupplier;
        private System.Windows.Forms.Button btnPO;
        private System.Windows.Forms.Button btnPI;
        private System.Windows.Forms.Button btnLaporanPembelian;
        private System.Windows.Forms.LinkLabel lblSignOut;
    }
}