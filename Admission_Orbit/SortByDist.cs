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
    public partial class SortByDist : Form
    {
        DataTable uniTable;
        public SortByDist()
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

                    // Fetch all universities with district
                    string query = "SELECT [University Name], [District] FROM dbo.Public_Uni";
                    SqlDataAdapter da = new SqlDataAdapter(query, con);
                    uniTable = new DataTable();
                    da.Fill(uniTable);

                    if (uniTable.Rows.Count == 0)
                    {
                        MessageBox.Show("No universities found in database!");
                        return;
                    }

                    // Sort by District ascending
                    DataView dv = uniTable.DefaultView;
                    dv.Sort = "[District] ASC";

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
            nameCol.VisitedLinkColor = Color.Blue;
            nameCol.ActiveLinkColor = Color.Gray;


            DataGridViewTextBoxColumn districtCol = new DataGridViewTextBoxColumn();
            districtCol.Name = "District";
            districtCol.HeaderText = "District";
            districtCol.DataPropertyName = "District";

            dgvUniversities.Columns.Add(nameCol);
            dgvUniversities.Columns.Add(districtCol);

            dgvUniversities.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void SortByDist_Load(object sender, EventArgs e)
        {

        }
        private void dgvUniversities_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (dgvUniversities.Columns[e.ColumnIndex].Name == "UniversityName")
            {
                string uniName = dgvUniversities.Rows[e.RowIndex].Cells["UniversityName"].Value.ToString().Trim();
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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            publicPrivate ps = new publicPrivate();
            ps.Show();
        }
    }
}
