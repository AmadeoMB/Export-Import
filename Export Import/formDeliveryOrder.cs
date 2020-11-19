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
    public partial class formDeliveryOrder : Form
    {
        public OracleConnection conn;
        private formMasterGudang master;
        private OracleDataAdapter daCustomer;
        private OracleDataAdapter daGudang;
        private OracleDataAdapter daStaff;
        private OracleDataAdapter daEkspedisi;
        private OracleDataAdapter daCurrency;
        private OracleDataAdapter daItem;
        private OracleDataAdapter daNegara;
        private DataSet ds = new DataSet();
        public String id_so = "";

        public formDeliveryOrder()
        {
            InitializeComponent();
            this.conn = new OracleConnection("user id=export;password=import;data source=orcl");
            this.conn.Open();
        }

        public formDeliveryOrder(formMasterGudang master)
        {
            InitializeComponent();
            this.master = master;
            this.conn = master.conn;
        }

        public formDeliveryOrder(formListSalesOrder list)
        {
            InitializeComponent();
            this.master = list.gudang;
            this.conn = list.conn;
            this.id_so = list.id_sales_order;
        }

        private void formDeliveryOrder_Load(object sender, EventArgs e)
        {
            this.dataGridView.Columns["subtotal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dataGridView.Columns["harga"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            try
            {
                if (!this.id_so.Equals(""))
                {
                    this.groupSO.Add(this.id_so);
                }

                setColomnDS();
                isiCBCustomer();
                isiCBCurrency();
                isiCBGudang();
                isiCBSales();
                isiCBShipVia();
                isiCBNegara();
                generatecreateNomerDO();
                ambilDataSO(id_so);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        void isiCBCustomer()
        {
            String cmd = "select id_customer, nama_customer, alamat_customer from customer";
            daCustomer = new OracleDataAdapter(cmd, conn);
            daCustomer.Fill(ds, "customer");
            cbIdCust.DataSource = ds.Tables["customer"];
            cbIdCust.DisplayMember = "id_customer";
            cbIdCust.ValueMember = "id_customer";
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

        void isiCBSales()
        {
            String cmd = "select id_staff, nama_staff from staff where id_jabatan = 5";
            daStaff = new OracleDataAdapter(cmd, conn);
            daStaff.Fill(ds, "staff");
            cbNamaSales.DataSource = ds.Tables["staff"];
            cbNamaSales.DisplayMember = "nama_staff";
            cbNamaSales.ValueMember = "id_staff";
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

        void generatecreateNomerDO()
        {
            String nomerSO = "DO";
            nomerSO += dateDO.Value.ToString("/dd/MM/yyyy/");
            nomerSO += getNomerSO(nomerSO);

            txtIdDO.Text = nomerSO;
        }

        String getNomerSO(String id)
        {
            String cmd = "select count(*)+1 from H_delivery_Order where id_delivery_order like '" + id + "%'";
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
            String cmd = "select * from d_sales_order";
            daItem = new OracleDataAdapter(cmd, conn);
            daItem.Fill(ds, "item");

            ds.Tables["item"].Clear();
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
        void ambilDataSO(String id)
        {
            String cmd = "select distinct c.id_customer as ID, c.nama_customer as Nama, c.alamat_customer as Alamat from h_sales_order h join customer c on h.id_customer = c.id_customer";

            if (!id.Equals(""))
            {
                ds.Tables["customer"].Clear();

                cmd += " where id_sales_order = '" + id + "'";
                daCustomer = new OracleDataAdapter(cmd, conn);
                daCustomer.Fill(ds, "customer");
                txtNamaCust.Text = new OracleCommand("select nama_customer from h_sales_order where id_sales_order = '" + id_so + "'", conn).ExecuteScalar().ToString();
                txtAlamatCust.Text = new OracleCommand("select alamat_customer from h_sales_order where id_sales_order = '" + id_so + "'", conn).ExecuteScalar().ToString();

                pnlAtas.Enabled = false;
            }

            daCustomer = new OracleDataAdapter(cmd, conn);
            daCustomer.Fill(ds, "customer");
            cbIdCust.DataSource = ds.Tables["customer"];
            cbIdCust.DisplayMember = "ID";
            cbIdCust.ValueMember = "ID";

            cmd = "select distinct g.id_gudang as ID, g.nama_gudang as Nama from h_sales_order h join gudang g " +
                "on h.id_gudang = g.id_gudang";

            if (!id.Equals(""))
            {
                cmd += " where id_sales_order = '" + id + "'";
                ds.Tables["gudang"].Clear();
            }

            daGudang = new OracleDataAdapter(cmd, conn);
            daGudang.Fill(ds, "gudang");
            cbGudang.DataSource = ds.Tables["gudang"];
            cbGudang.DisplayMember = "Nama";
            cbGudang.ValueMember = "ID";

            cmd = "select distinct h.id_staff as ID, nama_staff as Nama from h_sales_order h join staff s on h.id_staff = s.id_staff";

            if (!id.Equals(""))
            {
                cmd += " where id_sales_order = '" + id + "'";
                ds.Tables["staff"].Clear();
            }

            daStaff = new OracleDataAdapter(cmd, conn);
            daStaff.Fill(ds, "staff");
            cbNamaSales.DataSource = ds.Tables["staff"];
            cbNamaSales.DisplayMember = "Nama";
            cbNamaSales.ValueMember = "ID";

            cmd = "select distinct ship_via as ID, nama_ekspedisi as Nama from h_sales_order join ekspedisi on ship_via = id_ekspedisi";

            if (!id.Equals(""))
            {
                cmd += " where id_sales_order = '" + id + "'";
                ds.Tables["ekspedisi"].Clear();
                MessageBox.Show(cmd);
            }

            daEkspedisi = new OracleDataAdapter(cmd, conn);
            daEkspedisi.Fill(ds, "ekspedisi");
            cbShipVia.DataSource = ds.Tables["ekspedisi"];
            cbShipVia.DisplayMember = "Nama";
            cbShipVia.ValueMember = "ID";

            cmd = "select distinct a.id_negara as ID, b.nama_negara as Nama from h_sales_order a join negara  b on b.id_negara = a.id_negara";

            if (!id.Equals(""))
            {
                cmd += " where id_sales_order = '" + id + "'";
                ds.Tables["negara"].Clear();
            }

            daNegara = new OracleDataAdapter(cmd, conn);
            daNegara.Fill(ds, "negara");
            cbNegara.DataSource = ds.Tables["negara"];
            cbNegara.DisplayMember = "Nama";
            cbNegara.ValueMember = "ID";

            cmd = "select distinct currency_sales_order as ID, nama_currency as Nama from h_sales_order h join currency c on currency_sales_order = id_currency";

            if (!id.Equals(""))
            {
                cmd += " where id_sales_order = '" + id + "'";
                ds.Tables["currency"].Clear();

                daCurrency = new OracleDataAdapter(cmd, conn);
                daCurrency.Fill(ds, "currency");
                txtRate.Text = "1 : " + new OracleCommand("select rate from h_sales_order where id_sales_order = '" + id_so + "'", conn).ExecuteScalar().ToString();
            }

            daCurrency = new OracleDataAdapter(cmd, conn);
            daCurrency.Fill(ds, "currency");
            cbCurrency.DataSource = ds.Tables["currency"];
            cbCurrency.DisplayMember = "Nama";
            cbCurrency.ValueMember = "ID";

            if (!id.Equals(""))
            {
                cmd = "select credit_term_sales_order from h_sales_order where id_sales_order = '" + id + "'";
                cbCreditTerm.Text = new OracleCommand(cmd, conn).ExecuteScalar().ToString() + " Days";

                cmd = "select total from h_sales_order where id_sales_order = '" + id + "'";
                txtTotal.Text = "Rp " + Convert.ToInt32(new OracleCommand(cmd, conn).ExecuteScalar().ToString());

                cmd = "select total_ppn from h_sales_order where id_sales_order = '" + id + "'";
                txtTotalPPN.Text = "Rp " + Convert.ToInt32(new OracleCommand(cmd, conn).ExecuteScalar().ToString());

                cmd = "select total_harga from h_sales_order where id_sales_order = '" + id + "'";
                txtNetTotal.Text = "Rp " + new OracleCommand(cmd, conn).ExecuteScalar().ToString();

                cmd = "select total_harga_convert from h_sales_order where id_sales_order = '" + id + "'";
                txtTotalConvert.Text = cbCurrency.SelectedValue.ToString() + " " + new OracleCommand(cmd, conn).ExecuteScalar().ToString();

                isiDataItem(id);
            }
        }

        void isiDataItem(String id)
        {
            String cmd = "select * from d_sales_order where id_sales_order = '" + id + "'";
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
                ds.Tables["item"].Rows.Add(newRow);
            }
            dataGridView.DataSource = ds.Tables["item"];
        }

        private void pnlAtas_Enter(object sender, EventArgs e)
        {

        }

        public List<String> groupSO = new List<String>();

        private void btnSearchSO_Click(object sender, EventArgs e)
        {
            formSearchSO search = new formSearchSO(this);
            if (search.ShowDialog() == DialogResult.Yes)
            {
                if (!this.id_so.Equals(""))
                {
                    isiDataItem(search.id_so);

                    int total = Convert.ToInt32(txtTotal.Text.Substring(3));
                    int totalPPN = Convert.ToInt32(txtTotalPPN.Text.Substring(3));
                    int netTotal = Convert.ToInt32(txtNetTotal.Text.Substring(3));
                    int totalConvert = Convert.ToInt32(txtTotalConvert.Text.Substring(4));

                    String cmd = "select total from h_sales_order where id_sales_order = '" + search.id_so + "'";
                    txtTotal.Text = "Rp " + (total + Convert.ToInt32(new OracleCommand(cmd, conn).ExecuteScalar().ToString()));

                    cmd = "select total_ppn from h_sales_order where id_sales_order = '" + search.id_so + "'";
                    txtTotalPPN.Text = "Rp " + (totalPPN + Convert.ToInt32(new OracleCommand(cmd, conn).ExecuteScalar().ToString()));

                    cmd = "select total_harga from h_sales_order where id_sales_order = '" + search.id_so + "'";
                    txtNetTotal.Text = "Rp " + (netTotal + Convert.ToInt32(new OracleCommand(cmd, conn).ExecuteScalar().ToString()));

                    cmd = "select total_harga_convert from h_sales_order where id_sales_order = '" + search.id_so + "'";
                    txtTotalConvert.Text = cbCurrency.SelectedValue.ToString() + " " + (totalConvert + Convert.ToInt32(new OracleCommand(cmd, conn).ExecuteScalar().ToString()));
                }
                else
                {
                    this.id_so = search.id_so;
                    ambilDataSO(this.id_so);
                }
            }
            this.groupSO.Add(search.id_so);
        }

        private void cbIdCust_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        void overwrite()
        {
            if (dataGridView.Rows.Count <= 0)
            {
                MessageBox.Show("Mohon tambahkan setidaknya 1 item");
                return;
            }
            if (cbCreditTerm.SelectedIndex < 0)
            {
                MessageBox.Show("Pilih Credit Term");
                return;
            }

            int creditTerm = 1;
            if (cbCreditTerm.Text != "Cash" && cbCreditTerm.Text != "COD")
            {
                creditTerm = Convert.ToInt32(cbCreditTerm.Text.Substring(0, 2));
            }

            String id_customer = cbIdCust.SelectedValue + "";
            String id_gudang = cbGudang.SelectedValue + "";
            String id_DO = txtIdDO.Text;
            String id_staff = cbNamaSales.SelectedValue + "";
            DateTime tanggalDO = dateDO.Value;
            String shipVia = cbShipVia.SelectedValue + "";
            String negara = cbNegara.SelectedValue + "";
            String currency = cbCurrency.SelectedValue + "";
            int rate = Convert.ToInt32(txtRate.Text.Substring(4));
            int total = Convert.ToInt32(txtTotal.Text.Substring(3));
            int totalPPN = Convert.ToInt32(txtTotalPPN.Text.Substring(3));
            int netTotal = Convert.ToInt32(txtNetTotal.Text.Substring(3));
            int convert = Convert.ToInt32(txtTotalConvert.Text.Substring(4));
            MessageBox.Show(negara);

            OracleCommand cmd = new OracleCommand("update h_delivery_order " +
                "set " +
                "total = :total, " +
                "total_ppn = :totalPPN, " +
                "total_harga = :netTotal, " +
                "total_harga_convert = :convert " +
                "where id_delivery_order = '" + id_DO + "'", conn);

            cmd.Parameters.Add(":total", total);
            cmd.Parameters.Add(":totalPPN", totalPPN);
            cmd.Parameters.Add(":netTotal", netTotal);
            cmd.Parameters.Add(":convert", convert);

            cmd.ExecuteNonQuery();

            //Delete last dokumen
            cmd = new OracleCommand("delete from d_delivery_order where id_delivery_order = '" + id_DO + "'", conn);
            cmd.ExecuteNonQuery();

            for (int i = 0; i < ds.Tables["item"].Rows.Count; i++)
            {
                String id_item = ds.Tables["item"].Rows[i][0].ToString();
                String id_SO = ds.Tables["item"].Rows[i][1].ToString();
                String nama_item = ds.Tables["item"].Rows[i][2].ToString();
                String qty_item = ds.Tables["item"].Rows[i][3].ToString();
                String satuan_item = ds.Tables["item"].Rows[i][4].ToString();
                String hJual_item = ds.Tables["item"].Rows[i][5].ToString();
                String berat_item = ds.Tables["item"].Rows[i][6].ToString();
                String jenis_ppn = ds.Tables["item"].Rows[i][7].ToString();
                String discount = ds.Tables["item"].Rows[i][8].ToString();
                String subtotal = ds.Tables["item"].Rows[i][9].ToString();

                new OracleCommand("update h_sales_order set id_delivery_order = '" + id_DO + "' where id_sales_order = '" + id_SO + "'", conn).ExecuteNonQuery();
                OracleCommand cmdDetail = new OracleCommand("insert into d_delivery_order values (:id, :so, :do, :nama, :qty, :jenis, :harga, :berat, :ppn, :discount, :subtotal)", conn);
                cmdDetail.Parameters.Add(":id", id_item);
                cmdDetail.Parameters.Add(":so", id_SO);
                cmdDetail.Parameters.Add(":do", id_DO);
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

        void save()
        {
            if (dataGridView.Rows.Count <= 0)
            {
                MessageBox.Show("Mohon tambahkan setidaknya 1 item");
                return;
            }
            if (cbCreditTerm.SelectedIndex < 0)
            {
                MessageBox.Show("Pilih Credit Term");
                return;
            }

            int creditTerm = 1;
            if (cbCreditTerm.Text != "Cash" && cbCreditTerm.Text != "COD")
            {
                creditTerm = Convert.ToInt32(cbCreditTerm.Text.Substring(0, 2));
            }

            String id_customer = cbIdCust.SelectedValue + "";
            String id_gudang = cbGudang.SelectedValue + "";
            String id_DO = txtIdDO.Text;
            String id_staff = cbNamaSales.SelectedValue + "";
            DateTime tanggalDO = dateDO.Value;
            String shipVia = cbShipVia.SelectedValue + "";
            String negara = cbNegara.SelectedValue + "";
            String currency = cbCurrency.SelectedValue + "";
            int rate = Convert.ToInt32(txtRate.Text.Substring(4));
            int total = Convert.ToInt32(txtTotal.Text.Substring(3));
            int totalPPN = Convert.ToInt32(txtTotalPPN.Text.Substring(3));
            int netTotal = Convert.ToInt32(txtNetTotal.Text.Substring(3));
            int convert = Convert.ToInt32(txtTotalConvert.Text.Substring(4));

            OracleCommand cmd = new OracleCommand("insert into h_delivery_order values (:id, :customer, :gudang, :staff, :nama, :alamat, :tgl, :credit, :ship,:negara ,:currency, :rate, :total, :totalPPN, :netTotal, :convert)", conn);
            cmd.Parameters.Add(":id", id_DO);
            cmd.Parameters.Add(":customer", id_customer);
            cmd.Parameters.Add(":gudang", id_gudang);
            cmd.Parameters.Add(":staff", id_staff);
            cmd.Parameters.Add(":nama", txtNamaCust.Text);
            cmd.Parameters.Add(":alamat", txtAlamatCust.Text);
            cmd.Parameters.Add(":tgl", tanggalDO);
            cmd.Parameters.Add(":credit", creditTerm);
            cmd.Parameters.Add(":ship", shipVia);
            cmd.Parameters.Add(":negara", negara);
            cmd.Parameters.Add(":currency", currency);
            cmd.Parameters.Add(":rate", rate);
            cmd.Parameters.Add(":total", total);
            cmd.Parameters.Add(":totalPPN", totalPPN);
            cmd.Parameters.Add(":netTotal", netTotal);
            cmd.Parameters.Add(":convert", convert);
            cmd.ExecuteNonQuery();

            for (int i = 0; i < ds.Tables["item"].Rows.Count; i++)
            {
                String id_item = ds.Tables["item"].Rows[i][0].ToString();
                String id_SO = ds.Tables["item"].Rows[i][1].ToString();
                String nama_item = ds.Tables["item"].Rows[i][2].ToString();
                String qty_item = ds.Tables["item"].Rows[i][3].ToString();
                String satuan_item = ds.Tables["item"].Rows[i][4].ToString();
                String hJual_item = ds.Tables["item"].Rows[i][5].ToString();
                String berat_item = ds.Tables["item"].Rows[i][6].ToString();
                String jenis_ppn = ds.Tables["item"].Rows[i][7].ToString();
                String discount = ds.Tables["item"].Rows[i][8].ToString();
                String subtotal = ds.Tables["item"].Rows[i][9].ToString();

                new OracleCommand("update h_sales_order set id_delivery_order = '" + id_DO + "' where id_sales_order = '" + id_SO + "'", conn).ExecuteNonQuery();
                OracleCommand cmdDetail = new OracleCommand("insert into d_delivery_order values (:id, :so, :do, :nama, :qty, :jenis, :harga, :berat, :ppn, :discount, :subtotal)", conn);
                cmdDetail.Parameters.Add(":id", id_item);
                cmdDetail.Parameters.Add(":so", id_SO);
                cmdDetail.Parameters.Add(":do", id_DO);
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

            String cmdString = "select distinct id_sales_order from d_delivery_order where id_delivery_order = '" + id_DO + "'";
            OracleDataReader reader = new OracleCommand(cmdString, conn).ExecuteReader();
            while (reader.Read())
            {
                new OracleCommand("update h_sales_order set id_delivery_order = '" + id_DO + "' where id_sales_order = '" + reader.GetValue(0) + "'", conn).ExecuteNonQuery();
            }

            saved = true;
            MessageBox.Show("Save berhasil");
        }
        
        Boolean saved = false;

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

        public String id_do;

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

            this.id_do = txtIdDO.Text;
            new formPreviewDO(this).ShowDialog();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
            master.Show();
        }

        private void cbCreditTerm_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
