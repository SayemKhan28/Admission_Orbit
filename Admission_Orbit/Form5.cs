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
    public partial class Form5 : Form
    {
        string connectionString = "data source=SAYEM\\SQLEXPRESS; database=master; integrated security=SSPI";


        public Form5()
        {

            InitializeComponent();
            textBox2.PasswordChar = '*';
            textBox3.PasswordChar = '*';
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            string email = textBox1.Text.Trim();
            string password = textBox2.Text.Trim();
            string confirmPassword = textBox3.Text.Trim();


            if (string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(confirmPassword))
            {
                MessageBox.Show("Password fields cannot be empty.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
                      }


            if (password != confirmPassword)
            {
                MessageBox.Show("Password and Confirm Password do not match.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
                  }

          string query = "UPDATE Registration SET Password = @Password WHERE Email = @Email";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Password", password);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Password updated successfully!", "Success",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Hide();
                        Form2 f2 = new Form2();
                        f2.Show();
                    }
                    else
                    {
                        MessageBox.Show("User not found.", "Error",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
          }
            }
          }

        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.PasswordChar == '*')
            {
                textBox2.PasswordChar = '\0';
                button2.Text = "Hide";
            }
            else
            {
                textBox2.PasswordChar = '*';
                button2.Text = "Show";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox3.PasswordChar == '*')
            {
                textBox3.PasswordChar = '\0';
                button3.Text = "Hide";
            }
            else
            {
                textBox3.PasswordChar = '*';
                button3.Text = "Show";
            }
        }
    }
       }

