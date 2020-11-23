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
    public partial class formSearchPO : Form
    {
        formPurchaseInvoice form;
        OracleConnection conn;
        private OracleDataAdapter dapurchaseOrder;
        private DataSet ds = new DataSet();
        public String id_po = "";
        int idx = -1;
        public formSearchPO()
        {
            InitializeComponent();
        }
        public formSearchPO(formPurchaseInvoice form)
        {
            InitializeComponent();
            this.form = form;
            this.conn = form.conn;
            this.id_po = form.id_po;
        }
        void refreshTable()
        {
            String cmd = "select id_purchase_order, nama_supplier, tgl_purchase_order from h_purchase_order";
            dapurchaseOrder = new OracleDataAdapter(cmd, conn);
            dapurchaseOrder.Fill(ds, "h_purchase_order");
            dataGridView.DataSource = ds.Tables["h_purchase_order"];
        }
        void refreshTable(String id, String keyword)
        {
            String cmd = "select id_purchase_order, nama_supplier, tgl_purchase_order from h_purchase_order " +
                "where id_purchase_order != '" + id + "' AND " +
                "nama_supplier = '" + keyword + "'";
            dapurchaseOrder = new OracleDataAdapter(cmd, conn);
            dapurchaseOrder.Fill(ds, "h_purchase_order");
            dataGridView.DataSource = ds.Tables["h_purchase_order"];
        }
        void refreshTable(String keyword)
        {
            String cmd = "select id_purchase_order, nama_supplier, tgl_purchase_order from h_purchase_order " +
                "where id_purchase_order = '" + keyword + "' OR " +
                "nama_supplier = '" + keyword + "'";
            dapurchaseOrder = new OracleDataAdapter(cmd, conn);
            dapurchaseOrder.Fill(ds, "h_purchase_order");
            dataGridView.DataSource = ds.Tables["h_purchase_order"];
        }
        private void btnGet_Click(object sender, EventArgs e)
        {
            if (dataGridView.Rows.Count <= 1 || idx == dataGridView.Rows.Count - 1)
            {
                MessageBox.Show("Data kosong");
                return;
            }

            if (idx > -1)
            {
                this.id_po = dataGridView.Rows[idx].Cells[0].Value.ToString();
                this.DialogResult = DialogResult.Yes;
                this.Close();
            }
        }

        private void formSearchPO_Load(object sender, EventArgs e)
        {
            if (!id_po.Equals(""))
            {
                String nama_supplier = new OracleCommand("select nama_supplier from h_purchase_order where id_purchase_order = '" + id_po + "'", conn).ExecuteScalar().ToString();

                refreshTable(id_po, nama_supplier);
                return;
            }
            refreshTable();
        }

        private void txtKeyword_TextChanged(object sender, EventArgs e)
        {
            ds.Tables["h_purchase_order"].Clear();
            if (!id_po.Equals(""))
            {
                refreshTable(id_po, txtKeyword.Text);
                return;
            }
            refreshTable(txtKeyword.Text);
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            idx = e.RowIndex;
        }
    }
}
