namespace DVLD.People.Controls
{
    partial class infoPearson
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.LinkEdit = new System.Windows.Forms.LinkLabel();
            this.LinkRemove = new System.Windows.Forms.LinkLabel();
            this.ID = new System.Windows.Forms.TextBox();
            this.PersonID = new System.Windows.Forms.Label();
            this.Save = new System.Windows.Forms.Button();
            this.Close = new System.Windows.Forms.Button();
            this.linkSet = new System.Windows.Forms.LinkLabel();
            this.tPhone = new System.Windows.Forms.TextBox();
            this.rFemale = new System.Windows.Forms.RadioButton();
            this.rMale = new System.Windows.Forms.RadioButton();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.ComboCountry = new System.Windows.Forms.ComboBox();
            this.tEmail = new System.Windows.Forms.TextBox();
            this.tAddress = new System.Windows.Forms.TextBox();
            this.tNational = new System.Windows.Forms.TextBox();
            this.tLast = new System.Windows.Forms.TextBox();
            this.tThrid = new System.Windows.Forms.TextBox();
            this.tSecond = new System.Windows.Forms.TextBox();
            this.tFirst = new System.Windows.Forms.TextBox();
            this.Last = new System.Windows.Forms.Label();
            this.Second = new System.Windows.Forms.Label();
            this.Third = new System.Windows.Forms.Label();
            this.First = new System.Windows.Forms.Label();
            this.Country = new System.Windows.Forms.Label();
            this.DateOfBirth = new System.Windows.Forms.Label();
            this.Phone = new System.Windows.Forms.Label();
            this.Address = new System.Windows.Forms.Label();
            this.National = new System.Windows.Forms.Label();
            this.Gendor = new System.Windows.Forms.Label();
            this.Email = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.LinkEdit);
            this.groupBox1.Controls.Add(this.LinkRemove);
            this.groupBox1.Controls.Add(this.ID);
            this.groupBox1.Controls.Add(this.PersonID);
            this.groupBox1.Controls.Add(this.Save);
            this.groupBox1.Controls.Add(this.Close);
            this.groupBox1.Controls.Add(this.linkSet);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.tPhone);
            this.groupBox1.Controls.Add(this.rFemale);
            this.groupBox1.Controls.Add(this.rMale);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Controls.Add(this.ComboCountry);
            this.groupBox1.Controls.Add(this.tEmail);
            this.groupBox1.Controls.Add(this.tAddress);
            this.groupBox1.Controls.Add(this.tNational);
            this.groupBox1.Controls.Add(this.tLast);
            this.groupBox1.Controls.Add(this.tThrid);
            this.groupBox1.Controls.Add(this.tSecond);
            this.groupBox1.Controls.Add(this.tFirst);
            this.groupBox1.Controls.Add(this.Last);
            this.groupBox1.Controls.Add(this.Second);
            this.groupBox1.Controls.Add(this.Third);
            this.groupBox1.Controls.Add(this.First);
            this.groupBox1.Controls.Add(this.Country);
            this.groupBox1.Controls.Add(this.DateOfBirth);
            this.groupBox1.Controls.Add(this.Phone);
            this.groupBox1.Controls.Add(this.Address);
            this.groupBox1.Controls.Add(this.National);
            this.groupBox1.Controls.Add(this.Gendor);
            this.groupBox1.Controls.Add(this.Email);
            this.groupBox1.Controls.Add(this.labelName);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.GreenYellow;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(907, 414);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Information Person";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // LinkEdit
            // 
            this.LinkEdit.AutoSize = true;
            this.LinkEdit.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.LinkEdit.Location = new System.Drawing.Point(693, 157);
            this.LinkEdit.Name = "LinkEdit";
            this.LinkEdit.Size = new System.Drawing.Size(160, 28);
            this.LinkEdit.TabIndex = 65;
            this.LinkEdit.TabStop = true;
            this.LinkEdit.Text = "EditInfoPerson";
            this.LinkEdit.Visible = false;
            this.LinkEdit.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkEdit_LinkClicked);
            // 
            // LinkRemove
            // 
            this.LinkRemove.AutoSize = true;
            this.LinkRemove.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.LinkRemove.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.LinkRemove.Location = new System.Drawing.Point(792, 325);
            this.LinkRemove.Name = "LinkRemove";
            this.LinkRemove.Size = new System.Drawing.Size(92, 28);
            this.LinkRemove.TabIndex = 64;
            this.LinkRemove.TabStop = true;
            this.LinkRemove.Text = "Remove";
            this.LinkRemove.Visible = false;
            this.LinkRemove.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkRemove_LinkClicked);
            // 
            // ID
            // 
            this.ID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ID.Enabled = false;
            this.ID.ForeColor = System.Drawing.Color.LightCoral;
            this.ID.Location = new System.Drawing.Point(77, 65);
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Size = new System.Drawing.Size(92, 35);
            this.ID.TabIndex = 63;
            this.ID.Text = "????";
            // 
            // PersonID
            // 
            this.PersonID.AutoSize = true;
            this.PersonID.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PersonID.ForeColor = System.Drawing.Color.LawnGreen;
            this.PersonID.Location = new System.Drawing.Point(18, 36);
            this.PersonID.Name = "PersonID";
            this.PersonID.Size = new System.Drawing.Size(104, 24);
            this.PersonID.TabIndex = 62;
            this.PersonID.Text = "PersonID :";
            // 
            // Save
            // 
            this.Save.BackColor = System.Drawing.Color.White;
            this.Save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Save.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Save.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.Save.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Save.Location = new System.Drawing.Point(797, 359);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(105, 38);
            this.Save.TabIndex = 61;
            this.Save.Text = "Save";
            this.Save.UseVisualStyleBackColor = false;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // Close
            // 
            this.Close.BackColor = System.Drawing.Color.White;
            this.Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Close.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Close.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.Close.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Close.Location = new System.Drawing.Point(665, 359);
            this.Close.Name = "Close";
            this.Close.Size = new System.Drawing.Size(106, 38);
            this.Close.TabIndex = 60;
            this.Close.Text = "Close";
            this.Close.UseVisualStyleBackColor = false;
            this.Close.Click += new System.EventHandler(this.Close_Click);
            // 
            // linkSet
            // 
            this.linkSet.AutoSize = true;
            this.linkSet.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.linkSet.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.linkSet.Location = new System.Drawing.Point(661, 325);
            this.linkSet.Name = "linkSet";
            this.linkSet.Size = new System.Drawing.Size(110, 28);
            this.linkSet.TabIndex = 59;
            this.linkSet.TabStop = true;
            this.linkSet.Text = "SetImage";
            this.linkSet.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkSet_LinkClicked);
            // 
            // tPhone
            // 
            this.tPhone.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.tPhone.Location = new System.Drawing.Point(461, 206);
            this.tPhone.Name = "tPhone";
            this.tPhone.Size = new System.Drawing.Size(200, 35);
            this.tPhone.TabIndex = 57;
            // 
            // rFemale
            // 
            this.rFemale.AutoSize = true;
            this.rFemale.BackColor = System.Drawing.Color.OldLace;
            this.rFemale.ForeColor = System.Drawing.Color.LightGreen;
            this.rFemale.Location = new System.Drawing.Point(193, 192);
            this.rFemale.Name = "rFemale";
            this.rFemale.Size = new System.Drawing.Size(105, 32);
            this.rFemale.TabIndex = 56;
            this.rFemale.TabStop = true;
            this.rFemale.Text = "Female";
            this.rFemale.UseVisualStyleBackColor = false;
            // 
            // rMale
            // 
            this.rMale.AutoSize = true;
            this.rMale.BackColor = System.Drawing.Color.OldLace;
            this.rMale.ForeColor = System.Drawing.Color.LightGreen;
            this.rMale.Location = new System.Drawing.Point(114, 192);
            this.rMale.Name = "rMale";
            this.rMale.Size = new System.Drawing.Size(80, 32);
            this.rMale.TabIndex = 55;
            this.rMale.TabStop = true;
            this.rMale.Text = "Male";
            this.rMale.UseVisualStyleBackColor = false;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CalendarFont = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dateTimePicker1.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Location = new System.Drawing.Point(461, 168);
            this.dateTimePicker1.MaxDate = new System.DateTime(2025, 9, 7, 0, 0, 0, 0);
            this.dateTimePicker1.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 28);
            this.dateTimePicker1.TabIndex = 54;
            this.dateTimePicker1.Value = new System.DateTime(2005, 9, 7, 0, 0, 0, 0);
            // 
            // ComboCountry
            // 
            this.ComboCountry.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ComboCountry.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ComboCountry.FormattingEnabled = true;
            this.ComboCountry.Location = new System.Drawing.Point(461, 247);
            this.ComboCountry.Name = "ComboCountry";
            this.ComboCountry.Size = new System.Drawing.Size(200, 36);
            this.ComboCountry.TabIndex = 53;
            // 
            // tEmail
            // 
            this.tEmail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.tEmail.Location = new System.Drawing.Point(114, 228);
            this.tEmail.Name = "tEmail";
            this.tEmail.Size = new System.Drawing.Size(148, 35);
            this.tEmail.TabIndex = 52;
            // 
            // tAddress
            // 
            this.tAddress.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.tAddress.Location = new System.Drawing.Point(114, 297);
            this.tAddress.Multiline = true;
            this.tAddress.Name = "tAddress";
            this.tAddress.Size = new System.Drawing.Size(547, 100);
            this.tAddress.TabIndex = 51;
            // 
            // tNational
            // 
            this.tNational.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.tNational.Location = new System.Drawing.Point(150, 154);
            this.tNational.Name = "tNational";
            this.tNational.Size = new System.Drawing.Size(126, 35);
            this.tNational.TabIndex = 50;
            this.tNational.TextChanged += new System.EventHandler(this.tNational_TextChanged);
            this.tNational.Validating += new System.ComponentModel.CancelEventHandler(this.tNational_Validating);
            // 
            // tLast
            // 
            this.tLast.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.tLast.Location = new System.Drawing.Point(661, 116);
            this.tLast.Name = "tLast";
            this.tLast.Size = new System.Drawing.Size(148, 35);
            this.tLast.TabIndex = 49;
            // 
            // tThrid
            // 
            this.tThrid.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.tThrid.Location = new System.Drawing.Point(479, 116);
            this.tThrid.Name = "tThrid";
            this.tThrid.Size = new System.Drawing.Size(148, 35);
            this.tThrid.TabIndex = 48;
            // 
            // tSecond
            // 
            this.tSecond.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.tSecond.Location = new System.Drawing.Point(301, 116);
            this.tSecond.Name = "tSecond";
            this.tSecond.Size = new System.Drawing.Size(148, 35);
            this.tSecond.TabIndex = 47;
            // 
            // tFirst
            // 
            this.tFirst.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.tFirst.Location = new System.Drawing.Point(129, 116);
            this.tFirst.Name = "tFirst";
            this.tFirst.Size = new System.Drawing.Size(147, 35);
            this.tFirst.TabIndex = 46;
            // 
            // Last
            // 
            this.Last.AutoSize = true;
            this.Last.ForeColor = System.Drawing.Color.LightGreen;
            this.Last.Location = new System.Drawing.Point(693, 83);
            this.Last.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.Last.Name = "Last";
            this.Last.Size = new System.Drawing.Size(68, 28);
            this.Last.TabIndex = 45;
            this.Last.Text = "Last :";
            // 
            // Second
            // 
            this.Second.AutoSize = true;
            this.Second.ForeColor = System.Drawing.Color.LightGreen;
            this.Second.Location = new System.Drawing.Point(342, 83);
            this.Second.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.Second.Name = "Second";
            this.Second.Size = new System.Drawing.Size(101, 28);
            this.Second.TabIndex = 44;
            this.Second.Text = "Second :";
            // 
            // Third
            // 
            this.Third.AutoSize = true;
            this.Third.ForeColor = System.Drawing.Color.LightGreen;
            this.Third.Location = new System.Drawing.Point(499, 83);
            this.Third.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.Third.Name = "Third";
            this.Third.Size = new System.Drawing.Size(79, 28);
            this.Third.TabIndex = 43;
            this.Third.Text = "Third :";
            // 
            // First
            // 
            this.First.AutoSize = true;
            this.First.ForeColor = System.Drawing.Color.LightGreen;
            this.First.Location = new System.Drawing.Point(175, 83);
            this.First.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.First.Name = "First";
            this.First.Size = new System.Drawing.Size(70, 28);
            this.First.TabIndex = 42;
            this.First.Text = "First :";
            // 
            // Country
            // 
            this.Country.AutoSize = true;
            this.Country.ForeColor = System.Drawing.Color.LightGreen;
            this.Country.Location = new System.Drawing.Point(313, 250);
            this.Country.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.Country.Name = "Country";
            this.Country.Size = new System.Drawing.Size(106, 28);
            this.Country.TabIndex = 41;
            this.Country.Text = "Country :";
            // 
            // DateOfBirth
            // 
            this.DateOfBirth.AutoSize = true;
            this.DateOfBirth.ForeColor = System.Drawing.Color.LightGreen;
            this.DateOfBirth.Location = new System.Drawing.Point(297, 174);
            this.DateOfBirth.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.DateOfBirth.Name = "DateOfBirth";
            this.DateOfBirth.Size = new System.Drawing.Size(156, 28);
            this.DateOfBirth.TabIndex = 40;
            this.DateOfBirth.Text = "Date of Birth :";
            // 
            // Phone
            // 
            this.Phone.AutoSize = true;
            this.Phone.ForeColor = System.Drawing.Color.LightGreen;
            this.Phone.Location = new System.Drawing.Point(313, 209);
            this.Phone.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.Phone.Name = "Phone";
            this.Phone.Size = new System.Drawing.Size(90, 28);
            this.Phone.TabIndex = 39;
            this.Phone.Text = "Phone :";
            // 
            // Address
            // 
            this.Address.AutoSize = true;
            this.Address.ForeColor = System.Drawing.Color.LightGreen;
            this.Address.Location = new System.Drawing.Point(6, 276);
            this.Address.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.Address.Name = "Address";
            this.Address.Size = new System.Drawing.Size(107, 28);
            this.Address.TabIndex = 38;
            this.Address.Text = "Address :";
            // 
            // National
            // 
            this.National.AutoSize = true;
            this.National.ForeColor = System.Drawing.Color.LightGreen;
            this.National.Location = new System.Drawing.Point(6, 161);
            this.National.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.National.Name = "National";
            this.National.Size = new System.Drawing.Size(143, 28);
            this.National.TabIndex = 37;
            this.National.Text = "National No :";
            this.National.Click += new System.EventHandler(this.National_Click);
            // 
            // Gendor
            // 
            this.Gendor.AutoSize = true;
            this.Gendor.ForeColor = System.Drawing.Color.LightGreen;
            this.Gendor.Location = new System.Drawing.Point(6, 196);
            this.Gendor.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.Gendor.Name = "Gendor";
            this.Gendor.Size = new System.Drawing.Size(100, 28);
            this.Gendor.TabIndex = 36;
            this.Gendor.Text = "Gendor :";
            // 
            // Email
            // 
            this.Email.AutoSize = true;
            this.Email.ForeColor = System.Drawing.Color.LightGreen;
            this.Email.Location = new System.Drawing.Point(9, 232);
            this.Email.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.Email.Name = "Email";
            this.Email.Size = new System.Drawing.Size(81, 28);
            this.Email.TabIndex = 35;
            this.Email.Text = "Email :";
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.ForeColor = System.Drawing.Color.LightGreen;
            this.labelName.Location = new System.Drawing.Point(6, 118);
            this.labelName.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(85, 28);
            this.labelName.TabIndex = 34;
            this.labelName.Text = "Name :";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.pictureBox1.Image = global::DVLD.Properties.Resources.id_card__1_;
            this.pictureBox1.Location = new System.Drawing.Point(711, 192);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(127, 130);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 58;
            this.pictureBox1.TabStop = false;
            // 
            // infoPearson
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.groupBox1);
            this.Name = "infoPearson";
            this.Size = new System.Drawing.Size(925, 424);
            this.Load += new System.EventHandler(this.infoPearson_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.LinkLabel LinkEdit;
        private System.Windows.Forms.LinkLabel LinkRemove;
        private System.Windows.Forms.TextBox ID;
        private System.Windows.Forms.Label PersonID;
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.Button Close;
        private System.Windows.Forms.LinkLabel linkSet;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox tPhone;
        private System.Windows.Forms.RadioButton rFemale;
        private System.Windows.Forms.RadioButton rMale;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.ComboBox ComboCountry;
        private System.Windows.Forms.TextBox tEmail;
        private System.Windows.Forms.TextBox tAddress;
        private System.Windows.Forms.TextBox tNational;
        private System.Windows.Forms.TextBox tLast;
        private System.Windows.Forms.TextBox tThrid;
        private System.Windows.Forms.TextBox tSecond;
        private System.Windows.Forms.TextBox tFirst;
        private System.Windows.Forms.Label Last;
        private System.Windows.Forms.Label Second;
        private System.Windows.Forms.Label Third;
        private System.Windows.Forms.Label First;
        private System.Windows.Forms.Label Country;
        private System.Windows.Forms.Label DateOfBirth;
        private System.Windows.Forms.Label Phone;
        private System.Windows.Forms.Label Address;
        private System.Windows.Forms.Label National;
        private System.Windows.Forms.Label Gendor;
        private System.Windows.Forms.Label Email;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}
