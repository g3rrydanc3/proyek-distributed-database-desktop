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
    public partial class Reservation : Form
    {
        OracleConnection conn;
        public Reservation()
        {
            InitializeComponent();
            conn = new OracleConnection(Login.connectionString);
        }

        public Reservation(string name)
        {
            InitializeComponent();
            conn = new OracleConnection(Login.connectionString);
            txtFname.Text = name;
        }

        private void Reservation_Load(object sender, EventArgs e)
        {
            load_customer();
            load_method();
            load_room_type();            
        }

        private void load_method()
        {
            cbMethod.Items.Add("Cash");
            cbMethod.Items.Add("Debit");
            cbMethod.Items.Add("Credit");
            cbMethod.SelectedIndex = 0;
        }

        private void load_room_type()
        {
            OracleCommand cmd = new OracleCommand("select room_type from room_type", conn);
            OracleDataReader myReader;
            try
            {
                conn.Open();
                myReader = cmd.ExecuteReader();  //exception due to this line

                while (myReader.Read())
                {
                    cbRoomType.Items.Add(myReader.GetString(myReader.GetOrdinal("room_type")));
                }
                cbRoomType.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            conn.Close();
        }

        private void load_customer()
        {
            OracleCommand cmd = new OracleCommand("select customer_id from customer", conn);
            OracleDataReader myReader;
            try
            {
                conn.Open();
                myReader = cmd.ExecuteReader();  //exception due to this line
                while (myReader.Read())
                {
                    cbCustomerID.Items.Add(myReader.GetString(0));
                }
                cbCustomerID.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            conn.Close();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbRoomType_SelectionChangeCommitted(object sender, EventArgs e)
        {
            btnRoomType.Enabled = true;
        }

        private void btnGuests_Click(object sender, EventArgs e)
        {
            Guests g = new Guests(true, this);
            g.ShowDialog();

        }

        private void btnRoomType_Click(object sender, EventArgs e)
        {
            Rooms r = new Rooms(true, this);
            r.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure to process this reservation?","Confirmation",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if(result == DialogResult.Yes)
            {
                if(txtFname.Text != "" || txtLname.Text != "" || rtxtAddress.Text != "" || txtPhone.Text != "" || txtRoomNo.Text != "" || dtCheckOut.Value.Date > DateTime.Today || txtCardNo.Text != "")
                {
                    OracleParameter dateCheckIn = new OracleParameter();
                    dateCheckIn.OracleDbType = OracleDbType.Date;
                    dateCheckIn.Value = dtCheckIn.Value;

                    OracleParameter dateCheckOut = new OracleParameter();
                    dateCheckOut.OracleDbType = OracleDbType.Date;
                    dateCheckOut.Value = dtCheckOut.Value;

                    OracleParameter dateCheckPayment = new OracleParameter();
                    dateCheckPayment.OracleDbType = OracleDbType.Date;
                    dateCheckPayment.Value = dtPayment.Value;

                    string custid = cbCustomerID.SelectedItem.ToString();
                    string fname = txtFname.Text;
                    string lname = txtLname.Text;
                    string address = rtxtAddress.Text;
                    string phone = txtPhone.Text;
                    string roomtype = cbRoomType.SelectedItem.ToString();
                    string roomno = txtRoomNo.Text;

                }
                else
                {
                    MessageBox.Show("Some field are empty");
                }
            }
        }
    }
}
