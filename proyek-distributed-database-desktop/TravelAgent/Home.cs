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
    public partial class Home : Form
    {
		Dashboard f;
		MainMenu m;
        public Home()
        {
            InitializeComponent();
			f = new Dashboard();
			f.MdiParent = this;
			f.Show();
        }

		private void homeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			f = new Dashboard();
			f.MdiParent = this;
			f.Show();
		}

		private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
		{

			m = new MainMenu();
			m.Closed += (s, args) => this.Close();
			this.Hide();
			m.Show();
		}
	}
}
