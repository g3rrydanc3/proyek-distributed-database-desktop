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
        public Dashboard()
        {
            InitializeComponent();
            conn = new OracleConnection(Login.newconnectionString);
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            load_updates();
        }

        private void load_updates()
        {
            conn.Open();
            OracleDataAdapter adap = new OracleDataAdapter("select substr(b.bill_id,0,10) as BillID, substr(e.first_name,0,10) as Employee, substr(c.first_name,0,10) as Customer,substr(s.room_no,0,10) as RoomNo,substr(b.total,0,10) as Total, substr(p.payment_method,0,10) as Method from bill b, bill_detail bd, service s, employee e, customer c, payment p where b.employee_id = e.employee_id and b.customer_id = c.customer_id and b.bill_id = p.bill_id and bd.payment_id = p.payment_id and bd.service_id = s.service_id", conn);
            DataTable dt = new DataTable();
            adap.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            load_updates();
        }
    }
}
