using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OODProject.Admin.Feedback
{
    public partial class feedbackDetails : Form
    {
        public feedbackDetails()
        {
            InitializeComponent();
        }

        public adminDash Dash { get; set; }
        private feedback feedbackForm { get; set; }
        public feedbackDetails(adminDash dash, feedback feedbackPage)
        {
            InitializeComponent();
            Dash = dash;
            feedbackForm = feedbackPage;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Dash.showScreen(feedbackForm);
        }
    }
}
