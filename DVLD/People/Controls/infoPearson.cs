using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_Buisness;
using Entity;
namespace DVLD.People.Controls
{
    public partial class infoPearson : UserControl
    {
        public static string CurrentID;

        public infoPearson()
        {
            InitializeComponent();
        }
        public static int personID {  get; set; }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        public  enum Mode
        {
            Add,
                Edit,
                ShowDetailes
        }
       public static Mode mode= Mode.Add;
        string PathImage = "";
        private void infoPearson_Load(object sender, EventArgs e)
        {
            LinkRemove.Visible = false;
            LinkEdit.Visible = false;
            Load_Countries();
            GetPerson();
            

        }
        public void GetPerson()
        {

            if (mode == Mode.Edit || mode == Mode.ShowDetailes)
            {
                Entity.People person = clsPeople.GetPerson(Convert.ToInt32(CurrentID));
                if (person != null)
                {
                    ID.Text = person.PersonID.ToString();
                    tNational.Text = person.NationalNo;
                    tFirst.Text = person.FirstName;
                    tSecond.Text = person.SecondName;
                    tThrid.Text = person.ThirdName;
                    tLast.Text = person.LastName;
                    dateTimePicker1.Value = person.DateOfBirth;
                    if (person.Gendor == 0) rMale.Checked = true; else rFemale.Checked = true;
                    tAddress.Text = person.Address;
                    tPhone.Text = person.Phone;
                    tEmail.Text = person.Email;
                    ComboCountry.SelectedValue = person.NationalityCountryID;
                    if (person.ImagePath != "")
                    {
                        try
                        {
                            pictureBox1.Image = Image.FromFile(person.ImagePath);
                            PathImage = person.ImagePath;
                            if (mode == Mode.Edit) LinkRemove.Visible = true;

                        }
                        catch
                        {
                            pictureBox1.Image = Properties.Resources.user_data;
                            PathImage = "";
                        }
                    }
                    else
                    {
                        pictureBox1.Image = Properties.Resources.user_data;
                        PathImage = "";
                    }

                    if (mode == Mode.ShowDetailes)
                    {
                        Disable();
                        foreach (Control ctrl in groupBox1.Controls)
                        {
                            if (ctrl.Name == "LinkEdit")
                            {
                                ctrl.Visible = true;

                                ctrl.Enabled = true;
                            }
                            if (ctrl.Name == "linkSet") ctrl.Visible = false;
                        }
                    }
                }
            }
        }
        private void Load_Countries()
        {
            DataTable dt = clsCountry.GetAllCountries();

            ComboCountry.DataSource = dt;           // ربط البيانات مباشرة بالـComboBox
            ComboCountry.DisplayMember = "CountryName";  // العمود اللي يظهر للمستخدم
            ComboCountry.ValueMember = "CountryID";      // العمود اللي يمثل القيمة (الـID)
            ComboCountry.SelectedIndex = 0;
        }

        private void AddPerson()
        {
            Entity.People person = null;
            int gendor = (rMale.Checked) ? 0 : 1;
            int Country = Convert.ToInt32(ComboCountry.SelectedValue);

            person = new Entity.People(tNational.Text, tFirst.Text, tSecond.Text, tThrid.Text, tLast.Text, dateTimePicker1.Value,
           gendor, tAddress.Text, tPhone.Text, tEmail.Text, Country, PathImage);
           personID = DVLD_Buisness.clsPeople.AddPerson(person);
            ID.Text = personID.ToString();
            MessageBox.Show("Person Added Successfully with ID: " + personID);
            ID.Text = personID.ToString();


        }

        public void Edit()
        {
            int countryID = Convert.ToInt32(ComboCountry.SelectedValue);
            int Gendor = rMale.Checked ? 0 : 1;
            bool result;
            
                result = clsPeople.EditPerson(new Entity.People( Convert.ToInt32(ID.Text),tNational.Text,
                    tFirst.Text,
                    tSecond.Text,
                    tThrid.Text,
                    tLast.Text,
                    dateTimePicker1.Value, Gendor,
                   tAddress.Text, tPhone.Text, tEmail.Text, countryID, PathImage
                   ));
          
            if (result) MessageBox.Show("Person Edited Successfully");
            else MessageBox.Show("Person Edited Vailed");

        }
        private void Close_Click(object sender, EventArgs e)
        {
            this.FindForm().Close();
        }

        private void Apply_Save()
        {
            if (mode == Mode.Add)
            {
              AddPerson();
                Disable();
            }
            else if (mode == Mode.Edit)
            {
                Edit();
                Disable();

            }
            else 
            {

            }
        }
        private void Disable()
        {
          
            foreach (Control ctrl in groupBox1.Controls)
            {
                ctrl.Enabled = false;
                if (ctrl.Text=="Close")
                    ctrl.Enabled = true;
            }

        }
        private void linkSet_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
           PathImage= clsGlobal.OpenFileDialogChooseImage();
            if (PathImage != "")
            {
                pictureBox1.Image = Image.FromFile(PathImage);
                clsGlobal.SaveImageInFolderImages(PathImage);
                LinkRemove.Visible = true; 
            }
        }

        private void LinkRemove_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pictureBox1.Image = Properties.Resources.user_data;
            PathImage = "";
        }

        private void Save_Click(object sender, EventArgs e)
        {
            Apply_Save();
        }

        private void tNational_Validating(object sender, CancelEventArgs e)
        {
            bool result=clsPeople.CheckNational(tNational.Text);
            if (result)
            {
                e.Cancel = true;
                errorProvider1.SetError(tNational, "Error! the National is found Enter Else National .");
            }

        }

        private void tNational_TextChanged(object sender, EventArgs e)
        {

        }

        private void LinkEdit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form form = new Add_Edit_People();
            mode = Mode.Edit;
            form.Show();
        }
        //Info Person With Filter
        public void RemoveSomeControlsfromControl()
        {
            foreach (Control ctrl in groupBox1.Controls)
            {
                if ( ctrl.Name == "linkSet" || ctrl.Name == "Close" || ctrl.Name == "Save")
                {
                    ctrl.Visible = false;
                }
            }
        }

        public void ClearControls()
        {
            foreach (Control ctrl in groupBox1.Controls)
            {
                if (ctrl is TextBox)
                    ((TextBox)ctrl).Text = "";
                else if (ctrl is ComboBox)
                    ((ComboBox)ctrl).SelectedIndex = 0;
                else if (ctrl is CheckBox)
                    ((CheckBox)ctrl).Checked = false;
                else if(ctrl.Name== "LinkEdit")
                    ctrl.Enabled = false;
            }
            ID.Text = "????";
            personID = 0;
            CurrentID = "0";
        }
    }
}
