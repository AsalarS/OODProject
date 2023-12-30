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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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
            comboBox1.Items.Clear();

            // Define the SQL query
            string queryStr = "SELECT BranchName FROM Branch";

            // Create a new SqlCommand with the SQL query and the SqlConnection
            SqlCommand cmd = new SqlCommand(queryStr, con);

            // Open the SqlConnection
            con.Open();

            // Execute the SqlCommand and fetch the data into a SqlDataReader
            SqlDataReader reader = cmd.ExecuteReader();

            // Iterate through the rows returned by the query
            while (reader.Read())
            {
                // Add the branch name to the comboBox
                comboBox1.Items.Add(reader["BranchName"].ToString());
            }

            // Close the SqlDataReader and the SqlConnection
            reader.Close();
            con.Close();

        }




        private void button1_Click(object sender, EventArgs e)
        {
            Dash.showScreen(new information(Dash));

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void submitBtn_Click(object sender, EventArgs e)
        {
            // Get the values of the checkboxes
            bool isTeacherChecked = teachersCheckBox.Checked;
            bool isStudentChecked = studentsCheckBox.Checked;

            // Determine the scope based on the checkboxes
            string scope;
            if (isTeacherChecked && isStudentChecked)
            {
                scope = "All";
            }
            else if (isTeacherChecked)
            {
                scope = "teachers";
            }
            else if (isStudentChecked)
            {
                scope = "students";
            }
            else
            {
                throw new Exception("No checkbox was selected");
            }

            string title = recipientTextBox.Text;
            string desc = mailBody.Text;

            // Get the selected branch name in comboBox1
            string selectedBranchName = comboBox1.SelectedItem.ToString();

            // Define the SQL query to get the BranchID for the selected BranchName
            string queryStr2 = "SELECT BranchID FROM Branch WHERE BranchName = @BranchName";
            SqlCommand cmd2 = new SqlCommand(queryStr2, con);
            cmd2.Parameters.AddWithValue("@BranchName", selectedBranchName);

            // Open the SqlConnection
            con.Open();

            // Execute the SqlCommand and get the BranchID
            int branchID = Convert.ToInt32(cmd2.ExecuteScalar());

            // Close the SqlConnection
            con.Close();

            // Define the SQL query
            string queryStr = "UPDATE announcements SET title=@Title, scope=@Scope, description=@Description, branchID=@BranchID WHERE id=@Id";

            // Create a new SqlCommand with the SQL query and the SqlConnection
            SqlCommand cmd = new SqlCommand(queryStr, con);

            // Add the parameters to the SqlCommand
            cmd.Parameters.AddWithValue("@Title", title);
            cmd.Parameters.AddWithValue("@Scope", scope);
            cmd.Parameters.AddWithValue("@Description", desc);
            cmd.Parameters.AddWithValue("@BranchID", branchID);
            cmd.Parameters.AddWithValue("@Id", id);

            // Open the SqlConnection
            con.Open();

            // Execute the SqlCommand
            cmd.ExecuteNonQuery();

            // Close the SqlConnection
            con.Close();

        }
    }
}
