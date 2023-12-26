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
    public partial class courseDetails : Form
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

        public courseDetails()
        {
            InitializeComponent();
        }

        public adminDash Dash { get; set; }
        private course coursesForm { get; set; }
        private int id;
        public courseDetails(adminDash dash, course course, int id)
        {
            InitializeComponent();
            Dash = dash;
            coursesForm = course;
            this.id = id;

            string sql = @"SELECT 
               c.CourseID, 
               c.CourseName, 
               c.CourseCredit, 
               c.CourseDescription, 
               b.BranchName, 
               u.FirstName + ' ' + u.LastName as TeacherName
               FROM Course c
               INNER JOIN Branch b ON c.BranchID = b.BranchID
               INNER JOIN [User] u ON c.TeacherID = u.UserID
               WHERE c.CourseID = @CourseId";

            using (var command = new SqlCommand(sql, con))
            {
                command.Parameters.AddWithValue("@CourseId", id);
                con.Open();
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        textBox1.Text = reader["CourseName"].ToString();
                        textBox2.Text = reader["CourseDescription"].ToString();
                        textBox3.Text = reader["CourseCredit"].ToString();
                        IDNumber.Text = reader["CourseID"].ToString();

                        // Set the selected branch name in ComboBox1
                        comboBox1.Text = reader["BranchName"].ToString();

                        // Set the selected teacher name in ComboBox2
                        comboBox2.Text = reader["TeacherName"].ToString();
                    }
                }
                con.Close();
            }

            string sql1 = @"SELECT 
              sc.StudentID, 
              u.FirstName + ' ' + u.LastName as StudentName
              FROM StudentCourse sc
              INNER JOIN Students s ON sc.StudentID = s.StudentID
              INNER JOIN [User] u ON s.UserID = u.UserID
              WHERE sc.CourseID = @CourseId";

            using (var command = new SqlCommand(sql1, con))
            {
                command.Parameters.AddWithValue("@CourseId", id);
                con.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        listBox2.Items.Add(reader["StudentName"].ToString());
                    }
                }
                con.Close();
            }
            con.Open();
            string sql3 = "SELECT BranchId, BranchName FROM Branch";

            using (var command = new SqlCommand(sql3, con))
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



        }

        private void button2_Click(object sender, EventArgs e)
        {
            Dash.showScreen(new course(Dash));
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
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
                // con.Close();
            }
            else
            {
                MessageBox.Show("Please select a branch.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
