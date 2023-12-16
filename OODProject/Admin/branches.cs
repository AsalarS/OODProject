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
    public partial class branches : Form
    {
        public branches()
        {
            InitializeComponent();
        }

        private void branches_Load(object sender, EventArgs e)
        {
            UserControlNormalList[] lists = new UserControlNormalList[20];
            for (int i = 0; i < lists.Length; i++)
            {
                lists[i] = new UserControlNormalList();
                lists[i].ItemName = ("Item " + i);
                if(flowLayoutPanel1.Controls.Count > 0)
                {
                    flowLayoutPanel1.Controls.Clear();
                } else
                {
                    flowLayoutPanel1.Controls.Add(lists[i]);
                }
            }
        }
    }
}

