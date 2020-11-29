using System;
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
                String cmd = "select sum(total_harga)+0 from h_purchase_invoice where id_purchase_invoice like 'PI/" + tahunSekarang + "/" + i + "/%'";
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

            //String cmd = "select sum(total_harga)+0 from h_purchase_invoice where id_purchase_invoice like 'PI/" + tahunSekarang + "/" + i + "/%'";
            //String hasilQuery = new OracleCommand(cmd, conn).ExecuteScalar().ToString();
            //Int64 total = 0;
            //if (!hasilQuery.Equals(""))
            //{
            //    total = Convert.ToInt64(hasilQuery);
            //}

            for (int i = 1; i < 13; i++)
            {
                chartPie.Series["Kategori"].Points.AddXY(getMonth(i), 1);
            }
        }

        private void formLaporanPembelian_Load(object sender, EventArgs e)
        {
            loadChart();
            loadChartPie();
        }
    }
}
