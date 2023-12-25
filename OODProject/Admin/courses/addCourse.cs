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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace OODProject.Admin
{
    public partial class addCourse : Form
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
        private course coursesForm { get; set; }
        public addCourse(adminDash dash, course Courses)
        {
            InitializeComponent();
            Dash = dash;
            coursesForm = Courses;

            con.Open();
            string sql = @"SELECT u.UserId, u.FirstName, u.LastName 
              FROM [User] u 
              INNER JOIN Teacher t ON u.UserID = t.UserID 
              WHERE u.Role = 'Teacher';";
            using (var command = new SqlCommand(sql, con))
            {
                using (var reader = command.ExecuteReader())
                {
                    
                    while (reader.Read())
                    {
                        comboBox2.Items.Add($"{reader["UserID"]}: {reader["FirstName"]} {reader["LastName"]}");
                    }
                }
            }
            con.Close();
            con.Open();
        


            string sql1 = "SELECT BranchId, BranchName FROM Branch";

            using (var command = new SqlCommand(sql1, con))
            {
              
                using (var reader = command.ExecuteReader())
                {
                    
                    while (reader.Read())
                    {
                        comboBox1.Items.Add($"{reader["BranchID"]}: {reader["BranchName"]}");
                    }

                    // Bind data to the ComboBox
                
                }
                con.Close();
            }
            con.Open();

            string sql2 = @"SELECT s.StudentID, u.FirstName, u.LastName 
             FROM Students s 
             INNER JOIN [User] u ON s.UserID = u.UserID";
            using (var command = new SqlCommand(sql2, con))
            {
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        listBox2.Items.Add($"{reader["StudentID"]}: {reader["FirstName"]} {reader["LastName"]}");
                    }
                }
            }
            con.Close() ;   

        }
        public addCourse()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Dash.showScreen(new branches(Dash));
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            Dash.showScreen(new course(Dash));
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            string selectedStudents = string.Join(",", listBox2.SelectedItems.Cast<string>().Select(s => $"'{s}'"));
            // Get values from TextBoxes and ComboBoxes
            string courseName = textBox1.Text;
                string courseDescription = textBox2.Text;
                int courseCredits = int.Parse(textBox3.Text);
                string branchInfo = comboBox1.SelectedItem.ToString();
                string teacherInfo = comboBox2.SelectedItem.ToString();

                // Extract BranchID and TeacherID from the selected items
                int branchId = int.Parse(branchInfo.Split(':')[0]);
                int teacherId = int.Parse(teacherInfo.Split(':')[0]);

                // Open connection
                con.Open();

                // Insert into Course table
                string sql = $@"INSERT INTO Course (CourseName, CourseDescription, CourseCredit, BranchID, TeacherID) 
                VALUES ('{courseName}', '{courseDescription}', {courseCredits}, {branchId}, {teacherId});
                SELECT SCOPE_IDENTITY() AS CourseID;";
                using (var command = new SqlCommand(sql, con))
                {
                    int courseId = Convert.ToInt32(command.ExecuteScalar());

                    // Close connection
                    con.Close();

                    // Open connection again
                    con.Open();

                    // Insert into StudentCourse table
                    string sql1 = $@"INSERT INTO StudentCourse (StudentID, CourseID) 
                     SELECT StudentID, {courseId} 
                     FROM Students 
                     WHERE StudentName IN ({selectedStudents})";
                    using (var command1 = new SqlCommand(sql1, con))
                    {
                        command1.ExecuteNonQuery();
                    }
                }

                // Close connection
                con.Close();
            }

        }
    }

