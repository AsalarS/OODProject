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
    public partial class feedbackS : Form
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

        public feedbackS()
        {
            InitializeComponent();
            PopulateComboBox();
        }

        public feedbackS(int ID)
        {
            InitializeComponent();
            this.ID = ID;
            PopulateComboBox();


        }

        private void PopulateComboBox()
        {
            try
            {
                con.Open();

                // Get the StudentID associated with the UserID
                string sqlFindStudentID = $"SELECT StudentID FROM Students WHERE UserID = {ID}";
                int studentID = 0;
                using (var command = new SqlCommand(sqlFindStudentID, con))
                {
                    studentID = Convert.ToInt32(command.ExecuteScalar());
                }

                // Now get the courses the student is registered for
                string query = "SELECT c.CourseID, c.CourseName FROM Course c INNER JOIN StudentCourse sc ON c.CourseID = sc.CourseID WHERE sc.StudentID = @studentID";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@studentID", studentID);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    // Concatenate CourseID and CourseName
                    string courseInfo = reader["CourseID"].ToString() + ": " + reader["CourseName"].ToString();
                    courseCombo.Items.Add(courseInfo);
                }

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }



        private void submitBtn_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                string query = "INSERT INTO Feedback (feedbackContent, courseID, studentID) VALUES ( @feedbackContent, @courseID, @studentID)";
                SqlCommand cmd = new SqlCommand(query, con);

                // Extract the CourseID from the selected item string
                string selectedItem = courseCombo.SelectedItem.ToString();
                string[] parts = selectedItem.Split(':');
                string courseIDStr = parts[0].Trim(); // Trim to remove leading and trailing spaces

                cmd.Parameters.AddWithValue("@courseID", courseIDStr);
                cmd.Parameters.AddWithValue("@feedbackContent", feedbackContent.Text);

                // Find the StudentID based on the UserID
                string sqlFindStudentID = $"SELECT StudentID FROM Students WHERE UserID = {ID}";
                using (var command = new SqlCommand(sqlFindStudentID, con))
                {
                    int studentID = Convert.ToInt32(command.ExecuteScalar());
                    cmd.Parameters.AddWithValue("@studentID", studentID);
                }

                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Feedback submitted successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

    }
}
