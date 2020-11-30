namespace Export_Import
{
    partial class formMasterPenjualan
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
            this.lblCustomer = new System.Windows.Forms.Label();
            this.lblStock = new System.Windows.Forms.Label();
            this.btnSO = new System.Windows.Forms.Button();
            this.btnInvoice = new System.Windows.Forms.Button();
            this.btnLaporanPenjualan = new System.Windows.Forms.Button();
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
            this.panel1.TabIndex = 1;
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
            // lblCustomer
            // 
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomer.Location = new System.Drawing.Point(12, 98);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(78, 20);
            this.lblCustomer.TabIndex = 2;
            this.lblCustomer.Text = "Customer";
            this.lblCustomer.Click += new System.EventHandler(this.lblCustomer_Click);
            // 
            // lblStock
            // 
            this.lblStock.AutoSize = true;
            this.lblStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStock.Location = new System.Drawing.Point(96, 98);
            this.lblStock.Name = "lblStock";
            this.lblStock.Size = new System.Drawing.Size(50, 20);
            this.lblStock.TabIndex = 3;
            this.lblStock.Text = "Stock";
            this.lblStock.Click += new System.EventHandler(this.lblStock_Click);
            // 
            // btnSO
            // 
            this.btnSO.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnSO.Font = new System.Drawing.Font("Calibri", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSO.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnSO.Location = new System.Drawing.Point(186, 145);
            this.btnSO.Name = "btnSO";
            this.btnSO.Size = new System.Drawing.Size(330, 62);
            this.btnSO.TabIndex = 6;
            this.btnSO.Text = "Sales Order";
            this.btnSO.UseVisualStyleBackColor = false;
            this.btnSO.Click += new System.EventHandler(this.btnSO_Click);
            // 
            // btnInvoice
            // 
            this.btnInvoice.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnInvoice.Font = new System.Drawing.Font("Calibri", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInvoice.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnInvoice.Location = new System.Drawing.Point(186, 222);
            this.btnInvoice.Name = "btnInvoice";
            this.btnInvoice.Size = new System.Drawing.Size(330, 62);
            this.btnInvoice.TabIndex = 7;
            this.btnInvoice.Text = "Invoice";
            this.btnInvoice.UseVisualStyleBackColor = false;
            this.btnInvoice.Click += new System.EventHandler(this.btnInvoice_Click);
            // 
            // btnLaporanPenjualan
            // 
            this.btnLaporanPenjualan.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnLaporanPenjualan.Font = new System.Drawing.Font("Calibri", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLaporanPenjualan.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnLaporanPenjualan.Location = new System.Drawing.Point(186, 299);
            this.btnLaporanPenjualan.Name = "btnLaporanPenjualan";
            this.btnLaporanPenjualan.Size = new System.Drawing.Size(330, 62);
            this.btnLaporanPenjualan.TabIndex = 8;
            this.btnLaporanPenjualan.Text = "Laporan Penjualan";
            this.btnLaporanPenjualan.UseVisualStyleBackColor = false;
            this.btnLaporanPenjualan.Click += new System.EventHandler(this.btnLaporanPenjualan_Click);
            // 
            // lblSignOut
            // 
            this.lblSignOut.AutoSize = true;
            this.lblSignOut.Location = new System.Drawing.Point(16, 425);
            this.lblSignOut.Name = "lblSignOut";
            this.lblSignOut.Size = new System.Drawing.Size(48, 13);
            this.lblSignOut.TabIndex = 9;
            this.lblSignOut.TabStop = true;
            this.lblSignOut.Text = "Sign Out";
            this.lblSignOut.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblSignOut_LinkClicked);
            // 
            // formMasterPenjualan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Honeydew;
            this.ClientSize = new System.Drawing.Size(720, 450);
            this.Controls.Add(this.lblSignOut);
            this.Controls.Add(this.btnLaporanPenjualan);
            this.Controls.Add(this.btnInvoice);
            this.Controls.Add(this.btnSO);
            this.Controls.Add(this.lblStock);
            this.Controls.Add(this.lblCustomer);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "formMasterPenjualan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Admin Penjualan : ";
            this.Load += new System.EventHandler(this.formMasterPenjualan_Load);
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
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.Label lblStock;
        private System.Windows.Forms.Button btnSO;
        private System.Windows.Forms.Button btnInvoice;
        private System.Windows.Forms.Button btnLaporanPenjualan;
        private System.Windows.Forms.LinkLabel lblSignOut;
    }
}