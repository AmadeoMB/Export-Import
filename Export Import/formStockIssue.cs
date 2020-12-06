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
    public partial class formStockIssue : Form
    {
        public OracleConnection conn;
        public String admin;
        OracleDataAdapter daItem;

        DataSet ds = new DataSet();
        formMasterStock master;
        private Stack<Object[]> done = new Stack<Object[]>(100);
        private Stack<Object[]> undone = new Stack<Object[]>(100);
        private List<Int64> qtyList = new List<Int64>(999);
        private List<Int64> hargaList = new List<Int64>(999);
        private List<Int64> subtotalList = new List<Int64>(999);
        private Int64 total = 0;

        public formStockIssue()
        {
            InitializeComponent();
            this.conn = new OracleConnection("user id=export;password=import;data source=orcl");
            this.conn.Open();
            this.admin = "Melvern Tallall";
        }
        public formStockIssue(formMasterStock master)
        {
            InitializeComponent();
            this.master = master;
            this.conn = master.conn;
            this.admin = master.admin;
        }

        String getNomerSI(String id)
        {
            String cmd = "select count(*)+1 from h_stock_issue where id_stock_issue like '" + id + "%'";
            int jumlah = Convert.ToInt32(new OracleCommand(cmd, conn).ExecuteScalar());

            if (jumlah < 10)
            {
                return "0" + jumlah;
            }
            else
            {
                return "" + jumlah;
            }
        }

        void generateNomerSI()
        {
            String nomerSI = "SI";
            nomerSI += dateStockIssue.Value.ToString("/dd/MM/yyyy/");
            nomerSI += getNomerSI(nomerSI);

            txtIdStockIssue.Text = nomerSI;
        }

        void refreshTotal()
        {
            total = 0;
            for (int i = 0; i < subtotalList.Count; i++)
            {
                total += Convert.ToInt64(subtotalList[i]);
            }
            txtTotal.Text = "Rp " + total.ToString("#,##0.00");
        }

        void insertItem(Object[] data)
        {
            object id_item = data[0];
            int discount = Convert.ToInt32(data[1]);
            Int64 qty = Convert.ToInt32(data[2]);

            //Hitung Subtotal Kotor
            String cmd = "select harga_beli_item from item where id_item ='" + id_item + "'";
            Int64 hargaBeli = Convert.ToInt64(new OracleCommand(cmd, conn).ExecuteScalar());
            Int64 subtotal = hargaBeli * qty;

            if (dataGridView.Rows.Count > 1)
            {
                int i = 0;
                bool ada = false;
                for (; i < ds.Tables["item"].Rows.Count; i++)
                {
                    if (ds.Tables["item"].Rows[i][0].ToString().Equals(id_item))
                    {
                        ada = true;
                        break;
                    }
                }

                if (ada)
                {
                    qtyList[i] += qty;
                    subtotalList[i] += subtotal;

                    ds.Tables["item"].Rows[i][2] = qtyList[i].ToString("#,###");
                    ds.Tables["item"].Rows[i][5] = subtotalList[i].ToString("Rp #,##0.00");

                    return;
                }
            }

            qtyList.Add(qty);
            hargaList.Add(hargaBeli);
            subtotalList.Add(subtotal);
            

            cmd = "select id_item as id, " +
                "nama_item as nama, '" +
                qty.ToString("#,###") + "' as qty, " +
                "satuan_item as satuan, '" +
                hargaBeli.ToString("Rp #,##0.00") + "' as harga, '" +
                subtotal.ToString("Rp #,##0.00") + "' as subtotal " +
                "from item " +
                "where id_item = '" + id_item + "'";

            daItem = new OracleDataAdapter(cmd, conn);
            daItem.Fill(ds, "item");
            dataGridView.DataSource = ds.Tables["item"];
        }

        private void formStockIssue_Load(object sender, EventArgs e)
        {
            this.dataGridView.Columns["subtotal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dataGridView.Columns["harga"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            try
            {
                generateNomerSI();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            formSearchItem search = new formSearchItem(this);

            if (search.ShowDialog() != DialogResult.Cancel)
            {
                insertItem(search.data);


                Object[] temp = search.data;
                Array.Resize(ref temp, temp.Length + 1);
                temp[3] = "insert";
                done.Push(temp);

                refreshTotal();
            }
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            if (dataGridView.Rows.Count <= 1 || idx == dataGridView.Rows.Count - 1)
            {
                MessageBox.Show("Barang kosong");
                return;
            }

            if (idx > -1)
            {
                Object[] temp = {
                    ds.Tables["item"].Rows[idx][0],
                    0,
                    qtyList[idx],
                    "delete",
                };
                done.Push(temp);

                ds.Tables["item"].Rows.RemoveAt(idx);
                subtotalList.RemoveAt(idx);
                hargaList.RemoveAt(idx);
                qtyList.RemoveAt(idx);

                refreshTotal();
            }
            else
            {
                MessageBox.Show("Click salah satu baris pada tabel terlebih dahulu");
            }
        }

        int idx = -1;

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            idx = e.RowIndex;
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            if (idx > -1)
            {
                if (idx > 0)
                {
                    Object[] tempBawah = ds.Tables["item"].Rows[idx].ItemArray;
                    Object[] tempAtas = ds.Tables["item"].Rows[idx - 1].ItemArray;

                    ds.Tables["item"].Rows[idx].ItemArray = tempAtas;
                    ds.Tables["item"].Rows[idx - 1].ItemArray = tempBawah;
                }
                else
                {
                    MessageBox.Show("Data sudah berada dipaling atas");
                }
            }
            else
            {
                MessageBox.Show("Click salah satu baris pada tabel terlebih dahulu");
            }
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            if (idx > -1)
            {
                if (idx < ds.Tables["item"].Rows.Count - 1)
                {
                    Object[] tempAtas = ds.Tables["item"].Rows[idx].ItemArray;
                    Object[] tempBawah = ds.Tables["item"].Rows[idx + 1].ItemArray;

                    ds.Tables["item"].Rows[idx].ItemArray = tempBawah;
                    ds.Tables["item"].Rows[idx + 1].ItemArray = tempAtas;
                }
                else
                {
                    MessageBox.Show("Data sudah berada dipaling bawah");
                }
            }
            else
            {
                MessageBox.Show("Click salah satu baris pada tabel terlebih dahulu");
            }
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            if (done.Count > 0)
            {
                Object[] temp = done.Pop();
                undone.Push(temp);

                if (temp[3].ToString().Equals("insert"))
                {
                    for (int i = 0; i < ds.Tables["item"].Rows.Count; i++)
                    {
                        if (ds.Tables["item"].Rows[i][0].ToString().Equals(temp[0]))
                        {
                            ds.Tables["item"].Rows.RemoveAt(i);
                            subtotalList.RemoveAt(i);
                            hargaList.RemoveAt(i);
                            qtyList.RemoveAt(i);
                            break;
                        }
                    }
                }
                else
                {
                    insertItem(temp);
                }
                refreshTotal();
            }
        }

        private void btnRedo_Click(object sender, EventArgs e)
        {
            if (undone.Count > 0)
            {
                Object[] temp = undone.Pop();
                done.Push(temp);

                if (temp[3].ToString().Equals("insert"))
                {
                    insertItem(temp);
                }
                else
                {
                    for (int i = 0; i < ds.Tables["item"].Rows.Count; i++)
                    {
                        if (ds.Tables["item"].Rows[i][0].ToString().Equals(temp[0]))
                        {
                            ds.Tables["item"].Rows.RemoveAt(i);
                            subtotalList.RemoveAt(i);
                            hargaList.RemoveAt(i);
                            qtyList.RemoveAt(i);
                            break;
                        }
                    }
                }
                refreshTotal();
            }
        }

        Boolean saved = false;

        void overwrite()
        {
            String id_si = txtIdStockIssue.Text;
            DateTime tanggal = dateStockIssue.Value;
            String jenis = cbJenis.Text;
            String deskripsi = txtDeskripsi.Text;
            Int64 total = this.total;

            OracleCommand cmd = new OracleCommand("update h_stock_issue set " +
                "desk_stock_issue = :deskripsi, " +
                "jenis = :jenis, " +
                "tgl_stock_issue = :tanggal, " +
                "total_stock_issue = :total " +
                "where id_stock_issue = '" + id_si + "'", conn);
            cmd.Parameters.Add(":deskripsi", deskripsi);
            cmd.Parameters.Add(":jenis", jenis);
            cmd.Parameters.Add(":tanggal", tanggal);
            cmd.Parameters.Add(":total", total);
            cmd.ExecuteNonQuery();

            //Delete Last Dokumen
            new OracleCommand("delete from d_stock_issue where id_stock_issue = '" + id_si + "'", conn).ExecuteNonQuery();

            for (int i = 0; i < ds.Tables["item"].Rows.Count; i++)
            {
                String id_item = ds.Tables["item"].Rows[i][0].ToString();
                String nama_item = ds.Tables["item"].Rows[i][1].ToString();
                String satuan_item = ds.Tables["item"].Rows[i][3].ToString();
                Int64 qty_item = qtyList[i];
                Int64 hBeli_item = hargaList[i];
                Int64 subtotal = subtotalList[i];

                OracleCommand cmdDetail = new OracleCommand("insert into d_stock_issue values (:id, :si, :nama, :qty,  :harga,:jenis, :subtotal)", conn);
                cmdDetail.Parameters.Add(":id", id_item);
                cmdDetail.Parameters.Add(":si", id_si);
                cmdDetail.Parameters.Add(":nama", nama_item);
                cmdDetail.Parameters.Add(":qty", qty_item);
                cmdDetail.Parameters.Add(":harga", hBeli_item);
                cmdDetail.Parameters.Add(":jenis", satuan_item);
                cmdDetail.Parameters.Add(":subtotal", subtotal);
                cmdDetail.ExecuteNonQuery();
            }
            MessageBox.Show("Save Berhasil");
        }

        void save()
        {

            String id_si = txtIdStockIssue.Text;
            String id_staff = new OracleCommand("select id_staff from staff where nama_staff = '" + admin + "'", conn).ExecuteScalar().ToString();
            String jenis = cbJenis.Text;
            DateTime tanggal = dateStockIssue.Value;
            String deskripsi = txtDeskripsi.Text;
            Int64 total = this.total;

            OracleCommand cmd = new OracleCommand("insert into h_stock_issue values (:id, :ids, :jenis, :do, :gudang, :total)", conn);
            cmd.Parameters.Add(":id", id_si);
            cmd.Parameters.Add(":ids", id_staff);
            cmd.Parameters.Add(":jenis", jenis);
            cmd.Parameters.Add(":deskripsi", deskripsi);
            cmd.Parameters.Add(":tanggal", tanggal);
            cmd.Parameters.Add(":total", total);
            cmd.ExecuteNonQuery();

            for (int i = 0; i < ds.Tables["item"].Rows.Count; i++)
            {
                String id_item = ds.Tables["item"].Rows[i][0].ToString();
                String nama_item = ds.Tables["item"].Rows[i][1].ToString();
                String satuan_item = ds.Tables["item"].Rows[i][3].ToString();
                Int64 qty_item = qtyList[i];
                Int64 hBeli_item = hargaList[i];
                Int64 subtotal = subtotalList[i];

                OracleCommand cmdDetail = new OracleCommand("insert into d_stock_issue values (:id, :si, :nama, :qty, :harga,:jenis, :subtotal)", conn);
                cmdDetail.Parameters.Add(":id", id_item);
                cmdDetail.Parameters.Add(":si", id_si);
                cmdDetail.Parameters.Add(":nama", nama_item);
                cmdDetail.Parameters.Add(":qty", qty_item);
                cmdDetail.Parameters.Add(":harga", hBeli_item);
                cmdDetail.Parameters.Add(":jenis", satuan_item);
                cmdDetail.Parameters.Add(":subtotal", subtotal);
                cmdDetail.ExecuteNonQuery();
            }

            MessageBox.Show("Save Berhasil");
            saved = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cbJenis.SelectedIndex < 0)
            {
                MessageBox.Show("Mohon pilih jenis");
                return;
            }

            if (txtDeskripsi.Text.Length == 0)
            {
                MessageBox.Show("Mohon isi deskipsi");
                return;
            }
            if (dataGridView.Rows.Count <= 1)
            {
                MessageBox.Show("Mohon isi barang");
                return;
            }

            if (saved)
            {
                if (MessageBox.Show("Anda sudah meng-save apakah anda mau meng-update dokumen terakhir?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    overwrite();
                }
            }
            else
            {
                save();
            }
        }

        public String id_si;

        private void btnPreview_Click(object sender, EventArgs e)
        {
            if (cbJenis.SelectedIndex < 0)
            {
                MessageBox.Show("Mohon pilih jenis");
                return;
            }

            if (txtDeskripsi.Text.Length == 0)
            {
                MessageBox.Show("Mohon isi deskipsi");
                return;
            }
            if (dataGridView.Rows.Count <= 1)
            {
                MessageBox.Show("Mohon isi barang");
                return;
            }

            if (saved)
            {
                if (MessageBox.Show("Anda sudah meng-save apakah anda mau meng-update dokumen terakhir?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    overwrite();
                }
            }
            else
            {
                save();
            }

            this.id_si = txtIdStockIssue.Text;
            new formPreviewSI(this).ShowDialog();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            master.Show();
        }

        private void dataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2 && dataGridView.Rows.Count > 1)
            {
                object jumlah = dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                if (Convert.ToInt32(jumlah) != 0)
                {
                    ds.Tables["item"].Rows[e.RowIndex][e.ColumnIndex] = jumlah;
                    ds.Tables["item"].Rows[e.RowIndex][5] = Convert.ToInt32(jumlah) * Convert.ToInt32(ds.Tables["item"].Rows[e.RowIndex][4]);
                }
                else
                {
                    ds.Tables["item"].Rows.RemoveAt(e.RowIndex);
                }
                dataGridView.DataSource = ds.Tables["item"];
                refreshTotal();
            }
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            idx = e.RowIndex;
        }
    }
}
