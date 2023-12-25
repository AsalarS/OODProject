namespace OODProject.student
{
    partial class feedbackS
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(feedbackS));
            this.branchesLbl = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.courseCombo = new System.Windows.Forms.ComboBox();
            this.feedbackContent = new System.Windows.Forms.RichTextBox();
            this.submitBtn = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // branchesLbl
            // 
            this.branchesLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.branchesLbl.AutoSize = true;
            this.branchesLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.branchesLbl.ForeColor = System.Drawing.Color.White;
            this.branchesLbl.Location = new System.Drawing.Point(429, 20);
            this.branchesLbl.Name = "branchesLbl";
            this.branchesLbl.Size = new System.Drawing.Size(143, 33);
            this.branchesLbl.TabIndex = 0;
            this.branchesLbl.Text = "Feedback";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(182)))), ((int)(((byte)(255)))));
            this.panel1.Controls.Add(this.branchesLbl);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(984, 65);
            this.panel1.TabIndex = 1;
            // 
            // courseCombo
            // 
            this.courseCombo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.courseCombo.FormattingEnabled = true;
            this.courseCombo.Location = new System.Drawing.Point(296, 81);
            this.courseCombo.Name = "courseCombo";
            this.courseCombo.Size = new System.Drawing.Size(393, 26);
            this.courseCombo.TabIndex = 6;
            // 
            // feedbackContent
            // 
            this.feedbackContent.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.feedbackContent.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.feedbackContent.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(38)))), ((int)(((byte)(51)))));
            this.feedbackContent.Location = new System.Drawing.Point(112, 139);
            this.feedbackContent.Name = "feedbackContent";
            this.feedbackContent.Size = new System.Drawing.Size(783, 402);
            this.feedbackContent.TabIndex = 20;
            this.feedbackContent.Text = resources.GetString("feedbackContent.Text");
            // 
            // submitBtn
            // 
            this.submitBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(146)))), ((int)(((byte)(227)))));
            this.submitBtn.FlatAppearance.BorderSize = 0;
            this.submitBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.submitBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.submitBtn.ForeColor = System.Drawing.Color.White;
            this.submitBtn.Location = new System.Drawing.Point(435, 568);
            this.submitBtn.Name = "submitBtn";
            this.submitBtn.Size = new System.Drawing.Size(127, 36);
            this.submitBtn.TabIndex = 21;
            this.submitBtn.Text = "Submit";
            this.submitBtn.UseVisualStyleBackColor = false;
            this.submitBtn.Click += new System.EventHandler(this.submitBtn_Click);
            // 
            // feedbackS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 631);
            this.Controls.Add(this.submitBtn);
            this.Controls.Add(this.feedbackContent);
            this.Controls.Add(this.courseCombo);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "feedbackS";
            this.Text = "feedbackS";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label branchesLbl;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox courseCombo;
        private System.Windows.Forms.RichTextBox feedbackContent;
        private System.Windows.Forms.Button submitBtn;
    }
}