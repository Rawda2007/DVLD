using DVLD.Global;
using DVLD.Main;
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

namespace DVLD.Login
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.RemmberMe)
            {
                UserName.Text = Properties.Settings.Default.UserName;
                Passport.Text = Properties.Settings.Default.Password.ToString();
                checkRemmber.Checked = Properties.Settings.Default.RemmberMe;

            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (UserName.Text == "" || Passport.Text == "")
            {
                MessageBox.Show("Please Enter User Name and Password !");
                return;
            }
           

            
               bool result= clsUser.CheckLogIn(UserName.Text, Passport.Text);
                if(!result)
                {
                    MessageError.Text = "Invailed Log in ! Error in User Name and Passsword .";
                }
                else
                {
                    if(checkRemmber.Checked)
                    {
                        clsGlobal.RemmberUserNameAndPassword(UserName.Text,Passport.Text);
                    }
                    else
                    {
                        clsGlobal.NotRemmberUserNameAndPassword();
                    }

                Form form = new MainScreen();
                form.ShowDialog();
                this.Close();
            }
            }

        }
    }

