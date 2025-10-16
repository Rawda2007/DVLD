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
    public partial class Mangement_Application_Types : Form
    {
        public Mangement_Application_Types()
        {
            InitializeComponent();
        }

        private void Mangement_Application_Types_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = clsAppliction_Type.GetAllApplicationTypes();
            dataGridView1.Columns[1].Width = 450;


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

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = clsAppliction_Type.GetAllApplicationTypes();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void editApplicaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new Edit_Application_Types(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value));
            frm.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
