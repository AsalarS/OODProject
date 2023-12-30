using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace OODProject
{
    public partial class UserControlAnnouncement : UserControl
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

        public UserControlAnnouncement()
        {
            InitializeComponent();
        }
        public UserControlAnnouncement(int iD)
        {
            InitializeComponent();
            ID = iD;

        }

        private int ID;

        #region Properties

        private String _announcementtitle;
        private String _description;
        private String _date;

        [Category("Custom Property")]
        public String announcementtitle
        {
            get { return _announcementtitle; }
            set { _announcementtitle = value; titleLabel.Text = value; }
        }

        public String description
        {
            get { return _description; }
            set { _description = value; descTextBox.Text = value; }
        }

        public String date
        {
            get { return _date; }
            set { _date = value; dateLbl.Text = value; }
        }

        #endregion

       
        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && listViewFiles.SelectedItems.Count > 0)
            {
                contextMenuStrip1.Show(listViewFiles, e.Location);
            }
        }

        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (listViewFiles.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listViewFiles.SelectedItems[0];
                string originalFileName = selectedItem.Text;
                byte[] fileData = selectedItem.Tag as byte[];

                if (fileData != null)
                {
                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.FileName = originalFileName;
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        File.WriteAllBytes(saveFileDialog.FileName, fileData);
                        MessageBox.Show("File downloaded successfully!");
                    }
                }
            }
        }
    }
}
