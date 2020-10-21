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
        OracleConnection conn;
        public formMasterGudang gudang;
        OracleDataAdapter daSO;
        DataSet ds = new DataSet();
        Object[] filter = { "", null, 0 };
        public String id_sales_order;

        public formListSalesOrder()
        {
            InitializeComponent();
        }

        public formListSalesOrder(formMasterGudang gudang)
        {
            InitializeComponent();
            this.gudang = gudang;
        }

        private void formListSalesOrder_Load(object sender, EventArgs e)
        {
            conn = new OracleConnection("user id=export;password=import;data source=orcl");

            try
            {
                conn.Open();
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
                "select h.id_sales_order as id, nama_customer as nama, tgl_sales_order as tanggal( " +
                    "select count(d.id_item) " +
                    "from d_sales_order d " +
                    "where d.id_sales_order = h.id_sales_order" +
                ") as jumlah " +
                "from h_sales_order h " +
                "where id_delivery_order = '-'";

            daSO = new OracleDataAdapter(cmd, conn);
            daSO.Fill(ds, "so");
            dataGridView.DataSource = ds.Tables["so"];
        }

        void refreshTable(Object[] data)
        {
            String cmd = 
                "select h.id_sales_order as id, nama_customer as nama, tgl_sales_order as tanggal( " +
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
                ") > " + data[2];

            if (data[1] != null)
            {
                cmd += " AND tgl_sales_order =" + data[1];
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
            filter[1] = dateFilter.Value;

            refreshTable(filter);
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
            if (idx > -1)
            {
                id_sales_order = ds.Tables["so"].Rows[idx][0].ToString();
                this.Close();
                new formDeliveryOrder().Show();
            }
        }
    }
}
