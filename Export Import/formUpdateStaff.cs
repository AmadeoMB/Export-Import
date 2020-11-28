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
    public partial class formUpdateStaff : Form
    {
        formMasterStaff form;
        OracleConnection conn;
        private OracleDataAdapter daJabatan;
        private DataSet ds = new DataSet();
        private Object[] data;

        public formUpdateStaff()
        {
            InitializeComponent();
        }

        public formUpdateStaff(formMasterStaff form)
        {
            InitializeComponent();
            this.form = form;
            this.data = form.data;
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

        private void formUpdateStaff_Load(object sender, EventArgs e)
        {
            conn = form.conn;

            try
            {
                isiCB();

                int id_jabatan = -1;
                string cmd = "select * from jabatan where nm_jabatan = '" + data[8].ToString() + "'";
                id_jabatan = Convert.ToInt32(new OracleCommand(cmd, conn).ExecuteScalar());

                txtNama.Text = data[1].ToString();
                cbJabatan.SelectedValue = id_jabatan;
                cbJabatan.Text = data[8].ToString();
                txtAlamat.Text = data[2].ToString();
                tanggalLahir.Value = Convert.ToDateTime(data[4]);
                txtNoTelp.Text = data[6].ToString();
                txtUsername.Text = data[7].ToString();
                txtEmail.Text = data[3].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
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

            OracleCommand cmd2;
            cmd2 = new OracleCommand("update staff set nama_staff = :nama, id_jabatan = :jabatan, username_staff = :username, tgl_lahir_staff = :lahir, alamat_staff = :alamat, nomer_telp_staff = :nomer, email_staff = :email where id_staff = '" + data[0] + "'", conn);
            cmd2.Parameters.Add(":nama", txtNama.Text);
            cmd2.Parameters.Add(":jabatan", cbJabatan.SelectedValue);
            cmd2.Parameters.Add(":username", txtUsername.Text);
            cmd2.Parameters.Add(":lahir", tanggalLahir.Value);
            cmd2.Parameters.Add(":alamat", txtAlamat.Text);
            cmd2.Parameters.Add(":nomer", txtNoTelp.Text);
            cmd2.Parameters.Add(":email", txtEmail.Text);
            cmd2.ExecuteNonQuery();//ini buat insert update delete
            this.Close();
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

        String keyChar = "";
        private void txtUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyChar = e.KeyChar.ToString();
        }

        private void txtUsername_KeyUp(object sender, KeyEventArgs e)
        {
            if (keyChar.Equals(" "))
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

        private void cbJabatan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbJabatan.SelectedValue + "" == "5")
            {
                groupBox1.Enabled = false;
                txtUsername.Text = "-";
                txtPassword.Text = "-";
                txtCPassword.Text = "-";
            }
            else
            {
                txtUsername.Text = "";
                txtPassword.Text = "";
                txtCPassword.Text = "";
            }
        }
    }
}