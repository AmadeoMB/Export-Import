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
    public partial class formTransferDocument : Form
    {
        formPurchaseInvoice form;
        public Object[] data;

        public formTransferDocument()
        {
            InitializeComponent();
        }

        public formTransferDocument(formPurchaseInvoice form)
        {
            InitializeComponent();
            this.form = form;
        }

        private void formTransferDocument_Load(object sender, EventArgs e)
        {
            lblNamaItem.Text = form.dataItem[0].ToString();
            numQty.Value = Convert.ToInt32(form.dataItem[1].ToString());
        }

        private void btnSet_Click(object sender, EventArgs e)
        {
            Object[] temp = {
                lblNamaItem.Text,
                numQty.Value,
                numKadar.Value
            };
            this.data = temp;

            this.DialogResult = DialogResult.Yes;
            this.Close();
        }
    }
}
