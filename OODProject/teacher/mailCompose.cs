using OODProject.Admin;
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
    public partial class mailCompose : Form
    {

        public teachDash Dash { get; set; }
        private mail mailForm { get; set; }

        public mailCompose()
        {
            InitializeComponent();
        }

        public mailCompose(teachDash dash, mail form)
        {
            InitializeComponent();
            Dash = dash;
            mailForm = form;
        }

        private void maiDetail_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dash.showScreen(mailForm);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Dash.showScreen(mailForm);
        }
    }
}
