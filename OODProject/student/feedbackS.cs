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

namespace OODProject.student
{
    public partial class feedbackS : Form
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

        private int studentID;

        public feedbackS()
        {
            InitializeComponent();  
            PopulateComboBox();
        }

        public feedbackS(int studentID)
        {
            InitializeComponent();
            PopulateComboBox();
            this.studentID = studentID;
        }

        private void PopulateComboBox()
        {
            try
            {
                con.Open();
                string query = "SELECT * FROM Course";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    courseCombo.Items.Add(reader["courseID"].ToString());
                }

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void submitBtn_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                string query = "INSERT INTO Feedback (courseID, feedbackContent, studentID) VALUES (@courseID, @feedbackContent, @studentID)";
                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@courseID", courseCombo.SelectedItem);
                cmd.Parameters.AddWithValue("@feedbackContent", feedbackContent.Text);
                cmd.Parameters.AddWithValue("@studentID", studentID);

                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Feedback submitted successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
