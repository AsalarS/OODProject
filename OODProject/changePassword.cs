using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace OODProject
{
    public partial class changePassword : Form
    {
        public changePassword()
        {
            InitializeComponent();
            this.MouseClick += new MouseEventHandler(popUpMouseClick);
        }

        private void popUpMouseClick(object sender, MouseEventArgs e)
        {
            if (!ClientRectangle.Contains(e.Location))
            {
                this.Close();
            }
        }

        private void registerBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
