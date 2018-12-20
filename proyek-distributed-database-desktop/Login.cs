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
        public static string connectionString, newconnectionString;
        public static string username_login, password_login;
        public static string employee_loginid, role_login, database_login, first_name;
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
                //connectionString = "Data source=" + data[forms.ToString()]["datasource"] + ";User ID=" + username + ";Password=" + password;
                connectionString = "Data source=" + data[forms.ToString()]["datasource"] + ";User ID=" + data[forms.ToString()]["username"] + ";Password=" + data[forms.ToString()]["password"];
                conn = new OracleConnection(connectionString);
                conn.Open();
                if (conn.State == ConnectionState.Open)
                {
                    database_login = data[forms.ToString()]["datasource"];
                    OracleCommand command = conn.CreateCommand();
                    if (forms == Forms.FrontOffice)
                    {
                        command.CommandText =
                                "select employee_id, role, database,first_name from employee where username = :username and password = :password";
                    }
                    else
                    {
                        command.CommandText =
                                "select employee_id, role, database,first_name from employee@kefrontoffice where username = :username and password = :password";
                    }
                    command.Parameters.Add(":username", username_login);
                    command.Parameters.Add(":password", password_login);
                    OracleDataReader read = command.ExecuteReader();
                    if (read.Read())
                    {
                        employee_loginid = read.GetString(0);
                        role_login = read.GetString(1);
                        database_login = read.GetString(2);
                        first_name = read.GetString(3);
                    }
                    newconnectionString = "Data source=" + database_login + ";User ID=" + username_login + ";Password=" + password_login;
                }
                conn.Close();
                openForms(this.forms);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
                username_login = textBox1.Text.Trim();
                password_login = textBox2.Text.TrimStart().TrimEnd();
                createConnection(username_login, password_login);
                //conn.Open();
            }
            else
            {
                MessageBox.Show("Username & password tidak boleh kosong.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
