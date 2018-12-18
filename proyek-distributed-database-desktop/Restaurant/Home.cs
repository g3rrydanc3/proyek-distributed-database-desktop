using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proyek_distributed_database_desktop.Restaurant
{
    public partial class Home : Form
    {
        MainMenu m;
        public Home()
        {
            InitializeComponent();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m = new MainMenu();
            m.Closed += (s, args) => this.Close();
            this.Dispose();
            m.Show();
        }

        private void listProductsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListProduct listProduct = new ListProduct();
            listProduct.MdiParent = this;
            listProduct.Show();
        }

        private void dashboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard();
            dashboard.MdiParent = this;
            dashboard.Show();
        }
    }
}
