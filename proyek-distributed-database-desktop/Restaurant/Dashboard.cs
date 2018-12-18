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

namespace proyek_distributed_database_desktop.Restaurant
{
    public partial class Dashboard : Form
    {
        OracleConnection conn;
        public Dashboard()
        {
            InitializeComponent();
            conn = new OracleConnection(Login.connectionString);
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            loadMenu();
            loadCustomer();
        }

        private void loadMenu()
        {
            conn.Open();
            OracleDataAdapter adap = new OracleDataAdapter("select * from menu", conn);
            DataTable dt = new DataTable();
            adap.Fill(dt);
            dataGridView2.DataSource = dt;
            conn.Close();
        }

        public void loadCustomer()
        {
            conn.Open();
            OracleCommand command = new OracleCommand("select customer_id, first_name || ' ' || last_name as full_name from customer@keFrontOffice", conn);
            DataTable dt = new DataTable();
            OracleDataReader reader;
            reader = command.ExecuteReader();
            dt.Columns.Add("customer_id", typeof(string));
            dt.Columns.Add("customer_name", typeof(string));
            dt.Load(reader);
            
            comboBox1.ValueMember = "customer_id";
            comboBox1.DisplayMember = "full_name";
            comboBox1.DataSource = dt;
            
            conn.Close();
        }

        private void dataGridView2_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddCustomer addcustomer = new AddCustomer();
            addcustomer.Show();
            loadCustomer();
        }
    }
}
