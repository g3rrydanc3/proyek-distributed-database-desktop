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
	public partial class RegisterUser : Form
	{
		OracleConnection conn;
		public RegisterUser()
		{
			InitializeComponent();
			conn = new OracleConnection(Login.connectionString);
		}

		private void button1_Click(object sender, EventArgs e)
		{
			richTextBox2.Text =
				"NIK : " + textBox1.Text + "\n\n" + "Nama Depan : " + textBox2.Text + "\n\n" + "Nama Belakang : " + textBox3.Text + "\n\n" + "Address : " + richTextBox1.Text + "\n\n" + "Telepon : " + textBox4.Text;
		}

		private void RegisterUser_Load(object sender, EventArgs e)
		{
			for (int i = 0; i < TravelAgent.Dashboard.isi.Count; i++)
			{
				listBox1.Items.Add(TravelAgent.Dashboard.isi[i]);
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{

			conn.Open();
			OracleCommand command = new OracleCommand("INSERT INTO CUSTOMER@keFrontOffice(CUSTOMER_ID, FIRST_NAME, LAST_NAME, ADDRESS, PHONE) VALUES('" + textBox1.Text + "', '" + textBox2.Text + "', '" + textBox3.Text + "', '" + richTextBox1.Text + "', '" + textBox4.Text + "')", conn);
			
			int rowsInsert = command.ExecuteNonQuery();
			conn.Close();	

			if (rowsInsert == 0)
			{
				MessageBox.Show("Record not inserted");
			}
			else
			{
				MessageBox.Show("Success! User has been created");
				this.Close();
			}

			void_reserv();
			void_rdetail();

		}

		private void void_rdetail()
		{

			int rowsInsert = 0;
			for (int i = 0; i<TravelAgent.Dashboard.roomtype.Count; i++)
			{
				conn.Open();
				OracleCommand command = new OracleCommand("INSERT INTO RESERVATION_DETAIL(RESERVATION_ID, ROOM_TYPE, QTY, PRICE) VALUES((select* from(select RESERVATION_ID from RESERVATIONorder by RESERTAVION_ID desc) where ROWNUM = 1),'" + TravelAgent.Dashboard.roomtype + "','" + TravelAgent.Dashboard.qty + "','" + TravelAgent.Dashboard.price + "')", conn);
				rowsInsert = command.ExecuteNonQuery();

				conn.Close();
			}

			

			if (rowsInsert == 0)
			{
				MessageBox.Show("Record not inserted");
			}
			else
			{
				MessageBox.Show("Success! User has been created");
				this.Close();
			}
		}

		private void void_reserv()
		{
			conn.Open();
			int rowsInsert =0;
			
			for (int i = 0; i < TravelAgent.Dashboard.roomtype.Count; i++)
			{
				OracleCommand command = new OracleCommand("INSERT INTO RESERVATION(CUSTOMER_ID, AGENT_ID, CHECK_IN, CHECK_OUT) VALUES('" + textBox1.Text + "','TirtaJaya','todate('" + TravelAgent.Dashboard.Cin[i] + "', 'yyyy/mm/dd')','todate('" + TravelAgent.Dashboard.Cout[i] + "', 'yyyy/mm/dd')')", conn);
				rowsInsert = command.ExecuteNonQuery();
			}

			
			conn.Close();

			if (rowsInsert == 0)
			{
				MessageBox.Show("Record not inserted");
			}
			else
			{
				MessageBox.Show("Success! User has been created");
				this.Close();
			}
		}

		private void button3_Click(object sender, EventArgs e)
		{
			
		}
	}
}
