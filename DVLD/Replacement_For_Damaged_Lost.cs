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

namespace DVLD
{
    public partial class Replacement_For_Damaged_Lost : Form
    {
        public Replacement_For_Damaged_Lost()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Replacement_For_Damaged_Lost_Load(object sender, EventArgs e)
        {
            UserName.Text = Properties.Settings.Default.UserName;
            AppDate.Text = DateTime.Now.ToString();
            radioButton1.Checked = true;
        }

        private void Filter_TextChanged(object sender, EventArgs e)
        {
            issue.Enabled = false;
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
                if (Notes.Text != "") Notes.Text = "No Notes";
                DriverID.Text = dt.Rows[0]["DriverID"].ToString();
                IssueDate.Text = Convert.ToDateTime(dt.Rows[0]["IssueDate"]).ToString("yyyy-MM-dd");
                exDate.Text = Convert.ToDateTime(dt.Rows[0]["ExpirationDate"]).ToString("yyyy-MM-dd");
                Reason.Text = dt.Rows[0]["IssueReason"].ToString();
                IsActive.Text = Convert.ToBoolean(dt.Rows[0]["IsActive"]) ? "Active" : "Inactive";
                if (!string.IsNullOrEmpty(dt.Rows[0]["ImagePath"].ToString()))
                {

                    //   MessageBox.Show(dt.Rows[0]["ImagePath"].ToString() );
                    pictureBox1.Image = System.Drawing.Image.FromFile(dt.Rows[0]["ImagePath"].ToString());

                }
                LicenseID.Text = dt.Rows[0]["LicenseID"].ToString();
                int diffYears = Convert.ToDateTime(dt.Rows[0]["ExpirationDate"]).Year - Convert.ToDateTime(dt.Rows[0]["IssueDate"]).Year;

                if (Convert.ToDateTime(dt.Rows[0]["ExpirationDate"]) < DateTime.Now)
                {
                    MessageBox.Show("This License is  expired, you can not replace it .", "Not allow", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    issue.Enabled = false;
                    return;
                }
                if(IsActive.Text== "Inactive")
                {
                    MessageBox.Show("This License is  Inactive, you can not replace it .", "Not allow", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    issue.Enabled = false;
                    return;
                }

                else
                {
                    issue.Enabled = true;
                }
            }
            else
            {
                MessageBox.Show("Not Found License ID .");
                Filter.Text = "";
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            AppFees.Text = clsAppliction_Type.FeesTypeByTypeID((radioButton1.Checked)?4:3).ToString();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            AppFees.Text = clsAppliction_Type.FeesTypeByTypeID((radioButton1.Checked) ? 4 : 3).ToString();

        }

        private void issue_Click(object sender, EventArgs e)
        {
            clsLicense.changeActiveLicenseToNonActive(Convert.ToInt32(LicenseID.Text));
            int AID = 0;
            int NewLicenseID = clsRenewLicenses.RenewLicense(
                Convert.ToInt32(LicenseID.Text),
               ref AID,
                Notes.Text,
                Convert.ToInt32(AppFees.Text),
                Convert.ToInt32(AppFees.Text),
                clsUser.GetUserIDByUserName(UserName.Text),
                Convert.ToDateTime(exDate.Text),
                (radioButton1.Checked) ? 4 : 3,
                (radioButton2.Checked) ? 4 : 3
                );
            AppID.Text = Convert.ToString(AID);
            RenewID.Text = Convert.ToString(NewLicenseID);
            if (NewLicenseID > 0)
            {
                MessageBox.Show($"Replace License successfully. New License ID={NewLicenseID} , Application ID={AID}");
            }
            issue.Enabled = false;
            Filter.Enabled= false;
            SearchPerson.Enabled= false;
            groupBox4.Enabled= false;
        }
    }
}
