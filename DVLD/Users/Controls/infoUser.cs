using DVLD.People.Controls;
using DVLD_Buisness;
using Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Users.Controls
{
    public partial class infoUser : UserControl
    {
        public infoUser()
        {
            InitializeComponent();
        }

        private void infoUser_Load(object sender, EventArgs e)
        {
            if (DesignMode) return; // يمنع التنفيذ في وضع التصميم

            // تأكدي إن infoPearson1 جاهز قبل الاستخدام
            if (infoPearson1 == null)
                return;

            infoPearson1.GetPerson();

            // تأكدي إن الشخص فعلاً تم جلبه قبل النداء على GetUserByPersonID
            if (infoPearson.personID == 0)
                return;

            User entity = clsUser.GetUserByPersonID(infoPearson.personID);

            if (entity != null)
            {
                UserName.Text = entity.UserName;
                UserID.Text = entity.UserID.ToString();
                Active.Text = (entity.IsActive == 1) ? "Yes" : "No";
            }
            infoPearson1.RemoveSomeControlsfromControl();
        }
        private void infoPearson1_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
