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
    public partial class AdminPrivateDelete : Form
    {
        public AdminPrivateDelete()
        {
            InitializeComponent();
        }
        void BindGridView()
        {
            string connectionString = "Data Source= SAYEM\\SQLEXPRESS; database=master; integrated security=SSPI";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Registration";
                using (SqlDataAdapter sda = new SqlDataAdapter(query, connection))
                {
                    DataTable data = new DataTable();
                    sda.Fill(data);
                    dataGridView1.DataSource = data;
                }
            }
        }

        private void AdminPrivateDelete_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source= SAYEM\\SQLEXPRESS; database=master; integrated security=SSPI";
            string searchValue = textBox1.Text.Trim();

            string query = "Select* From Modified WHERE [University Name] LIKE @searchTerm";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@searchTerm", "%" + searchValue + "%");
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (!reader.HasRows)
                        {
                            MessageBox.Show("No universities found matching the search term.", "No Results", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }

                        DataTable dt = new DataTable();
                        dt.Load(reader);
                        dataGridView1.DataSource = dt;
                    }

                }
            }

        }
        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source= SAYEM\\SQLEXPRESS; database=master; integrated security=SSPI";
            DialogResult result = MessageBox.Show(

               "Are you sure you want to delete this profile?",

                  "Confirm Deletion",

                  MessageBoxButtons.YesNo,

                 MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)

            {
                string uniName = textBox2.Text.Trim();


                string query = "DELETE FROM  Modified WHERE [University Name] = @UniversityName";
                using (SqlConnection connection = new SqlConnection(connectionString))

                {

                    using (SqlCommand command = new SqlCommand(query, connection))

                    {

                        command.Parameters.AddWithValue("@UniversityName", uniName);

                        connection.Open();

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)

                        {

                            MessageBox.Show("Profile deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            BindGridView();
                        }
                        else
                        {
                            MessageBox.Show("No profile was found to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }
        

        private void button3_Click(object sender, EventArgs e)
        {
            BindGridView();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminPrivateDashboard adminPrivateDashboard= new AdminPrivateDashboard();   
            adminPrivateDashboard.Show();
        }
       
    }
}
