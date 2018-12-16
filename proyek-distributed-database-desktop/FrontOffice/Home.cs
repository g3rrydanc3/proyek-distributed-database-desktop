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

namespace proyek_distributed_database_desktop.FrontOffice
{
    public partial class Home : Form
    {
        Dashboard d;
        OracleConnection conn;
        public Home()
        {
            InitializeComponent();
            conn = new OracleConnection(Login.connectionString);

            d = new Dashboard();
            d.MdiParent = this;
            d.FormClosed += new FormClosedEventHandler(d_closed);
            d.Show();
            
        }
        Guests g;
        private void guestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (g == null)
            {  
                g = new Guests();
                g.MdiParent = this;
                g.FormClosed += new FormClosedEventHandler(g_closed);
                g.Show();
            }
            else
            {
                g.Activate();
            }
        }

        public void g_closed(object sender, EventArgs e)
        {
            g = null;
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

        Rooms ro;
        private void roomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ro == null)
            {
                ro = new Rooms();
                ro.MdiParent = this;
                ro.FormClosed += new FormClosedEventHandler(ro_closed);
                ro.Show();
            }
            else
            {
                ro.Activate();
            }
        }

        public void ro_closed(object sender, EventArgs e)
        {
            ro = null;
        }

        Employees em;
        private void employeesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (em == null)
            {
                em = new Employees();
                em.MdiParent = this;
                em.FormClosed += new FormClosedEventHandler(em_closed);
                em.Show();
            }
            else
            {
                em.Activate();
            }
        }

        public void em_closed(object sender, EventArgs e)
        {
            em = null;
        }

        private void dashboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (d == null)
            {
                d = new Dashboard();
                d.MdiParent = this;
                d.FormClosed += new FormClosedEventHandler(em_closed);
                d.Show();
            }
            else
            {
                d.Activate();
            }
        }

        public void d_closed(object sender, EventArgs e)
        {
            d = null;
        }

        private void Home_Load(object sender, EventArgs e)
        {
            
        }

        
    }
}
