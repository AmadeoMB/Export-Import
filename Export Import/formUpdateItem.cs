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
    public partial class formUpdateItem : Form
    {
        formListStock form;
        OracleConnection conn;

        public formUpdateItem()
        {
            InitializeComponent();
        }

        public formUpdateItem(formListStock form)
        {
            InitializeComponent();
            this.form = form;
            this.conn = form.conn;
        }

        private void formUpdateItem_Load(object sender, EventArgs e)
        {
            cbCategory.DataSource = form.ds.Tables["category"];
            cbCategory.ValueMember = "ID";
            cbCategory.DisplayMember = "Category";
            
            txtNama.Text = form.data[1];
            cbCategory.SelectedValue = form.data[2];
            txtBerat.Text = form.data[3].Substring(0, form.data[3].Length - 1);
            txtPanjang.Text = form.data[4].Substring(0,form.data[4].Length - 2);
            txtTinggi.Text = form.data[5].Substring(0, form.data[5].Length - 2);
            txtLebar.Text = form.data[6].Substring(0, form.data[6].Length - 2);
            txtKadarAir.Text = form.data[7].Substring(0, form.data[7].Length - 1);
            cbSatuan.Text = form.data[9];
            txtHargaJual.Text = form.data[10].Substring(3).Replace(",", "").Replace(" ", "");
            txtHargaBeli.Text = form.data[11].Substring(3).Replace(",", "").Replace(" ", "");

            if (form.data[8].Equals("EXC"))
            {
                rbEXC.Checked = true;
            }
            else
            {
                rbINC.Checked = true;
            }
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
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            txtHargaJual.Text = txtHargaJual.Text.Replace(",", "");
            txtHargaBeli.Text = txtHargaBeli.Text.Replace(",", "");

            if (!cekAngka(txtBerat))
            {
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

            if (cbSatuan.SelectedIndex < 0)
            {
                MessageBox.Show("Mohon pilih satuan barang");
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
            cmd2 = new OracleCommand("update item set id_category = :category,  nama_item = :nama, satuan_item = :satuan, harga_jual_item = :hJual, harga_beli_item = :hBeli, " +
                "berat_item = :berat, panjang_item = :panjang, tinggi_item = :tinggi, lebar_item = :lebar, " +
                "kadar_air_item = :kadar, jenis_ppn = :ppn where id_item = '" + form.data[0] + "'", conn);
            cmd2.Parameters.Add(":category", cbCategory.SelectedValue);
            cmd2.Parameters.Add(":nama", txtNama.Text);
            cmd2.Parameters.Add(":satuan", cbSatuan.Text);
            cmd2.Parameters.Add(":hJual", txtHargaJual.Text);
            cmd2.Parameters.Add(":hBeli", txtHargaBeli.Text);
            cmd2.Parameters.Add(":berat", txtBerat.Text);
            cmd2.Parameters.Add(":panjang", txtPanjang.Text);
            cmd2.Parameters.Add(":tinggi", txtTinggi.Text);
            cmd2.Parameters.Add(":lebar", txtLebar.Text);
            cmd2.Parameters.Add(":kadar", txtKadarAir.Text);
            cmd2.Parameters.Add(":ppn", ppn);
            cmd2.ExecuteNonQuery();//ini buat insert update delete

            this.Close();
        }
    }
}
