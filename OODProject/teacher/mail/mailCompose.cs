using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace OODProject.teacher.mail
{
    public partial class mailCompose : Form
    {
        public teachDash Dash { get; set; }
        private Mail mailForm { get; set; }

        public mailCompose()
        {
            InitializeComponent();
        }

        public mailCompose(teachDash dash, Mail form)
        {
            InitializeComponent();
            Dash = dash;
            mailForm = form;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Dash.showScreen(mailForm);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Dash.showScreen(mailForm);
        }

        private string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads", "files");
        private List<string> filePaths = new List<string>();
        private HashSet<string> uniqueFiles = new HashSet<string>();
        private int count = 0;


        private void attachBtn_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                foreach (string fileName in openFileDialog1.FileNames)
                {
                    if (count >= 10 || uniqueFiles.Contains(fileName))
                    {
                        MessageBox.Show("You have reached the maximum number of files or the file is already added.", "Limit Reached", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    string targetPath = Path.Combine(filePath, Path.GetFileName(fileName));
                    byte[] fileData = File.ReadAllBytes(targetPath);
                    ListViewItem item = new ListViewItem(Path.GetFileName(fileName));
                    item.Tag = fileData;
                    listView1.Items.Add(item);
                    count++;
                }
            }
        }

        public void load_file()
        {
            listView1.Items.Clear();
            string fileExtension = "";

            for (int i = 0; i < filePaths.Count; i++)
            {
                var fileInfo = new FileInfo(filePaths[i]);
                fileExtension = fileInfo.Extension.ToUpper();
                switch (fileExtension)
                {
                    case ".MP3":
                    case ".MP2":
                        listView1.Items.Add(fileInfo.Name, 3);
                        break;
                    case ".EXE":
                    case ".COM":
                        listView1.Items.Add(fileInfo.Name, 5);
                        break;
                    case ".MP4":
                    case ".AVI":
                    case ".MKV":
                        listView1.Items.Add(fileInfo.Name, 4);
                        break;
                    case ".PDF":
                        listView1.Items.Add(fileInfo.Name, 2);
                        break;
                    case ".DOC":
                    case ".DOCX":
                        listView1.Items.Add(fileInfo.Name, 1);
                        break;
                    case ".PNG":
                    case ".JPG":
                    case ".JPEG":
                        listView1.Items.Add(fileInfo.Name, 7);
                        break;
                    default:
                        listView1.Items.Add(fileInfo.Name, 6);
                        break;
                }
            }
        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && listView1.SelectedItems.Count > 0)
            {
                contextMenuStrip1.Show(listView1, e.Location);
            }
        }

        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listView1.SelectedItems[0];
                selectedItem.Tag = null;
                count--;
                listView1.Items.Remove(selectedItem);
            }
        }
    }
}
