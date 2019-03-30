using MetroFramework;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer;
namespace HostelManagement
{
    public partial class Student : MetroForm
    {
        public Student()
        {
            InitializeComponent();
        }

        BllStudent blstudent = new BllStudent();
        private void Student_Load(object sender, EventArgs e)
        {
            LoadGrid();
        }

        private void LoadGrid()
        {
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            btnSave.Enabled = true;
            gridStudent.Rows.Clear();
            DataTable dt = blstudent.GetAllStudent();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                gridStudent.Rows.Add();
                gridStudent.Rows[i].Cells["colStudentId"].Value = dt.Rows[i]["StudentId"].ToString();
                gridStudent.Rows[i].Cells["colFullname"].Value = dt.Rows[i]["Firstname"].ToString() + " " + dt.Rows[i]["Lastname"].ToString();
                gridStudent.Rows[i].Cells["colGender"].Value = dt.Rows[i]["Gender"].ToString();
                DateTime regd = Convert.ToDateTime(dt.Rows[i]["ReqDate"].ToString());
                gridStudent.Rows[i].Cells["colRegDate"].Value = regd.ToString("d");
            }
        }

        
        private void btnSave_Click(object sender, EventArgs e)
        {
          
            int i = blstudent.CreateStudent(txtFirstname.Text, txtLastname.Text, radioMale.Checked ? "Male" : "Female", dateTimePicker.Value, checkBox1.Checked ? true : false);
            if (i > 0)
            {
                LoadGrid();
                MetroMessageBox.Show(this, "Student Created");
            }
            else
            {
                MetroMessageBox.Show(this, "Error");
            }
            
        }
        int studentId = 0;
        private void gridStudent_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            studentId = Convert.ToInt32(gridStudent.CurrentRow.Cells["colStudentId"].Value.ToString());
            DataTable dt = blstudent.GetStudentById(studentId);
            txtFirstname.Text = dt.Rows[0]["Firstname"].ToString();
            txtLastname.Text = dt.Rows[0]["Lastname"].ToString();
            string gender = dt.Rows[0]["Gender"].ToString();
            if (gender == "Male")
            {
                radioMale.Checked = true;
            }
            else
            {
                radioFemale.Checked = true;
            }
            dateTimePicker.Value = Convert.ToDateTime(dt.Rows[0]["ReqDate"].ToString());
            bool isChecked = Convert.ToBoolean(dt.Rows[0]["IsActive"].ToString());
            if (isChecked)
            {
                checkBox1.Checked = true;
            }
            else
            {
                checkBox1.Checked = false;
            }
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
            btnSave.Enabled = false;
        }
      
        
        private void metroButton1_Click(object sender, EventArgs e)
        {

            int i = blstudent.UpdateStudent(txtFirstname.Text, txtLastname.Text, radioMale.Checked ? "Male" : "Female", dateTimePicker.Value, checkBox1.Checked ? true : false, studentId);
            if (i > 0)
            {
                LoadGrid();
                txtFirstname.Text = "";
                txtLastname.Text = string.Empty;
                radioMale.Checked = false;
                radioFemale.Checked = false;
                checkBox1.Checked = false;


                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
                btnSave.Enabled = true;
                MetroMessageBox.Show(this, "Student Updated");
            }
            else
            {
                MetroMessageBox.Show(this, "Error");
            }
        }
        
       
        private void metroButton2_Click(object sender, EventArgs e)
        {
            if (MetroMessageBox.Show(this, "Are you sure want to Delete?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                int i = blstudent.DeleteStudent(studentId);
                if (i > 0)
                {
                    LoadGrid();
                    txtFirstname.Text = "";
                    txtLastname.Text = string.Empty;
                    radioMale.Checked = false;
                    radioFemale.Checked = false;
                    checkBox1.Checked = false;


                    btnUpdate.Enabled = false;
                    btnDelete.Enabled = false;
                    btnSave.Enabled = true;
                    MetroMessageBox.Show(this, "Student Deleted");
                }
                else
                {
                    MetroMessageBox.Show(this, "Error");
                }
            }
            else
            {
                txtFirstname.Text = "";
                txtLastname.Text = string.Empty;
                radioMale.Checked = false;
                radioFemale.Checked = false;
                checkBox1.Checked = false;

                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
                btnSave.Enabled = true;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            
            txtFirstname.Text = "";
            txtLastname.Text = string.Empty;
            radioMale.Checked = false;
            radioFemale.Checked = false;
            checkBox1.Checked = false;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            btnSave.Enabled = true;
        }
    }
}
