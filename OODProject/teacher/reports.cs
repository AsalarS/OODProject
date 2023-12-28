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

namespace OODProject.teacher
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
        public reports()
        {
            InitializeComponent();
        }
        private int id;
        public reports(int id)
        {
            InitializeComponent();
            this.id = id;
            con.Open();
            Console.WriteLine(id);
            PopulateCoursesByTeacher();
            
            this.comboBox1.SelectionChangeCommitted += new EventHandler(this.comboBox1_SelectionChangeCommitted);
            con.Close();
        }
        private void PopulateCoursesByTeacher()
        {
            // First, fetch the teacher's ID using the UserID
            string teacherQuery = $@"
    SELECT TeacherID 
    FROM Teacher 
    WHERE UserID = {id}";
            SqlCommand teacherCmd = new SqlCommand(teacherQuery, con);
            int teacherId = Convert.ToInt32(teacherCmd.ExecuteScalar());

            // Now fetch the courses taught by this teacher
            string query = $@"
    SELECT c.* 
    FROM Course c
    WHERE c.TeacherID = {id}";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                // Store CourseName as a string
                comboBox1.Items.Add(reader["CourseName"].ToString());
            }
        }

        private SqlDataAdapter adapter;
        private DataTable dt;


        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                var selectedCourseName = (string)comboBox1.SelectedItem;

                string query = $@"
      SELECT sc.* 
      FROM StudentCourse sc
      INNER JOIN Course c ON sc.CourseID = c.CourseID
      WHERE c.CourseName = '{selectedCourseName}'";
                SqlCommand cmd = new SqlCommand(query, con);
                adapter = new SqlDataAdapter(cmd);
                dt = new DataTable();
                adapter.AcceptChangesDuringFill = true;
                adapter.Fill(dt);

                // Set the DataSet and Table of the DataAdapter
                adapter.UpdateCommand = new SqlCommand("UPDATE StudentCourse SET Grade = @grade WHERE StudentID = @studentId AND CourseID = @courseId", con);
                adapter.UpdateCommand.Parameters.Add("@grade", SqlDbType.Int, 0, "Grade");
                adapter.UpdateCommand.Parameters.Add("@studentId", SqlDbType.Int, 0, "StudentID");
                adapter.UpdateCommand.Parameters.Add("@courseId", SqlDbType.Int, 0, "CourseID");

                // Define the InsertCommand
                adapter.InsertCommand = new SqlCommand("INSERT INTO StudentCourse (StudentID, CourseID, Grade) VALUES (@studentId, @courseId, @grade)", con);
                adapter.InsertCommand.Parameters.Add("@studentId", SqlDbType.Int, 0, "StudentID");
                adapter.InsertCommand.Parameters.Add("@courseId", SqlDbType.Int, 0, "CourseID");
                adapter.InsertCommand.Parameters.Add("@grade", SqlDbType.Int, 0, "Grade");

                // Define the DeleteCommand
                adapter.DeleteCommand = new SqlCommand("DELETE FROM StudentCourse WHERE StudentID = @studentId AND CourseID = @courseId", con);
                adapter.DeleteCommand.Parameters.Add("@studentId", SqlDbType.Int, 0, "StudentID");
                adapter.DeleteCommand.Parameters.Add("@courseId", SqlDbType.Int, 0, "CourseID");

                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                // Handle or log the exception
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                adapter.Update(dt);
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                // Handle or log the exception
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            
        }

       
    }
}
