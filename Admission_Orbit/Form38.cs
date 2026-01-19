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
    public partial class Form38 : Form
    {
        public Form38()
        {
            InitializeComponent();
            textBox2.PasswordChar = '*';
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string adminUser = "admin";
            string adminPass = "1234";

            if (textBox1.Text == adminUser && textBox2.Text == adminPass)
            {
                MessageBox.Show("Login Successful!", "Admin",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                
                
                this.Hide();
                AdminPublicPrivate adminPublicPrivate = new AdminPublicPrivate();
                adminPublicPrivate.Show();
                
            }
            else
            {
                MessageBox.Show("Invalid Username or Password!",
                    "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
    }

