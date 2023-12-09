using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OODProject
{
    public partial class studentDash : Form
    {
        public studentDash()
        {
            InitializeComponent();
        }

        public void showScreen(object Form)
        {
            if (this.mainScreen.Controls.Count > 0)
                this.mainScreen.Controls.RemoveAt(0);
            Form f = Form as Form;
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            this.mainScreen.Controls.Add(f);
            this.mainScreen.Tag = f;
            f.Show();
        }
    }
}
