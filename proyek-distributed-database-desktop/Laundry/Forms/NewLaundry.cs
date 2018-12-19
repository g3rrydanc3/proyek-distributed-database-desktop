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

namespace proyek_distributed_database_desktop.Laundry
{
    public partial class NewLaundry : Form
    {
        OracleConnection conn;
        Dictionary<String, int> serviceTypes = new Dictionary<String, int>();

        public NewLaundry()
        {
            InitializeComponent();
        }

        private void NewLaundry_Load(object sender, EventArgs e)
        {
            conn = new OracleConnection(Login.connectionString);
            conn.Open();
            refresh();
            reset();

            dataGridView1.Columns[2].DefaultCellStyle.Format = "c2";
            dataGridView1.Columns[2].DefaultCellStyle.FormatProvider = CultureInfo.GetCultureInfo("id-ID");
            dataGridView1.Columns[3].DefaultCellStyle.Format = "c2";
            dataGridView1.Columns[3].DefaultCellStyle.FormatProvider = CultureInfo.GetCultureInfo("id-ID");
        }

        private void reset()
        {
            checkBoxWalkIn.Checked = false;
            dataGridView1.Rows.Clear();
            listBox1.SelectedIndex = 0;
            comboBox1.SelectedIndex = 0;
            labelTotal.Text = "Rp 0.00";
        }

        private void refresh()
        {
            OracleCommand cmd = new OracleCommand(@"
                select room.room_no, room_type.room_type 
                from room@keFrontOffice, room_type@keFrontOffice
                where room_type.room_type_id = room.type_id and 
                room.status=0", conn);

            OracleDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                listBox1.Items.Add(reader.GetInt32(0) + " - " + reader.GetString(1));
            }
            cmd.CommandText = "select * from laundry_service";
            reader = cmd.ExecuteReader();
            List<String> serviceTypesList = new List<string>();
            while (reader.Read())
            {
                serviceTypesList.Add(String.Format("{0} - {1}", reader.GetString(1), Rupiah.ToRupiah(reader.GetInt32(2))));
                serviceTypes.Add(reader.GetString(1), reader.GetInt32(0));
            }
            comboBox1.Items.AddRange(serviceTypesList.ToArray());

            if (listBox1.SelectedIndex == -1) listBox1.SelectedIndex = 0;
            if (comboBox1.SelectedIndex == -1) comboBox1.SelectedIndex = 0;
        }

        private void checkBoxWalkIn_CheckedChanged(object sender, EventArgs e)
        {
            listBox1.Enabled = !checkBoxWalkIn.Checked;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            String service_type = comboBox1.SelectedItem.ToString().Split('-')[0].Trim();
            bool ada = false;
            int total = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells[0].Value.ToString() == service_type)
                {
                    row.Cells[1].Value = Int32.Parse(row.Cells[1].Value.ToString()) + numericUpDownWeight.Value;
                    row.Cells[2].Value = numericUpDownPrice.Value;
                    row.Cells[3].Value = Int32.Parse(row.Cells[1].Value.ToString()) * Int32.Parse(row.Cells[2].Value.ToString());
                    ada = true;
                    break;
                }
            }

            if (!ada)
            {
                dataGridView1.Rows.Add(service_type, numericUpDownWeight.Value, numericUpDownPrice.Value, numericUpDownPrice.Value * numericUpDownWeight.Value);
            }

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                total += Int32.Parse(row.Cells[3].Value.ToString());
            }

            labelTotal.Text = Rupiah.ToRupiah(total);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            numericUpDownPrice.Value = Rupiah.ToAngka(comboBox1.SelectedItem.ToString().Split('-')[1].Trim());
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            reset();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            String laundry_bill_id = insertLaundry();
            MessageBox.Show(laundry_bill_id.ToString());
            insertLaundryDetail(laundry_bill_id);
            reset();
        }

        private String insertLaundry()
        {
            DateTime now = DateTime.Now;

            OracleParameter dateParam = new OracleParameter();
            dateParam.OracleDbType = OracleDbType.Date;
            dateParam.Value = now;


            OracleCommand cmd = conn.CreateCommand();

            cmd.CommandText = "insert into laundry_bill (room_no, employee_id, total, bill_date) values(:a1, :a2, :a3, :a4)";
            if (checkBoxWalkIn.Checked)
            {
                cmd.Parameters.Add("a1", "0");
            }
            else
            {
                cmd.Parameters.Add("a1", Int32.Parse(listBox1.SelectedItem.ToString().Split('-')[0].Trim()));
            }
            cmd.Parameters.Add("a2", "DUMMY");
            cmd.Parameters.Add("a3", Rupiah.ToAngka(labelTotal.Text));
            cmd.Parameters.Add(dateParam);
            cmd.ExecuteNonQuery();

            cmd.CommandText = "select max(substr(laundry_bill_id,7)) from laundry_bill";
            OracleDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return now.ToString("ddMMyy") + reader.GetString(0);
            }
            throw new Exception("Laundry Bill not inserted");
        }

        private void insertLaundryDetail(String laundry_bill_id)
        {
            OracleCommand cmd = conn.CreateCommand();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "insert into laundry_bill_detail (laundry_bill_id, laundry_service_id, weight, price) values(:a1, :a2, :a3, :a4)";
                cmd.Parameters.Add("a1", laundry_bill_id);
                cmd.Parameters.Add("a2", serviceTypes[row.Cells[0].Value.ToString()]);
                cmd.Parameters.Add("a3", row.Cells[1].Value.ToString());
                cmd.Parameters.Add("a4", row.Cells[2].Value.ToString());
                cmd.ExecuteNonQuery();
            }
        }
    }
}
