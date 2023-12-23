using OODProject.teacher;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OODProject.student.mail
{
    public partial class mailDetailS : Form
    {
        public studentDash Dash { get; set; }
        private mailS mailForm { get; set; }

        public mailDetailS()
        {
            InitializeComponent();
        }

        public mailDetailS(studentDash Dash, mailS mailForm)
        {
            InitializeComponent();
            this.Dash = Dash;
            this.mailForm = mailForm;
        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && listView1.SelectedItems.Count > 0)
            {
                contextMenuStrip1.Show(listView1, e.Location);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dash.showScreen(mailForm);
        }
    }
}
