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
    public partial class formMasterUser : Form
    {
        Form form;
        public OracleConnection conn;
        public String[] data;
        private OracleDataAdapter daUser;
        private DataSet ds = new DataSet();
        private int idx = -1;

        public formMasterUser()
        {
            InitializeComponent();
        }

        public formMasterUser(Form form)
        {
            InitializeComponent();
            this.form = form;
        }

        public void refreshTabel()
        {

            string cmd = "select id_staff, nama_staff, alamat_staff, " +
                "email_staff, tgl_lahir_staff,  tgl_masuk, " +
                "'0'||nomer_telp_staff as nomer_telp_staff, username_staff, nm_jabatan " +
                "from staff s join jabatan j on s.id_jabatan = j.id_jabatan";

            daUser = new OracleDataAdapter(cmd, conn);
            daUser.Fill(ds, "user");
            dataGridView.DataSource = ds.Tables["user"];
        }

        private void formMasterUser_Load(object sender, EventArgs e)
        {
            conn = new OracleConnection("user id=export;password=import;data source=orcl");

            conn.Open();

            this.dataGridView.DefaultCellStyle.Font = new Font("Calibri", 12);
            dataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
            dataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView.ColumnHeadersDefaultCellStyle.Font = new Font("Calibri", 15, FontStyle.Bold);

            refreshTabel();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {

        }
    }
}
