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
    public partial class formListSalesOrder : Form
    {
        public OracleConnection conn;
        public formMasterGudang gudang;
        OracleDataAdapter daSO;
        DataSet ds = new DataSet();
        Object[] filter = { "", null, 0 };
        public String id_sales_order;

        public formListSalesOrder()
        {
            InitializeComponent();
            this.conn = new OracleConnection("user id=export;password=import;data source=orcl");
            this.conn.Open();
        }

        public formListSalesOrder(formMasterGudang gudang)
        {
            InitializeComponent();
            this.gudang = gudang;
            this.conn = gudang.conn;
        }

        private void formListSalesOrder_Load(object sender, EventArgs e)
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
                "select h.id_sales_order as id, nama_customer as nama, tgl_sales_order as tanggal, ( " +
                    "select count(d.id_item) " +
                    "from d_sales_order d " +
                    "where d.id_sales_order = h.id_sales_order" +
                " ) as jumlah " +
                "from h_sales_order h " +
                "where id_delivery_order = '-'";

            daSO = new OracleDataAdapter(cmd, conn);
            daSO.Fill(ds, "so");
            dataGridView.DataSource = ds.Tables["so"];
        }

        void refreshTable(Object[] data)
        {
            String cmd = 
                "select h.id_sales_order as id, nama_customer as nama, tgl_sales_order as tanggal, ( " +
                    "select count(d.id_item) " +
                    "from d_sales_order d " +
                    "where d.id_sales_order = h.id_sales_order" +
                ") as jumlah " +
                "from h_sales_order h " +
                "where id_delivery_order = '-' ";

            cmd += "AND nama_customer = '" + data[0] + "' ";
            cmd += "AND ( " +
                    "select count(d.id_item) " +
                    "from d_sales_order d " +
                    "where d.id_sales_order = h.id_sales_order" +
                ") > " + data[2] + " ";

            if (data[1] != null)
            {
                cmd += "AND tgl_sales_order =" + data[1];
            }

            daSO = new OracleDataAdapter(cmd, conn);
            daSO.Fill(ds, "so");
            dataGridView.DataSource = ds.Tables["so"];
        }

        private void txtKeyword_TextChanged(object sender, EventArgs e)
        {
            filter[0] = txtKeyword.Text;

            refreshTable(filter);
        }

        private void dateFilter_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void numJumlah_ValueChanged(object sender, EventArgs e)
        {
            filter[2] = numJumlah.Value;

            refreshTable(filter);
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

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (dataGridView.Rows.Count <= 1 || idx == dataGridView.Rows.Count - 1)
            {
                MessageBox.Show("Data kosong");
                return;
            }

            if (idx > -1)
            {
                id_sales_order = dataGridView.Rows[idx].Cells[0].Value.ToString();
                this.Hide();
                new formDeliveryOrder(this).Show();
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
            gudang.Show();
        }

        private void dateFilter_VisibleChanged(object sender, EventArgs e)
        {
            filter[1] = dateFilter.Value.ToString("yyyy-MM-dd");

            refreshTable(filter);
        }
    }
}
