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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using DVLD_Buisness;
namespace DVLD.LocalDrivingLicenseApplications_View
{
    public partial class infoDrivingLicenseApp : UserControl
    {
        public infoDrivingLicenseApp()
        {
            InitializeComponent();
            int Passed = 0, AppID = 0, Fees = 0;
            string Class = "", status = "", Type = "", Name = "", User = "";
            DateTime DateApp = DateTime.Now, StDate = DateTime.Now;
            clsLocalDrivingLicenseApp.FullControlLocalDriving(DLAppID, ref Class, ref Passed, ref AppID,
                               ref status, ref Fees, ref Type, ref Name,
                               ref DateApp, ref StDate, ref User);

            DLID.Text = DLAppID.ToString();
            tClass.Text = Class;
            Pass.Text = Passed.ToString();
            ApID.Text = AppID.ToString();
            State.Text = status;
            tFees.Text = Fees.ToString();
            tType.Text = Type;
            tName.Text = Name;
            LDate.Text = DateApp.ToShortDateString();
            StatusDate.Text = StDate.ToShortDateString();
            CreatedBy.Text = User;
        }
        public static int DLAppID = 0;

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void infoDrivingLicenseApp_Load(object sender, EventArgs e)
        {

        }
    }
}
