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
    public partial class UserControlNormalList : UserControl
    {
        public event EventHandler Clicked;

        private void OnClick(object sender, EventArgs e)
        {
            Clicked?.Invoke(this, e);
        }

        public UserControlNormalList()
        {
            InitializeComponent();
            this.MouseClick += OnClick;
            this.itemNameLabel.Click += OnClick;
            this.pictureBox1.Click += OnClick;
        }


        #region Properties

        private String _itemName;

        [Category("Custom Property")]
        public String ItemName
        {
            get { return _itemName; }
            set { _itemName  = value; itemNameLabel.Text = value; }
        }

        #endregion

        private void itemNameLabel_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
