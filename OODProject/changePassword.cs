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

namespace OODProject
{
    public partial class changePassword : Form
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

        private int ID;

        public changePassword()
        {
            InitializeComponent();
            this.MouseClick += new MouseEventHandler(popUpMouseClick);
        }

        public changePassword(int ID)
        {
            InitializeComponent();
            this.MouseClick += new MouseEventHandler(popUpMouseClick);
            this.ID = ID;
        }

        private void popUpMouseClick(object sender, MouseEventArgs e)
        {
            if (!ClientRectangle.Contains(e.Location))
            {
                this.Close();
            }
        }

        private void registerBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void changeBtn_Click(object sender, EventArgs e)
        {
            string newPassword1 = password1.Text;
            string newPassword2 = password2.Text;

            // Check if passwords match
            if (newPassword1 != newPassword2)
            {
                MessageBox.Show("Passwords do not match.", "Error", MessageBoxButtons.OK);
                return;
            }

            // Get the current user's email
            string email = "";
            con.Open();
            string sql = "SELECT Email FROM [User] WHERE UserID = @Id";
            using (var command = new SqlCommand(sql, con))
            {
                command.Parameters.AddWithValue("@Id", ID);
                using (var reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        reader.Read();
                        email = reader["Email"].ToString();
                    }
                }
            }
            con.Close();

            if (string.IsNullOrEmpty(email))
            {
                MessageBox.Show("No user found with the given ID.", "Error", MessageBoxButtons.OK);
                return;
            }

            con.Open();
            sql = "UPDATE [User] SET Password = @NewPassword WHERE Email = @Email";
            using (var command = new SqlCommand(sql, con))
            {
                command.Parameters.AddWithValue("@NewPassword", newPassword1);
                command.Parameters.AddWithValue("@Email", email);
                command.ExecuteNonQuery();
            }
            con.Close();

            DialogResult result = MessageBox.Show("Password updated successfully.", "Success", MessageBoxButtons.OK);
            if (result == DialogResult.OK)
            {
                this.Close();
            }

        }
    }
}
