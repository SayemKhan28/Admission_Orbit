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
    public partial class CU : Form
    {
        DataRow cuRow;
        public CU()
        {
            InitializeComponent();
            LoadcuData();
        }


        private void LoadcuData()
        {
            try
            {
                string cs = @"Data Source=SAYEM\SQLEXPRESS; Database=master; Integrated Security=SSPI";


                using (SqlConnection con = new SqlConnection(cs))
                {
                    con.Open();

                    

                    string query = "SELECT * FROM dbo.Public_Uni WHERE [University Name] = 'University of Chittagong'";
                    SqlDataAdapter da = new SqlDataAdapter(query, con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("University data not found in database!");
                        return;
                    }

                   
                    cuRow = dt.Rows[0];

                 
                    label1.Text = cuRow["University Name"].ToString();
                    date.Text = "Application: " + Convert.ToDateTime(cuRow["Application Starting Date"]).ToString("dd MMM yyyy")
                                + " to " + Convert.ToDateTime(cuRow["Application Ending Date"]).ToString("dd MMM yyyy");
                    rssc.Text = "Required SSC GPA: " + cuRow["Required SSC GPA"].ToString();
                    rhsc.Text = "Required HSC GPA: " + cuRow["Required HSC GPA"].ToString();
                    fees.Text = "Fees: " + cuRow["Application Fees"].ToString();
                    units.Text = "Units: " + cuRow["Exam Units"].ToString();
                    format.Text = "Exam Format: " + cuRow["Exam Format"].ToString();
                    marks.Text = "Exam Marks: " + cuRow["Exam Marks"].ToString();
                    sub.Text = "Subjects: " + cuRow["Exam Subjects"].ToString();
                    seats.Text = "Total Seats: " + cuRow["Available Seats"].ToString();
                    dept.Text = "Departments: " + cuRow["Department Wise Seats"].ToString();
                    dist.Text = "District: " + cuRow["District"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading CU data: " + ex.Message);
            }
        }



        private void CU_Load(object sender, EventArgs e)
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

            string sscGpaStr = cuRow["Required SSC GPA"].ToString();
            string hscGpaStr = cuRow["Required HSC GPA"].ToString();


            
            string[] sscParts = sscGpaStr.Split(new string[] { ")," }, StringSplitOptions.None);
            string[] hscParts = hscGpaStr.Split(new string[] { ")," }, StringSplitOptions.None);

            double reqSSC = 0;
            double reqHSC = 0;

            switch (grp)
            {
                case "Science":   
                    double.TryParse(sscParts[0].Split('(')[0], out reqSSC);
                    double.TryParse(hscParts[0].Split('(')[0], out reqHSC);
                    break;

                case "Business":  
                case "Humanities":
                    double.TryParse(sscParts[1].Split('(')[0], out reqSSC);
                    double.TryParse(hscParts[1].Split('(')[0], out reqHSC);
                    break;

                case "Special":   
                    double.TryParse(sscParts[2].Split('(')[0], out reqSSC);
                    double.TryParse(hscParts[2].Split('(')[0], out reqHSC);
                    break;

                default:
                    result.Text = "Please select a valid group";
                    result.ForeColor = Color.Red;
                    return;
            }



           
            if (ssc >= reqSSC && hsc >= reqHSC)
            {
                result.Text = "You are ELIGIBLE to apply for University of Chittagong";
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
