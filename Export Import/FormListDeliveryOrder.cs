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
    public partial class formListDeliveryOrder : Form
    {
        public OracleConnection conn;
        public formMasterGudang gudang;
        public formMasterPenjualan penjualan;
        OracleDataAdapter daSO;
        DataSet ds = new DataSet();
        Object[] filter = { "", null, 0 };
        public String id_delivery_order;

        public formListDeliveryOrder()
        {
            InitializeComponent();
            this.conn = new OracleConnection("user id=export;password=import;data source=orcl");
            this.conn.Open();
        }

        public formListDeliveryOrder(formMasterGudang gudang)
        {
            InitializeComponent();
            this.gudang = gudang;
            this.conn = gudang.conn;
        }
        public formListDeliveryOrder(formMasterPenjualan penjualan)
        {
            InitializeComponent();
            this.penjualan = penjualan;
            this.conn = penjualan.conn;
        }
        private void formListDeliveryOrder_Load(object sender, EventArgs e)
        {
            try
            {
                refreshTable();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        void refreshTable()
        {
            String cmd =
                "select h.id_delivery_order as id, nama_customer as nama, tgl_delivery_order as tanggal, ( " +
                    "select count(d.id_item) " +
                    "from d_delivery_order d " +
                    "where d.id_delivery_order = h.id_delivery_order" +
                " ) as jumlah, status_do as status " +
                "from h_delivery_order h ";
            
            daSO = new OracleDataAdapter(cmd, conn);
            daSO.Fill(ds, "do");
            dataGridView.DataSource = ds.Tables["do"];
        }

        void refreshTable(Object[] data)
        {
            String cmd =
                "select h.id_delivery_order as id, nama_customer as nama, tgl_delivery_order as tanggal, ( " +
                    "select count(d.id_item) " +
                    "from d_delivery_order d " +
                    "where d.id_delivery_order = h.id_delivery_order" +
                ") as jumlah " +
                "from h_delivery_order h ";

            cmd += "AND nama_customer = '" + data[0] + "' ";
            cmd += "AND ( " +
                    "select count(d.id_item) " +
                    "from d_delivery_order d " +
                    "where d.id_delivery_order = h.id_delivery_order" +
                ") > " + data[2] + " ";

            if (data[1] != null)
            {
                cmd += "AND tgl_delivery_order =" + data[1];
            }

            daSO = new OracleDataAdapter(cmd, conn);
            daSO.Fill(ds, "do");
            dataGridView.DataSource = ds.Tables["do"];
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (dataGridView.Rows.Count <= 1 || idx == dataGridView.Rows.Count - 1)
            {
                MessageBox.Show("Data kosong");
                return;
            }

            if (idx > -1)
            {
                id_delivery_order = dataGridView.Rows[idx].Cells[0].Value.ToString();
                this.Hide();
                new formInvoice(this).Show();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView.Rows.Count <= 1 || idx == dataGridView.Rows.Count - 1)
            {
                MessageBox.Show("Data kosong");
                return;
            }

            if (dataGridView.Rows[idx].Cells[4].Value.ToString().Equals("1"))
            {
                MessageBox.Show("Data tidak bisa diedit");
                return;
            }

            if (idx > -1)
            {
                id_delivery_order = dataGridView.Rows[idx].Cells[0].Value.ToString();
                this.Hide();
                new formDeliveryOrder(this).Show();
            }
        }
        int idx = -1;
        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            idx = e.RowIndex;

            if (idx > -1)
            {
                btnCreate.Enabled = true;
            }
            else
            {
                btnCreate.Enabled = false;
            }
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            idx = e.RowIndex;

            if (idx > -1)
            {
                btnCreate.Enabled = true;
            }
            else
            {
                btnCreate.Enabled = false;
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {

        }
    }
}
