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

namespace OODProject.Admin.Feedback
{
    public partial class feedbackDetails : Form
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


        public feedbackDetails()
        {
            InitializeComponent();
        }

        public adminDash Dash { get; set; }
        private feedback feedbackForm { get; set; }
        public feedbackDetails(adminDash dash, feedback feedbackPage)
        {
            InitializeComponent();
            Dash = dash;
            feedbackForm = feedbackPage;
        }

        private int feedbackID;

        public feedbackDetails(adminDash dash, feedback feedbackPage, int feedbackID)
        {
           
           
            string sql = "SELECT Feedback.FeedbackContent, CONCAT([User].FirstName, ' ', [User].LastName) AS studentName, Students.studentID," +
                " Course.courseName FROM Feedback INNER JOIN Students ON Feedback.StudentID = Students.studentID INNER JOIN [User] " +
                "ON Students.UserID = [User].UserID INNER JOIN Course ON Feedback.courseID = Course.courseID WHERE " +
                "Feedback.feedbackId = @feedbackId";
            this.feedbackID = feedbackID;
            
            con.Open();
            using (var command = new SqlCommand(sql, con))
            {
                command.Parameters.AddWithValue("@feedbackId", feedbackID);
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {

                        // Display the feedback content in the RichTextBox

                       
                           richTextBox1.Text = reader["feedbackContent"].ToString();
                        

                        // Display the student's name in the Label
                        
                        studentName.Text = reader["studentName"].ToString();

                        // Display the student ID in the Label
                        IDNumber.Text = reader["studentID"].ToString();

                        // Display the course name in the Label
                        Course.Text = reader["courseName"].ToString();
                    }
                }
            }
            con.Close();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            Dash.showScreen(feedbackForm);
        }
    }
}
