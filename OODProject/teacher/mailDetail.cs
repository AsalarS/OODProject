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
    public partial class mailDetail : Form
    {
        public teachDash Dash { get; set; }
        private mail mailForm { get; set; }

        public mailDetail()
        {
            InitializeComponent();
        }

        public mailDetail(teachDash Dash, mail mailForm)
        {
            InitializeComponent();
            this.Dash = Dash;
            this.mailForm = mailForm;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dash.showScreen(mailForm);
        }
    }
}
