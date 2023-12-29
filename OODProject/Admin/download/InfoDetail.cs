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

namespace OODProject.Admin.download
{
    public partial class InfoDetail : Form
    {
        public adminDash Dash { get; set; }
        public information info { get; set; }
        public reports repo { get; set; }
        public bool infoUsed = false;

        public InfoDetail()
        {
            InitializeComponent();
        }

        public InfoDetail(adminDash Dash, information info)
        {
            InitializeComponent();
            this.Dash = Dash;
            this.info = info;
            infoUsed = true;
        }

        public InfoDetail(adminDash Dash, reports repo)
        {
            InitializeComponent();
            this.Dash = Dash; 
            this.repo = repo;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (infoUsed)
            {
                Dash.showScreen(info);
            } else
            {
                Dash.showScreen(repo);
            }
            
        }
    }
}
