﻿using Oracle.DataAccess.Client;
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
    public partial class formMasterPenjualan : Form
    {
        private LoginForm form = null;
        public OracleConnection conn;
        public String admin = "";

        public formMasterPenjualan()
        {
            InitializeComponent();
        }

        public formMasterPenjualan(LoginForm form)
        {
            InitializeComponent();
            this.form = form;
            this.conn = form.conn;
            this.admin = form.user;
        }

        private void lblStock_Click(object sender, EventArgs e)
        {
            this.Hide();
            new formListStock(this).Show();
        }

        private void lblCustomer_Click(object sender, EventArgs e)
        {
            this.Hide();
            new formListCustomer(this).Show();
        }

        private void btnSO_Click(object sender, EventArgs e)
        {
            this.Hide();
            new formSalesOrder(this).Show();
        }

        private void btnInvoice_Click(object sender, EventArgs e)
        {
            this.Hide();
            new formInvoice(this).Show();
        }

        private void formMasterPenjualan_Load(object sender, EventArgs e)
        {
            if (this.form != null)
            {
                this.Text = this.Text + form.user;
            }
        }

        private void lblSignOut_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
            form.Show();
        }

        private void btnLaporanPenjualan_Click(object sender, EventArgs e)
        {
            new formLaporanPenjualan(this).ShowDialog();
        }
    }
}
