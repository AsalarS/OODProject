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
    public partial class learning : Form
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

        public learning()
        {
            InitializeComponent();
            load_file(null);
            this.listView1.Padding = new Padding(10);
        }

        private int userId;

        public learning(int userId)
        {
            InitializeComponent();
            this.listView1.Padding = new Padding(10);
            this.userId = userId;
            PopulateCourses();
        }


        private string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads", "files");

        public void load_file(int? courseId)
        {
            string sql = courseId.HasValue
                ? $@"
    SELECT cf.FileId, cf.FileData, cf.OriginalFileName 
    FROM CourseFiles cf
    WHERE cf.CourseID = {courseId}
 "
                : $@"
    SELECT cf.FileId, cf.FileData, cf.OriginalFileName 
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
                            int fileId = (int)reader["FileId"];
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
                            ListViewItem item = new ListViewItem(originalFileName, imageIndex);
                            item.Tag = fileId; // Assign the fileId to the Tag property
                            listView1.Items.Add(item);
                        }
                    }
                }
            }
        }

        private byte[] FetchFileDataFromDatabase(int fileId)
        {
            byte[] fileData = null;
            string sql = $@"
       SELECT cf.FileData 
       FROM CourseFiles cf
       WHERE cf.FileId = {fileId}
   ";
            using (var con = new SqlConnection(connectionString))
            {
                con.Open();
                using (var command = new SqlCommand(sql, con))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            fileData = (byte[])reader["FileData"];
                        }
                    }
                }
            }
            return fileData;
        }


        public void PopulateCourses()
        {
            List<int> courseIds = new List<int>();
            string sql = $@"
     SELECT c.courseName, c.courseID 
     FROM Course c
     INNER JOIN StudentCourse sc ON c.CourseID = sc.CourseID
     INNER JOIN Students s ON sc.StudentID = s.StudentID
     INNER JOIN [User] u ON s.UserID = u.UserID
     WHERE u.UserID = {userId}
 ";

            using (var command = new SqlCommand(sql, con))
            {
                con.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string courseName = reader["courseName"].ToString();
                        int courseID = (int)reader["courseID"];
                        comboBox1.Items.Add($"{courseID} - {courseName}");
                        courseIds.Add(courseID);
                    }
                }
                con.Close();
            }

            if (courseIds.Any())
            {
                load_file(courseIds[0]);
            }
        }





        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && listView1.SelectedItems.Count > 0)
            {
                contextMenuStrip1.Show(listView1, e.Location);
            }
        }

        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ListViewItem selectedItem = listView1.SelectedItems[0];
            int fileId = (int)selectedItem.Tag;
            byte[] fileData = FetchFileDataFromDatabase(fileId); // Fetch the file data from the database
            string fileName = selectedItem.Text;

            // Show the save file dialog
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "All Files (*.*)|*.*";
                saveFileDialog.Title = "Save File";
                saveFileDialog.FileName = fileName;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Save the file
                    File.WriteAllBytes(saveFileDialog.FileName, fileData);
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedItem = comboBox1.SelectedItem.ToString();
            string[] parts = selectedItem.Split('-');
            string courseIDString = parts[0].Trim(); // trim removes any leading or trailing spaces
            int courseID = int.Parse(courseIDString); // convert the course ID from a string to an integer
            load_file(courseID);
        }
    }
}
