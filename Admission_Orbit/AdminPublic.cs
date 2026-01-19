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
    public partial class AdminPublic : Form
    {
        public AdminPublic()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddUni addUni = new AddUni();
            addUni.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            AllInfo allInfo = new AllInfo();
            allInfo.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            EditPublic editPublic = new EditPublic();
            editPublic.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminDelete adminDelete = new AdminDelete();
            adminDelete.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminPublicPrivate adminPublicPrivate = new AdminPublicPrivate();
            adminPublicPrivate.Show();
        }
    }
}
