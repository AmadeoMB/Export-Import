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
    public partial class formInsertEkspedisi : Form
    {
        formMasterEkspedisi form;
        OracleConnection conn;

        public formInsertEkspedisi()
        {
            InitializeComponent();
        }

        public formInsertEkspedisi(formMasterEkspedisi form)
        {
            InitializeComponent();
            this.form = form;
            this.conn = form.conn;
        }

        private void formInsertEkspedisi_Load(object sender, EventArgs e)
        {

        }

        private void btnInsert_Click(object sender, EventArgs e)
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
                else if (txtNoTelp.Text.Length < 10 || txtNoTelp.Text.Length > 14)
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

            String id_ekspedisi = txtNama.Text.ToUpper().Substring(4, 1);
            int i = 4;
            for (; i < txtNama.Text.Length; i++)
            {
                int num = Convert.ToInt32(txtNama.Text[i]);
                if (num == 32)
                {
                    break;
                }
            }

            if (i == txtNama.Text.Length)
            {
                id_ekspedisi += txtNama.Text[1];
            }
            else
            {
                id_ekspedisi += txtNama.Text[i + 1];
            }

            id_ekspedisi = id_ekspedisi.ToUpper();

            String cmdId = "select count(*)+1 from ekspedisi where id_ekspedisi = '" + id_ekspedisi + "%'";
            int jum = Convert.ToInt32(new OracleCommand(cmdId, conn).ExecuteScalar());
            if (jum < 10)
            {
                id_ekspedisi += "00" + jum;
            }
            else if (jum < 100)
            {
                id_ekspedisi += "0" + jum;
            }
            else
            {
                id_ekspedisi += jum;
            }

            OracleCommand cmd = new OracleCommand("insert into ekspedisi values (:id, :nama, :alamat, :cp, :no)", conn);
            cmd.Parameters.Add(":id", id_ekspedisi);
            cmd.Parameters.Add(":nama", txtNama.Text);
            cmd.Parameters.Add(":alamat", txtAlamat.Text);
            cmd.Parameters.Add(":cp", txtContactPerson.Text);
            cmd.Parameters.Add(":no", txtNoTelp.Text);
            cmd.ExecuteNonQuery();

            this.Close();
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

        private void txtNama_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNama_KeyUp(object sender, KeyEventArgs e)
        {

        }
    }
}
