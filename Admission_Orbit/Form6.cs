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
   public partial class Form6 : Form
    {
    public Form6()
        {
            InitializeComponent();
            textBox2.PasswordChar = '*';
            textBox3.PasswordChar = '*';
            textBox4.PasswordChar = '*';
        }

    private void button1_Click(object sender, EventArgs e)
        {
            string connectionString =
        "data source=SAYEM\\SQLEXPRESS; database=master; integrated security=SSPI";

    
            string email = textBox1.Text.Trim();
            string currentPassword = textBox2.Text.Trim();
            string newPassword = textBox3.Text.Trim();
            string confirmPassword = textBox4.Text.Trim();


            if (string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(currentPassword) ||
                string.IsNullOrWhiteSpace(newPassword) ||
                string.IsNullOrWhiteSpace(confirmPassword))
            {
                MessageBox.Show("All fields are required ", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            if (newPassword != confirmPassword)
            {
                MessageBox.Show("New Password and Confirm Password do not match ", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();


                string checkQuery =
                    "SELECT COUNT(*) FROM Registration WHERE Email = @Email AND Password = @Password";

                using (SqlCommand checkCmd = new SqlCommand(checkQuery, connection))
                {
                    checkCmd.Parameters.AddWithValue("@Email", email);
                    checkCmd.Parameters.AddWithValue("@Password", currentPassword);

                    int userExists = (int)checkCmd.ExecuteScalar();

                    if (userExists == 0)
                    {
                        MessageBox.Show("Invalid email or current password ", "Error",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }


                string updateQuery =
                    "UPDATE Registration SET Password = @NewPassword WHERE Email = @Email";

                using (SqlCommand updateCmd = new SqlCommand(updateQuery, connection))
                {
                    updateCmd.Parameters.AddWithValue("@NewPassword", newPassword);
                    updateCmd.Parameters.AddWithValue("@Email", email);

                    updateCmd.ExecuteNonQuery();

                    MessageBox.Show("Password Changed Successfully", "Success",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Hide();
                    Form2 f2 = new Form2();
                    f2.Show();
                }
               }
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

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox4.PasswordChar == '*')
            {
                textBox4.PasswordChar = '\0';
                button4.Text = "Hide";
            }
            else
            {
                textBox4.PasswordChar = '*';
                button4.Text = "Show";
            }
        }
    }
        }

