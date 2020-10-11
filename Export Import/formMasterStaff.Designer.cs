namespace Export_Import
{
    partial class formMasterStaff
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
            this.btnInsert = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.id_item = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nama_item = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nama_jabatan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.username_staff = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tgl_lahir_stff = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_gudang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.no_hp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tgl_masuk = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnClose = new System.Windows.Forms.Button();
            this.groupFilter = new System.Windows.Forms.GroupBox();
            this.txtKeyword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbJabatan = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
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
            this.pnlAtas.Size = new System.Drawing.Size(1904, 85);
            this.pnlAtas.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(189, 59);
            this.label1.TabIndex = 0;
            this.label1.Text = "List Staff";
            // 
            // pnlBawah
            // 
            this.pnlBawah.BackColor = System.Drawing.SystemColors.Control;
            this.pnlBawah.Controls.Add(this.btnDelete);
            this.pnlBawah.Controls.Add(this.btnUpdate);
            this.pnlBawah.Controls.Add(this.btnInsert);
            this.pnlBawah.Controls.Add(this.dataGridView);
            this.pnlBawah.Controls.Add(this.btnClose);
            this.pnlBawah.Controls.Add(this.groupFilter);
            this.pnlBawah.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBawah.Location = new System.Drawing.Point(0, 91);
            this.pnlBawah.Name = "pnlBawah";
            this.pnlBawah.Size = new System.Drawing.Size(1904, 950);
            this.pnlBawah.TabIndex = 3;
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
            // btnInsert
            // 
            this.btnInsert.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInsert.Location = new System.Drawing.Point(438, 119);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(85, 30);
            this.btnInsert.TabIndex = 4;
            this.btnInsert.Text = "Insert";
            this.btnInsert.UseVisualStyleBackColor = true;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_item,
            this.nama_item,
            this.nama_jabatan,
            this.username_staff,
            this.tgl_lahir_stff,
            this.id_gudang,
            this.no_hp,
            this.tgl_masuk,
            this.email});
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridView.Location = new System.Drawing.Point(0, 155);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(1904, 795);
            this.dataGridView.TabIndex = 3;
            this.dataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellClick);
            // 
            // id_item
            // 
            this.id_item.DataPropertyName = "id_staff";
            this.id_item.Frozen = true;
            this.id_item.HeaderText = "ID";
            this.id_item.Name = "id_item";
            this.id_item.ReadOnly = true;
            // 
            // nama_item
            // 
            this.nama_item.DataPropertyName = "nama_staff";
            this.nama_item.Frozen = true;
            this.nama_item.HeaderText = "Nama";
            this.nama_item.Name = "nama_item";
            this.nama_item.ReadOnly = true;
            this.nama_item.Width = 250;
            // 
            // nama_jabatan
            // 
            this.nama_jabatan.DataPropertyName = "nm_jabatan";
            this.nama_jabatan.Frozen = true;
            this.nama_jabatan.HeaderText = "Jabatan";
            this.nama_jabatan.Name = "nama_jabatan";
            this.nama_jabatan.ReadOnly = true;
            this.nama_jabatan.Width = 150;
            // 
            // username_staff
            // 
            this.username_staff.DataPropertyName = "username_staff";
            this.username_staff.Frozen = true;
            this.username_staff.HeaderText = "Username";
            this.username_staff.Name = "username_staff";
            this.username_staff.ReadOnly = true;
            this.username_staff.Width = 150;
            // 
            // tgl_lahir_stff
            // 
            this.tgl_lahir_stff.DataPropertyName = "tgl_lahir_staff";
            this.tgl_lahir_stff.Frozen = true;
            this.tgl_lahir_stff.HeaderText = "Tanggal Lahir";
            this.tgl_lahir_stff.Name = "tgl_lahir_stff";
            this.tgl_lahir_stff.ReadOnly = true;
            this.tgl_lahir_stff.Width = 225;
            // 
            // id_gudang
            // 
            this.id_gudang.DataPropertyName = "alamat_staff";
            this.id_gudang.Frozen = true;
            this.id_gudang.HeaderText = "Alamat";
            this.id_gudang.Name = "id_gudang";
            this.id_gudang.ReadOnly = true;
            this.id_gudang.Width = 360;
            // 
            // no_hp
            // 
            this.no_hp.DataPropertyName = "nomer_telp_staff";
            this.no_hp.Frozen = true;
            this.no_hp.HeaderText = "No HP";
            this.no_hp.Name = "no_hp";
            this.no_hp.ReadOnly = true;
            this.no_hp.Width = 150;
            // 
            // tgl_masuk
            // 
            this.tgl_masuk.DataPropertyName = "tgl_masuk";
            this.tgl_masuk.Frozen = true;
            this.tgl_masuk.HeaderText = "Tanggal Masuk";
            this.tgl_masuk.Name = "tgl_masuk";
            this.tgl_masuk.ReadOnly = true;
            this.tgl_masuk.Width = 225;
            // 
            // email
            // 
            this.email.DataPropertyName = "email_staff";
            this.email.Frozen = true;
            this.email.HeaderText = "Email";
            this.email.Name = "email";
            this.email.ReadOnly = true;
            this.email.Width = 250;
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
            this.groupFilter.Controls.Add(this.label3);
            this.groupFilter.Controls.Add(this.cbJabatan);
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
            // cbJabatan
            // 
            this.cbJabatan.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbJabatan.FormattingEnabled = true;
            this.cbJabatan.Location = new System.Drawing.Point(93, 64);
            this.cbJabatan.Name = "cbJabatan";
            this.cbJabatan.Size = new System.Drawing.Size(200, 27);
            this.cbJabatan.TabIndex = 2;
            this.cbJabatan.DropDownClosed += new System.EventHandler(this.cbJabatan_DropDownClosed);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(20, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 19);
            this.label3.TabIndex = 3;
            this.label3.Text = "Jabatan :";
            // 
            // formMasterStaff
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.pnlBawah);
            this.Controls.Add(this.pnlAtas);
            this.Name = "formMasterStaff";
            this.Text = "formMasterUser";
            this.Load += new System.EventHandler(this.formMasterUser_Load);
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlBawah;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox groupFilter;
        public System.Windows.Forms.TextBox txtKeyword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_item;
        private System.Windows.Forms.DataGridViewTextBoxColumn nama_item;
        private System.Windows.Forms.DataGridViewTextBoxColumn nama_jabatan;
        private System.Windows.Forms.DataGridViewTextBoxColumn username_staff;
        private System.Windows.Forms.DataGridViewTextBoxColumn tgl_lahir_stff;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_gudang;
        private System.Windows.Forms.DataGridViewTextBoxColumn no_hp;
        private System.Windows.Forms.DataGridViewTextBoxColumn tgl_masuk;
        private System.Windows.Forms.DataGridViewTextBoxColumn email;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbJabatan;
    }
}