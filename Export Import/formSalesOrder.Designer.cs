namespace Export_Import
{
    partial class formSalesOrder
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
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cbCreditTerm = new System.Windows.Forms.ComboBox();
            this.txtShip = new System.Windows.Forms.TextBox();
            this.cbShip = new System.Windows.Forms.ComboBox();
            this.cbStaff = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dateSO = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.txtIdSO = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbGudang = new System.Windows.Forms.ComboBox();
            this.cbIdCust = new System.Windows.Forms.ComboBox();
            this.txtAlamatCust = new System.Windows.Forms.TextBox();
            this.txtNamaCust = new System.Windows.Forms.TextBox();
            this.pnlBawah = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnPreview = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.cbCurrency = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtRate = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtTotalHarga = new System.Windows.Forms.TextBox();
            this.txtTotalHargaConvert = new System.Windows.Forms.TextBox();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.groupButton = new System.Windows.Forms.GroupBox();
            this.btnRedo = new System.Windows.Forms.Button();
            this.btnUndo = new System.Windows.Forms.Button();
            this.btnMoveDown = new System.Windows.Forms.Button();
            this.btnMoveUp = new System.Windows.Forms.Button();
            this.btnMinus = new System.Windows.Forms.Button();
            this.btnPlus = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.id_item = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nama_item = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qty_item = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jenis_satuan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.harga_satuan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.berat_total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jenis_ppn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.total_ppn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.discount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subtotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlAtas.SuspendLayout();
            this.pnlBawah.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.groupButton.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlAtas
            // 
            this.pnlAtas.BackColor = System.Drawing.Color.MediumTurquoise;
            this.pnlAtas.Controls.Add(this.btnSearch);
            this.pnlAtas.Controls.Add(this.label10);
            this.pnlAtas.Controls.Add(this.label9);
            this.pnlAtas.Controls.Add(this.label8);
            this.pnlAtas.Controls.Add(this.label7);
            this.pnlAtas.Controls.Add(this.cbCreditTerm);
            this.pnlAtas.Controls.Add(this.txtShip);
            this.pnlAtas.Controls.Add(this.cbShip);
            this.pnlAtas.Controls.Add(this.cbStaff);
            this.pnlAtas.Controls.Add(this.label6);
            this.pnlAtas.Controls.Add(this.dateSO);
            this.pnlAtas.Controls.Add(this.label5);
            this.pnlAtas.Controls.Add(this.txtIdSO);
            this.pnlAtas.Controls.Add(this.label4);
            this.pnlAtas.Controls.Add(this.label3);
            this.pnlAtas.Controls.Add(this.label2);
            this.pnlAtas.Controls.Add(this.label1);
            this.pnlAtas.Controls.Add(this.cbGudang);
            this.pnlAtas.Controls.Add(this.cbIdCust);
            this.pnlAtas.Controls.Add(this.txtAlamatCust);
            this.pnlAtas.Controls.Add(this.txtNamaCust);
            this.pnlAtas.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlAtas.Location = new System.Drawing.Point(0, 0);
            this.pnlAtas.Name = "pnlAtas";
            this.pnlAtas.Size = new System.Drawing.Size(1350, 289);
            this.pnlAtas.TabIndex = 1;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(939, 180);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(93, 19);
            this.label10.TabIndex = 20;
            this.label10.Text = "Shipping Info";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(971, 147);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(61, 19);
            this.label9.TabIndex = 19;
            this.label9.Text = "Ship Via";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(947, 114);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(85, 19);
            this.label8.TabIndex = 18;
            this.label8.Text = "Nama Sales";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(952, 81);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 19);
            this.label7.TabIndex = 17;
            this.label7.Text = "Credit Term";
            // 
            // cbCreditTerm
            // 
            this.cbCreditTerm.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCreditTerm.FormattingEnabled = true;
            this.cbCreditTerm.Location = new System.Drawing.Point(1038, 78);
            this.cbCreditTerm.Name = "cbCreditTerm";
            this.cbCreditTerm.Size = new System.Drawing.Size(300, 27);
            this.cbCreditTerm.TabIndex = 16;
            // 
            // txtShip
            // 
            this.txtShip.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtShip.Location = new System.Drawing.Point(1038, 177);
            this.txtShip.Multiline = true;
            this.txtShip.Name = "txtShip";
            this.txtShip.Size = new System.Drawing.Size(300, 99);
            this.txtShip.TabIndex = 15;
            // 
            // cbShip
            // 
            this.cbShip.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbShip.FormattingEnabled = true;
            this.cbShip.Location = new System.Drawing.Point(1038, 144);
            this.cbShip.Name = "cbShip";
            this.cbShip.Size = new System.Drawing.Size(300, 27);
            this.cbShip.TabIndex = 14;
            // 
            // cbStaff
            // 
            this.cbStaff.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbStaff.FormattingEnabled = true;
            this.cbStaff.Location = new System.Drawing.Point(1038, 111);
            this.cbStaff.Name = "cbStaff";
            this.cbStaff.Size = new System.Drawing.Size(300, 27);
            this.cbStaff.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(944, 48);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 19);
            this.label6.TabIndex = 12;
            this.label6.Text = "Tanggal S/O";
            // 
            // dateSO
            // 
            this.dateSO.Enabled = false;
            this.dateSO.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateSO.Location = new System.Drawing.Point(1038, 45);
            this.dateSO.Name = "dateSO";
            this.dateSO.Size = new System.Drawing.Size(300, 27);
            this.dateSO.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(952, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 19);
            this.label5.TabIndex = 10;
            this.label5.Text = "Nomer S/O";
            // 
            // txtIdSO
            // 
            this.txtIdSO.Enabled = false;
            this.txtIdSO.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdSO.Location = new System.Drawing.Point(1038, 12);
            this.txtIdSO.Name = "txtIdSO";
            this.txtIdSO.Size = new System.Drawing.Size(300, 27);
            this.txtIdSO.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(24, 206);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 19);
            this.label4.TabIndex = 8;
            this.label4.Text = "Dikirim dari";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(53, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 19);
            this.label3.TabIndex = 7;
            this.label3.Text = "Alamat";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(61, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 19);
            this.label2.TabIndex = 6;
            this.label2.Text = "Nama";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(37, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 19);
            this.label1.TabIndex = 5;
            this.label1.Text = "Customer";
            // 
            // cbGudang
            // 
            this.cbGudang.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbGudang.FormattingEnabled = true;
            this.cbGudang.Location = new System.Drawing.Point(114, 203);
            this.cbGudang.Name = "cbGudang";
            this.cbGudang.Size = new System.Drawing.Size(300, 27);
            this.cbGudang.TabIndex = 3;
            // 
            // cbIdCust
            // 
            this.cbIdCust.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbIdCust.FormattingEnabled = true;
            this.cbIdCust.Location = new System.Drawing.Point(114, 12);
            this.cbIdCust.Name = "cbIdCust";
            this.cbIdCust.Size = new System.Drawing.Size(300, 27);
            this.cbIdCust.TabIndex = 2;
            this.cbIdCust.DropDownClosed += new System.EventHandler(this.cbIdCust_DropDownClosed);
            // 
            // txtAlamatCust
            // 
            this.txtAlamatCust.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAlamatCust.Location = new System.Drawing.Point(114, 78);
            this.txtAlamatCust.Multiline = true;
            this.txtAlamatCust.Name = "txtAlamatCust";
            this.txtAlamatCust.Size = new System.Drawing.Size(300, 119);
            this.txtAlamatCust.TabIndex = 1;
            // 
            // txtNamaCust
            // 
            this.txtNamaCust.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNamaCust.Location = new System.Drawing.Point(114, 45);
            this.txtNamaCust.Name = "txtNamaCust";
            this.txtNamaCust.Size = new System.Drawing.Size(300, 27);
            this.txtNamaCust.TabIndex = 0;
            // 
            // pnlBawah
            // 
            this.pnlBawah.Controls.Add(this.btnSave);
            this.pnlBawah.Controls.Add(this.btnPreview);
            this.pnlBawah.Controls.Add(this.btnCancel);
            this.pnlBawah.Controls.Add(this.label15);
            this.pnlBawah.Controls.Add(this.cbCurrency);
            this.pnlBawah.Controls.Add(this.label14);
            this.pnlBawah.Controls.Add(this.txtRate);
            this.pnlBawah.Controls.Add(this.label13);
            this.pnlBawah.Controls.Add(this.label12);
            this.pnlBawah.Controls.Add(this.txtTotalHarga);
            this.pnlBawah.Controls.Add(this.txtTotalHargaConvert);
            this.pnlBawah.Controls.Add(this.dataGridView);
            this.pnlBawah.Controls.Add(this.groupButton);
            this.pnlBawah.Controls.Add(this.label11);
            this.pnlBawah.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBawah.Location = new System.Drawing.Point(0, 295);
            this.pnlBawah.Name = "pnlBawah";
            this.pnlBawah.Size = new System.Drawing.Size(1350, 452);
            this.pnlBawah.TabIndex = 2;
            this.pnlBawah.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlBawah_Paint);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.LimeGreen;
            this.btnSave.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(1026, 408);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 35);
            this.btnSave.TabIndex = 20;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            // 
            // btnPreview
            // 
            this.btnPreview.BackColor = System.Drawing.Color.DarkOrange;
            this.btnPreview.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPreview.Location = new System.Drawing.Point(1132, 408);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(100, 35);
            this.btnPreview.TabIndex = 19;
            this.btnPreview.Text = "Preview";
            this.btnPreview.UseVisualStyleBackColor = false;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Red;
            this.btnCancel.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(1238, 408);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 35);
            this.btnCancel.TabIndex = 18;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(572, 370);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(66, 19);
            this.label15.TabIndex = 17;
            this.label15.Text = "Currency";
            // 
            // cbCurrency
            // 
            this.cbCurrency.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCurrency.FormattingEnabled = true;
            this.cbCurrency.Location = new System.Drawing.Point(644, 367);
            this.cbCurrency.Name = "cbCurrency";
            this.cbCurrency.Size = new System.Drawing.Size(75, 27);
            this.cbCurrency.TabIndex = 16;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(725, 370);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(39, 19);
            this.label14.TabIndex = 15;
            this.label14.Text = "Rate";
            // 
            // txtRate
            // 
            this.txtRate.Enabled = false;
            this.txtRate.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRate.Location = new System.Drawing.Point(770, 367);
            this.txtRate.Name = "txtRate";
            this.txtRate.Size = new System.Drawing.Size(150, 27);
            this.txtRate.TabIndex = 14;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(926, 370);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(106, 19);
            this.label13.TabIndex = 13;
            this.label13.Text = "Local Net Total";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(964, 337);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(68, 19);
            this.label12.TabIndex = 12;
            this.label12.Text = "Net Total";
            // 
            // txtTotalHarga
            // 
            this.txtTotalHarga.Enabled = false;
            this.txtTotalHarga.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalHarga.Location = new System.Drawing.Point(1038, 334);
            this.txtTotalHarga.Name = "txtTotalHarga";
            this.txtTotalHarga.Size = new System.Drawing.Size(300, 27);
            this.txtTotalHarga.TabIndex = 11;
            // 
            // txtTotalHargaConvert
            // 
            this.txtTotalHargaConvert.Enabled = false;
            this.txtTotalHargaConvert.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalHargaConvert.Location = new System.Drawing.Point(1038, 367);
            this.txtTotalHargaConvert.Name = "txtTotalHargaConvert";
            this.txtTotalHargaConvert.Size = new System.Drawing.Size(300, 27);
            this.txtTotalHargaConvert.TabIndex = 10;
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_item,
            this.nama_item,
            this.qty_item,
            this.jenis_satuan,
            this.harga_satuan,
            this.berat_total,
            this.jenis_ppn,
            this.total_ppn,
            this.discount,
            this.subtotal});
            this.dataGridView.Location = new System.Drawing.Point(3, 81);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(1347, 247);
            this.dataGridView.TabIndex = 2;
            // 
            // groupButton
            // 
            this.groupButton.Controls.Add(this.btnRedo);
            this.groupButton.Controls.Add(this.btnUndo);
            this.groupButton.Controls.Add(this.btnMoveDown);
            this.groupButton.Controls.Add(this.btnMoveUp);
            this.groupButton.Controls.Add(this.btnMinus);
            this.groupButton.Controls.Add(this.btnPlus);
            this.groupButton.Location = new System.Drawing.Point(3, 30);
            this.groupButton.Name = "groupButton";
            this.groupButton.Size = new System.Drawing.Size(1898, 45);
            this.groupButton.TabIndex = 1;
            this.groupButton.TabStop = false;
            this.groupButton.Text = "Table Button";
            // 
            // btnRedo
            // 
            this.btnRedo.Location = new System.Drawing.Point(235, 16);
            this.btnRedo.Name = "btnRedo";
            this.btnRedo.Size = new System.Drawing.Size(50, 23);
            this.btnRedo.TabIndex = 26;
            this.btnRedo.Text = "Redo";
            this.btnRedo.UseVisualStyleBackColor = true;
            // 
            // btnUndo
            // 
            this.btnUndo.Location = new System.Drawing.Point(179, 16);
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.Size = new System.Drawing.Size(50, 23);
            this.btnUndo.TabIndex = 25;
            this.btnUndo.Text = "Undo";
            this.btnUndo.UseVisualStyleBackColor = true;
            // 
            // btnMoveDown
            // 
            this.btnMoveDown.Location = new System.Drawing.Point(123, 16);
            this.btnMoveDown.Name = "btnMoveDown";
            this.btnMoveDown.Size = new System.Drawing.Size(50, 23);
            this.btnMoveDown.TabIndex = 24;
            this.btnMoveDown.Text = "Down";
            this.btnMoveDown.UseVisualStyleBackColor = true;
            // 
            // btnMoveUp
            // 
            this.btnMoveUp.Location = new System.Drawing.Point(67, 16);
            this.btnMoveUp.Name = "btnMoveUp";
            this.btnMoveUp.Size = new System.Drawing.Size(50, 23);
            this.btnMoveUp.TabIndex = 23;
            this.btnMoveUp.Text = "Up";
            this.btnMoveUp.UseVisualStyleBackColor = true;
            // 
            // btnMinus
            // 
            this.btnMinus.Location = new System.Drawing.Point(38, 16);
            this.btnMinus.Name = "btnMinus";
            this.btnMinus.Size = new System.Drawing.Size(23, 23);
            this.btnMinus.TabIndex = 22;
            this.btnMinus.Text = "-";
            this.btnMinus.UseVisualStyleBackColor = true;
            // 
            // btnPlus
            // 
            this.btnPlus.Location = new System.Drawing.Point(9, 16);
            this.btnPlus.Name = "btnPlus";
            this.btnPlus.Size = new System.Drawing.Size(23, 23);
            this.btnPlus.TabIndex = 21;
            this.btnPlus.Text = "+";
            this.btnPlus.UseVisualStyleBackColor = true;
            this.btnPlus.Click += new System.EventHandler(this.btnPlus_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(655, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(95, 26);
            this.label11.TabIndex = 0;
            this.label11.Text = "List Order";
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(420, 12);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(72, 27);
            this.btnSearch.TabIndex = 21;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // id_item
            // 
            this.id_item.DataPropertyName = "id_item";
            this.id_item.Frozen = true;
            this.id_item.HeaderText = "ID Item";
            this.id_item.Name = "id_item";
            this.id_item.ReadOnly = true;
            // 
            // nama_item
            // 
            this.nama_item.DataPropertyName = "nama_item";
            this.nama_item.Frozen = true;
            this.nama_item.HeaderText = "Nama Item";
            this.nama_item.Name = "nama_item";
            this.nama_item.ReadOnly = true;
            this.nama_item.Width = 200;
            // 
            // qty_item
            // 
            this.qty_item.DataPropertyName = "qty_item";
            this.qty_item.Frozen = true;
            this.qty_item.HeaderText = "QTY Item";
            this.qty_item.Name = "qty_item";
            this.qty_item.ReadOnly = true;
            // 
            // jenis_satuan
            // 
            this.jenis_satuan.Frozen = true;
            this.jenis_satuan.HeaderText = "Satuan";
            this.jenis_satuan.Name = "jenis_satuan";
            this.jenis_satuan.ReadOnly = true;
            this.jenis_satuan.Width = 150;
            // 
            // harga_satuan
            // 
            this.harga_satuan.Frozen = true;
            this.harga_satuan.HeaderText = "Harga Satuan";
            this.harga_satuan.Name = "harga_satuan";
            this.harga_satuan.ReadOnly = true;
            this.harga_satuan.Width = 150;
            // 
            // berat_total
            // 
            this.berat_total.Frozen = true;
            this.berat_total.HeaderText = "Berat Total";
            this.berat_total.Name = "berat_total";
            this.berat_total.ReadOnly = true;
            // 
            // jenis_ppn
            // 
            this.jenis_ppn.Frozen = true;
            this.jenis_ppn.HeaderText = "Jenis PPN";
            this.jenis_ppn.Name = "jenis_ppn";
            this.jenis_ppn.ReadOnly = true;
            this.jenis_ppn.Width = 75;
            // 
            // total_ppn
            // 
            this.total_ppn.Frozen = true;
            this.total_ppn.HeaderText = "Total PPN";
            this.total_ppn.Name = "total_ppn";
            this.total_ppn.ReadOnly = true;
            this.total_ppn.Width = 150;
            // 
            // discount
            // 
            this.discount.DataPropertyName = "discount";
            this.discount.Frozen = true;
            this.discount.HeaderText = "Discount";
            this.discount.Name = "discount";
            this.discount.ReadOnly = true;
            this.discount.Width = 75;
            // 
            // subtotal
            // 
            this.subtotal.Frozen = true;
            this.subtotal.HeaderText = "Subtotal";
            this.subtotal.Name = "subtotal";
            this.subtotal.ReadOnly = true;
            this.subtotal.Width = 200;
            // 
            // formSalesOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1350, 747);
            this.Controls.Add(this.pnlBawah);
            this.Controls.Add(this.pnlAtas);
            this.Name = "formSalesOrder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "New Sales Order";
            this.Load += new System.EventHandler(this.formSalesOrder_Load);
            this.pnlAtas.ResumeLayout(false);
            this.pnlAtas.PerformLayout();
            this.pnlBawah.ResumeLayout(false);
            this.pnlBawah.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.groupButton.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlAtas;
        private System.Windows.Forms.Panel pnlBawah;
        private System.Windows.Forms.TextBox txtNamaCust;
        private System.Windows.Forms.TextBox txtAlamatCust;
        private System.Windows.Forms.ComboBox cbIdCust;
        private System.Windows.Forms.ComboBox cbGudang;
        private System.Windows.Forms.TextBox txtIdSO;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dateSO;
        private System.Windows.Forms.TextBox txtShip;
        private System.Windows.Forms.ComboBox cbShip;
        private System.Windows.Forms.ComboBox cbStaff;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbCreditTerm;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupButton;
        private System.Windows.Forms.Button btnMinus;
        private System.Windows.Forms.Button btnPlus;
        private System.Windows.Forms.Button btnMoveDown;
        private System.Windows.Forms.Button btnMoveUp;
        private System.Windows.Forms.Button btnUndo;
        private System.Windows.Forms.Button btnRedo;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.TextBox txtTotalHargaConvert;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtTotalHarga;
        private System.Windows.Forms.TextBox txtRate;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cbCurrency;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_item;
        private System.Windows.Forms.DataGridViewTextBoxColumn nama_item;
        private System.Windows.Forms.DataGridViewTextBoxColumn qty_item;
        private System.Windows.Forms.DataGridViewTextBoxColumn jenis_satuan;
        private System.Windows.Forms.DataGridViewTextBoxColumn harga_satuan;
        private System.Windows.Forms.DataGridViewTextBoxColumn berat_total;
        private System.Windows.Forms.DataGridViewTextBoxColumn jenis_ppn;
        private System.Windows.Forms.DataGridViewTextBoxColumn total_ppn;
        private System.Windows.Forms.DataGridViewTextBoxColumn discount;
        private System.Windows.Forms.DataGridViewTextBoxColumn subtotal;
    }
}