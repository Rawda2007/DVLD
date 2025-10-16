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

namespace DVLD.Test_Types
{
    public partial class Edit_Test_Type : Form
    {
        public Edit_Test_Type(int ID)
        {
            InitializeComponent();
            IDTest = ID;
        }
        int IDTest = 0;
        private void Edit_Test_Type_Load(object sender, EventArgs e)
        {
            DataTable dataTable = clsTestType.GetInfoTestByID(IDTest);
            foreach (DataRow row in dataTable.Rows)
            {
                ID.Text = row[0].ToString();
                Title.Text = row[1].ToString();
                Description.Text = row[2].ToString();
                oldFees.Text = row[3].ToString();
            }
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
            if (clsTestType.ChangeFees(IDTest, Convert.ToDecimal(NewFees.Text)))
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

        private void NewFees_TextChanged(object sender, EventArgs e)
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
    }
}
