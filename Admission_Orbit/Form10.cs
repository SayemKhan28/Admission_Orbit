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
    public partial class Form10 : Form
    {
        

        public Form10()
        {
            InitializeComponent();
        }
        public Form10(string sscGpa)
        {
            InitializeComponent();
            
            

        }

        private void Form10_Load(object sender, EventArgs e)
        {
            
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            
            Form8 f8 = new Form8();
            f8.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form34 f34 = new Form34();
            f34.Show();
        }
    }
}
