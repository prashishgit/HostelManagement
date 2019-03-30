using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetroFramework;
namespace BusinessLayer
{
    public class BllStudent
    {
        public int CreateStudent(string firstName, string lastName, string gender, DateTime regDate, bool isActive)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Integrated Security=true; Database=HostelDB");
            SqlCommand cmd = new SqlCommand("insert into tblStudent values(@a,@b,@c,@d,@e)", con);
            cmd.Parameters.AddWithValue("@a", firstName);
            cmd.Parameters.AddWithValue("@b", lastName);
            cmd.Parameters.AddWithValue("@c", gender);
            cmd.Parameters.AddWithValue("@d", regDate);
            cmd.Parameters.AddWithValue("@e", isActive);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            
            return i;
        }
        public int UpdateStudent(string firstName, string lastName, string gender, DateTime regDate, bool isActive, int studentId)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Integrated Security=true; Database=HostelDB");
            SqlCommand cmd = new SqlCommand("update tblStudent set Firstname=@a,Lastname=@b,Gender=@c,ReqDate=@d,IsActive=@e where StudentId=@f", con);
            cmd.Parameters.AddWithValue("@a", firstName);
            cmd.Parameters.AddWithValue("@b", lastName);
            cmd.Parameters.AddWithValue("@c", gender);
            cmd.Parameters.AddWithValue("@d", regDate);
            cmd.Parameters.AddWithValue("@e", isActive);
            cmd.Parameters.AddWithValue("@f", studentId);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            return i;
        }
        public int DeleteStudent(int studentId)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Integrated Security=true; Database=HostelDB");
            SqlCommand cmd = new SqlCommand("delete from tblStudent where StudentId=@f", con);
            cmd.Parameters.AddWithValue("@f", studentId);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            return i;
        }
        public DataTable GetAllStudent()
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Integrated Security=true; Database=HostelDB");
            SqlCommand cmd = new SqlCommand("select * from tblStudent", con);
            SqlDataAdapter data = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            data.Fill(dt);
            return dt;
        }
        public DataTable GetStudentById(int studentId)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Integrated Security=true; Database=HostelDB");
            SqlCommand cmd = new SqlCommand("select * from tblStudent where studentid=@f", con);
            cmd.Parameters.AddWithValue("@f", studentId);
            SqlDataAdapter data = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            data.Fill(dt);
            return dt;
        }
    }
}
