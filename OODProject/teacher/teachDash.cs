using OODProject.student;
using OODProject.teacher;
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

    public partial class teachDash : Form
    {
        private int ID;
        public teachDash()
        {
            InitializeComponent();
            this.Icon = new Icon("Resources\\icon.ico");
            showScreen(new announcementsS());
            this.AllowDrop = true;
        }

        public teachDash(int ID)
        {
            InitializeComponent();
            this.Icon = new Icon("Resources\\icon.ico");
            showScreen(new announcementsS());
            this.AllowDrop = true;
            this.ID = ID;
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

        private void label1_Click(object sender, EventArgs e)
        {
            showScreen(new announcementsS());
        }

        private void filesBtn_Click(object sender, EventArgs e)
        {
            showScreen(new files(ID));
        }

        private void logoutBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            login loginPage = new login();
            loginPage.ShowDialog();
            this.Close();
        }

        private void reportsBtn_Click(object sender, EventArgs e)
        {
            showScreen(new reports());
        }

        private void mailBtn_Click(object sender, EventArgs e)
        {
            showScreen(new Mail(this, ID));
        }

        private void changePwd_Click(object sender, EventArgs e)
        {
            var form = new changePassword(ID);
            form.ShowDialog();
        }

        private void announcements_Click(object sender, EventArgs e)
        {
            showScreen(new announcementsT());
        }
    }
}
