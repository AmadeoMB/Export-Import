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
    public partial class formUpdateEkspedisi : Form
    {
        formMasterEkspedisi form;
        OracleConnection conn;
        String id_ekspedisi;

        public formUpdateEkspedisi()
        {
            InitializeComponent();
        }

        public formUpdateEkspedisi(formMasterEkspedisi form)
        {
            InitializeComponent();
            this.form = form;
            this.conn = form.conn;
        }

        private void formUpdateEkspedisi_Load(object sender, EventArgs e)
        {
            this.id_ekspedisi = form.data[0].ToString();
            txtNama.Text = form.data[1].ToString();
            txtAlamat.Text = form.data[2].ToString();
            txtContactPerson.Text = form.data[3].ToString();
            txtNoTelp.Text = form.data[4].ToString();
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
            if (txtContactPerson.Text == "")
            {
                MessageBox.Show("Nama Contact Person harus di isi");
                return;
            }
            if (txtAlamat.Text == "")
            {
                MessageBox.Show("Alamat harus di isi");
                return;
            }

            try
            {
                if (txtNoTelp.Text.Length == 0)
                {
                    MessageBox.Show("Nomer telpon harus di isi");
                    return;
                }
                else if (txtNoTelp.Text.Length < 10 && txtNoTelp.Text.Length > 14)
                {
                    MessageBox.Show("Nomer telpon setidaknya 10 digit angka");
                    return;
                }
                foreach (char item in txtNoTelp.Text)
                {
                    int noTelp = Convert.ToInt32(item.ToString());
                }
            }
            catch
            {
                MessageBox.Show("No Telp harus berupa angka");
                txtNoTelp.Text = "";
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

            OracleCommand cmd = new OracleCommand("update ekspedisi set nama_ekspedisi = :nama, alamat_ekspedisi = :alamat, cp_ekspedisi = :cp, no_telp = :notelp where id_ekspedisi = '" + id_ekspedisi + "'", conn);
            cmd.Parameters.Add(":nama", txtNama.Text.ToUpper());
            cmd.Parameters.Add(":alamat", txtAlamat.Text.ToUpper());
            cmd.Parameters.Add(":cp", txtContactPerson.Text.ToUpper());
            cmd.Parameters.Add(":notelp", txtNoTelp.Text.ToUpper());
            cmd.ExecuteNonQuery();

            this.Close();
        }
    }
}
