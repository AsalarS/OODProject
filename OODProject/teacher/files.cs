using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OODProject.teacher
{
    public partial class files : Form
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

        private void PopulateCourses()
        {
            con.Open();
            string sql = $@"
     SELECT c.courseName, c.courseID 
     FROM Course c
     INNER JOIN Teacher t ON c.TeacherID = t.TeacherID
     WHERE t.UserID = {ID}
 ";
            using (var command = new SqlCommand(sql, con))
            {
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string courseName = reader["courseName"].ToString();
                        int courseID = (int)reader["courseID"];
                        comboBox1.Items.Add($"{courseID} - {courseName}");
                    }
                }
                con.Close();
            }
            /*comboBox1.DisplayMember = "";
            comboBox1.ValueMember = "";*/
        }







        public files()
        {
            InitializeComponent();
            this.listView1.Padding = new Padding(10);
            PopulateCourses();
            load_file(null);
        }

        public files(int ID)
        {
            this.ID = ID;
            InitializeComponent();
            this.listView1.Padding = new Padding(10);
            Console.WriteLine(ID + "files consturcter");
            PopulateCourses();
        }


        private int selectedCourseId;
        private int ID;



        public void load_file(int? teacherId)
        {
            string sql = teacherId.HasValue
                ? $@"
           SELECT cf.FileData, cf.OriginalFileName 
           FROM CourseFiles cf
           JOIN Course c ON cf.CourseID = c.CourseID
           WHERE c.TeacherID = {teacherId} OR cf.CourseID = {selectedCourseId}
       "
                : $@"
           SELECT cf.FileData, cf.OriginalFileName 
           FROM CourseFiles cf
       ";

            using (var con = new SqlConnection(connectionString))
            {
                con.Open();
                using (var command = new SqlCommand(sql, con))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        listView1.Items.Clear();
                        while (reader.Read())
                        {
                            byte[] fileData = (byte[])reader["FileData"];
                            string originalFileName = reader["OriginalFileName"].ToString();
                            string fileExtension = Path.GetExtension(originalFileName).ToUpper();
                            Console.WriteLine(fileExtension);
                            int imageIndex;
                            switch (fileExtension)
                            {
                                case ".MP3":
                                case ".MP2":
                                    imageIndex = 3;
                                    break;
                                case ".EXE":
                                case ".COM":
                                    imageIndex = 5;
                                    break;
                                case ".MP4":
                                case ".AVI":
                                case ".MKV":
                                    imageIndex = 4;
                                    break;
                                case ".PDF":
                                    imageIndex = 2;
                                    break;
                                case ".DOC":
                                case ".DOCX":
                                    imageIndex = 1;
                                    break;
                                case ".PNG":
                                case ".JPG":
                                case ".JPEG":
                                    imageIndex = 7;
                                    break;
                                default:
                                    imageIndex = 6;
                                    break;
                            }
                            listView1.Items.Add(originalFileName, imageIndex);
                        }
                    }
                }
            }
        }





        private string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads", "files");

        private void button1_Click_1(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                foreach (string fileName in openFileDialog1.FileNames)
                {
                    byte[] fileData = File.ReadAllBytes(fileName);

                    // Append a timestamp to the filename
                    string uniqueFileName = Path.GetFileNameWithoutExtension(fileName) + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + Path.GetExtension(fileName);

                    // Check if the course exists
                    string checkSql = $"SELECT COUNT(*) FROM Course WHERE CourseID = {selectedCourseId}";
                    using (var con = new SqlConnection(connectionString))
                    {
                        con.Open();
                        using (var command = new SqlCommand(checkSql, con))
                        {
                            int count = (int)command.ExecuteScalar();
                            if (count == 0)
                            {
                                MessageBox.Show($"No course found with ID {selectedCourseId}.");
                                continue;
                            }
                        }
                    }

                    // Insert a record into the CourseFiles table
                    string insertSql = $"INSERT INTO CourseFiles (CourseID, FileData, OriginalFileName) VALUES ({selectedCourseId}, @FileData, @OriginalFileName)";
                    using (var con = new SqlConnection(connectionString))
                    {
                        con.Open();
                        using (var command = new SqlCommand(insertSql, con))
                        {
                            command.Parameters.AddWithValue("@FileData", fileData);
                            command.Parameters.AddWithValue("@OriginalFileName", uniqueFileName);
                            command.ExecuteNonQuery();
                        }
                    }
                }
                load_file(selectedCourseId);
            }
        }

        private void listView1_MouseClick_1(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && listView1.SelectedItems.Count > 0)
            {
                contextMenuStrip1.Show(listView1, e.Location);
            }
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                string selectedFile = listView1.SelectedItems[0].Text;
                string fullPath = Path.Combine(filePath, selectedFile);
                try
                {
                    Process.Start(fullPath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                string selectedFile = listView1.SelectedItems[0].Text;

                // Delete the record from the database
                string deleteSql = $"DELETE FROM CourseFiles WHERE OriginalFileName = '{selectedFile}' AND CourseID = {selectedCourseId}";
                using (var con = new SqlConnection(connectionString))
                {
                    con.Open();
                    using (var command = new SqlCommand(deleteSql, con))
                    {
                        try
                        {
                            command.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            // Log the exception message
                            Console.WriteLine("Error: " + ex.Message);
                        }
                    }
                }

                load_file(selectedCourseId);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                string selectedItem = comboBox1.SelectedItem.ToString();
                string[] parts = selectedItem.Split(' ');
                if (parts.Length >= 2)
                {
                    string courseIdStr = parts[0];
                    if (int.TryParse(courseIdStr, out int courseId))
                    {
                        selectedCourseId = courseId;
                        load_file(selectedCourseId);
                    }
                }
            }
        }
    }
}
