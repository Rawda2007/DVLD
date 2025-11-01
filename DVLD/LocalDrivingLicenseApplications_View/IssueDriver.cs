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

namespace DVLD.LocalDrivingLicenseApplications_View
{
    public partial class IssueDriver : Form
    {
        public IssueDriver()
        {
            InitializeComponent();
        }
        public static int LDAppID=0;
        public static string ClassName = "";
        public static string National = "";
        private void IssueDriver_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int UserID=clsUser.GetUserIDByUserName(Properties.Settings.Default.UserName);   
            int LicenseID = clsLocalDrivingLicenseApp.IssueDrivingLicense(LDAppID,ClassName, National,UserID, Notes.Text);
            MessageBox.Show("Issue License Successfully wuth License ID = " + LicenseID.ToString(), "عملية ناجحة", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
}
}
