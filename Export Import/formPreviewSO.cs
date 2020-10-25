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
    public partial class formPreviewSO : Form
    {
        formSalesOrder form;

        public formPreviewSO()
        {
            InitializeComponent();
        }

        public formPreviewSO(formSalesOrder form)
        {
            InitializeComponent();
            this.form = form;
        }

        private void formPreviewSO_Load(object sender, EventArgs e)
        {
            PreviewSalesOrder rep = new PreviewSalesOrder();
            rep.SetDatabaseLogon("export", "import", "orcl", "");
            rep.SetParameterValue("ID_SO", form.id_so);
            crystalReportViewer.ReportSource = rep;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
