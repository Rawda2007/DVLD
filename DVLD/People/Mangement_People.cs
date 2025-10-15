using DVLD.People.Controls;
using DVLD_Buisness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.People
{
    public partial class Mangement_People : Form
    {
        DataTable allPeople = clsPeople.GetAllPeople();

        public Mangement_People()
        {
            InitializeComponent();
            //Filter combo box
            comboBox1.Items.AddRange(new string[]
    {
        "None",
        "PersonID",
        "FirstName",
        "SecondName",
        "ThirdName",
        "LastName",
        "Nationality",
        "Phone",
        "Email"
    });
            comboBox1.SelectedIndex = 0; // اختيار أول عنصر افتراضيًا

        }

        private void Mangement_People_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = clsPeople.GetAllPeople();
            dataGridView1.ContextMenuStrip = contextMenuStrip1;

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

        private void button1_Click(object sender, EventArgs e)
        {
            infoPearson.mode = infoPearson.Mode.Add;
            Form form = new Add_Edit_People ();
            form.Show();
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = clsPeople.GetAllPeople();

        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool result=false;
            if (MessageBox.Show("Are you sure you want to delete this person?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            { 
                result= clsPeople.DeletePerson(int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString())); 
         
                if(!result)
            {
                MessageBox.Show("Error Deleting Person Because Connect by Database else");
            }
            else
            {
                MessageBox.Show("Person Deleted Successfully");
                dataGridView1.DataSource = clsPeople.GetAllPeople();
            }
            }
          
        }

        private void addNewPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            infoPearson.mode = infoPearson.Mode.Add;
            Form form = new Add_Edit_People();
            form.Show();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            infoPearson.mode = infoPearson.Mode.Edit;
            infoPearson.CurrentID = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            Form form = new Add_Edit_People();
            form.Show();
        }

        private void showDetailesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            infoPearson.mode = infoPearson.Mode.ShowDetailes;
            infoPearson.CurrentID = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            Form form = new Add_Edit_People();
            form.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.Text == "None")
            {
                Filter.Visible = false;
                Filter.Text = "";
            }
            else
            {
                Filter.Visible = true;
                Filter.Text = "";
                Filter.Focus();
            }
        }
        private void ApplyFilter()
        {
            if (allPeople == null) return;

            string column = comboBox1.Text;
            string text = Filter.Text;

            if (string.IsNullOrWhiteSpace(text))
            {
                // لو فاضي رجعي كل البيانات
                (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = "";
                return;
            }
          
            // استخدمي LIKE للبحث الجزئي
            string filter = "";

            // لو العمود رقم (مثل PersonID) نبحث بدون علامات اقتباس
            if (column == "None")
            {
                filter = "";
            }
            else if (column == "PersonID")
                filter = $"{column} = {text}";
            else
                filter = $"{column} LIKE '%{text.Replace("'", "''")}%'";

            (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = filter;
        }

        private void Filter_TextChanged(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        private void Filter_Validating(object sender, CancelEventArgs e)
        {
           
        }

        private void Filter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (comboBox1.Text == "PersonID")
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true; // يمنع الإدخال
                }
            }
        }

        private void Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }
    }
}
