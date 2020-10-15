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

        private void btnPlus_Click(object sender, EventArgs e)
        {
            formSearchItem search = new formSearchItem(this);

            if (search.ShowDialog() != DialogResult.Cancel)
            {
                String cmd = "select id_item, nama_item, " +
                    search.data[1] + " as discount, " +
                    search.data[2] + " as qty_item " +
                    "from item " +
                    "where id_item = '" + search.data[0] + "'";

                daItem = new OracleDataAdapter(cmd, conn);
                daItem.Fill(ds, "item");
                dataGridView.DataSource = ds.Tables["item"];
            }
        }
    }
}
