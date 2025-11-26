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
    public partial class ShowLicenseHistory : Form
    {
        int PersonID = 0;
        public ShowLicenseHistory(int personID)
        {
            InitializeComponent();
            PersonID= personID;
            infoPearson.mode = infoPearson.Mode.ShowDetailes;
            infoPearson.CurrentID = personID.ToString();
            infoPearson.personID = personID;
            dataGridView1.DataSource = clsLocalDrivingLicenseApp.GetDataLicenseToHistoryLicense(PersonID);
            //dataGridView1.Columns[3].Width = 170;
            //dataGridView1.Columns[4].Width = 170;

            dataGridView2.DataSource = clsInternationalLicense.GetDataInternationalToHistoryLicense(PersonID);
            //dataGridView2.Columns[3].Width = 170;
            //dataGridView2.Columns[4].Width = 170;

        }

        private void ShowLicenseHistory_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void infoPearson1_Load(object sender, EventArgs e)
        {

        }
    }


}
