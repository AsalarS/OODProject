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
    public partial class register : Form
    {
        public register()
        {
            InitializeComponent();
            this.Icon = new Icon("D:\\vs projects\\OODProject\\OODProject\\Resources\\icon.ico");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            login loginPage = new login();
            loginPage.ShowDialog();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            login loginPage = new login();
            loginPage.ShowDialog();
            this.Close();
        }

        private void registerBtn_Click(object sender, EventArgs e)
        {
            DialogResult ok = MessageBox.Show("Your account has been registered and must be approve by an Admin", "Registered", MessageBoxButtons.OK);
            if (ok == DialogResult.OK) {
                this.Hide();
                login loginPage = new login();
                loginPage.ShowDialog();
                this.Close();
            }
        }
    }
}
