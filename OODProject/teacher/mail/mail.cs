using OODProject.teacher.mail;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OODProject.teacher
{
    public partial class Mail : Form
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
        public teachDash dash;
        public Mail()
        {
            InitializeComponent();
            rows();
        }

        public Mail(teachDash dash)
        {
            InitializeComponent();
            this.dash = dash;
            rows();
        }
        private int id;
        public Mail(teachDash dash, int id)
        {
            InitializeComponent();
            this.dash = dash;
            this.id = id;
            rows();
        }

        private void rows()
        {
            flowLayoutPanel1.Padding = new Padding(10);
            con.Open();
            string sql = "SELECT E.Subject, E.Content, E.EmailDate, E.EmailID FROM Email E WHERE E.RecipientID = @teacherId ORDER BY E.EmailDate DESC";

            using (var command = new SqlCommand(sql, con))
            {
                command.Parameters.AddWithValue("@teacherId", id);

                using (var reader = command.ExecuteReader())
                {
                    int i = 0;
                    int emailID = 0; // Declare the emailID variable
                    while (reader.Read() && i < 20)
                    {
                        UserControlMail list = new UserControlMail();
                        list.ItemName = reader.GetString(0);
                        list.mailContent = reader.GetString(1);
                        list.date = reader.GetDateTime(2).ToString("MM/dd/yyyy");
                        emailID = reader.GetInt32(3); // Update the emailID variable
                        flowLayoutPanel1.Controls.Add(list);
                        list.Margin = new Padding(10);

                        list.Clicked += (sender, e) => UserControl_Click(sender, e, emailID);
                        i++;
                    }
                }
            }
            con.Close();

        }

        private void UserControl_Click(object sender, EventArgs e, int emailId)
        {

            if (dash != null)
            {
                dash.showScreen(new mailDetail(dash, this, emailId));
            }

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            dash.showScreen(new mailCompose(dash, this, id));
        }
    }
}
