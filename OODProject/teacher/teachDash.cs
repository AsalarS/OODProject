using OODProject.student;
using OODProject.teacher;
using System;
using System.Collections;
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

    public partial class teachDash : Form
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
        public teachDash()
        {
            InitializeComponent();
            this.Icon = new Icon("Resources\\icon.ico");
            showScreen(new announcementsT(ID));
            this.AllowDrop = true;
        }

        public teachDash(int ID)
        {
            InitializeComponent();
            this.Icon = new Icon("Resources\\icon.ico");
            showScreen(new announcementsT(ID));
            this.AllowDrop = true;
            this.ID = ID;

            // Query to select isNotificationRead for the current user
            string query = "SELECT isNotificationRead FROM [dbo].[User] WHERE UserID = @SessionID";

            try
            {
                // Open the connection
                con.Open();

                // Create a SqlCommand to execute the query
                using (SqlCommand command = new SqlCommand(query, con))
                {
                    // Set the parameter value
                    command.Parameters.AddWithValue("@SessionID", sessionID);

                    // Execute the query and get the SqlDataReader
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();
                            bool isNotificationRead = Convert.ToBoolean(reader["isNotificationRead"]);

                            // Update the button image based on the isNotificationRead value
                            if (!isNotificationRead)
                            {
                                // Use the other image
                                announcementsBtn.Image = Properties.Resources.announcementsRED;
                            }
                            else
                            {
                                // Use the original image
                                announcementsBtn.Image = Properties.Resources.announcements;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading announcements: " + ex.Message);
            }
            finally
            {
                // Close the connection
                con.Close();
            }

            string updateQuery = "UPDATE [dbo].[User] SET isNotificationRead = 1 WHERE UserID = @userID";

            try
            {
                // Open the connection
                con.Open();

                // Create a SqlCommand to execute the update query
                using (SqlCommand command = new SqlCommand(updateQuery, con))
                {
                   
                    // Set the parameter value
                    command.Parameters.AddWithValue("@userID", ID);

                    // Execute the update query
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating isNotificationRead: " + ex.Message);
            }
            finally
            {
                // Close the connection
                con.Close();
            }
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
            showScreen(new announcementsT(ID));
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
            showScreen(new reports(ID));
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
