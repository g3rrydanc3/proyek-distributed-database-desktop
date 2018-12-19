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
    public partial class AddMenu : Form
    {
        public AddMenu()
        {
            InitializeComponent();
        }

        private void AddMenu_Load(object sender, EventArgs e)
        {
            DataGridViewRow rows = Restaurant.Dashboard.row;
            menuName.Text = rows.Cells[1].Value.ToString();
            Price.Text = Rupiah.ToRupiah(Convert.ToInt32(rows.Cells[3].Value.ToString()));
        }
    }
}
