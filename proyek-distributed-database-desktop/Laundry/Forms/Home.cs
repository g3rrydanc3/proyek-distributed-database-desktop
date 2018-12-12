using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proyek_distributed_database_desktop.Laundry
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        MasterLaundryService masterLaundryServiceForm;
        NewLaundry newLaundryForm;

        private void Home_Load(object sender, EventArgs e)
        {

        }

        private void newLaundryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (newLaundryForm == null)
            {
                newLaundryForm = new NewLaundry();
                newLaundryForm.MdiParent = this;
                newLaundryForm.Show();
            }
            else
            {
                newLaundryForm.Activate();
            }
        }

        private void editLaundryToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void masterLaundryServiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(masterLaundryServiceForm == null)
            {
                masterLaundryServiceForm = new MasterLaundryService();
                masterLaundryServiceForm.MdiParent = this;
                masterLaundryServiceForm.Show();
            }
            else
            {
                masterLaundryServiceForm.Activate();
            }
        }
    }
}
