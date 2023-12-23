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

namespace OODProject.teacher
{
    public partial class Mail : Form
    {
        public teachDash dash;
        public Mail()
        {
            InitializeComponent();
            rows();
        }

        public Mail(teachDash dash)
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
                lists[i].mailContent = ("Loream Ipsum something ssomething");
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
                dash.showScreen(new mailDetail(dash, this));
            }

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            dash.showScreen(new mailCompose(dash, this));
        }
    }
}
