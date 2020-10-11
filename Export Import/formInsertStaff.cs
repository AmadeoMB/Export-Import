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
    public partial class formInsertStaff : Form
    {
        formMasterStaff form;
        OracleConnection conn;
        private OracleDataAdapter daJabatan;
        private DataSet ds = new DataSet();

        public formInsertStaff()
        {
            InitializeComponent();
        }

        public formInsertStaff(formMasterStaff form)
        {
            InitializeComponent();
            this.form = form;
        }

        void isiCB()
        {
            string cmd = "select * from jabatan";

            daJabatan = new OracleDataAdapter(cmd, conn);
            daJabatan.Fill(ds, "jabatan");
            cbJabatan.DataSource = ds.Tables["jabatan"];
            cbJabatan.DisplayMember = "nm_jabatan";
            cbJabatan.ValueMember = "id_jabatan";
        }

        private void formInsertUser_Load(object sender, EventArgs e)
        {
            conn = form.conn;

            conn.Open();
            isiCB();
        }

        private bool cekAngka(TextBox text)
        {
            try
            {
                if (text.Text.Length == 0)
                {
                    MessageBox.Show(text.Name.Substring(3) + " harus di isi");
                    return false;
                }
                foreach (char staff in text.Text)
                {
                    int temp = Convert.ToInt32(staff.ToString());
                }
                return true;
            }
            catch
            {
                MessageBox.Show(text.Name.Substring(3) + " harus diisi berupa angka");
                text.Text = "";
                return false;
            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (!cekAngka(txtNoTelp))
            {
                return;
            }

            if (txtNama.Text.Length == 0)
            {
                MessageBox.Show("Nama harus di isi");
                return;
            }

            if (txtAlamat.Text.Length == 0)
            {
                MessageBox.Show("Alamat harus di isi");
                return;
            }

            String email = "";
            if (txtEmail.Text.Length == 0)
            {
                if (MessageBox.Show("Apakah anda yakin Staff anda tidak mempunyai email?", "Email Kosong", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    email = "-";
                    return;
                }
            }
            else
            {
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
                email = txtEmail.Text;
            }

            if (!txtPassword.Text.Equals(txtCPassword.Text))
            {
                txtPassword.Text = "";
                txtCPassword.Text = "";

                MessageBox.Show("Password tidak sama dengan Confirm Password");
                return;
            }

            String id_staff = txtNama.Text[0].ToString();
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
                id_staff += txtNama.Text[1];
            }
            else
            {
                id_staff += txtNama.Text[i + 1];
            }

            OracleCommand cmd;
            cmd = new OracleCommand("select count(id_staff)+1 from staff where id_staff like '" + id_staff + "%'", conn);
            int jum = Convert.ToInt32(cmd.ExecuteScalar());

            if (jum < 10)
            {
                id_staff += "00" + jum;
            }
            else if (jum < 100)
            {
                id_staff += "0" + jum;
            }
            else
            {
                id_staff += jum;
            }

            OracleCommand cmd2;
            cmd2 = new OracleCommand("insert into staff values(:id, :jabatan, :nama, :username, :password, :lahir, :alamat, :nomer, SYSDATE, :email)", conn);
            cmd2.Parameters.Add(":id", id_staff);
            cmd2.Parameters.Add(":jabatan", cbJabatan.SelectedValue);
            cmd2.Parameters.Add(":nama", txtNama.Text);
            cmd2.Parameters.Add(":username", txtUsername.Text);
            cmd2.Parameters.Add(":password", txtPassword.Text);
            cmd2.Parameters.Add(":lahir", tanggalLahir.Value);
            cmd2.Parameters.Add(":alamat", txtAlamat.Text);
            cmd2.Parameters.Add(":nomer", txtNoTelp.Text);
            cmd2.Parameters.Add(":email", txtEmail.Text);
            cmd2.ExecuteNonQuery();//ini buat insert update delete

            conn.Close();
            this.Close();
        }

        String keyChar = "";

        private void txtUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyChar = e.KeyChar.ToString();
        }

        private void txtUsername_KeyUp(object sender, KeyEventArgs e)
        {
            if (keyChar == " ")
            {
                String text = "";
                for (int i = 0; i < txtUsername.Text.Length - 1; i++)
                {
                    text += txtUsername.Text[i];
                }
                txtUsername.Text = text;
                MessageBox.Show("Tidak boleh ada spasi pada username");
            }
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyChar = e.KeyChar.ToString();
        }

        private void txtPassword_KeyUp(object sender, KeyEventArgs e)
        {
            if (keyChar == " ")
            {
                String text = "";
                for (int i = 0; i < txtUsername.Text.Length - 1; i++)
                {
                    text += txtUsername.Text[i];
                }
                txtUsername.Text = text;
                MessageBox.Show("Tidak boleh ada spasi pada password");
            }
        }
    }
}
