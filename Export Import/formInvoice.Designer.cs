namespace Export_Import
{
    partial class formInvoice
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.txtRate = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.cbCurrency = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.txtTotalConvert = new System.Windows.Forms.TextBox();
            this.txtNetTotal = new System.Windows.Forms.TextBox();
            this.txtTotalPPN = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnPreview = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.id_item = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_so = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nama_item = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qty_item = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.satuan_item = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.harga_item = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.berat_total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jenis_ppn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.discount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subtotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnGetSO = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbShipVia = new System.Windows.Forms.ComboBox();
            this.cbStaff = new System.Windows.Forms.ComboBox();
            this.cbCreditTerm = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.dateInvoice = new System.Windows.Forms.DateTimePicker();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtIdInvoice = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbGudang = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtAlamatCustomer = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNamaCustomer = new System.Windows.Forms.TextBox();
            this.cbIdCustomer = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbNegara = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.groupBox3.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtTotal);
            this.groupBox3.Controls.Add(this.label21);
            this.groupBox3.Controls.Add(this.txtRate);
            this.groupBox3.Controls.Add(this.label20);
            this.groupBox3.Controls.Add(this.label19);
            this.groupBox3.Controls.Add(this.cbCurrency);
            this.groupBox3.Controls.Add(this.label18);
            this.groupBox3.Controls.Add(this.label17);
            this.groupBox3.Controls.Add(this.txtTotalConvert);
            this.groupBox3.Controls.Add(this.txtNetTotal);
            this.groupBox3.Controls.Add(this.txtTotalPPN);
            this.groupBox3.Controls.Add(this.label16);
            this.groupBox3.Enabled = false;
            this.groupBox3.Location = new System.Drawing.Point(-2, 550);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1347, 140);
            this.groupBox3.TabIndex = 14;
            this.groupBox3.TabStop = false;
            // 
            // txtTotal
            // 
            this.txtTotal.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotal.Location = new System.Drawing.Point(1181, 9);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(157, 27);
            this.txtTotal.TabIndex = 11;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(1134, 12);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(41, 19);
            this.label21.TabIndex = 10;
            this.label21.Text = "Total";
            // 
            // txtRate
            // 
            this.txtRate.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRate.Location = new System.Drawing.Point(932, 108);
            this.txtRate.Name = "txtRate";
            this.txtRate.Size = new System.Drawing.Size(131, 27);
            this.txtRate.TabIndex = 9;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(678, 111);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(66, 19);
            this.label20.TabIndex = 8;
            this.label20.Text = "Currency";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(887, 111);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(39, 19);
            this.label19.TabIndex = 7;
            this.label19.Text = "Rate";
            // 
            // cbCurrency
            // 
            this.cbCurrency.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCurrency.FormattingEnabled = true;
            this.cbCurrency.Location = new System.Drawing.Point(750, 108);
            this.cbCurrency.Name = "cbCurrency";
            this.cbCurrency.Size = new System.Drawing.Size(131, 27);
            this.cbCurrency.TabIndex = 6;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(1069, 111);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(106, 19);
            this.label18.TabIndex = 5;
            this.label18.Text = "Local Net Total";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(1107, 78);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(68, 19);
            this.label17.TabIndex = 4;
            this.label17.Text = "Net Total";
            // 
            // txtTotalConvert
            // 
            this.txtTotalConvert.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalConvert.Location = new System.Drawing.Point(1181, 108);
            this.txtTotalConvert.Name = "txtTotalConvert";
            this.txtTotalConvert.Size = new System.Drawing.Size(157, 27);
            this.txtTotalConvert.TabIndex = 3;
            // 
            // txtNetTotal
            // 
            this.txtNetTotal.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNetTotal.Location = new System.Drawing.Point(1181, 75);
            this.txtNetTotal.Name = "txtNetTotal";
            this.txtNetTotal.Size = new System.Drawing.Size(157, 27);
            this.txtNetTotal.TabIndex = 2;
            // 
            // txtTotalPPN
            // 
            this.txtTotalPPN.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalPPN.Location = new System.Drawing.Point(1181, 42);
            this.txtTotalPPN.Name = "txtTotalPPN";
            this.txtTotalPPN.Size = new System.Drawing.Size(157, 27);
            this.txtTotalPPN.TabIndex = 1;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(1069, 45);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(110, 19);
            this.label16.TabIndex = 0;
            this.label16.Text = "Total PPN (EXC)";
            // 
            // groupBox5
            // 
            this.groupBox5.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.groupBox5.Controls.Add(this.btnCancel);
            this.groupBox5.Controls.Add(this.btnSave);
            this.groupBox5.Controls.Add(this.btnPreview);
            this.groupBox5.Location = new System.Drawing.Point(-2, 690);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(1347, 40);
            this.groupBox5.TabIndex = 15;
            this.groupBox5.TabStop = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(1260, 2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(78, 34);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(1086, 2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(78, 34);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnPreview
            // 
            this.btnPreview.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPreview.Location = new System.Drawing.Point(1170, 2);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(84, 34);
            this.btnPreview.TabIndex = 5;
            this.btnPreview.Text = "Preview";
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(630, 201);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(86, 23);
            this.label15.TabIndex = 13;
            this.label15.Text = "List Order";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.groupBox2.Controls.Add(this.dataGridView);
            this.groupBox2.Controls.Add(this.btnGetSO);
            this.groupBox2.Location = new System.Drawing.Point(-2, 227);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1353, 317);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_item,
            this.id_so,
            this.nama_item,
            this.qty_item,
            this.satuan_item,
            this.harga_item,
            this.berat_total,
            this.jenis_ppn,
            this.discount,
            this.subtotal});
            this.dataGridView.Location = new System.Drawing.Point(6, 46);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(1341, 265);
            this.dataGridView.TabIndex = 8;
            // 
            // id_item
            // 
            this.id_item.DataPropertyName = "id_item";
            this.id_item.Frozen = true;
            this.id_item.HeaderText = "ID Item";
            this.id_item.Name = "id_item";
            this.id_item.ReadOnly = true;
            // 
            // id_so
            // 
            this.id_so.DataPropertyName = "id_sales_order";
            this.id_so.Frozen = true;
            this.id_so.HeaderText = "ID S/O";
            this.id_so.Name = "id_so";
            this.id_so.ReadOnly = true;
            // 
            // nama_item
            // 
            this.nama_item.DataPropertyName = "nama_item";
            this.nama_item.Frozen = true;
            this.nama_item.HeaderText = "Nama Item";
            this.nama_item.Name = "nama_item";
            this.nama_item.ReadOnly = true;
            // 
            // qty_item
            // 
            this.qty_item.DataPropertyName = "qty_item";
            this.qty_item.Frozen = true;
            this.qty_item.HeaderText = "QTY Item";
            this.qty_item.Name = "qty_item";
            this.qty_item.ReadOnly = true;
            // 
            // satuan_item
            // 
            this.satuan_item.DataPropertyName = "jenis_satuan";
            this.satuan_item.Frozen = true;
            this.satuan_item.HeaderText = "Satuan Item";
            this.satuan_item.Name = "satuan_item";
            this.satuan_item.ReadOnly = true;
            // 
            // harga_item
            // 
            this.harga_item.DataPropertyName = "harga_satuan";
            this.harga_item.Frozen = true;
            this.harga_item.HeaderText = "Harga Item";
            this.harga_item.Name = "harga_item";
            this.harga_item.ReadOnly = true;
            // 
            // berat_total
            // 
            this.berat_total.DataPropertyName = "berat_total";
            this.berat_total.Frozen = true;
            this.berat_total.HeaderText = "Berat Total";
            this.berat_total.Name = "berat_total";
            this.berat_total.ReadOnly = true;
            // 
            // jenis_ppn
            // 
            this.jenis_ppn.DataPropertyName = "jenis_ppn";
            this.jenis_ppn.Frozen = true;
            this.jenis_ppn.HeaderText = "Jenis PPN";
            this.jenis_ppn.Name = "jenis_ppn";
            this.jenis_ppn.ReadOnly = true;
            // 
            // discount
            // 
            this.discount.DataPropertyName = "discount";
            this.discount.Frozen = true;
            this.discount.HeaderText = "Discount";
            this.discount.Name = "discount";
            this.discount.ReadOnly = true;
            // 
            // subtotal
            // 
            this.subtotal.DataPropertyName = "subtotal";
            this.subtotal.Frozen = true;
            this.subtotal.HeaderText = "Subtotal";
            this.subtotal.Name = "subtotal";
            this.subtotal.ReadOnly = true;
            // 
            // btnGetSO
            // 
            this.btnGetSO.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGetSO.Location = new System.Drawing.Point(1181, 10);
            this.btnGetSO.Name = "btnGetSO";
            this.btnGetSO.Size = new System.Drawing.Size(157, 30);
            this.btnGetSO.TabIndex = 0;
            this.btnGetSO.Text = "Search DO";
            this.btnGetSO.UseVisualStyleBackColor = true;
            this.btnGetSO.Click += new System.EventHandler(this.btnGetSO_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.groupBox1.Controls.Add(this.cbNegara);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.cbShipVia);
            this.groupBox1.Controls.Add(this.cbStaff);
            this.groupBox1.Controls.Add(this.cbCreditTerm);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.dateInvoice);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.txtIdInvoice);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cbGudang);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtAlamatCustomer);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtNamaCustomer);
            this.groupBox1.Controls.Add(this.cbIdCustomer);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Enabled = false;
            this.groupBox1.Location = new System.Drawing.Point(-1, -1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1354, 199);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // cbShipVia
            // 
            this.cbShipVia.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbShipVia.FormattingEnabled = true;
            this.cbShipVia.Location = new System.Drawing.Point(1137, 131);
            this.cbShipVia.Name = "cbShipVia";
            this.cbShipVia.Size = new System.Drawing.Size(200, 27);
            this.cbShipVia.TabIndex = 23;
            // 
            // cbStaff
            // 
            this.cbStaff.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbStaff.FormattingEnabled = true;
            this.cbStaff.Location = new System.Drawing.Point(1137, 102);
            this.cbStaff.Name = "cbStaff";
            this.cbStaff.Size = new System.Drawing.Size(200, 27);
            this.cbStaff.TabIndex = 22;
            // 
            // cbCreditTerm
            // 
            this.cbCreditTerm.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCreditTerm.FormattingEnabled = true;
            this.cbCreditTerm.Location = new System.Drawing.Point(1137, 73);
            this.cbCreditTerm.Name = "cbCreditTerm";
            this.cbCreditTerm.Size = new System.Drawing.Size(200, 27);
            this.cbCreditTerm.TabIndex = 21;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(976, 134);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(61, 19);
            this.label13.TabIndex = 19;
            this.label13.Text = "Ship Via";
            // 
            // dateInvoice
            // 
            this.dateInvoice.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateInvoice.Location = new System.Drawing.Point(1137, 43);
            this.dateInvoice.Name = "dateInvoice";
            this.dateInvoice.Size = new System.Drawing.Size(200, 27);
            this.dateInvoice.TabIndex = 18;
            this.dateInvoice.Value = new System.DateTime(2020, 9, 28, 0, 0, 0, 0);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(976, 104);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(50, 19);
            this.label12.TabIndex = 17;
            this.label12.Text = "Admin";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(976, 76);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(84, 19);
            this.label11.TabIndex = 16;
            this.label11.Text = "Credit Term";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(977, 49);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(40, 19);
            this.label10.TabIndex = 15;
            this.label10.Text = "Date";
            // 
            // txtIdInvoice
            // 
            this.txtIdInvoice.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdInvoice.Location = new System.Drawing.Point(1137, 11);
            this.txtIdInvoice.Name = "txtIdInvoice";
            this.txtIdInvoice.ReadOnly = true;
            this.txtIdInvoice.Size = new System.Drawing.Size(200, 27);
            this.txtIdInvoice.TabIndex = 14;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(976, 16);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 19);
            this.label9.TabIndex = 13;
            this.label9.Text = "Invoice No";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(140, 172);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(10, 13);
            this.label8.TabIndex = 11;
            this.label8.Text = ":";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(137, 85);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(10, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = ":";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(137, 53);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(10, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = ":";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(137, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(10, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = ":";
            // 
            // cbGudang
            // 
            this.cbGudang.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbGudang.FormattingEnabled = true;
            this.cbGudang.Location = new System.Drawing.Point(153, 166);
            this.cbGudang.Name = "cbGudang";
            this.cbGudang.Size = new System.Drawing.Size(200, 27);
            this.cbGudang.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(7, 168);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(127, 19);
            this.label4.TabIndex = 6;
            this.label4.Text = "Purchase Location";
            // 
            // txtAlamatCustomer
            // 
            this.txtAlamatCustomer.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAlamatCustomer.Location = new System.Drawing.Point(153, 78);
            this.txtAlamatCustomer.Multiline = true;
            this.txtAlamatCustomer.Name = "txtAlamatCustomer";
            this.txtAlamatCustomer.Size = new System.Drawing.Size(200, 79);
            this.txtAlamatCustomer.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 19);
            this.label3.TabIndex = 4;
            this.label3.Text = "Address";
            // 
            // txtNamaCustomer
            // 
            this.txtNamaCustomer.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNamaCustomer.Location = new System.Drawing.Point(153, 48);
            this.txtNamaCustomer.Name = "txtNamaCustomer";
            this.txtNamaCustomer.Size = new System.Drawing.Size(200, 27);
            this.txtNamaCustomer.TabIndex = 3;
            // 
            // cbIdCustomer
            // 
            this.cbIdCustomer.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbIdCustomer.FormattingEnabled = true;
            this.cbIdCustomer.Location = new System.Drawing.Point(153, 18);
            this.cbIdCustomer.Name = "cbIdCustomer";
            this.cbIdCustomer.Size = new System.Drawing.Size(200, 27);
            this.cbIdCustomer.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(7, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Supplier";
            // 
            // cbNegara
            // 
            this.cbNegara.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbNegara.FormattingEnabled = true;
            this.cbNegara.Location = new System.Drawing.Point(1137, 165);
            this.cbNegara.Name = "cbNegara";
            this.cbNegara.Size = new System.Drawing.Size(200, 27);
            this.cbNegara.TabIndex = 25;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(976, 168);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(103, 19);
            this.label14.TabIndex = 24;
            this.label14.Text = "Negara Tujuan";
            // 
            // formInvoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1350, 729);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "formInvoice";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "New Invoice";
            this.Load += new System.EventHandler(this.formInvoice_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtRate;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.ComboBox cbCurrency;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtTotalConvert;
        private System.Windows.Forms.TextBox txtNetTotal;
        private System.Windows.Forms.TextBox txtTotalPPN;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button btnGetSO;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbShipVia;
        private System.Windows.Forms.ComboBox cbStaff;
        private System.Windows.Forms.ComboBox cbCreditTerm;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DateTimePicker dateInvoice;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtIdInvoice;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbGudang;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtAlamatCustomer;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNamaCustomer;
        private System.Windows.Forms.ComboBox cbIdCustomer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_item;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_so;
        private System.Windows.Forms.DataGridViewTextBoxColumn nama_item;
        private System.Windows.Forms.DataGridViewTextBoxColumn qty_item;
        private System.Windows.Forms.DataGridViewTextBoxColumn satuan_item;
        private System.Windows.Forms.DataGridViewTextBoxColumn harga_item;
        private System.Windows.Forms.DataGridViewTextBoxColumn berat_total;
        private System.Windows.Forms.DataGridViewTextBoxColumn jenis_ppn;
        private System.Windows.Forms.DataGridViewTextBoxColumn discount;
        private System.Windows.Forms.DataGridViewTextBoxColumn subtotal;
        private System.Windows.Forms.ComboBox cbNegara;
        private System.Windows.Forms.Label label14;
    }
}