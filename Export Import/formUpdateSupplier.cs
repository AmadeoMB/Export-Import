using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Client;

namespace Export_Import
{
    public partial class formUpdateSupplier : Form
    {
        formListSupplier form;
        OracleConnection conn;

        public formUpdateSupplier()
        {
            InitializeComponent();
        }

        public formUpdateSupplier(formListSupplier form)
        {
            InitializeComponent();
            this.form = form;
        }

        private void formUpdateSupplier_Load(object sender, EventArgs e)
        {
            txtNama.Text = form.data[1];
            txtAlamat.Text = form.data[2];
            cbProvinsi.Text = form.data[3];
            txtNoTelp.Text = form.data[4];
            txtEmail.Text = form.data[5];

            conn = form.conn;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
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

                String id_supplier = form.data[0];
                OracleCommand cmd2;
                cmd2 = new OracleCommand("update SUPPLIER set nama_supplier = :nama, alamat_supplier = :alamat, provinsi_supplier = :provinsi, no_telp_supplier = :nomer, email_supplier = :email where id_supplier = '" + id_supplier + "'", conn);
                cmd2.Parameters.Add(":nama", txtNama.Text);
                cmd2.Parameters.Add(":alamat", txtAlamat.Text);
                cmd2.Parameters.Add(":provinsi", cbProvinsi.Text);
                cmd2.Parameters.Add(":nomer", txtNoTelp.Text);
                cmd2.Parameters.Add(":email", txtEmail.Text);
                cmd2.ExecuteNonQuery();//ini buat insert update delete

                conn.Close();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal update supplier");
                MessageBox.Show(ex.Message);
            }
        }
    }
}
