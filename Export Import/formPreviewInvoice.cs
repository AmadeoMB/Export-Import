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
    public partial class formPreviewInvoice : Form
    {
        formInvoice form;

        public formPreviewInvoice()
        {
            InitializeComponent();
        }

        public formPreviewInvoice(formInvoice form)
        {
            InitializeComponent();
            this.form = form;
        }

        private void formPreviewInvoice_Load(object sender, EventArgs e)
        {
            PreviewInvoice rep = new PreviewInvoice();
            rep.SetDatabaseLogon("export", "import", "orcl", "");
            rep.SetParameterValue("id_si", form.id_invoice);
            crystalReportViewer.ReportSource = rep;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
