namespace Export_Import
{
    partial class formListStock
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
            this.pnlBawah = new System.Windows.Forms.Panel();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnNewItem = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.id_item = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nama_item = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_gudang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nama_category = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.berat_item = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panjang_item = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tinggi_item = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lebar_item = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kadar_air_item = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jenis_ppn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.satuan_item = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qty_item = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.harga_jual_item = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.harga_beli_item = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.balance_cost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnClose = new System.Windows.Forms.Button();
            this.groupFilter = new System.Windows.Forms.GroupBox();
            this.btnMore = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cbCategory = new System.Windows.Forms.ComboBox();
            this.txtKeyword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlAtas.SuspendLayout();
            this.pnlBawah.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.groupFilter.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlAtas
            // 
            this.pnlAtas.BackColor = System.Drawing.Color.MediumTurquoise;
            this.pnlAtas.Controls.Add(this.label1);
            this.pnlAtas.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlAtas.Location = new System.Drawing.Point(0, 0);
            this.pnlAtas.Name = "pnlAtas";
            this.pnlAtas.Size = new System.Drawing.Size(1350, 85);
            this.pnlAtas.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(206, 59);
            this.label1.TabIndex = 0;
            this.label1.Text = "List Stock";
            // 
            // pnlBawah
            // 
            this.pnlBawah.BackColor = System.Drawing.SystemColors.Control;
            this.pnlBawah.Controls.Add(this.btnDelete);
            this.pnlBawah.Controls.Add(this.btnUpdate);
            this.pnlBawah.Controls.Add(this.btnNewItem);
            this.pnlBawah.Controls.Add(this.dataGridView);
            this.pnlBawah.Controls.Add(this.btnClose);
            this.pnlBawah.Controls.Add(this.groupFilter);
            this.pnlBawah.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBawah.Location = new System.Drawing.Point(0, 104);
            this.pnlBawah.Name = "pnlBawah";
            this.pnlBawah.Size = new System.Drawing.Size(1350, 625);
            this.pnlBawah.TabIndex = 1;
            // 
            // btnDelete
            // 
            this.btnDelete.Enabled = false;
            this.btnDelete.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(256, 119);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(85, 30);
            this.btnDelete.TabIndex = 6;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Enabled = false;
            this.btnUpdate.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.Location = new System.Drawing.Point(347, 119);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(85, 30);
            this.btnUpdate.TabIndex = 5;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnNewItem
            // 
            this.btnNewItem.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewItem.Location = new System.Drawing.Point(438, 119);
            this.btnNewItem.Name = "btnNewItem";
            this.btnNewItem.Size = new System.Drawing.Size(85, 30);
            this.btnNewItem.TabIndex = 4;
            this.btnNewItem.Text = "New Item";
            this.btnNewItem.UseVisualStyleBackColor = true;
            this.btnNewItem.Click += new System.EventHandler(this.btnNewItem_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_item,
            this.nama_item,
            this.id_gudang,
            this.nama_category,
            this.berat_item,
            this.panjang_item,
            this.tinggi_item,
            this.lebar_item,
            this.kadar_air_item,
            this.jenis_ppn,
            this.satuan_item,
            this.qty_item,
            this.harga_jual_item,
            this.harga_beli_item,
            this.balance_cost});
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridView.Location = new System.Drawing.Point(0, 155);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(1350, 470);
            this.dataGridView.TabIndex = 3;
            this.dataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellClick);
            // 
            // id_item
            // 
            this.id_item.DataPropertyName = "ID";
            this.id_item.Frozen = true;
            this.id_item.HeaderText = "ID";
            this.id_item.Name = "id_item";
            this.id_item.ReadOnly = true;
            this.id_item.Width = 75;
            // 
            // nama_item
            // 
            this.nama_item.DataPropertyName = "Nama";
            this.nama_item.Frozen = true;
            this.nama_item.HeaderText = "Nama";
            this.nama_item.Name = "nama_item";
            this.nama_item.ReadOnly = true;
            this.nama_item.Width = 150;
            // 
            // id_gudang
            // 
            this.id_gudang.DataPropertyName = "Lokasi";
            this.id_gudang.Frozen = true;
            this.id_gudang.HeaderText = "Lokasi";
            this.id_gudang.Name = "id_gudang";
            this.id_gudang.ReadOnly = true;
            this.id_gudang.Width = 75;
            // 
            // nama_category
            // 
            this.nama_category.DataPropertyName = "Category";
            this.nama_category.Frozen = true;
            this.nama_category.HeaderText = "Category";
            this.nama_category.Name = "nama_category";
            this.nama_category.ReadOnly = true;
            this.nama_category.Width = 75;
            // 
            // berat_item
            // 
            this.berat_item.DataPropertyName = "Berat";
            this.berat_item.Frozen = true;
            this.berat_item.HeaderText = "Berat";
            this.berat_item.Name = "berat_item";
            this.berat_item.ReadOnly = true;
            this.berat_item.Width = 50;
            // 
            // panjang_item
            // 
            this.panjang_item.DataPropertyName = "Panjang";
            this.panjang_item.Frozen = true;
            this.panjang_item.HeaderText = "Panjang";
            this.panjang_item.Name = "panjang_item";
            this.panjang_item.ReadOnly = true;
            this.panjang_item.Width = 50;
            // 
            // tinggi_item
            // 
            this.tinggi_item.DataPropertyName = "Tinggi";
            this.tinggi_item.Frozen = true;
            this.tinggi_item.HeaderText = "Tinggi";
            this.tinggi_item.Name = "tinggi_item";
            this.tinggi_item.ReadOnly = true;
            this.tinggi_item.Width = 50;
            // 
            // lebar_item
            // 
            this.lebar_item.DataPropertyName = "Lebar";
            this.lebar_item.Frozen = true;
            this.lebar_item.HeaderText = "Lebar";
            this.lebar_item.Name = "lebar_item";
            this.lebar_item.ReadOnly = true;
            this.lebar_item.Width = 50;
            // 
            // kadar_air_item
            // 
            this.kadar_air_item.DataPropertyName = "Kadar";
            this.kadar_air_item.Frozen = true;
            this.kadar_air_item.HeaderText = "Kadar Air";
            this.kadar_air_item.Name = "kadar_air_item";
            this.kadar_air_item.ReadOnly = true;
            this.kadar_air_item.Width = 50;
            // 
            // jenis_ppn
            // 
            this.jenis_ppn.DataPropertyName = "PPN";
            this.jenis_ppn.Frozen = true;
            this.jenis_ppn.HeaderText = "Jenis PPN";
            this.jenis_ppn.Name = "jenis_ppn";
            this.jenis_ppn.ReadOnly = true;
            this.jenis_ppn.Width = 50;
            // 
            // satuan_item
            // 
            this.satuan_item.DataPropertyName = "Satuan";
            this.satuan_item.Frozen = true;
            this.satuan_item.HeaderText = "Satuan";
            this.satuan_item.Name = "satuan_item";
            this.satuan_item.ReadOnly = true;
            this.satuan_item.Width = 75;
            // 
            // qty_item
            // 
            this.qty_item.DataPropertyName = "QTY";
            this.qty_item.Frozen = true;
            this.qty_item.HeaderText = "Qty";
            this.qty_item.Name = "qty_item";
            this.qty_item.ReadOnly = true;
            // 
            // harga_jual_item
            // 
            this.harga_jual_item.DataPropertyName = "hJual";
            this.harga_jual_item.Frozen = true;
            this.harga_jual_item.HeaderText = "Harga Jual";
            this.harga_jual_item.Name = "harga_jual_item";
            this.harga_jual_item.ReadOnly = true;
            this.harga_jual_item.Width = 150;
            // 
            // harga_beli_item
            // 
            this.harga_beli_item.DataPropertyName = "hBeli";
            this.harga_beli_item.Frozen = true;
            this.harga_beli_item.HeaderText = "Harga Beli";
            this.harga_beli_item.Name = "harga_beli_item";
            this.harga_beli_item.ReadOnly = true;
            this.harga_beli_item.Width = 150;
            // 
            // balance_cost
            // 
            this.balance_cost.DataPropertyName = "balance_cost";
            this.balance_cost.Frozen = true;
            this.balance_cost.HeaderText = "Balance Cost";
            this.balance_cost.Name = "balance_cost";
            this.balance_cost.ReadOnly = true;
            this.balance_cost.Width = 150;
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(12, 119);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(85, 30);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // groupFilter
            // 
            this.groupFilter.Controls.Add(this.btnMore);
            this.groupFilter.Controls.Add(this.label3);
            this.groupFilter.Controls.Add(this.cbCategory);
            this.groupFilter.Controls.Add(this.txtKeyword);
            this.groupFilter.Controls.Add(this.label2);
            this.groupFilter.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupFilter.Location = new System.Drawing.Point(13, 4);
            this.groupFilter.Name = "groupFilter";
            this.groupFilter.Size = new System.Drawing.Size(510, 109);
            this.groupFilter.TabIndex = 0;
            this.groupFilter.TabStop = false;
            this.groupFilter.Text = "Filter";
            // 
            // btnMore
            // 
            this.btnMore.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMore.Location = new System.Drawing.Point(405, 21);
            this.btnMore.Name = "btnMore";
            this.btnMore.Size = new System.Drawing.Size(99, 27);
            this.btnMore.TabIndex = 3;
            this.btnMore.Text = "More Option";
            this.btnMore.UseVisualStyleBackColor = true;
            this.btnMore.Click += new System.EventHandler(this.btnMore_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(16, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 19);
            this.label3.TabIndex = 1;
            this.label3.Text = "Kategori :";
            // 
            // cbCategory
            // 
            this.cbCategory.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCategory.FormattingEnabled = true;
            this.cbCategory.Location = new System.Drawing.Point(93, 65);
            this.cbCategory.Name = "cbCategory";
            this.cbCategory.Size = new System.Drawing.Size(200, 27);
            this.cbCategory.TabIndex = 2;
            this.cbCategory.DropDownClosed += new System.EventHandler(this.cbCategory_DropDownClosed);
            // 
            // txtKeyword
            // 
            this.txtKeyword.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKeyword.Location = new System.Drawing.Point(93, 22);
            this.txtKeyword.Name = "txtKeyword";
            this.txtKeyword.Size = new System.Drawing.Size(200, 27);
            this.txtKeyword.TabIndex = 1;
            this.txtKeyword.TextChanged += new System.EventHandler(this.txtKeyword_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(15, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 19);
            this.label2.TabIndex = 0;
            this.label2.Text = "Keyword :";
            // 
            // formListStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1350, 729);
            this.Controls.Add(this.pnlBawah);
            this.Controls.Add(this.pnlAtas);
            this.Name = "formListStock";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "List Stock";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.formListStock_Load);
            this.pnlAtas.ResumeLayout(false);
            this.pnlAtas.PerformLayout();
            this.pnlBawah.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.groupFilter.ResumeLayout(false);
            this.groupFilter.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlAtas;
        private System.Windows.Forms.Panel pnlBawah;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupFilter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnMore;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridView dataGridView;
        public System.Windows.Forms.TextBox txtKeyword;
        public System.Windows.Forms.ComboBox cbCategory;
        private System.Windows.Forms.Button btnNewItem;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_item;
        private System.Windows.Forms.DataGridViewTextBoxColumn nama_item;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_gudang;
        private System.Windows.Forms.DataGridViewTextBoxColumn nama_category;
        private System.Windows.Forms.DataGridViewTextBoxColumn berat_item;
        private System.Windows.Forms.DataGridViewTextBoxColumn panjang_item;
        private System.Windows.Forms.DataGridViewTextBoxColumn tinggi_item;
        private System.Windows.Forms.DataGridViewTextBoxColumn lebar_item;
        private System.Windows.Forms.DataGridViewTextBoxColumn kadar_air_item;
        private System.Windows.Forms.DataGridViewTextBoxColumn jenis_ppn;
        private System.Windows.Forms.DataGridViewTextBoxColumn satuan_item;
        private System.Windows.Forms.DataGridViewTextBoxColumn qty_item;
        private System.Windows.Forms.DataGridViewTextBoxColumn harga_jual_item;
        private System.Windows.Forms.DataGridViewTextBoxColumn harga_beli_item;
        private System.Windows.Forms.DataGridViewTextBoxColumn balance_cost;
        private System.Windows.Forms.Button btnDelete;
    }
}