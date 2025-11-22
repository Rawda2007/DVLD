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
using static System.Net.Mime.MediaTypeNames;
namespace DVLD.International_License
{
    public partial class International_License : Form
    {
        public International_License()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void International_License_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = clsInternationalLicense.GetAllDatabase();
            dataGridView1.Columns[4].Width = 142;
            dataGridView1.Columns[5].Width = 142;
            dataGridView1.ContextMenuStrip = contextMenuStrip1;
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
            dataGridView1.GridColor = Color.FromArgb(180, 255, 180);  // خطوط ناعمة بنفس درجة اللون
            comboBox1.Items.AddRange(new string[]
            {
                "None",
                "InternationalLicenseID",
                "ApplicationID",
                "DriverID",
                "IssuedUsingLocalLicenseID",
                "IsActive"

            }); 
            comboBox1.SelectedIndex = 0;
            Filter.Visible = false;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.SelectedIndex == 0)
            {
                Filter.Visible = false;
                dataGridView1.DataSource = clsInternationalLicense.GetAllDatabase();
            }
            else
            {
                Filter.Visible = true;
            }
        }

        private void Filter_KeyPress(object sender, KeyPressEventArgs e)
        {
            //only numbers for ID columns
            
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            
        }

        private void Filter_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Filter.Text))
            {
                // لو فاضي رجعي كل البيانات
                (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = "";
                return;
            }
            string filter = $"{comboBox1.Text}={Filter.Text}";
            (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = filter;
        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            infoPearson.mode = infoPearson.Mode.ShowDetailes;
            infoPearson.CurrentID = clsApplication.GetPersonIDByApplicationID(int.Parse(dataGridView1.CurrentRow.Cells[1].Value.ToString())).ToString();
            Form form = new Add_Edit_People();
            form.Show();
        }

        private void showToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form form = new ShowLicenseHistory(clsApplication.GetPersonIDByApplicationID(int.Parse(dataGridView1.CurrentRow.Cells[1].Value.ToString())));
            form.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form frm = new New_International_License();
            frm.ShowDialog();
        }

        private void showLicenseDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm =new ShowLicenseDetails(Convert.ToInt16(dataGridView1.CurrentRow.Cells[3].Value.ToString()));
            frm.Show();
        }
    }
}
