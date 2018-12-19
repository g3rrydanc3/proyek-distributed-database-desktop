using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proyek_distributed_database_desktop.Laundry
{
    public partial class MasterLaundryService : Form
    {
        OracleConnection conn;
        OracleTransaction trans;
        int id_clicked = -1;

        public MasterLaundryService()
        {
            InitializeComponent();
        }

        private void MasterLaundryService_Load(object sender, EventArgs e)
        {
            conn = new OracleConnection(Login.connectionString);
            conn.Open();
            reset();
            refresh();
        }

        private void refresh()
        {
            OracleCommand cmd = new OracleCommand("select * from laundry_service order by laundry_service_id", conn);
            OracleDataReader reader = cmd.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(reader);

            dataGridView1.DataSource = dataTable;
            if (dataGridView1.Columns.Count >= 2)
            {
                dataGridView1.Columns[2].DefaultCellStyle.Format = "c2";
                dataGridView1.Columns[2].DefaultCellStyle.FormatProvider = CultureInfo.GetCultureInfo("id-ID");
            }
        }

        private void resetForm()
        {
            id_clicked = -1;
            buttonAddEdit.Text = "Add";
            buttonCancel.Enabled = false;
            textBoxServiceType.Text = "";
            numericUpDownPrice.Value = 0;
            groupBox1.Text = "Add";
        }

        private void reset()
        {
            resetForm();
            buttonRevert.Enabled = false;
            buttonSave.Enabled = false;

            trans = conn.BeginTransaction(IsolationLevel.ReadCommitted);
        }
        
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex != -1)
            {
                id_clicked = Int32.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                buttonCancel.Enabled = true;
                buttonAddEdit.Text = "Edit";
                groupBox1.Text = "Edit";

                OracleCommand cmd = new OracleCommand("select service_type, price from laundry_service where laundry_service_id = :laundry_service_id", conn);
                cmd.Parameters.Add("laundry_service_id", id_clicked);
                OracleDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    textBoxServiceType.Text = reader.GetString(0);
                    numericUpDownPrice.Value = reader.GetInt32(1);
                }
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            resetForm();
        }

        private void buttonAddEdit_Click(object sender, EventArgs e)
        {
            if(textBoxServiceType.Text != null) {
                OracleCommand cmd;
                cmd = conn.CreateCommand();
                cmd.Transaction = trans;

                if (id_clicked == -1)
                {
                    cmd.CommandText = "insert into laundry_service (service_type, price) VALUES (:a1, :a2)";
                    cmd.Parameters.Add("a1", textBoxServiceType.Text);
                    cmd.Parameters.Add("a2", numericUpDownPrice.Value);
                }
                else
                {
                    cmd.CommandText = "update laundry_service set service_type = :a1, price = :a2 where laundry_service_id = :id";
                    cmd.Parameters.Add("a1", textBoxServiceType.Text);
                    cmd.Parameters.Add("a2", numericUpDownPrice.Value);
                    cmd.Parameters.Add("id", id_clicked);
                }
                cmd.ExecuteNonQuery();

                resetForm();
                buttonRevert.Enabled = true;
                buttonSave.Enabled = true;

                refresh();
            }
        }

        private void buttonRevert_Click(object sender, EventArgs e)
        {
            trans.Rollback();
            refresh();
            reset();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            trans.Commit();
            refresh();
            reset();
        }
    }
}
