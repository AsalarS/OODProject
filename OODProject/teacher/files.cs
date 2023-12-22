using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OODProject.teacher
{
    public partial class files : Form
    {
        public files()
        {
            InitializeComponent();
            load_file();
            this.listView1.Padding = new Padding(10);
        }
        public void load_file()
        {
            DirectoryInfo fileList;
            try
            {
                listView1.Items.Clear();
                fileList = new DirectoryInfo(filePath);
                FileInfo[] files = fileList.GetFiles();
                string fileExtension = "";

                for (int i = 0; i < files.Length; i++)
                {
                    fileExtension = files[i].Extension.ToUpper();
                    switch (fileExtension)
                    {
                        case ".MP3":
                        case ".MP2":
                            listView1.Items.Add(files[i].Name, 3);
                            break;
                        case ".EXE":
                        case ".COM":
                            listView1.Items.Add(files[i].Name, 5);
                            break;

                        case ".MP4":
                        case ".AVI":
                        case ".MKV":
                            listView1.Items.Add(files[i].Name, 4);
                            break;
                        case ".PDF":
                            listView1.Items.Add(files[i].Name, 2);
                            break;
                        case ".DOC":
                        case ".DOCX":
                            listView1.Items.Add(files[i].Name, 1);
                            break;
                        case ".PNG":
                        case ".JPG":
                        case ".JPEG":
                            listView1.Items.Add(files[i].Name, 7);
                            break;

                        default:
                            listView1.Items.Add(files[i].Name, 6);
                            break;
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private string filePath = "C:\\Users\\Ali\\Downloads\\files";

        private void button1_Click_1(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                foreach (string fileName in openFileDialog1.FileNames)
                {
                    string targetPath = Path.Combine(filePath, Path.GetFileName(fileName));
                    File.Copy(fileName, targetPath, true);
                }
                load_file();
            }
        }

        private void listView1_MouseClick_1(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && listView1.SelectedItems.Count > 0)
            {
                contextMenuStrip1.Show(listView1, e.Location);
            }
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                string selectedFile = listView1.SelectedItems[0].Text;
                string fullPath = Path.Combine(filePath, selectedFile);
                try
                {
                    Process.Start(fullPath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                string selectedFile = listView1.SelectedItems[0].Text;
                string fullPath = Path.Combine(filePath, selectedFile);
                try
                {
                    File.Delete(fullPath);
                    load_file();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
