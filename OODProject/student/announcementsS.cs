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

namespace OODProject.student
{
    public partial class announcementsS : Form
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

        public announcementsS()
        {
            InitializeComponent();

        }
        int ID;
        public announcementsS(int ID)
        {
            this.ID = ID;
            InitializeComponent();
            rows(ID);

        }

        private void rows(int userID)
        {
            flowLayoutPanel1.Padding = new Padding(10);

            // Query to select announcements from the database
            string query = @"SELECT a.* FROM [dbo].[announcements] a
                   INNER JOIN [dbo].[Course] c ON a.[branchID] = c.[BranchID]
                   INNER JOIN [dbo].[Students] s ON c.[CourseID] = s.[CourseID]
                   WHERE a.[scope] = 'students' AND s.[UserID] = @UserID";

            try
            {
                // Open the connection
                con.Open();

                // Create a SqlCommand to execute the query
                using (SqlCommand command = new SqlCommand(query, con))
                {
                    // Add the UserID parameter to the command
                    command.Parameters.AddWithValue("@UserID", userID);

                    // Execute the query and get the SqlDataReader
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Loop through the result set
                        while (reader.Read())
                        {
                            // Create a new UserControlAnnouncement
                            UserControlAnnouncement announcementControl = new UserControlAnnouncement();

                            // Populate the UserControlAnnouncement properties with data from the database
                            announcementControl.announcementtitle = reader["title"].ToString();
                            // Replace "date" with the actual column name for the date in your table
                            DateTime dateValue;
                            if (DateTime.TryParse(reader["date"].ToString(), out dateValue))
                            {
                                // Use ToShortDateString to display only the date part
                                announcementControl.date = dateValue.ToShortDateString();
                            }
                            else
                            {
                                announcementControl.date = "Invalid Date";
                            }
                            announcementControl.description = reader["description"].ToString();

                            // Add the UserControlAnnouncement to the flowLayoutPanel
                            flowLayoutPanel1.Controls.Add(announcementControl);
                            announcementControl.Margin = new Padding(10);
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
        }



        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
