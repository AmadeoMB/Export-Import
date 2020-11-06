using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Export_Import
{
    public partial class formDetailLog : Form
    {
        formListStock form;
        OracleConnection conn;
        OracleDataAdapter daLog;
        DataSet ds = new DataSet();

        public formDetailLog()
        {
            InitializeComponent();
            this.conn = new OracleConnection("user id=export;password=import;data source=orcl");
            this.conn.Open();
        }

        public formDetailLog(formListStock form)
        {
            InitializeComponent();
            this.form = form;
            this.conn = form.conn;
        }

        void isiDataItem(String id)
        {
            lblIdItem.Text = id;
            lblNamaItem.Text = new OracleCommand("select nama_item from item where id_item ='" + id + "'", conn).ExecuteScalar().ToString();

            String harga = "";
            int idx = 0;
            String hargaTemp = new OracleCommand("select harga_beli_item from item where id_item ='" + id + "'", conn).ExecuteScalar().ToString();
            for (int i = hargaTemp.Length-1; i > -1; i--)
            {
                idx++;
                harga += hargaTemp[i];
                if (idx == 3)
                {
                    if (i != 0)
                    {
                        harga += ".";
                        idx = 0;
                    }
                }
            }
            hargaTemp = "";
            for (int i = harga.Length - 1; i > -1; i--)
            {
                hargaTemp += harga[i];
            }
            lblHargaItem.Text = "Rp " + hargaTemp;
        }

        void cariLog(String id)
        {
            String cmd = "select " +
                "tgl_log as Tanggal, " +
                "SUBSTR(id_dokumen, 0, 2) as Tipe, " +
                "id_dokumen as Id, " +
                "qty as Qty, " +
                "balance as Balance from log_stock where id_item = '" + id + "'";
            daLog = new OracleDataAdapter(cmd, conn);
            daLog.Fill(ds, "log");
            dataGridView.DataSource = ds.Tables["log"];
        }

        private void formDetailLog_Load(object sender, EventArgs e)
        {
            isiDataItem(form.id_item);
            cariLog(form.id_item);
        }
    }
}
