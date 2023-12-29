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

namespace OODProject.Admin.download
{
    public partial class InfoDetail : Form
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
        public information info { get; set; }
        public bool infoUsed = false;
        private int id;

        public InfoDetail()
        {
            InitializeComponent();
        }

        public InfoDetail(adminDash Dash, information info, int id)
        {
            InitializeComponent();
            this.Dash = Dash;
            this.info = info;
            infoUsed = true;
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
                    command.Parameters.AddWithValue("@id", id);

                    // Execute the query and get the SqlDataReader
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Loop through the result set
                        while (reader.Read())
                        {
                            string fileName = reader["fileName"].ToString();
                            byte[] fileData = (byte[])reader["FileData"];
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
             Dash.showScreen(new information(Dash)); 
            
        }
    }
}
