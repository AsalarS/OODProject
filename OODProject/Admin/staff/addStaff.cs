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
    public partial class addStaff : Form
    {
        public adminDash Dash { get; set; }
        private staff staffForm { get; set; }
        public addStaff(adminDash dash, staff Staff)
        {
            InitializeComponent();
            Dash = dash;
            staffForm = Staff;
        }

        public addStaff()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Dash.showScreen(staffForm);
        }
    }
}
