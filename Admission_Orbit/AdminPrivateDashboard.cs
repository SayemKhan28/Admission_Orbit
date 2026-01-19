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
    public partial class AdminPrivateDashboard : Form
    {
        public AdminPrivateDashboard()
        {
            InitializeComponent();
        }

        private void AdminPrivateDashboard_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddPrivateUni addPrivateUni = new AddPrivateUni();
            addPrivateUni.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminPrivateView adminPrivateView = new AdminPrivateView();
            adminPrivateView.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminPrivateDelete adminPrivateDelete = new AdminPrivateDelete();
            adminPrivateDelete.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminPrivateModify adminPrivateModify = new AdminPrivateModify();
            adminPrivateModify.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminPublicPrivate adminPublicPrivate= new AdminPublicPrivate();
            adminPublicPrivate.Show();
        }
    }
}
