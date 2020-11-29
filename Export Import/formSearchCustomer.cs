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
    public partial class formSearchCustomer : Form
    {
        formSalesOrder form;
        OracleConnection conn;
        DataSet ds = new DataSet();
        OracleDataAdapter daCustomer;
        public Object[] data;

        public formSearchCustomer()
        {
            InitializeComponent();
        }

        public formSearchCustomer(formSalesOrder form)
        {
            InitializeComponent();
            this.form = form;
        }

        void refreshTable() {
            string cmd = "select " +
                "id_customer, nama_customer, alamat_customer, " +
                "'0'||no_telp_customer as no_telp_customer, " +
                "email_customer from customer";

            daCustomer = new OracleDataAdapter(cmd, conn);
            daCustomer.Fill(ds, "customer");
            dataGridView.DataSource = ds.Tables["customer"];
        }

        void refreshTable(String keyword)
        {
            ds.Tables["customer"].Clear();

            string cmd = "select " +
                "id_customer, nama_customer, alamat_customer, " +
                "'0'||no_telp_customer as no_telp_customer, " +
                "email_customer from customer " +
                "where id_customer like '%" + keyword + "%' OR " +
                "nama_customer like '%" + keyword + "%' OR " +
                "alamat_customer like '%" + keyword + "%' OR " +
                "email_customer like '%" + keyword + "%'";

            if (keyword.Length > 1)
            {
                cmd += " OR no_telp_customer like '%" + keyword.Substring(1) + "%'";
            }

            daCustomer = new OracleDataAdapter(cmd, conn);
            daCustomer.Fill(ds, "customer");
            dataGridView.DataSource = ds.Tables["customer"];
        }

        private void formSearchCustomer_Load(object sender, EventArgs e)
        {
            this.conn = form.conn;

            refreshTable();
        }

        private void txtKeyword_TextChanged(object sender, EventArgs e)
        {
            refreshTable(txtKeyword.Text);
        }

        int idx = -1;

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            idx = e.RowIndex;
        }

        private void btnGet_Click(object sender, EventArgs e)
        {
            if (dataGridView.Rows.Count <= 1 || idx == dataGridView.Rows.Count - 1)
            {
                MessageBox.Show("Data kosong");
                return;
            }

            if (idx != -1)
            {
                Object[] temp =
                {
                    ds.Tables["customer"].Rows[idx][0],
                    ds.Tables["customer"].Rows[idx][1],
                    ds.Tables["customer"].Rows[idx][2]
                };

                data = temp;

                this.DialogResult = DialogResult.Yes;
                this.Close();
            }
        }
    }
}
