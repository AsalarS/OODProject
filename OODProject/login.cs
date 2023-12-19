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
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
            this.Icon = new Icon("D:\\vs projects\\OODProject\\OODProject\\Resources\\icon.ico");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (adminLogin.Checked)
            {
                this.Hide();
                adminDash adminDashboard = new adminDash();
                adminDashboard.ShowDialog();
                this.Close();
            } else if (teacherLogin.Checked)
            {
                this.Hide();
                teachDash teachDashboard = new teachDash();
                teachDashboard.ShowDialog();
                this.Close();
            } else if (studentLogin.Checked)
            {
                this.Hide();
                studentDash studentDashboard = new studentDash();
                studentDashboard.ShowDialog();
                this.Close();
            } else
            {
                MessageBox.Show("Select login user", "Select", MessageBoxButtons.OK);
            }
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void login_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void registerBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            register reg = new register();
            reg.ShowDialog();
            this.Close();
        }
    }
}
