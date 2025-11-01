using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD.LocalDrivingLicenseApplications_View.Control;
using DVLD_Buisness;
namespace DVLD.LocalDrivingLicenseApplications_View
{
    public partial class LocalDriving : Form
    {
        public LocalDriving()
        {
            InitializeComponent();
        }
        DataTable allUsers = clsLocalDrivingLicenseApp.GetAllDatabase();
        private void LocalDriving_Load(object sender, EventArgs e)
        {
            dataGridView2.DataSource = clsLocalDrivingLicenseApp.GetAllDatabase();
            dataGridView2.Columns[1].Width = 300;
            dataGridView2.Columns[3].Width = 320;
            dataGridView2.BackgroundColor = Color.White;

            // الصفوف
            dataGridView2.RowsDefaultCellStyle.BackColor = Color.FromArgb(204, 255, 204);          // أخضر فاتح جدًا
            dataGridView2.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(230, 255, 230); // أفتح درجة

            // لون النصوص
            dataGridView2.DefaultCellStyle.ForeColor = Color.DarkGreen;
            dataGridView2.DefaultCellStyle.Font = new Font("Tahoma", 10, FontStyle.Regular);

            // رأس الأعمدة
            dataGridView2.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(153, 255, 153); // أخضر متوسط فاتح
            dataGridView2.ColumnHeadersDefaultCellStyle.ForeColor = Color.DarkGreen;
            dataGridView2.EnableHeadersVisualStyles = false;

            // حدود الجدول
            dataGridView2.GridColor = Color.FromArgb(180, 255, 180);  //
            comboBox1.Items.AddRange(new string[]
            {
                "None",
                "LDLAppID",
                "FullName",
                "NationalNo"
                ,"Satatus"
            });
            comboBox1.SelectedIndex = 0;
            Filter.Visible = false;



        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form frm = new NewLocalDrivingLincese();
            frm.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() == "None")
            {
                Filter.Visible = false;
                Filter.Text = "";
                dataGridView2.DataSource = clsLocalDrivingLicenseApp.GetAllDatabase();
            }
            else
            {
                Filter.Visible = true;
            }
        }

        private void Filter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (comboBox1.Text == "LDLAppID")
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true; // يمنع الإدخال
                }
            }
        }

        private void ApplyFilter()
        {
            if (allUsers == null) return;
            if (string.IsNullOrWhiteSpace(Filter.Text))
            {
                allUsers.DefaultView.RowFilter = "";
                dataGridView2.DataSource = allUsers;
                return;
            }
            string filter = "";
            string column = comboBox1.SelectedItem.ToString();
            string text = Filter.Text;

            if (comboBox1.Text == "LDLAppID")

            {
                filter = $"{column}={text}";
            }
            else if (comboBox1.Text == "None") filter = "";
            else
            {
                filter = $"{column} LIKE '%{text.Replace("'", "''")}%'";
            }
            allUsers.DefaultView.RowFilter = filter;
            dataGridView2.DataSource = allUsers;
        }
        private void Filter_TextChanged(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void canselApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to cancel this application ?", "cansel Application", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            bool result = clsLocalDrivingLicenseApp.CancelLocalDriving(Convert.ToInt32(dataGridView2.CurrentRow.Cells[0].Value));
            if (result)
            {
                MessageBox.Show("The application has been canceled successfully");
            }
        }

        private void refrashToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView2.DataSource = clsLocalDrivingLicenseApp.GetAllDatabase();
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            infoDrivingLicenseApp.DLAppID = Convert.ToInt32(dataGridView2.CurrentRow.Cells[0].Value);
            Test.IDLocal = Convert.ToInt32(dataGridView2.CurrentRow.Cells[0].Value);
            infoTest.LID = Convert.ToInt32(dataGridView2.CurrentRow.Cells[0].Value);


            Test.IDTest = 1;
            infoTest.typeTest = infoTest.TypeTest.Vision;
            Form frm = new Test();
            frm.ShowDialog();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //ContexMenuStrip Enable
            int LocalID = Convert.ToInt32(dataGridView2.SelectedRows[0].Cells[0].Value);
            int TestTypeID = clsLocalDrivingLicenseApp.GetTestTypeIDByLocalID(LocalID);
            cVisionTest.Enabled = false;
            cWrittenTest.Enabled = false;
            cStreetTest.Enabled = false;
            cIssueDriving.Enabled = false;
            cShowLicense.Enabled = false;
            toolStripMenuItem1.Enabled = true;
            toolStripMenuItem2.Enabled = true;
            toolStripMenuItem3.Enabled = true;
            canselApplicationToolStripMenuItem.Enabled = true;
            if (dataGridView2.CurrentRow.Cells["Status"].Value.ToString() == "Cancelled")
            {
                toolStripMenuItem1.Enabled = false;
                toolStripMenuItem2.Enabled = false;
                toolStripMenuItem3.Enabled = false;
                canselApplicationToolStripMenuItem.Enabled = false;

                return;
            }
            if (dataGridView2.CurrentRow.Cells["Status"].Value.ToString() == "Completed")
            {
                toolStripMenuItem1.Enabled = false;
                toolStripMenuItem2.Enabled = false;
                toolStripMenuItem3.Enabled = false;
                canselApplicationToolStripMenuItem.Enabled = false;
                cShowLicense.Enabled = true;
                return;
            }
            switch (TestTypeID)
            {
                case 1:
                    cVisionTest.Enabled = true;
                    break;
                case 2:
                    cWrittenTest.Enabled = true;
                    break;
                case 3:
                    cStreetTest.Enabled = true;
                    break;
                case 4:
                    cIssueDriving.Enabled = true;
                    break;

                default:
                    break;
            }
        }

        private void cWrittenTest_Click(object sender, EventArgs e)
        {
            infoDrivingLicenseApp.DLAppID = Convert.ToInt32(dataGridView2.CurrentRow.Cells[0].Value);
            Test.IDLocal = Convert.ToInt32(dataGridView2.CurrentRow.Cells[0].Value);
            infoTest.LID = Convert.ToInt32(dataGridView2.CurrentRow.Cells[0].Value);

            Test.IDTest = 2;
            infoTest.typeTest = infoTest.TypeTest.Writing;
            Form frm = new Test();
            frm.ShowDialog();
        }

        private void cStreetTest_Click(object sender, EventArgs e)
        {
            //infoDrivingLicenseApp.DLAppID = Convert.ToInt32(dataGridView2.CurrentRow.Cells[0].Value);
            //Test.IDLocal = Convert.ToInt32(dataGridView2.CurrentRow.Cells[0].Value);
            //infoTest.LID = Convert.ToInt32(dataGridView2.CurrentRow.Cells[0].Value);


            //Test.IDTest = 1;
            //infoTest.typeTest = infoTest.TypeTest.Vision;
            //Form frm = new Test();
            //frm.ShowDialog();


            infoDrivingLicenseApp.DLAppID = Convert.ToInt32(dataGridView2.CurrentRow.Cells[0].Value);
            Test.IDLocal = Convert.ToInt32(dataGridView2.CurrentRow.Cells[0].Value);
            infoTest.LID = Convert.ToInt32(dataGridView2.CurrentRow.Cells[0].Value);
            Test.IDTest = 3;
            infoTest.typeTest = infoTest.TypeTest.Street;
            Form frm = new Test();
            frm.ShowDialog();
        }

        private void cIssueDriving_Click(object sender, EventArgs e)
        {
            IssueDriver.LDAppID = Convert.ToInt32(dataGridView2.CurrentRow.Cells[0].Value);
            IssueDriver.ClassName = dataGridView2.CurrentRow.Cells[1].Value.ToString();
            IssueDriver.National = dataGridView2.CurrentRow.Cells[2].Value.ToString();
            infoDrivingLicenseApp.DLAppID = Convert.ToInt32(dataGridView2.CurrentRow.Cells[0].Value);
            Form frm = new IssueDriver();
            frm.ShowDialog();
        }

        private void cShowLicense_Click(object sender, EventArgs e)
        {
            infoShowLicense.NationalNo = dataGridView2.CurrentRow.Cells[2].Value.ToString();
            infoShowLicense.ClassName = dataGridView2.CurrentRow.Cells[1].Value.ToString();
            infoShowLicense.FullName = dataGridView2.CurrentRow.Cells[3].Value.ToString();
            Form frm = new Show_License();
            frm.ShowDialog();
        }
    }
}
