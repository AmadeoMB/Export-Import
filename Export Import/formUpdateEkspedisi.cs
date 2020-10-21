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
    public partial class formUpdateEkspedisi : Form
    {
        formMasterEkspedisi form;
        String id_ekspedisi;

        public formUpdateEkspedisi()
        {
            InitializeComponent();
        }

        public formUpdateEkspedisi(formMasterEkspedisi form)
        {
            InitializeComponent();
            this.form = form;
        }

        private void formUpdateEkspedisi_Load(object sender, EventArgs e)
        {
            this.id_ekspedisi = form.data[0].ToString();
            txtNama.Text = form.data[1].ToString();
        }

        String keyChar = "";

        private void txtNama_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.keyChar = e.KeyChar.ToString();
            if (txtNama.Text.Length == 1 && keyChar.Equals(" "))
            {
                txtNama.Text = "";
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtNama.Text == "")
            {
                MessageBox.Show("Nama harus di isi");
                return;
            }

            int j = 0;
            for (; j < txtNama.Text.Length; j++)
            {
                int num = Convert.ToInt32(txtNama.Text[j]);
                if (num == 32 || num == 46)
                {
                    break;
                }
            }

            if (txtNama.Text[0].ToString().ToLower().Equals("p") && txtNama.Text[1].ToString().ToLower().Equals("t"))
            {
                MessageBox.Show("Test");
                if (txtNama.Text[j + 1].Equals(' '))
                {
                    txtNama.Text = "PT. " + txtNama.Text.Substring(j + 2);
                }
                else
                {
                    txtNama.Text = "PT. " + txtNama.Text.Substring(j + 1);
                }
            }
            else
            {
                txtNama.Text = "PT. " + txtNama.Text;
            }
        }
    }
}
