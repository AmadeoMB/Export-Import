﻿using Oracle.DataAccess.Client;
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
        OracleDataAdapter daSales;
        OracleDataAdapter daItem;
        OracleDataAdapter daCurrent;
        OracleDataAdapter daship;
        private Stack<Object[]> done = new Stack<Object[]>(100);
        private Stack<Object[]> undone = new Stack<Object[]>(100);
        DataSet ds = new DataSet();
        int idx = -1;
        int netTotal = 0;
        public String admin = "";

        public formPurchaseOrder()
        {
            InitializeComponent();
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
            int itung = dataGridView1.Rows.Count;
            if (itung == 0) {
                return;
            }
            else {
                for (int i = 0; i < dataGridView1.Rows.Count-1; i++)
                {
                    int harga = Int32.Parse(ds.Tables["item"].Rows[i][8].ToString());
                    netTotal += harga;

                }
                textBox5.Text = netTotal.ToString();
            }
        }
        public void refreshlocalnet() {
            int ubahnettotal = Int32.Parse(textBox5.Text);
            int ubahrate = Int32.Parse(textBox7.Text);
            LNTotal.Text = (ubahnettotal / ubahrate).ToString();
        }
        private void formPurchaseOrder_Load(object sender, EventArgs e)
        {
            txtAgent.Text = admin;

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
            refreshnettotal();
            refreshlocalnet();
        }

        private void Kurang_Click(object sender, EventArgs e)
        {
            if (idx > -1)
            {
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
                    ds.Tables["item"].Rows.RemoveAt(ds.Tables["item"].Rows.Count - 1);
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
                    ds.Tables["item"].Rows.RemoveAt(ds.Tables["item"].Rows.Count - 1);
                }
            }
            refreshnettotal();
            refreshlocalnet();
        }

        Boolean saved = false;

        void save()
        {
            //kurang pengecekan textbox atau combobox
            //buat header PO
            int lntot = Int32.Parse(LNTotal.Text);
            int tot = Int32.Parse(textBox5.Text);
            int rat = Int32.Parse(textBox7.Text);
            string a = comboBox2.SelectedItem.ToString();
            string b = a.Substring(0, 1);
            int c = Int32.Parse(b);
            string sales = new OracleCommand("select id_staff from staff where nama_staff = '" + admin + "'", conn).ExecuteScalar().ToString();

            OracleCommand cmd2;
            cmd2 = new OracleCommand("insert into H_PURCHASE_ORDER values(:idp, :ids, :idst, :idg, :nama, :alamat, :tgl, :creditterm, :shipvia, :currencypo, :rate, :totalh, :totalhc)", conn);
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
                int qtty = Int32.Parse(qtyy);
                string jeniss = ds.Tables["item"].Rows[i][3].ToString();
                string hargas = ds.Tables["item"].Rows[i][4].ToString();
                int hargass = Int32.Parse(hargas);
                string diskoun = ds.Tables["item"].Rows[i][7].ToString();
                int discroun = Int32.Parse(diskoun);
                string jenisppn = ds.Tables["item"].Rows[i][5].ToString();
                string totalppn = ds.Tables["item"].Rows[i][6].ToString();
                int tppn = Int32.Parse(totalppn);
                string subtotal = ds.Tables["item"].Rows[i][8].ToString();
                int stotal = Int32.Parse(subtotal);
                cmd3 = new OracleCommand("insert into D_PURCHASE_ORDER values(:iditem, :idpo,:nama,:qty,:jeniss,:hargas,:diskon,:jenisppn,:totalppn,:subtotal)", conn);
                cmd3.Parameters.Add(":iditem", iditems);
                cmd3.Parameters.Add(":idpo", PONO.Text);
                cmd3.Parameters.Add(":nama", nama);
                cmd3.Parameters.Add(":qty", qtty);
                cmd3.Parameters.Add(":jeniss", jeniss);
                cmd3.Parameters.Add(":hargas", hargass);
                cmd3.Parameters.Add(":diskon", discroun);
                cmd3.Parameters.Add(":jenisppn", jenisppn);
                cmd3.Parameters.Add(":totalppn", tppn);
                cmd3.Parameters.Add(":subtotal", stotal);
                cmd3.ExecuteNonQuery();
            }

            saved = true;

            MessageBox.Show("Berhasil  Menyimpan");
        }

        private void button11_Click(object sender, EventArgs e)
        {
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
            int lntot = Int32.Parse(LNTotal.Text);
            int tot = Int32.Parse(textBox5.Text);
            int rat = Int32.Parse(textBox7.Text);
            string a = comboBox2.SelectedItem.ToString();
            string b = a.Substring(0, 1);
            int c = Int32.Parse(b);
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
                int qtty = Int32.Parse(qtyy);
                string jeniss = ds.Tables["item"].Rows[i][3].ToString();
                string hargas = ds.Tables["item"].Rows[i][4].ToString();
                int hargass = Int32.Parse(hargas);
                string diskoun = ds.Tables["item"].Rows[i][7].ToString();
                int discroun = Int32.Parse(diskoun);
                string jenisppn = ds.Tables["item"].Rows[i][5].ToString();
                string totalppn = ds.Tables["item"].Rows[i][6].ToString();
                int tppn = Int32.Parse(totalppn);
                string subtotal = ds.Tables["item"].Rows[i][8].ToString();
                int stotal = Int32.Parse(subtotal);
                cmd3 = new OracleCommand("insert into D_PURCHASE_ORDER values(:iditem, :idpo,:nama,:qty,:jeniss,:hargas,:diskon,:jenisppn,:totalppn,:subtotal)", conn);
                cmd3.Parameters.Add(":iditem", iditems);
                cmd3.Parameters.Add(":idpo", PONO.Text);
                cmd3.Parameters.Add(":nama", nama);
                cmd3.Parameters.Add(":qty", qtty);
                cmd3.Parameters.Add(":jeniss", jeniss);
                cmd3.Parameters.Add(":hargas", hargass);
                cmd3.Parameters.Add(":diskon", discroun);
                cmd3.Parameters.Add(":jenisppn", jenisppn);
                cmd3.Parameters.Add(":totalppn", tppn);
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
