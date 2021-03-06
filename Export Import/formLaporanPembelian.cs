﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.DataAccess.Client;
using System.Windows.Forms;

namespace Export_Import
{
    public partial class formLaporanPembelian : Form
    {
        public OracleConnection conn;

        public formLaporanPembelian()
        {
            InitializeComponent();
            this.conn = new OracleConnection("user id=export;password=import;data source=orcl");
            this.conn.Open();
        }

        public formLaporanPembelian(formMasterPembelian form)
        {
            InitializeComponent();
            this.conn = form.conn;
        }

        private String getMonth(int monthIndex)
        {
            if (monthIndex == 1)
            {
                return "Januari";
            }
            else if (monthIndex == 2)
            {
                return "Februari";
            }
            else if (monthIndex == 3)
            {
                return "Maret";
            }
            else if (monthIndex == 4)
            {
                return "April";
            }
            else if (monthIndex == 5)
            {
                return "Mei";
            }
            else if (monthIndex == 6)
            {
                return "Juni";
            }
            else if (monthIndex == 7)
            {
                return "Juli";
            }
            else if (monthIndex == 8)
            {
                return "Agustus";
            }
            else if (monthIndex == 9)
            {
                return "September";
            }
            else if (monthIndex == 10)
            {
                return "Oktober";
            }
            else if (monthIndex == 11)
            {
                return "November";
            }
            else if (monthIndex == 12)
            {
                return "Desember";
            }
            else
            {
                return null;
            }
        }

        private void loadChart()
        {
            String tahunSekarang = DateTime.Today.ToString("yyyy");
            lblChartPembelian.Text += " " + tahunSekarang;

            for (int i = 1; i < 13; i++)
            {
                String monthIndex = i + "";
                if (i < 10)
                {
                    monthIndex = "0" + monthIndex;
                }
                String cmd = "select sum(total_harga)+0 from h_purchase_invoice where id_purchase_invoice like 'PI/" + tahunSekarang + "/" + monthIndex + "/%'";
                String hasilQuery = new OracleCommand(cmd, conn).ExecuteScalar().ToString();
                Int64 total = 0;
                if (!hasilQuery.Equals(""))
                {
                    total = Convert.ToInt64(hasilQuery);
                }
                chartPembelian.Series["Total"].Points.AddXY(getMonth(i), total);
            }
        }

        private void loadChartPie()
        {
            String tahunSekarang = DateTime.Today.ToString("yyyy");
            lblKategori.Text += " " + tahunSekarang;

            String cmd =    "select nama_category, count(*) "+
                            "from d_purchase_invoice d "+
                            "join item i on d.id_item = i.id_item "+
                            "join category c on i.id_category = c.id_category "+
                            "where "+
                            "id_purchase_invoice like 'PI/" + tahunSekarang + "/%' "+
                            "group by nama_category ";
            OracleDataReader hasilQuery = new OracleCommand(cmd, conn).ExecuteReader();
            while (hasilQuery.Read())
            {
                chartPie.Series["Kategori"].Points.AddXY(hasilQuery.GetValue(0), hasilQuery.GetValue(1));
            }
        }

        private void formLaporanPembelian_Load(object sender, EventArgs e)
        {
            loadChart();
            loadChartPie();

            dateTimePicker1.Value = DateTime.Today;
            dateTimePicker2.Value = DateTime.UtcNow;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (dateTimePicker1.Value > DateTime.Now)
            {
                MessageBox.Show("Value tanggal 1 tidak bisa lebih besar dari hari ini");
                return;
            }

            if (dateTimePicker1.Value > dateTimePicker2.Value)
            {
                MessageBox.Show("Value tanggal 1 tidak bisa lebih besar dari tanggal 2");
                return;
            }

            LaporanPembelian rep = new LaporanPembelian();
            rep.SetDatabaseLogon("export", "import", "orcl", "");
            rep.SetParameterValue("Awal", dateTimePicker1.Value.ToString("dd-MMM-yy"));
            rep.SetParameterValue("Akhir", dateTimePicker2.Value.ToString("dd-MMM-yy"));
            crystalReportViewer.ReportSource = rep;
        }
    }
}
