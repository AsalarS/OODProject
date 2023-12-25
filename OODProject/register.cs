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
    public partial class register : Form
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
        public register()
        {
            InitializeComponent();
            this.Icon = new Icon("Resources\\icon.ico");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            login loginPage = new login();
            loginPage.ShowDialog();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            login loginPage = new login();
            loginPage.ShowDialog();
            this.Close();
        }

        private void registerBtn_Click(object sender, EventArgs e)
        {
            string firstName = firstNameReg.Text;
            string lastName = lastNameReg.Text;
            string email = emailReg.Text;
            string phoneNumber = phoneReg.Text;
            string password1 = pass1Reg.Text;
            string password2 = pass2Reg.Text;

            // Check if passwords match
            if (password1 != password2)
            {
                MessageBox.Show("Passwords do not match.", "Error", MessageBoxButtons.OK);
                return;
            }

            // Check if a role is selected
            RadioButton selectedRoleRadioButton = roleGroup.Controls.OfType<RadioButton>().FirstOrDefault(rb => rb.Checked);
            if (selectedRoleRadioButton == null)
            {
                MessageBox.Show("Please select a role.", "Error", MessageBoxButtons.OK);
                return;
            }

            string role = selectedRoleRadioButton.Name; // Assuming the radio button's Name property contains the role

            con.Open();
            string sql = "INSERT INTO [User] (FirstName, LastName, Email, PhoneNumber, Password, Role, Approved) VALUES (@FirstName, @LastName, @Email, @PhoneNumber, @Password, @Role, @Approved)";
            using (var command = new SqlCommand(sql, con))
            {
                command.Parameters.AddWithValue("@FirstName", firstName);
                command.Parameters.AddWithValue("@LastName", lastName);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                command.Parameters.AddWithValue("@Password", password1);
                command.Parameters.AddWithValue("@Role", role);
                command.Parameters.AddWithValue("@Approved", 0);
                command.ExecuteNonQuery();
            }
            con.Close();

            DialogResult ok = MessageBox.Show("Your account has been registered and must be approved by an Admin", "Registered", MessageBoxButtons.OK);
            if (ok == DialogResult.OK) {
                this.Hide();
                login loginPage = new login();
                loginPage.ShowDialog();
                this.Close();
            }
        }
    }
}
