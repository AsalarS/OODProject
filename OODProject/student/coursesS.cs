using OODProject.Admin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OODProject.student
{
    public partial class coursesS : Form
    {
        public coursesS()
        {
            InitializeComponent();
            rows();
        }

        private void rows()
        {
            flowLayoutPanel1.Padding = new Padding(10);
            UserControlDetail[] lists = new UserControlDetail[20];
            for (int i = 0; i < lists.Length; i++)
            {
                lists[i] = new UserControlDetail();
                lists[i].ItemName = ("Item " + i);
                lists[i].Detail = ("Detail " + i);
                flowLayoutPanel1.Controls.Add(lists[i]);
                lists[i].Margin = new Padding(10);

            }
        }

    }
}
