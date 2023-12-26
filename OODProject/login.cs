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

namespace OODProject
{
    public partial class login : Form
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

        public login()
        {
            InitializeComponent();
            //this.Icon = new Icon("Resources\\icon.ico");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string email = emailLogin.Text;
            string password = passwordLogin.Text;

            con.Open();
            string sql = "SELECT * FROM [User] WHERE LOWER(Email) = LOWER(@Email) AND Password = @Password AND Approved = 1";
            using (var command = new SqlCommand(sql, con))
            {
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@Password", password);
                using (var reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        reader.Read();
                        string role = reader["Role"].ToString();
                        int id = Convert.ToInt32(reader["UserID"]);
                        Console.WriteLine(id);

                        switch (role)
                        {
                            case "Admin":
                                this.Hide();
                                adminDash adminDashboard = new adminDash(id);
                                adminDashboard.ShowDialog();
                                this.Close();
                                break;

                            case "Teacher":
                                this.Hide();
                                teachDash teachDashboard = new teachDash(id);
                                teachDashboard.ShowDialog();
                                this.Close();
                                break;

                            case "Student":
                                this.Hide();
                                studentDash studentDashboard = new studentDash(id);
                                Console.WriteLine(id);
                                studentDashboard.ShowDialog();
                                this.Close();
                                break;

                            default:
                                MessageBox.Show("Invalid user role.", "Error", MessageBoxButtons.OK);
                                break;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid email or password.", "Error", MessageBoxButtons.OK);
                    }
                }
            }
            con.Close();
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void login_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void registerBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            register reg = new register();
            reg.ShowDialog();
            this.Close();
        }

        private void adminLogin_CheckedChanged(object sender, EventArgs e)
        {
            this.Hide();
            adminDash adminDashboard = new adminDash();
            adminDashboard.ShowDialog();
            this.Close();
        }

        private void teacherLogin_CheckedChanged(object sender, EventArgs e)
        {
            this.Hide();
            teachDash teachDashboard = new teachDash();
            teachDashboard.ShowDialog();
            this.Close();
        }

        private void studentLogin_CheckedChanged(object sender, EventArgs e)
        {
            this.Hide();
            studentDash studentDashboard = new studentDash();
            studentDashboard.ShowDialog();
            this.Close();
        }
    }
}
