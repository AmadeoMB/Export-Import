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
        private DataSet ds = new DataSet();
        private Stack<Object[]> done = new Stack<Object[]>(100);
        private Stack<Object[]> undone = new Stack<Object[]>(100);
        public String id_so = "";

        public formDeliveryOrder()
        {
            InitializeComponent();
        }

        public formDeliveryOrder(formMasterGudang master)
        {
            InitializeComponent();
            this.master = master;
        }

        public formDeliveryOrder(formListSalesOrder list)
        {
            InitializeComponent();
            this.master = list.gudang;
            this.id_so = list.id_sales_order;
        }

        private void formDeliveryOrder_Load(object sender, EventArgs e)
        {
            conn = new OracleConnection("user id=export;password=import;data source=orcl");

            try
            {
                conn.Open();

                setColomnDS();
                generatecreateNomerDO();
                ambilDataSO(id_so);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        void generatecreateNomerDO()
        {
            String nomerSO = "DO";
            nomerSO += dateDO.Value.ToString("ddMMyyyy");
            nomerSO += getNomerSO(nomerSO);

            txtIdDO.Text = nomerSO;
        }

        String getNomerSO(String id)
        {
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

        void setColomnDS()
        {
            String cmd = "select * from d_sales_order";
            daItem = new OracleDataAdapter(cmd, conn);
            daItem.Fill(ds, "item");

            ds.Tables["item"].Clear();
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
                txtNamaCust.Text = ds.Tables["customer"].Rows[0][1].ToString();
                txtAlamatCust.Text = ds.Tables["customer"].Rows[0][2].ToString();

                pnlAtas.Enabled = false;
            }

            daCustomer = new OracleDataAdapter(cmd, conn);
            daCustomer.Fill(ds, "customer");
            cbIdCust.DataSource = ds.Tables["customer"];
            cbIdCust.DisplayMember = "ID";
            cbIdCust.ValueMember = "Nama";

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
            cbGudang.DisplayMember = "ID";
            cbGudang.ValueMember = "Nama";

            cmd = "select distinct h.id_staff as ID, nama_staff as Nama from h_sales_order h join staff s on h.id_staff = s.id_staff";

            if (!id.Equals(""))
            {
                cmd += " where id_sales_order = '" + id + "'";
                ds.Tables["staff"].Clear();
            }

            daStaff = new OracleDataAdapter(cmd, conn);
            daStaff.Fill(ds, "staff");
            cbNamaSales.DataSource = ds.Tables["staff"];
            cbNamaSales.DisplayMember = "ID";
            cbNamaSales.ValueMember = "Nama";

            cmd = "select distinct ship_via as ID, nama_ekspedisi as Nama from h_sales_order join ekspedisi on ship_via = id_ekspedisi";

            if (!id.Equals(""))
            {
                cmd += " where id_sales_order = '" + id + "'";
                ds.Tables["ekspedisi"].Clear();
            }

            daEkspedisi = new OracleDataAdapter(cmd, conn);
            daEkspedisi.Fill(ds, "ekspedisi");
            cbShipVia.DataSource = ds.Tables["ekspedisi"];
            cbShipVia.DisplayMember = "ID";
            cbShipVia.ValueMember = "Nama";

            cmd = "select distinct currency_sales_order as ID, h.rate as Rate from h_sales_order h join currency c on currency_sales_order = id_currency";

            if (!id.Equals(""))
            {
                cmd += " where id_sales_order = '" + id + "'";
                ds.Tables["currency"].Clear();

                daCurrency = new OracleDataAdapter(cmd, conn);
                daCurrency.Fill(ds, "currency");
                txtRate.Text = "1 : " + ds.Tables["currency"].Rows[0][1];
            }

            daCurrency = new OracleDataAdapter(cmd, conn);
            daCurrency.Fill(ds, "currency");
            cbCurrency.DataSource = ds.Tables["currency"];
            cbCurrency.DisplayMember = "ID";
            cbCurrency.ValueMember = "Rate";

            if (!id.Equals(""))
            {
                cmd = "select credit_term_sales_order from h_sales_order where id_sales_order = '" + id + "'";
                cbCreditTerm.Text = new OracleCommand(cmd, conn).ExecuteScalar().ToString();

                cmd = "select total_harga from h_sales_order where id_sales_order = '" + id + "'";
                txtTotal.Text = new OracleCommand(cmd, conn).ExecuteScalar().ToString();

                cmd = "select total_harga_convert from h_sales_order where id_sales_order = '" + id + "'";
                txtTotalConvert.Text = new OracleCommand(cmd, conn).ExecuteScalar().ToString();

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
                newRow[10] = reader.GetValue(10).ToString();
                ds.Tables["item"].Rows.Add(newRow);
            }
            dataGridView.DataSource = ds.Tables["item"];
        }

        private void pnlAtas_Enter(object sender, EventArgs e)
        {

        }

        private void btnSearchSO_Click(object sender, EventArgs e)
        {
            formSearchSO search = new formSearchSO(this);
            if (search.ShowDialog() == DialogResult.Yes)
            {
                if (!this.id_so.Equals(""))
                {
                    isiDataItem(search.id_so);
                }
                else
                {
                    this.id_so = search.id_so;
                    ambilDataSO(this.id_so);
                }
            }
        }

        private void cbIdCust_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
