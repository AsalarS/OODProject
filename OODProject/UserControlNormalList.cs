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
        public UserControlNormalList()
        {
            InitializeComponent();
        }

        #region Properties

        private String _itemName;

        [Category("Custom Props")]
        public String ItemName
        {
            get { return _itemName; }
            set { _itemName  = value; itemNameLabel.Text = value; }
        }

        #endregion
    }
}
