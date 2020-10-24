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
    public partial class formSearchItem : Form
    {
        formSalesOrder formSO; formPurchaseOrder formPO; formStockIssue formSI;
        OracleDataAdapter daItem;
        DataSet ds = new DataSet();
        OracleConnection conn;
        public Object[] data;

        public formSearchItem()
        {
            InitializeComponent();
        }

        public formSearchItem(formSalesOrder form)
        {
            InitializeComponent();
            this.formSO = form;
            this.conn = form.conn;
        }

        public formSearchItem(formPurchaseOrder form)
        {
            InitializeComponent();
            this.formPO = form;
            this.conn = form.conn;
        }

        public formSearchItem(formStockIssue form)
        {
            InitializeComponent();
            this.formSI = form;
            this.conn = form.conn;
        }

        private void checkDiscount_CheckedChanged(object sender, EventArgs e)
        {
            if (checkDiscount.Checked) {
                numDiscount.Enabled = true;
            }
            else
            {
                numDiscount.Enabled = false;
            }
        }

        void refreshTable()
        {
            String cmd = "select id_item, nama_item, ";
            if (formSO != null)
            {
                cmd += "harga_jual_item as harga";
            }
            else
            {
                cmd += "harga_beli_item as harga";
            }
            cmd += " from item";

            daItem = new OracleDataAdapter(cmd, conn);
            daItem.Fill(ds, "item");
            dataGridView.DataSource = ds.Tables["item"];
        }

        void refreshTable(String keyword)
        {
            keyword = keyword.ToLower();

            String cmd = "select id_item, nama_item, ";
            if (formSO != null)
            {
                cmd += "harga_jual_item as harga";
            }
            else { 
                cmd += "harga_beli_item as harga";
            }
            cmd += " from item where Lower(id_item) like '%" + keyword +"%' OR Lower(nama_item) like '%"+ keyword +"%'";

            daItem = new OracleDataAdapter(cmd, conn);
            daItem.Fill(ds, "item");
            dataGridView.DataSource = ds.Tables["item"];
        }

        private void formSearchItem_Load(object sender, EventArgs e)
        {
            refreshTable();

            if (formSI != null)
            {
                groupDiscount.Enabled = false;
            }
        }

        private void txtKeyword_TextChanged(object sender, EventArgs e)
        {
            ds.Tables["item"].Clear();
            refreshTable(txtKeyword.Text);
        }

        private void btnGet_Click(object sender, EventArgs e)
        {
            if (idx != -1)
            {
                if (numQty.Value > 0)
                {
                    decimal discount = 0;
                    if (checkDiscount.Checked)
                    {
                        discount = numDiscount.Value;
                    }
                    Object[] temp = {
                        dataGridView.Rows[idx].Cells[0].Value.ToString(),
                        discount,
                        numQty.Value
                    };

                    this.data = temp;

                    this.DialogResult = DialogResult.Yes;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Qty tolong di isi");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Select Item!!");
                return;
            }
        }

        int idx = -1;

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            idx = e.RowIndex;
        }
    }
}
