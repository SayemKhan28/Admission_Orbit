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
    public partial class DeleteUserAccount : Form
    {
        public DeleteUserAccount()
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

        private void DeleteUserAccount_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            BindGridView();
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
                string email = textBox1.Text.Trim();
                string password = textBox2.Text.Trim();


                string query = "DELETE FROM  Registration WHERE [Email] = @Email";
                using (SqlConnection connection = new SqlConnection(connectionString))

                {

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Email", email);
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
            this.Hide();
           AdminPublicPrivate adminPublicPrivate= new AdminPublicPrivate();
            adminPublicPrivate.Show();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            DataGridViewRow row = dataGridView1.SelectedRows[0];
            textBox1.Text= row.Cells[3].Value.ToString();
            textBox2.Text = row.Cells[4].Value.ToString();
        }
    }
}
