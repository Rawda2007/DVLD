using DVLD.People.Controls;
using DVLD_Buisness;
using Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Users
{
    public partial class Add_Edit_User : Form
    {
        public Add_Edit_User()
        {
            InitializeComponent();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void infoPersonWithFilter1_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            infoPearson.personID = 0;
            infoPearson.CurrentID = "0";

            this.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(infoPearson.personID==0 )
            {
                MessageBox.Show("Please Enter information person ");
                return;
            }
            else if(clsUser.DoPersonIdConnectecedToUser(infoPearson.personID))
            {
                MessageBox.Show("This Person Already Connected to User ");
                return;
            }
                tabControl1.SelectedTab = tabPage2;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(UserName.Text=="" || Password.Text==""||cPassword.Text=="")
            {
                MessageBox.Show("Please Enter User Name and Password ");
                return;
            }
            else if (Password.Text!=cPassword.Text)
            {
                MessageBox.Show("Please Enter Correct Confirm Password ");
                return;
            }
            else if(infoPearson.personID==0)
            {
                MessageBox.Show("Please Enter information person ");
                return;
            }
            else
            {
                // Save User Information
                int active = (Active.Checked) ? 1 : 0;
                int personID = infoPearson.personID;
                User user = new User(personID, UserName.Text, Password.Text, active);
                int result = DVLD_Buisness.clsUser.AddUser(user);
                if (result == 0)
                {
                    MessageBox.Show("Error in Save User Information ");
                    return;
                }
                else
                {
                    MessageBox.Show("User Added Successfully with ID : " + result);
                    UserID.Text = result.ToString();

                }
                button1.Enabled = false;
                button2.Enabled = false;



                //Disable
            }
        }

        private void infoPersonWithFilter1_Load_1(object sender, EventArgs e)
        {

        }

        private void Add_Edit_User_Load(object sender, EventArgs e)
        {

        }
    }
}
