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
        
        int idx;
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
            cbRole.Items.Add("ADMIN");
            cbRole.Items.Add("KASIR");
            cbRole.SelectedIndex = 0;

            cbDatabase.Items.Add("FRONTOFFICE");
            cbDatabase.Items.Add("LAUNDRY");
            cbDatabase.Items.Add("RESTAURANT");
            cbDatabase.Items.Add("TRAVELAGENT");
            cbDatabase.SelectedIndex = 0;

            load_employee();
        }

        private void load_employee()
        {
            conn.Open();
            OracleDataAdapter adap = new OracleDataAdapter("select * from employee where status = 1", conn);
            DataTable dt = new DataTable();
            adap.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            conn.Open();
            OracleCommand command = conn.CreateCommand();
            OracleTransaction trans;
            trans = conn.BeginTransaction(IsolationLevel.Serializable);

            //string id = txtID.Text;
            string fname = txtFirst.Text;
            string lname = txtLast.Text;
            //string uname = txtUser.Text;
            string upass = txtPass.Text;
            string urole = cbRole.SelectedItem.ToString();
            string database = cbDatabase.SelectedItem.ToString();

            if (fname != null && lname != null){ 
                try
                {
                    command.CommandText =
                        "INSERT INTO employee (first_name, last_name, password, role, database, status) values (:fname,:lname,:pass,:urole,:database,:status)";
                    command.Parameters.Add("fname", fname);
                    command.Parameters.Add("lname", lname);
                    command.Parameters.Add("pass", upass);
                    command.Parameters.Add("urole", urole);
                    command.Parameters.Add("database", database);
                    command.Parameters.Add("status", 1);
                    command.ExecuteNonQuery();
                    trans.Commit();
                    MessageBox.Show("Please tell user to change password after log in");
                    Console.WriteLine("Inserted.");
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    Console.WriteLine(ex.ToString());
                    Console.WriteLine("Failed Inserted.");
                }
            }
            else{
                MessageBox.Show("Please fill first name and last name before insert");
            }
            conn.Close();
            load_employee();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            OracleCommand command = conn.CreateCommand();
            OracleTransaction trans;
            trans = conn.BeginTransaction(IsolationLevel.Serializable);

            string id = txtID.Text;
            string fname = txtFirst.Text;
            string lname = txtLast.Text;
            string uname = txtUser.Text;
            string upass = txtPass.Text;
            string urole = cbRole.SelectedItem.ToString();

            if (fname != null && lname != null)
            {
                try
                {
                    command.CommandText =
                       "UPDATE employee set first_name = :fname, last_name = :lname, password = :password where employee_id = :id";
                    command.Parameters.Add(":fname", fname);
                    command.Parameters.Add(":lname", lname);
                    command.Parameters.Add(":password", upass);
                    command.Parameters.Add(":id", id);
                    command.ExecuteNonQuery();
                    trans.Commit();
                    MessageBox.Show("Success Updated");
                    Console.WriteLine("Updated.");
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    Console.WriteLine(ex.ToString());
                    Console.WriteLine("Failed Updated.");
                }
            }
            else
            {
                MessageBox.Show("Please fill first name and last name before insert");
            }
            conn.Close();
            load_employee();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            conn.Open();
            string id = txtID.Text;
            OracleCommand command = conn.CreateCommand();
            OracleTransaction trans;
            trans = conn.BeginTransaction(IsolationLevel.Serializable);
            try
            {
                command.CommandText =
                    "UPDATE employee SET status = 0 WHERE employee_id = :employee_id ";
                command.Parameters.Add("employee_id", id);
                command.ExecuteNonQuery();
                trans.Commit();
                MessageBox.Show("Success Deleted");
                Console.WriteLine("Deleted.");
            }
            catch (Exception ex)
            {
                trans.Rollback();
                Console.WriteLine(ex.ToString());
                Console.WriteLine("Failed Deleted.");
            }
            conn.Close();
            load_employee();
        }
        
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            idx = e.RowIndex;
            DataGridViewRow row = dataGridView1.Rows[idx];

            txtID.Text = row.Cells[0].Value.ToString();
            txtFirst.Text = row.Cells[1].Value.ToString();
            txtLast.Text = row.Cells[2].Value.ToString();
            txtUser.Text = row.Cells[3].Value.ToString();
            txtPass.Text = row.Cells[4].Value.ToString();
            cbRole.SelectedItem = row.Cells[5].Value.ToString();
            cbDatabase.SelectedItem = row.Cells[6].Value.ToString();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
