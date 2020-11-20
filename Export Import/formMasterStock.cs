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
    public partial class formMasterStock : Form
    {
        formMasterGudang form;
        public OracleConnection conn;
        public String admin;

        public formMasterStock()
        {
            InitializeComponent();
            conn = new OracleConnection("user id=export;password=import;data source=orcl");
            conn.Open();
        }

        public formMasterStock(formMasterGudang form)
        {
            InitializeComponent();
            this.form = form;
            this.conn = form.conn;
            this.admin = form.admin;
        }

        private void lblBack_Click(object sender, EventArgs e)
        {
            this.Close();
            form.Show();
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            this.Hide();
            new formListStock(this).Show();
        }

        private void btnStockIssue_Click(object sender, EventArgs e)
        {
            this.Hide();
            new formStockIssue(this).Show();
        }

        private void formMasterStock_Load(object sender, EventArgs e)
        {
            this.Text += " : " + admin;
        }
    }
}
