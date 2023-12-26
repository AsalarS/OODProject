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
            string sql = $"SELECT courseName, courseID FROM Course WHERE TeacherID = {ID}";
            using (var command = new SqlCommand(sql, con))
            {
                using (var reader = command.ExecuteReader())
                {
                    var dt = new DataTable();
                    dt.Load(reader);

                    comboBox1.DataSource = dt;
                    comboBox1.DisplayMember = "courseName";
                    comboBox1.ValueMember = "courseID";
                }
            }
            con.Close();
        }


        public files()
        {
            InitializeComponent();
            this.listView1.Padding = new Padding(10);
            PopulateCourses();
        }

        public files(int ID)
        {
            InitializeComponent();
            this.listView1.Padding = new Padding(10);
            this.ID = ID;
            PopulateCourses();
        }


        private int selectedCourseId;
        private int ID;



        public void load_file(int teacherId)
        {
            string sql = $@"
      SELECT cf.filePath 
      FROM CourseFiles cf
      JOIN Course c ON cf.courseID = c.courseID
      WHERE c.TeacherID = {teacherId}
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
                            string filePath = reader["filePath"].ToString();
                            filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads", "files", filePath);
                            FileInfo fileInfo = new FileInfo(filePath);
                            string fileExtension = fileInfo.Extension.ToUpper();
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
                            listView1.Items.Add(fileInfo.Name, imageIndex);
                            PopulateCourses();
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
                    string targetPath = Path.Combine(filePath, Path.GetFileName(fileName));
                    File.Copy(fileName, targetPath, true);

                    // Insert a record into the CourseFiles table
                    string insertSql = $"INSERT INTO CourseFiles (courseID, filePath) VALUES ({selectedCourseId}, '{targetPath}')";
                    using (var con = new SqlConnection(connectionString))
                    {
                        con.Open();
                        using (var command = new SqlCommand(insertSql, con))
                        {
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
                string fullPath = Path.Combine(filePath, selectedFile);
                try
                {
                    File.Delete(fullPath);
                    load_file(selectedCourseId);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var drv = comboBox1.SelectedItem as DataRowView;
            if (drv != null)
            {
                selectedCourseId = Convert.ToInt32(drv.Row["courseID"]);
                load_file(selectedCourseId);
            }

        }
    }
}
