using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OODProject
{
    public partial class UserControlAnnouncement : UserControl
    {
        public UserControlAnnouncement()
        {
            InitializeComponent();
            load_file();
            this.MouseClick += OnClick;
            this.titleLabel.Click += OnClick;
            this.descTextBox.Click += OnClick;
            this.dateLbl.Click += OnClick;
        }

        public event EventHandler Clicked;

        private void OnClick(object sender, EventArgs e)
        {
            Clicked?.Invoke(this, e);
        }

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

        private string filePath = "C:\\Users\\Ali\\Downloads\\files";

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

        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
