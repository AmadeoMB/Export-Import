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
    public partial class formMasterPembelian : Form
    {
        LoginForm form;
        public OracleConnection conn;
        public String admin;

        public formMasterPembelian()
        {
            InitializeComponent();
        }

        public formMasterPembelian(LoginForm form)
        {
            InitializeComponent();
            this.form = form;
            this.conn = form.conn;
            this.admin = form.user;
        }

        private void btnPO_Click(object sender, EventArgs e)
        {
            this.Hide();
            new formPurchaseOrder(this).Show();
        }

        private void btnPI_Click(object sender, EventArgs e)
        {
            this.Hide();
            new formPurchaseInvoice(this).Show();
        }

        private void lblSupplier_Click(object sender, EventArgs e)
        {
            this.Hide();
            new formListSupplier(this).Show();
        }

        private void lblSignOut_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
            form.Show();
        }

        private void formMasterPembelian_Load(object sender, EventArgs e)
        {
            this.Text += form.user;
        }

        private void btnLaporanPembelian_Click(object sender, EventArgs e)
        {

        }
    }
}
