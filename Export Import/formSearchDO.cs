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
    public partial class formSearchDO : Form
    {
        private formInvoice form;
        private OracleConnection conn;
        private OracleDataAdapter daDeliveryOrder;
        private DataSet ds = new DataSet();
        private int idx = -1;


        public String id_do = "";

        public formSearchDO()
        {
            InitializeComponent();
        }

        public formSearchDO(formInvoice form)
        {
            InitializeComponent();
            this.form = form;
            this.conn = form.conn;
        }

        void refreshTable(String keyword)
        {
            String cmd = "select id_delivery_order, nama_customer, tgl_delivery_order from h_delivery_order " +
                "where id_delivery_order like '%" + keyword + "%' OR " +
                "nama_customer like '%" + keyword + "%'";
            daDeliveryOrder = new OracleDataAdapter(cmd, conn);
            daDeliveryOrder.Fill(ds, "DeliveryOrder");
            dataGridView.DataSource = ds.Tables["DeliveryOrder"];
        }

        private void formSearchDO_Load(object sender, EventArgs e)
        {
            refreshTable("");
        }

        private void txtKeyword_TextChanged(object sender, EventArgs e)
        {
            refreshTable(txtKeyword.Text);
        }

        private void btnGet_Click(object sender, EventArgs e)
        {
            this.id_do = dataGridView.Rows[idx].Cells[0].Value.ToString();
            this.DialogResult = DialogResult.Yes;
            this.Close();
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            idx = e.RowIndex;
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            idx = e.RowIndex;
        }
    }
}
