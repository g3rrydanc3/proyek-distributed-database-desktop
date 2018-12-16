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
    public partial class Employees : Form
    {
        OracleConnection conn;
        public Employees()
        {
            InitializeComponent();
            conn = new OracleConnection(Login.connectionString);
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Employees_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("ADMIN");
            comboBox1.Items.Add("ROLE");
            comboBox1.SelectedIndex = 0;
        }

        private void load_employee()
        {
            conn.Open();
            OracleDataAdapter adap = new OracleDataAdapter("select * from employee", conn);
            DataTable dt = new DataTable();
            adap.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Dispose();

        }
    }
}
