namespace DVLD.People.Controls
{
    partial class infoPersonWithFilter
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
            this.Filter = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.SearchPerson = new System.Windows.Forms.Button();
            this.infoPearson1 = new DVLD.People.Controls.infoPearson();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Filter
            // 
            this.Filter.Location = new System.Drawing.Point(339, 38);
            this.Filter.Name = "Filter";
            this.Filter.Size = new System.Drawing.Size(245, 32);
            this.Filter.TabIndex = 16;
            this.Filter.TextChanged += new System.EventHandler(this.Filter_TextChanged);
            this.Filter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Filter_KeyPress);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(112, 38);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(198, 32);
            this.comboBox1.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tw Cen MT", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.LightGreen;
            this.label2.Location = new System.Drawing.Point(10, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 27);
            this.label2.TabIndex = 14;
            this.label2.Text = "Filter By :";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.White;
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.SearchPerson);
            this.groupBox2.Controls.Add(this.Filter);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.comboBox1);
            this.groupBox2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.GreenYellow;
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(844, 113);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Filter Person";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // button2
            // 
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button2.Image = global::DVLD.Properties.Resources.add_user;
            this.button2.Location = new System.Drawing.Point(715, 30);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(80, 47);
            this.button2.TabIndex = 18;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // SearchPerson
            // 
            this.SearchPerson.Image = global::DVLD.Properties.Resources.search;
            this.SearchPerson.Location = new System.Drawing.Point(617, 30);
            this.SearchPerson.Name = "SearchPerson";
            this.SearchPerson.Size = new System.Drawing.Size(79, 47);
            this.SearchPerson.TabIndex = 17;
            this.SearchPerson.UseVisualStyleBackColor = true;
            this.SearchPerson.Click += new System.EventHandler(this.SearchPerson_Click_1);
            // 
            // infoPearson1
            // 
            this.infoPearson1.BackColor = System.Drawing.Color.White;
            this.infoPearson1.Location = new System.Drawing.Point(0, 122);
            this.infoPearson1.Name = "infoPearson1";
            this.infoPearson1.Size = new System.Drawing.Size(931, 434);
            this.infoPearson1.TabIndex = 20;
            // 
            // infoPersonWithFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.infoPearson1);
            this.Controls.Add(this.groupBox2);
            this.Name = "infoPersonWithFilter";
            this.Size = new System.Drawing.Size(928, 552);
            this.Load += new System.EventHandler(this.infoPersonWithFilter_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox Filter;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button SearchPerson;
        private infoPearson infoPearson1;
    }
}
