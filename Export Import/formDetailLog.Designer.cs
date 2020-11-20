namespace Export_Import
{
    partial class formDetailLog
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
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblIdItem = new System.Windows.Forms.Label();
            this.lblNamaItem = new System.Windows.Forms.Label();
            this.lblHargaItem = new System.Windows.Forms.Label();
            this.date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipe_dokumen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_dokumen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Old_Stock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.New_Stock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Balance_Qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.date,
            this.tipe_dokumen,
            this.id_dokumen,
            this.Old_Stock,
            this.qty,
            this.New_Stock,
            this.Balance_Qty});
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridView.Location = new System.Drawing.Point(0, 64);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(1026, 281);
            this.dataGridView.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "Id Item : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(401, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nama Item : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(822, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 19);
            this.label3.TabIndex = 3;
            this.label3.Text = "Harga Item : ";
            // 
            // lblIdItem
            // 
            this.lblIdItem.AutoSize = true;
            this.lblIdItem.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIdItem.Location = new System.Drawing.Point(84, 25);
            this.lblIdItem.Name = "lblIdItem";
            this.lblIdItem.Size = new System.Drawing.Size(66, 19);
            this.lblIdItem.TabIndex = 4;
            this.lblIdItem.Text = "lblIdItem";
            // 
            // lblNamaItem
            // 
            this.lblNamaItem.AutoSize = true;
            this.lblNamaItem.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNamaItem.Location = new System.Drawing.Point(499, 25);
            this.lblNamaItem.Name = "lblNamaItem";
            this.lblNamaItem.Size = new System.Drawing.Size(92, 19);
            this.lblNamaItem.TabIndex = 5;
            this.lblNamaItem.Text = "lblNamaItem";
            // 
            // lblHargaItem
            // 
            this.lblHargaItem.AutoSize = true;
            this.lblHargaItem.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHargaItem.Location = new System.Drawing.Point(921, 25);
            this.lblHargaItem.Name = "lblHargaItem";
            this.lblHargaItem.Size = new System.Drawing.Size(93, 19);
            this.lblHargaItem.TabIndex = 6;
            this.lblHargaItem.Text = "lblHargaItem";
            // 
            // date
            // 
            this.date.DataPropertyName = "Tanggal";
            this.date.Frozen = true;
            this.date.HeaderText = "Tanggal";
            this.date.Name = "date";
            this.date.ReadOnly = true;
            this.date.Width = 125;
            // 
            // tipe_dokumen
            // 
            this.tipe_dokumen.DataPropertyName = "Tipe";
            this.tipe_dokumen.Frozen = true;
            this.tipe_dokumen.HeaderText = "Tipe Dokumen";
            this.tipe_dokumen.Name = "tipe_dokumen";
            this.tipe_dokumen.ReadOnly = true;
            this.tipe_dokumen.Width = 75;
            // 
            // id_dokumen
            // 
            this.id_dokumen.DataPropertyName = "Id";
            this.id_dokumen.Frozen = true;
            this.id_dokumen.HeaderText = "Id Dokumen";
            this.id_dokumen.Name = "id_dokumen";
            this.id_dokumen.ReadOnly = true;
            this.id_dokumen.Width = 125;
            // 
            // Old_Stock
            // 
            this.Old_Stock.DataPropertyName = "old";
            this.Old_Stock.Frozen = true;
            this.Old_Stock.HeaderText = "Old Stock";
            this.Old_Stock.Name = "Old_Stock";
            this.Old_Stock.ReadOnly = true;
            this.Old_Stock.Width = 150;
            // 
            // qty
            // 
            this.qty.DataPropertyName = "changes";
            this.qty.Frozen = true;
            this.qty.HeaderText = "Qty Change";
            this.qty.Name = "qty";
            this.qty.ReadOnly = true;
            this.qty.Width = 150;
            // 
            // New_Stock
            // 
            this.New_Stock.DataPropertyName = "new";
            this.New_Stock.Frozen = true;
            this.New_Stock.HeaderText = "New Stock";
            this.New_Stock.Name = "New_Stock";
            this.New_Stock.ReadOnly = true;
            this.New_Stock.Width = 150;
            // 
            // Balance_Qty
            // 
            this.Balance_Qty.DataPropertyName = "Balance";
            this.Balance_Qty.Frozen = true;
            this.Balance_Qty.HeaderText = "Balance Qty";
            this.Balance_Qty.Name = "Balance_Qty";
            this.Balance_Qty.ReadOnly = true;
            this.Balance_Qty.Width = 200;
            // 
            // formDetailLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1026, 345);
            this.Controls.Add(this.lblHargaItem);
            this.Controls.Add(this.lblNamaItem);
            this.Controls.Add(this.lblIdItem);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView);
            this.Name = "formDetailLog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Detail Log";
            this.Load += new System.EventHandler(this.formDetailLog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblIdItem;
        private System.Windows.Forms.Label lblNamaItem;
        private System.Windows.Forms.Label lblHargaItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn date;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipe_dokumen;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_dokumen;
        private System.Windows.Forms.DataGridViewTextBoxColumn Old_Stock;
        private System.Windows.Forms.DataGridViewTextBoxColumn qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn New_Stock;
        private System.Windows.Forms.DataGridViewTextBoxColumn Balance_Qty;
    }
}