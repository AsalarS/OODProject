using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OODProject.Admin
{
    public partial class courseDetails : Form
    {
        

        public courseDetails()
        {
            InitializeComponent();
        }

        public adminDash Dash { get; set; }
        private courses coursesForm { get; set; }
        public courseDetails(adminDash dash, courses course)
        {
            InitializeComponent();
            Dash = dash;
            coursesForm = course;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Dash.showScreen(coursesForm);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
