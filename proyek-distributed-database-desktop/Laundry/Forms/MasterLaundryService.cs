using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proyek_distributed_database_desktop.Laundry
{
    public partial class MasterLaundryService : Form
    {
        OracleConnection conn;
        public MasterLaundryService()
        {
            InitializeComponent();
        }

        private void MasterLaundryService_Load(object sender, EventArgs e)
        {
            conn = new OracleConnection(Login.connectionString);
            conn.Open();
            OracleCommand cmd = new OracleCommand("select * from laundry_service", conn);
            OracleDataReader reader = cmd.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(reader);
            

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells[2] != null)
                {
                    //row.Cells[2].Value = Rupiah.ToRupiah(Int32.Parse(row.Cells[2].Value.ToString()));
                }
            }

            dataGridView1.DataSource = dataTable;
        }
    }
}
