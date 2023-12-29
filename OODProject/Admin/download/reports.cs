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
    public partial class reports : Form
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

        public reports(adminDash dash)
        {
            InitializeComponent();
            rows();
            this.Dash = dash;

        }
        public reports()
        {
            InitializeComponent();
            rows();
        }
        private void rows()
        {
            // Create a new SqlCommand to select the titles from the announcements table
            SqlCommand cmd = new SqlCommand("SELECT title FROM announcements", con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            // Initialize the array of UserControlNormalList controls
            UserControlNormalList[] lists = new UserControlNormalList[20];

            // Iterate through the rows returned by the query
            int i = 0;
            while (reader.Read() && i < lists.Length)
            {
                // Retrieve the title from the current row
                string title = reader["title"].ToString();

                // Create a new UserControlNormalList control and set its ItemName property to the title
                lists[i] = new UserControlNormalList();
                lists[i].ItemName = title;

                // Add the control to the flowLayoutPanel1 and set its Margin property
                flowLayoutPanel1.Controls.Add(lists[i]);
                lists[i].Margin = new Padding(10);

                // Attach the UserControl_Click event handler to the Clicked event
                lists[i].Clicked += UserControl_Click;

                // Move to the next iteration
                i++;
            }

            // Close the SqlDataReader and the SqlConnection
            reader.Close();
            con.Close();
        }


        private void UserControl_Click(object sender, EventArgs e)
        {

            if (Dash != null)
            {
                Dash.showScreen(new downloadDetail(Dash, this));
            }

        }
    }
}
