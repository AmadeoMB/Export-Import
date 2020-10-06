using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Oracle.DataAccess.Client;

namespace Export_Import
{
    public partial class LoginForm : Form
    {
        public OracleConnection conn;
        public String user;

        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            conn = new OracleConnection("user id=export;password=import;data source=orcl");
            try
            {
                bool terisi = true;
                lblErrorPassword.Visible = false;
                lblErrorInput.Visible = false;
                lblErrorUsername.Visible = false;
                if (txtUsername.Text.Equals("") || txtUsername.Text.Equals("Email :"))
                {
                    lblErrorUsername.Visible = true;
                    terisi = !terisi;
                    return;
                }
                if (txtPassword.Text.Equals("") || txtPassword.Text.Equals("Password :"))
                {
                    lblErrorPassword.Visible = true;
                    terisi = !terisi;
                    return;
                }
                if (terisi)
                {
                    conn.Open();
                    OracleCommand cmd = new OracleCommand("SELECT count(*) from staff where username_staff = '"+ txtUsername.Text + "' AND password_staff = '" + txtPassword.Text + "'", conn);
                    int hasil = Convert.ToInt16(cmd.ExecuteScalar());

                    if (hasil == 1)
                    {
                        cmd = new OracleCommand("SELECT id_jabatan from staff where username_staff = :username AND password_staff = :pass", conn);
                        cmd.Parameters.Add(":username", txtUsername.Text);
                        cmd.Parameters.Add(":pass", txtPassword.Text);
                        int jabatan = Convert.ToInt16(cmd.ExecuteScalar());

                        cmd = new OracleCommand("SELECT nama_staff from staff where username_staff = :username AND password_staff = :pass", conn);
                        cmd.Parameters.Add(":username", txtUsername.Text);
                        cmd.Parameters.Add(":pass", txtPassword.Text);
                        user = cmd.ExecuteScalar().ToString();

                        conn.Close();
                        if (jabatan == 1)
                        {
                            //Form Gudang
                            this.Hide();
                            new formMasterGudang(this).ShowDialog();
                        }
                        else if (jabatan == 2)
                        {
                            //Form Penjualan
                            this.Hide();
                            new formMasterPenjualan(this).ShowDialog();
                        }
                        else if (jabatan == 3)
                        {
                            //Form Pembelian
                            this.Hide();
                            new formMasterPembelian(this).ShowDialog();
                        }
                        else if (jabatan == 4)
                        {
                            //Form Akutansi
                            this.Hide();
                            new formAkutansi(this).ShowDialog();
                        }
                    }
                    else
                    {
                        lblErrorInput.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }

        private void txtPassword_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtPassword.ForeColor == Color.Black)
                return;
            txtPassword.Text = "";
            txtPassword.ForeColor = Color.Black;
            txtPassword.PasswordChar = '*';
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtPassword.ForeColor == Color.Black)
                return;
            txtPassword.Text = "";
            txtPassword.ForeColor = Color.Black;
            txtPassword.PasswordChar = '*';
        }

        private void txtUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtUsername.ForeColor == Color.Black)
                return;
            txtUsername.Text = "";
            txtUsername.ForeColor = Color.Black;
        }

        private void txtUsername_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtUsername.ForeColor == Color.Black)
                return;
            txtUsername.Text = "";
            txtUsername.ForeColor = Color.Black;
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
    }
}
