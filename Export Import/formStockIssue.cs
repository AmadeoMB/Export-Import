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
        OracleDataAdapter daItem;
        DataSet ds = new DataSet();
        formMasterStock master;
        private Stack<Object[]> done = new Stack<Object[]>(100);
        private Stack<Object[]> undone = new Stack<Object[]>(100);

        public formStockIssue()
        {
            InitializeComponent();
        }

        public formStockIssue(formMasterStock master)
        {
            InitializeComponent();
            this.master = master;
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
            nomerSI += dateStockIssue.Value.ToString("ddMMyyyy");
            nomerSI += getNomerSI(nomerSI);

            txtIdStockIssue.Text = nomerSI;
        }

        void refreshTotal()
        {
            int total = 0;
            for (int i = 0; i < ds.Tables["item"].Rows.Count; i++)
            {
                total += Convert.ToInt32(ds.Tables["item"].Rows[i][5]);
            }
            txtTotal.Text = "Rp " + total;
        }

        void insertItem(Object[] data)
        {
            int discount = Convert.ToInt32(data[1]);
            int qty = Convert.ToInt32(data[2]);
            object id_item = data[0];

            //Hitung Subtotal Kotor
            String cmd = "select harga_beli_item from item where id_item ='" + id_item + "'";
            int hargaBeli = Convert.ToInt32(new OracleCommand(cmd, conn).ExecuteScalar());
            int subtotal = hargaBeli * qty;

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
                    ds.Tables["item"].Rows[i][2] = Convert.ToInt32(ds.Tables["item"].Rows[i][2]) + qty;
                    ds.Tables["item"].Rows[i][5] = Convert.ToInt32(ds.Tables["item"].Rows[i][5]) + subtotal;

                    return;
                }
            }

            cmd = "select id_item as id, " +
                "nama_item as nama, " +
                qty + " as qty, " +
                "satuan_item as satuan, " +
                hargaBeli + " as harga, " +
                subtotal + " as subtotal " +
                "from item " +
                "where id_item = '" + id_item + "'";

            daItem = new OracleDataAdapter(cmd, conn);
            daItem.Fill(ds, "item");
            dataGridView.DataSource = ds.Tables["item"];
        }

        private void formStockIssue_Load(object sender, EventArgs e)
        {
            conn = new OracleConnection("user id=export;password=import;data source=orcl");

            try
            {
                conn.Open();
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
            if (idx > -1)
            {
                ds.Tables["item"].Rows.RemoveAt(idx);
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
            if (txtDeskripsi.Text.Length == 0)
            {
                MessageBox.Show("Mohon isi deskipsi");
                return;
            }

            String id_si = txtIdStockIssue.Text;
            DateTime tanggal = dateStockIssue.Value;
            String deskripsi = txtDeskripsi.Text;
            int total = Convert.ToInt32(txtTotal.Text.Substring(3));

            OracleCommand cmd = new OracleCommand("update h_stock_issue set " +
                "desk_stock_issue = :deskripsi, " +
                "tgl_stock_issue = :tanggal, " +
                "total_stock_issue = :total " +
                "where id_stock_issue = '" + id_si + "'", conn);
            cmd.Parameters.Add(":deskripsi", deskripsi);
            cmd.Parameters.Add(":tanggal", tanggal);
            cmd.Parameters.Add(":total", total);
            cmd.ExecuteNonQuery();

            //Delete Last Dokumen
            new OracleCommand("delete from d_stock_issue where id_stock_issue = '" + id_si + "'", conn).ExecuteNonQuery();

            for (int i = 0; i < ds.Tables["item"].Rows.Count; i++)
            {
                String id_item = ds.Tables["item"].Rows[i][0].ToString();
                String nama_item = ds.Tables["item"].Rows[i][1].ToString();
                int qty_item = Convert.ToInt32(ds.Tables["item"].Rows[i][2].ToString());
                String satuan_item = ds.Tables["item"].Rows[i][3].ToString();
                String hBeli_item = ds.Tables["item"].Rows[i][4].ToString();
                int subtotal = Convert.ToInt32(ds.Tables["item"].Rows[i][5].ToString());

                OracleCommand cmdDetail = new OracleCommand("insert into d_stock_issue values (:id, :si, :nama, :qty, :jenis, :harga, :subtotal)", conn);
                cmdDetail.Parameters.Add(":id", id_item);
                cmdDetail.Parameters.Add(":si", id_si);
                cmdDetail.Parameters.Add(":nama", nama_item);
                cmdDetail.Parameters.Add(":qty", qty_item);
                cmdDetail.Parameters.Add(":jenis", satuan_item);
                cmdDetail.Parameters.Add(":harga", hBeli_item);
                cmdDetail.Parameters.Add(":subtotal", subtotal);
                cmdDetail.ExecuteNonQuery();
            }
        }

        void save()
        {
            if (txtDeskripsi.Text.Length == 0)
            {
                MessageBox.Show("Mohon isi deskipsi");
                return;
            }

            String id_si = txtIdStockIssue.Text;
            DateTime tanggal = dateStockIssue.Value;
            String deskripsi = txtDeskripsi.Text;
            int total = Convert.ToInt32(txtTotal.Text.Substring(3));

            OracleCommand cmd = new OracleCommand("insert into h_stock_issue values (:id, :do, :gudang, :total)", conn);
            cmd.Parameters.Add(":id", id_si);
            cmd.Parameters.Add(":deskripsi", deskripsi);
            cmd.Parameters.Add(":tanggal", tanggal);
            cmd.Parameters.Add(":total", total);
            cmd.ExecuteNonQuery();

            for (int i = 0; i < ds.Tables["item"].Rows.Count; i++)
            {
                String id_item = ds.Tables["item"].Rows[i][0].ToString();
                String nama_item = ds.Tables["item"].Rows[i][1].ToString();
                int qty_item = Convert.ToInt32(ds.Tables["item"].Rows[i][2].ToString());
                String satuan_item = ds.Tables["item"].Rows[i][3].ToString();
                String hBeli_item = ds.Tables["item"].Rows[i][4].ToString();
                int subtotal = Convert.ToInt32(ds.Tables["item"].Rows[i][5].ToString());

                OracleCommand cmdDetail = new OracleCommand("insert into d_stock_issue values (:id, :si, :nama, :qty, :jenis, :harga, :subtotal)", conn);
                cmdDetail.Parameters.Add(":id", id_item);
                cmdDetail.Parameters.Add(":si", id_si);
                cmdDetail.Parameters.Add(":nama", nama_item);
                cmdDetail.Parameters.Add(":qty", qty_item);
                cmdDetail.Parameters.Add(":jenis", satuan_item);
                cmdDetail.Parameters.Add(":harga", hBeli_item);
                cmdDetail.Parameters.Add(":subtotal", subtotal);
                cmdDetail.ExecuteNonQuery();
            }

            saved = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
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
    }
}
