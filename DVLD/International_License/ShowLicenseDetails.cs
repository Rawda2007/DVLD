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
    public partial class ShowLicenseDetails : Form
    {
        public ShowLicenseDetails(int LicenseID)

        {

            InitializeComponent();
            //Driver License
            DataTable dt = clsInternationalLicense.GetDataDriveLicenseInfoByLicenseID(LicenseID);

            NClass.Text = dt.Rows[0]["ClassName"].ToString();
            FName.Text = dt.Rows[0]["Name"].ToString();
            NationalNo.Text = dt.Rows[0]["NationalNo"].ToString();
            LID.Text = dt.Rows[0]["LicenseID"].ToString();
            Notes.Text = dt.Rows[0]["Notes"].ToString();
            DriverID.Text = dt.Rows[0]["DriverID"].ToString();
            IssueDate.Text = Convert.ToDateTime(dt.Rows[0]["IssueDate"]).ToString("yyyy-MM-dd");
            exDate.Text = Convert.ToDateTime(dt.Rows[0]["ExpirationDate"]).ToString("yyyy-MM-dd");
            Reason.Text = dt.Rows[0]["IssueReason"].ToString();
            IsActive.Text = Convert.ToBoolean(dt.Rows[0]["IsActive"]) ? "Active" : "Inactive";
            if (!string.IsNullOrEmpty(dt.Rows[0]["ImagePath"].ToString()))
            {

                //   MessageBox.Show(dt.Rows[0]["ImagePath"].ToString() );
                pictureBox1.Image = Image.FromFile(dt.Rows[0]["ImagePath"].ToString());

            }

            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ShowLicenseDetails_Load(object sender, EventArgs e)
        {

        }
    }
}
