﻿using OODProject.student;
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
using static System.Windows.Forms.AxHost;

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
            checkedListBox1.CheckOnClick = true;

            string sql = @"SELECT 
                      c.CourseID, 
                    u.Userid,
                      c.CourseName, 
                      c.CourseCredit, 
                      c.CourseDescription,
                      b.BranchID,
                      b.BranchName, 
                      t.TeacherID,
                      u.FirstName + ' ' + u.LastName as TeacherName
                      FROM Course c
                      INNER JOIN Branch b ON c.BranchID = b.BranchID
                      INNER JOIN [User] u ON c.TeacherID = u.UserID
                      INNER JOIN Teacher t ON u.UserID = t.UserID
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
                        comboBox1.Text = $"{reader["BranchID"]}: {reader["BranchName"]}".ToString();

                        // Set the selected teacher name in ComboBox2
                        comboBox2.Text = $"{reader["Userid"]}: {reader["TeacherName"]}".ToString();
                    }
                }
                con.Close();
            }

            string sql2 = @"SELECT s.StudentID, u.FirstName, u.LastName 
                               FROM Students s 
                               INNER JOIN [User] u ON s.UserID = u.UserID";
            con.Open();
            using (var command = new SqlCommand(sql2, con))
            {
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        checkedListBox1.Items.Add($"{reader["StudentID"]}: {reader["FirstName"]} {reader["LastName"]}");
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
                        string studentFullName = $"{reader["StudentID"]}: {reader["StudentName"]}";
                        int index = checkedListBox1.Items.IndexOf(studentFullName);
                        if (index != -1)
                        {
                            checkedListBox1.SetItemChecked(index, true);
                        }
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

                    comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;


                }
            }

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

            DialogResult confirmDelete = MessageBox.Show("Are you sure you want to delete this course?", "Confirm", MessageBoxButtons.YesNo);

            if (confirmDelete == DialogResult.Yes)
            {
                con.Open();
                string sql = "DELETE FROM Course WHERE CourseID = @CourseID";
                using (var command = new SqlCommand(sql, con))
                {
                    command.Parameters.AddWithValue("@CourseID", id);
                    command.ExecuteNonQuery();
                }
                con.Close();

                MessageBox.Show("Course deleted successfully.", "Success", MessageBoxButtons.OK);
            }

            Dash.showScreen(new course(Dash));




        }

        private void submitBtn_Click(object sender, EventArgs e)
        {
            string courseName = textBox1.Text;
            string courseDescription = textBox2.Text;
            int courseCredits = int.Parse(textBox3.Text);
            string branchInfo;
            string teacherInfo;
            if (comboBox1.SelectedItem == null)
            {
                branchInfo = comboBox1.Text;
            }
            else
            {
                branchInfo = comboBox1.SelectedItem.ToString();
            }
            if (comboBox1.SelectedItem == null)
            {
                teacherInfo = comboBox2.Text;
            }
            else
            {
                teacherInfo = comboBox2.SelectedItem.ToString();
            }

            // Extract BranchID and TeacherID from the selected items
            int branchId = int.Parse(branchInfo.Split(':')[0]);
            int teacherId = int.Parse(teacherInfo.Split(':')[0]);

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                // Update Course table
                string sql = $@"UPDATE Course 
                  SET CourseName = '{courseName}', 
                      CourseDescription = '{courseDescription}', 
                      CourseCredit = {courseCredits}, 
                      BranchID = {branchId}, 
                      TeacherID = {teacherId} 
                  WHERE CourseID = @CourseID";

                using (var command = new SqlCommand(sql, con))
                {
                    command.Parameters.AddWithValue("@CourseID", id);
                    command.ExecuteNonQuery();
                }

                // Iterate over all items in the CheckedListBox
                for (int i = 0; i < checkedListBox1.Items.Count; i++)
                {
                    bool isChecked = checkedListBox1.GetItemChecked(i);
                    string studentName = checkedListBox1.Items[i].ToString();
                    string[] parts = studentName.Split(':');
                    string studentIdStr = parts[0];
                    int studentId = int.Parse(studentIdStr);

                    if (isChecked)
                    {
                        // If the student is checked, add them to the course
                        string insertSql = $@"INSERT INTO StudentCourse (StudentID, CourseID) 
                                SELECT {studentId}, @CourseID
                                WHERE NOT EXISTS (
                                    SELECT 1 FROM StudentCourse sc
                                    WHERE sc.StudentID = {studentId} AND sc.CourseID = @CourseID
                                )";

                        using (var insertCommand = new SqlCommand(insertSql, con))
                        {
                            insertCommand.Parameters.AddWithValue("@CourseID", id);
                            insertCommand.ExecuteNonQuery();
                        }
                    }
                    else
                    {


                        // If the student is not checked, remove them from the course
                        string deleteSql = $@"DELETE FROM StudentCourse 
                              WHERE StudentID = {studentId} AND CourseID = @CourseID";

                        using (var deleteCommand = new SqlCommand(deleteSql, con))
                        {
                            deleteCommand.Parameters.AddWithValue("@CourseID", id);
                            deleteCommand.ExecuteNonQuery();
                        }
                    }
                }

                con.Close();
            }

            MessageBox.Show("Course updated successfully.", "Success", MessageBoxButtons.OK);
            Dash.showScreen(new course(Dash));
        }
    }
}
