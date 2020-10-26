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
    public partial class formPreviewDO : Form
    {
        formDeliveryOrder form;

        public formPreviewDO()
        {
            InitializeComponent();
        }

        public formPreviewDO(formDeliveryOrder form)
        {
            InitializeComponent();
            this.form = form;
        }

        private void formPreviewDO_Load(object sender, EventArgs e)
        {
            PreviewDeliveryOrder rep = new PreviewDeliveryOrder();
            rep.SetDatabaseLogon("export", "import", "orcl", "");
            rep.SetParameterValue("ID_do", form.id_do);
            crystalReportViewer.ReportSource = rep;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
