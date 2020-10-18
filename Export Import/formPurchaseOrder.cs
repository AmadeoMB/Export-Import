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
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
