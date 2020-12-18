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
    public partial class FormListPurchaseInvoice : Form
    {
        public OracleConnection conn;
        public formMasterPembelian pembelian;
        OracleDataAdapter daPI;
        DataSet ds = new DataSet();
        public FormListPurchaseInvoice()
        {
            InitializeComponent();
            this.conn = new OracleConnection("user id=export;password=import;data source=orcl");
            this.conn.Open();
        }

        private void FormListPurchaseInvoice_Load(object sender, EventArgs e)
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
                "select h.id_Purchase_invoice as id, nama_supplier as nama, tgl_Purchase_invoice as tanggal, ( " +
                    "select count(d.id_item) " +
                    "from d_Purchase_invoice d " +
                    "where d.id_Purchase_invoice = h.id_Purchase_invoice" +
                " ) as jumlah from h_Purchase_invoice h ";

            daPI = new OracleDataAdapter(cmd, conn);
            daPI.Fill(ds, "pi");
            dataGridView.DataSource = ds.Tables["pi"];
        }
    }
}
