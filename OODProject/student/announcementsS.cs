using OODProject.UserControls;
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

            string query = @"SELECT a.*, a.FileData, a.fileName FROM [dbo].[announcements] a
                             INNER JOIN [dbo].[Course] c ON a.[branchID] = c.[BranchID]
                             INNER JOIN [dbo].[StudentCourse] sc ON c.[CourseID] = sc.[CourseID]
                             INNER JOIN [dbo].[Students] s ON sc.[StudentID] = s.[StudentID]
                             WHERE a.[scope] != 'Teachers' AND s.[UserID] = @UserID" ;

            try
            {
                con.Open();

                using (SqlCommand command = new SqlCommand(query, con))
                {
                    command.Parameters.AddWithValue("@UserID", userID);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            UserControl announcementControl;

                            byte[] fileData = reader["FileData"] as byte[];
                            if (fileData != null)
                            {
                                announcementControl = new UserControlAnnouncement();

                                ((UserControlAnnouncement)announcementControl).announcementtitle = reader["title"].ToString();
                                DateTime dateValue;
                                if (DateTime.TryParse(reader["date"].ToString(), out dateValue))
                                {
                                    ((UserControlAnnouncement)announcementControl).date = dateValue.ToShortDateString();
                                }
                                else
                                {
                                    ((UserControlAnnouncement)announcementControl).date = "Invalid Date";
                                }
                               ((UserControlAnnouncement)announcementControl).description = reader["description"].ToString();

                                // Load the files for the announcement
                                string fileName = "grades.txt"; // Hardcoded file name
                                ListViewItem item = new ListViewItem(fileName);
                                item.Tag = fileData;
                                item.ImageIndex = 6; 
                                        

                               ((UserControlAnnouncement)announcementControl).listViewFiles.Items.Add(item);
                            }
                            else
                            {
                                announcementControl = new UserControlAnnouncementNoFile();
                                ((UserControlAnnouncementNoFile)announcementControl).announcementtitle = reader["title"].ToString();
                                DateTime dateValue;
                                if (DateTime.TryParse(reader["date"].ToString(), out dateValue))
                                {
                                    ((UserControlAnnouncementNoFile)announcementControl).date = dateValue.ToShortDateString();
                                }
                                else
                                {
                                    ((UserControlAnnouncementNoFile)announcementControl).date = "Invalid Date";
                                }
                               ((UserControlAnnouncementNoFile)announcementControl).description = reader["description"].ToString();
                            }

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
                con.Close();
            }
        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
