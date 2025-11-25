using DVLD_Buisness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace DVLD.Renew_License
{
    public partial class Renew_License_Application : Form
    {
        public Renew_License_Application()
        {
            InitializeComponent();
        }

        private void SearchPerson_Click(object sender, EventArgs e)
        {

             if (clsLocalDrivingLicenseApp.IsExist(Convert.ToInt32(Filter.Text)))
            {
                DataTable dt = clsInternationalLicense.GetDataDriveLicenseInfoByLicenseID(Convert.ToInt32(Filter.Text));
               
                

                    NClass.Text = dt.Rows[0]["ClassName"].ToString();
                    FName.Text = dt.Rows[0]["Name"].ToString();
                    NationalNo.Text = dt.Rows[0]["NationalNo"].ToString();
                    LID.Text = dt.Rows[0]["LicenseID"].ToString();
                    Notes.Text = dt.Rows[0]["Notes"].ToString();
                if(Notes.Text!="") Notes.Text ="No Notes";
                DriverID.Text = dt.Rows[0]["DriverID"].ToString();
                    IssueDate.Text = Convert.ToDateTime(dt.Rows[0]["IssueDate"]).ToString("yyyy-MM-dd");
                    exDate.Text = Convert.ToDateTime(dt.Rows[0]["ExpirationDate"]).ToString("yyyy-MM-dd");
                    Reason.Text = dt.Rows[0]["IssueReason"].ToString();
                    IsActive.Text = Convert.ToBoolean(dt.Rows[0]["IsActive"]) ? "Active" : "Inactive";
                    if (!string.IsNullOrEmpty(dt.Rows[0]["ImagePath"].ToString()))
                    {

                        //   MessageBox.Show(dt.Rows[0]["ImagePath"].ToString() );
                        pictureBox1.Image = System.Drawing. Image.FromFile(dt.Rows[0]["ImagePath"].ToString());

                    }
                LicenseID.Text = dt.Rows[0]["LicenseID"].ToString();
                int diffYears = Convert.ToDateTime(dt.Rows[0]["ExpirationDate"]).Year - Convert.ToDateTime(dt.Rows[0]["IssueDate"]).Year;
                ExpDate.Text = DateTime.Now.AddYears(diffYears).ToString("yyyy-MM-dd");

                if (Convert.ToDateTime(dt.Rows[0]["ExpirationDate"])>DateTime.Now)
                {
                    MessageBox.Show("This License is not expired, you can not renew it .", "Not allow", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                else
                {
                    renew.Enabled = true;
                }
                if (IsActive.Text == "Inactive")
                {
                    MessageBox.Show("This License is  Inactive, you can not renew it .", "Not allow", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    renew.Enabled = false;
                    return;
                }
            }
            else
            {
                MessageBox.Show("Not Found License ID .");
                Filter.Text = "";
            }
            
            int NumClass = Convert.ToInt32(Regex.Match(NClass.Text, @"\d+").Value);
            if (NumClass<=6)
            {
               LFees.Text= clsLicense.GetFeesClassByClassID(NumClass).ToString();
                TFees.Text= ( Convert.ToDecimal( LFees.Text) +Convert.ToDecimal(AppFees.Text)).ToString();
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void Renew_License_Application_Load(object sender, EventArgs e)
        {
            AppFees.Text=clsAppliction_Type.FeesTypeByTypeID(2).ToString();
            AppDate.Text= DateTime.Now.ToString();
            IDate.Text= DateTime.Now.ToString();
            UserName.Text= Properties.Settings.Default.UserName;
        }

        private void Filter_TextChanged(object sender, EventArgs e)
        {
            renew.Enabled = false;
        }

        private void renew_Click(object sender, EventArgs e)
        {
            clsLicense.changeActiveLicenseToNonActive(Convert.ToInt32(LicenseID.Text));
            int AID = 0;
            int NewLicenseID = clsRenewLicenses.RenewLicense(
                Convert.ToInt32(LicenseID.Text),
               ref AID,
                Note.Text,
                Convert.ToInt32(AppFees.Text),
                Convert.ToInt32(TFees.Text),
                clsUser.GetUserIDByUserName(UserName.Text),
                Convert.ToDateTime(ExpDate.Text),2,2
                );
            AppID.Text=Convert.ToString(AID);
            RenewID.Text= Convert.ToString(NewLicenseID);
            if (NewLicenseID > 0)
            {
                MessageBox.Show($"Renew License successfully. New License ID={NewLicenseID} , Application ID={AID}");
            }
            renew.Enabled = false;
            Filter.Enabled = false;
            SearchPerson.Enabled = false;

        }
    }
}
