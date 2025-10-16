using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Application_Types
{
    public partial class Edit_Application_Types : Form
    {
        public Edit_Application_Types(int ApplicationID)
        {
            InitializeComponent();
            this.AppplicationID = ApplicationID;
        }
        int AppplicationID; 
        private void Close_Click(object sender, EventArgs e)
        {
            this .Close();
        }

        private void Edit_Application_Types_Load(object sender, EventArgs e)
        {
           DataTable dataTable= clsAppliction_Type.GetApplicationByID(AppplicationID);
            foreach (DataRow row in dataTable.Rows)
            {
                ID.Text = row["ApplicationTypeID"].ToString();
                Type.Text = row["ApplicationTypeTitle"].ToString();
                oldFees.Text = row["ApplicationFees"].ToString();
            }



            Save.Enabled = false;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if(NewFees.Text.Length > 0)
            {
                Save.Enabled = true; 
            }
            else
            {
                Save.Enabled = false;
            }
        }

        private void Save_Click(object sender, EventArgs e)
        {
            if(clsAppliction_Type.ChangeFees(AppplicationID,Convert.ToDecimal (NewFees.Text)))
            {
                MessageBox.Show("Fees Changed Successfully");
                NewFees.Enabled = false;
                Save.Enabled = false;
            }
            else
            {
                MessageBox.Show("Error in Changing Fees");
            }
        }
    }
}
