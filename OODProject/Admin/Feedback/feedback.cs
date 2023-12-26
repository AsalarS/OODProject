using OODProject.Admin.Feedback;
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

namespace OODProject.Admin
{
    public partial class feedback : Form
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


        public adminDash Dash { get; set; }

        public feedback()
        {
            InitializeComponent();
            rows();
            
        }

        public feedback(adminDash dash)
        {
            InitializeComponent();
            rows();
            this.Dash = dash;
            PopulateCourses();
         
        }
        private void rows()
        {
            flowLayoutPanel1.Padding = new Padding(10);
            flowLayoutPanel1.Refresh();

            con.Open();
            string sql = @"SELECT Feedback.FeedbackID, CONCAT(u.FirstName, ' ', u.LastName) AS studentName, Feedback.feedbackContent 
FROM Feedback 
INNER JOIN Students s ON Feedback.StudentID = s.StudentID
INNER JOIN [User] u ON s.UserID = u.UserID";
            using (var command = new SqlCommand(sql, con))
            {
                using (var reader = command.ExecuteReader())
                {
                    int i = 0;
                    while (reader.Read() && i < 20)
                    {
                        UserControlNormalList list = new UserControlNormalList();
                        list.ItemName = reader["studentName"].ToString(); // Use the student's name as the item name
                        flowLayoutPanel1.Controls.Add(list);
                        list.Margin = new Padding(10);
                        int feedbackId = reader.GetInt32(0); // Assuming feedbackId is an integer
                        list.Clicked += (sender, e) => UserControl_Click(sender, e, feedbackId);
                        i++;
                    }
                }
            }
            flowLayoutPanel1.Refresh();
            con.Close();
        }

        // Populate the combobox with all courses
        // Populate the combobox with all courses
        private void PopulateCourses()
        {
            con.Open();
            string sql = "SELECT CourseName FROM Course";
            using (var command = new SqlCommand(sql, con))
            {
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        comboBox1.Items.Add(reader["CourseName"]);
                    }
                }
            }
            con.Close();
        }

        // Event handler for the SelectedIndexChanged event of the combobox
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Clear the list
            flowLayoutPanel1.Controls.Clear();

            // Get the selected course
            string selectedCourse = comboBox1.SelectedItem.ToString();

            // Retrieve all feedbacks for the selected course
            rows(selectedCourse);
        }

        private void rows(string courseName)
        {
            flowLayoutPanel1.Padding = new Padding(10);
            flowLayoutPanel1.Refresh();

            con.Open();
            string sql = @"SELECT Feedback.FeedbackID, CONCAT(u.FirstName, ' ', u.LastName) AS studentName, Feedback.feedbackContent 
FROM Feedback 
INNER JOIN Students s ON Feedback.StudentID = s.StudentID
INNER JOIN [User] u ON s.UserID = u.UserID
INNER JOIN Course c ON Feedback.CourseID = c.CourseID
WHERE c.CourseName = @courseName";
            using (var command = new SqlCommand(sql, con))
            {
                command.Parameters.AddWithValue("@courseName", courseName);
                using (var reader = command.ExecuteReader())
                {
                    int i = 0;
                    while (reader.Read() && i < 20)
                    {
                        UserControlNormalList list = new UserControlNormalList();
                        list.ItemName = reader["studentName"].ToString(); // Use the student's name as the item name
                        flowLayoutPanel1.Controls.Add(list);
                        list.Margin = new Padding(10);
                        int feedbackId = reader.GetInt32(0); // Assuming feedbackId is an integer
                        list.Clicked += (sender, e) => UserControl_Click(sender, e, feedbackId);
                        i++;
                    }
                }
            }
            flowLayoutPanel1.Refresh();
            con.Close();
        }



        private void UserControl_Click(object sender, EventArgs e, int feedbackId)
        {
            if (Dash != null)
            {
                Dash.showScreen(new feedbackDetails(Dash, this, feedbackId));
            }

        }
    }
}
