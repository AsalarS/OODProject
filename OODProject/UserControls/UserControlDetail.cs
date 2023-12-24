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
    public partial class UserControlDetail : UserControl
    {
        public event EventHandler Clicked;

        public UserControlDetail()
        {
            InitializeComponent();
            this.MouseClick += OnClick;
        }

        private void OnClick(object sender, EventArgs e)
        {
            Clicked?.Invoke(this, e);
        }

        #region Properties

        private String _itemName;
        private String _Detail;

        [Category("Custom Property")]
        public String ItemName
        {
            get { return _itemName; }
            set { _itemName = value; itemNameLabel.Text = value; }
        }

        public String Detail
        {
            get { return _Detail; }
            set { _Detail = value; detailLbl.Text = value; }
        }

        #endregion
    }
}
