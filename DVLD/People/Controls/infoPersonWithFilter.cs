using DVLD_Buisness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace DVLD.People.Controls
{
    public partial class infoPersonWithFilter : UserControl
    {
        public infoPersonWithFilter()
        {
            InitializeComponent();
            FormUpdateUser(); 
       }

        private void infoPersonWithFilter_Load(object sender, EventArgs e)
        {
            comboBox1.Items.AddRange(new string[]
            {
                "NationalNo",
                "PersonID"
            });
            comboBox1.SelectedIndex = 0; // اختيار أول عنصر افتراضيًا
            infoPearson1.RemoveSomeControlsfromControl();
            //infoPearson infoPearson = new infoPearson();
            //infoPearson.Dock = DockStyle.Fill;
            //Controls.Add(infoPearson);
        }
          public enum mode
        {
            Add,
            Update
        }
      


        public static mode CurrentMode= mode.Add;

        private void Filter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (comboBox1.Text == "PersonID")
            {
                // السماح بالأرقام فقط
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            infoPearson.mode = infoPearson.Mode.Add;
            Form frm = new Add_Edit_People();
            frm.Show();
        }

        private void SearchPerson_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(Filter.Text))
            {
                MessageBox.Show("Please enter a value to search.");
                return;
            }
            if(comboBox1.Text=="NationalNo")
            {
                infoPearson.CurrentID = DVLD_Buisness.clsPeople.GetPersonIDByNational(Filter.Text).ToString();
               
            }
            else if(comboBox1.Text == "PersonID")
            {
                infoPearson.CurrentID = Filter.Text;
            }
            else
            {
                MessageBox.Show("Person Not Found.");
                return;
            }
            infoPearson.mode = infoPearson.Mode.ShowDetailes;
            
                      infoPearson1.GetPerson();

        }

        private void SearchPerson_Click_1(object sender, EventArgs e)
        {
            string PersonID="0";
            if (string.IsNullOrWhiteSpace(Filter.Text))
            {
                MessageBox.Show("Please enter a value to search.");
                return;
            }
            if (comboBox1.Text == "NationalNo")
            {
                PersonID = DVLD_Buisness.clsPeople.GetPersonIDByNational(Filter.Text).ToString();

            }
            else if (comboBox1.Text == "PersonID")
            {
                PersonID = Filter.Text;
            }
            else
            {

            }

            if (!clsPeople.IsExist(Convert.ToInt32(PersonID)))
            {
                MessageBox.Show("Person Not Found.");
                return;
            }
            infoPearson.mode = infoPearson.Mode.ShowDetailes;
            infoPearson.CurrentID = PersonID;
            infoPearson.personID= Convert.ToInt32(PersonID);
            infoPearson1.GetPerson();

        }

        private void Filter_TextChanged(object sender, EventArgs e)
        {
            infoPearson1.ClearControls();

        }

        private void infoPearson1_Load(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        public void FormUpdateUser()
        {
            if(CurrentMode== mode.Update)
            {
                groupBox2.Enabled = false;
                infoPearson.mode = infoPearson.Mode.ShowDetailes;
                infoPearson1.GetPerson();
            }
           

        }

        private void infoPearson1_Load_1(object sender, EventArgs e)
        {

        }
    }
}
