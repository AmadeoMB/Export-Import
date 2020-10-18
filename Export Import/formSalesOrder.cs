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
    public partial class formSalesOrder : Form
    {
        public OracleConnection conn;
        private formMasterPenjualan master;
        private OracleDataAdapter daCustomer;
        private OracleDataAdapter daStaff;
        private OracleDataAdapter daGudang;
        private OracleDataAdapter daItem;
        private DataSet ds = new DataSet();
        private Stack<Object[]> done = new Stack<Object[]>(100);
        private Stack<Object[]> undone = new Stack<Object[]>(100);
        private string id_cust;

        public formSalesOrder()
        {
            InitializeComponent();
        }

        public formSalesOrder(formMasterPenjualan master, string id_cust = "")
        {
            InitializeComponent();
            txtNamaCust.Text = id_cust;
            this.master = master;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            master.Show();
        }

        private void pnlBawah_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            formSearchCustomer search = new formSearchCustomer(this);

            if (search.ShowDialog() != DialogResult.Cancel)
            {
                cbIdCust.SelectedValue = search.data[0];
                txtNamaCust.Text = search.data[1].ToString();
                txtAlamatCust.Text = search.data[2].ToString();
            }
        }

        void isiCBCustomer() {
            String cmd = "select id_customer, nama_customer, alamat_customer from customer";
            daCustomer = new OracleDataAdapter(cmd, conn);
            daCustomer.Fill(ds, "customer");
            cbIdCust.DataSource = ds.Tables["customer"];
            cbIdCust.DisplayMember = "id_customer";
            cbIdCust.ValueMember = "id_customer";
        }

        void isiCBGudang() {
            String cmd = "select id_gudang, nama_gudang, alamat_gudang from gudang";
            daGudang = new OracleDataAdapter(cmd, conn);
            daGudang.Fill(ds, "gudang");
            cbGudang.DataSource = ds.Tables["gudang"];
            cbGudang.DisplayMember = "nama_gudang";
            cbGudang.ValueMember = "id_gudang";
        }

        String getNomerSO(String id) {
            String cmd = "select count(*)+1 from H_Sales_Order where id_sales_order like '" + id + "%'";
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

        void generatecreateNomerSO() {
            String nomerSO = "SO";
            nomerSO += dateSO.Value.ToString("ddMMyyyy");
            nomerSO += getNomerSO(nomerSO);

            txtIdSO.Text = nomerSO;
        }

        void isiCBSales() {
            String cmd = "select nama_staff from staff where id_jabatan = 5";
            daStaff = new OracleDataAdapter(cmd, conn);
            daStaff.Fill(ds, "staff");
            cbStaff.DataSource = ds.Tables["staff"];
            cbStaff.DisplayMember = "nama_staff";
            cbStaff.ValueMember = "nama_staff";
        }

        private void formSalesOrder_Load(object sender, EventArgs e)
        {
            conn = new OracleConnection("user id=export;password=import;data source=orcl");

            try
            {
                conn.Open();

                isiCBCustomer();
                isiCBCurrency();
                isiCBGudang();
                isiCBSales();
                generatecreateNomerSO();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }

        private void cbIdCust_DropDownClosed(object sender, EventArgs e)
        {
            int idx = cbIdCust.SelectedIndex;
            txtNamaCust.Text = ds.Tables["customer"].Rows[idx][1].ToString();
            txtAlamatCust.Text = ds.Tables["customer"].Rows[idx][2].ToString();
        }

        void insertItem(Object[] data)
        {
            int discount = Convert.ToInt32(data[1]);
            int qty = Convert.ToInt32(data[2]);
            object id_item = data[0];

            //Hitung Subtotal Kotor
            String cmd = "select harga_jual_item from item where id_item ='" + id_item + "'";
            int hargaJual = Convert.ToInt32(new OracleCommand(cmd, conn).ExecuteScalar());
            int subtotal = hargaJual * qty;

            //Hitung Discount
            int totalDiscount = subtotal * discount / 100;
            subtotal -= totalDiscount;

            //Hitung PPN
            cmd = "select jenis_ppn from item where id_item='" + id_item + "'";
            String ppn = new OracleCommand(cmd, conn).ExecuteScalar().ToString();
            int totalPPN = 0;
            if (ppn.Equals("EXC"))
            {
                totalPPN = subtotal * 10 / 100;
                subtotal += totalPPN;
            }

            //Hitung berat
            cmd = "select berat_item from item where id_item='" + id_item + "'";
            int berat = Convert.ToInt32(new OracleCommand(cmd, conn).ExecuteScalar());
            int beratTotal = berat * qty;

            cmd = "select id_item, nama_item, " +
                qty + " as qty_item, " +
                "satuan_item, " +
                hargaJual + " as harga_jual_item, " +
                beratTotal + " as berat, " +
                "jenis_ppn, " +
                totalPPN + " as total_ppn, " +
                discount + " as discount, " +
                subtotal + " as subtotal " +
                "from item " +
                "where id_item = '" + id_item + "'";

            daItem = new OracleDataAdapter(cmd, conn);
            daItem.Fill(ds, "item");
            dataGridView.DataSource = ds.Tables["item"];
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            formSearchItem search = new formSearchItem(this);

            if (search.ShowDialog() != DialogResult.Cancel)
            {
                insertItem(search.data);


                Object[] temp = search.data;
                Array.Resize(ref temp, temp.Length+1);
                temp[3] = "insert";
                done.Push(temp);

                refreshTotal();
            }
        }

        int idx = -1;

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            idx = e.RowIndex;
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            if (idx > -1)
            {
                ds.Tables["item"].Rows.RemoveAt(idx);
                refreshTotal();
            }
            else
            {
                MessageBox.Show("Click salah satu baris pada tabel terlebih dahulu");
            }
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            idx = e.RowIndex;
        }

        private void btnMoveUp_Click(object sender, EventArgs e)
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

        private void btnMoveDown_Click(object sender, EventArgs e)
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

        private void btnUndo_Click(object sender, EventArgs e)
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
                    insertItem(temp);
                }
                refreshTotal();
            }
        }

        private void btnRedo_Click(object sender, EventArgs e)
        {
            if (undone.Count > 0)
            {
                Object[] temp = undone.Pop();
                done.Push(temp);

                if (temp[3].ToString().Equals("insert"))
                {
                    insertItem(temp);
                }
                else
                {
                    ds.Tables["item"].Rows.RemoveAt(ds.Tables["item"].Rows.Count - 1);
                }
                refreshTotal();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            String id_customer = cbIdCust.SelectedValue + "";
            String id_gudang = cbGudang.SelectedValue + "";
            String id_SO = txtIdSO.Text;
            DateTime tanggalSO = dateSO.Value;
            String creditTerm = cbCreditTerm.Text;
            String shipVia = cbShip.Text;
            String shipInfo = txtShip.Text;

        }

        void refreshTotal()
        {
            int total = 0;
            for (int i = 0; i < ds.Tables["item"].Rows.Count; i++)
            {
                total += Convert.ToInt32(ds.Tables["item"].Rows[i][9]);
            }
            txtTotalHarga.Text = "Rp " + total;

            txtRate.Text = "1 : " + ds.Tables["currency"].Rows[cbCurrency.SelectedIndex][2].ToString();
            int totalRp = total;
            int rate = Convert.ToInt32(ds.Tables["currency"].Rows[cbCurrency.SelectedIndex][2]);

            txtTotalHargaConvert.Text = ds.Tables["currency"].Rows[cbCurrency.SelectedIndex][0] + " " + (totalRp / rate);
        }

        private void cbIdCust_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idx = cbIdCust.SelectedIndex;
            txtNamaCust.Text = ds.Tables["customer"].Rows[idx][1].ToString();
            txtAlamatCust.Text = ds.Tables["customer"].Rows[idx][2].ToString();
        }

        void isiCBCurrency()
        {
            String cmd = "select * from currency";
            new OracleDataAdapter(cmd, conn).Fill(ds, "currency");
            cbCurrency.DataSource = ds.Tables["currency"];
            cbCurrency.DisplayMember = "nama_currency";
            cbCurrency.ValueMember = "rate";
        }

        private void cbCurrency_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtRate.Text = "1 : " + ds.Tables["currency"].Rows[cbCurrency.SelectedIndex][2].ToString();
            int totalRp = Convert.ToInt32(txtTotalHarga.Text.Substring(3));
            int rate = Convert.ToInt32(ds.Tables["currency"].Rows[cbCurrency.SelectedIndex][2]);

            txtTotalHargaConvert.Text = ds.Tables["currency"].Rows[cbCurrency.SelectedIndex][0] + " " + (totalRp / rate) ;
        }
    }
}
