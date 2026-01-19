using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Admission_Orbit
{
    public partial class Form8 : Form
    {

        string connectionString = "data source=SAYEM\\SQLEXPRESS; database=master; integrated security=SSPI";
        Dictionary<string, (double lat, double lng)> areaCoordinates;



       
       


        public Form8()
        {
            InitializeComponent();
            areaCoordinates = new Dictionary<string, (double lat, double lng)>
{
     { "Mohammadpur", (23.7620, 90.3650) },
    { "Dhanmondi", (23.7385, 90.3747) },
    { "Hazaribagh", (23.7310, 90.4025) },
    { "Mirpur", (23.82235, 90.36542) },    
    { "Pallabi", (23.8400, 90.3660) },
    { "Rupnagar", (23.8215, 90.3685) },
    { "Kazipara", (23.8115, 90.3660) },
    { "Shewrapara", (23.8085, 90.3700) },
    { "Agargaon", (23.7590, 90.3820) },
    { "Motijheel", (23.7375, 90.4140) },
    { "Paltan", (23.7370, 90.4080) },
    { "Kakrail", (23.7390, 90.4065) },
    { "Shahbagh", (23.7403, 90.3917) },
    { "Farmgate", (23.7517, 90.3918) },
    { "Tejgaon", (23.7625, 90.3996) },
    { "Uttara", (23.8738, 90.3975) },
    { "Airport", (23.8443, 90.3978) },
    { "Gulshan", (23.7810, 90.4194) },
    { "Banani", (23.7930, 90.4058) },
    { "Mohakhali", (23.7896, 90.4102) },
    { "Old Dhaka", (23.7170, 90.4070) },
    { "Wari", (23.7208, 90.3977) },
    { "Sadarghat", (23.7102, 90.4015) },
    { "Bangshal", (23.7198, 90.4140) }
};

        }



        private void button9_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form9 f9 = new Form9();
            f9.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form10 f10 = new Form10();
            f10.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form11 f11 = new Form11();
            f11.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form12 f12 = new Form12();
            f12.Show();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form18 f18 = new Form18();
            f18.Show();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form13 f13 = new Form13();
            f13.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form20 f20 = new Form20();
            f20.Show();

        }

        private void Form8_Load(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
        }
       

        private DataTable GetTable(string query, decimal budget, string cs)
        {
            DataTable table = new DataTable();
            table.Columns.Add("University Name");
            table.Columns.Add("Departments");

            using (SqlConnection con = new SqlConnection(cs))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@Budget", budget);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string uni = reader["University Name"].ToString();
                    string dept = "";


                    string[] cols = { "CSE", "EEE", "BBA", "LLB", "Pharmacy", "Architecture", "CE", "MSJ", "Economics" };
                    foreach (string c in cols)
                        if (!reader.IsDBNull(reader.GetOrdinal(c)))
                            dept += reader[c] + ", ";

                    if (dept.Length > 2)
                        dept = dept.Substring(0, dept.Length - 2);

                    table.Rows.Add(uni, dept);
                }
            }
            return table;
        }



        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form21 f21 = new Form21();
            f21.Show();
        }
        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form15 f15 = new Form15();
            f15.Show();
        }

        private void button11_Click_1(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Please select a sort option.");
                return;
            }

            string selectedSort = comboBox1.SelectedItem.ToString();
            string query = "";

            if (selectedSort == "Application Ending Date Wise")
            {
                query = @"
        SELECT [University Name], [Application Ending Date]
        FROM Modified
        WHERE [Application Ending Date] IS NOT NULL
        ORDER BY [Application Ending Date] ASC";
            }
            else if (selectedSort == "Exam Date Wise")
            {
                query = @"
        SELECT [University Name], [Exam Date]
        FROM Modified
        WHERE [Exam Date] IS NOT NULL
        ORDER BY [Exam Date] ASC";
            }
            else if (selectedSort == "Result Date Wise")
            {
                query = @"
        SELECT [University Name], [Result Date]
        FROM Modified
        WHERE [Result Date] IS NOT NULL
        ORDER BY [Result Date] ASC";
            }
            else
            {
                MessageBox.Show("Invalid sort option.");
                return;
            }

            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, con))
            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
            {
                con.Open();
                da.Fill(dt);
            }


            Form19 f19 = new Form19(dt, selectedSort);
            f19.Show();
            this.Hide();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            string selectedArea = comboBox2.Text;

            if (!areaCoordinates.ContainsKey(selectedArea))
            {
                MessageBox.Show("Please select a valid location");
                return;
            }

            var userLocation = areaCoordinates[selectedArea];
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = @" SELECT [University Name], Location, ROUND( (6371 * ACOS( COS(RADIANS(@lat)) * COS(RADIANS(Latitude)) * COS(RADIANS(Longitude) - RADIANS(@lng)) + SIN(RADIANS(@lat)) * SIN(RADIANS(Latitude)) )), 2)* 1.45 AS Approximate_DistanceKm FROM Modified WHERE Latitude IS NOT NULL ORDER BY Approximate_DistanceKm ASC";



                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.Add("@lat", SqlDbType.Float).Value = userLocation.lat;
                cmd.Parameters.Add("@lng", SqlDbType.Float).Value = userLocation.lng;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }


            Form19 f19 = new Form19(dt);
            f19.Show();
            this.Hide();
        }

        private void button10_Click_1(object sender, EventArgs e)
        {
            try
            {
                decimal budget = decimal.Parse(textBox1.Text);
                string cs = "data source=SAYEM\\SQLEXPRESS; database=master; integrated security=SSPI";

                string queryNormal = @"SELECT [University Name],
       CASE WHEN [CSE(T.E)] > 0 AND [CSE(T.E)] <= @Budget THEN 'CSE' END AS CSE,
       CASE WHEN [EEE(T.E)] > 0 AND [EEE(T.E)] <= @Budget THEN 'EEE' END AS EEE,
       CASE WHEN [BBA(T.E)] > 0 AND [BBA(T.E)] <= @Budget THEN 'BBA' END AS BBA,
       CASE WHEN [LLB(T.E)] > 0 AND [LLB(T.E)] <= @Budget THEN 'LLB' END AS LLB,
       CASE WHEN [Pharmacy(T.E)] > 0 AND [Pharmacy(T.E)] <= @Budget THEN 'Pharmacy' END AS Pharmacy,
       CASE WHEN [Architecture(T.E)] > 0 AND [Architecture(T.E)] <= @Budget THEN 'Architecture' END AS Architecture,
       CASE WHEN [CE(T.E)] > 0 AND [CE(T.E)] <= @Budget THEN 'Civil Engineering' END AS CE,
       CASE WHEN [MSJ(T.E)] > 0 AND [MSJ(T.E)] <= @Budget THEN 'Media/English' END AS MSJ,
       CASE WHEN [Economics(T.E)] > 0 AND [Economics(T.E)] <= @Budget THEN 'Economics' END AS Economics
FROM Modified
WHERE ([CSE(T.E)] <= @Budget OR [EEE(T.E)] <= @Budget OR [BBA(T.E)] <= @Budget
       OR [LLB(T.E)] <= @Budget OR [Pharmacy(T.E)] <= @Budget OR [Architecture(T.E)] <= @Budget
       OR [CE(T.E)] <= @Budget OR [MSJ(T.E)] <= @Budget OR [Economics(T.E)] <= @Budget)";

                DataTable normalTable = GetTable(queryNormal, budget, cs);
                string queryScholarship = @"SELECT [University Name],
       CASE WHEN [CSE(T.E)] > 0 AND ([CSE(T.E)] * 0.80) <= @Budget THEN 'CSE' END AS CSE,
       CASE WHEN [EEE(T.E)] > 0 AND ([EEE(T.E)] * 0.80) <= @Budget THEN 'EEE' END AS EEE,
       CASE WHEN [BBA(T.E)] > 0 AND ([BBA(T.E)] * 0.80) <= @Budget THEN 'BBA' END AS BBA,
       CASE WHEN [LLB(T.E)] > 0 AND ([LLB(T.E)] * 0.80) <= @Budget THEN 'LLB' END AS LLB,
       CASE WHEN [Pharmacy(T.E)] > 0 AND ([Pharmacy(T.E)] * 0.80) <= @Budget THEN 'Pharmacy' END AS Pharmacy,
       CASE WHEN [Architecture(T.E)] > 0 AND ([Architecture(T.E)] * 0.80) <= @Budget THEN 'Architecture' END AS Architecture,
       CASE WHEN [CE(T.E)] > 0 AND ([CE(T.E)] * 0.80) <= @Budget THEN 'Civil Engineering' END AS CE,
       CASE WHEN [MSJ(T.E)] > 0 AND ([MSJ(T.E)] * 0.80) <= @Budget THEN 'Media/English' END AS MSJ,
       CASE WHEN [Economics(T.E)] > 0 AND ([Economics(T.E)] * 0.80) <= @Budget THEN 'Economics' END AS Economics
FROM Modified
WHERE
(
    ([CSE(T.E)] > 0 AND ([CSE(T.E)] * 0.80) <= @Budget) OR
    ([EEE(T.E)] > 0 AND ([EEE(T.E)] * 0.80) <= @Budget) OR
    ([BBA(T.E)] > 0 AND ([BBA(T.E)] * 0.80) <= @Budget) OR
    ([LLB(T.E)] > 0 AND ([LLB(T.E)] * 0.80) <= @Budget) OR
    ([Pharmacy(T.E)] > 0 AND ([Pharmacy(T.E)] * 0.80) <= @Budget) OR
    ([Architecture(T.E)] > 0 AND ([Architecture(T.E)] * 0.80) <= @Budget) OR
    ([CE(T.E)] > 0 AND ([CE(T.E)] * 0.80) <= @Budget) OR
    ([MSJ(T.E)] > 0 AND ([MSJ(T.E)] * 0.80) <= @Budget) OR
    ([Economics(T.E)] > 0 AND ([Economics(T.E)] * 0.80) <= @Budget)
             );  "  ;

                DataTable scholarshipTable = GetTable(queryScholarship, budget, cs);


                Form16 f16 = new Form16(normalTable, scholarshipTable);
                f16.Show();
                this.Hide();
            }
            catch
            {
                MessageBox.Show("Please enter a valid budget.");
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (comboBox3.SelectedItem == null)
            {
                MessageBox.Show("Please select a department");
                return;
            }

            string department = comboBox3.SelectedItem.ToString();

            this.Hide();
            Form40 f40 = new Form40(department);
            f40.Show();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form7 form7 = new Form7();
            form7.Show();
        }
    }
    }

    
            
           


           
        
    












