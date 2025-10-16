namespace DVLD.Users
{
    partial class show_Detailes_User
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
            this.Close = new System.Windows.Forms.Button();
            this.infoUser1 = new DVLD.Users.Controls.infoUser();
            this.SuspendLayout();
            // 
            // Close
            // 
            this.Close.BackColor = System.Drawing.Color.White;
            this.Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Close.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Close.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.Close.Image = global::DVLD.Properties.Resources.close1;
            this.Close.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Close.Location = new System.Drawing.Point(759, 360);
            this.Close.Name = "Close";
            this.Close.Size = new System.Drawing.Size(106, 36);
            this.Close.TabIndex = 62;
            this.Close.Text = "Close";
            this.Close.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Close.UseVisualStyleBackColor = false;
            this.Close.Click += new System.EventHandler(this.Close_Click);
            // 
            // infoUser1
            // 
            this.infoUser1.BackColor = System.Drawing.Color.White;
            this.infoUser1.Dock = System.Windows.Forms.DockStyle.Left;
            this.infoUser1.Location = new System.Drawing.Point(0, 0);
            this.infoUser1.Name = "infoUser1";
            this.infoUser1.Size = new System.Drawing.Size(926, 546);
            this.infoUser1.TabIndex = 0;
            this.infoUser1.Load += new System.EventHandler(this.infoUser1_Load);
            // 
            // show_Detailes_User
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(931, 546);
            this.Controls.Add(this.Close);
            this.Controls.Add(this.infoUser1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "show_Detailes_User";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Show_Detailes_User";
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.infoUser infoUser1;
        private System.Windows.Forms.Button Close;
    }
}