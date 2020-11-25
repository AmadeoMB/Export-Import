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
        private List<Int64> qtyList = new List<Int64>(999);
        private List<Int64> hJualList = new List<Int64>(999);
        private List<Int64> subtotalList = new List<Int64>(999);
        public Object[] dataItem;
        Int64 total = 0;
        Int64 totalPPN = 0;
        Int64 netTotal = 0;
        Int64 totalConvert = 0;
        private DataTable dtPO = new DataTable();

        public formPurchaseInvoice()
        {
            InitializeComponent();
            this.conn = new OracleConnection("user id=export;password=import;data source=orcl");
            this.conn.Open();
        }

        public formPurchaseInvoice(formMasterPembelian master)
        {
            InitializeComponent();
            this.master = master;
            this.conn = master.conn;
        }

        void setColomnDS()
        {
            dtPO.Clear();
            dtPO.Columns.Add("ID");
            dtPO.Columns.Add("idPO");
            dtPO.Columns.Add("Nama");
            dtPO.Columns.Add("Qty");
            dtPO.Columns.Add("Satuan");
            dtPO.Columns.Add("Harga");
            dtPO.Columns.Add("discount");
            dtPO.Columns.Add("kadar");
            dtPO.Columns.Add("PPN");
            dtPO.Columns.Add("subtotal");
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
            nomerPI += DateToday.Value.ToString("/dd/MM/yyyy/");
            nomerPI += getNomerPI(nomerPI);

            txtIdPI.Text = nomerPI;
        }
        private void formPurchaseInvoice_Load(object sender, EventArgs e)
        {
            ds = new DataSet();

            this.dataGridView1.Columns["subtotal_column"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dataGridView1.Columns["harga_item"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dataGridView1.Columns["qty_item"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;


            this.groupPO.Add(id_po);
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
                "subtotal as subtotal " +
                "from d_purchase_order " +
                "where id_purchase_order = '" + id + "'";
            OracleDataReader reader = new OracleCommand(cmd, conn).ExecuteReader();
            while (reader.Read())
            {
                qtyList.Add(Convert.ToInt64(reader.GetValue(3)));
                hJualList.Add(Convert.ToInt64(reader.GetValue(5)));
                subtotalList.Add(Convert.ToInt64(reader.GetValue(9)));

                dtPO.Rows.Add(new Object[] {
                    reader.GetValue(0).ToString(),
                    reader.GetValue(1).ToString(),
                    reader.GetValue(2).ToString(),
                    Convert.ToInt64(reader.GetValue(3)).ToString("#,###"),
                    reader.GetValue(4).ToString(),
                    Convert.ToInt64(reader.GetValue(5)).ToString("Rp #,##0.00"),
                    reader.GetValue(6).ToString(),
                    reader.GetValue(7).ToString(),
                    reader.GetValue(8).ToString(),
                    Convert.ToInt64(reader.GetValue(9)).ToString("Rp #,##0.00")
                });

                //DataRow newRow = dataGridView1.NewRow();
                //newRow[0] = reader.GetValue(0).ToString();
                //newRow[1] = reader.GetValue(1).ToString();
                //newRow[2] = reader.GetValue(2).ToString();
                //newRow[3] = Convert.ToInt64(reader.GetValue(3)).ToString("#,##0.0");
                //newRow[4] = reader.GetValue(4).ToString();
                //newRow[5] = Convert.ToInt64(reader.GetValue(5)).ToString("Rp #,##0.0");
                //newRow[6] = reader.GetValue(6).ToString();
                //newRow[7] = reader.GetValue(7).ToString();
                //newRow[8] = reader.GetValue(8).ToString();
                //newRow[9] = Convert.ToInt64(reader.GetValue(9)).ToString("Rp #,##0.0");
            }
            dataGridView1.DataSource = dtPO;
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


                cmd = "select total from h_purchase_order where id_purchase_order = '" + id + "'";
                total = Convert.ToInt64(new OracleCommand(cmd, conn).ExecuteScalar());
                txtTotal.Text = "Rp " + total.ToString("#,##0.0");

                cmd = "select total_ppn from h_purchase_order where id_purchase_order = '" + id + "'";
                totalPPN = Convert.ToInt64(new OracleCommand(cmd, conn).ExecuteScalar());
                txtTotalPPN.Text = "Rp " + totalPPN.ToString("#,##0.0");

                cmd = "select total_harga from h_purchase_order where id_purchase_order = '" + id + "'";
                netTotal = Convert.ToInt64(new OracleCommand(cmd, conn).ExecuteScalar());
                txtNetTotal.Text = "Rp " + netTotal.ToString("#,##0.0");

                cmd = "select total_harga_convert from h_purchase_order where id_purchase_order = '" + id + "'";
                totalConvert = Convert.ToInt64(new OracleCommand(cmd, conn).ExecuteScalar());
                txtTotalConvert.Text = cbCurrent.SelectedValue.ToString() + " " + totalConvert.ToString("#,##0.0");

                isiDataItem(id);
            }
        }

        private void refreshTotal()
        {
            total = 0;
            totalPPN = 0;
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                total += subtotalList[i];
                if (dataGridView1.Rows[i].Cells[8].Value.Equals("EXC"))
                {
                    totalPPN += (subtotalList[i] / 10);
                }
            }
            txtTotal.Text = total.ToString("Rp #,##0.0");
            txtTotalPPN.Text = totalPPN.ToString("Rp #,##0.0");

            netTotal = total + totalPPN;
            txtNetTotal.Text = netTotal.ToString("Rp #,##0.0");

            int rate = Convert.ToInt32(txtRate.Text.Substring(3));
            totalConvert = netTotal / rate;
            txtTotalConvert.Text = cbCurrent.SelectedValue + totalConvert.ToString("#,##0.0");
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

        private void btnTD_Click(object sender, EventArgs e)
        {
            if (idx < 0)
            {
                MessageBox.Show("Mohon pilih isi tabel");
                return;
            }

            Object[] temp = {
                dataGridView1.Rows[idx].Cells[0].Value,
                qtyList[idx]
            };

            dataItem = temp;

            formTransferDocument td = new formTransferDocument(this);
            if (td.ShowDialog() == DialogResult.Yes)
            {
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    if (dataGridView1.Rows[i].Cells[0].Value.ToString().Equals(td.data[0].ToString()))
                    {
                        int qty = Convert.ToInt32(td.data[1]);
                        int kadar = Convert.ToInt32(td.data[2]);
                        Int64 harga = hJualList[i];
                        Int64 subtotal = qty * harga;

                        qtyList[i] = qty;
                        subtotalList[i] = subtotal;
                        dataGridView1.Rows[i].Cells[7].Value = kadar;
                        dataGridView1.Rows[i].Cells[3].Value = qty.ToString("#,###");
                        dataGridView1.Rows[i].Cells[9].Value = subtotal.ToString("Rp #,##0.0");
                    }
                }
                refreshTotal();
            }
        }

        Boolean saved = false;

        void save()
        {
            if (dataGridView1.Rows.Count <= 1)
            {
                MessageBox.Show("Mohon pilih PO");
                return;
            }

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

            int rate = Int32.Parse(txtRate.Text.Substring(4));
            String currency = cbCurrent.SelectedValue.ToString();

            OracleCommand cmd2;
            cmd2 = new OracleCommand("insert into H_PURCHASE_INVOICE values(:idp, :ids, :idg, :idst, :nama, :alamat, :invoice, :tgl, :creditterm, :shipvia, :currencypo, :rate, :total, :totalPPN, :totalh, :totalhc)", conn);
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
            cmd2.Parameters.Add(":total", total);
            cmd2.Parameters.Add(":totalPPN", totalPPN);
            cmd2.Parameters.Add(":totalh", netTotal);
            cmd2.Parameters.Add(":totalhc", totalConvert);
            cmd2.ExecuteNonQuery();

            cmd2 = new OracleCommand();

            OracleCommand cmd3;
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                string iditems = dataGridView1.Rows[i].Cells[0].Value.ToString();
                string nama = dataGridView1.Rows[i].Cells[1].Value.ToString();
                Int64 qtty = qtyList[i];
                string jeniss = dataGridView1.Rows[i].Cells[4].Value.ToString();
                Int64 hargass = hJualList[i];
                string diskoun = dataGridView1.Rows[i].Cells[6].Value.ToString();
                int discroun = Int32.Parse(diskoun);
                string kadar = dataGridView1.Rows[i].Cells[7].Value.ToString();
                int kadarr = Int32.Parse(kadar);
                string jenisppn = dataGridView1.Rows[i].Cells[8].Value.ToString();
                Int64 stotal = subtotalList[i];
                cmd3 = new OracleCommand("insert into D_PURCHASE_INVOICE values(:idpi, :iditem, :nama, :qty, :jeniss, :hargas, :diskon, :kadar, :jenisppn, :subtotal)", conn);
                cmd3.Parameters.Add(":idpi", id_pi);
                cmd3.Parameters.Add(":iditem", iditems);
                cmd3.Parameters.Add(":nama", nama);
                cmd3.Parameters.Add(":qty", qtty);
                cmd3.Parameters.Add(":jeniss", jeniss);
                cmd3.Parameters.Add(":hargas", hargass);
                cmd3.Parameters.Add(":diskon", discroun);
                cmd3.Parameters.Add(":kadar", kadarr);
                cmd3.Parameters.Add(":jenisppn", jenisppn);
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
                "total = :total, " +
                "total_ppn = :totalPPN, " +
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
            cmd2.Parameters.Add(":total", total);
            cmd2.Parameters.Add(":totalPPN", totalPPN);
            cmd2.Parameters.Add(":totalh", netTotal);
            cmd2.Parameters.Add(":totalhc", totalConvert);
            cmd2.ExecuteNonQuery();

            //Delete Last Dokumen
            new OracleCommand("delete from d_purchase_invoice where id_purchase_invoice = '" + id_pi + "'", conn).ExecuteNonQuery();

            OracleCommand cmd3;
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                string iditems = dataGridView1.Rows[i].Cells[0].Value.ToString();
                string nama = dataGridView1.Rows[i].Cells[1].Value.ToString();
                Int64 qtty = qtyList[i];
                string jeniss = dataGridView1.Rows[i].Cells[4].Value.ToString();
                Int64 hargass = hJualList[i];
                string diskoun = dataGridView1.Rows[i].Cells[6].Value.ToString();
                int discroun = Int32.Parse(diskoun);
                string kadar = dataGridView1.Rows[i].Cells[7].Value.ToString();
                int kadarr = Int32.Parse(kadar);
                string jenisppn = dataGridView1.Rows[i].Cells[8].Value.ToString();
                Int64 stotal = subtotalList[i];
                cmd3 = new OracleCommand("insert into D_PURCHASE_INVOICE values(:idpi, :iditem, :nama, :qty, :jeniss, :hargas, :diskon, :kadar, :jenisppn, :subtotal)", conn);
                cmd3.Parameters.Add(":idpi", id_pi);
                cmd3.Parameters.Add(":iditem", iditems);
                cmd3.Parameters.Add(":nama", nama);
                cmd3.Parameters.Add(":qty", qtty);
                cmd3.Parameters.Add(":jeniss", jeniss);
                cmd3.Parameters.Add(":hargas", hargass);
                cmd3.Parameters.Add(":diskon", discroun);
                cmd3.Parameters.Add(":kadar", kadarr);
                cmd3.Parameters.Add(":jenisppn", jenisppn);
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
