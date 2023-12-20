using OODProject.student;
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
    public partial class studentDash : Form
    {
        public studentDash()
        {
            this.Icon = new Icon("D:\\vs projects\\OODProject\\OODProject\\Resources\\icon.ico");
            InitializeComponent();
            showScreen(new coursesS());
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

        private void logoutBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            login loginPage = new login();
            loginPage.ShowDialog();
            this.Close();
        }

        private void coursesBtn_Click(object sender, EventArgs e)
        {
            showScreen(new coursesS());
        }

        private void learningBtn_Click(object sender, EventArgs e)
        {
            showScreen(new learning());
        }

        private void mailBtn_Click(object sender, EventArgs e)
        {
            showScreen(new mailS());
        }

        private void feedbackBtn_Click(object sender, EventArgs e)
        {
            showScreen(new feedbackS());
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var form = new changePassword();
            form.ShowDialog();
        }
    }
}
