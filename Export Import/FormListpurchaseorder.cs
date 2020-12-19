using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
namespace Export_Import
{
    public partial class FormListPurchaseOrder : Form
    {
        public OracleConnection conn;
        public formMasterPembelian pembelian;
        OracleDataAdapter daPO;
        DataSet ds = new DataSet();
        public string id_purchase_order;
        int idx = -1;
        public FormListPurchaseOrder()
        {
            InitializeComponent();
            this.conn = new OracleConnection("user id=export;password=import;data source=orcl");
            this.conn.Open();
        }
        public FormListPurchaseOrder(formMasterPembelian pembelian)
        {
            InitializeComponent();
            this.conn = pembelian.conn;
            this.pembelian = pembelian;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {

        }

        private void FormListPurchaseOrder_Load(object sender, EventArgs e)
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
                "select h.id_purchase_order as id, nama_supplier as nama, tgl_purchase_order as tanggal, ( " +
                    "select count(d.id_item) " +
                    "from d_purchase_order d " +
                    "where d.id_purchase_order = h.id_purchase_order" +
                " ) as jumlah from h_purchase_order h ";

            daPO = new OracleDataAdapter(cmd, conn);
            daPO.Fill(ds, "po");
            dataGridView.DataSource = ds.Tables["po"];
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView.Rows.Count <= 1 || idx == dataGridView.Rows.Count - 1)
            {
                MessageBox.Show("Data kosong");
                return;
            }

            if (idx > -1)
            {
                id_purchase_order = dataGridView.Rows[idx].Cells[0].Value.ToString();
                this.Hide();
                new formPurchaseOrder(this).Show();
            }
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            idx = e.RowIndex;

            if (idx > -1)
            {
                btnCreate.Enabled = true;
                btnEdit.Enabled = true;
            }
            else
            {
                btnCreate.Enabled = false;
                btnEdit.Enabled = false;
            }
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            idx = e.RowIndex;

            if (idx > -1)
            {
                btnCreate.Enabled = true;
                btnEdit.Enabled = true;
            }
            else
            {
                btnCreate.Enabled = false;
                btnEdit.Enabled = false;
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
                id_purchase_order = dataGridView.Rows[idx].Cells[0].Value.ToString();
                this.Hide();
                new formPurchaseInvoice(this).Show();
            }
        }
    }
}
