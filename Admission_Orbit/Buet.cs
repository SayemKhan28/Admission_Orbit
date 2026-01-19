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
    public partial class Buet : Form
    {
        DataRow buetRow;
        public Buet()
        {
            InitializeComponent();
            LoadBuetData();
        }


        

        private void LoadBuetData()
        { 
            try
            {
                string cs = @"data source=SAYEM\SQLEXPRESS; database=master; integrated security=SSPI";

                using (SqlConnection con = new SqlConnection(cs))
                {
                    con.Open();

                 
                    string query = "SELECT * FROM dbo.Public_Uni WHERE [University Name] = 'Bangladesh University of Engineering and Technology(BUET)'";
                    SqlDataAdapter da = new SqlDataAdapter(query, con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("BUET data not found in database!");
                        return;
                    }


                    buetRow = dt.Rows[0];


                    label1.Text = buetRow["University Name"].ToString();
                    date.Text = "Application: " + Convert.ToDateTime(buetRow["Application Starting Date"]).ToString("dd MMM yyyy")
                                + " to " + Convert.ToDateTime(buetRow["Application Ending Date"]).ToString("dd MMM yyyy");
                    rssc.Text = "Required SSC GPA: " + buetRow["Required SSC GPA"].ToString();
                    rhsc.Text = "Required HSC GPA: " + buetRow["Required HSC GPA"].ToString();
                    fees.Text = "Fees: " + buetRow["Application Fees"].ToString();
                    units.Text = "Units: " + buetRow["Exam Units"].ToString();
                    format.Text = "Exam Format: " + buetRow["Exam Format"].ToString();
                    marks.Text = "Exam Marks: " + buetRow["Exam Marks"].ToString();
                    sub.Text = "Subjects: " + buetRow["Exam Subjects"].ToString();
                    seats.Text = "Total Seats: " + buetRow["Available Seats"].ToString();
                    dept.Text = "Departments: " + buetRow["Department Wise Seats"].ToString();
                    dist.Text = "District: " + buetRow["District"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading BUET data: " + ex.Message);
            }
        }

        
        private void Buet_Load(object sender, EventArgs e)
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

            string group = comboGrp.Text;
            double reqSSC = Convert.ToDouble(buetRow["Required SSC GPA"]);
            double reqHSC = Convert.ToDouble(buetRow["Required HSC GPA"]);

            if (group != "Science")
            {
                result.Text = " Only Science group students are eligible";
                result.ForeColor = Color.Red;
                return;
            }

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
    }
    }

