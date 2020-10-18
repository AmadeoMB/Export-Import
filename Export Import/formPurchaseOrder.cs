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
    public partial class formPurchaseOrder : Form
    {
        OracleConnection conn;
        OracleDataAdapter daSupplier;
        OracleDataAdapter daGudang;
        OracleDataAdapter daSales;
        DataSet ds;
        int idx = -1;
        public formPurchaseOrder()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
        public void isicbsupplier() { 
            daSupplier = new OracleDataAdapter("select id_supplier as ID, nama_supplier as nama from supplier", conn);
            ds = new DataSet();
            daSupplier.Fill(ds, "supplier");
            cbcreditor.DataSource = ds.Tables["supplier"];
            cbcreditor.ValueMember = "ID";
            cbcreditor.DisplayMember = "nama";
        }
        public void isicbGudang() {
            daGudang = new OracleDataAdapter("select id_gudang as ID, nama_gudang as nama from gudang", conn);
            ds = new DataSet();
            daGudang.Fill(ds, "gudang");
            comboBox1.DataSource = ds.Tables["gudang"];
            comboBox1.ValueMember = "ID";
            comboBox1.DisplayMember = "nama";
        }
        public void isicbSales() {
            daSales = new OracleDataAdapter("select id_staff as ID, nama_staff as nama from staff where id_jabatan = '3'", conn);
            ds = new DataSet();
            daSales.Fill(ds, "staff");
            comboBox3.DataSource = ds.Tables["staff"];
            comboBox3.ValueMember = "ID";
            comboBox3.DisplayMember = "nama";
        }
        
        private void formPurchaseOrder_Load(object sender, EventArgs e)
        {
            conn = new OracleConnection("user id=export;password=import;data source=orcl");
            conn.Open();
            isicbsupplier();
            isicbGudang();
            isicbSales();
            generatecreateNomerPO();
        }
        String getNomerPO(String tgl)
        {
            String cmd = "select count(*)+1 from H_purchase_order where id_purchase_order like '" + tgl + "%'";
            int jumlah = Convert.ToInt32(new OracleCommand(cmd, conn).ExecuteScalar());

            if (jumlah < 10)
            {
                return "0" + jumlah;
            }
            else
            {
                return "" + jumlah;
            }
        }
        void generatecreateNomerPO()
        {
            String nomerPO = "PO";
            nomerPO += DateToday.Value.ToString("ddMMyyyy");
            nomerPO += getNomerPO(nomerPO);

            PONO.Text = nomerPO;
        }
        private void Tambah_Click(object sender, EventArgs e)
        {

        }

        private void Kurang_Click(object sender, EventArgs e)
        {
            if (idx > -1)
            {
                ds.Tables["item"].Rows.RemoveAt(idx);
            }
            else
            {
                MessageBox.Show("Click salah satu baris pada tabel terlebih dahulu");
            }
        }

        private void btnUp_Click(object sender, EventArgs e)
        {

        }

        private void btnDown_Click(object sender, EventArgs e)
        {

        }

        private void BtnUndo_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            idx = e.RowIndex;
        }
    }
}
