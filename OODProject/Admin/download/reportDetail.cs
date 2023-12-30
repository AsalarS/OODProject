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

namespace OODProject.Admin.download
{
    public partial class reportDetail : Form
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
        public reports repo { get; set; }
        private int id;
        public bool infoUsed = false;

        public reportDetail()
        {
            InitializeComponent();
        }

        public reportDetail(adminDash Dash, reports repo, int id)
        {
            InitializeComponent();
            this.Dash = Dash;
            this.repo = repo;
            this.id = id;
            load_file();


            
        }

        public void load_file()
        {
            listView1.Items.Clear();
            string fileExtension = "";

            // Query to select announcements from the database
            string query = @"SELECT * FROM [dbo].[announcements] WHERE [id] = @id";

            try
            {
                // Open the connection
                con.Open();

                // Create a SqlCommand to execute the query
                using (SqlCommand command = new SqlCommand(query, con))
                {
                    // Add the UserID parameter to the command
                    Console.WriteLine(id);
                    command.Parameters.AddWithValue("@id", id);

                    // Execute the query and get the SqlDataReader
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        

                        // Loop through the result set
                        while (reader.Read())
                        {
                            recipientTextBox.Text = reader["Title"].ToString();
                            textBox1.Text = reader["scope"].ToString();
                            mailBody.Text = reader["description"].ToString();

                            string fileName = reader["fileName"].ToString();
                            byte[] fileData;
                            if (reader["FileData"] != DBNull.Value)
                            {
                                fileData = (byte[])reader["FileData"];
                            }
                            else
                            {
                                fileData = null; 
                            }

                            // Load the files for the announcement
                            /*string fileName = "grades.txt"; // Hardcoded file name*/
                            ListViewItem item = new ListViewItem(fileName);
                            item.Tag = fileData;
                            item.ImageIndex = 6;

                            listView1.Items.Add(item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading announcements: " + ex.Message);
            }
            finally
            {
                // Close the connection
                con.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dash.showScreen(new reports(Dash));
        }

        private void submitBtn_Click(object sender, EventArgs e)
        {
            string title = recipientTextBox.Text;
            string scope = textBox1.Text;
            string desc = mailBody.Text;

            // Define the SQL query
            string queryStr = "UPDATE announcements SET title=@Title, scope=@Scope, description=@Description WHERE id=@Id";

            // Create a new SqlCommand with the SQL query and the SqlConnection
            SqlCommand cmd = new SqlCommand(queryStr, con);

            // Add the parameters to the SqlCommand
            cmd.Parameters.AddWithValue("@Title", title);
            cmd.Parameters.AddWithValue("@Scope", scope);
            cmd.Parameters.AddWithValue("@Description", desc);
            cmd.Parameters.AddWithValue("@Id", id);

            // Open the SqlConnection
            con.Open();

            // Execute the SqlCommand
            cmd.ExecuteNonQuery();

            // Close the SqlConnection
            con.Close();

            Dash.showScreen(new reports(Dash)); ;

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
                string originalFileName = selectedItem.Text;
                byte[] fileData = selectedItem.Tag as byte[];

                if (fileData != null)
                {
                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Filter = "Text Files (.txt)|*.txt";
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
