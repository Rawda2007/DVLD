using DVLD.LocalDrivingLicenseApplications_View.Control;
using DVLD.Test_Types;
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
    public partial class Test : Form
    {
        public Test()
        {
            InitializeComponent();
            if (infoTest.typeTest == infoTest.TypeTest.Vision)
            {
                this.Text = "Vision Test Appointments";
                lAddress.Text = "Vision Test Appointments";
            }
            else if (infoTest.typeTest == infoTest.TypeTest.Writing)
            {
                this.Text = "Writing Test Appointments";
                lAddress.Text = "Writing Test Appointments";
            }
            else if (infoTest.typeTest == infoTest.TypeTest.Street)
            {
                this.Text = "Street Test Appointments";
                lAddress.Text = "Street Test Appointments";
            }
        }

        private void infoDrivingLicenseApp1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();   
        }
       public static int IDLocal { get; set; }
       public static int IDTest=1;
        private void TestEye_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = clsLocalDrivingLicenseApp.GetAppointments(IDLocal, IDTest);
            if(dataGridView1.Rows.Count > 0 )  dataGridView1.Columns[1].Width = 265;

            infoTest.trial=dataGridView1.Rows.Count;

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool IsLoked = clsLocalDrivingLicenseApp.AppointmentIsLocked(IDLocal);
            if (!IsLoked)
            {
                MessageBox.Show("Person already have an active appointmentfor this test, You cannot add new appointment .","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            if(clsLocalDrivingLicenseApp.DoPassedTest(IDLocal, IDTest))
            {
                MessageBox.Show("Person already Passed test, You cannot add new appointment .", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            infoTest.trial=dataGridView1.Rows.Count;
            infoTest.LID = IDLocal;
            infoTest.testMode = infoTest.TestMode.Add;
            Form frm = new ScheduleTest ();
            frm.ShowDialog();

            dataGridView1.DataSource = clsLocalDrivingLicenseApp.GetAppointments(IDLocal, IDTest);
        }

        private void editDateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
           
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            editDateToolStripMenuItem.Enabled = true;
            takeTestToolStripMenuItem.Enabled = true;
            if (clsLocalDrivingLicenseApp.AppointmentIsLockedByAppointmentID(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value)))
            {
                editDateToolStripMenuItem.Enabled = false;
                takeTestToolStripMenuItem.Enabled=false;
            }
        }

        private void editDateToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            infoTest.AppointmentIDEdit = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            infoTest.testMode = infoTest.TestMode.Edit;
            infoTest.LID = IDLocal;
            Form form = new ScheduleTest();
            form.ShowDialog();

            dataGridView1.DataSource = clsLocalDrivingLicenseApp.GetAppointments(IDLocal, IDTest);
            dataGridView1.Columns[1].Width = 265;
        }

        private void takeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TakeTest.AppointmentID = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            Form frm=new TakeTest();
            frm.ShowDialog();
            dataGridView1.DataSource= clsLocalDrivingLicenseApp.GetAppointments(IDLocal, IDTest);
        }
    }
}
