using OODProject.teacher;
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

namespace OODProject.student.mail
{
    public partial class mailComposeS : Form
    {
        private string filePath = "C:\\Users\\Ali\\Downloads\\files";
        private List<string> filePaths = new List<string>();
        private HashSet<string> uniqueFiles = new HashSet<string>();
        private int count = 0;

        public mailComposeS()
        {
            InitializeComponent();
        }
        public studentDash Dash { get; set; }
        private mailS mailForm { get; set; }

        public mailComposeS(studentDash dash, mailS form)
        {
            InitializeComponent();
            Dash = dash;
            mailForm = form;
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

        private void contextMenuStrip1_MouseClick(object sender, MouseEventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listView1.SelectedItems[0];
                filePaths.Remove(selectedItem.Tag as string);
                uniqueFiles.Remove(selectedItem.Tag as string);
                count--;
                listView1.Items.Remove(selectedItem);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Dash.showScreen(mailForm);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dash.showScreen(mailForm);
        }

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
                    filePaths.Add(targetPath);
                    uniqueFiles.Add(fileName);
                    count++;
                }
                load_file();
            }
        }
    }
}
