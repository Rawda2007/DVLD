using DVLD.Test_Types;
using DVLD_Buisness;
using Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace DVLD.LocalDrivingLicenseApplications_View.Control
{
    public partial class infoTest : UserControl
    {
        public infoTest()
        {
            InitializeComponent();
            if (DesignMode)
                return;
            dateTimePicker1.MinDate = DateTime.Now;
            dateTimePicker1.MaxDate = DateTime.Now.AddDays(30);
        }
        public   enum TypeTest
        {
            Vision, 
            Writing,
            Street
        }
       public static TypeTest typeTest= TypeTest.Vision;

        public enum TestMode
        {
            Add,
            Edit
        }
        public static TestMode testMode = TestMode.Add;

        public static int AppointmentIDEdit = 0;
        public static int LID { get; set; }
        int AppID = 0;
        int UserID = clsUser.GetUserIDByUserName(Properties.Settings.Default.UserName);

        public static int trial = 0;
        private void VisionTest_Load(object sender, EventArgs e)
        {
            if (DesignMode)
                return;

            DataTable dt = DVLD_Buisness.clsLocalDrivingLicenseApp.InfoTestByLocalID(LID);
            if (dt.Rows.Count > 0)
            {
                LocalID.Text= dt.Rows[0]["LocalDrivingLicenseApplicationID"].ToString();
                   
                Class.Text = dt.Rows[0]["ClassName"].ToString();
                lName.Text = dt.Rows[0]["FullName"].ToString();
                Fees.Text = clsLocalDrivingLicenseApp.FeesVisionEye(Convert.ToInt32(typeTest)+1).ToString();
            }
           
            if (trial > 0)
            {
                int RetakeFees = clsAppliction_Type.FeesTypeByTypeID(7);
                RFees.Text = RetakeFees.ToString();
              
                foreach (System.Windows.Forms.Control c in groupBox2.Controls)
                {
                    c.Enabled = true;
                }
               

            }
            int TotalFees = Convert.ToInt32(Fees.Text) + Convert.ToInt32(RFees.Text);
            TFees.Text = TotalFees.ToString();
            Trial.Text = trial.ToString();
          
           
        }
      
        private void button1_Click(object sender, EventArgs e)
        {
           // clsLocalDrivingLicenseApps.SaveAppointment(LocalID, AppDate, Fees, UserName, TestType, UserID, trial)       
                if (testMode== TestMode.Add)
            {
                int success = clsLocalDrivingLicenseApp.SaveAppointment(Convert.ToInt32(LocalID.Text), dateTimePicker1.Value,Convert.ToInt32(TFees.Text), Convert.ToInt32(typeTest) + 1,UserID,AppID );
              if(trial>0)
                {
                    AppID = clsLocalDrivingLicenseApp.AddApplicationWhenRetakeTest(UserID, dateTimePicker1.Value, Convert.ToInt32(RFees.Text), 7);
                    ApplicationID.Text = AppID.ToString();
                }
                if (success > 0)
                {
                    MessageBox.Show("Appointment saved successfully .");
                    groupBox1.Enabled = false;
                    groupBox2.Enabled = false;

                }
                else
                {
                    MessageBox.Show("Failed to save appointment.");
                }
            }
         else if(testMode == TestMode.Edit)
            {
                
                bool result= clsLocalDrivingLicenseApp.EditAppointmentTest(AppointmentIDEdit, dateTimePicker1.Value);
                if(result)
                {
                    MessageBox.Show("Appointment edited successfully .");
                    groupBox1.Enabled = false;
                    groupBox2.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Failed to edit appointment.");
                }
            }

        }

        private void label14_Click(object sender, EventArgs e)
        {
           
        }
    }
}
