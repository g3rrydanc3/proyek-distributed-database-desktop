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
    public partial class AddCustomer : Form
    {
        OracleConnection conn;
        public AddCustomer()
        {
            InitializeComponent();
            conn = new OracleConnection(Login.connectionString);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            conn.Open();
            OracleCommand command = new OracleCommand("INSERT INTO CUSTOMER@keFrontOffice(FIRST_NAME, LAST_NAME, ADDRESS, PHONE) VALUES('" + textBox1.Text + "', '" + textBox2.Text + "', '" + textBox3.Text + "', '" + textBox4.Text + "')", conn);
            int rowsInsert = command.ExecuteNonQuery();
            conn.Close();
            if (rowsInsert == 0)
            {
                MessageBox.Show("Record not inserted");
            }
            else
            {
                MessageBox.Show("Success! User has been created");
                this.Close();
            }
        }
    }
}
