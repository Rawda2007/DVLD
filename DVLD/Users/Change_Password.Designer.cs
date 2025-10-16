namespace DVLD.Users
{
    partial class Change_Password
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
            this.infoUser1 = new DVLD.Users.Controls.infoUser();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.confP = new System.Windows.Forms.TextBox();
            this.CurrP = new System.Windows.Forms.TextBox();
            this.NewP = new System.Windows.Forms.TextBox();
            this.Save = new System.Windows.Forms.Button();
            this.Clos = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // infoUser1
            // 
            this.infoUser1.BackColor = System.Drawing.Color.White;
            this.infoUser1.Location = new System.Drawing.Point(-1, -6);
            this.infoUser1.Name = "infoUser1";
            this.infoUser1.Size = new System.Drawing.Size(927, 539);
            this.infoUser1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(56, 557);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(162, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "Current Password";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(69, 606);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 21);
            this.label2.TabIndex = 2;
            this.label2.Text = "New Password";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label3.Location = new System.Drawing.Point(52, 648);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(166, 21);
            this.label3.TabIndex = 3;
            this.label3.Text = "Confirm Password";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // confP
            // 
            this.confP.Location = new System.Drawing.Point(254, 645);
            this.confP.Name = "confP";
            this.confP.PasswordChar = '.';
            this.confP.Size = new System.Drawing.Size(181, 24);
            this.confP.TabIndex = 4;
            this.confP.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // CurrP
            // 
            this.CurrP.Location = new System.Drawing.Point(254, 558);
            this.CurrP.Name = "CurrP";
            this.CurrP.PasswordChar = '.';
            this.CurrP.Size = new System.Drawing.Size(181, 24);
            this.CurrP.TabIndex = 5;
            this.CurrP.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // NewP
            // 
            this.NewP.Location = new System.Drawing.Point(254, 603);
            this.NewP.Name = "NewP";
            this.NewP.PasswordChar = '.';
            this.NewP.Size = new System.Drawing.Size(181, 24);
            this.NewP.TabIndex = 6;
            // 
            // Save
            // 
            this.Save.BackColor = System.Drawing.Color.White;
            this.Save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Save.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Save.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.Save.Image = global::DVLD.Properties.Resources.bookmark__1_1;
            this.Save.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Save.Location = new System.Drawing.Point(783, 662);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(106, 36);
            this.Save.TabIndex = 64;
            this.Save.Text = "Save";
            this.Save.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Save.UseVisualStyleBackColor = false;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // Clos
            // 
            this.Clos.BackColor = System.Drawing.Color.White;
            this.Clos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Clos.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Clos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.Clos.Image = global::DVLD.Properties.Resources.close1;
            this.Clos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Clos.Location = new System.Drawing.Point(646, 662);
            this.Clos.Name = "Clos";
            this.Clos.Size = new System.Drawing.Size(106, 36);
            this.Clos.TabIndex = 63;
            this.Clos.Text = "Close";
            this.Clos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Clos.UseVisualStyleBackColor = false;
            this.Clos.Click += new System.EventHandler(this.Close_Click);
            // 
            // Change_Password
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(922, 729);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.Clos);
            this.Controls.Add(this.NewP);
            this.Controls.Add(this.CurrP);
            this.Controls.Add(this.confP);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.infoUser1);
            this.Name = "Change_Password";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Change_Password";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controls.infoUser infoUser1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox confP;
        private System.Windows.Forms.TextBox CurrP;
        private System.Windows.Forms.TextBox NewP;
        private System.Windows.Forms.Button Clos;
        private System.Windows.Forms.Button Save;
    }
}