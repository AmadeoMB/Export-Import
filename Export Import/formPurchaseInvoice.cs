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
        public string id_po = "";
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
        void isiDataItem(String id)
        {
            String cmd = "select * from d_purchase_order where id_purchase_order = '" + id + "'";
            OracleDataReader reader = new OracleCommand(cmd, conn).ExecuteReader();
            while (reader.Read())
            {
                DataRow newRow = ds.Tables["item"].NewRow();
                newRow[0] = reader.GetValue(0).ToString();
                newRow[1] = reader.GetValue(1).ToString();
                newRow[2] = reader.GetValue(2).ToString();
                newRow[3] = reader.GetValue(3).ToString();
                newRow[4] = reader.GetValue(4).ToString();
                newRow[5] = reader.GetValue(5).ToString();
                newRow[6] = reader.GetValue(6).ToString();
                newRow[7] = reader.GetValue(7).ToString();
                newRow[8] = reader.GetValue(8).ToString();
                newRow[9] = reader.GetValue(9).ToString();
                newRow[10] = reader.GetValue(10).ToString();
                ds.Tables["item"].Rows.Add(newRow);
            }
            dataGridView1.DataSource = ds.Tables["item"];
        }
        private void button13_Click(object sender, EventArgs e)
        {
            formSearchPO search = new formSearchPO(this);
            if (search.ShowDialog() == DialogResult.Yes)
            {
                if (!this.id_po.Equals(""))
                {
                    isiDataItem(search.id_po);
                }
                else
                {
                    MessageBox.Show(search.id_po);
                    this.id_po = search.id_po;
                    MessageBox.Show(this.id_po);
                    //ambilDataSO(this.id_po);
                }
            }
        }
    }
}
