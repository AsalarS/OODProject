using OODProject.teacher;
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

namespace OODProject.student.mail
{
    public partial class mailDetailS : Form
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
        public studentDash Dash { get; set; }
        private mailS mailForm { get; set; }

        public mailDetailS()
        {
            InitializeComponent();
        }
        private int id;
        public mailDetailS(studentDash Dash, mailS mailForm)
        {
            InitializeComponent();
            this.Dash = Dash;
            this.mailForm = mailForm;
        }
        public mailDetailS(studentDash Dash, mailS mailForm, int id)
        {
            InitializeComponent();
            this.Dash = Dash;
            this.mailForm = mailForm;
            this.id = id;

            con.Open();

            string sql = "SELECT U.Email, E.Content, E.Subject FROM Email E INNER JOIN [User] U ON E.SenderID = U.UserID WHERE E.EmailID = @emailId";

            using (var command = new SqlCommand(sql, con))
            {
                command.Parameters.AddWithValue("@emailId", id);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        recipientTextBox.Text = reader.GetString(0); // Set the User's Email
                        mailBody.Text = reader.GetString(1); // Set the Content
                        branchesLbl.Text = reader.GetString(2);
                    }
                }
            }
            con.Close();

            load_files();

        }

        public void load_files()
        {
            listView1.Items.Clear();

            string sql = "SELECT FileData, OriginalFileName FROM EmailAttachments WHERE EmailID = @EmailID";

            using (var command = new SqlCommand(sql, con))
            {
                command.Parameters.AddWithValue("@EmailID", id);

                con.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        byte[] fileData = (byte[])reader["FileData"];
                        string fileName = reader["OriginalFileName"].ToString();

                        ListViewItem item = new ListViewItem(fileName);
                        item.Tag = fileData;

                        string fileExtension = Path.GetExtension(fileName).ToUpper();
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
                con.Close();
            }
        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && listView1.SelectedItems.Count > 0)
            {
                contextMenuStrip1.Show(listView1, e.Location);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dash.showScreen(mailForm);
        }

        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listView1.SelectedItems[0];
                string originalFileName = selectedItem.Text;
                byte[] fileData = selectedItem.Tag as byte[];

                if (fileData != null)
                {
                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.FileName = originalFileName;
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        File.WriteAllBytes(saveFileDialog.FileName, fileData);
                        MessageBox.Show("File downloaded successfully!");
                    }
                }
            }
        }
    }
}
