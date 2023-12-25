namespace OODProject
{
    partial class studentDash
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
            this.seperator = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.feedbackBtn = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.logoutBtn = new System.Windows.Forms.Button();
            this.MailBtn = new System.Windows.Forms.Button();
            this.learningBtn = new System.Windows.Forms.Button();
            this.coursesBtn = new System.Windows.Forms.Button();
            this.announcementsBtn = new System.Windows.Forms.Button();
            this.mainScreen = new System.Windows.Forms.Panel();
            this.panelLogo.SuspendLayout();
            this.panelMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // seperator
            // 
            this.seperator.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.seperator.AutoSize = true;
            this.seperator.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(184)))), ((int)(((byte)(239)))));
            this.seperator.Location = new System.Drawing.Point(22, 49);
            this.seperator.Name = "seperator";
            this.seperator.Size = new System.Drawing.Size(157, 13);
            this.seperator.TabIndex = 1;
            this.seperator.Text = "_________________________";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(38)))), ((int)(((byte)(51)))));
            this.label1.Location = new System.Drawing.Point(18, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 42);
            this.label1.TabIndex = 0;
            this.label1.Text = "Student";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // panelLogo
            // 
            this.panelLogo.Controls.Add(this.seperator);
            this.panelLogo.Controls.Add(this.label1);
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(200, 65);
            this.panelLogo.TabIndex = 0;
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(201)))), ((int)(((byte)(255)))));
            this.panelMenu.Controls.Add(this.feedbackBtn);
            this.panelMenu.Controls.Add(this.button6);
            this.panelMenu.Controls.Add(this.logoutBtn);
            this.panelMenu.Controls.Add(this.MailBtn);
            this.panelMenu.Controls.Add(this.learningBtn);
            this.panelMenu.Controls.Add(this.coursesBtn);
            this.panelMenu.Controls.Add(this.announcementsBtn);
            this.panelMenu.Controls.Add(this.panelLogo);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(200, 631);
            this.panelMenu.TabIndex = 2;
            // 
            // feedbackBtn
            // 
            this.feedbackBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.feedbackBtn.FlatAppearance.BorderSize = 0;
            this.feedbackBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.feedbackBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.feedbackBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(38)))), ((int)(((byte)(51)))));
            this.feedbackBtn.Image = global::OODProject.Properties.Resources.feedbackWithPen;
            this.feedbackBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.feedbackBtn.Location = new System.Drawing.Point(0, 305);
            this.feedbackBtn.Name = "feedbackBtn";
            this.feedbackBtn.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.feedbackBtn.Size = new System.Drawing.Size(200, 60);
            this.feedbackBtn.TabIndex = 8;
            this.feedbackBtn.Text = "Feedback";
            this.feedbackBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.feedbackBtn.UseVisualStyleBackColor = true;
            this.feedbackBtn.Click += new System.EventHandler(this.feedbackBtn_Click);
            // 
            // button6
            // 
            this.button6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button6.FlatAppearance.BorderSize = 0;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(38)))), ((int)(((byte)(51)))));
            this.button6.Location = new System.Drawing.Point(0, 552);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(200, 39);
            this.button6.TabIndex = 7;
            this.button6.Text = "Change Password";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // logoutBtn
            // 
            this.logoutBtn.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.logoutBtn.FlatAppearance.BorderSize = 0;
            this.logoutBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.logoutBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logoutBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(38)))), ((int)(((byte)(51)))));
            this.logoutBtn.Location = new System.Drawing.Point(0, 591);
            this.logoutBtn.Name = "logoutBtn";
            this.logoutBtn.Size = new System.Drawing.Size(200, 40);
            this.logoutBtn.TabIndex = 6;
            this.logoutBtn.Text = "Logout";
            this.logoutBtn.UseVisualStyleBackColor = true;
            this.logoutBtn.Click += new System.EventHandler(this.logoutBtn_Click);
            // 
            // MailBtn
            // 
            this.MailBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.MailBtn.FlatAppearance.BorderSize = 0;
            this.MailBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MailBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MailBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(38)))), ((int)(((byte)(51)))));
            this.MailBtn.Image = global::OODProject.Properties.Resources.mail;
            this.MailBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.MailBtn.Location = new System.Drawing.Point(0, 245);
            this.MailBtn.Name = "MailBtn";
            this.MailBtn.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.MailBtn.Size = new System.Drawing.Size(200, 60);
            this.MailBtn.TabIndex = 3;
            this.MailBtn.Text = "Mail";
            this.MailBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.MailBtn.UseVisualStyleBackColor = true;
            this.MailBtn.Click += new System.EventHandler(this.mailBtn_Click);
            // 
            // learningBtn
            // 
            this.learningBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.learningBtn.FlatAppearance.BorderSize = 0;
            this.learningBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.learningBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.learningBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(38)))), ((int)(((byte)(51)))));
            this.learningBtn.Image = global::OODProject.Properties.Resources.folder;
            this.learningBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.learningBtn.Location = new System.Drawing.Point(0, 185);
            this.learningBtn.Name = "learningBtn";
            this.learningBtn.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.learningBtn.Size = new System.Drawing.Size(200, 60);
            this.learningBtn.TabIndex = 2;
            this.learningBtn.Text = "Learning";
            this.learningBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.learningBtn.UseVisualStyleBackColor = true;
            this.learningBtn.Click += new System.EventHandler(this.learningBtn_Click);
            // 
            // coursesBtn
            // 
            this.coursesBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.coursesBtn.FlatAppearance.BorderSize = 0;
            this.coursesBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.coursesBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.coursesBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(38)))), ((int)(((byte)(51)))));
            this.coursesBtn.Image = global::OODProject.Properties.Resources.branches;
            this.coursesBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.coursesBtn.Location = new System.Drawing.Point(0, 125);
            this.coursesBtn.Name = "coursesBtn";
            this.coursesBtn.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.coursesBtn.Size = new System.Drawing.Size(200, 60);
            this.coursesBtn.TabIndex = 1;
            this.coursesBtn.Text = "Courses";
            this.coursesBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.coursesBtn.UseVisualStyleBackColor = true;
            this.coursesBtn.Click += new System.EventHandler(this.coursesBtn_Click);
            // 
            // announcementsBtn
            // 
            this.announcementsBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.announcementsBtn.FlatAppearance.BorderSize = 0;
            this.announcementsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.announcementsBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.announcementsBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(38)))), ((int)(((byte)(51)))));
            this.announcementsBtn.Image = global::OODProject.Properties.Resources.announcements;
            this.announcementsBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.announcementsBtn.Location = new System.Drawing.Point(0, 65);
            this.announcementsBtn.Name = "announcementsBtn";
            this.announcementsBtn.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.announcementsBtn.Size = new System.Drawing.Size(200, 60);
            this.announcementsBtn.TabIndex = 0;
            this.announcementsBtn.Text = "Announcements";
            this.announcementsBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.announcementsBtn.UseVisualStyleBackColor = true;
            this.announcementsBtn.Click += new System.EventHandler(this.announcements_Click);
            // 
            // mainScreen
            // 
            this.mainScreen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainScreen.Location = new System.Drawing.Point(200, 0);
            this.mainScreen.Name = "mainScreen";
            this.mainScreen.Size = new System.Drawing.Size(984, 631);
            this.mainScreen.TabIndex = 3;
            // 
            // studentDash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 631);
            this.Controls.Add(this.mainScreen);
            this.Controls.Add(this.panelMenu);
            this.Name = "studentDash";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dashboard";
            this.panelLogo.ResumeLayout(false);
            this.panelLogo.PerformLayout();
            this.panelMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label seperator;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button MailBtn;
        private System.Windows.Forms.Button learningBtn;
        private System.Windows.Forms.Button coursesBtn;
        private System.Windows.Forms.Button announcementsBtn;
        private System.Windows.Forms.Panel panelLogo;
        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button logoutBtn;
        private System.Windows.Forms.Panel mainScreen;
        private System.Windows.Forms.Button feedbackBtn;
    }
}