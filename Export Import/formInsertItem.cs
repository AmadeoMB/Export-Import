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
    public partial class formInsertItem : Form
    {
        formListStock form;
        OracleConnection conn;

        public formInsertItem()
        {
            InitializeComponent();
        }

        public formInsertItem(formListStock form)
        {
            InitializeComponent();
            this.form = form;
            this.conn = form.conn;
        }

        private void formInsertItem_Load(object sender, EventArgs e)
        {
            cbCategory.DataSource = form.ds.Tables["category"];
            cbCategory.ValueMember = "ID";
            cbCategory.DisplayMember = "Category";
            cbCategory.SelectedIndex = form.ds.Tables["category"].Rows.Count - 1;
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
                foreach (char item in text.Text)
                {
                    int temp = Convert.ToInt32(item.ToString());
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
            txtHargaJual.Text = txtHargaJual.Text.Replace(",", "");
            txtHargaBeli.Text = txtHargaBeli.Text.Replace(",", "");

            if (!cekAngka(txtBerat)) {
                return;
            }
            if (!cekAngka(txtHargaBeli))
            {
                return;
            }
            if (!cekAngka(txtHargaJual))
            {
                return;
            }
            if (!cekAngka(txtKadarAir))
            {
                return;
            }
            if (!cekAngka(txtLebar))
            {
                return;
            }
            if (!cekAngka(txtPanjang))
            {
                return;
            }
            if (!cekAngka(txtTinggi))
            {
                return;
            }

            if (txtNama.Text.Length == 0)
            {
                MessageBox.Show("Nama harus di isi");
                return;
            }

            if (!rbEXC.Checked && !rbINC.Checked)
            {
                MessageBox.Show("Pilih jenis PPN");
                return;
            }

            if (cbCategory.SelectedIndex == form.ds.Tables["category"].Rows.Count - 1)
            {
                MessageBox.Show("Pilih category barang");
                return;
            }

            String id_item = txtNama.Text[0].ToString();
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
                id_item += txtNama.Text[1];
            }
            else
            {
                id_item += txtNama.Text[i + 1];
            }

            OracleCommand cmd;
            cmd = new OracleCommand("select count(id_item)+1 from item where id_item like '" + id_item + "%'", conn);
            int jum = Convert.ToInt32(cmd.ExecuteScalar());

            if (jum < 10)
            {
                id_item += "00" + jum;
            }
            else if (jum < 100)
            {
                id_item += "0" + jum;
            }
            else
            {
                id_item += jum;
            }

            string ppn = "";

            if (rbEXC.Checked)
            {
                ppn += "EXC";
            }
            else
            {
                ppn += "INC";
            }

            OracleCommand cmd2;
            cmd2 = new OracleCommand("insert into item values(:id, :category, :gudang, :nama, :stok, :satuan, :hJual, :hBeli, :berat, :panjang, :tinggi, :lebar, :kadar, :balance, :ppn)", conn);
            cmd2.Parameters.Add(":id", id_item);
            cmd2.Parameters.Add(":category", cbCategory.SelectedValue);
            cmd2.Parameters.Add(":gudang", "-");
            cmd2.Parameters.Add(":nama", txtNama.Text);
            cmd2.Parameters.Add(":stok", '0');
            cmd2.Parameters.Add(":satuan", cbSatuan.Text);
            cmd2.Parameters.Add(":hJual", txtHargaJual.Text);
            cmd2.Parameters.Add(":hBeli", txtHargaBeli.Text);
            cmd2.Parameters.Add(":berat", txtBerat.Text);
            cmd2.Parameters.Add(":panjang", txtPanjang.Text);
            cmd2.Parameters.Add(":tinggi", txtTinggi.Text);
            cmd2.Parameters.Add(":lebar", txtLebar.Text);
            cmd2.Parameters.Add(":kadar", txtKadarAir.Text);
            cmd2.Parameters.Add(":balance", '0');
            cmd2.Parameters.Add(":ppn", ppn);
            cmd2.ExecuteNonQuery();//ini buat insert update delete

            this.DialogResult = DialogResult.Yes;
            this.Close();
        }

        private void rbEXC_CheckedChanged(object sender, EventArgs e)
        {
            if (rbEXC.Checked)
            {
                rbINC.Checked = false;
            }
        }

        private void rbINC_CheckedChanged(object sender, EventArgs e)
        {
            if (rbINC.Checked)
            {
                rbEXC.Checked = false;
            }
        }
    }
}
