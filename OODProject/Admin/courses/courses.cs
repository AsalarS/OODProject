using OODProject.Admin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OODProject.Admin
{
    public partial class courses : Form
    {
        public adminDash Dash { get; set; }

        public courses()
        {
            InitializeComponent();
            rows();
        }

        public courses(adminDash Dash)
        {
            InitializeComponent();
            rows();
            this.Dash = Dash;
        }
        private void rows()
        {
            flowLayoutPanel1.Padding = new Padding(10);
            UserControlNormalList[] lists = new UserControlNormalList[20];
            for (int i = 0; i < lists.Length; i++)
            {
                lists[i] = new UserControlNormalList();
                lists[i].ItemName = ("Item " + i);
                flowLayoutPanel1.Controls.Add(lists[i]);
                lists[i].Margin = new Padding(10);

                lists[i].Clicked += UserControl_Click;
            }
        }

        private void UserControl_Click(object sender, EventArgs e)
        {
            if (Dash != null)
            {
                Dash.showScreen(new courseDetails(Dash, this));
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dash.showScreen(new addCourse(Dash, this));
        }
    }
}
