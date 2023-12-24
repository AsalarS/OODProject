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
    public partial class branchDetails : Form
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
        private branches branchesForm { get; set;                    }

        private int id;

       

        public branchDetails(adminDash dash, branches bran, int id)
        {
            InitializeComponent();
            Dash = dash;
            branchesForm = bran;
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

        public branchDetails()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Delete Item?", "Confirm", MessageBoxButtons.YesNo);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Submit Changes?", "Confirm", MessageBoxButtons.YesNo);

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
                 
        }

        private void branchDetails_Load(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Dash.showScreen(branchesForm);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
