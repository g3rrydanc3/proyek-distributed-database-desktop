using IniParser;
using IniParser.Model;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proyek_distributed_database_desktop
{
    public partial class Login : Form
    {
        OracleConnection conn;
        Forms forms;
        public Login(Forms forms)
        {
            InitializeComponent();
            this.forms = forms;
            createConnection();
        }

        private void createConnection()
        {
            try
            {
                var parser = new FileIniDataParser();
                IniData data = parser.ReadFile("Config.ini");
                string connectionString = "Data source=" + data[forms.ToString()]["datasource"] + ";User ID=" + data[forms.ToString()]["username"] + ";Password=" + data[forms.ToString()]["password"];
                //conn = new OracleConnection(connectionString);
                //conn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw ex;
            }
        }

        private void openForms(Forms forms)
        {
            if(forms == Forms.FrontOffice)
            {
                FrontOffice.Home f = new FrontOffice.Home();
                f.Closed += (s, args) => this.Close();
                this.Hide();
                f.Show();
            }
            else if(forms == Forms.Laundry)
            {
                Laundry.Home f = new Laundry.Home();
                f.Closed += (s, args) => this.Close();
                this.Hide();
                f.Show();
            }
            else if (forms == Forms.Restaurant)
            {
                Restaurant.Home f = new Restaurant.Home();
                f.Closed += (s, args) => this.Close();
                this.Hide();
                f.Show();
            }
            else if (forms == Forms.TravelAgent)
            {
                TravelAgent.Home f = new TravelAgent.Home();
                f.Closed += (s, args) => this.Close();
                this.Hide();
                f.Show();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim().ToLower().Count() != 0 && textBox2.Text.Count() != 0)
            {
                textBox1.Text = textBox1.Text.Trim();
                textBox2.Text = textBox2.Text.TrimStart().TrimEnd();
                
                openForms(this.forms);
            }
            else
            {
                MessageBox.Show("Username & password tidak boleh kosong.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
