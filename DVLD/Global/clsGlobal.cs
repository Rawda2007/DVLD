using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD
{
    public class clsGlobal
    {
        public static void RemmberUserNameAndPassword(string UserName, string password)
        {
            Properties.Settings.Default.UserName = UserName;
            Properties.Settings.Default.Password = password;
            Properties.Settings.Default.RemmberMe = true;
            Properties.Settings.Default.Save();
        }

        public static void NotRemmberUserNameAndPassword()
        {
            Properties.Settings.Default.UserName = "";
            Properties.Settings.Default.Password = "";
            Properties.Settings.Default.RemmberMe = false;
            Properties.Settings.Default.Save();
        }

        public static void GetStoredUserNameandPassword(ref string user, ref string password)
        {
            user = Properties.Settings.Default.UserName;
            password = Properties.Settings.Default.Password.ToString();

        }

        public static void SaveImageInFolderImages(string originalPath)
        {
            // إنشاء مجلد Images داخل برنامجك
            string folderPath = Path.Combine(Application.StartupPath, "Images");
            Directory.CreateDirectory(folderPath);

            // اسم الملف فقط
            string fileName = Path.GetFileName(originalPath);

            // مسار الصورة الجديد
            string destPath = Path.Combine(folderPath, fileName);

            // نسخ الصورة للمجلد
            File.Copy(originalPath, destPath, true);

        }

        public static string OpenFileDialogChooseImage()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Choose Image !";
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp ";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                return openFileDialog.FileName;
            }
            return "";
        }
    }
}