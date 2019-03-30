using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using BusinessLayer;
using MetroFramework;

namespace HostelManagement
{
    public partial class Login : MetroForm
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            
        }

        private void password_Click(object sender, EventArgs e)
        {

        }

        private void userName_Click(object sender, EventArgs e)
        {

        }

        private void userType_Click(object sender, EventArgs e)
        {

        }
        BllUsers bluser = new BllUsers();
        private void btnLogin_Click(object sender, EventArgs e)
        {
            DataTable dt = bluser.CheckUserLogin(txtUserName.Text, txtPassword.Text, cboUserType.Text);
            if(dt.Rows.Count>0)
            {
                Program.username = txtUserName.Text;
                Main main = new Main();
                this.Hide();
                main.Show();
            }
            else
            {
                MetroMessageBox.Show(this, "Invalid User");
                txtUserName.Text = "";
                txtPassword.Text = "";
                cboUserType.SelectedIndex = 0;
                txtUserName.Focus();
            }
        }

        private void cboUserType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
