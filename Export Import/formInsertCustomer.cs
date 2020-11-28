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
    public partial class formInsertCustomer : Form
    {
        formListCustomer form;
        OracleConnection conn;

        public formInsertCustomer()
        {
            InitializeComponent();
        }

        public formInsertCustomer(formListCustomer form)
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

                String id_customer = txtNama.Text[0].ToString();
                int i = 0;
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
                    id_customer += txtNama.Text[1];
                }
                else
                {
                    id_customer += txtNama.Text[i + 1];
                }

                id_customer = id_customer.ToUpper();

                OracleCommand command;
                command = new OracleCommand("select count(id_customer)+1 from customer where id_customer like '" + id_customer + "%'", conn);
                
                int jum = Convert.ToInt32(command.ExecuteScalar());

                if (jum < 10)
                {
                    id_customer += "00" + jum;
                }
                else if (jum < 100)
                {
                    id_customer += "0" + jum;
                }
                else
                {
                    id_customer += jum;
                }

                OracleCommand cmd2;
                cmd2 = new OracleCommand("insert into customer values(:id, :nama, :alamat, :nomer, :email)", conn);
                cmd2.Parameters.Add(":id", id_customer);
                cmd2.Parameters.Add(":nama", txtNama.Text);
                cmd2.Parameters.Add(":alamat", txtAlamat.Text);
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

        private void formInsertCustomer_Load(object sender, EventArgs e)
        {
            conn = new OracleConnection("user id=export;password=import;data source=orcl");
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }
    }
}
