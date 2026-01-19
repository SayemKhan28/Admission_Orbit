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
    public partial class DU : Form
    {
        DataRow duRow;
        public DU()
        {
            InitializeComponent();
            LoadDUData();
        }

        private void LoadDUData()
        {
            try
            {
                string cs = @"Data Source=SAYEM\SQLEXPRESS; Database=master; Integrated Security=SSPI";

                using (SqlConnection con = new SqlConnection(cs))
                {
                    con.Open();


                    string query = "SELECT * FROM dbo.Public_Uni WHERE [University Name] = 'Dhaka University'";
                    SqlDataAdapter da = new SqlDataAdapter(query, con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("University data not found in database!");
                        return;
                    }

                    duRow = dt.Rows[0];


                    label1.Text = duRow["University Name"].ToString();
                    date.Text = "Application: " + Convert.ToDateTime(duRow["Application Starting Date"]).ToString("dd MMM yyyy")
                                + " to " + Convert.ToDateTime(duRow["Application Ending Date"]).ToString("dd MMM yyyy");
                    rssc.Text = "Required SSC GPA: " + duRow["Required SSC GPA"].ToString();
                    rhsc.Text = "Required HSC GPA: " + duRow["Required HSC GPA"].ToString();
                    fees.Text = "Fees: " + duRow["Application Fees"].ToString();
                    units.Text = "Units: " + duRow["Exam Units"].ToString();
                    format.Text = "Exam Format: " + duRow["Exam Format"].ToString();
                    marks.Text = "Exam Marks: " + duRow["Exam Marks"].ToString();
                    sub.Text = "Subjects: " + duRow["Exam Subjects"].ToString();
                    seats.Text = "Total Seats: " + duRow["Available Seats"].ToString();
                    dept.Text = "Departments: " + duRow["Department Wise Seats"].ToString();
                    dist.Text = "District: " + duRow["District"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading DU data: " + ex.Message);
            }
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
           

            double reqSSC = Convert.ToDouble(duRow["Required SSC GPA"]);
            double reqHSC = Convert.ToDouble(duRow["Required HSC GPA"]);

            if (ssc >= reqSSC && hsc >= reqHSC)
            {
                result.Text = " You are ELIGIBLE to apply";
                result.ForeColor = Color.Green;
            }
            else
            {
                result.Text = " Not Eligible (GPA requirements not met)";
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

        private void DU_Load(object sender, EventArgs e)
        {

        }
    }
}
