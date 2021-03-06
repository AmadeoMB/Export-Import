﻿using System;
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
    public partial class formListStock : Form
    {
        public OracleConnection conn;
        private OracleDataAdapter daItem;
        private OracleDataAdapter daCategory;
        public DataSet ds = new DataSet();
        public formMasterStock formS;
        public formMasterPenjualan formP;
        public String admin = "";
        public String[] data;

        public formListStock()
        {
            InitializeComponent();
            this.conn = new OracleConnection("user id=export;password=import;data source=orcl");
            this.conn.Open();
        }

        public formListStock(formMasterStock form)
        {
            InitializeComponent();
            this.formS = form;
        }

        public formListStock(formMasterPenjualan form)
        {
            InitializeComponent();
            this.formP = form;
        }

        public formListStock(Form form, DataSet ds, String keyword, int index)
        {
            InitializeComponent();
            isiCB();
            this.ds = ds;
            txtKeyword.Text = keyword;
            cbCategory.SelectedIndex = index;

            refreshTabel(keyword, index);
        }

        public void refreshTabel()
        {
            string cmd = "select " +
                "i.id_item as ID, " +
                "i.nama_item as Nama, " +
                "i.id_gudang as Lokasi, " +
                "c.nama_category as Category, " +
                "i.berat_item||'g' as Berat, " +
                "i.panjang_item||'cm' as Panjang, " +
                "i.tinggi_item||'cm' as Tinggi, " +
                "i.lebar_item||'cm' as Lebar, " +
                "i.kadar_air_item||'%' as Kadar, " +
                "'Rp '||TO_CHAR(i.harga_jual_item,'9G999G999') as hJual, " +
                "'Rp '||TO_CHAR(i.harga_beli_item,'9G999G999') as hBeli, " +
                "'Rp '||TO_CHAR(balance_cost,'999G999G999G999') as balance_cost, " +
                "satuan_item as Satuan, " +
                "jenis_ppn as PPN, " +
                "TO_CHAR(stok_item,'9G999G999') as Qty " +
                "from item i join category c on i.id_category = c.id_category";

            daItem = new OracleDataAdapter(cmd, conn);
            daItem.Fill(ds, "item");
            this.dataGridView.DataSource = ds.Tables["item"];
        }

        public void refreshTabel(string keyword, int index)
        {
            string cmd = "select " +
                "i.id_item as ID, " +
                "i.nama_item as Nama, " +
                "i.id_gudang as Lokasi, " +
                "c.nama_category as Category, " +
                "i.berat_item||'g' as Berat, " +
                "i.panjang_item||'cm' as Panjang, " +
                "i.tinggi_item||'cm' as Tinggi, " +
                "i.lebar_item||'cm' as Lebar, " +
                "i.kadar_air_item||'%' as Kadar, " +
                "'Rp '||TO_CHAR(i.harga_jual_item,'9G999G999') as hJual, " +
                "'Rp '||TO_CHAR(i.harga_beli_item,'9G999G999') as hBeli, " +
                "'Rp '||TO_CHAR(balance_cost,'999G999G999G999') as balance_cost, " +
                "satuan_item as Satuan, " +
                "jenis_ppn as PPN, " +
                "TO_CHAR(stok_item,'9G999G999') as Qty " +
                "from item i join category c on i.id_category = c.id_category " +
                "where (lower(i.nama_item) like '%" + keyword.ToLower() + "%' " +
                "or lower(i.id_item) like '%"+ keyword.ToLower() +"%')";
            if (index != ds.Tables["category"].Rows.Count - 1)
            {
                cmd += " AND i.id_category = '" + cbCategory.SelectedValue + "'";
            }

            daItem = new OracleDataAdapter(cmd, conn);
            daItem.Fill(ds, "item");
            this.dataGridView.DataSource = ds.Tables["item"];
        }

        public void refreshTabel(params object[] optional)
        {
            string cmd = "select " +
                "i.id_item as ID, " +
                "i.nama_item as Nama, " +
                "i.id_gudang as Lokasi, " +
                "c.nama_category as Category, " +
                "i.berat_item||'g' as Berat, " +
                "i.panjang_item||'cm' as Panjang, " +
                "i.tinggi_item||'cm' as Tinggi, " +
                "i.lebar_item||'cm' as Lebar, " +
                "i.kadar_air_item||'%' as Kadar, " +
                "'Rp '||TO_CHAR(i.harga_jual_item,'9G999G999') as hJual, " +
                "'Rp '||TO_CHAR(i.harga_beli_item,'9G999G999') as hBeli, " +
                "'Rp '||TO_CHAR(balance_cost,'999G999G999G999') as balance_cost, " +
                "satuan_item as Satuan, " +
                "jenis_ppn as PPN, " +
                "TO_CHAR(stok_item,'9G999G999') as Qty " +
                "from item i join category c on i.id_category = c.id_category " +
                "where (lower(i.nama_item) like '%" + optional[0].ToString().ToLower() + "%' " +
                "or lower(i.id_item) like '%" + optional[0].ToString().ToLower() + "%')";
            if (Convert.ToInt32(optional[1]) < ds.Tables["category"].Rows.Count - 1 && Convert.ToInt32(optional[1]) > -1)
            {
                cmd += " AND i.id_category = '" + cbCategory.SelectedValue + "'";
            }

            if (optional[2].ToString().Length >= 0 && !optional[2].ToString().Equals("Semua"))
            {
                cmd += " AND satuan_item ='"+ optional[2].ToString() +"'";
            }

            if (!optional[5].Equals("Semua") && !optional[5].Equals("Diantara"))
            {
                if (optional[3].Equals("Beli") && optional[4].Equals("Jual"))
                {
                    cmd += " AND (harga_beli_item " + optional[5] + " " + optional[6] + " OR harga_jual_item " + optional[5] + " " + optional[6] + ")";
                }
                else if (optional[3].Equals("Beli"))
                {
                    cmd += " AND harga_beli_item " + optional[5] + " " + optional[6];
                }
                else if (optional[4].Equals("Jual"))
                {
                    cmd += " AND harga_Jual_item " + optional[5] + " " + optional[6];
                }
            }
            else if(optional[5].Equals("Diantara"))
            {
                if (optional[3].Equals("Beli") && optional[4].Equals("Jual"))
                {
                    cmd += " AND ((harga_beli_item < " + optional[7] + " AND harga_beli_item > " + optional[6] + ") OR (harga_jual_item < " + optional[7] + " AND harga_jual_item > " + optional[6] + "))";
                }
                else if (optional[3].Equals("Beli"))
                {
                    cmd += " AND harga_beli_item < " + optional[7] + " AND harga_beli_item > " + optional[6];
                }
                else if (optional[4].Equals("Jual"))
                {
                    cmd += " AND harga_jual_item < " + optional[7] + " AND harga_jual_item > " + optional[6];
                }
            }

            if (!optional[8].Equals("Semua"))
            {
                cmd += " AND i.id_gudang = '" + optional[8] + "'";
            }

            if (!optional[9].Equals("Semua"))
            {
                cmd += " AND i.jenis_ppn = '" + optional[9] + "'";
            }

            MessageBox.Show(cmd);

            daItem = new OracleDataAdapter(cmd, conn);
            daItem.Fill(ds, "item");
            this.dataGridView.DataSource = ds.Tables["item"];
        }

        public void isiCB()
        {
            daCategory = new OracleDataAdapter("select id_category as ID, nama_category as Category from category", conn);
            daCategory.Fill(ds, "category");
            DataRow newRow = ds.Tables["category"].NewRow();
            newRow[0] = "-1";
            newRow[1] = "Semua";
            ds.Tables["category"].Rows.Add(newRow);
            cbCategory.DataSource = ds.Tables["category"];
            cbCategory.ValueMember = "ID";
            cbCategory.DisplayMember = "Category";
            cbCategory.SelectedIndex = ds.Tables["category"].Rows.Count - 1;
        }


        private void formListStock_Load(object sender, EventArgs e)
        {
            if (formS != null)
            {
                this.conn = formS.conn;
                this.admin = formS.admin;
            }
            else if (formP != null)
            {
                this.conn = formP.conn;
                this.admin = formP.admin;
            }

            this.Text += " : " + this.admin;

            this.dataGridView.DefaultCellStyle.Font = new Font("Calibri", 12);
            dataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
            dataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView.ColumnHeadersDefaultCellStyle.Font = new Font("Calibri", 15, FontStyle.Bold);

            try
            {
                isiCB();

                refreshTabel();
                this.dataGridView.Columns["harga_jual_item"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dataGridView.Columns["harga_beli_item"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dataGridView.Columns["balance_cost"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dataGridView.Columns["qty_item"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void txtKeyword_TextChanged(object sender, EventArgs e)
        {
            ds.Tables["item"].Rows.Clear();

            refreshTabel(txtKeyword.Text, cbCategory.SelectedIndex);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            if (formS == null)
            {
                formP.Show();
            }
            else
            {
                formS.Show();
            }
        }

        private void btnMore_Click(object sender, EventArgs e)
        {
            formFilter filter = new formFilter(this);
            filter.ShowDialog();
            if (!filter.DialogResult.ToString().Equals("Cancel"))
            {
                this.txtKeyword.Text = filter.hasil[0].ToString();
                this.cbCategory.SelectedIndex = Convert.ToInt32(filter.hasil[1]);
                
                ds.Tables["item"].Clear();
                refreshTabel(filter.hasil);
            }
        }

        private void cbCategory_DropDownClosed(object sender, EventArgs e)
        {
            ds.Tables["item"].Clear();
            refreshTabel(txtKeyword.Text, cbCategory.SelectedIndex);
        }

        private void btnNewItem_Click(object sender, EventArgs e)
        {
            new formInsertItem(this).ShowDialog();

            ds.Tables["item"].Clear();
            refreshTabel();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridView.Rows.Count <= 1 || idx == dataGridView.Rows.Count - 1)
            {
                MessageBox.Show("Barang kosong");
                return;
            }

            if (idx > -1)
            {
                OracleCommand cmd = new OracleCommand("select id_category from category where nama_category = '" + dataGridView.Rows[idx].Cells[3].Value.ToString() + "'", conn);
                String id_category = cmd.ExecuteScalar().ToString();

                String[] obj =
                    {
                    dataGridView.Rows[idx].Cells[0].Value.ToString(),// ID 0
                    dataGridView.Rows[idx].Cells[1].Value.ToString(),// Nama 1
                    id_category,// Category 2
                    dataGridView.Rows[idx].Cells[4].Value.ToString(),// Berat 3
                    dataGridView.Rows[idx].Cells[5].Value.ToString(),// Panjang 4
                    dataGridView.Rows[idx].Cells[6].Value.ToString(),// Tinggi 5
                    dataGridView.Rows[idx].Cells[7].Value.ToString(),// Lebar 6
                    dataGridView.Rows[idx].Cells[8].Value.ToString(),// Kadar Air 7
                    dataGridView.Rows[idx].Cells[13].Value.ToString(),// PPN 8
                    dataGridView.Rows[idx].Cells[12].Value.ToString(),// Satuan 9
                    dataGridView.Rows[idx].Cells[9].Value.ToString(),// Harga Jual 10
                    dataGridView.Rows[idx].Cells[10].Value.ToString(),// Harga Beli 11
                };

                data = obj;

                new formUpdateItem(this).ShowDialog();

                ds.Tables["item"].Clear();
                refreshTabel();
            }
        }

        private int idx = -1;

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            idx = e.RowIndex;

            if (idx > -1)
            {
                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;
                btnLog.Enabled = true;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView.Rows.Count <= 1 || idx == dataGridView.Rows.Count - 1)
            {
                MessageBox.Show("Barang kosong");
                return;
            }

            if (idx > -1)
            {
                try
                {

                    String cmd = "delete from item where id_item = '" + dataGridView.Rows[idx].Cells[0].Value.ToString() + "'";
                    MessageBox.Show(cmd);
                    new OracleCommand(cmd, conn).ExecuteNonQuery();
                    ds.Tables["item"].Clear();
                    refreshTabel();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
            }
            else
            {
                MessageBox.Show("Pilih lah item pada tabel terlebih dahulu");
            }
        }

        public String id_item = "";

        private void btnLog_Click(object sender, EventArgs e)
        {
            if (dataGridView.Rows.Count <= 1 || idx == dataGridView.Rows.Count - 1)
            {
                MessageBox.Show("Barang kosong");
                return;
            }

            if (idx >= 0)
            {
                this.id_item = dataGridView.Rows[idx].Cells[0].Value.ToString();

                new formDetailLog(this).ShowDialog();
            }
            else
            {
                MessageBox.Show("Tolong click salah satu baris pada tabel");
            }
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            idx = e.RowIndex;

            if (idx > -1)
            {
                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;
                btnLog.Enabled = true;
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            new formLaporanStock(this).ShowDialog();
        }
    }
}
