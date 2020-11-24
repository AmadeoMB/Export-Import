namespace Export_Import
{
    partial class formFilter
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
            this.pnlAtas = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtKeyword = new System.Windows.Forms.TextBox();
            this.cbCategory = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbSatuan = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupHarga = new System.Windows.Forms.GroupBox();
            this.numHarga2 = new System.Windows.Forms.NumericUpDown();
            this.numHarga1 = new System.Windows.Forms.NumericUpDown();
            this.checkBoxBeli = new System.Windows.Forms.CheckBox();
            this.checkBoxJual = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbPembanding = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cbLokasi = new System.Windows.Forms.ComboBox();
            this.cbJenisPPN = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.pnlAtas.SuspendLayout();
            this.groupHarga.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numHarga2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHarga1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlAtas
            // 
            this.pnlAtas.BackColor = System.Drawing.Color.MediumTurquoise;
            this.pnlAtas.Controls.Add(this.label1);
            this.pnlAtas.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlAtas.Location = new System.Drawing.Point(0, 0);
            this.pnlAtas.Name = "pnlAtas";
            this.pnlAtas.Size = new System.Drawing.Size(296, 76);
            this.pnlAtas.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(276, 59);
            this.label1.TabIndex = 1;
            this.label1.Text = "More Option";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(35, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "Keyword :";
            // 
            // txtKeyword
            // 
            this.txtKeyword.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKeyword.Location = new System.Drawing.Point(113, 80);
            this.txtKeyword.Name = "txtKeyword";
            this.txtKeyword.Size = new System.Drawing.Size(175, 27);
            this.txtKeyword.TabIndex = 2;
            // 
            // cbCategory
            // 
            this.cbCategory.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCategory.FormattingEnabled = true;
            this.cbCategory.Location = new System.Drawing.Point(113, 114);
            this.cbCategory.Name = "cbCategory";
            this.cbCategory.Size = new System.Drawing.Size(175, 27);
            this.cbCategory.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(32, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 19);
            this.label3.TabIndex = 4;
            this.label3.Text = "Category :";
            // 
            // cbSatuan
            // 
            this.cbSatuan.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSatuan.FormattingEnabled = true;
            this.cbSatuan.Location = new System.Drawing.Point(113, 147);
            this.cbSatuan.Name = "cbSatuan";
            this.cbSatuan.Size = new System.Drawing.Size(175, 27);
            this.cbSatuan.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(46, 150);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 19);
            this.label4.TabIndex = 6;
            this.label4.Text = "Satuan :";
            // 
            // groupHarga
            // 
            this.groupHarga.Controls.Add(this.numHarga2);
            this.groupHarga.Controls.Add(this.numHarga1);
            this.groupHarga.Controls.Add(this.checkBoxBeli);
            this.groupHarga.Controls.Add(this.checkBoxJual);
            this.groupHarga.Controls.Add(this.label6);
            this.groupHarga.Controls.Add(this.label5);
            this.groupHarga.Controls.Add(this.cbPembanding);
            this.groupHarga.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupHarga.Location = new System.Drawing.Point(12, 180);
            this.groupHarga.Name = "groupHarga";
            this.groupHarga.Size = new System.Drawing.Size(276, 168);
            this.groupHarga.TabIndex = 7;
            this.groupHarga.TabStop = false;
            this.groupHarga.Text = "Harga";
            // 
            // numHarga2
            // 
            this.numHarga2.Enabled = false;
            this.numHarga2.Location = new System.Drawing.Point(88, 122);
            this.numHarga2.Maximum = new decimal(new int[] {
            1215752191,
            23,
            0,
            0});
            this.numHarga2.Name = "numHarga2";
            this.numHarga2.Size = new System.Drawing.Size(175, 27);
            this.numHarga2.TabIndex = 14;
            // 
            // numHarga1
            // 
            this.numHarga1.Location = new System.Drawing.Point(88, 89);
            this.numHarga1.Maximum = new decimal(new int[] {
            1215752191,
            23,
            0,
            0});
            this.numHarga1.Name = "numHarga1";
            this.numHarga1.Size = new System.Drawing.Size(175, 27);
            this.numHarga1.TabIndex = 13;
            // 
            // checkBoxBeli
            // 
            this.checkBoxBeli.AutoSize = true;
            this.checkBoxBeli.Location = new System.Drawing.Point(136, 26);
            this.checkBoxBeli.Name = "checkBoxBeli";
            this.checkBoxBeli.Size = new System.Drawing.Size(53, 23);
            this.checkBoxBeli.TabIndex = 12;
            this.checkBoxBeli.Text = "Beli";
            this.checkBoxBeli.UseVisualStyleBackColor = true;
            // 
            // checkBoxJual
            // 
            this.checkBoxJual.AutoSize = true;
            this.checkBoxJual.Location = new System.Drawing.Point(77, 26);
            this.checkBoxJual.Name = "checkBoxJual";
            this.checkBoxJual.Size = new System.Drawing.Size(53, 23);
            this.checkBoxJual.TabIndex = 11;
            this.checkBoxJual.Text = "Jual";
            this.checkBoxJual.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(18, 124);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 19);
            this.label6.TabIndex = 9;
            this.label6.Text = "Harga2 :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(26, 91);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 19);
            this.label5.TabIndex = 8;
            this.label5.Text = "Harga :";
            // 
            // cbPembanding
            // 
            this.cbPembanding.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPembanding.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbPembanding.FormattingEnabled = true;
            this.cbPembanding.Items.AddRange(new object[] {
            "Semua",
            "<",
            ">",
            "Diantara"});
            this.cbPembanding.Location = new System.Drawing.Point(46, 55);
            this.cbPembanding.Name = "cbPembanding";
            this.cbPembanding.Size = new System.Drawing.Size(175, 27);
            this.cbPembanding.TabIndex = 8;
            this.cbPembanding.SelectedIndexChanged += new System.EventHandler(this.cbPembanding_SelectedIndexChanged);
            this.cbPembanding.DropDownClosed += new System.EventHandler(this.cbPembanding_DropDownClosed);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(46, 366);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 19);
            this.label7.TabIndex = 8;
            this.label7.Text = "Lokasi :";
            // 
            // cbLokasi
            // 
            this.cbLokasi.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbLokasi.FormattingEnabled = true;
            this.cbLokasi.Location = new System.Drawing.Point(113, 363);
            this.cbLokasi.Name = "cbLokasi";
            this.cbLokasi.Size = new System.Drawing.Size(175, 27);
            this.cbLokasi.TabIndex = 9;
            // 
            // cbJenisPPN
            // 
            this.cbJenisPPN.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbJenisPPN.FormattingEnabled = true;
            this.cbJenisPPN.Items.AddRange(new object[] {
            "Semua",
            "EXC",
            "INC"});
            this.cbJenisPPN.Location = new System.Drawing.Point(113, 396);
            this.cbJenisPPN.Name = "cbJenisPPN";
            this.cbJenisPPN.Size = new System.Drawing.Size(175, 27);
            this.cbJenisPPN.TabIndex = 10;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(25, 399);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 19);
            this.label8.TabIndex = 11;
            this.label8.Text = "Jenis PPN :";
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(12, 440);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(272, 29);
            this.btnSearch.TabIndex = 12;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // formFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(296, 479);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cbJenisPPN);
            this.Controls.Add(this.cbLokasi);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.groupHarga);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbSatuan);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbCategory);
            this.Controls.Add(this.txtKeyword);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pnlAtas);
            this.Name = "formFilter";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Filter";
            this.Load += new System.EventHandler(this.formFilter_Load);
            this.pnlAtas.ResumeLayout(false);
            this.pnlAtas.PerformLayout();
            this.groupHarga.ResumeLayout(false);
            this.groupHarga.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numHarga2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHarga1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlAtas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtKeyword;
        private System.Windows.Forms.ComboBox cbCategory;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbSatuan;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupHarga;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbPembanding;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbLokasi;
        private System.Windows.Forms.CheckBox checkBoxJual;
        private System.Windows.Forms.CheckBox checkBoxBeli;
        private System.Windows.Forms.NumericUpDown numHarga1;
        private System.Windows.Forms.NumericUpDown numHarga2;
        private System.Windows.Forms.ComboBox cbJenisPPN;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnSearch;
    }
}