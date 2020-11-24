using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Export_Import
{
    public partial class formListCustomer : Form
    {
        formMasterPenjualan form;
        public OracleConnection conn;
        DataSet ds = new DataSet();
        OracleDataAdapter daCustomer;
        public String[] data;
        public String admin = "";

        int idx = -1;

        public formListCustomer()
        {
            InitializeComponent();
            this.conn = new OracleConnection("user id=export;password=import;data source=orcl");
            this.conn.Open();
        }

        public formListCustomer(formMasterPenjualan form)
        {
            InitializeComponent();
            this.form = form;
            this.conn = form.conn;
            this.admin = form.admin;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            form.Show();
        }

        public void refreshTabel()
        {

            string cmd = "select " +
                "id_customer, nama_customer, alamat_customer, " +
                "'0'||no_telp_customer as no_telp_customer, " +
                "email_customer from customer";

            daCustomer = new OracleDataAdapter(cmd, conn);
            daCustomer.Fill(ds, "customer");
            dataGridView.DataSource = ds.Tables["customer"];
        }

        public void refreshTabel(params object[] optional)
        {

            string cmd = "select " +
                "id_customer, nama_customer, alamat_customer, " +
                "'0'||no_telp_customer as no_telp_customer, " +
                "email_customer from customer where " +
                "lower(nama_customer) like '%" + optional[0].ToString().ToLower() + "%' AND " +
                "lower(id_customer) like '%"+ optional[0].ToString().ToLower() +"%'";

            daCustomer = new OracleDataAdapter(cmd, conn);
            daCustomer.Fill(ds, "customer");
            dataGridView.DataSource = ds.Tables["customer"];
        }

        private void formCustomer_Load(object sender, EventArgs e)
        {
            this.Text += " : " + admin;
            this.dataGridView.DefaultCellStyle.Font = new Font("Calibri", 12);
            dataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
            dataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView.ColumnHeadersDefaultCellStyle.Font = new Font("Calibri", 15, FontStyle.Bold);

            try
            {
                refreshTabel();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void txtKeyword_TextChanged(object sender, EventArgs e)
        {
            ds.Tables["customer"].Clear();

            refreshTabel(txtKeyword.Text);
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            new formInsertCustomer().ShowDialog();

            txtKeyword.Text = "";

            ds.Tables["customer"].Clear();
            refreshTabel();
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            idx = e.RowIndex;

            if (idx > -1)
            {
                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;
            }
            else
            {
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            String[] obj =
                {
                    dataGridView.Rows[idx].Cells[0].Value.ToString(),
                    dataGridView.Rows[idx].Cells[1].Value.ToString(),
                    dataGridView.Rows[idx].Cells[2].Value.ToString(),
                    dataGridView.Rows[idx].Cells[3].Value.ToString(),
                    dataGridView.Rows[idx].Cells[4].Value.ToString(),
                };

            data = obj;
            new formUpdateCustomer(this).ShowDialog();
            ds.Tables["customer"].Clear();

            refreshTabel();
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            idx = e.RowIndex;

            if (idx > -1)
            {
                btnDelete.Enabled = true;
                btnUpdate.Enabled = true;
            }
            else
            {
                btnDelete.Enabled = false;
                btnUpdate.Enabled = false;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (idx > -1)
            {
                try
                {

                    String cmd = "delete from customer where id_customer = '" + dataGridView.Rows[idx].Cells[0].Value.ToString() + "'";
                    new OracleCommand(cmd, conn).ExecuteNonQuery();
                    ds.Tables["customer"].Clear();
                    refreshTabel();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
            }
            else
            {
                MessageBox.Show("Pilih lah customer pada tabel terlebih dahulu");
            }
        }
    }
}
