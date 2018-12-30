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
    public partial class Dashboard : Form
    {
        OracleConnection conn;
        int columnIndex;
        public Dashboard()
        {
            InitializeComponent();
            conn = new OracleConnection(Login.connectionString);
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            load_updates();
        }

        private void load_updates()
        {
            conn.Open();
            OracleDataAdapter adap = new OracleDataAdapter("select substr(b.bill_id,0,10) as BillID, substr(e.first_name,0,10) as Employee, substr(c.first_name,0,10) as Customer,substr(s.room_no,0,10) as RoomNo,substr(b.total,0,10) as Total, substr(p.payment_method,0,10) as Method from bill b, bill_detail bd, service s, employee e, customer c, payment p where b.employee_id = e.employee_id and b.customer_id = c.customer_id and b.bill_id = p.bill_id and bd.payment_id = p.payment_id and bd.service_id = s.service_id and b.status = 1", conn);
            DataTable dt = new DataTable();
            adap.Fill(dt);
            dataGridView1.DataSource = dt;
            columnIndex = dataGridView1.Columns.Count;
            addButtonCheckout();
            conn.Close();
        
        }

        private void addButtonCheckout()
        {
            DataGridViewButtonColumn statusButton = new DataGridViewButtonColumn();
            statusButton.Name = "Status";
            statusButton.HeaderText = "Status";
            statusButton.Text = "Checkout";
            statusButton.UseColumnTextForButtonValue = true;
            if (dataGridView1.Columns["Status"] == null)
            {
                dataGridView1.Columns.Insert(columnIndex, statusButton);
            }
            dataGridView1.CellClick += datagridview_CellClickStatus;
        }

        private void datagridview_CellClickStatus(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["Status"].Index)
            {
                string billid = dataGridView1.Rows[e.RowIndex].Cells["BillID"].Value.ToString();
                conn.Open();
                OracleCommand command = conn.CreateCommand();
                OracleTransaction trans;
                trans = conn.BeginTransaction(IsolationLevel.Serializable);
                try
                {
                    command.CommandText =
                       "UPDATE bill set status = 0 where bill_id = :id";
                    command.Parameters.Add(":id", billid);
                    command.ExecuteNonQuery();
                    trans.Commit();
                    MessageBox.Show("Success Checkout");
                    Console.WriteLine("Updated.");
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    Console.WriteLine(ex.ToString());
                    Console.WriteLine("Failed Updated.");
                }
                conn.Close();
                load_updates();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            load_updates();
        }
    }
}
