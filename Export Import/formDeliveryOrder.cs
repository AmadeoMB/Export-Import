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
        private OracleDataAdapter daItem;
        private DataSet ds = new DataSet();
        private Stack<Object[]> done = new Stack<Object[]>(100);
        private Stack<Object[]> undone = new Stack<Object[]>(100);

        public formDeliveryOrder()
        {
            InitializeComponent();
        }

        public formDeliveryOrder(formMasterGudang master)
        {
            InitializeComponent();
            this.master = master;
        }

        private void formDeliveryOrder_Load(object sender, EventArgs e)
        {
            conn = new OracleConnection("user id=export;password=import;data source=orcl");

            try
            {
                conn.Open();

                isiCBCustomer();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }

        void isiCBCustomer()
        {
            String cmd = "select distinct c.id_customer, c.nama_customer, c.alamat_customer from h_sales_order h join customer c " +
                "on h.id_customer = c.id_customer";
            daCustomer = new OracleDataAdapter(cmd, conn);
            daCustomer.Fill(ds, "customer");
            cbIdCust.DataSource = ds.Tables["customer"];
            cbIdCust.DisplayMember = "id_customer";
            cbIdCust.ValueMember = "id_customer";
        }

        private void pnlAtas_Enter(object sender, EventArgs e)
        {

        }
    }
}
