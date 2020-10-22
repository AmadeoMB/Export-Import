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
    public partial class formMasterStaff : Form
    {
        Form form;
        public OracleConnection conn;
        public String[] data;
        private OracleDataAdapter daUser;
        private OracleDataAdapter daJabatan;
        private DataSet ds = new DataSet();
        private int idx = -1;

        public formMasterStaff()
        {
            InitializeComponent();
        }

        public formMasterStaff(Form form)
        {
            InitializeComponent();
            this.form = form;
        }

        public void refreshTabel()
        {
            string cmd = "select id_staff, nama_staff, alamat_staff, " +
                "email_staff, tgl_lahir_staff,  tgl_masuk, " +
                "'0'||nomer_telp_staff as nomer_telp_staff, username_staff, nm_jabatan " +
                "from staff s join jabatan j on s.id_jabatan = j.id_jabatan";

            daUser = new OracleDataAdapter(cmd, conn);
            daUser.Fill(ds, "user");
            dataGridView.DataSource = ds.Tables["user"];
        }

        public void refreshTabel(String nama, int jabatan)
        {
            string cmd = "select id_staff, nama_staff, alamat_staff, " +
                "email_staff, tgl_lahir_staff,  tgl_masuk, " +
                "'0'||nomer_telp_staff as nomer_telp_staff, username_staff, nm_jabatan " +
                "from staff s join jabatan j on s.id_jabatan = j.id_jabatan " +
                "where LOWER(nama_staff) like '%" + nama.ToLower() + "%' ";

            if (jabatan != -1)
            {
                cmd += "AND s.id_jabatan = " + jabatan;
            }

            daUser = new OracleDataAdapter(cmd, conn);
            daUser.Fill(ds, "user");
            dataGridView.DataSource = ds.Tables["user"];
        }

        public void isiCB()
        {
            string cmd = "select * from jabatan";

            daJabatan = new OracleDataAdapter(cmd, conn);
            daJabatan.Fill(ds, "jabatan");
            cbJabatan.DataSource = ds.Tables["jabatan"];
            cbJabatan.DisplayMember = "nm_jabatan";
            cbJabatan.ValueMember = "id_jabatan";

            DataRow newRow = ds.Tables["jabatan"].NewRow();
            newRow[0] = -1;
            newRow[1] = "Semua";
            ds.Tables["jabatan"].Rows.Add(newRow);

            cbJabatan.SelectedIndex = ds.Tables["jabatan"].Rows.Count - 1;
        }

        private void formMasterUser_Load(object sender, EventArgs e)
        {
            conn = new OracleConnection("user id=export;password=import;data source=orcl");

            conn.Open();

            this.dataGridView.DefaultCellStyle.Font = new Font("Calibri", 12);
            dataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
            dataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView.ColumnHeadersDefaultCellStyle.Font = new Font("Calibri", 15, FontStyle.Bold);

            refreshTabel();
            isiCB();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            new formInsertStaff(this).ShowDialog();
            ds.Tables["user"].Clear();
            refreshTabel();
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
                    dataGridView.Rows[idx].Cells[5].Value.ToString(),
                    dataGridView.Rows[idx].Cells[6].Value.ToString(),
                    dataGridView.Rows[idx].Cells[7].Value.ToString(),
                    dataGridView.Rows[idx].Cells[8].Value.ToString(),
                };

            data = obj;
            new formUpdateStaff(this).ShowDialog();
            ds.Tables["user"].Clear();

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
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (idx != -1)
            {
                OracleCommand cmd2;
                cmd2 = new OracleCommand("delete from staff where id_staff = '" +
                        dataGridView.Rows[idx].Cells[0].Value.ToString() + "'", conn);
                cmd2.ExecuteNonQuery();//ini buat insert update delete
                ds.Tables["user"].Clear();
                refreshTabel();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            form.Show();
        }

        private void txtKeyword_TextChanged(object sender, EventArgs e)
        {
            ds.Tables["user"].Clear();

            refreshTabel(txtKeyword.Text, Convert.ToInt32(cbJabatan.SelectedValue));
        }

        private void cbJabatan_DropDownClosed(object sender, EventArgs e)
        {
            ds.Tables["user"].Clear();

            refreshTabel(txtKeyword.Text, Convert.ToInt32(cbJabatan.SelectedValue));
        }
    }
}
