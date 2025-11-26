namespace DVLD.Detain_License
{
    partial class List_Detained_License
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
            this.Filter = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.Detain = new System.Windows.Forms.Button();
            this.Close = new System.Windows.Forms.Button();
            this.release = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Filter
            // 
            this.Filter.Location = new System.Drawing.Point(353, 156);
            this.Filter.Name = "Filter";
            this.Filter.Size = new System.Drawing.Size(204, 24);
            this.Filter.TabIndex = 15;
            this.Filter.Visible = false;
            this.Filter.TextChanged += new System.EventHandler(this.Filter_TextChanged);
            this.Filter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Filter_KeyPress);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(128, 156);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(182, 24);
            this.comboBox1.TabIndex = 14;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tw Cen MT", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.SeaGreen;
            this.label2.Location = new System.Drawing.Point(26, 153);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 27);
            this.label2.TabIndex = 13;
            this.label2.Text = "Filter By :";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 199);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 26;
            this.dataGridView1.Size = new System.Drawing.Size(1323, 263);
            this.dataGridView1.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Vladimir Script", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Lime;
            this.label1.Location = new System.Drawing.Point(344, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(378, 52);
            this.label1.TabIndex = 9;
            this.label1.Text = "List Detainted License";
            // 
            // Detain
            // 
            this.Detain.FlatAppearance.BorderSize = 0;
            this.Detain.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Detain.Image = global::DVLD.Properties.Resources.fees1;
            this.Detain.Location = new System.Drawing.Point(1296, 124);
            this.Detain.Name = "Detain";
            this.Detain.Size = new System.Drawing.Size(80, 69);
            this.Detain.TabIndex = 17;
            this.Detain.UseVisualStyleBackColor = true;
            this.Detain.Click += new System.EventHandler(this.Detain_Click);
            // 
            // Close
            // 
            this.Close.BackColor = System.Drawing.Color.Transparent;
            this.Close.FlatAppearance.BorderSize = 0;
            this.Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Close.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Close.ForeColor = System.Drawing.Color.ForestGreen;
            this.Close.Image = global::DVLD.Properties.Resources.closed1;
            this.Close.Location = new System.Drawing.Point(1234, 497);
            this.Close.Name = "Close";
            this.Close.Size = new System.Drawing.Size(209, 91);
            this.Close.TabIndex = 16;
            this.Close.UseVisualStyleBackColor = false;
            this.Close.Click += new System.EventHandler(this.Close_Click);
            // 
            // release
            // 
            this.release.FlatAppearance.BorderSize = 0;
            this.release.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.release.Image = global::DVLD.Properties.Resources.money1;
            this.release.Location = new System.Drawing.Point(1193, 124);
            this.release.Name = "release";
            this.release.Size = new System.Drawing.Size(75, 69);
            this.release.TabIndex = 12;
            this.release.UseVisualStyleBackColor = true;
            this.release.Click += new System.EventHandler(this.release_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD.Properties.Resources.creative_commons;
            this.pictureBox1.Location = new System.Drawing.Point(198, 24);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(140, 119);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // List_Detained_License
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1430, 643);
            this.Controls.Add(this.Detain);
            this.Controls.Add(this.Close);
            this.Controls.Add(this.Filter);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.release);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "List_Detained_License";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "List_Detained_License";
            this.Load += new System.EventHandler(this.List_Detained_License_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Close;
        private System.Windows.Forms.TextBox Filter;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button release;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Detain;
    }
}