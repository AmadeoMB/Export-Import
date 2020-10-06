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
    public partial class formAkutansi : Form
    {
        LoginForm form;

        public formAkutansi()
        {
            InitializeComponent();
        }

        public formAkutansi(LoginForm form)
        {
            InitializeComponent();
            this.form = form;
        }

        private void formAkutansi_Load(object sender, EventArgs e)
        {
            this.Text += form.user;
        }
    }
}
