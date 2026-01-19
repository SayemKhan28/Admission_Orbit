using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Admission_Orbit
{
    public partial class Form40 : Form
    {
        string department;

        public Form40(string dept)
        {
            InitializeComponent();
            department = dept;

           
          
            
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form8 f8 = new Form8();
            f8.Show();
        }

        void LoadRanking()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("Rank");
            dt.Columns.Add("University");
            dt.Columns.Add("Department");
            dt.Columns.Add("Reputation Basis");

            if (department == "CSE")
            {
                dt.Rows.Add("1", "BRAC University", "CSE", "QS Reputation");
                dt.Rows.Add("2", "North South University (NSU)", "CSE", "QS Reputation");
                dt.Rows.Add("3", "Ahsanullah University of Science & Technology (AUST)", "CSE", "Engineering Focus");
                dt.Rows.Add("4", "Independent University, Bangladesh (IUB)", "CSE", "Research & Alumni");
                dt.Rows.Add("5", "American International University-Bangladesh (AIUB)", "CSE", "Industry Popularity");
                dt.Rows.Add("6", "East West University (EWU)", "CSE", "Academic Performance");
                dt.Rows.Add("7", "United International University (UIU)", "CSE", "Competitive Programming");
                dt.Rows.Add("8", "Daffodil International University (DIU)", "CSE", "Tech Events & Scale");
                dt.Rows.Add("9", "Premier University, Chittagong", "CSE", "Emerging Tech Programs");
                dt.Rows.Add("10", "University of Asia Pacific (UAP)", "CSE", "Project-Based Learning");
            }
            else if (department == "EEE")
            {
                dt.Rows.Add("1", "Ahsanullah University of Science & Technology (AUST)", "EEE", "Strong Engineering Reputation");
                dt.Rows.Add("2", "BRAC University", "EEE", "Research & Faculty Strength");
                dt.Rows.Add("3", "North South University (NSU)", "EEE", "Academic Reputation");
                dt.Rows.Add("4", "East West University (EWU)", "EEE", "Accredited Engineering Program");
                dt.Rows.Add("5", "American International University-Bangladesh (AIUB)", "EEE", "Industry-Oriented Curriculum");
                dt.Rows.Add("6", "Independent University, Bangladesh (IUB)", "EEE", "Academic Performance");
                dt.Rows.Add("7", "United International University (UIU)", "EEE", "Lab & Practical Focus");
                dt.Rows.Add("8", "Daffodil International University (DIU)", "EEE", "Infrastructure & Scale");
                dt.Rows.Add("9", "Premier University, Chittagong", "EEE", "Emerging Tech Focus");
                dt.Rows.Add("10", "University of Asia Pacific (UAP)", "EEE", "Project-Based Learning");
            }
            else if (department == "BBA")
            {
                dt.Rows.Add("1", "North South University (NSU)", "BBA", "Business School Reputation");
                dt.Rows.Add("2", "BRAC University", "BBA", "Corporate & Research Focus");
                dt.Rows.Add("3", "Independent University, Bangladesh (IUB)", "BBA", "International Exposure");
                dt.Rows.Add("4", "East West University (EWU)", "BBA", "Academic Performance");
                dt.Rows.Add("5", "American International University-Bangladesh (AIUB)", "BBA", "Industry Alignment");
                dt.Rows.Add("6", "United International University (UIU)", "BBA", "Modern Curriculum");
                dt.Rows.Add("7", "Daffodil International University (DIU)", "BBA", "Entrepreneurship Focus");
                dt.Rows.Add("8", "Ahsanullah University of Science & Technology (AUST)", "BBA", "Management Programs");
                dt.Rows.Add("9", "Premier University, Chittagong", "BBA", "Emerging Business Practices");
                dt.Rows.Add("10", "University of Asia Pacific (UAP)", "BBA", "Practical Industry Projects");
            }
            else if (department == "LLB")
            {
                dt.Rows.Add("1", "BRAC University", "LLB", "Law Faculty & Research");
                dt.Rows.Add("2", "North South University (NSU)", "LLB", "Academic Reputation");
                dt.Rows.Add("3", "Independent University, Bangladesh (IUB)", "LLB", "Legal Studies Strength");
                dt.Rows.Add("4", "East West University (EWU)", "LLB", "Moot Court & Curriculum");
                dt.Rows.Add("5", "American International University-Bangladesh (AIUB)", "LLB", "Professional Training");
                dt.Rows.Add("6", "United International University (UIU)", "LLB", "Practical Legal Focus");
                dt.Rows.Add("7", "Daffodil International University (DIU)", "LLB", "Faculty Expertise");
                dt.Rows.Add("8", "Ahsanullah University of Science & Technology (AUST)", "LLB", "Law & Ethics Programs");
                dt.Rows.Add("9", "Premier University, Chittagong", "LLB", "Legal Research Focus");
                dt.Rows.Add("10", "University of Asia Pacific (UAP)", "LLB", "Curriculum & Internship Programs");
            }
            else if (department == "Civil")
            {
                dt.Rows.Add("1", "Ahsanullah University of Science & Technology (AUST)", "Civil", "Strong Engineering Heritage");
                dt.Rows.Add("2", "BRAC University", "Civil", "Research & Design Focus");
                dt.Rows.Add("3", "East West University (EWU)", "Civil", "Accredited Program");
                dt.Rows.Add("4", "American International University-Bangladesh (AIUB)", "Civil", "Industry-Oriented Curriculum");
                dt.Rows.Add("5", "Daffodil International University (DIU)", "Civil", "Infrastructure & Labs");
                dt.Rows.Add("6", "North South University (NSU)", "Civil", "Academic Excellence");
                dt.Rows.Add("7", "United International University (UIU)", "Civil", "Practical Projects");
                dt.Rows.Add("8", "Independent University, Bangladesh (IUB)", "Civil", "Modern Curriculum");
                dt.Rows.Add("9", "Premier University, Chittagong", "Civil", "Construction Project Focus");
                dt.Rows.Add("10", "University of Asia Pacific (UAP)", "Civil", "Urban Design Programs");
            }
            else if (department == "Architecture")
            {
                dt.Rows.Add("1", "BRAC University", "Architecture", "Design & Research Excellence");
                dt.Rows.Add("2", "Ahsanullah University of Science & Technology (AUST)", "Architecture", "Professional Recognition");
                dt.Rows.Add("3", "Independent University, Bangladesh (IUB)", "Architecture", "Creative Curriculum");
                dt.Rows.Add("4", "Daffodil International University (DIU)", "Architecture", "Modern Facilities");
                dt.Rows.Add("5", "North South University (NSU)", "Architecture", "Studio & Design Focus");
                dt.Rows.Add("6", "East West University (EWU)", "Architecture", "Research & Innovation");
                dt.Rows.Add("7", "United International University (UIU)", "Architecture", "Sustainable Design Programs");
                dt.Rows.Add("8", "American International University-Bangladesh (AIUB)", "Architecture", "Industry Exposure");
                dt.Rows.Add("9", "Premier University, Chittagong", "Architecture", "Emerging Design Programs");
                dt.Rows.Add("10", "University of Asia Pacific (UAP)", "Architecture", "Project & Studio Focus");
            }
            else if (department == "English")
            {
                dt.Rows.Add("1", "BRAC University", "English", "Liberal Arts Excellence");
                dt.Rows.Add("2", "North South University (NSU)", "English", "Academic Reputation");
                dt.Rows.Add("3", "Independent University, Bangladesh (IUB)", "English", "Research & Literature");
                dt.Rows.Add("4", "East West University (EWU)", "English", "Curriculum Strength");
                dt.Rows.Add("5", "American International University-Bangladesh (AIUB)", "English", "Language Programs");
                dt.Rows.Add("6", "United International University (UIU)", "English", "Literary Studies");
                dt.Rows.Add("7", "Daffodil International University (DIU)", "English", "Communication Focus");
                dt.Rows.Add("8", "Ahsanullah University of Science & Technology (AUST)", "English", "Academic Writing & Research");
                dt.Rows.Add("9", "Premier University, Chittagong", "English", "Creative Writing Programs");
                dt.Rows.Add("10", "University of Asia Pacific (UAP)", "English", "Language & Media Studies");
            }
            else if (department == "Pharmacy")
            {
                dt.Rows.Add("1", "BRAC University", "Pharmacy", "Research & Industry Linkage");
                dt.Rows.Add("2", "North South University (NSU)", "Pharmacy", "Academic Reputation");
                dt.Rows.Add("3", "East West University (EWU)", "Pharmacy", "Lab & Research Facilities");
                dt.Rows.Add("4", "Daffodil International University (DIU)", "Pharmacy", "Industry Exposure");
                dt.Rows.Add("5", "Independent University, Bangladesh (IUB)", "Pharmacy", "Clinical & Research Focus");
                dt.Rows.Add("6", "American International University-Bangladesh (AIUB)", "Pharmacy", "Modern Labs");
                dt.Rows.Add("7", "United International University (UIU)", "Pharmacy", "Pharmaceutical Projects");
                dt.Rows.Add("8", "Ahsanullah University of Science & Technology (AUST)", "Pharmacy", "Academic & Research Strength");
                dt.Rows.Add("9", "Premier University, Chittagong", "Pharmacy", "Emerging Pharma Programs");
                dt.Rows.Add("10", "University of Asia Pacific (UAP)", "Pharmacy", "Applied Pharmaceutical Studies");
            }
            else if (department == "Economics")
            {
                dt.Rows.Add("1", "BRAC University", "Economics", "Policy & Research Strength");
                dt.Rows.Add("2", "North South University (NSU)", "Economics", "Academic Reputation");
                dt.Rows.Add("3", "Independent University, Bangladesh (IUB)", "Economics", "Research Focus");
                dt.Rows.Add("4", "East West University (EWU)", "Economics", "Applied Economics");
                dt.Rows.Add("5", "American International University-Bangladesh (AIUB)", "Economics", "Economic Analysis Programs");
                dt.Rows.Add("6", "United International University (UIU)", "Economics", "Development Studies");
                dt.Rows.Add("7", "Daffodil International University (DIU)", "Economics", "Policy & Data Focus");
                dt.Rows.Add("8", "Ahsanullah University of Science & Technology (AUST)", "Economics", "Quantitative & Research Focus");
                dt.Rows.Add("9", "Premier University, Chittagong", "Economics", "Emerging Market Focus");
                dt.Rows.Add("10", "University of Asia Pacific (UAP)", "Economics", "Applied Economic Projects");
            }
            else if (department == "MSJ")
            {
                dt.Rows.Add("1", "BRAC University", "MSJ", "Media & Journalism Reputation");
                dt.Rows.Add("2", "North South University (NSU)", "MSJ", "Academic Excellence");
                dt.Rows.Add("3", "Independent University, Bangladesh (IUB)", "MSJ", "Media Studies Focus");
                dt.Rows.Add("4", "Daffodil International University (DIU)", "MSJ", "Practical Media Training");
                dt.Rows.Add("5", "East West University (EWU)", "MSJ", "Journalism Labs & Projects");
                dt.Rows.Add("6", "United International University (UIU)", "MSJ", "Digital Media Programs");
                dt.Rows.Add("7", "American International University-Bangladesh (AIUB)", "MSJ", "Industry Exposure");
                dt.Rows.Add("8", "Ahsanullah University of Science & Technology (AUST)", "MSJ", "Research & Reporting Focus");
                dt.Rows.Add("9", "Premier University, Chittagong", "MSJ", "Emerging Media Studies");
                dt.Rows.Add("10", "University of Asia Pacific (UAP)", "MSJ", "Project & Internship Focus");
            }
            else
            {
                dt.Rows.Add("-", "Ranking not available", department, "N/A");
            }






            dataGridView1.DataSource = dt;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; dataGridView1.ReadOnly = true; dataGridView1.AllowUserToAddRows = false;

            dataGridView1.Columns["Rank"].FillWeight = 10;
            dataGridView1.Columns["University"].FillWeight = 40;
            dataGridView1.Columns["Department"].FillWeight = 15;
            dataGridView1.Columns["Reputation Basis"].FillWeight = 35;


        }


        private void Form40_Load(object sender, EventArgs e)
        {
            LoadRanking();
        }
    }
}
