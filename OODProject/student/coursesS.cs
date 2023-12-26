using OODProject.Admin;
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

namespace OODProject.student
{
    public partial class coursesS : Form
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
        public coursesS()
        {
            InitializeComponent();
            rows();
        }
        private int id;
        public coursesS(int id)
        {
            InitializeComponent();
            
            this.id = id;
            rows();
            Console.WriteLine(id);
            
    
        }


        private void rows()
        {
            flowLayoutPanel1.Padding = new Padding(10);
            flowLayoutPanel1.Padding = new Padding(10);
            con.Open();
            string sql = @"SELECT s.StudentID, c.CourseName, c.CourseDescription 
FROM [User] u 
INNER JOIN Students s ON u.UserID = s.UserID
INNER JOIN StudentCourse sc ON s.StudentID = sc.StudentID
INNER JOIN Course c ON sc.CourseID = c.CourseID
WHERE u.UserID = @userId";

            using (var command = new SqlCommand(sql, con))
            {
                command.Parameters.AddWithValue("@userId", id);
                using (var reader = command.ExecuteReader())
                {
                    int j = 0;
                    while (reader.Read())
                    {
                        UserControlDetail list = new UserControlDetail();
                        list.ItemName = reader["CourseName"].ToString();
                        list.Detail = reader["CourseDescription"].ToString();
                        flowLayoutPanel1.Controls.Add(list);
                        list.Margin = new Padding(10);
                        j++;
                    }
                }
            }
            con.Close();
        }









    }

}

