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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace OODProject.teacher.mail
{
    public partial class mailCompose : Form
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
        public teachDash Dash { get; set; }
        private Mail mailForm { get; set; }

        public mailCompose()
        {
            InitializeComponent();
        }
        private int id;
        public mailCompose(teachDash dash, Mail form, int id)
        {
            InitializeComponent();
            Dash = dash;
            mailForm = form;
            this.id = id;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Dash.showScreen(mailForm);
        }
        private int teacherID;
        private int recipientUserID;
        private int studentID;



        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                string sql1 = "SELECT [User].UserID FROM [User] WHERE [User].Email = @email";

                using (var command = new SqlCommand(sql1, con))
                {
                    command.Parameters.AddWithValue("@email", recipientTextBox.Text);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            recipientUserID = reader.GetInt32(0);
                            // Now recipientUserID holds the UserID of the recipient
                        }
                        else
                        {
                            throw new Exception("No user found with the given email.");
                        }
                    }
                }
                con.Close();

                con.Open();
                string sql2 = "SELECT Teacher.TeacherID FROM Teacher WHERE Teacher.UserID = @userId";

                using (var command = new SqlCommand(sql2, con))
                {
                    command.Parameters.AddWithValue("@userId", id);

                    teacherID = Convert.ToInt32(command.ExecuteScalar());
                }
                con.Close();
                con.Open();

                string sql3 = "SELECT Students.StudentID FROM Students WHERE Students.UserID = @studentId";

                using (var command = new SqlCommand(sql3, con))
                {
                    command.Parameters.AddWithValue("@studentId", recipientUserID);

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
                    command.Parameters.AddWithValue("@recipientID", recipientUserID);
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








        private string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads", "files");
        private List<string> filePaths = new List<string>();
        private HashSet<string> uniqueFiles = new HashSet<string>();
        private int count = 0;


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
                    byte[] fileData = File.ReadAllBytes(targetPath);
                    ListViewItem item = new ListViewItem(Path.GetFileName(fileName));
                    item.Tag = fileData;
                    listView1.Items.Add(item);
                    count++;
                }
            }
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

        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listView1.SelectedItems[0];
                selectedItem.Tag = null;
                count--;
                listView1.Items.Remove(selectedItem);
            }
        }
    }
}
