using DVLD.Application_Types;
using DVLD.People;
using DVLD.People.Controls;
using DVLD.Users;
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

namespace DVLD.Main
{
    public partial class MainScreen : Form
    {
        public MainScreen()
        {
            InitializeComponent();
        }

        private void MainScreen_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void peopleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new Mangement_People();
            frm.ShowDialog();
        }

        private void sersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm=new Mangement_Users();
            frm.ShowDialog();
        }

        private void accountSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void currentUserInformationToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            infoPearson.mode = infoPearson.Mode.ShowDetailes;
            infoPearson.personID = clsUser.PersonIDByUserName(Properties.Settings.Default.UserName);
            infoPearson.CurrentID = infoPearson.personID.ToString();
            Form frm = new show_Detailes_User();
            frm.Show();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            infoPearson.mode = infoPearson.Mode.ShowDetailes;
            infoPearson.personID = clsUser.PersonIDByUserName(Properties.Settings.Default.UserName);
            infoPearson.CurrentID =infoPearson. personID.ToString();
            Form frm = new Change_Password();
            frm.Show();

        }

        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsGlobal.NotRemmberUserNameAndPassword();
            this.Close();


        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            Form frm = new Test_Types.Test_Types();
            frm.ShowDialog();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            Form frm = new Mangement_Application_Types();
            frm.ShowDialog();

        }
    }
}
