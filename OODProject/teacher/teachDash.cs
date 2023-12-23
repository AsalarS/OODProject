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
        public teachDash()
        {
            InitializeComponent();
            this.Icon = new Icon("D:\\vs projects\\OODProject\\OODProject\\Resources\\icon.ico");
            showScreen(new files());
            this.AllowDrop = true;
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
            
        }

        private void branchesBtn_Click(object sender, EventArgs e)
        {
            showScreen(new files());
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
            showScreen(new mail(this));
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var form = new changePassword();
            form.ShowDialog();
        }
    }
}
