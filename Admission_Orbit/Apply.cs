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
    public partial class Apply : Form
    {
        public Apply()
        {
            InitializeComponent();
        }

        private void Apply_Load(object sender, EventArgs e)
        {
            cmbUniversities.Items.Clear();
            cmbUniversities.Items.Add("BUET");
            cmbUniversities.Items.Add("Dhaka University");
            cmbUniversities.Items.Add("CKRUET");
            cmbUniversities.Items.Add("BUP");
            cmbUniversities.Items.Add("Jahangirnagar University");
            cmbUniversities.Items.Add("University of Chittagong");
            cmbUniversities.Items.Add("MIST");
            cmbUniversities.Items.Add("GST");
            cmbUniversities.Items.Add("Rajshahi University");

            //   cmbUniversities.SelectedIndex = 0; 
        }

        private double GetAdmissionFee(string uni)
        {
            switch (uni)
            {
                case "BUET": return 1000;
                case "Dhaka University": return 750;
                case "CKRUET": return 800;
                case "BUP": return 700;
                case "Jahangirnagar University": return 750;
                case "University of Chittagong": return 900;
                case "MIST": return 850;
                case "GST": return 800;
                case "Rajshahi University": return 780;
                default: return 0;
            }
        }

        private void bkash_Click(object sender, EventArgs e)
        {
            SendPaymentEmail("Bkash");
        }

        private void credit_Click(object sender, EventArgs e)
        {
            SendPaymentEmail("Credit Card");
        }

        private void SendPaymentEmail(string method)
        {
            try
            {
                string selectedUni = cmbUniversities.SelectedItem.ToString();
                double fee = GetAdmissionFee(selectedUni);

                EmailHelper.SendEmail(
                    UserSession.Email,
                    "Application Fee Paid",
                    $"University: {selectedUni}\nFee: {fee} TK\nPayment Method: {method}\nPayment Successful"
                );

                MessageBox.Show($"{method} Payment Successful! Confirmation email sent.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Email sending failed: " + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            publicPrivate publicPrivate = new publicPrivate();
            publicPrivate = new publicPrivate();

        }
    }
}
