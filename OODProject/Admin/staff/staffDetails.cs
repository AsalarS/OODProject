using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Text;
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

        private int teacherID;
        public staffDetails(adminDash dash, staff staffForm, int id)
        {
            InitializeComponent();
            this.Dash = dash;
            this.staffForm = staffForm;
            this.teacherID = id;

            string sql = "SELECT T.TeacherId, U.FirstName, U.LastName, U.Email, U.PhoneNumber, U.Password, B.BranchName FROM [User] U INNER JOIN Teacher T ON U.UserID = T.UserID INNER JOIN Branch B ON T.BranchId = B.BranchId WHERE T.TeacherID = @TeacherId";
            using (var command = new SqlCommand(sql, con))
            {
                command.Parameters.AddWithValue("@TeacherId", teacherID);
                con.Open();
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string fullName = reader["FirstName"].ToString() + " " + reader["LastName"].ToString();
                        textBox1.Text = reader["FirstName"].ToString();
                        textBox2.Text = reader["LastName"].ToString();
                        textBox3.Text = reader["Email"].ToString();
                        textBox4.Text = reader["PhoneNumber"].ToString();
                        textBox5.Text = reader["Password"].ToString();
                        comboBox1.Text = reader["BranchName"].ToString();
                        IDNumber.Text = reader["TeacherId"].ToString();
                        staffLbl.Text = fullName;
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

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            DialogResult confirmDelete = MessageBox.Show("Are you sure you want to delete this staff member?", "Confirm", MessageBoxButtons.YesNo);

            if (confirmDelete == DialogResult.Yes)
            {
                con.Open();
                string sql = "DELETE FROM Teacher WHERE TeacherId = @TeacherId";
                using (var command = new SqlCommand(sql, con))
                {
                    command.Parameters.AddWithValue("@TeacherId", teacherID);
                    command.ExecuteNonQuery();
                }
                con.Close();

                MessageBox.Show("Staff member deleted successfully.", "Success", MessageBoxButtons.OK);
            }

            Dash.showScreen(new staff(Dash));
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string fname = textBox1.Text;
            string lname = textBox2.Text;
            string email = textBox3.Text;
            string phone = textBox4.Text;
            string pass = textBox5.Text;
            string branchName = comboBox1.Text;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                // Retrieve the UserID associated with the TeacherID
                string sqlGetUserID = "SELECT UserID FROM Teacher WHERE TeacherID = @TeacherID";
                using (var commandGetUserID = new SqlCommand(sqlGetUserID, con))
                {
                    commandGetUserID.Parameters.AddWithValue("@TeacherID", teacherID);
                    int userID = (int)commandGetUserID.ExecuteScalar();

                    string sqlCheckEmail = "SELECT COUNT(*) FROM [User] WHERE Email = @Email AND UserID != @UserID";
                    using (var commandCheckEmail = new SqlCommand(sqlCheckEmail, con))
                    {
                        commandCheckEmail.Parameters.AddWithValue("@Email", email);
                        commandCheckEmail.Parameters.AddWithValue("@UserID", userID);
                        int existingEmails = (int)commandCheckEmail.ExecuteScalar();
                        if (existingEmails > 0)
                        {
                            MessageBox.Show("This email is already registered.", "Error", MessageBoxButtons.OK);
                            return;
                        }
                    }
                    con.Close();
                    string sqlUpdateUser = "UPDATE [User] SET FirstName = @FirstName, LastName = @LastName, Password = @Password, Email = @Email, PhoneNumber = @PhoneNumber WHERE UserID = @UserID";
                    using (var commandUpdateUser = new SqlCommand(sqlUpdateUser, con))
                    {
                        commandUpdateUser.Parameters.AddWithValue("@FirstName", fname);
                        commandUpdateUser.Parameters.AddWithValue("@LastName", lname);
                        commandUpdateUser.Parameters.AddWithValue("@Email", email);
                        commandUpdateUser.Parameters.AddWithValue("@PhoneNumber", phone);
                        commandUpdateUser.Parameters.AddWithValue("@UserID", userID);
                        commandUpdateUser.Parameters.AddWithValue("@Password", pass);
                        con.Open();
                        commandUpdateUser.ExecuteNonQuery();
                        con.Close();
                    }

                    string sqlUpdateTeacher = "UPDATE Teacher SET BranchID = (SELECT BranchID FROM Branch WHERE BranchName = @BranchName) WHERE UserID = @UserID";
                    using (var commandUpdateTeacher = new SqlCommand(sqlUpdateTeacher, con))
                    {
                        commandUpdateTeacher.Parameters.AddWithValue("@BranchName", branchName);
                        commandUpdateTeacher.Parameters.AddWithValue("@UserID", userID);

                        con.Open();
                        commandUpdateTeacher.ExecuteNonQuery();
                        con.Close();
                    }

                    MessageBox.Show("Staff member updated successfully.", "Success", MessageBoxButtons.OK);
                }
            }
            Dash.showScreen(new staff(Dash));
        }
    }
}