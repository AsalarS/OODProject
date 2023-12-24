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
    public partial class courseDetails : Form
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

        public courseDetails()
        {
            InitializeComponent();
        }

        public adminDash Dash { get; set; }
        private courses coursesForm { get; set; }
        private int id;
        public courseDetails(adminDash dash, courses course, int id)
        {
            InitializeComponent();
            Dash = dash;
            coursesForm = course;
            this.id = id;

            string sql = "SELECT BranchName, BranchManager, BranchId FROM Branch WHERE BranchId = @BranchId";
            using (var command = new SqlCommand(sql, con))
            {
                command.Parameters.AddWithValue("@BranchId", id);
                con.Open();
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        textBox1.Text = reader["BranchName"].ToString();
                        branchesLbl.Text = reader["BranchName"].ToString();
                        textBox2.Text = reader["BranchManager"].ToString();
                        IDNumber.Text = reader["BranchId"].ToString();
                    }
                }
                con.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Dash.showScreen(coursesForm);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
