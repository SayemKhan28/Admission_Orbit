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
    public partial class Form34 : Form
    {
        public Form34()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
     "Are you sure you want to exit the application?",
     "Confirm Exit",
     MessageBoxButtons.YesNo,
     MessageBoxIcon.Question
);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
