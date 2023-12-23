using OODProject.student.mail;
using OODProject.teacher.mail;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OODProject.student
{
    public partial class mailS : Form
    {
        public studentDash dash;
        public mailS()
        {
            InitializeComponent();
            rows();
        }
        public mailS(studentDash dash)
        {
            InitializeComponent();
            this.dash = dash;
            rows();
        }

        private void rows()
        {
            flowLayoutPanel1.Padding = new Padding(10);
            UserControlMail[] lists = new UserControlMail[20];
            for (int i = 0; i < lists.Length; i++)
            {
                lists[i] = new UserControlMail();
                lists[i].ItemName = ("Item " + i);
                lists[i].mailContent = ("Loream Ipsum something something");
                lists[i].date = ("1/1/2023");
                flowLayoutPanel1.Controls.Add(lists[i]);
                lists[i].Margin = new Padding(10);

                lists[i].Clicked += UserControl_Click;
            }
        }
        private void UserControl_Click(object sender, EventArgs e)
        {

            if (dash != null)
            {
                dash.showScreen(new mailDetailS(dash, this));
            }

        }

        private void attachBtn_Click(object sender, EventArgs e)
        {
            dash.showScreen(new mailComposeS(dash, this));
        }
    }
}
