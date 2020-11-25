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
        private OracleDataAdapter daEkspedisi;
        private OracleDataAdapter daItem;
        private OracleDataAdapter daNegara;
        private DataSet ds = new DataSet();
        private Stack<Object[]> done = new Stack<Object[]>(100);
        private Stack<Object[]> undone = new Stack<Object[]>(100);
        private List<Int64> qtyList = new List<Int64>(999);
        private List<Int64> hJualList = new List<Int64>(999);
        private List<Int64> beratList = new List<Int64>(999);
        private List<Int64> subtotalList = new List<Int64>(999);
        private String admin;
        private Int64 total = 0;
        private Int64 totalPPN = 0;
        private Int64 netTotal = 0;
        private Int64 convertTotal = 0;

        public formSalesOrder()
        {
            InitializeComponent();
            this.conn = new OracleConnection("user id=export;password=import;data source=orcl");
            conn.Open();
        }

        public formSalesOrder(formMasterPenjualan master, string id_cust = "")
        {
            InitializeComponent();
            txtNamaCust.Text = id_cust;
            this.master = master;
            this.conn = master.conn;
            this.admin = master.admin;
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
        void isiCBNegara()
        {
            String cmd = "select * from negara";
            daNegara = new OracleDataAdapter(cmd, conn);
            daNegara.Fill(ds, "negara");
            cbNegara.DataSource = ds.Tables["negara"];
            cbNegara.DisplayMember = "nama_negara";
            cbNegara.ValueMember = "id_negara";
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
            nomerSO += dateSO.Value.ToString("/dd/MM/yyyy/");
            nomerSO += getNomerSO(nomerSO);

            txtIdSO.Text = nomerSO;
        }

        void isiCBSales() {
            String cmd = "select id_staff, nama_staff from staff where id_jabatan = 5";
            daStaff = new OracleDataAdapter(cmd, conn);
            daStaff.Fill(ds, "staff");
            cbStaff.DataSource = ds.Tables["staff"];
            cbStaff.DisplayMember = "nama_staff";
            cbStaff.ValueMember = "id_staff";
        }

        void isiCBShipVia()
        {
            String cmd = "select id_ekspedisi, nama_ekspedisi from ekspedisi";
            daEkspedisi = new OracleDataAdapter(cmd, conn);
            daEkspedisi.Fill(ds, "ekspedisi");
            cbShip.DataSource = ds.Tables["ekspedisi"];
            cbShip.DisplayMember = "nama_ekspedisi";
            cbShip.ValueMember = "id_ekspedisi";
        }

        private void formSalesOrder_Load(object sender, EventArgs e)
        {
            this.dataGridView.Columns["subtotal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dataGridView.Columns["harga_satuan"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dateSO.Value = DateTime.Today;

            try
            {
                isiCBCustomer();
                isiCBCurrency();
                isiCBShipVia();
                isiCBGudang();
                isiCBSales();
                isiCBNegara();
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
            Int64 discount = Convert.ToInt64(data[1]);
            Int64 qty = Convert.ToInt64(data[2]);
            qtyList.Add(qty);
            object id_item = data[0]; 

            //Hitung Subtotal Kotor
            String cmd = "select harga_jual_item from item where id_item ='" + id_item + "'";
            Int64 hargaJual = Convert.ToInt64(new OracleCommand(cmd, conn).ExecuteScalar());
            Int64 subtotal = hargaJual * qty;
            hJualList.Add(hargaJual);

            //Hitung Discount
            Int64 totalDiscount = subtotal * discount / 100;
            subtotal -= totalDiscount;
            subtotalList.Add(subtotal);

            //Hitung berat
            cmd = "select berat_item from item where id_item='" + id_item + "'";
            Int64 berat = Convert.ToInt64(new OracleCommand(cmd, conn).ExecuteScalar());
            Int64 beratTotal = berat * qty;
            beratList.Add(beratTotal);

            if (dataGridView.Rows.Count > 1)
            {
                int i = 0;
                bool ada = false;
                for (; i < ds.Tables["item"].Rows.Count; i++)
                {
                    if (ds.Tables["item"].Rows[i][0].ToString().Equals(id_item))
                    {
                        ada = true;
                        break;
                    }
                }

                if (ada)
                {
                    qtyList[i] += qty;
                    beratList[i] += beratTotal;
                    subtotalList[i] += subtotal;
                    ds.Tables["item"].Rows[i][2] = qtyList[i].ToString("#,####");
                    ds.Tables["item"].Rows[i][5] = beratList[i].ToString("#,####") + " g";
                    ds.Tables["item"].Rows[i][8] = "Rp " + subtotalList[i].ToString("#,##0.00");

                    return;
                }
            }

            cmd = "select id_item, nama_item, '" +
                qty.ToString("#,###") + "' as qty_item, " +
                "satuan_item, 'Rp " +
                hargaJual.ToString("#,##0.00") + "' as harga_jual_item, '" +
                beratTotal.ToString("#,###") + " g' as berat, " +
                "jenis_ppn, " +
                discount + " as discount, 'Rp " +
                subtotal.ToString("#,##0.00") + "' as subtotal " +
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
            if (dataGridView.Rows.Count  <= 1 || idx == dataGridView.Rows.Count - 1)
            {
                MessageBox.Show("Barang kosong");
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
                subtotalList.RemoveAt(idx);
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
                    for (int i = 0; i < ds.Tables["item"].Rows.Count; i++)
                    {
                        if (ds.Tables["item"].Rows[i][0].ToString().Equals(temp[0]))
                        {
                            ds.Tables["item"].Rows.RemoveAt(i);
                            break;
                        }
                    }
                }
                refreshTotal();
            }
        }

        Boolean saved = false;

        void save()
        {
            if (dataGridView.Rows.Count <= 1)
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
            if (cbCreditTerm.Text != "Cash")
            {
                creditTerm = Convert.ToInt32(cbCreditTerm.Text.Substring(0, 2));
            }

            String id_customer = cbIdCust.SelectedValue + "";
            String id_gudang = cbGudang.SelectedValue + "";
            String id_SO = txtIdSO.Text;
            String id_staff = cbStaff.SelectedValue + "";
            DateTime tanggalSO = dateSO.Value;
            String shipVia = cbShip.SelectedValue + "";
            String Negara = cbNegara.SelectedValue + "";
            String currency = cbCurrency.SelectedValue + "";
            Int64 rate = Convert.ToInt64(ds.Tables["currency"].Rows[cbCurrency.SelectedIndex][2]);
            Int64 total = this.total;
            Int64 totalPPN = this.totalPPN;
            Int64 netTotal = this.netTotal;
            Int64 convert = this.convertTotal;

            OracleCommand cmd = new OracleCommand("insert into h_sales_order values (:id, :do, :gudang, :staff, :customer, :invoice, :nama, :alamat, :tgl, :credit, :ship,:negara ,:currency, :rate, :total, :totalPPN, :netTotal, :convert)", conn);
            cmd.Parameters.Add(":id", id_SO);
            cmd.Parameters.Add(":do", '-');
            cmd.Parameters.Add(":gudang", id_gudang);
            cmd.Parameters.Add(":staff", id_staff);
            cmd.Parameters.Add(":customer", id_customer);
            cmd.Parameters.Add(":invoice", '-');
            cmd.Parameters.Add(":nama", txtNamaCust.Text);
            cmd.Parameters.Add(":alamat", txtAlamatCust.Text);
            cmd.Parameters.Add(":tgl", tanggalSO);
            cmd.Parameters.Add(":credit", creditTerm);
            cmd.Parameters.Add(":ship", shipVia);
            cmd.Parameters.Add(":negara", Negara);
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
                String nama_item = ds.Tables["item"].Rows[i][1].ToString();
                String qty_item = qtyList[i].ToString();
                String satuan_item = ds.Tables["item"].Rows[i][3].ToString();
                String hJual_item = hJualList[i].ToString();
                String berat_item = beratList[i].ToString();
                String jenis_ppn = ds.Tables["item"].Rows[i][6].ToString();
                String discount = ds.Tables["item"].Rows[i][7].ToString();
                String subtotal = subtotalList[i].ToString();

                OracleCommand cmdDetail = new OracleCommand("insert into d_sales_order values (:id, :so, :nama, :qty, :jenis, :harga, :berat, :ppn, :discount, :subtotal)", conn);
                cmdDetail.Parameters.Add(":id", id_item);
                cmdDetail.Parameters.Add(":so", id_SO);
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

        void refreshTotal()
        {
            totalPPN = 0;
            total = 0;
            for (int i = 0; i < dataGridView.RowCount - 1; i++)
            {
                Int64 subtotal = subtotalList[i];
                total += Convert.ToInt64(subtotal);
                if (dataGridView.Rows[i].Cells[6].Value.Equals("EXC"))
                {
                    totalPPN += (subtotal / 10);
                }
            }
            txtTotal.Text = "Rp " + total.ToString("#,##0.00");

            txtTotalPPN.Text = "Rp " + totalPPN.ToString("#,##0.00");

            netTotal = (total + totalPPN);
            txtTotalHarga.Text = "Rp " + netTotal.ToString("#,##0.00");

            txtRate.Text = "1 : " + ds.Tables["currency"].Rows[cbCurrency.SelectedIndex][2];
            Int64 rate = Convert.ToInt64(ds.Tables["currency"].Rows[cbCurrency.SelectedIndex][2]);
            convertTotal = (netTotal / rate);
            txtTotalHargaConvert.Text = ds.Tables["currency"].Rows[cbCurrency.SelectedIndex][0] + " " + convertTotal.ToString("#,##0.00");
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
            cbCurrency.ValueMember = "id_currency";
        }

        private void cbCurrency_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtRate.Text = "1 : " + ds.Tables["currency"].Rows[cbCurrency.SelectedIndex][2].ToString();
            Int64 totalRp = netTotal;
            Int64 rate = Convert.ToInt64(ds.Tables["currency"].Rows[cbCurrency.SelectedIndex][2]);

            txtTotalHargaConvert.Text = ds.Tables["currency"].Rows[cbCurrency.SelectedIndex][0] + " " + (totalRp / rate).ToString("#,##0.00") ;
        }

        public String id_so = "";

        void overwrite()
        {
            if (dataGridView.Rows.Count <= 1)
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
            String id_SO = txtIdSO.Text;
            String id_staff = cbStaff.SelectedValue + "";
            DateTime tanggalSO = dateSO.Value;
            String shipVia = cbShip.Text;
            String negara = cbNegara.SelectedValue + "";
            String currency = cbCurrency.SelectedValue + "";
            Int64 rate = Convert.ToInt64(ds.Tables["currency"].Rows[cbCurrency.SelectedIndex][2]);
            Int64 total = this.total;
            Int64 totalPPN = this.totalPPN;
            Int64 netTotal = this.netTotal;
            Int64 convert = this.convertTotal;

            OracleCommand cmd = new OracleCommand("update h_sales_order " +
                "set " +
                "id_gudang = :gudang, " +
                "id_staff = :staff, " +
                "id_customer = :customer, " +
                "nama_customer = :nama, " +
                "alamat_customer = :alamat, " +
                "tgl_sales_order = :tgl, " +
                "credit_term_sales_order = :credit, " +
                "ship_via = :ship, " +
                "id_negara = :negara," +
                "currency_sales_order = :currency, " +
                "rate = :rate, " +
                "total = :total, " +
                "total_ppn = :totalPPN, " +
                "total_harga = :netTotal, " +
                "total_harga_convert = :convert " +
                "where id_sales_order = '" + id_so + "'", conn);

            cmd.Parameters.Add(":gudang", id_gudang);
            cmd.Parameters.Add(":staff", id_staff);
            cmd.Parameters.Add(":customer", id_customer);
            cmd.Parameters.Add(":nama", txtNamaCust.Text);
            cmd.Parameters.Add(":alamat", txtAlamatCust.Text);
            cmd.Parameters.Add(":tgl", tanggalSO);
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

            //Delete last delete
            cmd = new OracleCommand("delete from d_sales_order where id_sales_order = '" + id_SO + "'", conn);
            cmd.ExecuteNonQuery();

            for (int i = 0; i < ds.Tables["item"].Rows.Count; i++)
            {
                String id_item = ds.Tables["item"].Rows[i][0].ToString();
                String nama_item = ds.Tables["item"].Rows[i][1].ToString();
                String qty_item = qtyList[i].ToString();
                String satuan_item = ds.Tables["item"].Rows[i][3].ToString();
                String hJual_item = hJualList[i].ToString();
                String berat_item = beratList[i].ToString();
                String jenis_ppn = ds.Tables["item"].Rows[i][6].ToString();
                String discount = ds.Tables["item"].Rows[i][7].ToString();
                String subtotal = subtotalList [i].ToString();

                OracleCommand cmdDetail = new OracleCommand("insert into d_sales_order values (:id, :so, :nama, :qty, :jenis, :harga, :berat, :ppn, :discount, :subtotal)", conn);
                cmdDetail.Parameters.Add(":id", id_item);
                cmdDetail.Parameters.Add(":so", id_SO);
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
            this.id_so = txtIdSO.Text;

            new formPreviewSO(this).ShowDialog();
        }

        private void dataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2 && dataGridView.Rows.Count > 1)
            {
                object jumlah = dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                if (Convert.ToInt32(jumlah) != 0)
                {
                    ds.Tables["item"].Rows[e.RowIndex][e.ColumnIndex] = jumlah;
                    ds.Tables["item"].Rows[e.RowIndex][5] = Convert.ToInt32(jumlah) * Convert.ToInt32(ds.Tables["item"].Rows[e.RowIndex][4]);
                }
                else
                {
                    ds.Tables["item"].Rows.RemoveAt(e.RowIndex);
                }
                dataGridView.DataSource = ds.Tables["item"];
                refreshTotal();
            }
        }
    }
}
