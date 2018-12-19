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
        public DataGridViewRow rowMenu;
        public static String menu_id;
        public static int totalQty;
        DataGridView datagridview;
        Label lTotalItem, lTotal, lSubTotal;

        public AddMenu(DataGridView dg, Label totalItem, Label total, Label subtotal)
        {
            InitializeComponent();
            datagridview = dg;
            lTotalItem = totalItem;
            lTotal = total;
            lSubTotal = subtotal;
        }

        private void AddMenu_Load(object sender, EventArgs e)
        {
            DataGridViewRow rows = Restaurant.Dashboard.row;
            for (int i = 0; i < Restaurant.Dashboard.listMenuId.Count; i++)
            {
                if (Restaurant.Dashboard.listMenuId[i] == Convert.ToInt32(rows.Cells[0].Value.ToString()))
                {
                    qty.Value = Restaurant.Dashboard.listMenuQty[i];
                }
            }
            menu_id = rows.Cells[0].Value.ToString();
            menuName.Text = rows.Cells[1].Value.ToString();
            Price.Text = Rupiah.ToRupiah(Convert.ToInt32(rows.Cells[3].Value.ToString()));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataGridViewRow rows = Restaurant.Dashboard.row;
            totalQty = Convert.ToInt32(qty.Text);
            rowMenu = (DataGridViewRow)datagridview.Rows[0].Clone();
            bool found = false;
            int index = -1;

            for (int i = 0; i < Restaurant.Dashboard.listMenuId.Count; i++)
            {
                if (Restaurant.Dashboard.listMenuId[i] == Convert.ToInt32(rows.Cells[0].Value.ToString()))
                {
                    found = true;
                    index = i;
                }
            }
            
            if (found)
            {
                datagridview.Rows[index].Cells[2].Value = Convert.ToInt32(datagridview.Rows[index].Cells[2].Value) + totalQty;
                datagridview.Rows[index].Cells[3].Value = Convert.ToInt32(rows.Cells[3].Value.ToString()) * (Convert.ToInt32(datagridview.Rows[index].Cells[2].Value));
                Restaurant.Dashboard.listMenuQty[index] = Convert.ToInt32(datagridview.Rows[index].Cells[2].Value);
            }
            else
            {
                rowMenu.Cells[0].Value = rows.Cells[1].Value.ToString();
                rowMenu.Cells[1].Value = rows.Cells[3].Value.ToString();
                rowMenu.Cells[2].Value = totalQty;
                rowMenu.Cells[3].Value = Convert.ToInt32(rows.Cells[3].Value.ToString()) * totalQty;
                Restaurant.Dashboard.listMenuId.Add(Convert.ToInt32(rows.Cells[0].Value.ToString()));
                Restaurant.Dashboard.listMenuName.Add(rows.Cells[1].Value.ToString());
                Restaurant.Dashboard.listMenuPrice.Add(Convert.ToInt32(rows.Cells[3].Value.ToString()));
                Restaurant.Dashboard.listMenuQty.Add(totalQty);
                datagridview.Rows.Add(rowMenu);
            }

            lTotalItem.Text = (datagridview.Rows.Count-1).ToString();
            int subtotal = 0;
            for(int i = 0; i < Restaurant.Dashboard.listMenuId.Count; i++)
            {
                subtotal = subtotal + (Restaurant.Dashboard.listMenuQty[i] * Restaurant.Dashboard.listMenuPrice[i]);
            }
            lTotal.Text = subtotal.ToString();
            lSubTotal.Text = (subtotal + (subtotal * 10 / 100)).ToString();
            this.Close();
        }
    }
}
