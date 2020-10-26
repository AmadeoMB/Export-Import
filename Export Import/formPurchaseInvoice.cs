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
        OracleDataAdapter daItem;
        OracleDataAdapter daSales;
        OracleDataAdapter daCurrent;
        OracleDataAdapter daShip;
        public string id_po = "";
        formMasterPembelian master;

        public formPurchaseInvoice()
        {
            InitializeComponent();
        }

        public formPurchaseInvoice(formMasterPembelian master)
        {
            InitializeComponent();
            this.master = master;
            this.conn = master.conn;
        }

        public void isicbsupplier()
        {
            daSupplier = new OracleDataAdapter("select id_supplier as ID, nama_supplier as nama, alamat_supplier as alamat from supplier", conn);
            daSupplier.Fill(ds, "supplier");
            cbIdSupplier.DataSource = ds.Tables["supplier"];
            cbIdSupplier.ValueMember = "ID";
            cbIdSupplier.DisplayMember = "ID";

        }
        public void isicbGudang()
        {
            daGudang = new OracleDataAdapter("select id_gudang as ID, nama_gudang as nama from gudang", conn);
            daGudang.Fill(ds, "gudang");
            cbGudang.DataSource = ds.Tables["gudang"];
            cbGudang.ValueMember = "ID";
            cbGudang.DisplayMember = "nama";
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

            txtIdPI.Text = nomerPI;
        }
        private void formPurchaseInvoice_Load(object sender, EventArgs e)
        {
            ds = new DataSet();

            this.groupPO.Add(search.id_po);
            isicbsupplier();
            isicbGudang();
            isicbCurrent();
            isicbSales();
            isicbship();
            setColomnDS();
            generatecreateNomerPI();
        }

        private void cbcreditor_SelectedIndexChanged(object sender, EventArgs e)
        {
            //int idx = cbIdSupplier.SelectedIndex;
            //MessageBox.Show(idx + "");
            ////txtNamaSupplier.Text = ds.Tables["supplier"].Rows[idx][1].ToString();
            ////txtAlamatSupplier.Text = ds.Tables["supplier"].Rows[idx][2].ToString();
        }

        void setColomnDS()
        {
            String cmd = "select " +
                "id_item as id, " +
                "nama_item as nama, " +
                "id_purchase_order as idPO, " +
                "qty_item as qty, " +
                "jenis_satuan as satuan, " +
                "harga_satuan as harga, " +
                "discount as discount, " +
                "0 as kadar, " +
                "jenis_ppn as ppn, " +
                "total_ppn as TotalPPN, " +
                "subtotal as subtotal " +
                "from d_purchase_order";
            daItem = new OracleDataAdapter(cmd, conn);
            daItem.Fill(ds, "item");

            ds.Tables["item"].Clear();
        }

        void isiDataItem(String id)
        {
            String cmd = "select " +
                "id_item as id, " +
                "nama_item as nama, " +
                "id_purchase_order as idPO, " +
                "qty_item as qty, " +
                "jenis_satuan as satuan, " +
                "harga_satuan as harga, " +
                "discount as discount, " +
                "0 as kadar, " +
                "jenis_ppn as ppn, " +
                "total_ppn as TotalPPN, " +
                "subtotal as subtotal " +
                "from d_purchase_order " +
                "where id_purchase_order = '" + id + "'";
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

        public List<String> groupPO = new List<String>();
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
                    this.id_po = search.id_po;
                    ambilDataPO(this.id_po);
                }
            }
            this.groupPO.Add(search.id_po);
        }

        public void isicbSales()
        {
            daSales = new OracleDataAdapter("select id_staff as ID, nama_staff as nama from staff where id_jabatan = '3'", conn);

            daSales.Fill(ds, "staff");
            cbNamaStaff.DataSource = ds.Tables["staff"];
            cbNamaStaff.ValueMember = "ID";
            cbNamaStaff.DisplayMember = "nama";
        }
        public void isicbCurrent()
        {
            daCurrent = new OracleDataAdapter("select id_currency, nama_currency from currency", conn);
            daCurrent.Fill(ds, "currency");
            cbCurrent.DataSource = ds.Tables["currency"];
            cbCurrent.ValueMember = "id_currency";
            cbCurrent.DisplayMember = "nama_currency";
        }
        public void isicbship()
        {
            daShip = new OracleDataAdapter("select * from ekspedisi", conn);
            daShip.Fill(ds, "ekspedisi");
            cbEkspedisi.DataSource = ds.Tables["ekspedisi"];
            cbEkspedisi.ValueMember = "id_ekspedisi";
            cbEkspedisi.DisplayMember = "nama_ekspedisi";
        }

        void ambilDataPO(String id)
        {
            String cmd = "select distinct s.id_supplier as ID, s.nama_supplier as Nama, s.alamat_supplier as Alamat from h_purchase_order h join supplier s on h.id_supplier = s.id_supplier";

            if (!id.Equals(""))
            {
                ds.Tables["supplier"].Clear();

                cmd += " where id_purchase_order = '" + id + "'";
                daSupplier = new OracleDataAdapter(cmd, conn);
                daSupplier.Fill(ds, "supplier");
                txtNamaSupplier.Text = ds.Tables["supplier"].Rows[0][1].ToString();
                txtAlamatSupplier.Text = ds.Tables["supplier"].Rows[0][2].ToString();
            }

            daSupplier = new OracleDataAdapter(cmd, conn);
            daSupplier.Fill(ds, "supplier");
            cbIdSupplier.DataSource = ds.Tables["supplier"];
            cbIdSupplier.DisplayMember = "ID";
            cbIdSupplier.ValueMember = "Nama";

            cmd = "select distinct g.id_gudang as ID, g.nama_gudang as Nama from h_purchase_order h join gudang g " +
                "on h.id_gudang = g.id_gudang";

            if (!id.Equals(""))
            {
                cmd += " where id_purchase_order = '" + id + "'";
                ds.Tables["gudang"].Clear();
            }

            daGudang = new OracleDataAdapter(cmd, conn);
            daGudang.Fill(ds, "gudang");
            cbGudang.DataSource = ds.Tables["gudang"];
            cbGudang.DisplayMember = "Nama";
            cbGudang.ValueMember = "ID";

            cmd = "select distinct h.id_staff as ID, nama_staff as Nama from h_purchase_order h join staff s on h.id_staff = s.id_staff";

            if (!id.Equals(""))
            {
                cmd += " where id_purchase_order = '" + id + "'";
                ds.Tables["staff"].Clear();
            }

            daSales = new OracleDataAdapter(cmd, conn);
            daSales.Fill(ds, "staff");
            cbNamaStaff.DataSource = ds.Tables["staff"];
            cbNamaStaff.DisplayMember = "Nama";
            cbNamaStaff.ValueMember = "ID";

            cmd = "select distinct ship_via as ID, nama_ekspedisi as Nama from h_purchase_order join ekspedisi on ship_via = id_ekspedisi";

            if (!id.Equals(""))
            {
                cmd += " where id_purchase_order = '" + id + "'";
                ds.Tables["ekspedisi"].Clear();
            }

            daShip = new OracleDataAdapter(cmd, conn);
            daShip.Fill(ds, "ekspedisi");
            cbEkspedisi.DataSource = ds.Tables["ekspedisi"];
            cbEkspedisi.DisplayMember = "Nama";
            cbEkspedisi.ValueMember = "ID";

            cmd = "select distinct currency_purchase_order as ID, c.nama_currency as Nama from h_purchase_order h join currency c on id_currency = currency_purchase_order";

            if (!id.Equals(""))
            {
                cmd += " where id_purchase_order = '" + id + "'";
                ds.Tables["currency"].Clear();

                daCurrent = new OracleDataAdapter(cmd, conn);
                daCurrent.Fill(ds, "currency");

                txtRate.Text = "1 : " + new OracleCommand("select rate from h_purchase_order where id_purchase_order = '" + id + "'", conn).ExecuteScalar();
            }

            daCurrent = new OracleDataAdapter(cmd, conn);
            daCurrent.Fill(ds, "currency");
            cbCurrent.DataSource = ds.Tables["currency"];
            cbCurrent.DisplayMember = "Nama";
            cbCurrent.ValueMember = "ID";

            if (!id.Equals(""))
            {
                cmd = "select credit_term_purchase_order from h_purchase_order where id_purchase_order = '" + id + "'";
                cbCreditTerm.Text = new OracleCommand(cmd, conn).ExecuteScalar().ToString() + " Months";

                cmd = "select total_harga from h_purchase_order where id_purchase_order = '" + id + "'";
                txtTotal.Text = "Rp " + new OracleCommand(cmd, conn).ExecuteScalar().ToString();

                cmd = "select total_harga_convert from h_purchase_order where id_purchase_order = '" + id + "'";
                txtTotalConvert.Text = cbCurrent.SelectedValue + " " +new OracleCommand(cmd, conn).ExecuteScalar().ToString();

                isiDataItem(id);
            }
        }

        private void cbCurrent_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        int idx = -1;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            idx = e.RowIndex;

            if (idx > -1)
            {
                btnTD.Enabled = true;
            }
            else
            {
                btnTD.Enabled = false;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            idx = e.RowIndex;

            if (idx > -1)
            {
                btnTD.Enabled = true;
            }
            else
            {
                btnTD.Enabled = false;
            }
        }

        public Object[] dataItem;

        private void btnTD_Click(object sender, EventArgs e)
        {
            if (idx < 0)
            {
                MessageBox.Show("Mohon pilih isi tabel");
                return;
            }

            Object[] temp = {
                dataGridView1.Rows[idx].Cells[1].Value,
                dataGridView1.Rows[idx].Cells[3].Value
            };

            dataItem = temp;

            formTransferDocument td = new formTransferDocument(this);
            if (td.ShowDialog() == DialogResult.Yes)
            {
                for (int i = 0; i < ds.Tables["item"].Rows.Count; i++)
                {
                    MessageBox.Show(ds.Tables["item"].Rows[i][1].ToString() + "=" + td.data[0].ToString());
                    if (ds.Tables["item"].Rows[i][1].ToString().Equals(td.data[0].ToString()))
                    {
                        int qty = Convert.ToInt32(td.data[1]);
                        int kadar = Convert.ToInt32(td.data[2]);
                        int harga = Convert.ToInt32(ds.Tables["item"].Rows[i][5]);
                        int subtotal = qty * harga;

                        if (ds.Tables["item"].Rows[i][8].Equals("EXC"))
                        {
                            int ppn = subtotal * 10 / 100;
                            ds.Tables["item"].Rows[i][9] = ppn;

                            subtotal += ppn;
                        }

                        ds.Tables["item"].Rows[i][7] = kadar;
                        ds.Tables["item"].Rows[i][3] = qty;
                        ds.Tables["item"].Rows[i][10] = subtotal;
                        return;
                    }
                }
            }
        }

        Boolean saved = false;

        void save()
        {
            if (txtInvoiceSupplier.Text.Equals(""))
            {
                MessageBox.Show("Mohon isi Nomer Invoice dari Supplier");
                return;
            }
            //kurang pengecekan textbox atau combobox
            //buat header PO
            String id_supplier = cbIdSupplier.Text;
            String nama_supplier = txtNamaSupplier.Text;
            String alamat_supplier = txtAlamatSupplier.Text;
            String gudang = cbGudang.SelectedValue.ToString();
            String id_pi = txtIdPI.Text;
            String invoice_supplier = txtInvoiceSupplier.Text;
            DateTime tanggal = DateToday.Value;
            int creditTerm = Int32.Parse(cbCreditTerm.Text.Substring(0, 2));
            String admin = cbNamaStaff.SelectedValue.ToString();
            String ekspedisi = cbEkspedisi.SelectedValue.ToString();

            int total = Int32.Parse(txtTotal.Text.Substring(3));
            int totalConvert = Int32.Parse(txtTotalConvert.Text.Substring(4));
            int rate = Int32.Parse(txtRate.Text.Substring(4));
            String currency = cbCurrent.SelectedValue.ToString();

            OracleCommand cmd2;
            cmd2 = new OracleCommand("insert into H_PURCHASE_INVOICE values(:idp, :ids, :idg, :idst, :nama, :alamat, :invoice, :tgl, :creditterm, :shipvia, :currencypo, :rate, :totalh, :totalhc)", conn);
            cmd2.Parameters.Add(":idp", id_pi);
            cmd2.Parameters.Add(":ids", id_supplier);
            cmd2.Parameters.Add(":idg", gudang);
            cmd2.Parameters.Add(":idst", admin);
            cmd2.Parameters.Add(":nama", nama_supplier);
            cmd2.Parameters.Add(":alamat", alamat_supplier);
            cmd2.Parameters.Add(":invoice", invoice_supplier);
            cmd2.Parameters.Add(":tgl", tanggal);
            cmd2.Parameters.Add(":creditterm", creditTerm);
            cmd2.Parameters.Add(":shipvia", ekspedisi);
            cmd2.Parameters.Add(":currencypo", currency);
            cmd2.Parameters.Add(":rate", rate);
            cmd2.Parameters.Add(":totalh", total);
            cmd2.Parameters.Add(":totalhc", totalConvert);
            cmd2.ExecuteNonQuery();

            //buat detail PO (belum jadi sama sekali)

            OracleCommand cmd3;
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                string iditems = ds.Tables["item"].Rows[i][0].ToString();
                string nama = ds.Tables["item"].Rows[i][1].ToString();
                string qtyy = ds.Tables["item"].Rows[i][3].ToString();
                int qtty = Int32.Parse(qtyy);
                string jeniss = ds.Tables["item"].Rows[i][4].ToString();
                string hargas = ds.Tables["item"].Rows[i][5].ToString();
                int hargass = Int32.Parse(hargas);
                string diskoun = ds.Tables["item"].Rows[i][6].ToString();
                int discroun = Int32.Parse(diskoun);
                string kadar = ds.Tables["item"].Rows[i][7].ToString();
                int kadarr = Int32.Parse(kadar);
                string jenisppn = ds.Tables["item"].Rows[i][8].ToString();
                string totalppn = ds.Tables["item"].Rows[i][9].ToString();
                int tppn = Int32.Parse(totalppn);
                string subtotal = ds.Tables["item"].Rows[i][10].ToString();
                int stotal = Int32.Parse(subtotal);
                cmd3 = new OracleCommand("insert into D_PURCHASE_INVOICE values(:idpi, :iditem, :nama, :qty, :jeniss, :hargas, :diskon, :kadar, :jenisppn, :totalppn, :subtotal)", conn);
                cmd3.Parameters.Add(":idpi", id_pi);
                cmd3.Parameters.Add(":iditem", iditems);
                cmd3.Parameters.Add(":nama", nama);
                cmd3.Parameters.Add(":qty", qtty);
                cmd3.Parameters.Add(":jeniss", jeniss);
                cmd3.Parameters.Add(":hargas", hargass);
                cmd3.Parameters.Add(":diskon", discroun);
                cmd3.Parameters.Add(":kadar", kadarr);
                cmd3.Parameters.Add(":jenisppn", jenisppn);
                cmd3.Parameters.Add(":totalppn", tppn);
                cmd3.Parameters.Add(":subtotal", stotal);
                cmd3.ExecuteNonQuery();
            }

            MessageBox.Show("Berhasil  Menyimpan");
            saved = true;
        }

        void overwrite()
        {
            if (txtInvoiceSupplier.Text.Equals(""))
            {
                MessageBox.Show("Mohon isi Nomer Invoice dari Supplier");
                return;
            }
            //kurang pengecekan textbox atau combobox
            //buat header PO
            String id_supplier = cbIdSupplier.Text;
            String nama_supplier = txtNamaSupplier.Text;
            String alamat_supplier = txtAlamatSupplier.Text;
            String gudang = cbGudang.SelectedValue.ToString();
            String id_pi = txtIdPI.Text;
            String invoice_supplier = txtInvoiceSupplier.Text;
            DateTime tanggal = DateToday.Value;
            int creditTerm = Int32.Parse(cbCreditTerm.Text.Substring(0, 2));
            String admin = cbNamaStaff.SelectedValue.ToString();
            String ekspedisi = cbEkspedisi.SelectedValue.ToString();

            int total = Int32.Parse(txtTotal.Text);
            int totalConvert = Int32.Parse(txtTotalConvert.Text);
            int rate = Int32.Parse(txtRate.Text.Substring(4));
            String currency = cbCurrent.SelectedValue.ToString();

            OracleCommand cmd2;
            cmd2 = new OracleCommand("update H_PURCHASE_INVOICE set " +
                "id_supplier = :ids, " +
                "id_gudang = :idg, " +
                "id_staff = :idst, " +
                "nama_supplier = :nama, " +
                "alamat_supplier = :alamat, " +
                "supplier_id_invoice = :invoice, " +
                "tgl_purchase_invoice = :tgl, " +
                "credit_term_purchase_invoice = :creditterm, " +
                "ship_via = :shipvia, " +
                "currency_purchase_invoice = :currencypo, " +
                "rate = :rate, " +
                "total_harga = :totalh, " +
                "total_harga_convert = :totalhc " +
                "where id_purchase_invoice = '" + id_pi + "'", conn);
            cmd2.Parameters.Add(":ids", id_supplier);
            cmd2.Parameters.Add(":idg", gudang);
            cmd2.Parameters.Add(":idst", admin);
            cmd2.Parameters.Add(":nama", nama_supplier);
            cmd2.Parameters.Add(":alamat", alamat_supplier);
            cmd2.Parameters.Add(":invoice", invoice_supplier);
            cmd2.Parameters.Add(":tgl", tanggal);
            cmd2.Parameters.Add(":creditterm", creditTerm);
            cmd2.Parameters.Add(":shipvia", ekspedisi);
            cmd2.Parameters.Add(":currencypo", currency);
            cmd2.Parameters.Add(":rate", rate);
            cmd2.Parameters.Add(":totalh", total);
            cmd2.Parameters.Add(":totalhc", totalConvert);
            cmd2.ExecuteNonQuery();

            //Delete Last Dokumen
            new OracleCommand("delete from d_purchase_invoice where id_purchase_invoice = '" + id_pi + "'", conn).ExecuteNonQuery();

            OracleCommand cmd3;
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                string iditems = ds.Tables["item"].Rows[i][0].ToString();
                string nama = ds.Tables["item"].Rows[i][1].ToString();
                string qtyy = ds.Tables["item"].Rows[i][3].ToString();
                int qtty = Int32.Parse(qtyy);
                string jeniss = ds.Tables["item"].Rows[i][4].ToString();
                string hargas = ds.Tables["item"].Rows[i][5].ToString();
                int hargass = Int32.Parse(hargas);
                string diskoun = ds.Tables["item"].Rows[i][6].ToString();
                int discroun = Int32.Parse(diskoun);
                string kadar = ds.Tables["item"].Rows[i][7].ToString();
                int kadarr = Int32.Parse(kadar);
                string jenisppn = ds.Tables["item"].Rows[i][8].ToString();
                string totalppn = ds.Tables["item"].Rows[i][9].ToString();
                int tppn = Int32.Parse(totalppn);
                string subtotal = ds.Tables["item"].Rows[i][10].ToString();
                int stotal = Int32.Parse(subtotal);
                cmd3 = new OracleCommand("insert into D_PURCHASE_INVOICE values(:idpi, :iditem, :nama, :qty, :jeniss, :hargas, :diskon, :kadar, :jenisppn, :totalppn, :subtotal)", conn);
                cmd3.Parameters.Add(":idpi", id_pi);
                cmd3.Parameters.Add(":iditem", iditems);
                cmd3.Parameters.Add(":nama", nama);
                cmd3.Parameters.Add(":qty", qtty);
                cmd3.Parameters.Add(":jeniss", jeniss);
                cmd3.Parameters.Add(":hargas", hargass);
                cmd3.Parameters.Add(":diskon", discroun);
                cmd3.Parameters.Add(":kadar", kadarr);
                cmd3.Parameters.Add(":jenisppn", jenisppn);
                cmd3.Parameters.Add(":totalppn", tppn);
                cmd3.Parameters.Add(":subtotal", stotal);
                cmd3.ExecuteNonQuery();
            }

            MessageBox.Show("Berhasil  Menyimpan");
        }

        private void btnSave_Click(object sender, EventArgs e)
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

        public String id_pi;

        private void btnPreview_Click(object sender, EventArgs e)
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

            this.id_pi = txtIdPI.Text;

            new formPreviewPI(this).ShowDialog();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            master.Show();
        }
    }
}
