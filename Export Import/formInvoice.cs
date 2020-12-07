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
    public partial class formInvoice : Form
    {
        public OracleConnection conn;
        public String id_invoice = "";

        private formMasterPenjualan form;
        private OracleDataAdapter daCustomer;
        private OracleDataAdapter daGudang;
        private OracleDataAdapter daStaff;
        private OracleDataAdapter daEkspedisi;
        private OracleDataAdapter daCurrency;
        private OracleDataAdapter daNegara;
        private OracleDataAdapter daItem;
        private DataSet ds = new DataSet();
        private Boolean saved = false;
        private string id_do = "";
        private List<Int64> qtyList = new List<Int64>(999);
        private List<Int64> hJualList = new List<Int64>(999);
        private List<Int64> beratList = new List<Int64>(999);
        private List<Int64> subtotalList = new List<Int64>(999);
        private DataTable dtSO = new DataTable();
        Int64 total = 0;
        Int64 totalPPN = 0;
        Int64 netTotal = 0;
        Int64 totalConvert = 0;

        public formInvoice()
        {
            InitializeComponent();
            this.conn = new OracleConnection("user id=export;password=import;data source=orcl");
            this.conn.Open();
        }

        public formInvoice(formMasterPenjualan form)
        {
            InitializeComponent();
            this.form = form;
            this.conn = form.conn;
        }
        void isiCBNegara()
        {
            String cmd = "select * from negara";
            daNegara = new OracleDataAdapter(cmd, conn);
            daNegara.Fill(ds, "negara");
            cbNegara.DataSource = ds.Tables["negara"];
            cbNegara.DisplayMember = "nama_negara";
            cbNegara.ValueMember = "id_negara";
        }
        void isiCBCustomer()
        {
            String cmd = "select id_Customer, nama_Customer, alamat_Customer from Customer";
            daCustomer = new OracleDataAdapter(cmd, conn);
            daCustomer.Fill(ds, "Customer");
            cbIdCustomer.DataSource = ds.Tables["Customer"];
            cbIdCustomer.DisplayMember = "id_Customer";
            cbIdCustomer.ValueMember = "id_Customer";
        }

        void isiCBGudang()
        {
            String cmd = "select id_gudang, nama_gudang, alamat_gudang from gudang";
            daGudang = new OracleDataAdapter(cmd, conn);
            daGudang.Fill(ds, "gudang");
            cbGudang.DataSource = ds.Tables["gudang"];
            cbGudang.DisplayMember = "nama_gudang";
            cbGudang.ValueMember = "id_gudang";
        }

        void isicbStaff()
        {
            String cmd = "select id_staff, nama_staff from staff where id_jabatan = 5";
            daStaff = new OracleDataAdapter(cmd, conn);
            daStaff.Fill(ds, "staff");
            cbStaff.DataSource = ds.Tables["staff"];
            cbStaff.DisplayMember = "nama_staff";
            cbStaff.ValueMember = "id_staff";
        }

        void isiCBCurrency()
        {
            String cmd = "select * from currency";
            new OracleDataAdapter(cmd, conn).Fill(ds, "currency");
            cbCurrency.DataSource = ds.Tables["currency"];
            cbCurrency.DisplayMember = "nama_currency";
            cbCurrency.ValueMember = "id_currency";
        }

        void isiCBShipVia()
        {
            String cmd = "select id_ekspedisi, nama_ekspedisi from ekspedisi";
            daEkspedisi = new OracleDataAdapter(cmd, conn);
            daEkspedisi.Fill(ds, "ekspedisi");
            cbShipVia.DataSource = ds.Tables["ekspedisi"];
            cbShipVia.DisplayMember = "nama_ekspedisi";
            cbShipVia.ValueMember = "id_ekspedisi";
        }

        void generatecreateNomerInvoice()
        {
            String nomerInvoice = "IN";
            nomerInvoice += dateInvoice.Value.ToString("/yyyy/MM/dd/");
            nomerInvoice += getNomerInvoice(nomerInvoice);

            txtIdInvoice.Text = nomerInvoice;
        }

        String getNomerInvoice(String id)
        {
            String cmd = "select count(*)+1 from H_invoice where id_invoice like '" + id + "%'";
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

        void setColomnDS()
        {
            dtSO.Clear();
            dtSO.Columns.Add("id_item");
            dtSO.Columns.Add("id_sales_order");
            dtSO.Columns.Add("nama_item");
            dtSO.Columns.Add("qty_item");
            dtSO.Columns.Add("jenis_satuan");
            dtSO.Columns.Add("harga_satuan");
            dtSO.Columns.Add("berat_total");
            dtSO.Columns.Add("jenis_ppn");
            dtSO.Columns.Add("discount");
            dtSO.Columns.Add("subtotal");
        }

        void ambilDataDO(String id)
        {
            String cmd = "select distinct c.id_Customer as ID, c.nama_Customer as Nama, c.alamat_Customer as Alamat from h_delivery_order h join Customer c on h.id_Customer = c.id_Customer";

            if (!id.Equals(""))
            {
                ds.Tables["Customer"].Clear();

                cmd += " where id_delivery_order = '" + id + "'";
                daCustomer = new OracleDataAdapter(cmd, conn);
                daCustomer.Fill(ds, "Customer");
                txtNamaCustomer.Text = new OracleCommand("select nama_Customer from h_delivery_order where id_delivery_order = '" + id + "'", conn).ExecuteScalar().ToString();
                txtAlamatCustomer.Text = new OracleCommand("select alamat_Customer from h_delivery_order where id_delivery_order = '" + id + "'", conn).ExecuteScalar().ToString();

            }

            daCustomer = new OracleDataAdapter(cmd, conn);
            daCustomer.Fill(ds, "Customer");
            cbIdCustomer.DataSource = ds.Tables["Customer"];
            cbIdCustomer.DisplayMember = "ID";
            cbIdCustomer.ValueMember = "ID";

            cmd = "select distinct g.id_gudang as ID, g.nama_gudang as Nama from h_delivery_order h join gudang g " +
                "on h.id_gudang = g.id_gudang";

            if (!id.Equals(""))
            {
                cmd += " where id_delivery_order = '" + id + "'";
                ds.Tables["gudang"].Clear();
            }

            daGudang = new OracleDataAdapter(cmd, conn);
            daGudang.Fill(ds, "gudang");
            cbGudang.DataSource = ds.Tables["gudang"];
            cbGudang.DisplayMember = "Nama";
            cbGudang.ValueMember = "ID";

            cmd = "select distinct h.id_staff as ID, nama_staff as Nama from h_delivery_order h join staff s on h.id_staff = s.id_staff";

            if (!id.Equals(""))
            {
                cmd += " where id_delivery_order = '" + id + "'";
                ds.Tables["staff"].Clear();
            }

            daStaff = new OracleDataAdapter(cmd, conn);
            daStaff.Fill(ds, "staff");
            cbStaff.DataSource = ds.Tables["staff"];
            cbStaff.DisplayMember = "Nama";
            cbStaff.ValueMember = "ID";

            cmd = "select distinct ship_via as ID, nama_ekspedisi as Nama from h_delivery_order join ekspedisi on ship_via = id_ekspedisi";

            if (!id.Equals(""))
            {
                cmd += " where id_delivery_order = '" + id + "'";
                ds.Tables["ekspedisi"].Clear();
            }

            daEkspedisi = new OracleDataAdapter(cmd, conn);
            daEkspedisi.Fill(ds, "ekspedisi");
            cbShipVia.DataSource = ds.Tables["ekspedisi"];
            cbShipVia.DisplayMember = "Nama";
            cbShipVia.ValueMember = "ID";

            cmd = "select distinct a.id_negara as ID, b.nama_negara as Nama from h_delivery_order a join negara b on b.id_negara = a.id_negara";

            if (!id.Equals(""))
            {
                cmd += " where id_delivery_order = '" + id + "'";
                ds.Tables["negara"].Clear();
            }

            daNegara = new OracleDataAdapter(cmd, conn);
            daNegara.Fill(ds, "negara");
            cbNegara.DataSource = ds.Tables["negara"];
            cbNegara.DisplayMember = "Nama";
            cbNegara.ValueMember = "ID";

            cmd = "select distinct currency_delivery_order as ID, nama_currency as Nama from h_delivery_order h join currency c on currency_delivery_order = id_currency";

            if (!id.Equals(""))
            {
                cmd += " where id_delivery_order = '" + id + "'";
                ds.Tables["currency"].Clear();

                daCurrency = new OracleDataAdapter(cmd, conn);
                daCurrency.Fill(ds, "currency");
                txtRate.Text = "1 : " + new OracleCommand("select rate from h_delivery_order where id_delivery_order = '" + id + "'", conn).ExecuteScalar().ToString();
            }

            daCurrency = new OracleDataAdapter(cmd, conn);
            daCurrency.Fill(ds, "currency");
            cbCurrency.DataSource = ds.Tables["currency"];
            cbCurrency.DisplayMember = "Nama";
            cbCurrency.ValueMember = "ID";

            if (!id.Equals(""))
            {
                cmd = "select credit_term_delivery_order from h_delivery_order where id_delivery_order = '" + id + "'";
                cbCreditTerm.Text = new OracleCommand(cmd, conn).ExecuteScalar().ToString() + " Days";

                cmd = "select total from h_delivery_order where id_delivery_order = '" + id + "'";
                total = Convert.ToInt64(new OracleCommand(cmd, conn).ExecuteScalar());
                txtTotal.Text = "Rp " + total.ToString("#,##0.00");

                cmd = "select total_ppn from h_delivery_order where id_delivery_order = '" + id + "'";
                totalPPN = Convert.ToInt64(new OracleCommand(cmd, conn).ExecuteScalar());
                txtTotalPPN.Text = "Rp " + totalPPN.ToString("#,##0.00");

                cmd = "select total_harga from h_delivery_order where id_delivery_order = '" + id + "'";
                netTotal = Convert.ToInt64(new OracleCommand(cmd, conn).ExecuteScalar());
                txtNetTotal.Text = "Rp " + netTotal.ToString("#,##0.00");

                cmd = "select total_harga_convert from h_delivery_order where id_delivery_order = '" + id + "'";
                totalConvert = Convert.ToInt64(new OracleCommand(cmd, conn).ExecuteScalar());
                txtTotalConvert.Text = cbCurrency.SelectedValue.ToString() + " " + totalConvert.ToString("#,##0.00");

                isiDataItem(id);
            }
        }

        void isiDataItem(String id)
        {
            String cmd = "select * from d_sales_order where id_sales_order = '" + id + "'";
            OracleDataReader reader = new OracleCommand(cmd, conn).ExecuteReader();
            while (reader.Read())
            {
                dtSO.Rows.Add(new Object[] {
                    reader.GetValue(0).ToString(),
                    reader.GetValue(1).ToString(),
                    reader.GetValue(2).ToString(),
                    Convert.ToInt64(reader.GetValue(3)).ToString("#,###"),
                    reader.GetValue(4).ToString(),
                    Convert.ToInt64(reader.GetValue(5)).ToString("Rp #,##0.00"),
                    Convert.ToInt64(reader.GetValue(6)).ToString("#,###"),
                    reader.GetValue(7).ToString(),
                    reader.GetValue(8).ToString(),
                    Convert.ToInt64(reader.GetValue(9)).ToString("Rp #,##0.00")
                });
                qtyList.Add(Convert.ToInt64(reader.GetValue(3)));
                hJualList.Add(Convert.ToInt64(reader.GetValue(5)));
                beratList.Add(Convert.ToInt64(reader.GetValue(6)));
                subtotalList.Add(Convert.ToInt64(reader.GetValue(9)));
            }
            dataGridView.DataSource = dtSO;
        }

        void save()
        {
            if (dataGridView.Rows.Count <= 1)
            {
                MessageBox.Show("Mohon tambahkan setidaknya 1 item");
                return;
            }

            int creditTerm = 1;
            if (cbCreditTerm.Text != "Cash" && cbCreditTerm.Text != "COD")
            {
                creditTerm = Convert.ToInt32(cbCreditTerm.Text.Substring(0, 2));
            }

            String id_customer = cbIdCustomer.SelectedValue + "";
            String id_gudang = cbGudang.SelectedValue + "";
            String id_invoice = txtIdInvoice.Text;
            String id_staff = cbStaff.SelectedValue + "";
            DateTime tanggalInvoice = dateInvoice.Value;
            String shipVia = cbShipVia.SelectedValue + "";
            String negara = cbNegara.SelectedValue + "";
            String currency = cbCurrency.SelectedValue + "";
            int rate = Convert.ToInt32(txtRate.Text.Substring(4));

            OracleCommand cmd = new OracleCommand("insert into h_invoice values (:id, :gudang, :customer, :staff, :nama, :alamat, :tgl, :credit, :ship,:negara ,:currency, :rate, :total, :totalPPN, :netTotal, :convert)", conn);
            cmd.Parameters.Add(":id", id_invoice);
            cmd.Parameters.Add(":gudang", id_gudang);
            cmd.Parameters.Add(":customer", id_customer);
            cmd.Parameters.Add(":staff", id_staff);
            cmd.Parameters.Add(":nama", txtNamaCustomer.Text);
            cmd.Parameters.Add(":alamat", txtAlamatCustomer.Text);
            cmd.Parameters.Add(":tgl", tanggalInvoice);
            cmd.Parameters.Add(":credit", creditTerm);
            cmd.Parameters.Add(":ship", shipVia);
            cmd.Parameters.Add(":negara", negara);
            cmd.Parameters.Add(":currency", currency);
            cmd.Parameters.Add(":rate", rate);
            cmd.Parameters.Add(":total", total);
            cmd.Parameters.Add(":totalPPN", totalPPN);
            cmd.Parameters.Add(":netTotal", netTotal);
            cmd.Parameters.Add(":convert", totalConvert);
            cmd.ExecuteNonQuery();

            new OracleCommand("update h_delivery_order set status_do = 1 where id_delivery_order = '" + this.id_do +"'", conn).ExecuteNonQuery();

            for (int i = 0; i < dataGridView.Rows.Count - 1; i++)
            {
                String id_item = dataGridView.Rows[i].Cells[0].Value.ToString();
                String id_SO = dataGridView.Rows[i].Cells[1].Value.ToString();
                String nama_item = dataGridView.Rows[i].Cells[2].Value.ToString();
                String satuan_item = dataGridView.Rows[i].Cells[4].Value.ToString();
                String jenis_ppn = dataGridView.Rows[i].Cells[7].Value.ToString();
                String discount = dataGridView.Rows[i].Cells[8].Value.ToString();
                String qty_item = qtyList[i].ToString();
                String hJual_item = hJualList[i].ToString();
                String berat_item = beratList[i].ToString();
                String subtotal = subtotalList[i].ToString();

                OracleCommand cmdDetail = new OracleCommand("insert into d_invoice values (:id, :so, :do, :nama, :qty, :jenis, :harga, :berat, :ppn, :discount, :subtotal)", conn);
                cmdDetail.Parameters.Add(":id", id_item);
                cmdDetail.Parameters.Add(":so", id_SO);
                cmdDetail.Parameters.Add(":do", id_invoice);
                cmdDetail.Parameters.Add(":nama", nama_item);
                cmdDetail.Parameters.Add(":qty", qty_item);
                cmdDetail.Parameters.Add(":jenis", satuan_item);
                cmdDetail.Parameters.Add(":harga", hJual_item);
                cmdDetail.Parameters.Add(":berat", berat_item);
                cmdDetail.Parameters.Add(":ppn", jenis_ppn);
                cmdDetail.Parameters.Add(":discount", discount);
                cmdDetail.Parameters.Add(":subtotal", subtotal);
                cmdDetail.ExecuteNonQuery();
            }

            String cmdString = "select distinct id_sales_order from d_invoice where id_invoice = '" + id_invoice + "'";
            OracleDataReader reader = new OracleCommand(cmdString, conn).ExecuteReader();
            while (reader.Read())
            {
                new OracleCommand("update h_sales_order set id_invoice = '" + id_invoice + "' where id_sales_order = '" + reader.GetValue(0) + "'", conn).ExecuteNonQuery();
            }

            saved = true;
            MessageBox.Show("Save berhasil");
        }

        void overwrite()
        {
            if (dataGridView.Rows.Count <= 1)
            {
                MessageBox.Show("Mohon tambahkan setidaknya 1 item");
                return;
            }

            int creditTerm = 1;
            if (cbCreditTerm.Text != "Cash" && cbCreditTerm.Text != "COD")
            {
                creditTerm = Convert.ToInt32(cbCreditTerm.Text.Substring(0, 2));
            }

            String id_customer = cbIdCustomer.SelectedValue + "";
            String id_gudang = cbGudang.SelectedValue + "";
            String id_invoice = txtIdInvoice.Text;
            String id_staff = cbStaff.SelectedValue + "";
            DateTime tanggalInvoice = dateInvoice.Value;
            String shipVia = cbShipVia.SelectedValue + "";
            String negara = cbNegara.SelectedValue + "";
            String currency = cbCurrency.SelectedValue + "";
            int rate = Convert.ToInt32(txtRate.Text.Substring(4));

            OracleCommand cmd = new OracleCommand("update h_invoice " +
                "set " +
                "total = :total, " +
                "total_ppn = :totalPPN, " +
                "total_harga = :netTotal, " +
                "total_harga_convert = :convert " +
                "where id_invoice = '" + id_invoice + "'", conn);

            cmd.Parameters.Add(":total", total);
            cmd.Parameters.Add(":totalPPN", totalPPN);
            cmd.Parameters.Add(":netTotal", netTotal);
            cmd.Parameters.Add(":convert", totalConvert);

            cmd.ExecuteNonQuery();

            //Delete last dokumen
            cmd = new OracleCommand("delete from d_invoice where id_invoice = '" + id_invoice + "'", conn);
            cmd.ExecuteNonQuery();

            for (int i = 0; i < dataGridView.Rows.Count - 1; i++)
            {
                String id_item = dataGridView.Rows[i].Cells[0].Value.ToString();
                String id_SO = dataGridView.Rows[i].Cells[1].Value.ToString();
                String nama_item = dataGridView.Rows[i].Cells[2].Value.ToString();
                String satuan_item = dataGridView.Rows[i].Cells[4].Value.ToString();
                String jenis_ppn = dataGridView.Rows[i].Cells[7].Value.ToString();
                String discount = dataGridView.Rows[i].Cells[8].Value.ToString();
                String qty_item = qtyList[i].ToString();
                String hJual_item = hJualList[i].ToString();
                String berat_item = beratList[i].ToString();
                String subtotal = subtotalList[i].ToString();

                new OracleCommand("update h_sales_order set id_invoice = '" + id_invoice + "' where id_sales_order = '" + id_SO + "'", conn).ExecuteNonQuery();
                OracleCommand cmdDetail = new OracleCommand("insert into d_invoice values (:id, :so, :do, :nama, :qty, :jenis, :harga, :berat, :ppn, :discount, :subtotal)", conn);
                cmdDetail.Parameters.Add(":id", id_item);
                cmdDetail.Parameters.Add(":so", id_SO);
                cmdDetail.Parameters.Add(":do", id_invoice);
                cmdDetail.Parameters.Add(":nama", nama_item);
                cmdDetail.Parameters.Add(":qty", qty_item);
                cmdDetail.Parameters.Add(":jenis", satuan_item);
                cmdDetail.Parameters.Add(":harga", hJual_item);
                cmdDetail.Parameters.Add(":berat", berat_item);
                cmdDetail.Parameters.Add(":ppn", jenis_ppn);
                cmdDetail.Parameters.Add(":discount", discount);
                cmdDetail.Parameters.Add(":subtotal", subtotal);
                cmdDetail.ExecuteNonQuery();
            }

            saved = true;
            MessageBox.Show("Save berhasil");
        }

        private void formInvoice_Load(object sender, EventArgs e)
        {
            this.dataGridView.Columns["subtotal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dataGridView.Columns["harga_item"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dateInvoice.Value = DateTime.Today;

            try
            {
                setColomnDS();
                isiCBCustomer();
                isiCBCurrency();
                isiCBGudang();
                isicbStaff();
                isiCBNegara();
                isiCBShipVia();
                generatecreateNomerInvoice();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnGetSO_Click(object sender, EventArgs e)
        {
            formSearchDO search = new formSearchDO(this);
            if (search.ShowDialog() == DialogResult.Yes)
            {
                ambilDataDO(search.id_do);
                this.id_do = search.id_do;

                OracleDataReader reader = new OracleCommand("select distinct id_sales_order from d_delivery_order where id_delivery_order = '"+search.id_do+"'", conn).ExecuteReader();
                while (reader.Read())
                {
                    isiDataItem(reader.GetValue(0).ToString());
                }
                btnGetSO.Enabled = false;
            }
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

            this.id_invoice = txtIdInvoice.Text;
            new formPreviewInvoice(this).ShowDialog();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            form.Show();
        }
    }
}
