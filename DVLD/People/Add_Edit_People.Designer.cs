namespace DVLD.People
{
    partial class Add_Edit_People
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
            this.label1 = new System.Windows.Forms.Label();
            this.infoPearson1 = new DVLD.People.Controls.infoPearson();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Vladimir Script", 28.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.GreenYellow;
            this.label1.Location = new System.Drawing.Point(292, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(226, 57);
            this.label1.TabIndex = 1;
            this.label1.Text = "Add Person";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // infoPearson1
            // 
            this.infoPearson1.BackColor = System.Drawing.Color.White;
            this.infoPearson1.Location = new System.Drawing.Point(-8, 57);
            this.infoPearson1.Name = "infoPearson1";
            this.infoPearson1.Size = new System.Drawing.Size(931, 434);
            this.infoPearson1.TabIndex = 2;
            this.infoPearson1.Load += new System.EventHandler(this.infoPearson1_Load);
            // 
            // Add_Edit_People
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(918, 517);
            this.Controls.Add(this.infoPearson1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Add_Edit_People";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add_Edit_People";
            this.Load += new System.EventHandler(this.Add_Edit_People_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private Controls.infoPearson infoPearson1;
    }
}