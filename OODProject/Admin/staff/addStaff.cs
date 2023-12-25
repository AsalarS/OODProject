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
using System.Xml.Linq;

namespace OODProject.Admin

  
{
    
    public partial class addStaff : Form
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
        public addStaff(adminDash dash, staff Staff)
        {
            InitializeComponent();
            Dash = dash;
            staffForm = Staff;

            // Fetch data from the database
            string sql = "SELECT BranchName FROM Branch";
            using (var command = new SqlCommand(sql, con))
            {
                con.Open();
                using (var reader = command.ExecuteReader())
                {
                    var dataSource = new List<string>();
                    while (reader.Read())
                    {
                        dataSource.Add(reader["BranchName"].ToString());
                    }

                    // Bind data to the ComboBox
                    comboBox1.DataSource = dataSource;
                }
                con.Close();
            }

        }

    

        public addStaff()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Dash.showScreen(staffForm);
        }

        private void addBtn_Click(object sender, EventArgs e)
        {

            string fname = textBox1.Text;
            string lname = textBox2.Text;
            string email = textBox3.Text;
            string phone = textBox4.Text;
            string branch = comboBox1.Text;

            string sql = "INSERT INTO [User] (FirstName, LastName, Email, PhoneNumber, Role) VALUES (@FirstName, @LastName, @Email, @PhoneNumber, @Role); SELECT SCOPE_IDENTITY();";
            using (var command = new SqlCommand(sql, con))
            {
                command.Parameters.AddWithValue("@FirstName", fname);
                command.Parameters.AddWithValue("@LastName", lname);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@PhoneNumber", phone);
                command.Parameters.AddWithValue("@Role", "Teacher");

                con.Open();
                int userId = Convert.ToInt32(command.ExecuteScalar());
                con.Close();

                sql = "INSERT INTO Teacher (UserID) VALUES (@UserID)";
                using (var command2 = new SqlCommand(sql, con))
                {
                    command2.Parameters.AddWithValue("@UserID", userId);

                    con.Open();
                    command2.ExecuteNonQuery();
                    con.Close();
                }

                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                comboBox1.Text = "";
            }



        }
    }
}
