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
        int paymentT = 0;
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

        private void tableNo_Leave(object sender, EventArgs e)
        {
            if (tableNo.Text == "")
            {
                tableNo.Text = "Table No";
                tableNo.ForeColor = Color.Gray;
            }
        }

        private void tableNo_Enter(object sender, EventArgs e)
        {
            if (tableNo.Text == "Table No")
            {
                tableNo.ForeColor = Color.Black;
                tableNo.Text = "";
            }
        }

        private void payment_Click(object sender, EventArgs e)
        {
            int tableNoInt = -1;
            if(!Int32.TryParse(tableNo.Text, out tableNoInt)){
                MessageBox.Show("Table No number only.");
            }
            else
            {
                String menu_bill_id = insertBill(tableNoInt);
                insertBillDetail(menu_bill_id);
                cancel_Click(null, null);
            }
        }

        private String insertBill(int tableNoInt)
        {
            String roomNoString;
            if (roomNo.SelectedItem.ToString() == "walk-in-client")
            {
                roomNoString = "0";
            }
            else
            {
                roomNoString = roomNo.SelectedItem.ToString();
            }
            conn.Open();
            DateTime now = DateTime.Now;

            OracleParameter dateParam = new OracleParameter();
            dateParam.OracleDbType = OracleDbType.Date;
            dateParam.Value = now;
            for (int i = 0; i < listMenuPrice.Count; i++)
            {
                paymentT = paymentT + (listMenuPrice[i] * listMenuQty[i]);
            }

            paymentT = paymentT + (paymentT * 10 /100);

            OracleCommand command = new OracleCommand("INSERT INTO MENU_BILL(EMPLOYEE_ID, ROOM_NO, TABLE_NO, TOTAL, BILL_DATE) VALUES(:a1, :a2, :a3, :a4, :a5)", conn);
            command.Parameters.Add("a1", Login.employee_loginid);
            command.Parameters.Add("a2", roomNoString);
            command.Parameters.Add("a3", tableNoInt);
            command.Parameters.Add("a4", paymentT);
            command.Parameters.Add(dateParam);
            int rowsInsert = command.ExecuteNonQuery();
            if (rowsInsert != 0) {
                MessageBox.Show("Success! Bill has been created");

                command.CommandText = "select max(substr(menu_bill_id,7)) from menu_bill";
                OracleDataReader reader = command.ExecuteReader();
                conn.Clone();
                if (reader.Read())
                {
                    return now.ToString("ddMMyy") + reader.GetString(0);
                }
            }
            throw new Exception("Menu Bill not inserted");
        }

        private void insertBillDetail(String menu_bill_id)
        {
            OracleCommand cmd = conn.CreateCommand();
            for (int i = 0; i < listMenuId.Count; i++)
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "insert into menu_bill_detail (menu_bill_id, menu_id, qty, total) values(:a1, :a2, :a3, :a4)";
                cmd.Parameters.Add("a1", menu_bill_id);
                cmd.Parameters.Add("a2", listMenuId[i]);
                cmd.Parameters.Add("a3", listMenuQty[i]);
                cmd.Parameters.Add("a4", listMenuPrice[i] * listMenuQty[i]);
                cmd.ExecuteNonQuery();
            }
            conn.Close();
        }
    }
}
