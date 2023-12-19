namespace OODProject
{
    partial class teachDash
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
            this.button6 = new System.Windows.Forms.Button();
            this.logoutBtn = new System.Windows.Forms.Button();
            this.mainScreen = new System.Windows.Forms.Panel();
            this.mailBtn = new System.Windows.Forms.Button();
            this.reportsBtn = new System.Windows.Forms.Button();
            this.filesBtn = new System.Windows.Forms.Button();
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
            this.label1.Size = new System.Drawing.Size(163, 42);
            this.label1.TabIndex = 0;
            this.label1.Text = "Teacher";
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
            this.panelMenu.Controls.Add(this.button6);
            this.panelMenu.Controls.Add(this.logoutBtn);
            this.panelMenu.Controls.Add(this.mailBtn);
            this.panelMenu.Controls.Add(this.reportsBtn);
            this.panelMenu.Controls.Add(this.filesBtn);
            this.panelMenu.Controls.Add(this.panelLogo);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(200, 631);
            this.panelMenu.TabIndex = 1;
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
            // mainScreen
            // 
            this.mainScreen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainScreen.Location = new System.Drawing.Point(200, 0);
            this.mainScreen.Name = "mainScreen";
            this.mainScreen.Size = new System.Drawing.Size(984, 631);
            this.mainScreen.TabIndex = 4;
            // 
            // mailBtn
            // 
            this.mailBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.mailBtn.FlatAppearance.BorderSize = 0;
            this.mailBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.mailBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mailBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(38)))), ((int)(((byte)(51)))));
            this.mailBtn.Image = global::OODProject.Properties.Resources.mail;
            this.mailBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.mailBtn.Location = new System.Drawing.Point(0, 185);
            this.mailBtn.Name = "mailBtn";
            this.mailBtn.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.mailBtn.Size = new System.Drawing.Size(200, 60);
            this.mailBtn.TabIndex = 2;
            this.mailBtn.Text = "Mail";
            this.mailBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.mailBtn.UseVisualStyleBackColor = true;
            this.mailBtn.Click += new System.EventHandler(this.mailBtn_Click);
            // 
            // reportsBtn
            // 
            this.reportsBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.reportsBtn.FlatAppearance.BorderSize = 0;
            this.reportsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.reportsBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reportsBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(38)))), ((int)(((byte)(51)))));
            this.reportsBtn.Image = global::OODProject.Properties.Resources.report;
            this.reportsBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.reportsBtn.Location = new System.Drawing.Point(0, 125);
            this.reportsBtn.Name = "reportsBtn";
            this.reportsBtn.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.reportsBtn.Size = new System.Drawing.Size(200, 60);
            this.reportsBtn.TabIndex = 1;
            this.reportsBtn.Text = "Reports";
            this.reportsBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.reportsBtn.UseVisualStyleBackColor = true;
            this.reportsBtn.Click += new System.EventHandler(this.reportsBtn_Click);
            // 
            // filesBtn
            // 
            this.filesBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.filesBtn.FlatAppearance.BorderSize = 0;
            this.filesBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.filesBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.filesBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(38)))), ((int)(((byte)(51)))));
            this.filesBtn.Image = global::OODProject.Properties.Resources.new_document;
            this.filesBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.filesBtn.Location = new System.Drawing.Point(0, 65);
            this.filesBtn.Name = "filesBtn";
            this.filesBtn.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.filesBtn.Size = new System.Drawing.Size(200, 60);
            this.filesBtn.TabIndex = 0;
            this.filesBtn.Text = "Files";
            this.filesBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.filesBtn.UseVisualStyleBackColor = true;
            this.filesBtn.Click += new System.EventHandler(this.branchesBtn_Click);
            // 
            // teachDash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 631);
            this.Controls.Add(this.mainScreen);
            this.Controls.Add(this.panelMenu);
            this.Name = "teachDash";
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
        private System.Windows.Forms.Button mailBtn;
        private System.Windows.Forms.Button reportsBtn;
        private System.Windows.Forms.Button filesBtn;
        private System.Windows.Forms.Panel panelLogo;
        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button logoutBtn;
        private System.Windows.Forms.Panel mainScreen;
    }
}