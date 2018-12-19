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

        int idx;
        public RoomType()
        {
            InitializeComponent();
            conn = new OracleConnection(Login.newconnectionString);
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
            conn.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            idx = e.RowIndex;

            txtRoomTypeId.Text = dataGridView1.Rows[idx].Cells[0].Value.ToString();
            txtRoomType.Text = dataGridView1.Rows[idx].Cells[1].Value.ToString();
            txtDescription.Text = dataGridView1.Rows[idx].Cells[2].Value.ToString();
            txtCapacity.Text = dataGridView1.Rows[idx].Cells[3].Value.ToString();
            txtPrice.Text = dataGridView1.Rows[idx].Cells[4].Value.ToString();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            OracleCommand command = conn.CreateCommand();
            OracleTransaction trans;
            trans = conn.BeginTransaction(IsolationLevel.Serializable);

            //string id = txtID.Text;
            string roomtype = txtRoomType.Text;
            string description = txtDescription.Text;
            string capacity = txtCapacity.Text;
            string price = txtPrice.Text;

            if (roomtype != null && capacity != null && price != null)
            {
                try
                {
                    command.CommandText =
                        "INSERT INTO room_type (room_type, description, capacity, price) values (:roomtype,:desc,:capacity,:price)";
                    command.Parameters.Add(":roomtype", roomtype);
                    command.Parameters.Add(":desc", description);
                    command.Parameters.Add(":capacity", capacity);
                    command.Parameters.Add(":price", price);
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
                MessageBox.Show("Please fill room type, price, capacity before insert");
            }
            conn.Close();
            load_roomTypes();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            conn.Open();
            OracleCommand command = conn.CreateCommand();
            OracleTransaction trans;
            trans = conn.BeginTransaction(IsolationLevel.Serializable);

            string id = txtRoomTypeId.Text;
            string roomtype = txtRoomType.Text;
            string description = txtDescription.Text;
            string capacity = txtCapacity.Text;
            string price = txtPrice.Text;

            if (roomtype != null && capacity != null && price != null)
            {
                try
                {
                    command.CommandText =
                       "UPDATE room_type set room_type = :room_type, description = :description, capacity = :capacity, price = :price where room_type_id = :id";
                    command.Parameters.Add(":room_type", roomtype);
                    command.Parameters.Add(":description", description);
                    command.Parameters.Add(":capacity", capacity);
                    command.Parameters.Add(":price", price);
                    command.Parameters.Add(":room_type_id", id);
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
                MessageBox.Show("Please fill room type, price, capacity before updated");
            }
            conn.Close();
            load_roomTypes();
        }
    }
}
