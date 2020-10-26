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
    public partial class formPreviewSI : Form
    {
        formStockIssue form;

        public formPreviewSI()
        {
            InitializeComponent();
        }

        public formPreviewSI(formStockIssue form)
        {
            InitializeComponent();
            this.form = form;
        }

        private void formPreviewSI_Load(object sender, EventArgs e)
        {
            PreviewStockIssue rep = new PreviewStockIssue();
            rep.SetDatabaseLogon("export", "import", "orcl", "");
            rep.SetParameterValue("id_si", form.id_si);
            crystalReportViewer.ReportSource = rep;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
