namespace Export_Import
{
    partial class formDeliveryOrder
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
            this.pnlAtas = new System.Windows.Forms.GroupBox();
            this.cbShipVia = new System.Windows.Forms.ComboBox();
            this.cbNamaSales = new System.Windows.Forms.ComboBox();
            this.cbCreditTerm = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.dateDO = new System.Windows.Forms.DateTimePicker();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtIdDO = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbGudang = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtAlamatCust = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNamaCust = new System.Windows.Forms.TextBox();
            this.cbIdCust = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlTotal = new System.Windows.Forms.GroupBox();
            this.txtRate = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.cbCurrency = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.txtTotalConvert = new System.Windows.Forms.TextBox();
            this.txtNetTotal = new System.Windows.Forms.TextBox();
            this.pnlBawah = new System.Windows.Forms.GroupBox();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnPreview = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.pnlTengah = new System.Windows.Forms.GroupBox();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID_Sales = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nama = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.satuan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.harga = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.berat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jenis_ppn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.discount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subtotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSearchSO = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.txtTotalPPN = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.pnlAtas.SuspendLayout();
            this.pnlTotal.SuspendLayout();
            this.pnlBawah.SuspendLayout();
            this.pnlTengah.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlAtas
            // 
            this.pnlAtas.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.pnlAtas.Controls.Add(this.cbShipVia);
            this.pnlAtas.Controls.Add(this.cbNamaSales);
            this.pnlAtas.Controls.Add(this.cbCreditTerm);
            this.pnlAtas.Controls.Add(this.label13);
            this.pnlAtas.Controls.Add(this.dateDO);
            this.pnlAtas.Controls.Add(this.label12);
            this.pnlAtas.Controls.Add(this.label11);
            this.pnlAtas.Controls.Add(this.label10);
            this.pnlAtas.Controls.Add(this.txtIdDO);
            this.pnlAtas.Controls.Add(this.label9);
            this.pnlAtas.Controls.Add(this.label8);
            this.pnlAtas.Controls.Add(this.label7);
            this.pnlAtas.Controls.Add(this.label6);
            this.pnlAtas.Controls.Add(this.label5);
            this.pnlAtas.Controls.Add(this.cbGudang);
            this.pnlAtas.Controls.Add(this.label4);
            this.pnlAtas.Controls.Add(this.txtAlamatCust);
            this.pnlAtas.Controls.Add(this.label3);
            this.pnlAtas.Controls.Add(this.txtNamaCust);
            this.pnlAtas.Controls.Add(this.cbIdCust);
            this.pnlAtas.Controls.Add(this.label2);
            this.pnlAtas.Controls.Add(this.label1);
            this.pnlAtas.Location = new System.Drawing.Point(1, 2);
            this.pnlAtas.Name = "pnlAtas";
            this.pnlAtas.Size = new System.Drawing.Size(1354, 200);
            this.pnlAtas.TabIndex = 2;
            this.pnlAtas.TabStop = false;
            this.pnlAtas.Enter += new System.EventHandler(this.pnlAtas_Enter);
            // 
            // cbShipVia
            // 
            this.cbShipVia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbShipVia.Enabled = false;
            this.cbShipVia.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbShipVia.FormattingEnabled = true;
            this.cbShipVia.Location = new System.Drawing.Point(1137, 139);
            this.cbShipVia.Name = "cbShipVia";
            this.cbShipVia.Size = new System.Drawing.Size(200, 27);
            this.cbShipVia.TabIndex = 23;
            // 
            // cbNamaSales
            // 
            this.cbNamaSales.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbNamaSales.Enabled = false;
            this.cbNamaSales.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbNamaSales.FormattingEnabled = true;
            this.cbNamaSales.Location = new System.Drawing.Point(1137, 110);
            this.cbNamaSales.Name = "cbNamaSales";
            this.cbNamaSales.Size = new System.Drawing.Size(200, 27);
            this.cbNamaSales.TabIndex = 22;
            // 
            // cbCreditTerm
            // 
            this.cbCreditTerm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCreditTerm.Enabled = false;
            this.cbCreditTerm.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCreditTerm.FormattingEnabled = true;
            this.cbCreditTerm.Items.AddRange(new object[] {
            "Cash",
            "7 Days",
            "14 Days",
            "21 Days",
            "30 Days",
            "60 Days"});
            this.cbCreditTerm.Location = new System.Drawing.Point(1137, 81);
            this.cbCreditTerm.Name = "cbCreditTerm";
            this.cbCreditTerm.Size = new System.Drawing.Size(200, 27);
            this.cbCreditTerm.TabIndex = 21;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(1008, 142);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(61, 19);
            this.label13.TabIndex = 19;
            this.label13.Text = "Ship Via";
            // 
            // dateDO
            // 
            this.dateDO.Enabled = false;
            this.dateDO.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateDO.Location = new System.Drawing.Point(1137, 51);
            this.dateDO.Name = "dateDO";
            this.dateDO.Size = new System.Drawing.Size(200, 27);
            this.dateDO.TabIndex = 18;
            this.dateDO.Value = new System.DateTime(2020, 10, 26, 0, 0, 0, 0);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(984, 113);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(85, 19);
            this.label12.TabIndex = 17;
            this.label12.Text = "Nama Sales";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(985, 84);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(84, 19);
            this.label11.TabIndex = 16;
            this.label11.Text = "Credit Term";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(978, 57);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(91, 19);
            this.label10.TabIndex = 15;
            this.label10.Text = "Tanggal D/O";
            // 
            // txtIdDO
            // 
            this.txtIdDO.Enabled = false;
            this.txtIdDO.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdDO.Location = new System.Drawing.Point(1137, 21);
            this.txtIdDO.Name = "txtIdDO";
            this.txtIdDO.ReadOnly = true;
            this.txtIdDO.Size = new System.Drawing.Size(200, 27);
            this.txtIdDO.TabIndex = 14;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(986, 24);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(83, 19);
            this.label9.TabIndex = 13;
            this.label9.Text = "Nomer D/O";
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
            this.cbGudang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGudang.Enabled = false;
            this.cbGudang.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbGudang.FormattingEnabled = true;
            this.cbGudang.Location = new System.Drawing.Point(153, 166);
            this.cbGudang.Name = "cbGudang";
            this.cbGudang.Size = new System.Drawing.Size(251, 27);
            this.cbGudang.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(7, 168);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 19);
            this.label4.TabIndex = 6;
            this.label4.Text = "Dikirim dari";
            // 
            // txtAlamatCust
            // 
            this.txtAlamatCust.Enabled = false;
            this.txtAlamatCust.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAlamatCust.Location = new System.Drawing.Point(153, 78);
            this.txtAlamatCust.Multiline = true;
            this.txtAlamatCust.Name = "txtAlamatCust";
            this.txtAlamatCust.Size = new System.Drawing.Size(251, 79);
            this.txtAlamatCust.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 19);
            this.label3.TabIndex = 4;
            this.label3.Text = "Alamat";
            // 
            // txtNamaCust
            // 
            this.txtNamaCust.Enabled = false;
            this.txtNamaCust.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNamaCust.Location = new System.Drawing.Point(153, 48);
            this.txtNamaCust.Name = "txtNamaCust";
            this.txtNamaCust.Size = new System.Drawing.Size(251, 27);
            this.txtNamaCust.TabIndex = 3;
            // 
            // cbIdCust
            // 
            this.cbIdCust.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbIdCust.Enabled = false;
            this.cbIdCust.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbIdCust.FormattingEnabled = true;
            this.cbIdCust.Location = new System.Drawing.Point(153, 18);
            this.cbIdCust.Name = "cbIdCust";
            this.cbIdCust.Size = new System.Drawing.Size(251, 27);
            this.cbIdCust.TabIndex = 2;
            this.cbIdCust.SelectedIndexChanged += new System.EventHandler(this.cbIdCust_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(7, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nama";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Customer";
            // 
            // pnlTotal
            // 
            this.pnlTotal.Controls.Add(this.label16);
            this.pnlTotal.Controls.Add(this.txtTotal);
            this.pnlTotal.Controls.Add(this.label14);
            this.pnlTotal.Controls.Add(this.txtTotalPPN);
            this.pnlTotal.Controls.Add(this.txtRate);
            this.pnlTotal.Controls.Add(this.label20);
            this.pnlTotal.Controls.Add(this.label19);
            this.pnlTotal.Controls.Add(this.cbCurrency);
            this.pnlTotal.Controls.Add(this.label18);
            this.pnlTotal.Controls.Add(this.label17);
            this.pnlTotal.Controls.Add(this.txtTotalConvert);
            this.pnlTotal.Controls.Add(this.txtNetTotal);
            this.pnlTotal.Enabled = false;
            this.pnlTotal.Location = new System.Drawing.Point(0, 553);
            this.pnlTotal.Name = "pnlTotal";
            this.pnlTotal.Size = new System.Drawing.Size(1347, 140);
            this.pnlTotal.TabIndex = 9;
            this.pnlTotal.TabStop = false;
            // 
            // txtRate
            // 
            this.txtRate.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRate.Location = new System.Drawing.Point(944, 108);
            this.txtRate.Name = "txtRate";
            this.txtRate.Size = new System.Drawing.Size(117, 27);
            this.txtRate.TabIndex = 9;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(688, 111);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(66, 19);
            this.label20.TabIndex = 8;
            this.label20.Text = "Currency";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(897, 111);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(39, 19);
            this.label19.TabIndex = 7;
            this.label19.Text = "Rate";
            // 
            // cbCurrency
            // 
            this.cbCurrency.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCurrency.FormattingEnabled = true;
            this.cbCurrency.Location = new System.Drawing.Point(760, 108);
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
            // pnlBawah
            // 
            this.pnlBawah.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.pnlBawah.Controls.Add(this.btnBack);
            this.pnlBawah.Controls.Add(this.btnSave);
            this.pnlBawah.Controls.Add(this.btnPreview);
            this.pnlBawah.Location = new System.Drawing.Point(0, 693);
            this.pnlBawah.Name = "pnlBawah";
            this.pnlBawah.Size = new System.Drawing.Size(1347, 40);
            this.pnlBawah.TabIndex = 10;
            this.pnlBawah.TabStop = false;
            // 
            // btnBack
            // 
            this.btnBack.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.Location = new System.Drawing.Point(1260, 2);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(78, 34);
            this.btnBack.TabIndex = 7;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
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
            this.label15.Location = new System.Drawing.Point(637, 205);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(86, 23);
            this.label15.TabIndex = 8;
            this.label15.Text = "List Order";
            // 
            // pnlTengah
            // 
            this.pnlTengah.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.pnlTengah.Controls.Add(this.dataGridView);
            this.pnlTengah.Controls.Add(this.btnSearchSO);
            this.pnlTengah.Location = new System.Drawing.Point(0, 231);
            this.pnlTengah.Name = "pnlTengah";
            this.pnlTengah.Size = new System.Drawing.Size(1353, 316);
            this.pnlTengah.TabIndex = 7;
            this.pnlTengah.TabStop = false;
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.ID_Sales,
            this.nama,
            this.qty,
            this.satuan,
            this.harga,
            this.berat,
            this.jenis_ppn,
            this.discount,
            this.subtotal});
            this.dataGridView.Location = new System.Drawing.Point(6, 46);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(1341, 265);
            this.dataGridView.TabIndex = 8;
            // 
            // ID
            // 
            this.ID.DataPropertyName = "id_item";
            this.ID.Frozen = true;
            this.ID.HeaderText = "ID Item";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Width = 75;
            // 
            // ID_Sales
            // 
            this.ID_Sales.DataPropertyName = "id_sales_order";
            this.ID_Sales.Frozen = true;
            this.ID_Sales.HeaderText = "ID S/O";
            this.ID_Sales.Name = "ID_Sales";
            this.ID_Sales.ReadOnly = true;
            this.ID_Sales.Width = 150;
            // 
            // nama
            // 
            this.nama.DataPropertyName = "nama_item";
            this.nama.Frozen = true;
            this.nama.HeaderText = "Nama Item";
            this.nama.Name = "nama";
            this.nama.ReadOnly = true;
            this.nama.Width = 150;
            // 
            // qty
            // 
            this.qty.DataPropertyName = "qty_item";
            this.qty.Frozen = true;
            this.qty.HeaderText = "Qty Item";
            this.qty.Name = "qty";
            this.qty.ReadOnly = true;
            // 
            // satuan
            // 
            this.satuan.DataPropertyName = "jenis_satuan";
            this.satuan.Frozen = true;
            this.satuan.HeaderText = "Satuan";
            this.satuan.Name = "satuan";
            this.satuan.ReadOnly = true;
            this.satuan.Width = 75;
            // 
            // harga
            // 
            this.harga.DataPropertyName = "harga_satuan";
            this.harga.Frozen = true;
            this.harga.HeaderText = "Harga";
            this.harga.Name = "harga";
            this.harga.ReadOnly = true;
            this.harga.Width = 150;
            // 
            // berat
            // 
            this.berat.DataPropertyName = "berat_total";
            this.berat.Frozen = true;
            this.berat.HeaderText = "Berat Total";
            this.berat.Name = "berat";
            this.berat.ReadOnly = true;
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
            this.subtotal.Width = 170;
            // 
            // btnSearchSO
            // 
            this.btnSearchSO.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchSO.Location = new System.Drawing.Point(1138, 10);
            this.btnSearchSO.Name = "btnSearchSO";
            this.btnSearchSO.Size = new System.Drawing.Size(200, 30);
            this.btnSearchSO.TabIndex = 7;
            this.btnSearchSO.Text = "Search S/O";
            this.btnSearchSO.UseVisualStyleBackColor = true;
            this.btnSearchSO.Click += new System.EventHandler(this.btnSearchSO_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(1065, 45);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(110, 19);
            this.label14.TabIndex = 11;
            this.label14.Text = "Total PPN (EXC)";
            // 
            // txtTotalPPN
            // 
            this.txtTotalPPN.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalPPN.Location = new System.Drawing.Point(1181, 42);
            this.txtTotalPPN.Name = "txtTotalPPN";
            this.txtTotalPPN.Size = new System.Drawing.Size(157, 27);
            this.txtTotalPPN.TabIndex = 10;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(1134, 12);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(41, 19);
            this.label16.TabIndex = 13;
            this.label16.Text = "Total";
            // 
            // txtTotal
            // 
            this.txtTotal.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotal.Location = new System.Drawing.Point(1181, 9);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(157, 27);
            this.txtTotal.TabIndex = 12;
            // 
            // formDeliveryOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1350, 729);
            this.Controls.Add(this.pnlTotal);
            this.Controls.Add(this.pnlBawah);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.pnlTengah);
            this.Controls.Add(this.pnlAtas);
            this.Name = "formDeliveryOrder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "formDeliveryOrder";
            this.Load += new System.EventHandler(this.formDeliveryOrder_Load);
            this.pnlAtas.ResumeLayout(false);
            this.pnlAtas.PerformLayout();
            this.pnlTotal.ResumeLayout(false);
            this.pnlTotal.PerformLayout();
            this.pnlBawah.ResumeLayout(false);
            this.pnlTengah.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox pnlAtas;
        private System.Windows.Forms.ComboBox cbShipVia;
        private System.Windows.Forms.ComboBox cbNamaSales;
        private System.Windows.Forms.ComboBox cbCreditTerm;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DateTimePicker dateDO;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtIdDO;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbGudang;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtAlamatCust;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNamaCust;
        private System.Windows.Forms.ComboBox cbIdCust;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox pnlTotal;
        private System.Windows.Forms.TextBox txtRate;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.ComboBox cbCurrency;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtTotalConvert;
        private System.Windows.Forms.TextBox txtNetTotal;
        private System.Windows.Forms.GroupBox pnlBawah;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.GroupBox pnlTengah;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button btnSearchSO;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID_Sales;
        private System.Windows.Forms.DataGridViewTextBoxColumn nama;
        private System.Windows.Forms.DataGridViewTextBoxColumn qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn satuan;
        private System.Windows.Forms.DataGridViewTextBoxColumn harga;
        private System.Windows.Forms.DataGridViewTextBoxColumn berat;
        private System.Windows.Forms.DataGridViewTextBoxColumn jenis_ppn;
        private System.Windows.Forms.DataGridViewTextBoxColumn discount;
        private System.Windows.Forms.DataGridViewTextBoxColumn subtotal;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtTotalPPN;
    }
}