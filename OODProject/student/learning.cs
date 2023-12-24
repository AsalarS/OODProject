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

namespace OODProject.student
{
    public partial class learning : Form
    {
        public learning()
        {
            InitializeComponent();
            load_file();
            this.listView1.Padding = new Padding(10);
        }

        private string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads", "files");

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

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && listView1.SelectedItems.Count > 0)
            {
                contextMenuStrip1.Show(listView1, e.Location);
            }
        }
    }
}
