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
	public partial class Agent : Form
	{
		OracleConnection conn;
		public Agent()
		{
			InitializeComponent();
			conn = new OracleConnection(Login.connectionString);
		}

		private void Agent_Load(object sender, EventArgs e)
		{
			conn.Open();
			OracleDataAdapter adap = new OracleDataAdapter("select * from agent", conn);
			DataTable dt = new DataTable();
			adap.Fill(dt);
			dataGridView1.DataSource = dt;
			conn.Close();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			conn.Open();
			OracleDataAdapter adap = new OracleDataAdapter("insert into agent (name) values ('"+textBox1.Text+"')", conn);
			DataTable dt = new DataTable();
			adap.Fill(dt);
			dataGridView1.DataSource = dt;
			conn.Close();

			conn.Open();
			OracleDataAdapter adap2 = new OracleDataAdapter("select * from agent", conn);
			DataTable dt2 = new DataTable();
			adap2.Fill(dt2);
			dataGridView1.DataSource = dt2;
			conn.Close();
		}
	}
}
