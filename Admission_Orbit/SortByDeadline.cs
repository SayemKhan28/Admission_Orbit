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
    public partial class SortByDeadline : Form
    {
        DataTable uniTable;
        public SortByDeadline()
        {
            InitializeComponent();
            dgvUniversities.CellContentClick += dgvUniversities_CellContentClick;

            dgvUniversities.AutoGenerateColumns = false;
            LoadUniversityData();
        }
        private void LoadUniversityData()
        {
            try
            {
                string cs = @"Data Source=SAYEM\SQLEXPRESS; Database=master; Integrated Security=SSPI";

                using (SqlConnection con = new SqlConnection(cs))
                {
                    con.Open();

                   
                    string query = "SELECT [University Name], [Application Ending Date] FROM dbo.Public_Uni";
                    ;

                    SqlDataAdapter da = new SqlDataAdapter(query, con);
                    uniTable = new DataTable();
                    da.Fill(uniTable);

                    if (uniTable.Rows.Count == 0)
                    {
                        MessageBox.Show("No universities found in database!");
                        return;
                    }

                   
                    DataView dv = uniTable.DefaultView;
                    dv.Sort = "[Application Ending Date] ASC";

                    dgvUniversities.DataSource = dv;

                    MakeUniversityColumnClickable();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading university data: " + ex.Message);
            }
        }

        private void MakeUniversityColumnClickable()
        {
            dgvUniversities.Columns.Clear();

            DataGridViewLinkColumn nameCol = new DataGridViewLinkColumn();
            nameCol.Name = "UniversityName";
            nameCol.HeaderText = "University Name";
            nameCol.DataPropertyName = "University Name";
            nameCol.LinkBehavior = LinkBehavior.HoverUnderline;

            nameCol.LinkColor = Color.Black;
            nameCol.VisitedLinkColor = Color.Black;
            nameCol.ActiveLinkColor = Color.Gray;

            DataGridViewTextBoxColumn dateCol = new DataGridViewTextBoxColumn();
            dateCol.Name = "AdmissionDate";
            dateCol.HeaderText = "Admission Ending Date";
            dateCol.DataPropertyName = "Application Ending Date";
            dateCol.DefaultCellStyle.Format = "dd MMM yyyy";


            dgvUniversities.Columns.Add(nameCol);
            dgvUniversities.Columns.Add(dateCol);
           


            dgvUniversities.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void dgvUniversities_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (dgvUniversities.Columns[e.ColumnIndex].Name == "UniversityName")
            {
                string uniName = dgvUniversities.Rows[e.RowIndex].Cells["UniversityName"].Value.ToString();
                OpenUniversityForm(uniName);
            }
        }

        private void OpenUniversityForm(string uniName)
        {
            this.Hide();
            uniName = uniName.Trim();


            if (uniName.Contains("BUET"))
            {
                new Buet().Show();
            }
            else if (uniName == "Dhaka University")
            {
                new DU().Show();
            }
            else if (uniName == "CKRUET")
            {
                new CKRUET().Show();
            }
            else if (uniName.Contains("BUP"))
            {
                new Bup().Show();
            }
            else if (uniName.Contains("Jahangirnagar"))
            {
                new JU().Show();
            }
            else if (uniName.Contains("Chittagong"))
            {
                new CU().Show();
            }
            else if (uniName.Contains("MIST"))
            {
                new Mist().Show();
            }
            else if (uniName.Contains("GST"))
            {
                new Gst().Show();
            }
            else if (uniName.Contains("Rajshahi"))
            {
                new Rajshahi().Show();
            }
        }

        private void SortByDeadline_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            publicPrivate publicPrivate = new publicPrivate();
            publicPrivate.Show();
        }
    }
}
