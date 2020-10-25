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
    public partial class formPreviewPO : Form
    {
        formPurchaseOrder form;

        public formPreviewPO()
        {
            InitializeComponent();
        }

        public formPreviewPO(formPurchaseOrder form)
        {
            InitializeComponent();
            this.form = form;
        }

        private void formPreviewPO_Load(object sender, EventArgs e)
        {
            PreviewPurchaseOrder rep = new PreviewPurchaseOrder();
            rep.SetDatabaseLogon("export", "import", "orcl", "");
            rep.SetParameterValue("ID_po", form.id_po);
            crystalReportViewer.ReportSource = rep;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
