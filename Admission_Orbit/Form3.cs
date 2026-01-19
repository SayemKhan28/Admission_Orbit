using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Admission_Orbit
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = "data source=SAYEM\\SQLEXPRESS; database=master; integrated security=SSPI";




            string name = textBox1.Text.Trim();
            string sscgpa = textBox2.Text.Trim();
            string hscgpa = textBox3.Text.Trim();
            string email = textBox4.Text.Trim();
            string password = textBox5.Text.Trim();

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(sscgpa) ||
    string.IsNullOrWhiteSpace(hscgpa) || string.IsNullOrWhiteSpace(email)
       || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("All fields must be filled out.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!float.TryParse(sscgpa, out float parsedSSCGPA))
            {
                MessageBox.Show("Gpa must be a valid number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!float.TryParse(hscgpa, out float parsedHSCGPA))
            {
                MessageBox.Show("Gpa must be a valid number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

            if (!Regex.IsMatch(email, emailPattern))
            {
                MessageBox.Show("Please enter a valid email address.",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            string query = "INSERT INTO Registration (Name,SSC_GPA, HSC_GPA,Email,Password) VALUES ( @Name, @SSC_GPA, @HSC_GPA,@Email,@Password)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", name);

                    command.Parameters.AddWithValue("@SSC_GPA", parsedSSCGPA);

                    command.Parameters.AddWithValue("@HSC_GPA", parsedHSCGPA);
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Password", password);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {



                        MessageBox.Show("Profile created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        UserSession.Email = email;

                        // Optional: send registration email
                        EmailHelper.SendEmail(
                            email,
                            "Registration Successful",
                            "Welcome " + name + "!\nYour account has been created successfully."
                        );

                        this.Hide();
                        Form2 f2 = new Form2();
                        f2.Show();
                    }
                    else
                    {
                        MessageBox.Show("Failed to create the profile. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }


           
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
