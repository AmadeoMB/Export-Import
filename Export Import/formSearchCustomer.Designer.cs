namespace Export_Import
{
    partial class formSearchCustomer
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtKeyword = new System.Windows.Forms.TextBox();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.id_customer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nama_customer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.alamat_customer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.no_hp_customer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.email_customer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnGet = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Keyword : ";
            // 
            // txtKeyword
            // 
            this.txtKeyword.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKeyword.Location = new System.Drawing.Point(95, 17);
            this.txtKeyword.Name = "txtKeyword";
            this.txtKeyword.Size = new System.Drawing.Size(200, 27);
            this.txtKeyword.TabIndex = 1;
            this.txtKeyword.TextChanged += new System.EventHandler(this.txtKeyword_TextChanged);
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_customer,
            this.nama_customer,
            this.alamat_customer,
            this.no_hp_customer,
            this.email_customer});
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridView.Location = new System.Drawing.Point(0, 66);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(767, 116);
            this.dataGridView.TabIndex = 2;
            this.dataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellClick);
            // 
            // id_customer
            // 
            this.id_customer.DataPropertyName = "id_customer";
            this.id_customer.Frozen = true;
            this.id_customer.HeaderText = "ID";
            this.id_customer.Name = "id_customer";
            this.id_customer.ReadOnly = true;
            this.id_customer.Width = 75;
            // 
            // nama_customer
            // 
            this.nama_customer.DataPropertyName = "nama_customer";
            this.nama_customer.Frozen = true;
            this.nama_customer.HeaderText = "Nama";
            this.nama_customer.Name = "nama_customer";
            this.nama_customer.ReadOnly = true;
            this.nama_customer.Width = 175;
            // 
            // alamat_customer
            // 
            this.alamat_customer.DataPropertyName = "alamat_customer";
            this.alamat_customer.Frozen = true;
            this.alamat_customer.HeaderText = "Alamat";
            this.alamat_customer.Name = "alamat_customer";
            this.alamat_customer.ReadOnly = true;
            this.alamat_customer.Width = 200;
            // 
            // no_hp_customer
            // 
            this.no_hp_customer.DataPropertyName = "no_telp_customer";
            this.no_hp_customer.Frozen = true;
            this.no_hp_customer.HeaderText = "Nomer HP";
            this.no_hp_customer.Name = "no_hp_customer";
            this.no_hp_customer.ReadOnly = true;
            // 
            // email_customer
            // 
            this.email_customer.DataPropertyName = "email_customer";
            this.email_customer.Frozen = true;
            this.email_customer.HeaderText = "Email";
            this.email_customer.Name = "email_customer";
            this.email_customer.ReadOnly = true;
            this.email_customer.Width = 175;
            // 
            // btnGet
            // 
            this.btnGet.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGet.Location = new System.Drawing.Point(680, 12);
            this.btnGet.Name = "btnGet";
            this.btnGet.Size = new System.Drawing.Size(75, 35);
            this.btnGet.TabIndex = 3;
            this.btnGet.Text = "Get";
            this.btnGet.UseVisualStyleBackColor = true;
            this.btnGet.Click += new System.EventHandler(this.btnGet_Click);
            // 
            // formSearchCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(767, 182);
            this.Controls.Add(this.btnGet);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.txtKeyword);
            this.Controls.Add(this.label1);
            this.Name = "formSearchCustomer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Search Customer";
            this.Load += new System.EventHandler(this.formSearchCustomer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtKeyword;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button btnGet;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_customer;
        private System.Windows.Forms.DataGridViewTextBoxColumn nama_customer;
        private System.Windows.Forms.DataGridViewTextBoxColumn alamat_customer;
        private System.Windows.Forms.DataGridViewTextBoxColumn no_hp_customer;
        private System.Windows.Forms.DataGridViewTextBoxColumn email_customer;
    }
}