using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OODProject.teacher
{
    public partial class announcementsT : Form
    {
        public announcementsT()
        {
            InitializeComponent();
            rows();
        }

        private void rows()
        {
            flowLayoutPanel1.Padding = new Padding(10);
            UserControlAnnouncement[] lists = new UserControlAnnouncement[20];
            for (int i = 0; i < lists.Length; i++)
            {
                lists[i] = new UserControlAnnouncement();
                lists[i].announcementtitle = ("Item " + i);
                lists[i].date = ("1/1/2024");
                lists[i].description = ("Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged.");
                flowLayoutPanel1.Controls.Add(lists[i]);
                lists[i].Margin = new Padding(10);
            }
        }
    }
}
