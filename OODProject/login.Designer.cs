namespace OODProject
{
    partial class login
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.loginOption = new System.Windows.Forms.GroupBox();
            this.studentLogin = new System.Windows.Forms.RadioButton();
            this.teacherLogin = new System.Windows.Forms.RadioButton();
            this.adminLogin = new System.Windows.Forms.RadioButton();
            this.button3 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.passwordLogin = new System.Windows.Forms.TextBox();
            this.emailLogin = new System.Windows.Forms.TextBox();
            this.registerBtn = new System.Windows.Forms.Button();
            this.loginBtn = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.loginOption.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(201)))), ((int)(((byte)(255)))));
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.loginOption);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.passwordLogin);
            this.panel1.Controls.Add(this.emailLogin);
            this.panel1.Controls.Add(this.registerBtn);
            this.panel1.Controls.Add(this.loginBtn);
            this.panel1.Location = new System.Drawing.Point(690, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(494, 631);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // loginOption
            // 
            this.loginOption.Controls.Add(this.studentLogin);
            this.loginOption.Controls.Add(this.teacherLogin);
            this.loginOption.Controls.Add(this.adminLogin);
            this.loginOption.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.loginOption.Location = new System.Drawing.Point(0, 531);
            this.loginOption.Name = "loginOption";
            this.loginOption.Size = new System.Drawing.Size(494, 100);
            this.loginOption.TabIndex = 6;
            this.loginOption.TabStop = false;
            this.loginOption.Text = "Login Option";
            // 
            // studentLogin
            // 
            this.studentLogin.AutoSize = true;
            this.studentLogin.Location = new System.Drawing.Point(330, 40);
            this.studentLogin.Name = "studentLogin";
            this.studentLogin.Size = new System.Drawing.Size(62, 17);
            this.studentLogin.TabIndex = 2;
            this.studentLogin.Text = "Student";
            this.studentLogin.UseVisualStyleBackColor = true;
            // 
            // teacherLogin
            // 
            this.teacherLogin.AutoSize = true;
            this.teacherLogin.Location = new System.Drawing.Point(197, 40);
            this.teacherLogin.Name = "teacherLogin";
            this.teacherLogin.Size = new System.Drawing.Size(65, 17);
            this.teacherLogin.TabIndex = 1;
            this.teacherLogin.Text = "Teacher";
            this.teacherLogin.UseVisualStyleBackColor = true;
            // 
            // adminLogin
            // 
            this.adminLogin.AutoSize = true;
            this.adminLogin.Location = new System.Drawing.Point(62, 40);
            this.adminLogin.Name = "adminLogin";
            this.adminLogin.Size = new System.Drawing.Size(54, 17);
            this.adminLogin.TabIndex = 0;
            this.adminLogin.Text = "Admin";
            this.adminLogin.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(102)))), ((int)(((byte)(158)))));
            this.button3.Location = new System.Drawing.Point(166, 366);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(143, 23);
            this.button3.TabIndex = 5;
            this.button3.Text = "Forgot Password?";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(60)))), ((int)(((byte)(72)))));
            this.label1.Location = new System.Drawing.Point(178, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 42);
            this.label1.TabIndex = 4;
            this.label1.Text = "Login";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // passwordLogin
            // 
            this.passwordLogin.Location = new System.Drawing.Point(118, 255);
            this.passwordLogin.Name = "passwordLogin";
            this.passwordLogin.Size = new System.Drawing.Size(240, 20);
            this.passwordLogin.TabIndex = 3;
            // 
            // emailLogin
            // 
            this.emailLogin.Location = new System.Drawing.Point(118, 203);
            this.emailLogin.Name = "emailLogin";
            this.emailLogin.Size = new System.Drawing.Size(240, 20);
            this.emailLogin.TabIndex = 2;
            // 
            // registerBtn
            // 
            this.registerBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(60)))), ((int)(((byte)(72)))));
            this.registerBtn.FlatAppearance.BorderSize = 0;
            this.registerBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.registerBtn.ForeColor = System.Drawing.Color.White;
            this.registerBtn.Location = new System.Drawing.Point(68, 448);
            this.registerBtn.Name = "registerBtn";
            this.registerBtn.Size = new System.Drawing.Size(179, 41);
            this.registerBtn.TabIndex = 1;
            this.registerBtn.Text = "Register";
            this.registerBtn.UseVisualStyleBackColor = false;
            this.registerBtn.Click += new System.EventHandler(this.registerBtn_Click);
            // 
            // loginBtn
            // 
            this.loginBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(146)))), ((int)(((byte)(227)))));
            this.loginBtn.FlatAppearance.BorderSize = 0;
            this.loginBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.loginBtn.ForeColor = System.Drawing.Color.White;
            this.loginBtn.Location = new System.Drawing.Point(253, 448);
            this.loginBtn.Name = "loginBtn";
            this.loginBtn.Size = new System.Drawing.Size(179, 41);
            this.loginBtn.TabIndex = 0;
            this.loginBtn.Text = "Login";
            this.loginBtn.UseVisualStyleBackColor = false;
            this.loginBtn.Click += new System.EventHandler(this.button1_Click);
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
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(107)))), ((int)(((byte)(120)))));
            this.label2.Location = new System.Drawing.Point(122, 187);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "E-mail";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(107)))), ((int)(((byte)(120)))));
            this.label3.Location = new System.Drawing.Point(122, 239);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Password";
            // 
            // login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 631);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.Load += new System.EventHandler(this.login_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.loginOption.ResumeLayout(false);
            this.loginOption.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button registerBtn;
        private System.Windows.Forms.Button loginBtn;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox passwordLogin;
        private System.Windows.Forms.TextBox emailLogin;
        private System.Windows.Forms.GroupBox loginOption;
        private System.Windows.Forms.RadioButton studentLogin;
        private System.Windows.Forms.RadioButton teacherLogin;
        private System.Windows.Forms.RadioButton adminLogin;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}