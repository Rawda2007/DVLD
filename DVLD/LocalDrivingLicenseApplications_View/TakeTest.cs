using DVLD.LocalDrivingLicenseApplications_View.Control;
using DVLD_Buisness;
using Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DVLD.LocalDrivingLicenseApplications_View.Control.infoTest;

namespace DVLD.LocalDrivingLicenseApplications_View
{
    public partial class TakeTest : Form
    {
        public TakeTest()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        int DLAppID = Test.IDLocal;
        int trial = infoTest.trial;
        public static int AppointmentID = 0;
        private void TakeTest_Load(object sender, EventArgs e)
        {
            if (DesignMode)
                return;

            DataTable dt = DVLD_Buisness.clsLocalDrivingLicenseApp.InfoTest(DLAppID);
            if (dt.Rows.Count > 0)
            {
                LocalID.Text = dt.Rows[0]["LocalDrivingLicenseApplicationID"].ToString();
                Class.Text = dt.Rows[0]["ClassName"].ToString();
                lName.Text = dt.Rows[0]["FullName"].ToString();
                Fees.Text = dt.Rows[0]["PaidFees"].ToString();
                AppDate.Text = dt.Rows[0]["AppointmentDate"].ToString();
            }
            Trial.Text = trial.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int result = (radPass.Checked == true) ? 1 : 0;
            //clsLocalDrivingLicenseApps.SaveTakeTest(LDAppID, result, notes, userID);
            TestID.Text = clsLocalDrivingLicenseApp.SaveTakeTest(AppointmentID,DLAppID, result, Notes.Text, clsUser.GetUserIDByUserName(Properties.Settings.Default.UserName.ToString())).ToString();
            foreach(System.Windows.Forms.Control c in this.Controls)
            {
                if(c.Name!= "button2") c.Enabled = false;
            }

        }
    }
}
