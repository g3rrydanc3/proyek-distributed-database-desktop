using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proyek_distributed_database_desktop.Restaurant
{
    public partial class Dashboard : Form
    {
        OracleConnection conn;
        public static DataGridViewRow row;
        private class Item
        {
            public string Name;
            public string Value;
            public Item(string name, string value)
            {
                Name = name; Value = value;
            }
            public override string ToString()
            {
                // Generates the text shown in the combo box
                return Name;
            }
        }
        public Dashboard()
        {
            InitializeComponent();
            conn = new OracleConnection(Login.connectionString);
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            loadMenu();
            loadRoom();
        }

        private void loadMenu()
        {
            conn.Open();
            OracleDataAdapter adap = new OracleDataAdapter("select * from menu", conn);
            DataTable dt = new DataTable();
            adap.Fill(dt);
            menuList.DataSource = dt;
            menuList.Columns[3].DefaultCellStyle.Format = "c2";
            menuList.Columns[3].DefaultCellStyle.FormatProvider = CultureInfo.GetCultureInfo("id-ID");
            conn.Close();
        }

        public void loadRoom()
        {
            conn.Open();
            OracleDataAdapter adap = new OracleDataAdapter("select room_no, 'Room No - ' || room_no no from room@keFrontOffice where status=0 order by room_no asc", conn);
            DataTable dt = new DataTable();
            adap.Fill(dt);

            roomNo.Items.Add(new Item("walk-in-client", "walk-in-client"));
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                roomNo.Items.Add(new Item(dt.Rows[i].ItemArray[0].ToString(), dt.Rows[i].ItemArray[1].ToString()));
            }
            roomNo.SelectedIndex = 0;
            conn.Close();
        }

        private void note_Leave(object sender, EventArgs e)
        {
            note.ForeColor = Color.Gray;
            note.Text = "Reference Note";
            note.Select(note.TextLength, 0);
        }

        private void note_Click(object sender, EventArgs e)
        {
            note.Clear();
            note.ForeColor = Color.Black;
        }

        private void menuName_Leave(object sender, EventArgs e)
        {
            menuName.ForeColor = Color.Gray;
            menuName.Text = "Search menu by name";
            menuName.Select(note.TextLength, 0);
        }

        private void menuName_Click(object sender, EventArgs e)
        {
            menuName.Clear();
            menuName.ForeColor = Color.Black;
        }

        private void menuList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            row = this.menuList.Rows[e.RowIndex];
            AddMenu form = new AddMenu();
            form.Show();
        }
    }
}
