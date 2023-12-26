using OODProject.student;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OODProject
{
    public partial class studentDash : Form
    {
        static String path = RemoveLastTwoDirectories(Directory.GetCurrentDirectory());
        static String connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + "\"" + path + "\"" + ";Integrated Security=True";
        static int sessionID;
        SqlConnection con = new SqlConnection(connectionString);


        static string RemoveLastTwoDirectories(string path)
        {
            for (int i = 0; i < 2; i++)
            {
                path = Path.GetDirectoryName(path);

                // Check if the path is null, meaning there are not enough directories to remove
                if (path == null)
                {
                    // Handle the case where there are not enough directories in the path
                    return "Invalid Path";
                }
            }

            return path + "\\Database.mdf";
        }
        private int ID;
        public studentDash()
        {
            this.Icon = new Icon("Resources\\icon.ico");
            InitializeComponent();
            showScreen(new announcementsS());
        }

        public studentDash(int ID)
        {
            this.Icon = new Icon("Resources\\icon.ico");
            InitializeComponent();
            showScreen(new announcementsS());
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

        private void logoutBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            login loginPage = new login();
            loginPage.ShowDialog();
            this.Close();
        }

        private void coursesBtn_Click(object sender, EventArgs e)
        {
            showScreen(new coursesS(ID));
        }

        private void learningBtn_Click(object sender, EventArgs e)
        {
            showScreen(new learning());
        }

        private void mailBtn_Click(object sender, EventArgs e)
        {
            showScreen(new mailS(this));
        }

        private void feedbackBtn_Click(object sender, EventArgs e)
        {
            showScreen(new feedbackS(ID));
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var form = new changePassword(ID);
            form.ShowDialog();
        }

        private void announcements_Click(object sender, EventArgs e)
        {
            showScreen(new announcementsS());
        }

        private void label1_Click(object sender, EventArgs e)
        {
            showScreen(new announcementsS());
        }
    }
}
