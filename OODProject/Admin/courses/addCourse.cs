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

            string sql1 = "SELECT BranchId, BranchName FROM Branch";

            using (var command = new SqlCommand(sql1, con))
            {
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        comboBox1.Items.Add($"{reader["BranchID"]}: {reader["BranchName"]}");
                    }
                }
            }

            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;

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

            // Close connection
            con.Close();
        }

        public addCourse()
        {
            InitializeComponent();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Dash.showScreen(new course(Dash));
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            con.Open();
            if (comboBox1.SelectedIndex != -1)
            {
                string sql = @"SELECT u.UserId, u.FirstName, u.LastName 
   FROM [User] u 
   INNER JOIN Teacher t ON u.UserID = t.UserID 
   WHERE u.Role = 'Teacher' AND t.BranchID = @branchId;";

                using (var command = new SqlCommand(sql, con))
                {
                    command.Parameters.AddWithValue("@branchId", ((string)comboBox1.SelectedItem).Split(':')[0].Trim());
                    using (var reader = command.ExecuteReader())
                    {
                        comboBox2.Text = "";
                        comboBox2.Items.Clear(); // Clear the existing items in comboBox2
                        while (reader.Read())
                        {
                            comboBox2.Items.Add($"{reader["UserID"]}: {reader["FirstName"]} {reader["LastName"]}");
                        }
                    }
                }
                // Remove the line that closes the connection here
                con.Close();
            }
            else
            {
                MessageBox.Show("Please select a branch.");
            }
        }

   

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            Dash.showScreen(new course(Dash));
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            string selectedStudents = string.Join(",", listBox2.SelectedItems.Cast<string>().Select(s => $"'{s.Split(':')[1].Trim()}'"));
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

                // Insert into StudentCourse table
                string sql1 = $@"INSERT INTO StudentCourse (StudentID, CourseID) 
       SELECT s.StudentID, {courseId} 
       FROM Students s 
       INNER JOIN [User] u ON s.UserID = u.UserID 
       WHERE CONCAT(u.FirstName, ' ', u.LastName) IN ({selectedStudents})";
                using (var command1 = new SqlCommand(sql1, con))
                {
                    command1.ExecuteNonQuery();
                }
            }

            // Close connection
            con.Close();

            // Close connection

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";
            }

        }
    }

