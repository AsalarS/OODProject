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

                string sql = "INSERT INTO Email (Subject, Content, SenderID, RecipientID, TeacherID, StudentID, EmailDate) OUTPUT INSERTED.EmailID VALUES (@subject, @content, @senderID, @recipientID, @TeacherID, @StudentID, @EmailDate)";

                using (var command = new SqlCommand(sql, con))
                {
                    command.Parameters.AddWithValue("@subject", textBox2.Text);
                    command.Parameters.AddWithValue("@content", mailBody.Text);
                    command.Parameters.AddWithValue("@senderID", id);
                    command.Parameters.AddWithValue("@recipientID", recipientUserID);
                    command.Parameters.AddWithValue("@TeacherID", teacherID);
                    command.Parameters.AddWithValue("@StudentID", studentID);
                    command.Parameters.AddWithValue("@EmailDate", DateTime.Now);

                    int emailId = (int)command.ExecuteScalar();
                    con.Close();

                    // insert file paths into EmailAttachments table
                    string sqlAttachment = "INSERT INTO EmailAttachments (EmailID, FileData, OriginalFileName) VALUES (@EmailID, @FileData, @OriginalFileName)";

                    foreach (ListViewItem item in listView1.Items)
                    {
                        byte[] fileData = item.Tag as byte[];
                        if (fileData != null)
                        {
                            using (var commandAttachment = new SqlCommand(sqlAttachment, con))
                            {
                                commandAttachment.Parameters.AddWithValue("@EmailID", emailId);
                                commandAttachment.Parameters.AddWithValue("@FileData", fileData);
                                commandAttachment.Parameters.AddWithValue("@OriginalFileName", item.Text); // Use the original file name

                                con.Open();
                                commandAttachment.ExecuteNonQuery();
                                con.Close();
                            }
                        }
                    }


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
                    filePaths.Add(targetPath);
                    uniqueFiles.Add(fileName);
                    count++;
                }
                load_file();
            }
        }

        public void load_file()
        {
            listView1.Items.Clear();
            string fileExtension = "";

            for (int i = 0; i < uniqueFiles.Count; i++)
            {
                string fileName = uniqueFiles.ElementAt(i);
                string filePath = Path.Combine(this.filePath, fileName);
                byte[] fileData = File.ReadAllBytes(filePath);
                fileExtension = Path.GetExtension(fileName).ToUpper();
                ListViewItem item = new ListViewItem(fileName);
                item.Tag = fileData;

                switch (fileExtension)
                {
                    case ".MP3":
                    case ".MP2":
                        item.ImageIndex = 3;
                        break;
                    case ".EXE":
                    case ".COM":
                        item.ImageIndex = 5;
                        break;
                    case ".MP4":
                    case ".AVI":
                    case ".MKV":
                        item.ImageIndex = 4;
                        break;
                    case ".PDF":
                        item.ImageIndex = 2;
                        break;
                    case ".DOC":
                    case ".DOCX":
                        item.ImageIndex = 1;
                        break;
                    case ".PNG":
                    case ".JPG":
                    case ".JPEG":
                        item.ImageIndex = 7;
                        break;
                    default:
                        item.ImageIndex = 6;
                        break;
                }

                listView1.Items.Add(item);
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
