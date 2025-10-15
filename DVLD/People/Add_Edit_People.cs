using DVLD.People.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.People
{
    public partial class Add_Edit_People : Form
    {
        public Add_Edit_People()
        {
            InitializeComponent();
            if (infoPearson.mode == infoPearson.Mode.Add)
            {
                label1.Text = "Add New Person";
                Add_Edit_People.ActiveForm.Text = "Add New Person";
            }
            else if (infoPearson.mode == infoPearson.Mode.Edit)
            {
                label1.Text = "Edit Person";
                Add_Edit_People.ActiveForm.Text = "Edit Person";
            }
            else if (infoPearson.mode == infoPearson.Mode.ShowDetailes)
            {
                label1.Text = "Person Details";
                Add_Edit_People.ActiveForm.Text = "Person Details";
            }
        }
        
        private void Add_Edit_People_Load(object sender, EventArgs e)
        {
          
        }

        private void infoPearson1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
           
        }
    }
}
