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
    public partial class approveUsers : Form
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
        private staff staffForm { get; set; }
        public approveUsers(adminDash dash, staff Staff)
        {
            InitializeComponent();
            Dash = dash;
            staffForm = Staff;
            rows();
        }

        public approveUsers()
        {
            InitializeComponent();
            rows();
        }

        private void rows()
        {
            flowLayoutPanel1.Padding = new Padding(10);
            UserControlListWithTwoButton[] lists = new UserControlListWithTwoButton[20];

            string sql = "SELECT * FROM [User] WHERE Approved = 0";
            using (var command = new SqlCommand(sql, con))
            {
                con.Open();
                using (var reader = command.ExecuteReader())
                {
                    int i = 0;
                    while (reader.Read() && i < lists.Length)
                    {
                        string fullName = reader["FirstName"].ToString() + " " + reader["LastName"].ToString();
                        lists[i] = new UserControlListWithTwoButton(i);
                        lists[i].ItemName = fullName;
                        lists[i].BtnOne = "Deny";
                        lists[i].BtnTwo = "Approve";
                        flowLayoutPanel1.Controls.Add(lists[i]);
                        lists[i].Margin = new Padding(10);
                        int courseId = reader.GetInt32(0);
                        lists[i].Clicked += (sender, e) => UserControl_Click(sender, e, courseId);
                        lists[i].BtnOneClick += (sender, e, courseIdZ) => BtnOne_Click(sender, e, courseId);
                        lists[i].BtnTwoClick += (sender, e, courseIdZ) => BtnTwo_Click(sender, e, courseId);

                        i++;
                    }
                }
                con.Close();
            }
        }

        private void UserControl_Click(object sender, EventArgs e, int courseId)
        {
            if (Dash != null)
            {
                Console.WriteLine("Clicked!");
            }

        }
        private void BtnOne_Click(object sender, EventArgs e, int courseId)
        {
            string sql = $"DELETE FROM [Teacher] WHERE UserID = {courseId}";
            using (var command = new SqlCommand(sql, con))
            {
                con.Open();
                command.ExecuteNonQuery();
                con.Close();
            }

            sql = $"DELETE FROM [User] WHERE UserID = {courseId}";
            using (var command = new SqlCommand(sql, con))
            {
                con.Open();
                command.ExecuteNonQuery();
                con.Close();
            }
            MessageBox.Show("Row deleted successfully!");
            Dash.showScreen(new approveUsers(Dash, staffForm));
        }

        private void BtnTwo_Click(object sender, EventArgs e, int courseId)
        {
            string sql = $"UPDATE [User] SET Approved = 1 WHERE UserID = {courseId}";
            using (var command = new SqlCommand(sql, con))
            {
                con.Open();
                command.ExecuteNonQuery();
                con.Close();
            }
            MessageBox.Show("Row updated successfully!");
            Dash.showScreen(new approveUsers(Dash, staffForm));
        }


        private void button2_Click(object sender, EventArgs e)
        {
            Dash.showScreen(staffForm);
        }
    }
}
