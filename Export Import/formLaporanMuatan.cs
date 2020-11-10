using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Export_Import
{
    public partial class formLaporanMuatan : Form
    {
        formMasterGudang master;
        OracleConnection conn;

        public formLaporanMuatan()
        {
            InitializeComponent();
            this.conn = new OracleConnection("user id=export;password=import;data source=orcl");
            this.conn.Open();
        }

        public formLaporanMuatan(formMasterGudang master)
        {
            InitializeComponent();
            this.master = master;
            this.conn = master.conn;
        }

        private void formLaporanMuatan_Load(object sender, EventArgs e)
        {
            OracleCommand cmd = new OracleCommand("select id_invoice, nama_customer from h_invoice", conn);
            OracleDataReader dr = cmd.ExecuteReader();

            List<String> items = new List<String>();

            while (dr.Read())
            {
                items.Add(String.Format("{0} - {1}", dr.GetValue(0), dr.GetValue(1)));
            }

            cbInvoice.Items.AddRange(items.ToArray());
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (cbInvoice.SelectedIndex < 0)
            {
                MessageBox.Show("Mohon pilih Invoice");
                return;
            }
            if (txtNomerContainer.Text.Length <= 0)
            {
                MessageBox.Show("Mohon isi nomer container");
                return;
            }
            String invoice = cbInvoice.Text.Substring(0,16);
            MessageBox.Show(invoice);
            LaporanMuatan rep = new LaporanMuatan();
            rep.SetDatabaseLogon("export", "import", "orcl", "");
            rep.SetParameterValue("id_invoice", invoice);
            rep.SetParameterValue("tujuan", "asd");
            rep.SetParameterValue("no_container", txtNomerContainer.Text);
            crystalReportViewer.ReportSource = rep;
        }
    }
}
