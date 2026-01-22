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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Admission_Orbit
{
    public partial class AddPrivateUni : Form
    {
        public AddPrivateUni()
        {
            InitializeComponent();
            checkedListBox1.CheckOnClick = true;
        }

        private void AddPrivateUni_Load(object sender, EventArgs e)
        {

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


                if (string.IsNullOrWhiteSpace(uniName) || string.IsNullOrWhiteSpace(applicationStD)

                     || string.IsNullOrWhiteSpace(applicationEnD) || string.IsNullOrWhiteSpace(sscRequirement)

                     || string.IsNullOrWhiteSpace(hscRequirement) || string.IsNullOrWhiteSpace(examDate) ||

                     string.IsNullOrWhiteSpace(resultDate)

                     || string.IsNullOrWhiteSpace(scholarship) || string.IsNullOrWhiteSpace(applicationFees)

                     || string.IsNullOrWhiteSpace(faculties)

                     || string.IsNullOrWhiteSpace(otherInfo) || string.IsNullOrWhiteSpace(location))

                {

                    MessageBox.Show("All fields must be filled out.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    return;

                }

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


                string query = @"

INSERT INTO Modified

(

    [University Name],

    [Application Start Date],

    [Application Ending Date],

    [Exam Date],

    [Result Date],

    [SSC Requirement],

    [HSC Requirement],

    [Application Fees],

    [Faculties],

    [CSE],

    [EEE],

    [Architecture (B.Arch)],

    [BBA],

    [English],

    [Economics],

    [Pharmacy],

    [LLB],

    [Civil Engineering (CE)],

    [Media Studies & Journalism],

    [CSE(Other Expenses)],

    [EEE(O.E)],

    [Architecture(O.E)],

    [BBA(O.E)],

    [English(O.E)],

    [Economics(O.E)],

    [Pharmacy(O.E)],

    [LLB(O.E)],

    [CE(O.E)],

    [MSJ(O.E)],

    [CSE(T.E)],

    [EEE(T.E)],

    [Architecture(T.E)],

    [BBA(T.E)],

    [English(T.E)],

    [Economics(T.E)],

    [Pharmacy(T.E)],

    [LLB(T.E)],

    [CE(T.E)],

    [MSJ(T.E)],

    [Exam Format],

    [Scholarship],

    [Other Information],[location],[Latitude],[Longitude]

)

VALUES

(

    @UniversityName,

    @ApplicationStartingDate,

    @ApplicationEndingDate,

    @ExamDate,

    @ResultDate,

    @SSCRequirement,

    @HSCRequirement,

    @ApplicationFees,

    @Faculties,

    @CSE,

    @EEE,

    @Architecture_B_Arch,

    @BBA,

    @English,

    @Economics,

    @Pharmacy,

    @LLB,

    @CivilEngineering_CE,

    @Media_Studies_Journalism,

    @CSE_Other_Expenses,

    @EEE_OE,

    @Architecture_OE,

    @BBA_OE,

    @English_OE,

    @Economics_OE,

    @Pharmacy_OE,

    @LLB_OE,

    @CE_OE,

    @MSJ_OE,

    @CSE_TE,

    @EEE_TE,

    @Architecture_TE,

    @BBA_TE,

    @English_TE,

    @Economics_TE,

    @Pharmacy_TE,

    @LLB_TE,

    @CE_TE,

    @MSJ_TE,

    @ExamFormat,

    @Scholarship,

    @OtherInformation, @location, @Latitude, @Longitude

);";


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

                            MessageBox.Show("University Added successfully!", "Success",

                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                            this.Hide();

                            AdminPrivateView adminPrivateView = new AdminPrivateView();
                        adminPrivateView.Show();

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
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminPrivateDashboard adminPrivateDashboard = new AdminPrivateDashboard();
            adminPrivateDashboard.Show();

        }

        private void textBox37_TextChanged(object sender, EventArgs e)
        {

        }
    }

    }


    
