using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proyek_distributed_database_desktop.TravelAgent
{
	public partial class RegisterUser : Form
	{
		public RegisterUser()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			richTextBox2.Text =
				"NIK : " + textBox1.Text + "\n\n" + "Nama Depan : " + textBox2.Text + "\n\n" + "Nama Belakang : " + textBox3.Text + "\n\n" + "Address : " + richTextBox1.Text + "\n\n" + "Telepon : " + textBox4.Text;
		}
	}
}
