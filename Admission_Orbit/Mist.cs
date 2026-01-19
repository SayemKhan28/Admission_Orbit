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
    public partial class Mist : Form
    {
        DataRow mistRow;
        public Mist()
        {
            InitializeComponent();
            LoadMistData();
        }

        private void LoadMistData()
        {
            try
            {
                string cs = @"data source=SAYEM\SQLEXPRESS; database=master; integrated security=SSPI";

                using (SqlConnection con = new SqlConnection(cs))
                {
                    con.Open();


                    string query = "SELECT * FROM dbo.Public_Uni WHERE [University Name] = 'Military Institute of Science & Technology(MIST)'";
                    SqlDataAdapter da = new SqlDataAdapter(query, con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("University data not found in database!");
                        return;
                    }


                    mistRow = dt.Rows[0];


                    label1.Text = mistRow["University Name"].ToString();
                    date.Text = "Application: " + Convert.ToDateTime(mistRow["Application Starting Date"]).ToString("dd MMM yyyy")
                                + " to " + Convert.ToDateTime(mistRow["Application Ending Date"]).ToString("dd MMM yyyy");
                    rssc.Text = "Required SSC GPA: " + mistRow["Required SSC GPA"].ToString();
                    rhsc.Text = "Required HSC GPA: " + mistRow["Required HSC GPA"].ToString();
                    fees.Text = "Fees: " + mistRow["Application Fees"].ToString();
                    units.Text = "Units: " + mistRow["Exam Units"].ToString();
                    format.Text = "Exam Format: " + mistRow["Exam Format"].ToString();
                    marks.Text = "Exam Marks: " + mistRow["Exam Marks"].ToString();
                    sub.Text = "Subjects: " + mistRow["Exam Subjects"].ToString();
                    seats.Text = "Total Seats: " + mistRow["Available Seats"].ToString();
                    dept.Text = "Departments: " + mistRow["Department Wise Seats"].ToString();
                    dist.Text = "District: " + mistRow["District"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading MIST data: " + ex.Message);
            }
        }
        private void Mist_Load(object sender, EventArgs e)
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


            string sscGpaStr = mistRow["Required SSC GPA"].ToString();
            string hscGpaStr = mistRow["Required HSC GPA"].ToString();

            double reqSSC = 0;
            double reqHSC = 0;


            if (grp == "Science")
            {
                reqSSC = Convert.ToDouble(sscGpaStr.Split(' ')[0].Trim());
                reqHSC = Convert.ToDouble(hscGpaStr.Split(' ')[0].Trim());
            }
            else if (grp == "Business" || grp == "Humanities")
            {

                result.Text = "Only Science group students are eligible for MIST";
                result.ForeColor = Color.Red;
                return;
            }
            else
            {
                result.Text = "Please select a valid group";
                result.ForeColor = Color.Red;
                return;
            }


            if (ssc >= reqSSC && hsc >= reqHSC)
            {
                result.Text = "You are ELIGIBLE to apply for MIST";
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
