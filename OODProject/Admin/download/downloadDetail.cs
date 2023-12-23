﻿using OODProject.teacher;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OODProject.Admin.download
{
    public partial class downloadDetail : Form
    {
        public adminDash Dash { get; set; }
        public information info { get; set; }
        public reports repo { get; set; }

        public downloadDetail()
        {
            InitializeComponent();
        }

        public downloadDetail(adminDash Dash, information info)
        {
            InitializeComponent();
            this.Dash = Dash;
            this.info = info;
        }

        public downloadDetail(adminDash Dash, reports repo)
        {
            InitializeComponent();
            this.Dash = Dash; 
            this.info = info;
        }
    }
}