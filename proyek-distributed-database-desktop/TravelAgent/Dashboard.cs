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

namespace proyek_distributed_database_desktop.TravelAgent
{
	public partial class Dashboard : Form
	{
		OracleConnection conn;
		public Dashboard()
		{
			InitializeComponent();
            conn = new OracleConnection(Login.connectionString);
		}

		private void button1_Click(object sender, EventArgs e)
		{
			listBox1.Items.Add(comboBox1.SelectedItem + " - " +
				dateTimePicker1.Value.ToLongDateString() + " - " +
				dateTimePicker2.Value.ToLongDateString() + " - " +
				numericUpDown1.Value.ToString());
		}

		RegisterUser ru;
		private void button2_Click(object sender, EventArgs e)
		{
			ru = new RegisterUser();
			ru.MdiParent = Home.ActiveForm;
			this.Hide();
			ru.Show();
		}

		private void Dashboard_Load(object sender, EventArgs e)
		{
			conn.Open();
			OracleDataAdapter da = new OracleDataAdapter("Select * from travelagent", conn);
			conn.Close();
			conn.Open();
			OracleDataAdapter da2 = new OracleDataAdapter("Insert * from travelagent", conn);
			conn.Close();
		}

        private void load_cbRoomType()
        {
            conn.Open();
            OracleDataAdapter da = new OracleDataAdapter("Select * from travelagent", conn);
            conn.Close();
        }
	}
}
