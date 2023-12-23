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
    public partial class UserControlMail : UserControl
    {
        public UserControlMail()
        {
            InitializeComponent();
            this.MouseClick += OnClick;
            this.itemNameLabel.Click += OnClick;
            this.content.Click += OnClick;
            this.dateLbl.Click += OnClick;
        }

        public event EventHandler Clicked;

        private void OnClick(object sender, EventArgs e)
        {
            Clicked?.Invoke(this, e);
        }

        #region Properties

        private String _itemName;
        private String _mailContent;
        private String _date;

        [Category("Custom Property")]
        public String ItemName
        {
            get { return _itemName; }
            set { _itemName = value; itemNameLabel.Text = value; }
        }

        public String mailContent
        {
            get { return _mailContent; }
            set { _mailContent = value; content.Text = value; }
        }

        public String date
        {
            get { return _date; }
            set { _date = value; dateLbl.Text = value; }
        }

        #endregion
    }
}
