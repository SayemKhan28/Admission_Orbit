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
    public partial class publicPrivate : Form
    {
        DataTable dtUniversities = new DataTable();
        public publicPrivate()
        {
            InitializeComponent();

        }

        private void buet_Click(object sender, EventArgs e)
        {
            this.Hide();
            Buet buet = new Buet();
            buet.Show();
        }

        private void DU_Click(object sender, EventArgs e)
        {
            this.Hide();
            DU du = new DU();
            du.Show();
        }

        private void Bup_Click(object sender, EventArgs e)
        {
            this.Hide();
            Bup bup = new Bup();
            bup.Show();
        }

        private void CKRUET_Click(object sender, EventArgs e)
        {
            this.Hide();
            CKRUET ckruet = new CKRUET();
            ckruet.Show();
        }

        private void Rajshahi_Click(object sender, EventArgs e)
        {
            this.Hide();
            Rajshahi raj = new Rajshahi();
            raj.Show();
        }

        private void Mist_Click(object sender, EventArgs e)
        {
            this.Hide();
            Mist mist = new Mist();
            mist.Show();
        }

        private void JU_Click(object sender, EventArgs e)
        {
            this.Hide();
            JU ju = new JU();
            ju.Show();
        }

        private void CU_Click(object sender, EventArgs e)
        {
            this.Hide();
            CU cu = new CU();
            cu.Show();
        }

        private void Gst_Click(object sender, EventArgs e)
        {
            this.Hide();
            Gst gst = new Gst();
            gst.Show();
        }

        private void cmbSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSort.SelectedItem == null) return;

            this.Hide();

            if (cmbSort.SelectedItem.ToString() == "Admission Date")
            {
                SortByAdd frm = new SortByAdd();
                frm.Show();
            }
            else if (cmbSort.SelectedItem.ToString() == "District")
            {
                SortByDist frm2 = new SortByDist();
                frm2.Show();
            }
            else if (cmbSort.SelectedItem.ToString() == "Admission Deadline")
            {
                SortByDeadline frm3 = new SortByDeadline();
                frm3.Show();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form7 f7=new Form7();
            f7.Show();
        }
       

        private void publicPrivate_Load(object sender, EventArgs e)
        {

        }
    }
}
