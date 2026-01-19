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
    public partial class JU : Form
    {
        DataRow juRow;
        public JU()
        {
            InitializeComponent();
            LoadJuData();
        }

        private void LoadJuData()
        {
            try
            {

                string cs = @"Data Source=SAYEM\SQLEXPRESS; Database=master; Integrated Security=SSPI";

                using (SqlConnection con = new SqlConnection(cs))
                {
                    con.Open();


                    string query = "SELECT * FROM dbo.Public_Uni WHERE [University Name] = 'Jahangirnagar University (JU)'";
                    SqlDataAdapter da = new SqlDataAdapter(query, con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("University data not found in database!");
                        return;
                    }


                    juRow = dt.Rows[0];


                    label1.Text = juRow["University Name"].ToString();
                    date.Text = "Application: " + Convert.ToDateTime(juRow["Application Starting Date"]).ToString("dd MMM yyyy")
                                + " to " + Convert.ToDateTime(juRow["Application Ending Date"]).ToString("dd MMM yyyy");
                    rssc.Text = "Required SSC GPA: " + juRow["Required SSC GPA"].ToString();
                    rhsc.Text = "Required HSC GPA: " + juRow["Required HSC GPA"].ToString();
                    fees.Text = "Fees: " + juRow["Application Fees"].ToString();
                    units.Text = "Units: " + juRow["Exam Units"].ToString();
                    format.Text = "Exam Format: " + juRow["Exam Format"].ToString();
                    marks.Text = "Exam Marks: " + juRow["Exam Marks"].ToString();
                    sub.Text = "Subjects: " + juRow["Exam Subjects"].ToString();
                    seats.Text = "Total Seats: " + juRow["Available Seats"].ToString();
                    dept.Text = "Departments: " + juRow["Department Wise Seats"].ToString();
                    dist.Text = "District: " + juRow["District"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading JU data: " + ex.Message);
            }
        }

        private void JU_Load(object sender, EventArgs e)
        {

        }

        private void checkbtn_Click(object sender, EventArgs e)
        {
            if (!double.TryParse(txtssc.Text, out double ssc) || !double.TryParse(txthsc.Text, out double hsc))
            {
                result.Text = " Invalid GPA input";
                result.ForeColor = Color.Red;
                return;
            }

            if (ssc < 0 || ssc > 5 || hsc < 0 || hsc > 5)
            {
                result.Text = " GPA must be between 0 and 5";
                result.ForeColor = Color.Red;
                return;
            }

            string grp = comboGrp.Text;
            if (string.IsNullOrEmpty(grp))
            {
                result.Text = "Please select your group";
                result.ForeColor = Color.Red;
                return;
            }


            string sscGpaStr = juRow["Required SSC GPA"].ToString();
            string hscGpaStr = juRow["Required HSC GPA"].ToString();


            string[] sscParts = sscGpaStr.Split(new string[] { ")," }, StringSplitOptions.None);
            string[] hscParts = hscGpaStr.Split(new string[] { ")," }, StringSplitOptions.None);

            double reqSSC = 0;
            double reqHSC = 0;

            if (grp == "Science")
            {
                double.TryParse(sscParts[0].Split('(')[0], out reqSSC);
                double.TryParse(hscParts[0].Split('(')[0], out reqHSC);
            }
            else if (grp == "Business" || grp == "Humanities")
            {
                double.TryParse(sscParts[1].Split('(')[0], out reqSSC);
                double.TryParse(hscParts[1].Split('(')[0], out reqHSC);
            }
            else
            {
                result.Text = "Please select a valid group";
                result.ForeColor = Color.Red;
                return;
            }


            if (ssc >= reqSSC && hsc >= reqHSC)
            {
                result.Text = "You are ELIGIBLE to apply for Jahangirnagar University";
                result.ForeColor = Color.Green;
            }
            else
            {
                result.Text = "Not Eligible (GPA requirements not met)";
                result.ForeColor = Color.Red;
            }
        }

        private void apply_Click(object sender, EventArgs e)
        {
            this.Hide();
            Apply apply = new Apply();
            apply.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            publicPrivate publicPrivate = new publicPrivate();
            publicPrivate.Show();
        }
    }
}
