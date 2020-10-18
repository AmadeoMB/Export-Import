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
        public OracleConnection conn;
        OracleDataAdapter daSupplier;
        OracleDataAdapter daGudang;
        OracleDataAdapter daSales;
        OracleDataAdapter daItem;
        OracleDataAdapter daCurrent;
        private Stack<Object[]> done = new Stack<Object[]>(100);
        private Stack<Object[]> undone = new Stack<Object[]>(100);
        DataSet ds;
        int idx = -1;
        int netTotal = 0;
        int klik = 0;
        public formPurchaseOrder()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
        public void isicbsupplier() { 
            daSupplier = new OracleDataAdapter("select id_supplier as ID, nama_supplier as nama, alamat_supplier as alamat from supplier", conn);
            daSupplier.Fill(ds, "supplier");
            cbcreditor.DataSource = ds.Tables["supplier"];
            cbcreditor.ValueMember = "ID";
            cbcreditor.DisplayMember = "ID";
           
        }
        public void isicbGudang() {
            daGudang = new OracleDataAdapter("select id_gudang as ID, nama_gudang as nama from gudang", conn);
            daGudang.Fill(ds, "gudang");
            comboBox1.DataSource = ds.Tables["gudang"];
            comboBox1.ValueMember = "ID";
            comboBox1.DisplayMember = "nama";
        }
        public void isicbSales() {
            daSales = new OracleDataAdapter("select id_staff as ID, nama_staff as nama from staff where id_jabatan = '3'", conn);

            daSales.Fill(ds, "staff");
            comboBox3.DataSource = ds.Tables["staff"];
            comboBox3.ValueMember = "ID";
            comboBox3.DisplayMember = "nama";
        }
        public void isicbCurrent() {
            daCurrent = new OracleDataAdapter("select * from currency", conn);
            daCurrent.Fill(ds, "currency");
            cbCurrent.DataSource = ds.Tables["currency"];
            cbCurrent.ValueMember = "nama_currency";
            cbCurrent.DisplayMember = "nama_currency";
        }
        public void refreshnettotal() {
            netTotal = 0;
            if (klik == -1)
            {
                return;
            }
            else {
                for (int i = 0; i < klik; i++)
                {
                    int harga = Int32.Parse(ds.Tables["item"].Rows[i][8].ToString());
                    netTotal += harga;
                    
                }
                textBox5.Text = netTotal.ToString();
            }
            
        }
        private void formPurchaseOrder_Load(object sender, EventArgs e)
        {
            conn = new OracleConnection("user id=export;password=import;data source=orcl");
            conn.Open();
            ds = new DataSet();
            isicbsupplier();
            isicbGudang();
            isicbSales();
            generatecreateNomerPO();
            isicbCurrent();
            refreshnettotal();
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
        public void InsertItem(Object[] data) {
            int diskon = Convert.ToInt32(data[1]);
            int qty = Convert.ToInt32(data[2]);
            object id_item = data[0];

            String cmd = "select harga_beli_item from item where id_item ='" + id_item + "'";
            int hargaBeli = Convert.ToInt32(new OracleCommand(cmd, conn).ExecuteScalar());
            int subtotal = hargaBeli * qty;

            int totalDiscount = subtotal * diskon / 100;
            subtotal -= totalDiscount;

            cmd = "select jenis_ppn from item where id_item='" + id_item + "'";
            String ppn = new OracleCommand(cmd, conn).ExecuteScalar().ToString();
            int totalPPN = 0;
            if (ppn.Equals("EXC"))
            {
                totalPPN = subtotal * 10 / 100;
                subtotal += totalPPN;
            }
            
            cmd = "select id_item, nama_item, " +
                qty + " as qty_item, " +
                "satuan_item, " +
                hargaBeli + " as harga_beli_item, "+
                "jenis_ppn, " +
                totalPPN + " as total_ppn, " +
                diskon + " as discount, " +
                subtotal + " as subtotal " +
                "from item " +
                "where id_item = '" + id_item + "'";

            daItem = new OracleDataAdapter(cmd, conn);
            daItem.Fill(ds, "item");
            dataGridView1.DataSource = ds.Tables["item"];
        }
        private void Tambah_Click(object sender, EventArgs e)
        {
            formSearchItem search = new formSearchItem(this);
            if (search.ShowDialog() != DialogResult.Cancel)
            {
                InsertItem(search.data);


                Object[] temp = search.data;
                Array.Resize(ref temp, temp.Length + 1);
                temp[3] = "insert";
                done.Push(temp);
                
            }
            klik++;
            refreshnettotal();
        }

        private void Kurang_Click(object sender, EventArgs e)
        {
            if (idx > -1)
            {
                ds.Tables["item"].Rows.RemoveAt(idx);
                klik--;
                refreshnettotal();
            }
            else
            {
                MessageBox.Show("Click salah satu baris pada tabel terlebih dahulu");
            }

        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            if (idx > -1)
            {
                if (idx > 0)
                {
                    Object[] tempBawah = ds.Tables["item"].Rows[idx].ItemArray;
                    Object[] tempAtas = ds.Tables["item"].Rows[idx - 1].ItemArray;

                    ds.Tables["item"].Rows[idx].ItemArray = tempAtas;
                    ds.Tables["item"].Rows[idx - 1].ItemArray = tempBawah;
                }
                else
                {
                    MessageBox.Show("Data sudah berada dipaling atas");
                }
            }
            else
            {
                MessageBox.Show("Click salah satu baris pada tabel terlebih dahulu");
            }
        }
        private void btnDown_Click(object sender, EventArgs e)
        {
            if (idx > -1)
            {
                if (idx < ds.Tables["item"].Rows.Count - 1)
                {
                    Object[] tempAtas = ds.Tables["item"].Rows[idx].ItemArray;
                    Object[] tempBawah = ds.Tables["item"].Rows[idx + 1].ItemArray;

                    ds.Tables["item"].Rows[idx].ItemArray = tempBawah;
                    ds.Tables["item"].Rows[idx + 1].ItemArray = tempAtas;
                }
                else
                {
                    MessageBox.Show("Data sudah berada dipaling bawah");
                }
            }
            else
            {
                MessageBox.Show("Click salah satu baris pada tabel terlebih dahulu");
            }
        }

        private void BtnUndo_Click(object sender, EventArgs e)
        {
            if (done.Count > 0)
            {
                Object[] temp = done.Pop();
                undone.Push(temp);

                if (temp[3].ToString().Equals("insert"))
                {
                    ds.Tables["item"].Rows.RemoveAt(ds.Tables["item"].Rows.Count - 1);
                }
                else
                {
                    InsertItem(temp);
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            idx = e.RowIndex;
        }

        private void cbcreditor_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idx = cbcreditor.SelectedIndex;
            tbnama.Text = ds.Tables["supplier"].Rows[idx][1].ToString();
            textBox1.Text = ds.Tables["supplier"].Rows[idx][2].ToString();
        }

        private void btnRedo_Click(object sender, EventArgs e)
        {
            if (undone.Count > 0)
            {
                Object[] temp = undone.Pop();
                done.Push(temp);

                if (temp[3].ToString().Equals("insert"))
                {
                    InsertItem(temp);
                }
                else
                {
                    ds.Tables["item"].Rows.RemoveAt(ds.Tables["item"].Rows.Count - 1);
                }
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if () {
                textBox6.Text = "mantap";
            }
        }

        private void cbCurrent_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idx = cbCurrent.SelectedIndex;
            textBox7.Text = ds.Tables["currency"].Rows[idx][2].ToString();
        }
    }
}
