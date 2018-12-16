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
    public partial class Guests : Form
    {
        OracleConnection conn;
        public Guests()
        {
            InitializeComponent();
            conn = new OracleConnection(Login.connectionString);
        }

        private void Guests_Load(object sender, EventArgs e)
        {
            load_guest();
        }

        private void load_guest()
        {
            conn.Open();
            OracleDataAdapter adap = new OracleDataAdapter("select * from customer", conn);
            DataTable dt = new DataTable();
            adap.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Dispose();
        }
    }
}
