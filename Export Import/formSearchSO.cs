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
    public partial class formSearchSO : Form
    {
        formDeliveryOrder form;
        OracleConnection conn;
        private OracleDataAdapter daSalesOrder;
        private DataSet ds = new DataSet();
        public String id_so = "";

        public formSearchSO()
        {
            InitializeComponent();
        }

        public formSearchSO(formDeliveryOrder form)
        {
            InitializeComponent();
            this.form = form;
            this.conn = form.conn;
            this.id_so = form.id_so;
        }

        private void formSearchSO_Load(object sender, EventArgs e)
        {
            if (!id_so.Equals(""))
            {
                String nama_customer = new OracleCommand("select nama_customer from h_sales_order where id_sales_order = '" + id_so + "'", conn).ExecuteScalar().ToString();

                refreshTable(id_so, nama_customer);
                return;
            }
            refreshTable();
        }

        void refreshTable()
        {
            String cmd = "select id_sales_order, nama_customer, tgl_sales_order from h_sales_order";
            daSalesOrder = new OracleDataAdapter(cmd, conn);
            daSalesOrder.Fill(ds, "SalesOrder");
            dataGridView.DataSource = ds.Tables["SalesOrder"];
        }

        void refreshTable(String id, String keyword)
        {
            String cmd = "select id_sales_order, nama_customer, tgl_sales_order from h_sales_order " +
                "where id_sales_order != '" + id + "' AND " +
                "nama_customer = '" + keyword + "'";
            daSalesOrder = new OracleDataAdapter(cmd, conn);
            daSalesOrder.Fill(ds, "SalesOrder");
            dataGridView.DataSource = ds.Tables["SalesOrder"];
        }

        void refreshTable(String keyword)
        {
            String cmd = "select id_sales_order, nama_customer, tgl_sales_order from h_sales_order " +
                "where id_sales_order = '" + keyword + "' OR " +
                "nama_customer = '" + keyword + "'";
            daSalesOrder = new OracleDataAdapter(cmd, conn);
            daSalesOrder.Fill(ds, "SalesOrder");
            dataGridView.DataSource = ds.Tables["SalesOrder"];
        }

        private void txtKeyword_TextChanged(object sender, EventArgs e)
        {
            ds.Tables["SalesOrder"].Clear();
            if (!id_so.Equals(""))
            {
                refreshTable(id_so, txtKeyword.Text);
                return;
            }
            refreshTable(txtKeyword.Text);
        }

        private void btnGet_Click(object sender, EventArgs e)
        {
            if (idx > -1)
            {
                this.id_so = dataGridView.Rows[idx].Cells[0].Value.ToString();
                this.DialogResult = DialogResult.Yes;
                this.Close();
            }
        }

        int idx = -1;
        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            idx = e.RowIndex;
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            idx = e.RowIndex;
        }
    }
}
