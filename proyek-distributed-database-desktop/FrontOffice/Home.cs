using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proyek_distributed_database_desktop.FrontOffice
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void guestToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        Reservation r;
        private void reservationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(r == null)
            {
                r = new Reservation();
                r.MdiParent = this;
                r.FormClosed += new FormClosedEventHandler(r_closed);
                r.Show();
            }
            else
            {
                r.Activate();
            }

        }

        public void r_closed(object sender, EventArgs e)
        {
            r = null;
        }
    }
}
