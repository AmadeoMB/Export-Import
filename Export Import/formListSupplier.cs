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
    public partial class formListSupplier : Form
    {
        Form form;
        public OracleConnection conn;
        public String[] data;
        private OracleDataAdapter daProvinsi;
        private OracleDataAdapter daSupplier;
        private DataSet ds = new DataSet();
        private int idx = -1;

        public formListSupplier()
        {
            InitializeComponent();
        }

        public formListSupplier(Form form)
        {
            InitializeComponent();
            this.form = form;
        }

        public void refreshTabel()
        {

            string cmd = "select " +
                "id_supplier, nama_supplier, alamat_supplier, " +
                "provinsi_supplier, '0'||no_telp_supplier as no_telp_supplier, " +
                "email_supplier from supplier";

            daSupplier = new OracleDataAdapter(cmd, conn);
            daSupplier.Fill(ds, "supplier");
            dataGridView.DataSource = ds.Tables["supplier"];
        }

        public void refreshTabel(params object[] optional)
        {

            string cmd = "select " +
                "id_supplier, nama_supplier, alamat_supplier, " +
                "provinsi_supplier, '0'||no_telp_supplier as no_telp_supplier, " +
                "email_supplier from supplier where lower(nama_supplier) like '%" + optional[0].ToString().ToLower() + "%'";
            if (Convert.ToInt32(optional[1]) < ds.Tables["provinsi"].Rows.Count - 1 && Convert.ToInt32(optional[1]) > -1)
            {
                cmd += " AND provinsi_supplier = '" + cbProvinsi.SelectedValue + "'";
            }

            daSupplier = new OracleDataAdapter(cmd, conn);
            daSupplier.Fill(ds, "supplier");
            dataGridView.DataSource = ds.Tables["supplier"];
        }

        public void isiCB()
        {
            daProvinsi = new OracleDataAdapter("select distinct provinsi_supplier as provinsi from supplier", conn);
            daProvinsi.Fill(ds, "provinsi");
            DataRow newRow = ds.Tables["provinsi"].NewRow();
            newRow[0] = "Semua";
            ds.Tables["provinsi"].Rows.Add(newRow);
            cbProvinsi.DataSource = ds.Tables["provinsi"];
            cbProvinsi.ValueMember = "provinsi";
            cbProvinsi.DisplayMember = "provinsi";
            cbProvinsi.SelectedIndex = ds.Tables["provinsi"].Rows.Count - 1;
        }

        private void formSupplier_Load(object sender, EventArgs e)
        {
            conn = new OracleConnection("user id=export;password=import;data source=orcl");

            conn.Open();

            this.dataGridView.DefaultCellStyle.Font = new Font("Calibri", 12);
            dataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
            dataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView.ColumnHeadersDefaultCellStyle.Font = new Font("Calibri", 15, FontStyle.Bold);

            
            isiCB();

            refreshTabel(txtKeyword.Text, cbProvinsi.SelectedIndex);
        }

        private void txtKeyword_TextChanged(object sender, EventArgs e)
        {
            ds.Tables["supplier"].Clear();

            refreshTabel(txtKeyword.Text, cbProvinsi.SelectedIndex);
        }

        private void cbProvinsi_DropDownClosed(object sender, EventArgs e)
        {
            ds.Tables["supplier"].Clear();

            refreshTabel(txtKeyword.Text, cbProvinsi.SelectedIndex);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            form.Show();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            new formInsertSupplier(this).ShowDialog();
            ds.Tables["supplier"].Clear();
            refreshTabel();
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            idx = e.RowIndex;
            if (idx > -1)
            {
                btnUpdate.Enabled = true;
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
                    dataGridView.Rows[idx].Cells[5].Value.ToString(),
                };

            data = obj;
            new formUpdateSupplier(this).ShowDialog();
            ds.Tables["supplier"].Clear();

            refreshTabel();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            String hasil = MessageBox.Show( "Yakin mau delete supplier?", "Delete Supplier", MessageBoxButtons.YesNo).ToString();

            if (hasil.Equals("Yes"))
            {
                new OracleCommand("Delete from supplier where id_supplier='" + dataGridView.Rows[idx].Cells[0].Value + "'", conn).ExecuteNonQuery();
                ds.Tables["supplier"].Clear();
                refreshTabel();
            }
        }

        private void pnlBawah_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
