﻿namespace Export_Import
{
    partial class formListInvoice
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
            this.pnlBawah = new System.Windows.Forms.Panel();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.id_invoice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nama_customer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tgl_invoice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jumlah_barang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnBack = new System.Windows.Forms.Button();
            this.pnlAtas = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlBawah.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.pnlAtas.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBawah
            // 
            this.pnlBawah.Controls.Add(this.dataGridView);
            this.pnlBawah.Controls.Add(this.btnBack);
            this.pnlBawah.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBawah.Location = new System.Drawing.Point(0, 91);
            this.pnlBawah.Name = "pnlBawah";
            this.pnlBawah.Size = new System.Drawing.Size(1350, 656);
            this.pnlBawah.TabIndex = 10;
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_invoice,
            this.nama_customer,
            this.tgl_invoice,
            this.jumlah_barang});
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridView.Location = new System.Drawing.Point(0, 61);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(1350, 595);
            this.dataGridView.TabIndex = 2;
            // 
            // id_invoice
            // 
            this.id_invoice.DataPropertyName = "id";
            this.id_invoice.Frozen = true;
            this.id_invoice.HeaderText = "Nomer Invoice";
            this.id_invoice.Name = "id_invoice";
            this.id_invoice.ReadOnly = true;
            this.id_invoice.Width = 150;
            // 
            // nama_customer
            // 
            this.nama_customer.DataPropertyName = "nama";
            this.nama_customer.Frozen = true;
            this.nama_customer.HeaderText = "Nama Customer";
            this.nama_customer.Name = "nama_customer";
            this.nama_customer.ReadOnly = true;
            this.nama_customer.Width = 150;
            // 
            // tgl_invoice
            // 
            this.tgl_invoice.DataPropertyName = "tanggal";
            this.tgl_invoice.Frozen = true;
            this.tgl_invoice.HeaderText = "Tanggal";
            this.tgl_invoice.Name = "tgl_invoice";
            this.tgl_invoice.ReadOnly = true;
            this.tgl_invoice.Width = 150;
            // 
            // jumlah_barang
            // 
            this.jumlah_barang.DataPropertyName = "jumlah";
            this.jumlah_barang.Frozen = true;
            this.jumlah_barang.HeaderText = "Jumlah Barang";
            this.jumlah_barang.Name = "jumlah_barang";
            this.jumlah_barang.ReadOnly = true;
            this.jumlah_barang.Width = 150;
            // 
            // btnBack
            // 
            this.btnBack.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.Location = new System.Drawing.Point(22, 13);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(150, 42);
            this.btnBack.TabIndex = 7;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // pnlAtas
            // 
            this.pnlAtas.BackColor = System.Drawing.Color.MediumTurquoise;
            this.pnlAtas.Controls.Add(this.label1);
            this.pnlAtas.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlAtas.Location = new System.Drawing.Point(0, 0);
            this.pnlAtas.Name = "pnlAtas";
            this.pnlAtas.Size = new System.Drawing.Size(1350, 85);
            this.pnlAtas.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(239, 59);
            this.label1.TabIndex = 0;
            this.label1.Text = "List Invoice";
            // 
            // formListInvoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1350, 747);
            this.Controls.Add(this.pnlBawah);
            this.Controls.Add(this.pnlAtas);
            this.Name = "formListInvoice";
            this.Text = "FormListInvoice";
            this.Load += new System.EventHandler(this.formListInvoice_Load);
            this.pnlBawah.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.pnlAtas.ResumeLayout(false);
            this.pnlAtas.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlBawah;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Panel pnlAtas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_invoice;
        private System.Windows.Forms.DataGridViewTextBoxColumn nama_customer;
        private System.Windows.Forms.DataGridViewTextBoxColumn tgl_invoice;
        private System.Windows.Forms.DataGridViewTextBoxColumn jumlah_barang;
    }
}