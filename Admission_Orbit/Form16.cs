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
    public partial class Form16 : Form
    {
        DataTable scholarshipTable;
        public Form16(DataTable normalTable, DataTable scholarshipTableInput)
        {
            InitializeComponent();

            dataGridView2.DataSource = normalTable;

            scholarshipTable = scholarshipTableInput;
            dataGridView3.DataSource = scholarshipTable;
        }

        private void CalculateScholarship(int percent)
        {
            scholarshipTable.Rows.Clear();
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                if (row.IsNewRow) continue;
                string university = row.Cells["University Name"].Value.ToString();
                string departments = row.Cells["Departments"].Value.ToString();
                foreach (string dept in departments.Split(','))
                {
                    if (string.IsNullOrWhiteSpace(dept)) continue;
                    decimal tuitionFee = GetTuitionFee(university, dept.Trim());
                    decimal otherExpenses = 20000;
                    decimal totalExpense = tuitionFee + otherExpenses; scholarshipTable.Rows.Add(university, dept.Trim(), "0%", tuitionFee, tuitionFee, otherExpenses, totalExpense);
                }
                string[] allDepartments = { "CSE", "EEE", "BBA", "LLB", "Pharmacy", "Architecture", "CE", "MSJ", "Economics", "English" };
                foreach (string dept in allDepartments)
                {
                    if (departments.Split(',').Any(d => d.Trim() == dept)) continue;
                    decimal tuitionFee = GetTuitionFee(university, dept); decimal discountedFee = tuitionFee - (tuitionFee * percent / 100);
                    decimal otherExpenses = 20000;
                    decimal totalExpense = discountedFee + otherExpenses; if (discountedFee + otherExpenses <= 500000)
                    {
                        scholarshipTable.Rows.Add(university, dept, percent + "%", tuitionFee, discountedFee, otherExpenses, totalExpense);
                    }
                }
            }
        }






        private decimal GetTuitionFee(string university, string department)
        {
            
            return 500000; 
        }

       
        private void Form16_Load(object sender, EventArgs e)
        {
            decimal budget = 500000; 
            CalculateScholarship(20);
           
        }

        

        

        

      


        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form8 f8 = new Form8();
            f8.Show();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            string universityName = dataGridView2.Rows[e.RowIndex].Cells["University Name"].Value.ToString();
            
            Form nextForm = null;
            if (universityName == "BRAC University                                   ")
            {
                nextForm = new Form11();
            }
            else if (universityName == "American International University-Bangladesh      ")
            {
                nextForm = new Form10();
            }
            else if (universityName == "North South University (NSU)                      ")
            {
                nextForm = new Form12();
            }
            else if (universityName == "United International University (UIU)             ")
            {
                nextForm = new Form13();
            }
            else if (universityName == "Ahsanullah University Of Science and Technology   ")
            {
                nextForm = new Form15();
            }
            else if (universityName == "Independent University, Bangladesh (IUB)          ")
            {
                nextForm = new Form17();
            }
            else if (universityName == "Daffodil International University (DIU)           ")
            {
                nextForm = new Form18();
            }
            else if (universityName == "East West University (EWU)                        ")
            {
                nextForm = new Form20();
            }
            else if (universityName == "South East University (SEU)                       ")
            {
                nextForm = new Form21();
            }
            else if (universityName == "University of Liberal Arts Bangladesh (ULAB)      ")
            {
                nextForm = new Form14();
            }
            else if (universityName == "Northern University Bangladesh (NUB)              ")
            {
                nextForm = new Form36();
            }
            else if (universityName == "Premier University                                ")
            {
                nextForm = new Form37();
            }
            else {
                MessageBox.Show("No details form available for this university.");
                return;
            }
            nextForm.Show(); 
            this.Hide();
        }

        private void Form16_Load_1(object sender, EventArgs e)
        {
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            string universityName = dataGridView2.Rows[e.RowIndex].Cells["University Name"].Value.ToString();
            Form nextForm = null;
            if (universityName == "BRAC University                                   ")
            {
                nextForm = new Form23();
            }
            else if (universityName == "American International University-Bangladesh      ")
            {
                nextForm = new Form22();
            }
            else if (universityName == "North South University (NSU)                      ")
            {
                nextForm = new Form24();
            }
            else if (universityName == "United International University (UIU)             ")
            {
                nextForm = new Form25();
            }
            else if (universityName == "Ahsanullah University Of Science and Technology   ")
            {
                nextForm = new Form30();
            }
            else if (universityName == "Independent University, Bangladesh (IUB)          ")
            {
                nextForm = new Form28();
            }
            else if (universityName == "Daffodil International University (DIU)           ")
            {
                nextForm = new Form27();
            }
            else if (universityName == "East West University (EWU)                        ")
            {
                nextForm = new Form26();
            }
            else if (universityName == "South East University (SEU)                       ")
            {
                nextForm = new Form31();
            }
            else if (universityName == "University of Liberal Arts Bangladesh (ULAB)      ")
            {
                nextForm = new Form35();
            }
            else if (universityName == "Northern University Bangladesh (NUB)              ")
            {
                nextForm = new Form32();
            }
            else if (universityName == "Premier University                                ")
            {
                nextForm = new Form33();
            }
            else
            {
                MessageBox.Show("No details form available for this university.");
                return;
            }
            nextForm.Show(); this.Hide();


        }

    }
    }

