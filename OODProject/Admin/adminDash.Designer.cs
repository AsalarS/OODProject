﻿namespace OODProject
{
    partial class adminDash
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
            this.panelMenu = new System.Windows.Forms.Panel();
            this.button6 = new System.Windows.Forms.Button();
            this.logoutBtn = new System.Windows.Forms.Button();
            this.feedbackBtn = new System.Windows.Forms.Button();
            this.downloadBtn = new System.Windows.Forms.Button();
            this.uploadBtn = new System.Windows.Forms.Button();
            this.staffBtn = new System.Windows.Forms.Button();
            this.coursesBtn = new System.Windows.Forms.Button();
            this.branchesBtn = new System.Windows.Forms.Button();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.seperator = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.mainScreen = new System.Windows.Forms.Panel();
            this.panelMenu.SuspendLayout();
            this.panelLogo.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(201)))), ((int)(((byte)(255)))));
            this.panelMenu.Controls.Add(this.button6);
            this.panelMenu.Controls.Add(this.logoutBtn);
            this.panelMenu.Controls.Add(this.feedbackBtn);
            this.panelMenu.Controls.Add(this.downloadBtn);
            this.panelMenu.Controls.Add(this.uploadBtn);
            this.panelMenu.Controls.Add(this.staffBtn);
            this.panelMenu.Controls.Add(this.coursesBtn);
            this.panelMenu.Controls.Add(this.branchesBtn);
            this.panelMenu.Controls.Add(this.panelLogo);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(200, 631);
            this.panelMenu.TabIndex = 0;
            this.panelMenu.Paint += new System.Windows.Forms.PaintEventHandler(this.panelMenu_Paint);
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
            // feedbackBtn
            // 
            this.feedbackBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.feedbackBtn.FlatAppearance.BorderSize = 0;
            this.feedbackBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.feedbackBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.feedbackBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(38)))), ((int)(((byte)(51)))));
            this.feedbackBtn.Image = global::OODProject.Properties.Resources.feedback;
            this.feedbackBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.feedbackBtn.Location = new System.Drawing.Point(0, 365);
            this.feedbackBtn.Name = "feedbackBtn";
            this.feedbackBtn.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.feedbackBtn.Size = new System.Drawing.Size(200, 60);
            this.feedbackBtn.TabIndex = 5;
            this.feedbackBtn.Text = "Feedback";
            this.feedbackBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.feedbackBtn.UseVisualStyleBackColor = true;
            this.feedbackBtn.Click += new System.EventHandler(this.feedbackBtn_Click);
            // 
            // downloadBtn
            // 
            this.downloadBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.downloadBtn.FlatAppearance.BorderSize = 0;
            this.downloadBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.downloadBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.downloadBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(38)))), ((int)(((byte)(51)))));
            this.downloadBtn.Image = global::OODProject.Properties.Resources.download;
            this.downloadBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.downloadBtn.Location = new System.Drawing.Point(0, 305);
            this.downloadBtn.Name = "downloadBtn";
            this.downloadBtn.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.downloadBtn.Size = new System.Drawing.Size(200, 60);
            this.downloadBtn.TabIndex = 4;
            this.downloadBtn.Text = "Download";
            this.downloadBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.downloadBtn.UseVisualStyleBackColor = true;
            this.downloadBtn.Click += new System.EventHandler(this.downloadBtn_Click);
            // 
            // uploadBtn
            // 
            this.uploadBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.uploadBtn.FlatAppearance.BorderSize = 0;
            this.uploadBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.uploadBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uploadBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(38)))), ((int)(((byte)(51)))));
            this.uploadBtn.Image = global::OODProject.Properties.Resources.upload;
            this.uploadBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uploadBtn.Location = new System.Drawing.Point(0, 245);
            this.uploadBtn.Name = "uploadBtn";
            this.uploadBtn.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.uploadBtn.Size = new System.Drawing.Size(200, 60);
            this.uploadBtn.TabIndex = 3;
            this.uploadBtn.Text = "Upload";
            this.uploadBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.uploadBtn.UseVisualStyleBackColor = true;
            this.uploadBtn.Click += new System.EventHandler(this.uploadBtn_Click);
            // 
            // staffBtn
            // 
            this.staffBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.staffBtn.FlatAppearance.BorderSize = 0;
            this.staffBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.staffBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.staffBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(38)))), ((int)(((byte)(51)))));
            this.staffBtn.Image = global::OODProject.Properties.Resources.staff;
            this.staffBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.staffBtn.Location = new System.Drawing.Point(0, 185);
            this.staffBtn.Name = "staffBtn";
            this.staffBtn.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.staffBtn.Size = new System.Drawing.Size(200, 60);
            this.staffBtn.TabIndex = 2;
            this.staffBtn.Text = "Staff";
            this.staffBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.staffBtn.UseVisualStyleBackColor = true;
            this.staffBtn.Click += new System.EventHandler(this.staffBtn_Click);
            // 
            // coursesBtn
            // 
            this.coursesBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.coursesBtn.FlatAppearance.BorderSize = 0;
            this.coursesBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.coursesBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.coursesBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(38)))), ((int)(((byte)(51)))));
            this.coursesBtn.Image = global::OODProject.Properties.Resources.courses;
            this.coursesBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.coursesBtn.Location = new System.Drawing.Point(0, 125);
            this.coursesBtn.Name = "coursesBtn";
            this.coursesBtn.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.coursesBtn.Size = new System.Drawing.Size(200, 60);
            this.coursesBtn.TabIndex = 1;
            this.coursesBtn.Text = "Courses";
            this.coursesBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.coursesBtn.UseVisualStyleBackColor = true;
            this.coursesBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // branchesBtn
            // 
            this.branchesBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.branchesBtn.FlatAppearance.BorderSize = 0;
            this.branchesBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.branchesBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.branchesBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(38)))), ((int)(((byte)(51)))));
            this.branchesBtn.Image = global::OODProject.Properties.Resources.branches;
            this.branchesBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.branchesBtn.Location = new System.Drawing.Point(0, 65);
            this.branchesBtn.Name = "branchesBtn";
            this.branchesBtn.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.branchesBtn.Size = new System.Drawing.Size(200, 60);
            this.branchesBtn.TabIndex = 0;
            this.branchesBtn.Text = "Branches";
            this.branchesBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.branchesBtn.UseVisualStyleBackColor = true;
            this.branchesBtn.Click += new System.EventHandler(this.branchesBtn_Click);
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
            this.panelLogo.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
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
            this.seperator.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(38)))), ((int)(((byte)(51)))));
            this.label1.Location = new System.Drawing.Point(33, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 42);
            this.label1.TabIndex = 0;
            this.label1.Text = "Admin";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mainScreen
            // 
            this.mainScreen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainScreen.Location = new System.Drawing.Point(200, 0);
            this.mainScreen.Name = "mainScreen";
            this.mainScreen.Size = new System.Drawing.Size(984, 631);
            this.mainScreen.TabIndex = 4;
            // 
            // adminDash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 631);
            this.Controls.Add(this.mainScreen);
            this.Controls.Add(this.panelMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "adminDash";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dashboard";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panelMenu.ResumeLayout(false);
            this.panelLogo.ResumeLayout(false);
            this.panelLogo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Panel panelLogo;
        private System.Windows.Forms.Button branchesBtn;
        private System.Windows.Forms.Button feedbackBtn;
        private System.Windows.Forms.Button downloadBtn;
        private System.Windows.Forms.Button uploadBtn;
        private System.Windows.Forms.Button staffBtn;
        private System.Windows.Forms.Button coursesBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label seperator;
        private System.Windows.Forms.Button logoutBtn;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Panel mainScreen;
    }
}
