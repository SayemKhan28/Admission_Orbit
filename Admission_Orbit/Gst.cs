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
    public partial class Gst : Form
    {
        DataRow gstRow;
        public Gst()
        {
            InitializeComponent();
            LoadGstData();
        }

        private void LoadGstData()
        {
            try
            {

                string cs = @"Data Source=SAYEM\SQLEXPRESS; Database=master; Integrated Security=SSPI";

                using (SqlConnection con = new SqlConnection(cs))
                {
                    con.Open();


                    string query = "SELECT * FROM dbo.Public_Uni WHERE [University Name] = 'GST'";
                    SqlDataAdapter da = new SqlDataAdapter(query, con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("University data not found in database!");
                        return;
                    }


                    gstRow = dt.Rows[0];


                    label1.Text = gstRow["University Name"].ToString();
                    date.Text = "Application: " + Convert.ToDateTime(gstRow["Application Starting Date"]).ToString("dd MMM yyyy")
                                + " to " + Convert.ToDateTime(gstRow["Application Ending Date"]).ToString("dd MMM yyyy");
                    rssc.Text = "Required SSC GPA: " + gstRow["Required SSC GPA"].ToString();
                    rhsc.Text = "Required HSC GPA: " + gstRow["Required HSC GPA"].ToString();
                    fees.Text = "Fees: " + gstRow["Application Fees"].ToString();
                    units.Text = "Units: " + gstRow["Exam Units"].ToString();
                    format.Text = "Exam Format: " + gstRow["Exam Format"].ToString();
                    marks.Text = "Exam Marks: " + gstRow["Exam Marks"].ToString();
                    sub.Text = "Subjects: " + gstRow["Exam Subjects"].ToString();
                    seats.Text = "Total Seats: " + gstRow["Available Seats"].ToString();
                    dept.Text = "Departments: " + gstRow["Department Wise Seats"].ToString();
                    dist.Text = "District: " + gstRow["District"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading GST data: " + ex.Message);
            }
        }

        private void Gst_Load(object sender, EventArgs e)
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

            string sscGpaStr = gstRow["Required SSC GPA"].ToString();
            string hscGpaStr = gstRow["Required HSC GPA"].ToString();

            double reqSSC = 0;
            double reqHSC = 0;


            switch (grp)
            {
                case "Science":
                    reqSSC = Convert.ToDouble(sscGpaStr.Split(',')[0].Split('(')[0].Trim());
                    reqHSC = Convert.ToDouble(hscGpaStr.Split(',')[0].Split('(')[0].Trim());
                    break;

                case "Business":
                case "Humanities":
                    reqSSC = Convert.ToDouble(sscGpaStr.Split(',')[1].Split('(')[0].Trim());
                    reqHSC = Convert.ToDouble(hscGpaStr.Split(',')[1].Split('(')[0].Trim());
                    break;

                default:
                    result.Text = "Please select a valid group";
                    result.ForeColor = Color.Red;
                    return;
            }


            if (ssc >= reqSSC && hsc >= reqHSC)
            {
                result.Text = "You are ELIGIBLE to apply for GST";
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
