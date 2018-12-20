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
		public static List<string> isi = new List<string>();
		public static List<string> roomtype = new List<string>();
		public static List<string> Cin = new List<string>();
		public static List<string> Cout = new List<string>();
		public static List<string> qty = new List<string>();
		public static List<string> price = new List<string>();
		//public string[] isi = new string[1000];
		//public object isi;
		//int ctr = 1;
		public Dashboard()
		{
			InitializeComponent();
            conn = new OracleConnection(Login.connectionString);
		}

		private void button1_Click(object sender, EventArgs e)
		{
			//ctr = 0;

			listBox1.Items.Add(comboBox1.SelectedItem + " - " +
				dateTimePicker1.Value.ToShortDateString() + " - " +
				dateTimePicker2.Value.ToShortDateString() + " - " +
				numericUpDown1.Value.ToString()+ " - " +
				textBox1.Text);
			
			roomtype.Add(comboBox1.SelectedItem.ToString());
			Cin.Add(dateTimePicker1.Value.ToShortDateString());
			Cout.Add(dateTimePicker2.Value.ToShortDateString());
			qty.Add(numericUpDown1.Value.ToString());
			price.Add(textBox1.Text);

						
		}

		RegisterUser ru;
		private void button2_Click(object sender, EventArgs e)
		{
			foreach (object items in this.listBox1.Items)
			{
				isi.Add(items.ToString());
			}
			ru = new RegisterUser();
			ru.Closed += (s, args) => this.Close();
			//MessageBox.Show(isi[0]);
			ru.Show();
		}

		private void Dashboard_Load(object sender, EventArgs e)
		{
			
		}

        private void load_cbRoomType()
        {

        }
	}
}
