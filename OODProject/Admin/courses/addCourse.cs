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
    public partial class addCourse : Form
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
        private courses coursesForm { get; set; }
        public addCourse(adminDash dash, courses Courses)
        {
            InitializeComponent();
            Dash = dash;
            coursesForm = Courses;

            con.Open();
            string sql = "SELECT name FROM Teacher";
            using (var command = new SqlCommand(sql, con))
            {
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        comboBox1.Items.Add(reader["name"].ToString());
                    }
                }
            }
            con.Close();
        }
        public addCourse()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Dash.showScreen(coursesForm);
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            string description = textBox2.Text;
            string credits = textBox3.Text;


            con.Open();
            string sql = "INSERT INTO Course ( CourseName, CourseDescription, CourseCredit) VALUES ( @CourseName, @CourseDescription, @CourseCredit)";
            using (var command = new SqlCommand(sql, con))
            {


                command.Parameters.AddWithValue("@CourseName", name);
                command.Parameters.AddWithValue("@CourseDescription", description);
                command.Parameters.AddWithValue("@CourseCredit", credits);
                command.ExecuteNonQuery();
            }
            con.Close();

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }
    }
}
