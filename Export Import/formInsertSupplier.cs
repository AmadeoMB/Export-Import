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
    public partial class formInsertSupplier : Form
    {
        formListSupplier form;
        OracleConnection conn;

        public formInsertSupplier()
        {
            InitializeComponent();
        }

        public formInsertSupplier(formListSupplier form)
        {
            InitializeComponent();
            this.form = form;
            this.conn = form.conn;
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            try
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

                try
                {
                    if (txtNoTelp.Text.Length == 0)
                    {
                        MessageBox.Show("Nomer telpon harus di isi");
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

                bool emailBenar = false;
                foreach (var item in txtEmail.Text)
                {
                    if (item.ToString().Equals("@"))
                    {
                        emailBenar = true;
                    }
                }

                if (!emailBenar)
                {
                    MessageBox.Show("Email harus dimasukkan dengan benar");
                    txtEmail.Text = "";
                    return;
                }

                if (txtNama.Text.Length == 0 || txtAlamat.Text.Length == 0)
                {
                    MessageBox.Show("Semua data harus diisi");
                    return;
                }

                String id_supplier = cbProvinsi.Text[0].ToString();
                int i = 0;
                for (; i < cbProvinsi.Text.Length; i++)
                {
                    int num = Convert.ToInt32(cbProvinsi.Text[i]);
                    if (num == 32)
                    {
                        break;
                    }
                }

                if (i == cbProvinsi.Text.Length)
                {
                    id_supplier += cbProvinsi.Text[1];
                }
                else
                {
                    id_supplier += cbProvinsi.Text[i + 1];
                }

                id_supplier = id_supplier.ToUpper();

                OracleCommand cmd;
                cmd = new OracleCommand("select count(id_supplier)+1 from supplier where id_supplier like '" + id_supplier + "%'", conn);
                int jum = Convert.ToInt32(cmd.ExecuteScalar());

                if (jum < 10)
                {
                    id_supplier += "00" + jum;
                }
                else if (jum < 100)
                {
                    id_supplier += "0" + jum;
                }
                else
                {
                    id_supplier += jum;
                }

                OracleCommand cmd2;
                cmd2 = new OracleCommand("insert into SUPPLIER values(:id, :nama, :alamat, :provinsi, :nomer, :email)", conn);
                cmd2.Parameters.Add(":id", id_supplier);
                cmd2.Parameters.Add(":nama", txtNama.Text);
                cmd2.Parameters.Add(":alamat", txtAlamat.Text);
                cmd2.Parameters.Add(":provinsi", cbProvinsi.Text);
                cmd2.Parameters.Add(":nomer", txtNoTelp.Text);
                cmd2.Parameters.Add(":email", txtEmail.Text);
                cmd2.ExecuteNonQuery();//ini buat insert update delete

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal tambahkan supplier");
                MessageBox.Show(ex.Message);
            }
        }

        private void formInsertSupplier_Load(object sender, EventArgs e)
        {

        }
    }
}
