using OODProject.Admin.download;
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

namespace OODProject.Admin
{
    public partial class information : Form
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
        private int annoucnementId;

        public information(adminDash dash)
        {
            InitializeComponent();
            rows();
            this.Dash = dash;

        }
        public information()
        {
            InitializeComponent();
            rows();
        }
        private void rows()
        {
            flowLayoutPanel1.Padding = new Padding(10);

            // Query to select announcements from the database
            string query = "SELECT * FROM [dbo].[announcements]";

            try
            {
                // Open the connection
                con.Open();

                // Create a SqlCommand to execute the query
                using (SqlCommand command = new SqlCommand(query, con))
                {
                    // Execute the query and get the SqlDataReader
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Loop through the result set
                        while (reader.Read())
                        {
                            // Create a new UserControlNormalList
                            UserControlNormalList list = new UserControlNormalList();
                            list.ItemName = reader["title"].ToString();
                            flowLayoutPanel1.Controls.Add(list);
                            list.Margin = new Padding(10);

                            // Assign the announcementID to ID from the announcements table
                            annoucnementId = Convert.ToInt32(reader["id"]);

                            list.Clicked += UserControl_Click;
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


        private void UserControl_Click(object sender, EventArgs e)
        {

            if (Dash != null)
            {
                Dash.showScreen(new InfoDetail(Dash, this, annoucnementId));
            }

        }
    }
}
