using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace proyek_distributed_database_desktop.FrontOffice
{
    public partial class Rooms : Form
    {
        OracleConnection conn;
        public Rooms()
        {
            InitializeComponent();
            conn = new OracleConnection(Login.connectionString);
        }

        private void Rooms_Load(object sender, EventArgs e)
        {
            load_rooms();
        }
        private void load_rooms()
        {
            conn.Open();
            OracleDataAdapter adap = new OracleDataAdapter("select * from room", conn);
            DataTable dt = new DataTable();
            adap.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RoomType rt = new RoomType();
            rt.ShowDialog();
        }
    }
}
