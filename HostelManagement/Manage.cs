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
using System.Data.SqlClient;
using MetroFramework;

namespace HostelManagement
{
    public partial class Manage : MetroForm
    {
        public Manage()
        {
            InitializeComponent();
        }

        private void Manage_Load(object sender, EventArgs e)
        {
            LoadGrid();
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
        }

        private void LoadGrid()
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Integrated Security=true; Database=HostelDB");
            SqlCommand cmd = new SqlCommand("select * from tblUser", con);
            SqlDataAdapter data = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            data.Fill(dt);
            tableGrid.DataSource = dt;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            DataTable dt = CheckUser(txtUserName.Text);
            if (dt.Rows.Count > 0)
            {
                MetroMessageBox.Show(this, "User Name is already Taken ");

                txtUserName.Text = "";
                txtPassword.Text = string.Empty;
                txtFullname.Clear();
                txtAddress.Text = "";
                cboUserType.SelectedIndex = 0;
            }
            else
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Integrated Security=true; Database=HostelDB");
                SqlCommand cmd = new SqlCommand("insert into tblUser values(@a,@b,@c,@d,@e)", con);
                cmd.Parameters.AddWithValue("@a", txtUserName.Text);
                cmd.Parameters.AddWithValue("@b", txtPassword.Text);
                cmd.Parameters.AddWithValue("@c", cboUserType.Text);
                cmd.Parameters.AddWithValue("@d", txtFullname.Text);
                cmd.Parameters.AddWithValue("@e", txtAddress.Text);
                con.Open();
                int i = cmd.ExecuteNonQuery();
                con.Close();
                if (i > 0)
                {
                    LoadGrid();
                    MetroMessageBox.Show(this, "User Created");
                }
                else
                {
                    MetroMessageBox.Show(this, "Error");
                }
            }

        }

        private void tableGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        int userid = 0;
        private void tableGrid_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            userid = Convert.ToInt32(tableGrid.CurrentRow.Cells[0].Value.ToString());
            txtUserName.Text = tableGrid.CurrentRow.Cells[1].Value.ToString();
            txtPassword.Text = tableGrid.CurrentRow.Cells[2].Value.ToString();
            cboUserType.Text = tableGrid.CurrentRow.Cells[3].Value.ToString();
            txtFullname.Text = tableGrid.CurrentRow.Cells[4].Value.ToString();
            txtAddress.Text = tableGrid.CurrentRow.Cells[5].Value.ToString();
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
            btnCreate.Enabled = false;
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            btnCreate.Enabled = true;

            txtUserName.Text = "";
            txtPassword.Text = string.Empty;
            txtFullname.Clear();
            txtAddress.Text = "";
            cboUserType.SelectedIndex = 0;
        }

        private void btnUpdate_Click_1(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Integrated Security=true; Database=HostelDB");
            SqlCommand cmd = new SqlCommand("update tblUser set Username=@a,Password=@b,Usertype=@c,Fullname=@d,Address=@e where UserId=@f", con);
            cmd.Parameters.AddWithValue("@a", txtUserName.Text);
            cmd.Parameters.AddWithValue("@b", txtPassword.Text);
            cmd.Parameters.AddWithValue("@c", cboUserType.Text);
            cmd.Parameters.AddWithValue("@d", txtFullname.Text);
            cmd.Parameters.AddWithValue("@e", txtAddress.Text);
            cmd.Parameters.AddWithValue("@f", userid);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i > 0)
            {
                LoadGrid();
                txtUserName.Text = "";
                txtPassword.Text = string.Empty;
                txtFullname.Clear();
                txtAddress.Text = "";
                cboUserType.SelectedIndex = 0;

                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
                btnCreate.Enabled = true;
                MetroMessageBox.Show(this, "User Updated");
            }
            else
            {
                MetroMessageBox.Show(this, "Error");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MetroMessageBox.Show(this, "Are you sure want to Delete?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Integrated Security=true; Database=HostelDB");
                SqlCommand cmd = new SqlCommand("delete from tblUser where UserId=@f", con);
                cmd.Parameters.AddWithValue("@f", userid);
                con.Open();
                int i = cmd.ExecuteNonQuery();
                con.Close();
                if (i > 0)
                {
                    LoadGrid();
                    txtUserName.Text = "";
                    txtPassword.Text = string.Empty;
                    txtFullname.Clear();
                    txtAddress.Text = "";
                    cboUserType.SelectedIndex = 0;

                    btnUpdate.Enabled = false;
                    btnDelete.Enabled = false;
                    btnCreate.Enabled = true;
                    MetroMessageBox.Show(this, "User Deleted");
                }
                else
                {
                    MetroMessageBox.Show(this, "Error");
                }
            }else
            {
                txtUserName.Text = "";
                txtPassword.Text = string.Empty;
                txtFullname.Clear();
                txtAddress.Text = "";
                cboUserType.SelectedIndex = 0;

                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
                btnCreate.Enabled = true;
            }
        }

        private void txtSearch_Click(object sender, EventArgs e)
        {

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Integrated Security=true; Database=HostelDB");
            SqlCommand cmd = new SqlCommand("select * from tblUser where Username like @a", con);
            cmd.Parameters.AddWithValue("@a", txtSearch.Text + "%");
            SqlDataAdapter data = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            data.Fill(dt);
            tableGrid.DataSource = dt;
        }
        public DataTable CheckUser(string username)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Integrated Security=true; Database=HostelDB");
            SqlCommand cmd = new SqlCommand("select * from tblUser where Username = @a", con);
            cmd.Parameters.AddWithValue("@a", txtUserName.Text);
            SqlDataAdapter data = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            data.Fill(dt);
            return dt;
        }
    }
}
