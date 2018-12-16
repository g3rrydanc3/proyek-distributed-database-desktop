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
        public static string connectionString;
        public Login(Forms forms)
        {
            InitializeComponent();
            this.forms = forms;
            //createConnection();
        }

        private void createConnection(String username, String password)
        {
            try
            {
                var parser = new FileIniDataParser();
                IniData data = parser.ReadFile("Config.ini");
                connectionString = "Data source=" + data[forms.ToString()]["datasource"] + ";User ID=" + username + ";Password=" + password;
                conn = new OracleConnection(connectionString);
                conn.Open();
                if (conn.State == ConnectionState.Open)
                {

                    openForms(this.forms);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //throw ex;
            }
        }

        private void openForms(Forms forms)
        {
            if (forms == Forms.FrontOffice)
            {
                FrontOffice.Home f = new FrontOffice.Home();
                f.Closed += (s, args) => this.Close();
                this.Hide();
                f.Show();
            }
            else if (forms == Forms.Laundry)
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
                createConnection(textBox1.Text, textBox2.Text);
                //conn.Open();

            }
            else
            {
                MessageBox.Show("Username & password tidak boleh kosong.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
            if (forms == Forms.FrontOffice)
            {
                textBox1.Text = "adminfrontoffice";
                textBox2.Text = "admin";
            }
            else if (forms == Forms.Laundry)
            {
                textBox1.Text = "adminlaundry";
                textBox2.Text = "admin";
            }
            else if (forms == Forms.Restaurant)
            {
                textBox1.Text = "adminrestaurant";
                textBox2.Text = "admin";
            }
            else if (forms == Forms.TravelAgent)
            {
                textBox1.Text = "admintravelagent";
                textBox2.Text = "admin";
            }
        }
    }
}
