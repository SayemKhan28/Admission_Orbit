using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Admission_Orbit
{
    public partial class AdminPrivateView : Form
    {
        public AdminPrivateView()
        {
            InitializeComponent();
        }
        void BindGridView()
        {
            string connectionString = "Data Source= SAYEM\\SQLEXPRESS; database=master; integrated security=SSPI";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Modified";
                using (SqlDataAdapter sda = new SqlDataAdapter(query, connection))
                {
                    DataTable data = new DataTable();
                    sda.Fill(data);
                    dataGridView1.DataSource = data;
                }
            }
        }

        private void AdminPrivateView_Load(object sender, EventArgs e)
        {
            BindGridView();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminPrivateDashboard adminPrivateDashboard = new AdminPrivateDashboard();
            adminPrivateDashboard.Show();
        }
    }
}
