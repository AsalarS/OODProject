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
    public partial class branchDetails : Form
    {
        public branchDetails()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Delete Item?", "Confirm", MessageBoxButtons.YesNo);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Submit Changes?", "Confirm", MessageBoxButtons.YesNo);

        }
    }
}
