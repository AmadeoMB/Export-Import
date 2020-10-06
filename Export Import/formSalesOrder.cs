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
        private formMasterPenjualan master;
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
    }
}
