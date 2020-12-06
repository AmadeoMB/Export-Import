namespace Export_Import
{
    partial class formLaporanPenjualan
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.tabPageGrafik = new System.Windows.Forms.TabPage();
            this.lblKategori = new System.Windows.Forms.Label();
            this.chartPie = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lblChartPembelian = new System.Windows.Forms.Label();
            this.chartPembelian = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageLaporan = new System.Windows.Forms.TabPage();
            this.pnlAtas = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.crystalReportViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.btnPrint = new System.Windows.Forms.Button();
            this.tabPageGrafik.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartPie)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartPembelian)).BeginInit();
            this.tabControl.SuspendLayout();
            this.tabPageLaporan.SuspendLayout();
            this.pnlAtas.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPageGrafik
            // 
            this.tabPageGrafik.Controls.Add(this.lblKategori);
            this.tabPageGrafik.Controls.Add(this.chartPie);
            this.tabPageGrafik.Controls.Add(this.lblChartPembelian);
            this.tabPageGrafik.Controls.Add(this.chartPembelian);
            this.tabPageGrafik.Location = new System.Drawing.Point(4, 35);
            this.tabPageGrafik.Name = "tabPageGrafik";
            this.tabPageGrafik.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageGrafik.Size = new System.Drawing.Size(1342, 567);
            this.tabPageGrafik.TabIndex = 0;
            this.tabPageGrafik.Text = "Grafik";
            this.tabPageGrafik.UseVisualStyleBackColor = true;
            // 
            // lblKategori
            // 
            this.lblKategori.AutoSize = true;
            this.lblKategori.Font = new System.Drawing.Font("Calibri", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKategori.Location = new System.Drawing.Point(830, 485);
            this.lblKategori.Name = "lblKategori";
            this.lblKategori.Size = new System.Drawing.Size(281, 42);
            this.lblKategori.TabIndex = 3;
            this.lblKategori.Text = "Kategori Penjualan";
            // 
            // chartPie
            // 
            chartArea3.Name = "ChartArea1";
            this.chartPie.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chartPie.Legends.Add(legend3);
            this.chartPie.Location = new System.Drawing.Point(809, 78);
            this.chartPie.Name = "chartPie";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut;
            series3.Legend = "Legend1";
            series3.Name = "Kategori";
            this.chartPie.Series.Add(series3);
            this.chartPie.Size = new System.Drawing.Size(444, 404);
            this.chartPie.TabIndex = 2;
            this.chartPie.Text = "chart1";
            // 
            // lblChartPembelian
            // 
            this.lblChartPembelian.AutoSize = true;
            this.lblChartPembelian.Font = new System.Drawing.Font("Calibri", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChartPembelian.Location = new System.Drawing.Point(113, 485);
            this.lblChartPembelian.Name = "lblChartPembelian";
            this.lblChartPembelian.Size = new System.Drawing.Size(278, 42);
            this.lblChartPembelian.TabIndex = 1;
            this.lblChartPembelian.Text = "Laporan Penjualan";
            // 
            // chartPembelian
            // 
            chartArea4.Name = "ChartArea1";
            this.chartPembelian.ChartAreas.Add(chartArea4);
            legend4.Name = "Legend1";
            this.chartPembelian.Legends.Add(legend4);
            this.chartPembelian.Location = new System.Drawing.Point(18, 78);
            this.chartPembelian.Name = "chartPembelian";
            this.chartPembelian.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Berry;
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series4.Legend = "Legend1";
            series4.Name = "Total";
            this.chartPembelian.Series.Add(series4);
            this.chartPembelian.Size = new System.Drawing.Size(685, 404);
            this.chartPembelian.TabIndex = 0;
            this.chartPembelian.Text = "chart1";
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageGrafik);
            this.tabControl.Controls.Add(this.tabPageLaporan);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl.Location = new System.Drawing.Point(0, 85);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1350, 606);
            this.tabControl.TabIndex = 4;
            // 
            // tabPageLaporan
            // 
            this.tabPageLaporan.Controls.Add(this.btnPrint);
            this.tabPageLaporan.Controls.Add(this.crystalReportViewer);
            this.tabPageLaporan.Controls.Add(this.dateTimePicker2);
            this.tabPageLaporan.Controls.Add(this.dateTimePicker1);
            this.tabPageLaporan.Controls.Add(this.label3);
            this.tabPageLaporan.Controls.Add(this.label2);
            this.tabPageLaporan.Location = new System.Drawing.Point(4, 35);
            this.tabPageLaporan.Name = "tabPageLaporan";
            this.tabPageLaporan.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageLaporan.Size = new System.Drawing.Size(1342, 567);
            this.tabPageLaporan.TabIndex = 1;
            this.tabPageLaporan.Text = "Laporan";
            this.tabPageLaporan.UseVisualStyleBackColor = true;
            // 
            // pnlAtas
            // 
            this.pnlAtas.BackColor = System.Drawing.Color.MediumTurquoise;
            this.pnlAtas.Controls.Add(this.label1);
            this.pnlAtas.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlAtas.Location = new System.Drawing.Point(0, 0);
            this.pnlAtas.Name = "pnlAtas";
            this.pnlAtas.Size = new System.Drawing.Size(1350, 85);
            this.pnlAtas.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(384, 59);
            this.label1.TabIndex = 0;
            this.label1.Text = "Laporan Penjualan";
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.Red;
            this.btnBack.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.Location = new System.Drawing.Point(12, 700);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(100, 35);
            this.btnBack.TabIndex = 24;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(15, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 19);
            this.label2.TabIndex = 0;
            this.label2.Text = "Tanggal 1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(376, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 19);
            this.label3.TabIndex = 1;
            this.label3.Text = "Tanggal 2";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Location = new System.Drawing.Point(93, 18);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 27);
            this.dateTimePicker1.TabIndex = 2;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker2.Location = new System.Drawing.Point(454, 18);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(200, 27);
            this.dateTimePicker2.TabIndex = 3;
            // 
            // crystalReportViewer
            // 
            this.crystalReportViewer.ActiveViewIndex = -1;
            this.crystalReportViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.crystalReportViewer.Location = new System.Drawing.Point(3, 63);
            this.crystalReportViewer.Name = "crystalReportViewer";
            this.crystalReportViewer.Size = new System.Drawing.Size(1336, 501);
            this.crystalReportViewer.TabIndex = 4;
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnPrint.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.Location = new System.Drawing.Point(1234, 16);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(100, 35);
            this.btnPrint.TabIndex = 25;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // formLaporanPenjualan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1350, 747);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.pnlAtas);
            this.Name = "formLaporanPenjualan";
            this.Text = "Laporan Penjualan";
            this.Load += new System.EventHandler(this.formLaporanPenjualan_Load);
            this.tabPageGrafik.ResumeLayout(false);
            this.tabPageGrafik.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartPie)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartPembelian)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.tabPageLaporan.ResumeLayout(false);
            this.tabPageLaporan.PerformLayout();
            this.pnlAtas.ResumeLayout(false);
            this.pnlAtas.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tabPageGrafik;
        private System.Windows.Forms.Label lblKategori;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartPie;
        private System.Windows.Forms.Label lblChartPembelian;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartPembelian;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageLaporan;
        private System.Windows.Forms.Panel pnlAtas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnPrint;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
    }
}