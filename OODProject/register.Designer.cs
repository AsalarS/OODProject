namespace OODProject
{
    partial class register
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.backBtn = new System.Windows.Forms.Button();
            this.roleGroup = new System.Windows.Forms.GroupBox();
            this.teachRadioBtn = new System.Windows.Forms.RadioButton();
            this.stdntRadioBtn = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.pass2Reg = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.pass1Reg = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.phoneReg = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.emailReg = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lastNameReg = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.firstNameReg = new System.Windows.Forms.TextBox();
            this.registerBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.roleGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox1.Image = global::OODProject.Properties.Resources.loginDesign;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(692, 631);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(201)))), ((int)(((byte)(255)))));
            this.panel1.Controls.Add(this.backBtn);
            this.panel1.Controls.Add(this.roleGroup);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.pass2Reg);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.pass1Reg);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.phoneReg);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.emailReg);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.lastNameReg);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.firstNameReg);
            this.panel1.Controls.Add(this.registerBtn);
            this.panel1.Location = new System.Drawing.Point(690, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(494, 631);
            this.panel1.TabIndex = 2;
            // 
            // backBtn
            // 
            this.backBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(146)))), ((int)(((byte)(227)))));
            this.backBtn.FlatAppearance.BorderSize = 0;
            this.backBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.backBtn.ForeColor = System.Drawing.Color.White;
            this.backBtn.Location = new System.Drawing.Point(93, 519);
            this.backBtn.Name = "backBtn";
            this.backBtn.Size = new System.Drawing.Size(297, 41);
            this.backBtn.TabIndex = 19;
            this.backBtn.Text = "Back";
            this.backBtn.UseVisualStyleBackColor = false;
            this.backBtn.Click += new System.EventHandler(this.backBtn_Click);
            // 
            // roleGroup
            // 
            this.roleGroup.Controls.Add(this.teachRadioBtn);
            this.roleGroup.Controls.Add(this.stdntRadioBtn);
            this.roleGroup.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(60)))), ((int)(((byte)(72)))));
            this.roleGroup.Location = new System.Drawing.Point(119, 328);
            this.roleGroup.Name = "roleGroup";
            this.roleGroup.Size = new System.Drawing.Size(247, 54);
            this.roleGroup.TabIndex = 18;
            this.roleGroup.TabStop = false;
            this.roleGroup.Text = "Role";
            // 
            // teachRadioBtn
            // 
            this.teachRadioBtn.AutoSize = true;
            this.teachRadioBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(60)))), ((int)(((byte)(72)))));
            this.teachRadioBtn.Location = new System.Drawing.Point(153, 19);
            this.teachRadioBtn.Name = "teachRadioBtn";
            this.teachRadioBtn.Size = new System.Drawing.Size(65, 17);
            this.teachRadioBtn.TabIndex = 1;
            this.teachRadioBtn.TabStop = true;
            this.teachRadioBtn.Text = "Teacher";
            this.teachRadioBtn.UseVisualStyleBackColor = true;
            // 
            // stdntRadioBtn
            // 
            this.stdntRadioBtn.AutoSize = true;
            this.stdntRadioBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(60)))), ((int)(((byte)(72)))));
            this.stdntRadioBtn.Location = new System.Drawing.Point(40, 19);
            this.stdntRadioBtn.Name = "stdntRadioBtn";
            this.stdntRadioBtn.Size = new System.Drawing.Size(62, 17);
            this.stdntRadioBtn.TabIndex = 0;
            this.stdntRadioBtn.TabStop = true;
            this.stdntRadioBtn.Text = "Student";
            this.stdntRadioBtn.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(107)))), ((int)(((byte)(120)))));
            this.label6.Location = new System.Drawing.Point(261, 267);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(115, 16);
            this.label6.TabIndex = 17;
            this.label6.Text = "Repeat Password";
            // 
            // pass2Reg
            // 
            this.pass2Reg.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pass2Reg.Location = new System.Drawing.Point(257, 286);
            this.pass2Reg.Name = "pass2Reg";
            this.pass2Reg.Size = new System.Drawing.Size(206, 26);
            this.pass2Reg.TabIndex = 16;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(107)))), ((int)(((byte)(120)))));
            this.label7.Location = new System.Drawing.Point(27, 267);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 16);
            this.label7.TabIndex = 15;
            this.label7.Text = "Password";
            // 
            // pass1Reg
            // 
            this.pass1Reg.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pass1Reg.Location = new System.Drawing.Point(23, 286);
            this.pass1Reg.Name = "pass1Reg";
            this.pass1Reg.Size = new System.Drawing.Size(206, 26);
            this.pass1Reg.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(107)))), ((int)(((byte)(120)))));
            this.label4.Location = new System.Drawing.Point(261, 208);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 16);
            this.label4.TabIndex = 13;
            this.label4.Text = "PhoneNumber";
            // 
            // phoneReg
            // 
            this.phoneReg.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phoneReg.Location = new System.Drawing.Point(257, 227);
            this.phoneReg.Name = "phoneReg";
            this.phoneReg.Size = new System.Drawing.Size(206, 26);
            this.phoneReg.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(107)))), ((int)(((byte)(120)))));
            this.label5.Location = new System.Drawing.Point(26, 208);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 16);
            this.label5.TabIndex = 11;
            this.label5.Text = "E-mail";
            // 
            // emailReg
            // 
            this.emailReg.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emailReg.Location = new System.Drawing.Point(23, 227);
            this.emailReg.Name = "emailReg";
            this.emailReg.Size = new System.Drawing.Size(206, 26);
            this.emailReg.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(107)))), ((int)(((byte)(120)))));
            this.label3.Location = new System.Drawing.Point(262, 152);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 16);
            this.label3.TabIndex = 9;
            this.label3.Text = "Last Name";
            // 
            // lastNameReg
            // 
            this.lastNameReg.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lastNameReg.Location = new System.Drawing.Point(257, 171);
            this.lastNameReg.Name = "lastNameReg";
            this.lastNameReg.Size = new System.Drawing.Size(206, 26);
            this.lastNameReg.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(107)))), ((int)(((byte)(120)))));
            this.label2.Location = new System.Drawing.Point(26, 152);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "First Name";
            // 
            // button3
            // 
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(102)))), ((int)(((byte)(158)))));
            this.button3.Location = new System.Drawing.Point(170, 395);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(158, 23);
            this.button3.TabIndex = 5;
            this.button3.Text = "Already have an account?";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(60)))), ((int)(((byte)(72)))));
            this.label1.Location = new System.Drawing.Point(106, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(279, 73);
            this.label1.TabIndex = 4;
            this.label1.Text = "Register";
            // 
            // firstNameReg
            // 
            this.firstNameReg.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.firstNameReg.Location = new System.Drawing.Point(23, 171);
            this.firstNameReg.Name = "firstNameReg";
            this.firstNameReg.Size = new System.Drawing.Size(206, 26);
            this.firstNameReg.TabIndex = 2;
            // 
            // registerBtn
            // 
            this.registerBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(60)))), ((int)(((byte)(72)))));
            this.registerBtn.FlatAppearance.BorderSize = 0;
            this.registerBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.registerBtn.ForeColor = System.Drawing.Color.White;
            this.registerBtn.Location = new System.Drawing.Point(93, 472);
            this.registerBtn.Name = "registerBtn";
            this.registerBtn.Size = new System.Drawing.Size(297, 41);
            this.registerBtn.TabIndex = 1;
            this.registerBtn.Text = "Register";
            this.registerBtn.UseVisualStyleBackColor = false;
            this.registerBtn.Click += new System.EventHandler(this.registerBtn_Click);
            // 
            // register
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 631);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "register";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Register";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.roleGroup.ResumeLayout(false);
            this.roleGroup.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox firstNameReg;
        private System.Windows.Forms.Button registerBtn;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox pass2Reg;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox pass1Reg;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox phoneReg;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox emailReg;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox lastNameReg;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.GroupBox roleGroup;
        private System.Windows.Forms.RadioButton teachRadioBtn;
        private System.Windows.Forms.RadioButton stdntRadioBtn;
        private System.Windows.Forms.Button backBtn;
    }
}