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

namespace DVLD.LocalDrivingLicenseApplications_View.Control
{
    public partial class infoShowLicense : UserControl
    {
        public infoShowLicense()
        {
            InitializeComponent();
        }
        public static string NationalNo = "";
        public static string FullName = "";
        public static string ClassName = "";
        private void infoShowLicense_Load(object sender, EventArgs e)
        {
           
      if(DesignMode)
                return;
            DateLicense();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
        public void DateLicense()
        {
            int LicenceID = clsLicense.GetLicenseIDByNational(NationalNo, ClassName);
            DataTable dt = clsLicense.GetInfoLicenseByLicenseID(25);
            if (dt.Rows.Count > 0)
            {
                LID.Text = dt.Rows[0]["LicenseID"].ToString();
                string ClassName = clsLicense.GetClassNameByClassID(Convert.ToInt32(dt.Rows[0]["LicenseClass"]));
                NClass.Text = ClassName;
                FName.Text = FullName;
                Notes.Text = dt.Rows[0]["Notes"].ToString();
                IssueDate.Text = Convert.ToDateTime(dt.Rows[0]["IssueDate"]).ToString("yyyy-MM-dd");
                exDate.Text = Convert.ToDateTime(dt.Rows[0]["ExpirationDate"]).ToString("yyyy-MM-dd");
                Reason.Text = dt.Rows[0]["IssueReason"].ToString();
                IsActive.Text = Convert.ToBoolean(dt.Rows[0]["IsActive"]) ? "Active" : "Inactive";
            }
        }
    }
}
