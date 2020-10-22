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
    public partial class formMasterEkspedisi : Form
    {
        public OracleConnection conn;
        OracleDataAdapter daEkspedisi;
        DataSet ds = new DataSet();
        public Object[] data;
        LoginForm form;

        public formMasterEkspedisi()
        {
            InitializeComponent();
        }

        public formMasterEkspedisi(LoginForm form)
        {
            InitializeComponent();
            this.form = form;
        }

        void refreshTable()
        {
            String cmd = "select * from ekspedisi";
            daEkspedisi = new OracleDataAdapter(cmd, conn);
            daEkspedisi.Fill(ds, "ekspedisi");
            dataGridView.DataSource = ds.Tables["ekspedisi"];
        }

        void refreshTable(String keyword)
        {
            String cmd = "select * from ekspedisi where nama_ekspedisi = '" + keyword + "'";
            daEkspedisi = new OracleDataAdapter(cmd, conn);
            daEkspedisi.Fill(ds, "ekspedisi");
            dataGridView.DataSource = ds.Tables["ekspedisi"];
        }

        private void formMasterEkspedisi_Load(object sender, EventArgs e)
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

        private void txtKeyword_TextChanged(object sender, EventArgs e)
        {
            ds.Tables["ekspedisi"].Clear();
            refreshTable(txtKeyword.Text);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            this.form.Show();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            new formInsertEkspedisi(this).ShowDialog();
            ds.Tables["ekspedisi"].Clear();
            refreshTable();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (idx > -1)
            {
                Object[] temp = {
                    ds.Tables["ekspedisi"].Rows[idx][0],
                    ds.Tables["ekspedisi"].Rows[idx][1],
                    ds.Tables["ekspedisi"].Rows[idx][2],
                    ds.Tables["ekspedisi"].Rows[idx][3],
                    ds.Tables["ekspedisi"].Rows[idx][4]
                };
                data = temp;

                new formUpdateEkspedisi(this).ShowDialog();
                ds.Tables["ekspedisi"].Clear();
                refreshTable();
            }
            else
            {
                MessageBox.Show("Pilih lah ekspedisi pada tabel terlebih dahulu");
            }
        }

        void enablingButton(int index)
        {
            if (index > -1)
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

        int idx = -1;

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            idx = e.RowIndex;
            enablingButton(idx);
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            idx = e.RowIndex;
            enablingButton(idx);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (idx > -1)
            {
                try
                {

                    String cmd = "delete from ekspedisi where id_ekspedisi = '" + ds.Tables["ekspedisi"].Rows[idx][0] + "'";
                    new OracleCommand(cmd, conn).ExecuteNonQuery();
                    ds.Tables["ekspedisi"].Clear();
                    refreshTable();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
            }
            else
            {
                MessageBox.Show("Pilih lah ekspedisi pada tabel terlebih dahulu");
            }
        }
    }
}
