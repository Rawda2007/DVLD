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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace DVLD.Users
{
    public partial class Mangement_Users : Form
    {
        public Mangement_Users()
        {
            InitializeComponent();
            comboBox1.Items.AddRange(new string[]
            {
                "None",
                "UserID",
                "PersonID",
                "UserName",
                "Password",
                "IsActive"
                });
            comboBox1.SelectedIndex = 0; // اختيار أول عنصر افتراضيًا
            Filter.Visible = false;
        }
        private DataTable allUsers = clsUser.GetAllUsers();

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Mangement_Users_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = allUsers;
            //dataGridView1.ContextMenuStrip = contextMenuStrip1;

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
            dataGridView1.GridColor = Color.FromArgb(180, 255, 180);  // خطوط ناعمة بنفس درجة اللون

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.SelectedItem.ToString() == "None")
            {
                Filter.Visible = false;
                Filter.Text = "";
                dataGridView1.DataSource = clsUser.GetAllUsers();
            }
            else
            {
                Filter.Visible = true;
            }
        }

        private void ApplyFilter()
        {
            if(allUsers == null) return;
            if (string.IsNullOrWhiteSpace(Filter.Text))
            {
                allUsers.DefaultView.RowFilter = "";
                dataGridView1.DataSource = allUsers;
                return;
            }
            string filter = "";
            string column = comboBox1.SelectedItem.ToString();
            string text = Filter.Text;

            if (comboBox1.Text == "UserID" || comboBox1.Text == "PersonID" || comboBox1.Text == "IsActive")

            {
                filter = $"{column}={text}";
            }
            else if (comboBox1.Text == "None") filter = "";
            else
            {
                filter = $"{column} LIKE '%{text.Replace("'", "''")}%'";
            }
            allUsers.DefaultView.RowFilter = filter;
            dataGridView1.DataSource = allUsers;
        }
        private void Filter_TextChanged(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        private void Filter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(comboBox1.Text== "UserID"||comboBox1.Text== "PersonID"||comboBox1.Text=="IsActive")
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true; // يمنع الإدخال
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            infoPearson.personID = 0;
            infoPearson.CurrentID = "0";
            infoPersonWithFilter.CurrentMode = infoPersonWithFilter.mode.Add;
            Form frm = new Add_Edit_User();
            frm.Show();
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = clsUser.GetAllUsers();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you sure to delete this User ?","Confirm",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
            {
                if(clsUser.DoPersonIdConnectecedToUser(Convert.ToInt32( dataGridView1.CurrentRow.Cells["UserID"].Value.ToString())))
                {
                    MessageBox.Show("This Person Connected to User , You can't delete this User ","Failed",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    MessageBox.Show("User Deleted Successfully ");
                }
            }
        }

        private  void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            infoPersonWithFilter.CurrentMode = infoPersonWithFilter.mode.Update;
            infoPearson.personID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["PersonID"].Value.ToString());
            infoPearson.CurrentID = dataGridView1.CurrentRow.Cells["PersonID"].Value.ToString();
            Form frm = new Add_Edit_User();
            frm.Show();
        }

        private void addNewPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            infoPearson.personID = 0;
            infoPearson.CurrentID = "0";
            infoPersonWithFilter.CurrentMode = infoPersonWithFilter.mode.Add;
            Form frm = new Add_Edit_User();
            frm.Show();
        }

        private void showDetailesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            infoPearson.mode = infoPearson.Mode.ShowDetailes;   
            infoPearson.personID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["PersonID"].Value.ToString());
            infoPearson.CurrentID = dataGridView1.CurrentRow.Cells["PersonID"].Value.ToString();
            Form frm = new show_Detailes_User();
            frm.Show();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            infoPearson.mode = infoPearson.Mode.ShowDetailes;
            infoPearson.personID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["PersonID"].Value.ToString());
            infoPearson.CurrentID = dataGridView1.CurrentRow.Cells["PersonID"].Value.ToString();
            Form frm = new Change_Password();
            frm.Show();
        }
    }
}
