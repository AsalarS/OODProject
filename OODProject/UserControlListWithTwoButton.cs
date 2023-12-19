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
    public partial class UserControlListWithTwoButton : UserControl
    {
        public event EventHandler Clicked;

        private void OnClick(object sender, EventArgs e)
        {
            Clicked?.Invoke(this, e);
        }

        public UserControlListWithTwoButton()
        {
            InitializeComponent();
            this.MouseClick += OnClick;
        }

        #region Properties

        private String _itemName;
        private String _BtnOne;
        private String _BtnTwo;

        [Category("Custom Property")]
        public String ItemName
        {
            get { return _itemName; }
            set { _itemName = value; itemNameLabel.Text = value; }
        }
        public String BtnOne
        {
            get { return _BtnOne; }
            set { _BtnOne = value; button1.Text = value; }
        }
        public String BtnTwo
        {
            get { return _BtnTwo; }
            set { _BtnTwo = value; button2.Text = value; }
        }

        #endregion

    }
}
