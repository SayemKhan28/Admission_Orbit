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
    public partial class EditPublic : Form
    {
        public EditPublic()
        {
            InitializeComponent();
            checkedListBox1.CheckOnClick = true;
            checkedListBox2.CheckOnClick = true;
            checkedListBox3.CheckOnClick = true;
            checkedListBox4.CheckOnClick = true;
            checkedListBox5.CheckOnClick = true;
        }
        void BindGridView()
        {
            string connectionString = "Data Source= SAYEM\\SQLEXPRESS; database=master; integrated security=SSPI";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Public_Uni";
                using (SqlDataAdapter sda = new SqlDataAdapter(query, connection))
                {
                    DataTable data = new DataTable();
                    sda.Fill(data);
                    dataGridView1.DataSource = data;
                }
            }
        }
       /* private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {


            if (e.RowIndex < 0)
                return;
            DataGridViewRow row = dataGridView1.SelectedRows[0];
            textBox1.Text = row.Cells[0].Value.ToString();
            textBox2.Text = row.Cells[1].Value.ToString();
            textBox3.Text = row.Cells[2].Value.ToString();
            textBox4.Text = row.Cells[3].Value.ToString();
            textBox5.Text = row.Cells[4].Value.ToString();
            textBox6.Text = row.Cells[5].Value.ToString();

            ClearCheckedList(checkedListBox1);
            ClearCheckedList(checkedListBox2);
            ClearCheckedList(checkedListBox3);
            ClearCheckedList(checkedListBox4);
            ClearCheckedList(checkedListBox5);

            SetCheckedItems(checkedListBox1, row.Cells[6].Value.ToString());
            SetCheckedItems(checkedListBox2, row.Cells[7].Value.ToString());
            SetCheckedItems(checkedListBox3, row.Cells[8].Value.ToString());
            SetCheckedItems(checkedListBox4, row.Cells[9].Value.ToString());
            SetCheckedItems(checkedListBox5, row.Cells[15].Value.ToString());

            textBox7.Text = row.Cells[10].Value.ToString();
            textBox8.Text = row.Cells[11].Value.ToString();
            textBox9.Text = row.Cells[12].Value.ToString();
            textBox10.Text = row.Cells[13].Value.ToString();
            textBox11.Text = row.Cells[14].Value.ToString();


        }
        */
        private void EditPublic_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminPublic adminPublic = new AdminPublic();
            adminPublic.Show();
        }
        private void ClearCheckedList(CheckedListBox clb)
        {
            for (int i = 0; i < clb.Items.Count; i++)
            {
                clb.SetItemChecked(i, false);
            }
        }
        private void SetCheckedItems(CheckedListBox clb, string dbValue)
        {
            if (string.IsNullOrEmpty(dbValue))
                return;
            string[] values = dbValue.Split(',');
            for (int i = 0; i < clb.Items.Count; i++)
            {
                foreach (string val in values)
                {

                    if (clb.Items[i].ToString().Trim() == val.Trim())
                    {
                        clb.SetItemChecked(i, true);
                    }


                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            BindGridView(); 
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source= SAYEM\\SQLEXPRESS; database=master; integrated security=SSPI";

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


            string query = "UPDATE Public_Uni SET [Application Starting Date]=@ApplicationStartingDate,[Application Ending Date]=@ApplicationEndingDate,[Required SSC GPA]=@RequiredSSCGPA,[Required HSC GPA]=@RequiredHSCGPA, [Application Fees]=@ApplicationFees, [Exam Units]= @ExamUnits, [Exam Format]=@ExamFormat, [Exam Marks]= @ExamMarks,[Exam Subjects]=@ExamSubjects, [Scholarship/Waivers]= @Scholarship, [Available Seats]=@AvailableSeats, [Others]=@Others, [Additional Information]=@AdditionalInformation, [Department Wise Seats]= @DepartmentWiseSeats, [District]=@District WHERE [University Name] =@UniversityName";

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

                        BindGridView();


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

        private void dataGridView1_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex < 0)
                return;
            DataGridViewRow row = dataGridView1.SelectedRows[0];
            textBox1.Text = row.Cells[0].Value.ToString();
            textBox2.Text = row.Cells[1].Value.ToString();
            textBox3.Text = row.Cells[2].Value.ToString();
            textBox4.Text = row.Cells[3].Value.ToString();
            textBox5.Text = row.Cells[4].Value.ToString();
            textBox6.Text = row.Cells[5].Value.ToString();

            ClearCheckedList(checkedListBox1);
            ClearCheckedList(checkedListBox2);
            ClearCheckedList(checkedListBox3);
            ClearCheckedList(checkedListBox4);
            ClearCheckedList(checkedListBox5);

            SetCheckedItems(checkedListBox1, row.Cells[6].Value.ToString());
            SetCheckedItems(checkedListBox2, row.Cells[7].Value.ToString());
            SetCheckedItems(checkedListBox3, row.Cells[8].Value.ToString());
            SetCheckedItems(checkedListBox4, row.Cells[9].Value.ToString());
            SetCheckedItems(checkedListBox5, row.Cells[15].Value.ToString());

            textBox7.Text = row.Cells[10].Value.ToString();
            textBox8.Text = row.Cells[11].Value.ToString();
            textBox9.Text = row.Cells[12].Value.ToString();
            textBox10.Text = row.Cells[13].Value.ToString();
            textBox11.Text = row.Cells[14].Value.ToString();

        }
    }

}

 
        
