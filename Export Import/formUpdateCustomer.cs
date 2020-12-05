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
        OracleDataAdapter daNegara;
        DataTable dtNegara = new DataTable();

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

                if (cbNegara.SelectedIndex < 0)
                {
                    MessageBox.Show("Masukkan negara!");
                    return;
                }

                String id_customer = form.data[0];

                OracleCommand cmd2;
                cmd2 = new OracleCommand("update customer set nama_customer = :nama, alamat_customer = :alamat, id_negara = :negara, no_telp_customer = :nomer, email_customer = :email where id_customer = '" + id_customer + "'", conn);
                cmd2.Parameters.Add(":nama", txtNama.Text);
                cmd2.Parameters.Add(":alamat", txtAlamat.Text);
                cmd2.Parameters.Add(":negara", cbNegara.SelectedValue);
                cmd2.Parameters.Add(":nomer", txtNoTelp.Text);
                cmd2.Parameters.Add(":email", txtEmail.Text);
                cmd2.ExecuteNonQuery();//ini buat insert update delete

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }

        private void isiCBNegara()
        {
            daNegara = new OracleDataAdapter("select id_negara, nama_negara from negara", conn);
            daNegara.Fill(dtNegara);
            cbNegara.DataSource = dtNegara;
            cbNegara.DisplayMember = "nama_negara";
            cbNegara.ValueMember = "id_negara";
        }

        private void cariNegara(String nama)
        {
            String id = new OracleCommand("select id_negara from negara where nama_negara = '" + nama + "'", conn).ExecuteScalar().ToString();
            cbNegara.Text = nama;
            cbNegara.SelectedValue = id;
        }

        private void formUpdateCustomer_Load(object sender, EventArgs e)
        {
            txtNama.Text = form.data[1];
            txtAlamat.Text = form.data[2];
            String negara = form.data[3];
            txtNoTelp.Text = form.data[4];
            txtEmail.Text = form.data[5];

            this.conn = form.conn;
            isiCBNegara();
            cariNegara(negara);
        }
    }
}
