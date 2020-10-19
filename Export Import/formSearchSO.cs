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

        public formSearchSO()
        {
            InitializeComponent();
        }

        public formSearchSO(formDeliveryOrder form)
        {
            InitializeComponent();
            this.form = form;
            this.conn = form.conn;
        }

        private void formSearchSO_Load(object sender, EventArgs e)
        {
            refreshTable();
        }

        void refreshTable()
        {
            String cmd = "select id_sales_order, nama_customer from h_sales_order";
            daSalesOrder = new OracleDataAdapter(cmd, conn);
            daSalesOrder.Fill(ds, "SalesOrder");
            dataGridView.DataSource = ds.Tables["SalesOrder"];
        }

        void refreshTable(String keyword)
        {
            String cmd = "select id_sales_order, nama_customer from h_sales_order " +
                "where id_sales_order = '" + keyword + "' OR " +
                "nama_customer = '" + keyword + "'";
            daSalesOrder = new OracleDataAdapter(cmd, conn);
            daSalesOrder.Fill(ds, "SalesOrder");
            dataGridView.DataSource = ds.Tables["SalesOrder"];
        }

        private void txtKeyword_TextChanged(object sender, EventArgs e)
        {
            ds.Tables["SalesOrder"].Clear();
            refreshTable(txtKeyword.Text);
        }
    }
}
