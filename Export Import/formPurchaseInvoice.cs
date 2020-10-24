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
    public partial class formPurchaseInvoice : Form
    {
        public OracleConnection conn;
        DataSet ds;
        OracleDataAdapter daSupplier;
        OracleDataAdapter daGudang;
        public formPurchaseInvoice()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
        public void isicbsupplier()
        {
            daSupplier = new OracleDataAdapter("select id_supplier as ID, nama_supplier as nama, alamat_supplier as alamat from supplier", conn);
            daSupplier.Fill(ds, "supplier");
            cbcreditor.DataSource = ds.Tables["supplier"];
            cbcreditor.ValueMember = "ID";
            cbcreditor.DisplayMember = "ID";

        }
        public void isicbGudang()
        {
            daGudang = new OracleDataAdapter("select id_gudang as ID, nama_gudang as nama from gudang", conn);
            daGudang.Fill(ds, "gudang");
            comboBox1.DataSource = ds.Tables["gudang"];
            comboBox1.ValueMember = "ID";
            comboBox1.DisplayMember = "nama";
        }
        String getNomerPI(String tgl)
        {
            String cmd = "select count(*)+1 from H_purchase_invoice where id_purchase_invoice like '" + tgl + "%'";
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
        void generatecreateNomerPI()
        {
            String nomerPI = "PI";
            nomerPI += DateToday.Value.ToString("ddMMyyyy");
            nomerPI += getNomerPI(nomerPI);

            PINO.Text = nomerPI;
        }
        private void formPurchaseInvoice_Load(object sender, EventArgs e)
        {
            conn = new OracleConnection("user id=export;password=import;data source=orcl");
            conn.Open();
            ds = new DataSet();
            isicbsupplier();
            isicbGudang();
            generatecreateNomerPI();
        }

        private void cbcreditor_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idx = cbcreditor.SelectedIndex;
            tbnama.Text = ds.Tables["supplier"].Rows[idx][1].ToString();
            textBox1.Text = ds.Tables["supplier"].Rows[idx][2].ToString();
        }

        private void button13_Click(object sender, EventArgs e)
        {

        }
    }
}
