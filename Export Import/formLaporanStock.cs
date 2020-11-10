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
    public partial class formLaporanStock : Form
    {
        formListStock form;
        OracleConnection conn;

        public formLaporanStock()
        {
            InitializeComponent();
        }

        public formLaporanStock(formListStock form)
        {
            InitializeComponent();
            this.form = form;
            this.conn = form.conn;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
            form.Show();
        }

        private void formPreviewLaporanStock_Load(object sender, EventArgs e)
        {
            LaporanStock rep = new LaporanStock();
            rep.SetDatabaseLogon("export", "import", "orcl", "");
            rep.SetParameterValue("id_nama", form.admin);
            crystalReportViewer.ReportSource = rep;
        }
    }
}
