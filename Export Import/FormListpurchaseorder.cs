using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
namespace Export_Import
{
    public partial class FormListPurchaseOrder : Form
    {
        public OracleConnection conn;
        public formMasterPembelian pembelian;
        OracleDataAdapter daPO;
        DataSet ds = new DataSet();
        public FormListPurchaseOrder()
        {
            InitializeComponent();
            this.conn = new OracleConnection("user id=export;password=import;data source=orcl");
            this.conn.Open();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {

        }

        private void FormListPurchaseOrder_Load(object sender, EventArgs e)
        {
            try
            {
                refreshTable();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }
        void refreshTable()
        {
            String cmd =
                "select h.id_purchase_order as id, nama_supplier as nama, tgl_purchase_order as tanggal, ( " +
                    "select count(d.id_item) " +
                    "from d_purchase_order d " +
                    "where d.id_purchase_order = h.id_purchase_order" +
                " ) as jumlah from h_purchase_order h ";

            daPO = new OracleDataAdapter(cmd, conn);
            daPO.Fill(ds, "po");
            dataGridView.DataSource = ds.Tables["po"];
        }
    }
}
