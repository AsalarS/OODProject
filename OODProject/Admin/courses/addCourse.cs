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
    public partial class addCourse : Form
    {
        public adminDash Dash { get; set; }
        private courses coursesForm { get; set; }
        public addCourse(adminDash dash, courses Courses)
        {
            InitializeComponent();
            Dash = dash;
            coursesForm = Courses;
        }
        public addCourse()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Dash.showScreen(coursesForm);
        }
    }
}
