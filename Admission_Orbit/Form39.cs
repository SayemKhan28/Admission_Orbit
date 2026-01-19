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
using System.Xml.Linq;

namespace Admission_Orbit
{
    public partial class Form39 : Form
    {
        string cs = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=master;Integrated Security=True";

        public Form39()
        {
            InitializeComponent();
        }
        private void LoadParticipants()
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlDataAdapter da =
                    new SqlDataAdapter("SELECT * FROM Registration", con);

                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }

            dataGridView1.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void Form39_Load(object sender, EventArgs e)
        {
            LoadParticipants();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand(
                @"INSERT INTO Registration
          (Name, SSC_GPA, HSC_GPA, Email, Password)
          VALUES (@n,@ssc,@hsc,@e,@p)", con);

                cmd.Parameters.AddWithValue("@n", textBox1.Text);
                cmd.Parameters.AddWithValue("@ssc", Convert.ToDouble(textBox2.Text));
                cmd.Parameters.AddWithValue("@hsc", Convert.ToDouble(textBox3.Text));
                cmd.Parameters.AddWithValue("@e", textBox4.Text);
                cmd.Parameters.AddWithValue("@p", textBox5.Text);

                con.Open();
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Participant added successfully.");
            LoadParticipants();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a participant to delete.");
                return;
            }

            string email =
                dataGridView1.SelectedRows[0].Cells["Email"].Value.ToString();

            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete this participant?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                using (SqlConnection con = new SqlConnection(cs))
                {
                    SqlCommand cmd = new SqlCommand(
                        "DELETE FROM Registration WHERE Email = @e", con);

                    cmd.Parameters.AddWithValue("@e", email);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Participant deleted successfully.");
                LoadParticipants();
            }
        }
    }
}

