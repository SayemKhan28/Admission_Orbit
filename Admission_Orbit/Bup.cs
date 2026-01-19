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
    public partial class Bup : Form
    {
        DataRow bupRow;
        public Bup()
        {
            InitializeComponent();
            LoadBupData();
        }

        private void LoadBupData()
        {
            try
            {
                string cs = @"data source=SAYEM\SQLEXPRESS; database=master; integrated security=SSPI";

                using (SqlConnection con = new SqlConnection(cs))
                {
                    con.Open();


                    string query = "SELECT * FROM dbo.Public_Uni WHERE [University Name] = 'Bangladesh University of Professionals(BUP)'";

                    SqlDataAdapter da = new SqlDataAdapter(query, con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("University data not found in database!");
                        return;
                    }


                    bupRow = dt.Rows[0];


                    label1.Text = bupRow["University Name"].ToString();
                    date.Text = "Application: " + Convert.ToDateTime(bupRow["Application Starting Date"]).ToString("dd MMM yyyy")
                                + " to " + Convert.ToDateTime(bupRow["Application Ending Date"]).ToString("dd MMM yyyy");
                    rssc.Text = "Required SSC GPA: " + bupRow["Required SSC GPA"].ToString();
                    rhsc.Text = "Required HSC GPA: " + bupRow["Required HSC GPA"].ToString();
                    fees.Text = "Fees: " + bupRow["Application Fees"].ToString();
                    units.Text = "Units: " + bupRow["Exam Units"].ToString();
                    format.Text = "Exam Format: " + bupRow["Exam Format"].ToString();
                    marks.Text = "Exam Marks: " + bupRow["Exam Marks"].ToString();
                    sub.Text = "Subjects: " + bupRow["Exam Subjects"].ToString();
                    seats.Text = "Total Seats: " + bupRow["Available Seats"].ToString();
                    dept.Text = "Departments: " + bupRow["Department Wise Seats"].ToString();
                    dist.Text = "District: " + bupRow["District"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading BUP data: " + ex.Message);
            }
        }


        private void Bup_Load(object sender, EventArgs e)
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


            string sscGpaStr = bupRow["Required SSC GPA"].ToString();
            string hscGpaStr = bupRow["Required HSC GPA"].ToString();

            double reqSSC = 0;
            double reqHSC = 0;


            if (grp == "Science")
            {
                reqSSC = Convert.ToDouble(sscGpaStr.Split('(')[0].Trim());
                reqHSC = Convert.ToDouble(hscGpaStr.Split('(')[0].Trim());
            }
            else if (grp == "Business" || grp == "Humanities")
            {

                string sscOthers = sscGpaStr.Split(',')[1];
                string hscOthers = hscGpaStr.Split(',')[1];
                reqSSC = Convert.ToDouble(sscOthers.Split('(')[0].Trim());
                reqHSC = Convert.ToDouble(hscOthers.Split('(')[0].Trim());
            }
            else
            {
                result.Text = "Please select a valid group";
                result.ForeColor = Color.Red;
                return;
            }


            if (ssc >= reqSSC && hsc >= reqHSC)
            {
                result.Text = "You are ELIGIBLE to apply for BUP";
                result.ForeColor = Color.Green;
            }
            else
            {
                result.Text = "Not Eligible (GPA requirements not met)";
                result.ForeColor = Color.Red;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            publicPrivate publicprivate = new publicPrivate();
            publicprivate.Show();
        }

        private void apply_Click(object sender, EventArgs e)
        {
            this.Hide();
            Apply apply = new Apply();
            apply.Show();
        }
    }
}
