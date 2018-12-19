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
        int idx;
        bool fromReservation;
        Reservation rs;
        public Guests()
        {
            InitializeComponent();
            conn = new OracleConnection(Login.newconnectionString);
        }

        public Guests(bool get, Reservation rs)
        {
            InitializeComponent();
            conn = new OracleConnection(Login.newconnectionString);
            fromReservation = get;
            if (fromReservation)
            {
                btnAddReservation.Enabled = true;
            }
            this.rs = rs;
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
            conn.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            idx = e.RowIndex;
            DataGridViewRow row = dataGridView1.Rows[idx];

            txtCustomerId.Text = row.Cells[0].Value.ToString();
            txtFirstName.Text = row.Cells[1].Value.ToString();
            txtLastName.Text = row.Cells[2].Value.ToString();
            txtAddress.Text = row.Cells[3].Value.ToString();
            txtPhone.Text = row.Cells[4].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            conn.Open();
            OracleCommand command = conn.CreateCommand();
            OracleTransaction trans;
            trans = conn.BeginTransaction(IsolationLevel.Serializable);

            string id = txtCustomerId.Text;
            string fname = txtFirstName.Text;
            string lname = txtLastName.Text;
            string address = txtAddress.Text;
            string phone = txtPhone.Text;

            if (fname != null && lname != null)
            {
                try
                {
                    command.CommandText =
                        "INSERT INTO customer (customer_id,first_name, last_name, address, phone) values (:id,:fname,:lname,:address,:phone)";
                    command.Parameters.Add(":id", id);
                    command.Parameters.Add(":fname", fname);
                    command.Parameters.Add(":lname", lname);
                    command.Parameters.Add(":address", address);
                    command.Parameters.Add(":phone", phone);
                    command.ExecuteNonQuery();
                    trans.Commit();
                    MessageBox.Show("Success Insert");
                    Console.WriteLine("Inserted.");
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    Console.WriteLine(ex.ToString());
                    Console.WriteLine("Failed Insert.");
                }
            }
            else
            {
                MessageBox.Show("Please fill first name and last name before insert");
            }
            conn.Close();
            load_guest();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            OracleCommand command = conn.CreateCommand();
            OracleTransaction trans;
            trans = conn.BeginTransaction(IsolationLevel.Serializable);

            string id = txtCustomerId.Text;
            string fname = txtFirstName.Text;
            string lname = txtLastName.Text;
            string address = txtAddress.Text;
            string phone = txtPhone.Text;

            if (fname != null && lname != null)
            {
                try
                {
                    command.CommandText =
                       "UPDATE customer set first_name = :fname, last_name = :lname, address = :address, phone = :phone where customer_id = :id";
                    command.Parameters.Add(":fname", fname);
                    command.Parameters.Add(":lname", lname);
                    command.Parameters.Add(":address", address);
                    command.Parameters.Add(":phone", phone);
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
                MessageBox.Show("Please fill first name and last name before updated");
            }
            conn.Close();
            load_guest();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void btnAddReservation_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGridView1.Rows[idx];

            rs.cbCustomerID.SelectedItem = row.Cells[0].Value.ToString();
            rs.txtFname.Text = row.Cells[1].Value.ToString();
            rs.txtLname.Text = row.Cells[2].Value.ToString();
            rs.rtxtAddress.Text = row.Cells[3].Value.ToString();
            rs.txtPhone.Text = row.Cells[4].Value.ToString();
            //Reservation r = new Reservation(fname);
            //r.Show();
            this.Dispose();
        }
    }
}
