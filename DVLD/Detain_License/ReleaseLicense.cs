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

namespace DVLD.Detain_License
{
    public partial class ReleaseLicense : Form
    {
        public ReleaseLicense()
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
                IID.Text = dt.Rows[0]["LicenseID"].ToString();

                //info releaseDetainted
                DataTable dtDetain = clsDetainLicense.GetInfoDetainedByLicenseID(Convert.ToInt32(Filter.Text));
                if(dtDetain.Rows.Count==1)
                {
                    DetainID.Text = dtDetain.Rows[0]["DetainID"].ToString();
                    DetainDate.Text = Convert.ToDateTime(dtDetain.Rows[0]["DetainDate"]).ToString("yyyy-MM-dd");
                    FineFees.Text = dtDetain.Rows[0]["FineFees"].ToString();
                    TFees.Text = (Convert.ToDecimal(FineFees.Text)+Convert.ToDecimal(AppFees.Text)).ToString();
                }
                else
                {
                    DetainID.Text ="[???]";
                    DetainDate.Text= "[???]";
                    FineFees.Text = "[???]";
                    TFees.Text = "[???]";
                }
                if (!clsDetainLicense.DoLicenseExistInDetain(Convert.ToInt32(Filter.Text)))
                {
                    MessageBox.Show("This License is not detained .", "Not allow", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    release.Enabled = false;
                    return;
                }
                else
                {

                }
                if (IsActive.Text == "Inactive")
                {
                    MessageBox.Show("This License is  Inactive, you can not detain it .", "Not allow", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    release.Enabled = false;
                    return;
                }

                else
                {
                    release.Enabled = true;
                }
            }
            else
            {
                MessageBox.Show("Not Found License ID .");
                Filter.Text = "";
            }
        }

        private void release_Click(object sender, EventArgs e)
        {
          AppID.Text=   clsDetainLicense.ReleasedDetainedLicense(Convert.ToInt32(DetainID.Text), NationalNo.Text, UserName.Text).ToString();

            MessageBox.Show($"The License has been released successfully ,ApplicationID={AppID} .", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            release.Enabled = false;
        }

        private void ReleaseLicense_Load(object sender, EventArgs e)
        {
            UserName.Text=Properties.Settings.Default.UserName;
            AppFees.Text=clsAppliction_Type.FeesTypeByTypeID(5).ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();   
        }
    }
}
