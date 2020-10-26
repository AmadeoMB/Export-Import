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
    public partial class formMasterGudang : Form
    {
        private LoginForm form;
        public OracleConnection conn;
        public String admin;

        public formMasterGudang()
        {
            InitializeComponent();
        }

        public formMasterGudang(LoginForm form)
        {
            InitializeComponent();
            this.form = form;
            this.conn = form.conn;
            this.admin = form.user;
        }

        private void lblStock_Click(object sender, EventArgs e)
        {
            this.Hide();
            new formMasterStock(this).Show();
        }

        private void btnDO_Click(object sender, EventArgs e)
        {
            this.Hide();
            new formDeliveryOrder(this).Show();
        }

        private void lblSignOut_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
            form.Show();
        }

        private void formMasterGudang_Load(object sender, EventArgs e)
        {
            if (this.form != null)
            {
                this.Text = this.Text + form.user;
            }
        }

        private void btnSO_Click(object sender, EventArgs e)
        {
            this.Hide();
            new formListSalesOrder(this).Show();
        }
    }
}
