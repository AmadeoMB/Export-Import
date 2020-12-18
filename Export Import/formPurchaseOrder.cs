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
        DataTable dtPO = new DataTable();
        private Stack<Object[]> done = new Stack<Object[]>(100);
        private Stack<Object[]> undone = new Stack<Object[]>(100);
        DataSet ds = new DataSet();
        int idx = -1;
        private List<Int64> qtyList = new List<Int64>(999);
        private List<Int64> hBeliList = new List<Int64>(999);
        private List<Int64> subtotalList = new List<Int64>(999);
        Int64 localNetTotal = 0;
        Int64 netTotal = 0;
        Int64 total = 0;
        Int64 totalPPN = 0;
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
        public formPurchaseOrder(FormListPurchaseOrder pembelian)
        {
            InitializeComponent();
            this.form = pembelian.pembelian;
            this.conn = pembelian.conn;
            this.admin = "Melvern Tallall";
            this.id_po = pembelian.id_purchase_order;
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
        void ambilDataSO(String id)
        {
            saved = true;
            PONO.Text = id;
            String cmd = "";

            if (!id.Equals(""))
            {
                cmd = "select credit_term_purchase_order from h_purchase_order where id_purchase_order = '" + id + "'";
                string ct = new OracleCommand(cmd, conn).ExecuteScalar().ToString();
                comboBox2.Text = ct + " Day(s)";

                cmd = "select total from h_purchase_order where id_purchase_order = '" + id + "'";
                total += Convert.ToInt64(new OracleCommand(cmd, conn).ExecuteScalar().ToString());
                txtTotal.Text = "Rp " + total.ToString("#,##0.00");

                cmd = "select total_ppn from h_purchase_order where id_purchase_order = '" + id + "'";
                totalPPN += Convert.ToInt64(new OracleCommand(cmd, conn).ExecuteScalar().ToString());
                txtTotalPPN.Text = "Rp " + totalPPN.ToString("#,##0.00");

                cmd = "select total_harga from h_purchase_order where id_purchase_order = '" + id + "'";
                netTotal += Convert.ToInt64(new OracleCommand(cmd, conn).ExecuteScalar().ToString());
                textBox5.Text = "Rp " + netTotal.ToString("#,##0.00");

                cmd = "select total_harga_convert from h_purchase_order where id_purchase_order = '" + id + "'";
                localNetTotal += Convert.ToInt64(new OracleCommand(cmd, conn).ExecuteScalar().ToString());
                LNTotal.Text = cbCurrent.SelectedValue.ToString() + " " + localNetTotal.ToString("#,##0.00");

                isiDataItem(id);
            }
        }

        void isiDataItem(String id)
        {
            dtPO.Clear();
            dtPO.Columns.Add("id_item");
            dtPO.Columns.Add("nama_item");
            dtPO.Columns.Add("qty_item");
            dtPO.Columns.Add("satuan_item");
            dtPO.Columns.Add("harga_beli_item");
            dtPO.Columns.Add("discount");
            dtPO.Columns.Add("jenis_ppn");

            dtPO.Columns.Add("subtotal");

            String cmd = "";
            OracleDataReader reader;
            cmd = "select * from d_purchase_order where id_purchase_order = '" + id + "'";
            reader = new OracleCommand(cmd, conn).ExecuteReader();
            while (reader.Read())
            {
                dtPO.Rows.Add(new Object[] {
                    reader.GetValue(0).ToString(),
                    reader.GetValue(2).ToString(),
                    Convert.ToInt64(reader.GetValue(3)).ToString("#,###"),
                    reader.GetValue(4).ToString(),
                    Convert.ToInt64(reader.GetValue(5)).ToString("Rp #,##0.00"),
                    reader.GetValue(6).ToString(),
                    reader.GetValue(7).ToString(),
                    Convert.ToInt64(reader.GetValue(8)).ToString("Rp #,##0.00")
                });
                //DataRow newRow = dtSO.NewRow();
                //newRow[0] = reader.GetValue(0).ToString();
                //newRow["id_so"] = reader.GetValue(1).ToString();
                //newRow["nama_item"] = reader.GetValue(2).ToString();
                //newRow["qty_item"] = Convert.ToInt64(reader.GetValue(3)).ToString("#,###");
                //newRow["jenis_satuan"] = reader.GetValue(4).ToString();
                //newRow["harga_satuan"] = Convert.ToInt64(reader.GetValue(5)).ToString("Rp #,##0.00");
                //newRow["berat_total"] = Convert.ToInt64(reader.GetValue(6)).ToString("#,###");
                //newRow["jenis_ppn"] = reader.GetValue(7).ToString();
                //newRow["discount"] = reader.GetValue(8).ToString();
                //newRow["subtotal"] = Convert.ToInt64(reader.GetValue(9)).ToString("Rp #,##0.00");
                qtyList.Add(Convert.ToInt64(reader.GetValue(3)));
                hBeliList.Add(Convert.ToInt64(reader.GetValue(5)));
                subtotalList.Add(Convert.ToInt64(reader.GetValue(8)));
            }
            dataGridView1.DataSource = dtPO;
        }
        public void refreshnettotal() {
            total = 0;
            totalPPN = 0;
            Int64 itung = dataGridView1.Rows.Count;
            if (itung <= 1) {
                return;
            }
            else {
                for (int i = 0; i < dataGridView1.Rows.Count-1; i++)
                {
                    Int64 harga = subtotalList[i];
                    total += harga;
                    if (dataGridView1.Rows[i].Cells[5].Value.Equals("EXC"))
                    {
                        totalPPN += harga / 10;
                    }
                }
                netTotal = (total + totalPPN);

                txtTotal.Text = total.ToString("Rp #,##0.0");
                txtTotalPPN.Text = totalPPN.ToString("Rp #,##0.0");
                textBox5.Text = netTotal.ToString("Rp #,##0.0");
            }
        }
        public void refreshlocalnet() {
            Int64 ubahrate = Int64.Parse(textBox7.Text);
            localNetTotal = (netTotal / ubahrate);
            LNTotal.Text = localNetTotal.ToString("Rp #,##0.0");
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
            if (!this.id_po.Equals("")) {
                ambilDataSO(id_po);
            }
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
            nomerPO += DateToday.Value.ToString("/yyyy/MM/dd/");
            nomerPO += getNomerPO(nomerPO);

            PONO.Text = nomerPO;
        }

        public void InsertItem(Object[] data)
        {
            object id_item = data[0];
            Int64 diskon = Convert.ToInt64(data[1]);
            Int64 qty = Convert.ToInt64(data[2]);

            String cmd = "select harga_beli_item from item where id_item ='" + id_item + "'";
            Int64 hargaBeli = Convert.ToInt64(new OracleCommand(cmd, conn).ExecuteScalar());
            Int64 subtotal = hargaBeli * qty;

            Int64 totalDiscount = subtotal * diskon / 100;
            subtotal -= totalDiscount;

            if (dataGridView1.Rows.Count > 1)
            {
                int i = 0;
                bool ada = false;
                for (; i < dataGridView1.Rows.Count-1; i++)
                {
                    MessageBox.Show(dataGridView1.Rows[i].Cells[0].Value.ToString());
                    if (dataGridView1.Rows[i].Cells[0].Value.ToString().Equals(id_item))
                    {
                        ada = true;
                        break;
                    }
                }

                if (ada)
                {
                    qtyList[i] += qty;
                    subtotalList[i] += subtotal;

                    dataGridView1.Rows[i].Cells[2].Value = qtyList[i].ToString("#,###");
                    dataGridView1.Rows[i].Cells[7].Value = subtotalList[i].ToString("Rp #,##0.00");

                    return;
                }
            }

            qtyList.Add(qty);
            hBeliList.Add(hargaBeli);
            subtotalList.Add(subtotal);

            
            cmd = "select id_item, nama_item, '" +
                qty.ToString("#,###") + "' as qty_item, " +
                "satuan_item, '" +
                hargaBeli.ToString("Rp #,##0.0") + "' as harga_beli_item, "+
                diskon + " as discount, " +
                "jenis_ppn, '" +
                subtotal.ToString("Rp #,##0.0") + "' as subtotal " +
                "from item " +
                "where id_item = '" + id_item + "'";

            daItem = new OracleDataAdapter(cmd, conn);
            daItem.Fill(dtPO);
            dataGridView1.DataSource = dtPO;
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
                    dataGridView1.Rows[idx].Cells[0].Value,
                    dataGridView1.Rows[idx].Cells[6].Value,
                    qtyList[idx],
                    "delete",
                };
                done.Push(temp);

                qtyList.RemoveAt(idx);
                subtotalList.RemoveAt(idx);
                hBeliList.RemoveAt(idx);
                dataGridView1.Rows.RemoveAt(idx);

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
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        if (dataGridView1.Rows[i].Cells[0].Value.ToString().Equals(temp[0]))
                        {
                            dataGridView1.Rows.RemoveAt(i);
                            subtotalList.RemoveAt(i);
                            hBeliList.RemoveAt(i);
                            qtyList.RemoveAt(i);
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
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        if (dataGridView1.Rows[i].Cells[0].Value.ToString().Equals(temp[0]))
                        {
                            dataGridView1.Rows.RemoveAt(i);
                            subtotalList.RemoveAt(i);
                            hBeliList.RemoveAt(i);
                            qtyList.RemoveAt(i);
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
            Int64 rat = Int64.Parse(textBox7.Text);
            string a = comboBox2.SelectedItem.ToString();
            string b = a.Substring(0, 1);
            Int64 c = Int64.Parse(b);
            string sales = new OracleCommand("select id_staff from staff where nama_staff = '" + admin + "'", conn).ExecuteScalar().ToString();

            OracleCommand cmd2;
            cmd2 = new OracleCommand("insert into H_PURCHASE_ORDER  values(:idp, :ids, :idst, :idg, :nama, :alamat, :tgl, :creditterm, :shipvia, :currencypo, :rate, :total, :totalPPN, :totalh, :totalhc)", conn);
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
            cmd2.Parameters.Add(":totalh", netTotal);
            cmd2.Parameters.Add(":totalhc", localNetTotal);
            cmd2.ExecuteNonQuery();

            //buat detail PO (belum jadi sama sekali)

            OracleCommand cmd3;
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                string nama = dataGridView1.Rows[i].Cells[1].Value.ToString();
                string iditems = dataGridView1.Rows[i].Cells[0].Value.ToString();
                Int64 qtty = qtyList[i];
                string jeniss = dataGridView1.Rows[i].Cells[3].Value.ToString();
                Int64 hargass = hBeliList[i];
                string diskoun = dataGridView1.Rows[i].Cells[5].Value.ToString();
                Int64 discroun = Int64.Parse(diskoun);
                string jenisppn = dataGridView1.Rows[i].Cells[6].Value.ToString();
                Int64 stotal = subtotalList[i];
                cmd3 = new OracleCommand("insert into D_PURCHASE_ORDER values(:iditem, :idpo,:nama,:qty,:jeniss,:hargas,:diskon,:jenisppn,:subtotal)", conn);
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
            cmd2.Parameters.Add(":totalh", netTotal);
            cmd2.Parameters.Add(":totalhc", localNetTotal);
            cmd2.ExecuteNonQuery();

            //Delete
            new OracleCommand("delete from d_purchase_order where id_purchase_order = '" + PONO.Text + "'", conn).ExecuteNonQuery();

            OracleCommand cmd3;
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                string nama = dataGridView1.Rows[i].Cells[1].Value.ToString();
                string iditems = dataGridView1.Rows[i].Cells[0].Value.ToString();
                Int64 qtty = qtyList[i];
                string jeniss = dataGridView1.Rows[i].Cells[3].Value.ToString();
                Int64 hargass = hBeliList[i];
                string diskoun = dataGridView1.Rows[i].Cells[5].Value.ToString();
                Int64 discroun = Int64.Parse(diskoun);
                string jenisppn = dataGridView1.Rows[i].Cells[6].Value.ToString();
                Int64 stotal = subtotalList[i];
                cmd3 = new OracleCommand("insert into D_PURCHASE_ORDER values(:iditem, :idpo,:nama,:qty,:jeniss,:hargas,:diskon,:jenisppn,:subtotal)", conn);
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
