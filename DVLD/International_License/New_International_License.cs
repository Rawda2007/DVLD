using DVLD_Buisness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.International_License
{
    public partial class New_International_License : Form
    {
        public New_International_License()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void New_International_License_Load(object sender, EventArgs e)
        {
            UserName.Text = Properties.Settings.Default.UserName;
            Fees.Text =clsAppliction_Type.FeesTypeByTypeID(6).ToString() ;
            AppDate.Text = DateTime.Now.ToString();
            IDate.Text = DateTime.Now.ToString();
            ExpDate.Text = DateTime.Now.AddYears(1).ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SearchPerson_Click(object sender, EventArgs e)
        {
            if(clsInternationalLicense.IsExistLicenseIDBytLicenseID(Convert.ToInt32(Filter.Text)))
            {
                MessageBox.Show("This License ID is already used to issue International Driving License.","Not allow",MessageBoxButtons.OK,MessageBoxIcon.Error);
                Filter.Text = "";
            }
            else if (clsLocalDrivingLicenseApp.IsExist(Convert.ToInt32(Filter.Text)))
            {
                DataTable dt = clsInternationalLicense.GetDataDriveLicenseInfoByLicenseID(Convert.ToInt32(Filter.Text));
              if (dt.Rows[0]["ClassName"].ToString()!= "Class 3 - Ordinary driving license")
                {
                    MessageBox.Show("Only Allow 'Class 3 - Ordinary driving license' in international driving license.","Not allow",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
                else 
                {
                    
                    NClass.Text = dt.Rows[0]["ClassName"].ToString();
                    FName.Text = dt.Rows[0]["Name"].ToString();
                    NationalNo.Text = dt.Rows[0]["NationalNo"].ToString();
                    LID.Text = dt.Rows[0]["LicenseID"].ToString();    
                    Notes.Text = dt.Rows[0]["Notes"].ToString();
                    DriverID.Text = dt.Rows[0]["DriverID"].ToString();
                    IssueDate.Text= Convert.ToDateTime(dt.Rows[0]["IssueDate"]).ToString("yyyy-MM-dd");
                    exDate.Text= Convert.ToDateTime(dt.Rows[0]["ExpirationDate"]).ToString("yyyy-MM-dd");
                    Reason.Text = dt.Rows[0]["IssueReason"].ToString();
                    IsActive.Text = Convert.ToBoolean(dt.Rows[0]["IsActive"]) ? "Active" : "Inactive";
                    if (!string.IsNullOrEmpty(dt.Rows[0]["ImagePath"].ToString()))
                    {
                     
                     //   MessageBox.Show(dt.Rows[0]["ImagePath"].ToString() );
                    pictureBox1.Image = Image.FromFile(dt.Rows[0]["ImagePath"].ToString());

                    }
                    Issue.Enabled = true;

                }
                if (IsActive.Text == "Inactive")
                {
                    MessageBox.Show("This License is  Inactive .", "Not allow", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Issue.Enabled = false;
                    return;
                }
            }
            else
            {
                MessageBox.Show("Not Found License ID .");
                Filter.Text = "";
            }
        }

        private void Filter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // يمنع الإدخال
            }

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void Filter_TextChanged(object sender, EventArgs e)
        {
            NClass.Text ="[???]";
            FName.Text = "[???]";
            NationalNo.Text= "[???]";
            LID.Text = "[???]";
            Notes.Text = "[???]";
            DriverID.Text="[???]";
            IssueDate.Text="[???]";
            exDate.Text ="[???]";
            Reason.Text ="[???]";
            IsActive.Text="[???]";
            Issue.Enabled = false;
        }

        private void Issue_Click(object sender, EventArgs e)
        {
            if(IsActive.Text=="Inactive")
            {
                MessageBox.Show("The local driving license is inactive, cannot issue an international driving license.","Not allow",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            int ApplicationID= clsApplication.InsertApplication(
                clsPeople.GetPersonIDByNational(NationalNo.Text),
                DateTime.Now,
                6,
                3,
                DateTime.Now,
                Convert.ToDecimal(Fees.Text),
                UserName.Text
                );
            int InternationalID= clsInternationalLicense.InsertInternationalLicense(ApplicationID,
                Convert.ToInt32(DriverID.Text),
                Convert.ToInt32(LID.Text),
                Convert.ToDateTime(IDate.Text),
                Convert.ToDateTime(ExpDate.Text),
                true,
                clsUser.GetUserIDByUserName(UserName.Text)
                );
            if(InternationalID>0)
            {
             MessageBox.Show($"International Driving License issued successfully.International License ID={InternationalID}");

                AppID.Text = ApplicationID.ToString();
                IID.Text = InternationalID.ToString();
               LicenseID.Text= LID.Text  ;
                Issue.Enabled = false;
                Filter.Enabled = false;
                SearchPerson.Enabled = false;

            }
        }
    }
}
