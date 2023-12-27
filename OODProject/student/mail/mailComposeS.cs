using OODProject.teacher;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace OODProject.student.mail
{
    public partial class mailComposeS : Form
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
        private string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads", "files");
        private List<string> filePaths = new List<string>();
        private HashSet<string> uniqueFiles = new HashSet<string>();
        private int count = 0;

        public mailComposeS()
        {
            InitializeComponent();
        }
        public studentDash Dash { get; set; }
        private mailS mailForm { get; set; }

        public mailComposeS(studentDash dash, mailS form)
        {
            InitializeComponent();
            Dash = dash;
            mailForm = form;
        }
        private int id;
      
        public mailComposeS(studentDash dash, mailS form , int id)
        {
            InitializeComponent();
            Dash = dash;
            mailForm = form;
            this.id = id;
        


        }

        public void load_file()
        {
            listView1.Items.Clear();
            string fileExtension = "";

            for (int i = 0; i < filePaths.Count; i++)
            {
                var fileInfo = new FileInfo(filePaths[i]);
                fileExtension = fileInfo.Extension.ToUpper();
                switch (fileExtension)
                {
                    case ".MP3":
                    case ".MP2":
                        listView1.Items.Add(fileInfo.Name, 3);
                        break;
                    case ".EXE":
                    case ".COM":
                        listView1.Items.Add(fileInfo.Name, 5);
                        break;
                    case ".MP4":
                    case ".AVI":
                    case ".MKV":
                        listView1.Items.Add(fileInfo.Name, 4);
                        break;
                    case ".PDF":
                        listView1.Items.Add(fileInfo.Name, 2);
                        break;
                    case ".DOC":
                    case ".DOCX":
                        listView1.Items.Add(fileInfo.Name, 1);
                        break;
                    case ".PNG":
                    case ".JPG":
                    case ".JPEG":
                        listView1.Items.Add(fileInfo.Name, 7);
                        break;
                    default:
                        listView1.Items.Add(fileInfo.Name, 6);
                        break;
                }
            }
        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && listView1.SelectedItems.Count > 0)
            {
                contextMenuStrip1.Show(listView1, e.Location);
            }
        }

        private void contextMenuStrip1_MouseClick(object sender, MouseEventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listView1.SelectedItems[0];
                filePaths.Remove(selectedItem.Tag as string);
                uniqueFiles.Remove(selectedItem.Tag as string);
                count--;
                listView1.Items.Remove(selectedItem);
            }
        }
        private int teacherID;
        private int studentID;
        private int teacherUserID;
        private void button2_Click(object sender, EventArgs e)
        {

            try
            {
                con.Open();
                string sql1 = "SELECT Teacher.TeacherID, [User].UserID FROM Teacher INNER JOIN [User] ON Teacher.UserID = [User].UserID WHERE [User].Email = @email";

                using (var command = new SqlCommand(sql1, con))
                {
                    command.Parameters.AddWithValue("@email", recipientTextBox.Text);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            teacherID = reader.GetInt32(0);
                            teacherUserID = reader.GetInt32(1);
                            // Now teacherUserID holds the UserID of the teacher
                        }
                        else
                        {
                            throw new Exception("No teacher found with the given email.");
                        }
                    }
                }
                con.Close();

                con.Open();
                string sql2 = "SELECT Students.StudentID FROM Students WHERE Students.UserID = @userId";

                using (var command = new SqlCommand(sql2, con))
                {
                    command.Parameters.AddWithValue("@userId", id);

                    studentID = Convert.ToInt32(command.ExecuteScalar());
                }
                con.Close();
                con.Open();


                string sql = "INSERT INTO Email (Subject, Content, SenderID, RecipientID, TeacherID, StudentID, EmailDate) VALUES (@subject, @content, @senderID, @recipientID, @TeacherID, @StudentID, @EmailDate)";

                using (var command = new SqlCommand(sql, con))
                {
                    command.Parameters.AddWithValue("@subject", textBox2.Text);
                    command.Parameters.AddWithValue("@content", mailBody.Text);
                    command.Parameters.AddWithValue("@senderID", id);
                    command.Parameters.AddWithValue("@recipientID", teacherUserID);
                    command.Parameters.AddWithValue("@TeacherID", teacherID);
                    command.Parameters.AddWithValue("@StudentID", studentID);
                    command.Parameters.AddWithValue("@EmailDate", DateTime.Now);

                    command.ExecuteNonQuery();
                    con.Close();
                }
                Dash.showScreen(mailForm);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Dash.showScreen(mailForm);
        }

        private void attachBtn_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                foreach (string fileName in openFileDialog1.FileNames)
                {
                    if (count >= 10 || uniqueFiles.Contains(fileName))
                    {
                        MessageBox.Show("You have reached the maximum number of files or the file is already added.", "Limit Reached", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    string targetPath = Path.Combine(filePath, Path.GetFileName(fileName));
                    filePaths.Add(targetPath);
                    uniqueFiles.Add(fileName);
                    count++;
                }
                load_file();
            }
        }
    }
}
