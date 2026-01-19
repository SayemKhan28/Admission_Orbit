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
    public partial class AdminPublicPrivate : Form
    {
        public AdminPublicPrivate()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminPublic adminPublic=new AdminPublic();
            adminPublic.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            DeleteUserAccount deleteUserAccount = new DeleteUserAccount();  
            deleteUserAccount.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminPrivateDashboard adminPrivateDashboard = new AdminPrivateDashboard();
            adminPrivateDashboard.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 f2=new Form2();
            f2.Show();
        }
    }
}
