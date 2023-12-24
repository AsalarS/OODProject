using OODProject.Admin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OODProject
{
 
    public partial class branches : Form
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

        public branches(adminDash dash)
        {
            InitializeComponent();
            rows();
            this.Dash = dash;

        }
        public branches()
        {
            InitializeComponent();
            rows();
        }
        private void rows()
        {
            flowLayoutPanel1.Padding = new Padding(10);
            UserControlNormalList[] lists = new UserControlNormalList[20];
            flowLayoutPanel1.Refresh();
            con.Open();
            string sql = "SELECT BranchId, BranchName FROM Branch";
            using (var command = new SqlCommand(sql, con))
            {
                using (var reader = command.ExecuteReader())
                {
                    int i = 0;
                    while (reader.Read() && i < lists.Length)
                    {
                        lists[i] = new UserControlNormalList();
                        lists[i].ItemName = reader["BranchName"].ToString();
                        flowLayoutPanel1.Controls.Add(lists[i]);
                        lists[i].Margin = new Padding(10);
                        int branchId = reader.GetInt32(0); // Assuming BranchId is an integer
                        lists[i].Clicked += (sender, e) => UserControl_Click(sender, e, branchId);
                        i++;
                    }
                }
            }
            flowLayoutPanel1.Refresh();
            con.Close();
        }

        private void UserControl_Click(object sender, EventArgs e, int branchId)
        {

            if (Dash != null)
            {
                Dash.showScreen(new branchDetails(Dash, this, branchId));
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dash.showScreen(new addBranch(Dash, this));
        }
    }
}

