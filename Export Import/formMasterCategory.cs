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
    public partial class formMasterCategory : Form
    {
        LoginForm form;
        public OracleConnection conn;
        private OracleDataAdapter daJabatan;
        private DataSet ds = new DataSet();

        public formMasterCategory()
        {
            InitializeComponent();
        }

        public formMasterCategory(LoginForm form)
        {
            InitializeComponent();
            this.form = form;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            form.Show();
        }

        public void refreshTabel()
        {
            string cmd = "select id_category as ID, nama_category as Nama from category";

            daJabatan = new OracleDataAdapter(cmd, conn);
            daJabatan.Fill(ds, "category");
            dataGridView.DataSource = ds.Tables["category"];
        }

        private void formMasterJabatan_Load(object sender, EventArgs e)
        {
            conn = form.conn;

            try
            {
                conn.Open();

                refreshTabel();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            conn.Close();
            new formInsertCategory(this).ShowDialog();

            conn.Open();
            ds.Tables["category"].Clear();
            refreshTabel();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            conn.Close();
            new formUpdateCategory(this).ShowDialog();

            conn.Open();
            ds.Tables["category"].Clear();
            refreshTabel();
        }

        public String nama = "";
        int idx = -1;

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            nama = dataGridView.Rows[e.RowIndex].Cells[1].Value.ToString();

            idx = e.RowIndex;

            btnDelete.Enabled = true;
            btnUpdate.Enabled = true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (idx != -1)
            {
                OracleCommand cmd = new OracleCommand("delete from category where id_category = '" + dataGridView.Rows[idx].Cells[0].Value + "'", conn);

                if (DialogResult.Yes == MessageBox.Show("Anda yakin mau delete category " + dataGridView.Rows[idx].Cells[1].Value, "Confirmation", MessageBoxButtons.YesNo))
                {
                    cmd.ExecuteNonQuery();//ini buat insert update delete

                    ds.Tables["category"].Clear();
                    refreshTabel();
                }
            }
        }
    }
}
