using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Collections.Specialized.BitVector32;

namespace Admission_Orbit
{

   
    public partial class Form19 : Form
    {
        int ALERT_DAYS = 7;
        public Form19()
        {
            InitializeComponent();
        }


        bool IsNear(DateTime? date)
        {
            if (date == null) return false;

            double days = (date.Value.Date - DateTime.Today).TotalDays;
            return days >= 0 && days <= ALERT_DAYS;
        }
        void SendEmail(string toEmail, string subject, string body)
        {
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("raihankhan0191457697@gmail.com");
            mail.To.Add(toEmail);
            mail.Subject = subject;
            mail.Body = body;

            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.Credentials = new NetworkCredential(
                "raihankhan0191457697@gmail.com",
                "rytm buwb xstf yygb"
            );
            smtp.EnableSsl = true;

            smtp.Send(mail);
        }
        public Form19(DataTable table)
        {
            InitializeComponent();
            dataGridView1.DataSource = table;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        public Form19(DataTable dt, string title)
        {
            InitializeComponent();
            label1.Text = title;
            dataGridView1.DataSource = dt;

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ReadOnly = true;
            
        }

        private void Form19_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form8 f8 = new Form8();
            f8.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string cs = "data source=SAYEM\\SQLEXPRESS; database=master; integrated security=SSPI";
            string message = "";

            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();

                string q = @"
        SELECT [University Name],
               [Application Ending Date],
               [Exam Date],
               [Result Date]
        FROM Modified";

                SqlCommand cmd = new SqlCommand(q, con);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    string uni = dr["University Name"].ToString();

                    DateTime? appEnd = dr["Application Ending Date"] as DateTime?;
                    DateTime? exam = dr["Exam Date"] as DateTime?;
                    DateTime? result = dr["Result Date"] as DateTime?;

                    if (IsNear(appEnd))
                        message += $" {uni} Application deadline: {appEnd:dd-MMM-yyyy}";

                    if (IsNear(exam))
                        message += $" {uni} Exam date: {exam:dd-MMM-yyyy}";

                    if (IsNear(result))
                        message += $" {uni} Result date: {result:dd-MMM-yyyy}";
                }
            }

            if (string.IsNullOrEmpty(message))
            {
                MessageBox.Show("No upcoming deadlines within next 5 days");
                return;
            }
            if (string.IsNullOrEmpty(Session.CurrentUserEmail))
            {
                MessageBox.Show("User email not found. Please login again.");
                return;
            }

            SendEmail(
                Session.CurrentUserEmail.Trim(),
                "University Admission Deadline Alert",
                message
            );

            MessageBox.Show("Email notification sent successfully!");
        }
    }
    public static class Session
    {
        public static string CurrentUserEmail;
    }
}
