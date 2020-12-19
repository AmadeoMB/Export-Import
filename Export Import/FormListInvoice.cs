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
    public partial class formListInvoice : Form
    {
        public OracleConnection  conn;
        public formMasterPenjualan penjualanan;
        OracleDataAdapter daInvoice;
        DataSet ds = new DataSet();
        Object[] filter = { "", null, 0 };

        public formListInvoice()
        {
            InitializeComponent();
            this.conn = new OracleConnection("user id=export;password=import;data source=orcl");
            this.conn.Open();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {

        }

        private void formListInvoice_Load(object sender, EventArgs e)
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
                "select h.id_invoice as id, nama_customer as nama, tgl_invoice as tanggal, ( " +
                    "select count(d.id_item) " +
                    "from d_invoice d " +
                    "where d.id_invoice = h.id_invoice" +
                " ) as jumlah from h_invoice h ";

            daInvoice = new OracleDataAdapter(cmd, conn);
            daInvoice.Fill(ds, "invoice");
            dataGridView.DataSource = ds.Tables["invoice"];
        }


    }
}
