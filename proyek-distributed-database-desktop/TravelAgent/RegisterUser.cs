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
			//TravelAgent.Dashboard d = new TravelAgent.Dashboard();
			for (int i = 0; i < TravelAgent.Dashboard.isi.Count; i++)
			{
				listBox1.Items.Add(TravelAgent.Dashboard.isi[i]);
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			
			string nik = textBox1.Text;
			string fn = textBox2.Text;
			string ln = textBox3.Text;
			string add = richTextBox1.Text;
			string telp = textBox4.Text;

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


		}

		private void button3_Click(object sender, EventArgs e)
		{
			conn.Open();
			OracleCommand command = new OracleCommand("SELECT * FROM CUSTOMER@keFrontOffice WHERE customer_id = "+textBox1.Text + "')", conn);
			int rowsInsert = command.ExecuteNonQuery();
			OracleDataReader isi = command.ExecuteReader();
			conn.Close();
			if (rowsInsert == 0)//kalau kembar
			{
				textBox1.Text = isi.GetValue(0).ToString();
				MessageBox.Show("User Sudah Terdaftar");
			}
			else
			{
				MessageBox.Show("User Belum Terdaftar");
			}
		}
	}
}
