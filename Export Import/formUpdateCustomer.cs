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
    public partial class formUpdateCustomer : Form
    {
        OracleConnection conn;
        formListCustomer form;

        public formUpdateCustomer()
        {
            InitializeComponent();
        }

        public formUpdateCustomer(formListCustomer form)
        {
            InitializeComponent();
            this.form = form;
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNama.Text.Length == 0 || txtAlamat.Text.Length == 0)
                {
                    MessageBox.Show("Nama dan Alamat harus di isi");
                    return;
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

                String id_customer = form.data[0];

                OracleCommand cmd2;
                cmd2 = new OracleCommand("update customer set nama_customer = :nama, alamat_customer = :alamat, no_telp_customer = :nomer, email_customer = :email where id_customer = '" + id_customer + "'", conn);
                cmd2.Parameters.Add(":nama", txtNama.Text);
                cmd2.Parameters.Add(":alamat", txtAlamat.Text);
                cmd2.Parameters.Add(":nomer", txtNoTelp.Text);
                cmd2.Parameters.Add(":email", txtEmail.Text);
                cmd2.ExecuteNonQuery();//ini buat insert update delete

                conn.Close();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }

        private void formUpdateCustomer_Load(object sender, EventArgs e)
        {
            txtNama.Text = form.data[1];
            txtAlamat.Text = form.data[2];
            txtNoTelp.Text = form.data[3];
            txtEmail.Text = form.data[4];

            conn = new OracleConnection("user id=export;password=import;data source=orcl");
            try
            {
                conn.Open();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
