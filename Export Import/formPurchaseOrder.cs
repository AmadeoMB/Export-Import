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
        formMasterPembelian form;
        OracleDataAdapter daSupplier;
        OracleDataAdapter daGudang;
        OracleDataAdapter daItem;
        OracleDataAdapter daCurrent;
        OracleDataAdapter daship;
        private Stack<Object[]> done = new Stack<Object[]>(100);
        private Stack<Object[]> undone = new Stack<Object[]>(100);
        DataSet ds = new DataSet();
        int idx = -1;
        Int64 netTotal = 0;
        public String admin = "";

        public formPurchaseOrder()
        {
            InitializeComponent();
            this.conn = new OracleConnection("user id=export;password=import;data source=orcl");
            this.conn.Open();
            this.admin = "Melvern Tallall";
        }

        public formPurchaseOrder(formMasterPembelian form)
        {
            InitializeComponent();
            this.form = form;
            this.conn = form.conn;
            this.admin = form.admin;
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
        public void isicbCurrent() {
            daCurrent = new OracleDataAdapter("select * from currency", conn);
            daCurrent.Fill(ds, "currency");
            cbCurrent.DataSource = ds.Tables["currency"];
            cbCurrent.ValueMember = "id_currency";
            cbCurrent.DisplayMember = "nama_currency";
        }
        public void isicbship() {
            daship = new OracleDataAdapter("select * from ekspedisi", conn);
            daship.Fill(ds, "ekspedisi");
            comboBox4.DataSource = ds.Tables["ekspedisi"];
            comboBox4.ValueMember = "id_ekspedisi";
            comboBox4.DisplayMember = "nama_ekspedisi";
        }
        public void refreshnettotal() {
            netTotal = 0;
            Int64 total = 0;
            Int64 itung = dataGridView1.Rows.Count;
            if (itung == 0) {
                return;
            }
            else {
                for (int i = 0; i < dataGridView1.Rows.Count-1; i++)
                {
                    Int64 harga = Int64.Parse(ds.Tables["item"].Rows[i][7].ToString());
                    total += harga;
                }
                txtTotal.Text = total.ToString();
                txtTotalPPN.Text = totalPPN.ToString();
                textBox5.Text = (total + totalPPN).ToString();
            }
        }
        public void refreshlocalnet() {
            Int64 ubahnettotal = Int64.Parse(textBox5.Text);
            Int64 ubahrate = Int64.Parse(textBox7.Text);
            LNTotal.Text = (ubahnettotal / ubahrate).ToString();
        }
        private void formPurchaseOrder_Load(object sender, EventArgs e)
        {
            txtAgent.Text = admin;

            this.dataGridView1.Columns["subtotal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dataGridView1.Columns["harga_beli_item"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.DateToday.Value = DateTime.Today;

            isicbsupplier();
            isicbGudang();
            generatecreateNomerPO();
            isicbCurrent();
            isicbship();
            refreshnettotal();
            refreshlocalnet();
        }
        String getNomerPO(String tgl)
        {
            String cmd = "select count(*)+1 from H_purchase_order where id_purchase_order like '" + tgl + "%'";
            Int64 jumlah = Convert.ToInt64(new OracleCommand(cmd, conn).ExecuteScalar());

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
            nomerPO += DateToday.Value.ToString("/dd/MM/yyyy/");
            nomerPO += getNomerPO(nomerPO);

            PONO.Text = nomerPO;
        }
        Int64 totalPPN = 0;

        public void InsertItem(Object[] data) {
            Int64 diskon = Convert.ToInt64(data[1]);
            Int64 qty = Convert.ToInt64(data[2]);
            object id_item = data[0];

            String cmd = "select harga_beli_item from item where id_item ='" + id_item + "'";
            Int64 hargaBeli = Convert.ToInt64(new OracleCommand(cmd, conn).ExecuteScalar());
            Int64 subtotal = hargaBeli * qty;

            Int64 totalDiscount = subtotal * diskon / 100;
            subtotal -= totalDiscount;

            cmd = "select jenis_ppn from item where id_item='" + id_item + "'";
            String ppn = new OracleCommand(cmd, conn).ExecuteScalar().ToString();
            if (ppn.Equals("EXC"))
            {
                this.totalPPN += subtotal * 10 / 100;
            }
            
            cmd = "select id_item, nama_item, " +
                qty + " as qty_item, " +
                "satuan_item, " +
                hargaBeli + " as harga_beli_item, "+
                "jenis_ppn, " +
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
            refreshnettotal();
            refreshlocalnet();
        }

        private void Kurang_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count <= 1 || idx == dataGridView1.Rows.Count - 1)
            {
                MessageBox.Show("Data kosong");
                return;
            }

            if (idx > -1)
            {
                Object[] temp = {
                    ds.Tables["item"].Rows[idx][0],
                    ds.Tables["item"].Rows[idx][7],
                    ds.Tables["item"].Rows[idx][2],
                    "delete",
                };
                done.Push(temp);

                ds.Tables["item"].Rows.RemoveAt(idx);

                refreshnettotal();
                refreshlocalnet();
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
            refreshnettotal();
            refreshlocalnet();
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
                refreshnettotal();
                refreshlocalnet();
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
                    for (int i = 0; i < ds.Tables["item"].Rows.Count; i++)
                    {
                        if (ds.Tables["item"].Rows[i][0].ToString().Equals(temp[0]))
                        {
                            ds.Tables["item"].Rows.RemoveAt(i);
                            break;
                        }
                    }
                }
                else
                {
                    InsertItem(temp);
                }
                refreshnettotal();
                refreshlocalnet();
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
                    for (int i = 0; i < ds.Tables["item"].Rows.Count; i++)
                    {
                        if (ds.Tables["item"].Rows[i][0].ToString().Equals(temp[0]))
                        {
                            ds.Tables["item"].Rows.RemoveAt(i);
                            break;
                        }
                    }
                }
                refreshnettotal();
                refreshlocalnet();
            }
        }

        Boolean saved = false;

        void save()
        {
            //kurang pengecekan textbox atau combobox
            //buat header PO
            Int64 lntot = Int64.Parse(LNTotal.Text);
            Int64 tot = Int64.Parse(textBox5.Text);
            Int64 total = Int64.Parse(txtTotal.Text);
            Int64 totalPPN = Int64.Parse(txtTotalPPN.Text);
            Int64 rat = Int64.Parse(textBox7.Text);
            string a = comboBox2.SelectedItem.ToString();
            string b = a.Substring(0, 1);
            Int64 c = Int64.Parse(b);
            string sales = new OracleCommand("select id_staff from staff where nama_staff = '" + admin + "'", conn).ExecuteScalar().ToString();

            OracleCommand cmd2;
            cmd2 = new OracleCommand("insert Int64o H_PURCHASE_ORDER values(:idp, :ids, :idst, :idg, :nama, :alamat, :tgl, :creditterm, :shipvia, :currencypo, :rate, :total, :totalPPN, :totalh, :totalhc)", conn);
            cmd2.Parameters.Add(":idp", PONO.Text);
            cmd2.Parameters.Add(":ids", cbcreditor.SelectedValue);
            cmd2.Parameters.Add(":idst", sales);
            cmd2.Parameters.Add(":idg", comboBox1.SelectedValue);
            cmd2.Parameters.Add(":nama", tbnama.Text);
            cmd2.Parameters.Add(":alamat", textBox1.Text);
            cmd2.Parameters.Add(":tgl", DateToday.Value);
            cmd2.Parameters.Add(":creditterm", c);
            cmd2.Parameters.Add(":shipvia", comboBox4.SelectedValue);
            cmd2.Parameters.Add(":currencypo", cbCurrent.SelectedValue);
            cmd2.Parameters.Add(":rate", rat);
            cmd2.Parameters.Add(":total", total);
            cmd2.Parameters.Add(":totalPPN", totalPPN);
            cmd2.Parameters.Add(":totalh", tot);
            cmd2.Parameters.Add(":totalhc", lntot);
            cmd2.ExecuteNonQuery();

            //buat detail PO (belum jadi sama sekali)

            OracleCommand cmd3;
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                string nama = ds.Tables["item"].Rows[i][1].ToString();
                string iditems = ds.Tables["item"].Rows[i][0].ToString();
                string qtyy = ds.Tables["item"].Rows[i][2].ToString();
                Int64 qtty = Int64.Parse(qtyy);
                string jeniss = ds.Tables["item"].Rows[i][3].ToString();
                string hargas = ds.Tables["item"].Rows[i][4].ToString();
                Int64 hargass = Int64.Parse(hargas);
                string diskoun = ds.Tables["item"].Rows[i][6].ToString();
                Int64 discroun = Int64.Parse(diskoun);
                string jenisppn = ds.Tables["item"].Rows[i][5].ToString();
                string subtotal = ds.Tables["item"].Rows[i][7].ToString();
                Int64 stotal = Int64.Parse(subtotal);
                cmd3 = new OracleCommand("insert Int64o D_PURCHASE_ORDER values(:iditem, :idpo,:nama,:qty,:jeniss,:hargas,:diskon,:jenisppn,:subtotal)", conn);
                cmd3.Parameters.Add(":iditem", iditems);
                cmd3.Parameters.Add(":idpo", PONO.Text);
                cmd3.Parameters.Add(":nama", nama);
                cmd3.Parameters.Add(":qty", qtty);
                cmd3.Parameters.Add(":jeniss", jeniss);
                cmd3.Parameters.Add(":hargas", hargass);
                cmd3.Parameters.Add(":diskon", discroun);
                cmd3.Parameters.Add(":jenisppn", jenisppn);
                cmd3.Parameters.Add(":subtotal", stotal);
                cmd3.ExecuteNonQuery();
            }

            saved = true;

            MessageBox.Show("Berhasil  Menyimpan");
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex < 0)
            {
                MessageBox.Show("Pilih credit term tolong ya!!");
                return;
            }

            if (saved)
            {
                if (MessageBox.Show("Anda sudah meng-save apakah anda mau meng-update dokumen terakhir?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    overwrite();
                }
            }
            else
            {
                save();
            }
        }

        private void cbCurrent_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idx = cbCurrent.SelectedIndex;
            textBox7.Text = ds.Tables["currency"].Rows[idx][2].ToString();
            if (textBox5.Text != "") {
                refreshlocalnet();
            }
            
        }

        void overwrite()
        {
            if (comboBox2.SelectedIndex < 0)
            {
                MessageBox.Show("Mohon pilih credit term");
                return;
            }
            if (comboBox4.SelectedIndex < 0)
            {
                MessageBox.Show("Mohon pilih ship via");
                return;
            }
            //kurang pengecekan textbox atau combobox
            //buat header PO
            Int64 lntot = Int64.Parse(LNTotal.Text);
            Int64 tot = Int64.Parse(textBox5.Text);
            Int64 total = Int64.Parse(txtTotal.Text);
            Int64 totalPPN = Int64.Parse(txtTotalPPN.Text);
            Int64 rat = Int64.Parse(textBox7.Text);
            string a = comboBox2.SelectedItem.ToString();
            string b = a.Substring(0, 1);
            Int64 c = Int64.Parse(b);
            string sales = new OracleCommand("select id_staff from staff where nama_staff = '" + admin + "'", conn).ExecuteScalar().ToString();

            OracleCommand cmd2;
            cmd2 = new OracleCommand("update H_PURCHASE_ORDER " +
                "set " +
                "id_supplier = :ids, " +
                "id_staff = :idst, " +
                "id_gudang = :idg, " +
                "nama_supplier = :nama, " +
                "alamat_supplier = :alamat, " +
                "tgl_purchase_order = :tgl, " +
                "credit_term_purchase_order = :creditterm, " +
                "ship_via = :shipvia, " +
                "currency_purchase_order = :currencypo, " +
                "rate = :rate, " +
                "total = :total, " +
                "total_ppn = :totalppn, " +
                "total_harga = :totalh, " +
                "total_harga_convert = :totalhc " +
                "where id_purchase_order = '" + PONO.Text + "'", conn);
            cmd2.Parameters.Add(":ids", cbcreditor.SelectedValue);
            cmd2.Parameters.Add(":idst", sales);
            cmd2.Parameters.Add(":idg", comboBox1.SelectedValue);
            cmd2.Parameters.Add(":nama", tbnama.Text);
            cmd2.Parameters.Add(":alamat", textBox1.Text);
            cmd2.Parameters.Add(":tgl", DateToday.Value);
            cmd2.Parameters.Add(":creditterm", c);
            cmd2.Parameters.Add(":shipvia", comboBox4.SelectedValue);
            cmd2.Parameters.Add(":currencypo", cbCurrent.SelectedValue);
            cmd2.Parameters.Add(":rate", rat);
            cmd2.Parameters.Add(":total", total);
            cmd2.Parameters.Add(":totalppn", totalPPN);
            cmd2.Parameters.Add(":totalh", tot);
            cmd2.Parameters.Add(":totalhc", lntot);
            cmd2.ExecuteNonQuery();

            //Delete
            new OracleCommand("delete from d_purchase_order where id_purchase_order = '" + PONO.Text + "'", conn).ExecuteNonQuery();

            OracleCommand cmd3;
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                string nama = ds.Tables["item"].Rows[i][1].ToString();
                string iditems = ds.Tables["item"].Rows[i][0].ToString();
                string qtyy = ds.Tables["item"].Rows[i][2].ToString();
                Int64 qtty = Int64.Parse(qtyy);
                string jeniss = ds.Tables["item"].Rows[i][3].ToString();
                string hargas = ds.Tables["item"].Rows[i][4].ToString();
                Int64 hargass = Int64.Parse(hargas);
                string diskoun = ds.Tables["item"].Rows[i][6].ToString();
                Int64 discroun = Int64.Parse(diskoun);
                string jenisppn = ds.Tables["item"].Rows[i][5].ToString();
                string subtotal = ds.Tables["item"].Rows[i][7].ToString();
                Int64 stotal = Int64.Parse(subtotal);
                cmd3 = new OracleCommand("insert Int64o D_PURCHASE_ORDER values(:iditem, :idpo,:nama,:qty,:jeniss,:hargas,:diskon,:jenisppn,:subtotal)", conn);
                cmd3.Parameters.Add(":iditem", iditems);
                cmd3.Parameters.Add(":idpo", PONO.Text);
                cmd3.Parameters.Add(":nama", nama);
                cmd3.Parameters.Add(":qty", qtty);
                cmd3.Parameters.Add(":jeniss", jeniss);
                cmd3.Parameters.Add(":hargas", hargass);
                cmd3.Parameters.Add(":diskon", discroun);
                cmd3.Parameters.Add(":jenisppn", jenisppn);
                cmd3.Parameters.Add(":subtotal", stotal);
                cmd3.ExecuteNonQuery();
            }

            saved = true;

            MessageBox.Show("Berhasil  Menyimpan");
        }

        private void button14_Click(object sender, EventArgs e)
        {
            this.Close();
            form.Show();
        }

        public String id_po = "";

        private void button12_Click(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex < 0)
            {
                MessageBox.Show("Mohon pilih credit term");
                return;
            }
            if (comboBox4.SelectedIndex < 0)
            {
                MessageBox.Show("Mohon pilih ship via");
                return;
            }
            if (saved)
            {
                if (MessageBox.Show("Anda sudah meng-save apakah anda mau meng-update dokumen terakhir?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    overwrite();
                }
            }
            else
            {
                save();
            }
            this.id_po = PONO.Text;

            new formPreviewPO(this).ShowDialog();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
