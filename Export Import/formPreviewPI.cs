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
    public partial class formPreviewPI : Form
    {
        formPurchaseInvoice form;

        public formPreviewPI()
        {
            InitializeComponent();
        }

        public formPreviewPI(formPurchaseInvoice form)
        {
            InitializeComponent();
            this.form = form;
        }

        private void formPreviewPI_Load(object sender, EventArgs e)
        {
            PreviewPurchaseInvoice rep = new PreviewPurchaseInvoice();
            rep.SetDatabaseLogon("export", "import", "orcl", "");
            rep.SetParameterValue("ID_pi", form.id_pi);
            crystalReportViewer.ReportSource = rep;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
