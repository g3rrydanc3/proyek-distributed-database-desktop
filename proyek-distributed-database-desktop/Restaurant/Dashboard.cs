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
        public static List<int> listMenuId = new List<int>();
        public static List<String> listMenuName = new List<String>();
        public static List<int> listMenuQty = new List<int>();
        public static List<int> listMenuPrice = new List<int>();
        int index = -1;

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

            listMenuId.Clear();
            listMenuName.Clear();
            listMenuId.Clear();
            listMenuId.Clear();

            bill.Columns[1].DefaultCellStyle.Format = "c2";
            bill.Columns[1].DefaultCellStyle.FormatProvider = CultureInfo.GetCultureInfo("id-ID");
            bill.Columns[3].DefaultCellStyle.Format = "c2";
            bill.Columns[3].DefaultCellStyle.FormatProvider = CultureInfo.GetCultureInfo("id-ID");
        }

        private void loadMenu()
        {
            menuList.Rows.Clear();
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
            OracleDataAdapter adap = new OracleDataAdapter("select room_no from room@keFrontOffice where status=0 order by room_no asc", conn);
            DataTable dt = new DataTable();
            adap.Fill(dt);

            roomNo.Items.Add(new Item("walk-in-client", "walk-in-client"));
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                roomNo.Items.Add(new Item(dt.Rows[i].ItemArray[0].ToString(), dt.Rows[i].ItemArray[0].ToString()));
            }
            roomNo.SelectedIndex = 0;
            conn.Close();
        }

        private void menuName_Leave(object sender, EventArgs e)
        {
            menuName.ForeColor = Color.Gray;
            menuName.Text = "Search menu by name";
            menuName.Select(tableNo.TextLength, 0);
        }

        private void menuName_Click(object sender, EventArgs e)
        {
            menuName.Clear();
            menuName.ForeColor = Color.Black;
        }

        private void menuList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            row = this.menuList.Rows[e.RowIndex];
            AddMenu form = new AddMenu(bill, totalItem, total, totalPayment);
            form.ShowDialog();
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            bill.Rows.Clear();
            listMenuId.Clear();
            listMenuName.Clear();
            listMenuPrice.Clear();
            listMenuQty.Clear();
            total.Text = Rupiah.ToRupiah(0);
            totalPayment.Text = Rupiah.ToRupiah(0);
            totalItem.Text = 0.ToString();
        }

        private void bill_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            index = e.RowIndex;
        }

        private void delete_Click(object sender, EventArgs e)
        {
            bill.Rows.RemoveAt(index);
            listMenuId.RemoveAt(index);
            listMenuName.RemoveAt(index);
            listMenuPrice.RemoveAt(index);
            listMenuQty.RemoveAt(index);
            totalItem.Text = (bill.Rows.Count - 1).ToString();
            int subtotal = 0;
            for (int i = 0; i < listMenuId.Count; i++)
            {
                subtotal = subtotal + (listMenuQty[i] * listMenuPrice[i]);
            }
            total.Text = Rupiah.ToRupiah(subtotal);
            totalPayment.Text = Rupiah.ToRupiah((subtotal + (subtotal * 10 / 100)));
        }

        private void payment_Click(object sender, EventArgs e)
        {
            //String id;
            //if (roomNo.SelectedItem.ToString() == "walk-in-client")
            //{
            //    id = "0";
            //}else
            //{
            //    id = roomNo.SelectedItem.ToString();
            //}
            //conn.Open();
            //String now = DateTime.Now.ToString("DDMMYYYY");
            ////MessageBox.Show(now);
            //OracleCommand command = new OracleCommand("INSERT INTO MENU_BILL(EMPLOYEE_ID, ROOM_NO, TABLE_NO, TOTAL, BILL_DATE) VALUES('EM001', " + id+ ", " + tableNo.Text + ", 0, to_date(to_char('" + now + "', 'DD-MM-YYYY')))", conn);
            //int rowsInsert = command.ExecuteNonQuery();
            //conn.Close();
            //if (rowsInsert == 0)
            //{
            //    MessageBox.Show("Record not inserted");
            //}
            //else
            //{
            //    MessageBox.Show("Success! Bill has been created");
            //    this.Close();
            //}
        }

        private void tableNo_Leave(object sender, EventArgs e)
        {
            tableNo.ForeColor = Color.Gray;
            tableNo.Text = "Table No Note";
            tableNo.Select(tableNo.TextLength, 0);
        }

        private void tableNo_Click(object sender, EventArgs e)
        {
            tableNo.Clear();
            tableNo.ForeColor = Color.Black;
        }
    }
}
