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
    public partial class formMasterStock : Form
    {
        Form form;

        public formMasterStock()
        {
            InitializeComponent();
        }

        public formMasterStock(Form form)
        {
            InitializeComponent();
            this.form = form;
        }

        private void lblBack_Click(object sender, EventArgs e)
        {
            this.Close();
            form.Show();
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            this.Hide();
            new formListStock(this).Show();
        }
    }
}
