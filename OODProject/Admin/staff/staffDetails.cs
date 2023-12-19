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
    public partial class staffDetails : Form
    {
        public adminDash Dash { get; set; }
        private staff staffForm { get; set; }

        public staffDetails()
        {
            InitializeComponent();
        }

        public staffDetails(adminDash dash,staff staffForm)
        {
            InitializeComponent();
            this.Dash = dash;
            this.staffForm = staffForm;
        }

        private void branchesLbl_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Dash.showScreen(staffForm);
        }
    }
}
