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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            bool terisi = true;
            lblErrorPassword.Visible = false;
            lblErrorInput.Visible = false;
            lblErrorEmail.Visible = false;
            if (txtEmail.Text.Equals("") || txtEmail.Text.Equals("Email :"))
            {
                lblErrorEmail.Visible = true;
                terisi = !terisi;
            }
            if (txtPassword.Text.Equals("") || txtPassword.Text.Equals("Password :"))
            {
                lblErrorPassword.Visible = true;
                terisi = !terisi;
            }
            if (terisi)
            {
                if (txtEmail.Text.Equals("gudang@gmail.com") && txtPassword.Text.Equals("admingudang"))
                {
                    //Form Gudang
                    this.Hide();
                    new formMasterGudang().ShowDialog();
                }
                else if (txtEmail.Text.Equals("penjualan@gmail.com") && txtPassword.Text.Equals("adminpenjualan"))
                {
                    //Form Penjualan
                    this.Hide();
                    new formMasterPenjualan().ShowDialog();
                }
                else if (txtEmail.Text.Equals("pembelian@gmail.com") && txtPassword.Text.Equals("adminpembelian"))
                {
                    //Form Pembelian
                    this.Hide();
                    new formMasterPembelian().ShowDialog();
                }
                else if (txtEmail.Text.Equals("akutansi@gmail.com") && txtPassword.Text.Equals("adminakutansi"))
                {
                    //Form Akutansi
                    this.Hide();
                    new formAkutansi().ShowDialog();
                }
                else
                {
                    lblErrorInput.Visible = true;
                }
            }
        }

        private void txtEmail_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtEmail.ForeColor == Color.Black)
                return;
            txtEmail.Text = "";
            txtEmail.ForeColor = Color.Black;
        }

        private void txtPassword_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtPassword.PasswordChar == '*')
                return;
            txtPassword.Text = "";
            txtPassword.ForeColor = Color.Black;
            txtPassword.PasswordChar = '*';
        }
    }
}
