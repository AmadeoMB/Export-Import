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
    public partial class formFilter : Form
    {
        public OracleConnection conn;
        formListStock form;
        private OracleDataAdapter daSatuan;
        private OracleDataAdapter daGudang;
        private DataSet ds = new DataSet();
        public Object[] hasil = { };

        public formFilter()
        {
            InitializeComponent();
        }
        public formFilter(formListStock form)
        {
            this.form = form;
            InitializeComponent();
        }

        private void formFilter_Load(object sender, EventArgs e)
        {
            cbPembanding.SelectedIndex = 0;
            cbJenisPPN.SelectedIndex = 0;

            this.cbCategory.DataSource = form.ds.Tables["category"];
            cbCategory.ValueMember = "ID";
            cbCategory.DisplayMember = "Category";
            this.txtKeyword.Text = form.txtKeyword.Text;
            this.cbCategory.SelectedIndex = form.cbCategory.SelectedIndex;

            conn = new OracleConnection("user id=export;password=import;data source=orcl");

            try
            {
                conn.Open();

                daSatuan = new OracleDataAdapter("SELECT DISTINCT satuan_item FROM item", conn);
                daSatuan.Fill(ds, "satuan");
                DataRow newRow = ds.Tables["satuan"].NewRow();
                newRow[0] = "Semua";
                ds.Tables["satuan"].Rows.Add(newRow);
                cbSatuan.DataSource = ds.Tables["satuan"];
                cbSatuan.ValueMember = "satuan_item";
                cbSatuan.DisplayMember = "satuan_item";
                cbSatuan.SelectedIndex = ds.Tables["satuan"].Rows.Count - 1;

                daGudang = new OracleDataAdapter("SELECT id_gudang FROM gudang", conn);
                daGudang.Fill(ds, "lokasi");
                newRow = ds.Tables["lokasi"].NewRow();
                newRow[0] = "Semua";
                ds.Tables["lokasi"].Rows.Add(newRow);
                cbLokasi.DataSource = ds.Tables["lokasi"];
                cbLokasi.ValueMember = "id_gudang";
                cbLokasi.DisplayMember = "id_gudang";
                cbLokasi.SelectedIndex = ds.Tables["lokasi"].Rows.Count - 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;

            String beli = "";
            String jual = "";

            if (checkBoxJual.Checked)
            {
                jual = "Jual";
            }

            if (checkBoxBeli.Checked)
            {
                beli = "Beli";
            }

            if (cbPembanding.SelectedIndex > 0 && !checkBoxJual.Checked && !checkBoxJual.Checked)
            {
                MessageBox.Show("Mohon pilih Harga Jual atau Harga Beli");
                return;
            }

            Object[] temp = {txtKeyword.Text,
            cbCategory.SelectedIndex,
            cbSatuan.Text,
            beli,
            jual,
            cbPembanding.Text,
            numHarga1.Value,
            numHarga2.Value,
            cbLokasi.Text,
            cbJenisPPN.Text};


            this.hasil = temp;
            this.Close();
        }

        private void cbPembanding_DropDownClosed(object sender, EventArgs e)
        {
            if (cbPembanding.Text.Equals("Diantara"))
            {
                numHarga2.Enabled = true;
            }
            else
            {
                numHarga2.Enabled = false;
            }
        }

        private void cbPembanding_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbPembanding.Text.Equals("Diantara"))
            {
                numHarga2.Enabled = true;
            }
            else
            {
                numHarga2.Enabled = false;
            }
        }
    }
}
