using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer;
using MetroFramework;

namespace HostelManagement
{
    public partial class ChangePassword : MetroForm
    {
        public ChangePassword()
        {
            InitializeComponent();
        }

        private void ChangePassword_Load(object sender, EventArgs e)
        {

        }
        BllUsers bluser = new BllUsers();
        private void btnSave_Click(object sender, EventArgs e)
        {
            DataTable dt = bluser.CheckUser(Program.username, txtOldPassword.Text);
            if(dt.Rows.Count>0)
            {
                if(txtNewPassword.Text == txtConfirmPassword.Text)
                {
                    int i = bluser.UpdatePassword(Program.username, txtNewPassword.Text);
                    MetroMessageBox.Show(this, "Password Updated");
                }
                else
                {
                    MetroMessageBox.Show(this, "Password Mismatched");
                    txtNewPassword.Text = "";
                    txtConfirmPassword.Text = "";
                    txtOldPassword.Text = "";
                    txtNewPassword.Focus();
                }
            }
            else
            {
                MetroMessageBox.Show(this, "Enter a Valid Password");
                txtOldPassword.Text = "";
                txtNewPassword.Text = "";
                txtOldPassword.Focus();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtConfirmPassword.Text = "";
            txtNewPassword.Text = "";
            txtOldPassword.Text = "";
        }
    }
}
