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
    public partial class addBranch : Form
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
        private branches branchesForm { get; set; }
        public addBranch(adminDash dash, branches Branches)
        {
            InitializeComponent();
            Dash = dash;
            branchesForm = Branches;
        }
        public addBranch()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Dash.showScreen(branchesForm);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void addBtn_Click(object sender, EventArgs e)
        {

            string name = textBox2.Text;
            string manager = textBox1.Text;


            con.Open();
            string sql = "INSERT INTO Branch ( BranchName, BranchManager) VALUES ( @BranchName, @BranchManager)";
            using (var command = new SqlCommand(sql, con))
            {

              
                command.Parameters.AddWithValue("@BranchName", name);
                command.Parameters.AddWithValue("@BranchManager", manager);
                command.ExecuteNonQuery();
            }
            con.Close();

            textBox1.Text = "";
            textBox2.Text = "";
           
            
        }
    }
}
