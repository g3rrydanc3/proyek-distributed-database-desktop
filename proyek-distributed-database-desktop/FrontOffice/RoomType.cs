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
    public partial class RoomType : Form
    {
        OracleConnection conn;
        public RoomType()
        {
            InitializeComponent();
            conn = new OracleConnection(Login.connectionString);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void RoomType_Load(object sender, EventArgs e)
        {
            load_roomTypes();
        }

        private void load_roomTypes()
        {
            conn.Open();
            OracleDataAdapter adap = new OracleDataAdapter("select * from room_type", conn);
            DataTable dt = new DataTable();
            adap.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Dispose();
        }
    }
}
