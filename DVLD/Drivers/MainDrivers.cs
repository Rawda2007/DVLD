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

namespace DVLD.Drivers
{
    public partial class MainDrivers : Form
    {
        public MainDrivers()
        {
            InitializeComponent();
            comboBox1.Items.AddRange(new string[]
            {
                "none",
                "DriverID",
                "PersonID",
                "NationalNo",
                "FullName",
            });
            comboBox1.SelectedIndex = 0;
        }
        DataTable AllDriver = clsDriver.GetAllDrivers();

        private void MainDrivers_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource =AllDriver;
            dataGridView1.Columns[3].Width = 300;
            dataGridView1.Columns[4].Width = 140;
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
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.Text == "none")
            {
                Filter.Visible = false;
                dataGridView1.DataSource = clsDriver.GetAllDrivers();
                return;
            }
            else
            {
                               Filter.Visible = true;
            }
        }

        private void Filter_TextChanged(object sender, EventArgs e)
        {
            if (AllDriver == null) return;
            if (string.IsNullOrWhiteSpace(Filter.Text))
            {
                AllDriver.DefaultView.RowFilter = "";
                dataGridView1.DataSource = AllDriver;
                return;
            }
            string filter = "";
            string column = comboBox1.SelectedItem.ToString();
            string text = Filter.Text;

            if (comboBox1.Text == "DriverID"|| comboBox1.Text == "PersonID")

            {
                filter = $"{column}={text}";
            }
            else if (comboBox1.Text == "None") filter = "";
            else
            {
                filter = $"{column} LIKE '%{text.Replace("'", "''")}%'";
            }
            AllDriver.DefaultView.RowFilter = filter;
            dataGridView1.DataSource = AllDriver;
        }

        private void Filter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (comboBox1.Text == "PersonID"|| comboBox1.Text == "DriverID")
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true; // يمنع الإدخال
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
