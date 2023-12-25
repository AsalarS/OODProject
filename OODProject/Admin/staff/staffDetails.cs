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
    public partial class staffDetails : Form
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

        public staffDetails()
        {
            InitializeComponent();
        }

        private int id;
        public staffDetails(adminDash dash, staff staffForm, int id)
        {
            InitializeComponent();
            this.Dash = dash;
            this.staffForm = staffForm;
            this.id = id;

            string sql = "SELECT T.TeacherId, U.FirstName, U.LastName, U.Email, U.PhoneNumber, B.BranchName FROM [User] U INNER JOIN Teacher T ON U.UserID = T.UserID INNER JOIN Branch B ON T.BranchId = B.BranchId WHERE T.TeacherID = @TeacherId";
            using (var command = new SqlCommand(sql, con))
            {
                command.Parameters.AddWithValue("@TeacherId", id);
                con.Open();
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        textBox1.Text = reader["FirstName"].ToString();
                        textBox2.Text = reader["LastName"].ToString();
                        textBox3.Text = reader["Email"].ToString();
                        textBox4.Text = reader["PhoneNumber"].ToString();
                        comboBox1.Text = reader["BranchName"].ToString();
                        IDNumber.Text = reader["TeacherId"].ToString();
                    }
                }
                con.Close();
            }

        }

        private void branchesLbl_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Dash.showScreen(staffForm);
        }
    }
}
