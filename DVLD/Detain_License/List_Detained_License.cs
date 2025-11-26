using DVLD.International_License;
using DVLD.LocalDrivingLicenseApplications_View;
using DVLD.People;
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

namespace DVLD.Detain_License
{
    public partial class List_Detained_License : Form
    {
        public List_Detained_License()
        {
            InitializeComponent();
        }

        private void Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void List_Detained_License_Load(object sender, EventArgs e)
        {

            dataGridView1.DataSource = clsDetainLicense.GetAllDetainedLicenses();
            dataGridView1.Columns[6].Width = 250;
            dataGridView1.Columns[8].Width = 150;
            // خلفية الجدول
            dataGridView1.BackgroundColor = Color.White;

            // الصفوف
            dataGridView1.RowsDefaultCellStyle.BackColor = Color.FromArgb(204, 255, 204);          // أخضر فاتح جدًا
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(230, 255, 230); // أفتح درجة

            // لون النصوص
            dataGridView1.DefaultCellStyle.ForeColor = Color.DarkGreen;
            dataGridView1.DefaultCellStyle.Font = new Font("Tahoma", 10, FontStyle.Regular);

            // رأس الأعمدة
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(153, 255, 153); // أخضر متوسط فاتح
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.DarkGreen;
            dataGridView1.EnableHeadersVisualStyles = false;


            // حدود الجدول
            dataGridView1.GridColor = Color.FromArgb(red: 180, 255, 180);
            comboBox1.Items.AddRange(new string[]
            {
                "None",
                "DetainID",
                "LicenseID",
                "DriverID",
                "FineFees",
                "Name",
                "NationalNo",
                "IsReleased"
            });
            comboBox1.SelectedIndex = 0;
            bool isReleased = clsDetainLicense.DoReleaseDetaintedLicenses(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value));
            if (isReleased == true)
            {
                releaseDetainedLicenseToolStripMenuItem.Enabled = false;
            }
            else
            {
                releaseDetainedLicenseToolStripMenuItem.Enabled = true;
            }
        }

        private void Detain_Click(object sender, EventArgs e)
        {
            Form frm = new New_Detain_License();
            frm.Show();

        }

        private void release_Click(object sender, EventArgs e)
        {
            Form frm = new ReleaseLicense();
            frm.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                Filter.Visible = false;
            }
            else
            {
                Filter.Visible = true;
            }
        }

        private void Filter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (comboBox1.Text != "Name" && comboBox1.Text != "NationalNo")
            {
                //only numbers for ID columns
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }

        private void Filter_TextChanged(object sender, EventArgs e)
        {
            string filter = "";
            if (dataGridView1.DataSource == null) return;
            if (Filter.Text == "")
            {
                (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = "";
                return;

            }
            if (comboBox1.Text != "Name" && comboBox1.Text != "NationalNo")
            {
                filter = $"{comboBox1.Text}={Filter.Text}";
            }
            else
            {
                filter = $"{comboBox1.Text} like '%{Filter.Text}%'";
            }
            (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = filter;
        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            infoPearson.mode = infoPearson.Mode.ShowDetailes;
            infoPearson.CurrentID = clsLicense.GetPersonIDByLicensesID(Convert.ToInt32(dataGridView1.CurrentRow.Cells[1].Value.ToString())).ToString();
            Form form = new Add_Edit_People();
            form.Show();
        }

        private void showLicenseDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new ShowLicenseDetails(Convert.ToInt16(dataGridView1.CurrentRow.Cells[1].Value.ToString()));
            frm.Show();
        }

        private void showToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form form = new ShowLicenseHistory(clsLicense.GetPersonIDByLicensesID(int.Parse(dataGridView1.CurrentRow.Cells[1].Value.ToString())));
            form.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {

        }

        private void releaseDetainedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new ReleaseLicense(Convert.ToInt32(dataGridView1.CurrentRow.Cells[1].Value));
            frm.ShowDialog();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            bool isReleased = clsDetainLicense.DoReleaseDetaintedLicenses(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value));
            if(isReleased == true)
            {
                releaseDetainedLicenseToolStripMenuItem.Enabled = false;
            }
            else
            {
                releaseDetainedLicenseToolStripMenuItem.Enabled = true;
            }
        }
    }
}
