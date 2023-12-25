using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView;

namespace OODProject.Admin
{
    public partial class staff : Form
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

        public staff()
        {
            InitializeComponent();
        }
        
        public staff(adminDash dash)
        {
            InitializeComponent();
            rows();
            this.Dash = dash;
            
        }

        private void rows()
        {
            flowLayoutPanel1.Padding = new Padding(10);
            UserControlNormalList[] lists = new UserControlNormalList[20];
            con.Open();
            string sql = "SELECT TeacherID, FirstName, LastName FROM [User] INNER JOIN Teacher ON [User].UserID = Teacher.UserID";
            using (var command = new SqlCommand(sql, con))
            {
                using (var reader = command.ExecuteReader())
                {
                    int i = 0;
                    while (reader.Read() && i < lists.Length)
                    {
                        lists[i] = new UserControlNormalList();
                        lists[i].ItemName = reader["FirstName"].ToString() + " " + reader["LastName"].ToString();
                        flowLayoutPanel1.Controls.Add(lists[i]);
                        lists[i].Margin = new Padding(10);
                        int staffId = reader.GetInt32(0);
                        lists[i].Clicked += (sender, e) => UserControl_Click(sender, e, staffId);
                        i++;
                    }
                }
            }
            flowLayoutPanel1.Refresh();
            con.Close();
        }



        private void UserControl_Click(object sender, EventArgs e, int staffId)
        {

            if (Dash != null)
            {
                Dash.showScreen(new staffDetails(Dash, this, staffId));
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dash.showScreen(new addStaff(Dash, this));
        }

        private void approveBtn_Click(object sender, EventArgs e)
        {
            Dash.showScreen(new approveUsers(Dash, this));
        }
    }
}
