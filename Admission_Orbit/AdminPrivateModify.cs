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

namespace Admission_Orbit
{
    public partial class AdminPrivateModify : Form
    {
        public AdminPrivateModify()
        {
            InitializeComponent();
            checkedListBox1.CheckOnClick = true;
        }
        void BindGridView()
        {
            string connectionString = "Data Source= SAYEM\\SQLEXPRESS; database=master; integrated security=SSPI";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Modified";
                using (SqlDataAdapter sda = new SqlDataAdapter(query, connection))
                {
                    DataTable data = new DataTable();
                    sda.Fill(data);
                    dataGridView1.DataSource = data;
                }
            }
        }

        private void AdminPrivateModify_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminPrivateDashboard adminPrivateDashboard = new AdminPrivateDashboard();
            adminPrivateDashboard.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            BindGridView();
        }
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            DataGridViewRow row = dataGridView1.SelectedRows[0];
            textBox1.Text = row.Cells[0].Value.ToString();
            textBox2.Text = row.Cells[1].Value.ToString();
            textBox3.Text = row.Cells[2].Value.ToString();
            textBox4.Text = row.Cells[3].Value.ToString();
            textBox5.Text = row.Cells[4].Value.ToString();
            textBox6.Text = row.Cells[5].Value.ToString();
            textBox7.Text = row.Cells[6].Value.ToString();
            textBox8.Text = row.Cells[7].Value.ToString();
            textBox9.Text = row.Cells[8].Value.ToString();
            textBox10.Text = row.Cells[9].Value.ToString();
            textBox11.Text = row.Cells[10].Value.ToString();
            textBox12.Text = row.Cells[11].Value.ToString();
            textBox13.Text = row.Cells[12].Value.ToString();
            textBox14.Text = row.Cells[13].Value.ToString();
            textBox15.Text = row.Cells[14].Value.ToString();
            textBox16.Text = row.Cells[15].Value.ToString();
            textBox17.Text = row.Cells[16].Value.ToString();
            textBox18.Text = row.Cells[17].Value.ToString();
            textBox19.Text = row.Cells[18].Value.ToString();
            textBox20.Text = row.Cells[19].Value.ToString();
            textBox21.Text = row.Cells[20].Value.ToString();
            textBox22.Text = row.Cells[21].Value.ToString();
            textBox23.Text = row.Cells[22].Value.ToString();
            textBox24.Text = row.Cells[23].Value.ToString();
            textBox25.Text = row.Cells[24].Value.ToString();
            textBox26.Text = row.Cells[25].Value.ToString();
            textBox27.Text = row.Cells[26].Value.ToString();
            textBox28.Text = row.Cells[27].Value.ToString();
            textBox29.Text = row.Cells[28].Value.ToString();
            textBox30.Text = row.Cells[29].Value.ToString();
            textBox31.Text = row.Cells[30].Value.ToString();
            textBox32.Text = row.Cells[31].Value.ToString();
            textBox33.Text = row.Cells[32].Value.ToString();
            textBox34.Text = row.Cells[33].Value.ToString();
            textBox35.Text = row.Cells[34].Value.ToString();
            textBox36.Text = row.Cells[35].Value.ToString();
            textBox37.Text = row.Cells[36].Value.ToString();
            textBox38.Text = row.Cells[37].Value.ToString();
            textBox39.Text = row.Cells[38].Value.ToString();

            ClearCheckedList(checkedListBox1);
            SetCheckedItems(checkedListBox1, row.Cells[39].Value.ToString());

            textBox40.Text = row.Cells[40].Value.ToString();
            textBox41.Text = row.Cells[41].Value.ToString();
            textBox42.Text = row.Cells[42].Value.ToString();
            textBox43.Text = row.Cells[43].Value.ToString();
            textBox44.Text = row.Cells[44].Value.ToString();



        }
        private void ClearCheckedList(CheckedListBox clb)
        {
            for (int i = 0; i < clb.Items.Count; i++)
            {
                clb.SetItemChecked(i, false);
            }
        }
        private void SetCheckedItems(CheckedListBox clb, string dbValue)
        {
            if (string.IsNullOrEmpty(dbValue))
                return;
            string[] values = dbValue.Split(',');
            for (int i = 0; i < clb.Items.Count; i++)
            {
                foreach (string val in values)
                {

                    if (clb.Items[i].ToString().Trim() == val.Trim())
                    {
                        clb.SetItemChecked(i, true);
                    }


                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
                  

            string connectionString = "Data Source= SAYEM\\SQLEXPRESS; database=master; integrated security=SSPI";

            string uniName = textBox1.Text.Trim();

            string applicationStD = textBox2.Text.Trim();

            string applicationEnD = textBox3.Text.Trim();

            string examDate = textBox4.Text.Trim();

            string resultDate = textBox5.Text.Trim();

            string sscRequirement = textBox6.Text.Trim();

            string hscRequirement = textBox7.Text.Trim();

            string applicationFees = textBox8.Text.Trim();

            string faculties = textBox9.Text.Trim();

            string cse = textBox10.Text.Trim();

            string eee = textBox11.Text.Trim();

            string architecture = textBox12.Text.Trim();

            string bba = textBox13.Text.Trim();

            string english = textBox14.Text.Trim();

            string economics = textBox15.Text.Trim();

            string pharmacy = textBox16.Text.Trim();

            string llb = textBox17.Text.Trim();

            string ce = textBox18.Text.Trim();

            string msj = textBox19.Text.Trim();

            string cseOe = textBox20.Text.Trim();

            string eeeOe = textBox21.Text.Trim();

            string architectureOe = textBox22.Text.Trim();

            string bbaOe = textBox23.Text.Trim();

            string englishOe = textBox24.Text.Trim();

            string economicsOe = textBox25.Text.Trim();

            string pharmacyOe = textBox26.Text.Trim();

            string llbOe = textBox27.Text.Trim();

            string ceOe = textBox28.Text.Trim();

            string msjOe = textBox29.Text.Trim();

            string cseTe = textBox30.Text.Trim();

            string eeeTe = textBox31.Text.Trim();

            string architectureTe = textBox32.Text.Trim();

            string bbaTe = textBox33.Text.Trim();

            string englishTe = textBox34.Text.Trim();

            string economicsTe = textBox35.Text.Trim();

            string pharmacyTe = textBox36.Text.Trim();

            string llbTe = textBox37.Text.Trim();

            string ceTe = textBox38.Text.Trim();

            string msjTe = textBox39.Text.Trim();

            string scholarship = textBox40.Text.Trim();

            string otherInfo = textBox41.Text.Trim();

            string location = textBox42.Text.Trim();

            string latitude = textBox43.Text.Trim();

            string longitude = textBox44.Text.Trim();


            if (checkedListBox1.CheckedItems.Count == 0)

            {

                MessageBox.Show("No Option Selected");

                return;

            }

            string examFormat = "";

            foreach (var item in checkedListBox1.CheckedItems)

            {

                examFormat += item.ToString() + ",";

            }

            MessageBox.Show(examFormat);

            string query = @"UPDATE Modified SET

    [Application Start Date] = @ApplicationStartingDate,

    [Application Ending Date] = @ApplicationEndingDate,

    [Exam Date] = @ExamDate,

    [Result Date] = @ResultDate,

    [SSC Requirement] = @SSCRequirement,

    [HSC Requirement] = @HSCRequirement,

    [Application Fees] = @ApplicationFees,

    [Faculties] = @Faculties,

    [CSE] = @CSE,

    [EEE] = @EEE,

    [Architecture (B.Arch)] = @Architecture_B_Arch,

    [BBA] = @BBA,

    [English] = @English,

    [Economics] = @Economics,

    [Pharmacy] = @Pharmacy,

    [LLB] = @LLB,

    [Civil Engineering (CE)] = @CivilEngineering_CE,

    [Media Studies & Journalism] = @Media_Studies_Journalism,

    [CSE(Other Expenses)] = @CSE_Other_Expenses,

    [EEE(O.E)] = @EEE_OE,

    [Architecture(O.E)] = @Architecture_OE,

    [BBA(O.E)] = @BBA_OE,

    [English(O.E)] = @English_OE,

    [Economics(O.E)] = @Economics_OE,

    [Pharmacy(O.E)] = @Pharmacy_OE,

    [LLB(O.E)] = @LLB_OE,

    [CE(O.E)] = @CE_OE,

    [MSJ(O.E)] = @MSJ_OE,

    [CSE(T.E)] = @CSE_TE,

    [EEE(T.E)] = @EEE_TE,

    [Architecture(T.E)] = @Architecture_TE,

    [BBA(T.E)] = @BBA_TE,

    [English(T.E)] = @English_TE,

    [Economics(T.E)] = @Economics_TE,

    [Pharmacy(T.E)] = @Pharmacy_TE,

    [LLB(T.E)] = @LLB_TE,

    [CE(T.E)] = @CE_TE,

    [MSJ(T.E)] = @MSJ_TE,

    [Exam Format] = @ExamFormat,

    [Scholarship] = @Scholarship,

    [Other Information] = @OtherInformation,

    [location] = @location,

    [Latitude] = @Latitude,

    [Longitude] = @Longitude

WHERE [University Name] = @UniversityName;

";

            using (SqlConnection connection = new SqlConnection(connectionString))

            {

                using (SqlCommand command = new SqlCommand(query, connection))

                {

                    DateTime.TryParse(applicationStD, out DateTime appStart);

                    DateTime.TryParse(applicationEnD, out DateTime appEnd);

                    DateTime.TryParse(examDate, out DateTime examD);

                    DateTime.TryParse(resultDate, out DateTime resultD);

                    double.TryParse(sscRequirement, out double SSC);

                    double.TryParse(hscRequirement, out double HSC);

                    double.TryParse(applicationFees, out double FEES);

                    double.TryParse(latitude, out double LATITUDE);

                    double.TryParse(longitude, out double LONGITUDE);

                    int.TryParse(cse, out int CSE);

                    int.TryParse(eee, out int EEE);

                    int.TryParse(architecture, out int ARCH);

                    int.TryParse(bba, out int BBA);

                    int.TryParse(english, out int ENGLISH);

                    int.TryParse(economics, out int ECON);

                    int.TryParse(pharmacy, out int PHARM);

                    int.TryParse(llb, out int LLB);

                    int.TryParse(ce, out int CE);

                    int.TryParse(msj, out int MSJ);

                    int.TryParse(cseOe, out int CSE_OE);

                    int.TryParse(eeeOe, out int EEE_OE);

                    int.TryParse(architectureOe, out int ARCH_OE);

                    int.TryParse(bbaOe, out int BBA_OE);

                    int.TryParse(englishOe, out int ENGLISH_OE);

                    int.TryParse(economicsOe, out int ECON_OE);

                    int.TryParse(pharmacyOe, out int PHARM_OE);

                    int.TryParse(llbOe, out int LLB_OE);

                    int.TryParse(ceOe, out int CE_OE);

                    int.TryParse(msjOe, out int MSJ_OE);

                    int.TryParse(cseTe, out int CSE_TE);

                    int.TryParse(eeeTe, out int EEE_TE);

                    int.TryParse(architectureTe, out int ARCH_TE);

                    int.TryParse(bbaTe, out int BBA_TE);

                    int.TryParse(englishTe, out int ENGLISH_TE);

                    int.TryParse(economicsTe, out int ECON_TE);

                    int.TryParse(pharmacyTe, out int PHARM_TE);

                    int.TryParse(llbTe, out int LLB_TE);

                    int.TryParse(ceTe, out int CE_TE);

                    int.TryParse(msjTe, out int MSJ_TE);

                    command.Parameters.Add("@UniversityName", SqlDbType.NChar, 50).Value = uniName;

                    command.Parameters.Add("@ApplicationStartingDate", SqlDbType.SmallDateTime).Value = appStart;

                    command.Parameters.Add("@ApplicationEndingDate", SqlDbType.SmallDateTime).Value = appEnd;

                    command.Parameters.Add("@ExamDate", SqlDbType.SmallDateTime).Value = examD;

                    command.Parameters.Add("@ResultDate", SqlDbType.SmallDateTime).Value = resultD;

                    command.Parameters.Add("@SSCRequirement", SqlDbType.Float).Value = SSC;

                    command.Parameters.Add("@HSCRequirement", SqlDbType.Float).Value = HSC;

                    command.Parameters.Add("@ApplicationFees", SqlDbType.Float).Value = FEES;

                    command.Parameters.Add("@Faculties", SqlDbType.NChar, 200).Value = faculties;

                    command.Parameters.Add("@location", SqlDbType.VarChar, 200).Value = location;

                    command.Parameters.Add("@CSE", SqlDbType.Int).Value = CSE;

                    command.Parameters.Add("@EEE", SqlDbType.Int).Value = EEE;

                    command.Parameters.Add("@Architecture_B_Arch", SqlDbType.Int).Value = ARCH;

                    command.Parameters.Add("@BBA", SqlDbType.Int).Value = BBA;

                    command.Parameters.Add("@English", SqlDbType.Int).Value = ENGLISH;

                    command.Parameters.Add("@Economics", SqlDbType.Int).Value = ECON;

                    command.Parameters.Add("@Pharmacy", SqlDbType.Int).Value = PHARM;

                    command.Parameters.Add("@LLB", SqlDbType.Int).Value = LLB;

                    command.Parameters.Add("@CivilEngineering_CE", SqlDbType.Int).Value = CE;

                    command.Parameters.Add("@Media_Studies_Journalism", SqlDbType.Int).Value = MSJ;

                    command.Parameters.Add("@CSE_Other_Expenses", SqlDbType.Int).Value = CSE_OE;

                    command.Parameters.Add("@EEE_OE", SqlDbType.Int).Value = EEE_OE;

                    command.Parameters.Add("@Architecture_OE", SqlDbType.Int).Value = ARCH_OE;

                    command.Parameters.Add("@BBA_OE", SqlDbType.Int).Value = BBA_OE;

                    command.Parameters.Add("@English_OE", SqlDbType.Int).Value = ENGLISH_OE;

                    command.Parameters.Add("@Economics_OE", SqlDbType.Int).Value = ECON_OE;

                    command.Parameters.Add("@Pharmacy_OE", SqlDbType.Int).Value = PHARM_OE;

                    command.Parameters.Add("@LLB_OE", SqlDbType.Int).Value = LLB_OE;

                    command.Parameters.Add("@CE_OE", SqlDbType.Int).Value = CE_OE;

                    command.Parameters.Add("@MSJ_OE", SqlDbType.Int).Value = MSJ_OE;

                    command.Parameters.Add("@CSE_TE", SqlDbType.Int).Value = CSE_TE;

                    command.Parameters.Add("@EEE_TE", SqlDbType.Int).Value = EEE_TE;

                    command.Parameters.Add("@Architecture_TE", SqlDbType.Int).Value = ARCH_TE;

                    command.Parameters.Add("@BBA_TE", SqlDbType.Int).Value = BBA_TE;

                    command.Parameters.Add("@English_TE", SqlDbType.Int).Value = ENGLISH_TE;

                    command.Parameters.Add("@Economics_TE", SqlDbType.Int).Value = ECON_TE;

                    command.Parameters.Add("@Pharmacy_TE", SqlDbType.Int).Value = PHARM_TE;

                    command.Parameters.Add("@LLB_TE", SqlDbType.Int).Value = LLB_TE;

                    command.Parameters.Add("@CE_TE", SqlDbType.Int).Value = CE_TE;

                    command.Parameters.Add("@MSJ_TE", SqlDbType.Int).Value = MSJ_TE;

                    command.Parameters.Add("@ExamFormat", SqlDbType.NChar, 100).Value = examFormat.TrimEnd(',');

                    command.Parameters.Add("@Scholarship", SqlDbType.NChar, 200).Value = scholarship;

                    command.Parameters.Add("@OtherInformation", SqlDbType.NChar, 200).Value = otherInfo;

                    command.Parameters.Add("@Latitude", SqlDbType.Int).Value = LATITUDE;

                    command.Parameters.Add("@Longitude", SqlDbType.Int).Value = LONGITUDE;


                    connection.Open();

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)

                    {

                        MessageBox.Show("University Updated successfully!", "Success",

                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        this.Hide();

                        Form25 f25 = new Form25();

                        f25.Show();

                    }

                    else

                    {

                        MessageBox.Show("Insert failed!", "Error",

                            MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }

                    connection.Close();

                }

            }

        }

        

    }

}
 
        
