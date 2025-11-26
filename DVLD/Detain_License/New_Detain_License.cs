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
    public partial class New_Detain_License : Form
    {
        public New_Detain_License()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void New_Detain_License_Load(object sender, EventArgs e)
        {
            DetainDate.Text = DateTime.Now.ToString();
            UserName.Text = Properties.Settings.Default.UserName;
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

                if (IsActive.Text == "Inactive")
                {
                    MessageBox.Show("This License is  Inactive, you can not detain it .", "Not allow", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    detain.Enabled = false;
                    return;
                }

                else
                {
                    detain.Enabled = true;
                }
            }
            else
            {
                MessageBox.Show("Not Found License ID .");
                Filter.Text = "";
            }
        }

        private void detain_Click(object sender, EventArgs e)
        {
            if(clsDetainLicense.DoLicenseExistInDetain(Convert.ToInt32(IID.Text)))
            {
                MessageBox.Show("This License is already detained, you can not detain it again.","Not allow",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            if(Fees.Text=="" )
            {
                MessageBox.Show("Please enter Fees Detain.","Required",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            DetainID.Text=clsDetainLicense.AddDetainLicense(Convert.ToInt32(IID.Text), Convert.ToInt32(Fees.Text), clsUser.GetUserIDByUserName(Properties.Settings.Default.UserName)).ToString();
            MessageBox.Show("Detain License successfully . Detain ID : "+ DetainID.Text,"Success",MessageBoxButtons.OK,MessageBoxIcon.Information);
            detain.Enabled = false;
            Fees.Enabled = false;
        }

        private void Fees_KeyPress(object sender, KeyPressEventArgs e)
        {
            //only User enter digit
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }


        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
