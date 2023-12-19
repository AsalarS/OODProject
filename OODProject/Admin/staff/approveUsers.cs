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
    public partial class approveUsers : Form
    {
        public adminDash Dash { get; set; }
        private staff staffForm { get; set; }
        public approveUsers(adminDash dash, staff Staff)
        {
            InitializeComponent();
            Dash = dash;
            staffForm = Staff;
            rows();
        }

        public approveUsers()
        {
            InitializeComponent();
            rows();
        }

        private void rows()
        {
            flowLayoutPanel1.Padding = new Padding(10);
            UserControlListWithTwoButton[] lists = new UserControlListWithTwoButton[20];
            for (int i = 0; i < lists.Length; i++)
            {
                lists[i] = new UserControlListWithTwoButton();
                lists[i].ItemName = ("Item " + i);
                flowLayoutPanel1.Controls.Add(lists[i]);
                lists[i].Margin = new Padding(10);
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            Dash.showScreen(staffForm);
        }
    }
}
