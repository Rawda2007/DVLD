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

namespace DVLD.Users
{
    public partial class Change_Password : Form
    {
        public Change_Password()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Save_Click(object sender, EventArgs e)
        {
            if (confP.Text == null || CurrP.Text == null || NewP == null) return;
            if (confP.Text != NewP.Text)
            {
                MessageBox.Show("Please Enter Correct Confirm Password ");
                return;
            }

            if (clsUser.ChangePassword(infoPearson.personID, CurrP.Text, NewP.Text))
            {
                MessageBox.Show("Password Changed Successfully");

            }
            else
            {
                MessageBox.Show("Current Password is not correct");
                return;

            }
        }
    }
}
