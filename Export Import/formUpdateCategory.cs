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
    public partial class formUpdateCategory : Form
    {
        formMasterCategory form;
        OracleConnection conn;

        public formUpdateCategory()
        {
            InitializeComponent();
        }

        public formUpdateCategory(formMasterCategory form)
        {
            InitializeComponent();
            this.form = form;
        }

        private void formUpdateCategory_Load(object sender, EventArgs e)
        {
            txtNama.Text = form.nama;
            conn = form.conn;
            conn.Open();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtNama.Text.Length == 0)
            {
                MessageBox.Show("Nama harus di isi");
                return;
            }

            OracleCommand cmd;
            cmd = new OracleCommand("select id_category from category where nama_category = '" + form.nama + "'", conn);
            String id_category = cmd.ExecuteScalar().ToString();

            OracleCommand cmd2;
            cmd2 = new OracleCommand("update category set nama_category = :nama where id_category = '" + id_category + "'", conn);
            cmd2.Parameters.Add(":nama", txtNama.Text);

            if (DialogResult.Yes == MessageBox.Show("Anda yakin mau update category "+ id_category +" dengan nama " + txtNama.Text, "Confirmation", MessageBoxButtons.YesNo))
            {
                cmd2.ExecuteNonQuery();//ini buat insert update delete

                conn.Close();
                this.Close();
            }
        }
    }
}
