namespace DVLD.LocalDrivingLicenseApplications_View
{
    partial class NewLocalDrivingLincese
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.AppFees = new System.Windows.Forms.Label();
            this.TClass = new System.Windows.Forms.ComboBox();
            this.AppDate = new System.Windows.Forms.Label();
            this.CreadedBy = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ID = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.infoPersonWithFilter1 = new DVLD.People.Controls.infoPersonWithFilter();
            this.button3 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.Save = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(0, 1);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1211, 645);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.OldLace;
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.infoPersonWithFilter1);
            this.tabPage1.Location = new System.Drawing.Point(4, 27);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1203, 614);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Personal Information";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.White;
            this.tabPage2.Controls.Add(this.AppFees);
            this.tabPage2.Controls.Add(this.TClass);
            this.tabPage2.Controls.Add(this.AppDate);
            this.tabPage2.Controls.Add(this.CreadedBy);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.ID);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.Save);
            this.tabPage2.Location = new System.Drawing.Point(4, 27);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1203, 614);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Application Information";
            this.tabPage2.Click += new System.EventHandler(this.tabPage2_Click);
            // 
            // AppFees
            // 
            this.AppFees.AutoSize = true;
            this.AppFees.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AppFees.ForeColor = System.Drawing.Color.DarkRed;
            this.AppFees.Location = new System.Drawing.Point(292, 295);
            this.AppFees.Name = "AppFees";
            this.AppFees.Size = new System.Drawing.Size(55, 24);
            this.AppFees.TabIndex = 21;
            this.AppFees.Text = "?????";
            // 
            // TClass
            // 
            this.TClass.FormattingEnabled = true;
            this.TClass.Location = new System.Drawing.Point(281, 234);
            this.TClass.Name = "TClass";
            this.TClass.Size = new System.Drawing.Size(312, 26);
            this.TClass.TabIndex = 20;
            this.TClass.SelectedIndexChanged += new System.EventHandler(this.TClass_SelectedIndexChanged);
            // 
            // AppDate
            // 
            this.AppDate.AutoSize = true;
            this.AppDate.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AppDate.ForeColor = System.Drawing.Color.DarkRed;
            this.AppDate.Location = new System.Drawing.Point(292, 172);
            this.AppDate.Name = "AppDate";
            this.AppDate.Size = new System.Drawing.Size(55, 24);
            this.AppDate.TabIndex = 19;
            this.AppDate.Text = "?????";
            // 
            // CreadedBy
            // 
            this.CreadedBy.AutoSize = true;
            this.CreadedBy.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreadedBy.ForeColor = System.Drawing.Color.DarkRed;
            this.CreadedBy.Location = new System.Drawing.Point(292, 353);
            this.CreadedBy.Name = "CreadedBy";
            this.CreadedBy.Size = new System.Drawing.Size(55, 24);
            this.CreadedBy.TabIndex = 17;
            this.CreadedBy.Text = "?????";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkRed;
            this.label1.Location = new System.Drawing.Point(131, 353);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 24);
            this.label1.TabIndex = 16;
            this.label1.Text = "Created By :";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // ID
            // 
            this.ID.AutoSize = true;
            this.ID.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID.ForeColor = System.Drawing.Color.DarkRed;
            this.ID.Location = new System.Drawing.Point(292, 112);
            this.ID.Name = "ID";
            this.ID.Size = new System.Drawing.Size(55, 24);
            this.ID.TabIndex = 12;
            this.ID.Text = "?????";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.DarkRed;
            this.label5.Location = new System.Drawing.Point(82, 172);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(170, 24);
            this.label5.TabIndex = 11;
            this.label5.Text = "Application Date :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DarkRed;
            this.label4.Location = new System.Drawing.Point(111, 236);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(141, 24);
            this.label4.TabIndex = 10;
            this.label4.Text = "License Class :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DarkRed;
            this.label3.Location = new System.Drawing.Point(84, 295);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(168, 24);
            this.label3.TabIndex = 9;
            this.label3.Text = "Application Fees :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkRed;
            this.label2.Location = new System.Drawing.Point(68, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(184, 24);
            this.label2.TabIndex = 8;
            this.label2.Text = "D.L.Application ID :";
            // 
            // infoPersonWithFilter1
            // 
            this.infoPersonWithFilter1.BackColor = System.Drawing.Color.White;
            this.infoPersonWithFilter1.Location = new System.Drawing.Point(3, 0);
            this.infoPersonWithFilter1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.infoPersonWithFilter1.Name = "infoPersonWithFilter1";
            this.infoPersonWithFilter1.Size = new System.Drawing.Size(1200, 629);
            this.infoPersonWithFilter1.TabIndex = 3;
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.button3.Image = global::DVLD.Properties.Resources.close;
            this.button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.Location = new System.Drawing.Point(1048, 652);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(138, 43);
            this.button3.TabIndex = 5;
            this.button3.Text = "Close";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button1
            // 
            this.button1.ForeColor = System.Drawing.Color.Gray;
            this.button1.Image = global::DVLD.Properties.Resources.right_arrow1;
            this.button1.Location = new System.Drawing.Point(1097, 549);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(52, 43);
            this.button1.TabIndex = 4;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Save
            // 
            this.Save.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Save.ForeColor = System.Drawing.Color.Blue;
            this.Save.Image = global::DVLD.Properties.Resources.bookmark__1_;
            this.Save.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Save.Location = new System.Drawing.Point(1018, 497);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(128, 45);
            this.Save.TabIndex = 3;
            this.Save.Text = "Save";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.Save_Click_1);
            // 
            // NewLocalDrivingLincese
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1209, 700);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "NewLocalDrivingLincese";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "New Local Driving Lincese Application";
            this.Load += new System.EventHandler(this.NewLocalDrivingLincese_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button button1;
        private People.Controls.infoPersonWithFilter infoPersonWithFilter1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ComboBox TClass;
        private System.Windows.Forms.Label AppDate;
        private System.Windows.Forms.Label CreadedBy;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.Label ID;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label AppFees;
    }
}