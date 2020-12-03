namespace Export_Import
{
    partial class formLaporanPembelian
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend5 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea6 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend6 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.pnlAtas = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageGrafik = new System.Windows.Forms.TabPage();
            this.lblKategori = new System.Windows.Forms.Label();
            this.chartPie = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lblChartPembelian = new System.Windows.Forms.Label();
            this.chartPembelian = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabPageLaporan = new System.Windows.Forms.TabPage();
            this.btnBack = new System.Windows.Forms.Button();
            this.pnlAtas.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabPageGrafik.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartPie)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartPembelian)).BeginInit();
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
            this.pnlAtas.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(398, 59);
            this.label1.TabIndex = 0;
            this.label1.Text = "Laporan Pembelian";
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
            this.tabControl.Size = new System.Drawing.Size(1350, 597);
            this.tabControl.TabIndex = 2;
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
            this.tabPageGrafik.Size = new System.Drawing.Size(1342, 558);
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
            this.lblKategori.Size = new System.Drawing.Size(291, 42);
            this.lblKategori.TabIndex = 3;
            this.lblKategori.Text = "Kategori Pembelian";
            // 
            // chartPie
            // 
            chartArea5.Name = "ChartArea1";
            this.chartPie.ChartAreas.Add(chartArea5);
            legend5.Name = "Legend1";
            this.chartPie.Legends.Add(legend5);
            this.chartPie.Location = new System.Drawing.Point(809, 78);
            this.chartPie.Name = "chartPie";
            series5.ChartArea = "ChartArea1";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut;
            series5.Legend = "Legend1";
            series5.Name = "Kategori";
            this.chartPie.Series.Add(series5);
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
            this.lblChartPembelian.Size = new System.Drawing.Size(288, 42);
            this.lblChartPembelian.TabIndex = 1;
            this.lblChartPembelian.Text = "Laporan Pembelian";
            // 
            // chartPembelian
            // 
            chartArea6.Name = "ChartArea1";
            this.chartPembelian.ChartAreas.Add(chartArea6);
            legend6.Name = "Legend1";
            this.chartPembelian.Legends.Add(legend6);
            this.chartPembelian.Location = new System.Drawing.Point(18, 78);
            this.chartPembelian.Name = "chartPembelian";
            this.chartPembelian.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Berry;
            series6.ChartArea = "ChartArea1";
            series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series6.Legend = "Legend1";
            series6.Name = "Total";
            this.chartPembelian.Series.Add(series6);
            this.chartPembelian.Size = new System.Drawing.Size(685, 404);
            this.chartPembelian.TabIndex = 0;
            this.chartPembelian.Text = "chart1";
            // 
            // tabPageLaporan
            // 
            this.tabPageLaporan.Location = new System.Drawing.Point(4, 35);
            this.tabPageLaporan.Name = "tabPageLaporan";
            this.tabPageLaporan.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageLaporan.Size = new System.Drawing.Size(1342, 623);
            this.tabPageLaporan.TabIndex = 1;
            this.tabPageLaporan.Text = "Laporan";
            this.tabPageLaporan.UseVisualStyleBackColor = true;
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
            // formLaporanPembelian
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1350, 747);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.pnlAtas);
            this.Name = "formLaporanPembelian";
            this.Text = "Laporan Pembelian";
            this.Load += new System.EventHandler(this.formLaporanPembelian_Load);
            this.pnlAtas.ResumeLayout(false);
            this.pnlAtas.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.tabPageGrafik.ResumeLayout(false);
            this.tabPageGrafik.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartPie)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartPembelian)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlAtas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageGrafik;
        private System.Windows.Forms.TabPage tabPageLaporan;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartPembelian;
        private System.Windows.Forms.Label lblChartPembelian;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartPie;
        private System.Windows.Forms.Label lblKategori;
        private System.Windows.Forms.Button btnBack;
    }
}