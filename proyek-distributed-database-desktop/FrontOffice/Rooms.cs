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
    public partial class Rooms : Form
    {
        OracleConnection conn;
        int idx;
        bool fromReservation;
        Reservation rs;
        bool ready = false;
        public Rooms()
        {
            InitializeComponent();
            conn = new OracleConnection(Login.connectionString);
        }

        public Rooms(bool get, Reservation rs)
        {
            InitializeComponent();
            conn = new OracleConnection(Login.connectionString);
            fromReservation = get;
            if (fromReservation)
            {
                btnAddReservation.Enabled = true;
            }
            this.rs = rs;
            this.ready = true;
        }

        private void Rooms_Load(object sender, EventArgs e)
        {
            load_rooms();
            load_room_type();
            load_status();
        }
        private void load_rooms()
        {
            conn.Open();
            OracleDataAdapter adap;
            if (ready==false)
            {
                //MessageBox.Show("Occupied");
                adap = new OracleDataAdapter("select r.room_no, rs.room_type, (CASE r.status WHEN 1 THEN 'Ready' ELSE 'Occupied' END) as Status from room r, room_type rs where r.type_id = rs.room_type_id", conn);
            }
            else
            {
                //MessageBox.Show("Ready");
                adap = new OracleDataAdapter("select r.room_no, rs.room_type, (CASE r.status WHEN 1 THEN 'Ready' ELSE 'Occupied' END) as Status from room r, room_type rs where r.type_id = rs.room_type_id and Status = 1", conn);
            }
            DataTable dt = new DataTable();
            adap.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RoomType rt = new RoomType();
            rt.ShowDialog();
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

        private void load_status()
        {
            cbStatus.Items.Add("Ready");
            cbStatus.Items.Add("Occupied");
            cbStatus.SelectedIndex = 0;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            idx = e.RowIndex;
            txtRoomId.Text = dataGridView1.Rows[idx].Cells[0].Value.ToString();
            cbRoomType.SelectedItem = dataGridView1.Rows[idx].Cells[1].Value.ToString();
            cbStatus.SelectedItem = dataGridView1.Rows[idx].Cells[2].Value.ToString();
        }

        private void btnAddReservation_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGridView1.Rows[idx];

            rs.cbRoomType.SelectedItem = row.Cells[1].Value.ToString();
            rs.txtRoomNo.Text = row.Cells[0].Value.ToString();
        }
    }
}
