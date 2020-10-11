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
    public partial class formInsertCategory : Form
    {
        formMasterCategory form;
        OracleConnection conn;

        public formInsertCategory()
        {
            InitializeComponent();
        }

        public formInsertCategory(formMasterCategory form)
        {
            InitializeComponent();
            this.form = form;
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (txtNama.Text.Length == 0)
            {
                MessageBox.Show("Nama harus di isi");
                return;
            }

            String id_category = txtNama.Text[0].ToString().ToUpper();

            OracleCommand cmd;
            cmd = new OracleCommand("select count(id_category)+1 from category where id_category like '" + id_category + "%'", conn);
            int jum = Convert.ToInt32(cmd.ExecuteScalar());

            if (jum < 10)
            {
                id_category += "0" + jum;
            }
            else
            {
                id_category += jum;
            }

            OracleCommand cmd2;
            cmd2 = new OracleCommand("insert into category values(:id,  :nama)", conn);
            cmd2.Parameters.Add(":id", id_category);
            cmd2.Parameters.Add(":nama", txtNama.Text);

            if (DialogResult.Yes == MessageBox.Show("Anda yakin mau input category baru dengan nama " + txtNama.Text, "Confirmation", MessageBoxButtons.YesNo))
            {
                cmd2.ExecuteNonQuery();//ini buat insert update delete
                conn.Close();
                this.Close();
            }
        }

        private void formInsertCategory_Load(object sender, EventArgs e)
        {
            conn = form.conn;

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

        String keyChar = "";

        private void txtNama_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyChar = e.KeyChar.ToString();
        }

        private void txtNama_KeyUp(object sender, KeyEventArgs e)
        {
            if (keyChar.Equals(" ") && txtNama.Text.Length == 1)
            {
                txtNama.Text = "";
                MessageBox.Show("Karakter pertama tidak boleh Spasi");
            }
        }
    }
}
