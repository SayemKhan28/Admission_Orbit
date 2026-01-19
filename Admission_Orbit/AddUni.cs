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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Admission_Orbit
{
    public partial class AddUni : Form
    {
        public AddUni()
        {
            InitializeComponent();
            checkedListBox1.CheckOnClick = true;
            checkedListBox2.CheckOnClick = true;
            checkedListBox3.CheckOnClick = true;
            checkedListBox4.CheckOnClick = true;
            checkedListBox5.CheckOnClick = true;
        }

        private void AddUni_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=SAYEM\\SQLEXPRESS; database=master; integrated security=SSPI";
            string uniName = textBox1.Text.Trim();
            string applicationStD = textBox2.Text.Trim();
            string applicationEnD = textBox3.Text.Trim();
            string ssc = textBox4.Text.Trim();
            string hsc = textBox5.Text.Trim();
            string fees = textBox6.Text.Trim();
            string scholarship = textBox7.Text.Trim();
            string availableSeats = textBox8.Text.Trim();
            string others = textBox9.Text.Trim();
            string addInfo = textBox10.Text.Trim();
            string depWiseSeats = textBox11.Text.Trim();

            if (string.IsNullOrWhiteSpace(uniName) || string.IsNullOrWhiteSpace(applicationStD)
             || string.IsNullOrWhiteSpace(applicationEnD) || string.IsNullOrWhiteSpace(ssc)
             || string.IsNullOrWhiteSpace(hsc) || string.IsNullOrWhiteSpace(fees)
             || string.IsNullOrWhiteSpace(scholarship) || string.IsNullOrWhiteSpace(availableSeats)
             || string.IsNullOrWhiteSpace(others) || string.IsNullOrWhiteSpace(addInfo)
             || string.IsNullOrWhiteSpace(depWiseSeats))
            {
                MessageBox.Show("All fields must be filled out.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            if (checkedListBox1.CheckedItems.Count == 0)
            {
                MessageBox.Show("No Option Selected");
                return;
            }
            string examUnits = "";
            foreach (var item in checkedListBox1.CheckedItems)
            {
                examUnits += item.ToString() + ",";
            }
            MessageBox.Show(examUnits);

            if (checkedListBox2.CheckedItems.Count == 0)
            {
                MessageBox.Show("No Option Selected");
                return;
            }
            string result2 = "";
            foreach (var item in checkedListBox2.CheckedItems)
            {
                result2 += item.ToString() + ", ";
            }
            MessageBox.Show(result2);

            if (checkedListBox3.CheckedItems.Count == 0)
            {
                MessageBox.Show("No Option Selected");
                return;
            }
            string result3 = "";
            foreach (var item in checkedListBox3.CheckedItems)
            {
                result3 += item.ToString() + ", ";
            }
            MessageBox.Show(result3);

            if (checkedListBox4.CheckedItems.Count == 0)
            {
                MessageBox.Show("No Option Selected");
                return;
            }
            string result4 = "";
            foreach (var item in checkedListBox4.CheckedItems)
            {
                result4 += item.ToString() + ", ";
            }
            MessageBox.Show("" + result4);
            if (checkedListBox5.CheckedItems.Count == 0)
            {
                MessageBox.Show("No Option Selected");
                return;
            }
            string district = "";
            foreach (var item in checkedListBox5.CheckedItems)
            {
                district += item.ToString() + ",";
            }
            MessageBox.Show(district);

            string query = "INSERT INTO Public_Uni([University Name],[Application Starting Date],[Application Ending Date],[Required SSC GPA],[Required HSC GPA], [Application Fees], [Exam Units], [Exam Format], [Exam Marks],[Exam Subjects], [Scholarship/Waivers], [Available Seats], [Others], [Additional Information], [Department Wise Seats],[District]) VALUES (@UniversityName, @ApplicationStartingDate,@ApplicationEndingDate,@RequiredSSCGPA,@RequiredHSCGPA, @ApplicationFees, @ExamUnits, @ExamFormat, @ExamMarks,@ExamSubjects, @Scholarship, @AvailableSeats, @Others, @AdditionalInformation, @DepartmentWiseSeats, @District)";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add("@UniversityName", SqlDbType.NVarChar, 200).Value = uniName;

                    command.Parameters.Add("@ApplicationStartingDate", SqlDbType.Date).Value =
                        DateTime.Parse(applicationStD);

                    command.Parameters.Add("@ApplicationEndingDate", SqlDbType.Date).Value =
                        DateTime.Parse(applicationEnD);

                    command.Parameters.Add("@RequiredSSCGPA", SqlDbType.NVarChar).Value =
                        ssc;

                    command.Parameters.Add("@RequiredHSCGPA", SqlDbType.NVarChar).Value =
                        hsc;

                    command.Parameters.Add("@ApplicationFees", SqlDbType.NVarChar).Value =
                        fees;

                    command.Parameters.Add("@Scholarship", SqlDbType.NVarChar, 200).Value =
                        scholarship;

                    command.Parameters.Add("@AvailableSeats", SqlDbType.NVarChar).Value =
                        availableSeats;

                    command.Parameters.Add("@Others", SqlDbType.NVarChar, 500).Value =
                        others;

                    command.Parameters.Add("@AdditionalInformation", SqlDbType.NVarChar, 1000).Value =
                        addInfo;

                    command.Parameters.Add("@DepartmentWiseSeats", SqlDbType.NVarChar).Value =
                        depWiseSeats;

                    command.Parameters.Add("@ExamUnits", SqlDbType.NVarChar, 500).Value =
                        examUnits.TrimEnd(',', ' ');

                    command.Parameters.Add("@ExamFormat", SqlDbType.NVarChar, 500).Value =
                        result2.TrimEnd(',', ' ');

                    command.Parameters.Add("@ExamMarks", SqlDbType.NVarChar, 500).Value =
                        result3.TrimEnd(',', ' ');

                    command.Parameters.Add("@ExamSubjects", SqlDbType.NVarChar, 500).Value =
                        result4.TrimEnd(',', ' ');
                    command.Parameters.Add("@District", SqlDbType.NVarChar, 500).Value =
                       district.TrimEnd(',', ' ');

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("University Added successfully!", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Hide();
                        AllInfo allInfo = new AllInfo();
                        allInfo.Show();
                        
                    }
                    else
                    {
                        MessageBox.Show("Insert failed!", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    connection.Close();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminPublic adminPublic = new AdminPublic();
            adminPublic.Show();
        }
    }
}
