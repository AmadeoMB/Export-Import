namespace Export_Import
{
    partial class FormListPurchaseOrder
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
            this.id_po = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nama_supplier = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tgl_so = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jumlah_barang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupFilter = new System.Windows.Forms.GroupBox();
            this.btnCreate = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.numJumlah = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.txtKeyword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlAtas = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnEdit = new System.Windows.Forms.Button();
            this.pnlBawah.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.groupFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numJumlah)).BeginInit();
            this.pnlAtas.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBawah
            // 
            this.pnlBawah.Controls.Add(this.dataGridView);
            this.pnlBawah.Controls.Add(this.groupFilter);
            this.pnlBawah.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBawah.Location = new System.Drawing.Point(0, 73);
            this.pnlBawah.Name = "pnlBawah";
            this.pnlBawah.Size = new System.Drawing.Size(1350, 656);
            this.pnlBawah.TabIndex = 6;
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_po,
            this.nama_supplier,
            this.tgl_so,
            this.jumlah_barang});
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridView.Location = new System.Drawing.Point(0, 183);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(1350, 473);
            this.dataGridView.TabIndex = 2;
            this.dataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellClick);
            this.dataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellContentClick);
            // 
            // id_po
            // 
            this.id_po.DataPropertyName = "id";
            this.id_po.Frozen = true;
            this.id_po.HeaderText = "Nomer P/O";
            this.id_po.Name = "id_po";
            this.id_po.ReadOnly = true;
            this.id_po.Width = 150;
            // 
            // nama_supplier
            // 
            this.nama_supplier.DataPropertyName = "nama";
            this.nama_supplier.Frozen = true;
            this.nama_supplier.HeaderText = "Nama Supplier";
            this.nama_supplier.Name = "nama_supplier";
            this.nama_supplier.ReadOnly = true;
            this.nama_supplier.Width = 150;
            // 
            // tgl_so
            // 
            this.tgl_so.DataPropertyName = "tanggal";
            this.tgl_so.Frozen = true;
            this.tgl_so.HeaderText = "Tanggal";
            this.tgl_so.Name = "tgl_so";
            this.tgl_so.ReadOnly = true;
            this.tgl_so.Width = 150;
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
            // groupFilter
            // 
            this.groupFilter.Controls.Add(this.btnEdit);
            this.groupFilter.Controls.Add(this.btnCreate);
            this.groupFilter.Controls.Add(this.btnBack);
            this.groupFilter.Controls.Add(this.numJumlah);
            this.groupFilter.Controls.Add(this.label4);
            this.groupFilter.Controls.Add(this.txtKeyword);
            this.groupFilter.Controls.Add(this.label2);
            this.groupFilter.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupFilter.Location = new System.Drawing.Point(12, 13);
            this.groupFilter.Name = "groupFilter";
            this.groupFilter.Size = new System.Drawing.Size(572, 145);
            this.groupFilter.TabIndex = 1;
            this.groupFilter.TabStop = false;
            this.groupFilter.Text = "Filter";
            // 
            // btnCreate
            // 
            this.btnCreate.Enabled = false;
            this.btnCreate.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreate.Location = new System.Drawing.Point(416, 103);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(150, 42);
            this.btnCreate.TabIndex = 6;
            this.btnCreate.Text = "Create P/I";
            this.btnCreate.UseVisualStyleBackColor = true;
            // 
            // btnBack
            // 
            this.btnBack.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.Location = new System.Drawing.Point(416, 7);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(150, 42);
            this.btnBack.TabIndex = 7;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // numJumlah
            // 
            this.numJumlah.Location = new System.Drawing.Point(139, 68);
            this.numJumlah.Name = "numJumlah";
            this.numJumlah.Size = new System.Drawing.Size(191, 23);
            this.numJumlah.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(21, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 19);
            this.label4.TabIndex = 4;
            this.label4.Text = "Jumlah Barang :";
            // 
            // txtKeyword
            // 
            this.txtKeyword.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKeyword.Location = new System.Drawing.Point(139, 22);
            this.txtKeyword.Name = "txtKeyword";
            this.txtKeyword.Size = new System.Drawing.Size(200, 27);
            this.txtKeyword.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(22, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 19);
            this.label2.TabIndex = 0;
            this.label2.Text = "Nama Supplier :";
            // 
            // pnlAtas
            // 
            this.pnlAtas.BackColor = System.Drawing.Color.MediumTurquoise;
            this.pnlAtas.Controls.Add(this.label1);
            this.pnlAtas.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlAtas.Location = new System.Drawing.Point(0, 0);
            this.pnlAtas.Name = "pnlAtas";
            this.pnlAtas.Size = new System.Drawing.Size(1350, 85);
            this.pnlAtas.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(403, 59);
            this.label1.TabIndex = 0;
            this.label1.Text = "List Purchase Order";
            // 
            // btnEdit
            // 
            this.btnEdit.Font = new System.Drawing.Font("Calibri", 12F);
            this.btnEdit.Location = new System.Drawing.Point(416, 55);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(150, 41);
            this.btnEdit.TabIndex = 8;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // FormListPurchaseOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1350, 729);
            this.Controls.Add(this.pnlBawah);
            this.Controls.Add(this.pnlAtas);
            this.Name = "FormListPurchaseOrder";
            this.Text = "FormListPurchaseOrder";
            this.Load += new System.EventHandler(this.FormListPurchaseOrder_Load);
            this.pnlBawah.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.groupFilter.ResumeLayout(false);
            this.groupFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numJumlah)).EndInit();
            this.pnlAtas.ResumeLayout(false);
            this.pnlAtas.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlBawah;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.GroupBox groupFilter;
        private System.Windows.Forms.NumericUpDown numJumlah;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox txtKeyword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pnlAtas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_po;
        private System.Windows.Forms.DataGridViewTextBoxColumn nama_supplier;
        private System.Windows.Forms.DataGridViewTextBoxColumn tgl_so;
        private System.Windows.Forms.DataGridViewTextBoxColumn jumlah_barang;
        private System.Windows.Forms.Button btnEdit;
    }
}