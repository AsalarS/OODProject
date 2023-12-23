using OODProject.Admin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OODProject
{
    public partial class adminDash : Form
    {
        private bool menuExpand = false;
        public adminDash()
        {
            InitializeComponent();
            this.Icon = new Icon("Resources\\icon.ico");
            showScreen(new branches());
        }
        
        public void showScreen(object Form)
        {
            if (this.mainScreen.Controls.Count > 0)
                this.mainScreen.Controls.RemoveAt(0);
            Form f = Form as Form;
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            this.mainScreen.Controls.Add(f);
            this.mainScreen.Tag = f;
            f.Show();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelMenu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            showScreen(new courses(this));
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            var form = new changePassword();
            form.ShowDialog();
        }

        private void logoutBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            login loginPage = new login();
            loginPage.ShowDialog();
            this.Close();
        }

        private void branchesBtn_Click(object sender, EventArgs e)
        {
            showScreen(new branches(this));
        }

        private void staffBtn_Click(object sender, EventArgs e)
        {
            showScreen(new staff(this));
        }

        private void uploadBtn_Click(object sender, EventArgs e)
        {
            showScreen(new upload());
        }

        private void feedbackBtn_Click(object sender, EventArgs e)
        {
            showScreen(new feedback(this));
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (menuExpand == false)
            {
                uploadPanel.Height += 10;
                if (uploadPanel.Height > 138)
                {
                    timer1.Stop();
                    menuExpand = true;
                }
            } else
            {
                uploadPanel.Height -= 10;
                if (uploadPanel.Height <= 60)
                {
                    timer1.Stop();
                    menuExpand= false;
                }
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            timer1.Start();
            if (menuExpand == false)
            {
                button1.BackgroundImage = Properties.Resources.buttonBkgOpen1;
            } else
            {
                button1.BackgroundImage = Properties.Resources.buttonBkgClosed1;
            }
            
        }

        private void reportsBtn_Click(object sender, EventArgs e)
        {
            showScreen(new reports());
        }

        private void infoBtn_Click(object sender, EventArgs e)
        {
            showScreen(new information());
        }

        private void feedbackBtn_Click_1(object sender, EventArgs e)
        {
            showScreen(new feedback(this));
        }

        private void downloadBtn_Click_1(object sender, EventArgs e)
        {
            //showScreen(new Upload());
        }
    }
}
