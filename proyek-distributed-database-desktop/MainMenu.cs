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
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void openForm(Forms forms)
        {
            Login f = new Login(forms);
            f.Closed += (s, args) => this.Close();
            this.Hide();
            f.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openForm(Forms.FrontOffice);
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            openForm(Forms.Laundry);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            openForm(Forms.Restaurant);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            openForm(Forms.TravelAgent);
        }
    }
}
