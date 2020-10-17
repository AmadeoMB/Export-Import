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
    public partial class formPurchaseOrder : Form
    {
        OracleConnection conn;
        OracleDataAdapter daSupplier;
        DataSet ds;
        public formPurchaseOrder()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
        public void isicbsupplier() { 
            daSupplier = new OracleDataAdapter("select id_supplier as ID, nama_supplier as nama from supplier", conn);
            ds = new DataSet();
            daSupplier.Fill(ds, "supplier");
            cbcreditor.DataSource = ds.Tables["supplier"];
            cbcreditor.ValueMember = "ID";
            cbcreditor.DisplayMember = "nama";
        
        }
        private void formPurchaseOrder_Load(object sender, EventArgs e)
        {
            conn = new OracleConnection("user id=export;password=import;data source=orcl");
            conn.Open();
            isicbsupplier();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
