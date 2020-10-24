namespace Export_Import
{
    partial class formSearchPO
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
            this.btnGet = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.id_purchase_order = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nama_customer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tgl_purchase_order = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtKeyword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGet
            // 
            this.btnGet.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGet.Location = new System.Drawing.Point(379, 6);
            this.btnGet.Name = "btnGet";
            this.btnGet.Size = new System.Drawing.Size(75, 35);
            this.btnGet.TabIndex = 13;
            this.btnGet.Text = "Get";
            this.btnGet.UseVisualStyleBackColor = true;
            this.btnGet.Click += new System.EventHandler(this.btnGet_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_purchase_order,
            this.nama_customer,
            this.tgl_purchase_order});
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridView.Location = new System.Drawing.Point(0, 53);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(453, 243);
            this.dataGridView.TabIndex = 12;
            // 
            // id_purchase_order
            // 
            this.id_purchase_order.DataPropertyName = "id_purchase_order";
            this.id_purchase_order.Frozen = true;
            this.id_purchase_order.HeaderText = "Nomer PO";
            this.id_purchase_order.Name = "id_purchase_order";
            this.id_purchase_order.ReadOnly = true;
            this.id_purchase_order.Width = 125;
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
            // tgl_purchase_order
            // 
            this.tgl_purchase_order.DataPropertyName = "tgl_purchase_order";
            this.tgl_purchase_order.Frozen = true;
            this.tgl_purchase_order.HeaderText = "Tanggal";
            this.tgl_purchase_order.Name = "tgl_purchase_order";
            this.tgl_purchase_order.ReadOnly = true;
            this.tgl_purchase_order.Width = 150;
            // 
            // txtKeyword
            // 
            this.txtKeyword.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKeyword.Location = new System.Drawing.Point(95, 11);
            this.txtKeyword.Name = "txtKeyword";
            this.txtKeyword.Size = new System.Drawing.Size(200, 27);
            this.txtKeyword.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 19);
            this.label1.TabIndex = 10;
            this.label1.Text = "Keyword : ";
            // 
            // formSearchPO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(453, 296);
            this.Controls.Add(this.btnGet);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.txtKeyword);
            this.Controls.Add(this.label1);
            this.Name = "formSearchPO";
            this.Text = "formSearchPO";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGet;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_purchase_order;
        private System.Windows.Forms.DataGridViewTextBoxColumn nama_customer;
        private System.Windows.Forms.DataGridViewTextBoxColumn tgl_purchase_order;
        private System.Windows.Forms.TextBox txtKeyword;
        private System.Windows.Forms.Label label1;
    }
}