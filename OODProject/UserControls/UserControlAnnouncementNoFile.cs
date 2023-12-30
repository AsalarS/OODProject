using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OODProject.UserControls
{
    public partial class UserControlAnnouncementNoFile : UserControl
    {
        public UserControlAnnouncementNoFile()
        {
            InitializeComponent();
        }

        #region Properties

        private String _announcementtitle;
        private String _description;
        private String _date;

        [Category("Custom Property")]
        public String announcementtitle
        {
            get { return _announcementtitle; }
            set { _announcementtitle = value; titleLabel.Text = value; }
        }

        public String description
        {
            get { return _description; }
            set { _description = value; descTextBox.Text = value; }
        }

        public String date
        {
            get { return _date; }
            set { _date = value; dateLbl.Text = value; }
        }

        #endregion
    }
}
