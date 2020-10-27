namespace Export_Import
{
    partial class formSearchSO
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
            this.txtKeyword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.id_sales_order = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nama_customer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tgl_sales_order = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnGet = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // txtKeyword
            // 
            this.txtKeyword.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKeyword.Location = new System.Drawing.Point(96, 17);
            this.txtKeyword.Name = "txtKeyword";
            this.txtKeyword.Size = new System.Drawing.Size(200, 27);
            this.txtKeyword.TabIndex = 7;
            this.txtKeyword.TextChanged += new System.EventHandler(this.txtKeyword_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 19);
            this.label1.TabIndex = 6;
            this.label1.Text = "Keyword : ";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_sales_order,
            this.nama_customer,
            this.tgl_sales_order});
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridView.Location = new System.Drawing.Point(0, 53);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(467, 243);
            this.dataGridView.TabIndex = 8;
            this.dataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellClick);
            this.dataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellContentClick);
            // 
            // id_sales_order
            // 
            this.id_sales_order.DataPropertyName = "id_sales_order";
            this.id_sales_order.Frozen = true;
            this.id_sales_order.HeaderText = "Nomer SO";
            this.id_sales_order.Name = "id_sales_order";
            this.id_sales_order.ReadOnly = true;
            this.id_sales_order.Width = 125;
            // 
            // nama_customer
            // 
            this.nama_customer.DataPropertyName = "nama_customer";
            this.nama_customer.Frozen = true;
            this.nama_customer.HeaderText = "Nama";
            this.nama_customer.Name = "nama_customer";
            this.nama_customer.ReadOnly = true;
            this.nama_customer.Width = 150;
            // 
            // tgl_sales_order
            // 
            this.tgl_sales_order.DataPropertyName = "tgl_sales_order";
            this.tgl_sales_order.Frozen = true;
            this.tgl_sales_order.HeaderText = "Tanggal";
            this.tgl_sales_order.Name = "tgl_sales_order";
            this.tgl_sales_order.ReadOnly = true;
            this.tgl_sales_order.Width = 150;
            // 
            // btnGet
            // 
            this.btnGet.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGet.Location = new System.Drawing.Point(380, 12);
            this.btnGet.Name = "btnGet";
            this.btnGet.Size = new System.Drawing.Size(75, 35);
            this.btnGet.TabIndex = 9;
            this.btnGet.Text = "Get";
            this.btnGet.UseVisualStyleBackColor = true;
            this.btnGet.Click += new System.EventHandler(this.btnGet_Click);
            // 
            // formSearchSO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(467, 296);
            this.Controls.Add(this.btnGet);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.txtKeyword);
            this.Controls.Add(this.label1);
            this.Name = "formSearchSO";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tambah Sales Order";
            this.Load += new System.EventHandler(this.formSearchSO_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtKeyword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button btnGet;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_sales_order;
        private System.Windows.Forms.DataGridViewTextBoxColumn nama_customer;
        private System.Windows.Forms.DataGridViewTextBoxColumn tgl_sales_order;
    }
}