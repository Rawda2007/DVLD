using DVLD.People.Controls;
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
    public partial class NewLocalDrivingLincese : Form
    {
        public NewLocalDrivingLincese()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (infoPearson.personID == 0)
            {
                MessageBox.Show("Please Enter information person ");
                return;
            }
            tabControl1.SelectedTab = tabPage2;
            Save.Enabled = true;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void NewLocalDrivingLincese_Load(object sender, EventArgs e)
        {
            TClass.DataSource = clsLocalDrivingLicenseApp.LicenseClass();
            TClass.DisplayMember = "ClassName";
            TClass.ValueMember = "LicenseClassID";
            TClass.SelectedIndex = 2;

            CreadedBy.Text = Properties.Settings.Default.UserName;
            AppDate.Text = DateTime.Now.ToShortDateString();
            AppFees.Text = clsLocalDrivingLicenseApp.FeesNewLocal().ToString();
            if(infoPearson.personID==0)
            {
                Save.Enabled = false;
            }
        }

        private void Save_Click(object sender, EventArgs e)
        {

        }

        private void Save_Click_1(object sender, EventArgs e)
        {
            
            if (clsLocalDrivingLicenseApp.DoFindOrderElse(Convert.ToInt32(infoPearson.personID), Convert.ToInt32(TClass.SelectedValue)))
            {
                MessageBox.Show("Choose anthor License Class,The selected Person already have an active appliction ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
        }
            string National=clsPeople.GetNationalByPersonID(infoPearson.personID);
            if(clsLicense.GetLicenseIDByNational(National,TClass.Text)>0)
            {
                MessageBox.Show("Choose anthor License Class,The selected Person already have an active license for the selected class ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ID.Text= clsLocalDrivingLicenseApp.AddNewLocal(infoPearson.personID, Properties.Settings.Default.UserName, Convert.ToInt32(TClass.SelectedValue)
                ).ToString();
            MessageBox.Show("Local Driving License Application Added Successfully with ID : " + ID.Text);
            Save .Enabled = false;

        }
    }
}
