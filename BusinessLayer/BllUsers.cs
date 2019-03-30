using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class BllUsers
    {
        public DataTable CheckUserLogin(string username, string password, string usertype)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Integrated Security=true; Database=HostelDB");
            SqlCommand cmd = new SqlCommand("select * from tblUser where Username=@a and Password=@b and Usertype=@c", con);
            cmd.Parameters.AddWithValue("@a", username);
            cmd.Parameters.AddWithValue("@b", password);
            cmd.Parameters.AddWithValue("@c", usertype);
            SqlDataAdapter data = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            data.Fill(dt);
            return dt;
        }
        public DataTable CheckUser(string username, string password)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Integrated Security=true; Database=HostelDB");
            SqlCommand cmd = new SqlCommand("select * from tblUser where Username=@a and Password=@b", con);
            cmd.Parameters.AddWithValue("@a", username);
            cmd.Parameters.AddWithValue("@b", password);
            SqlDataAdapter data = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            data.Fill(dt);
            return dt;
        }

        public int UpdatePassword(string username, string password)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Integrated Security=true; Database=HostelDB");
            SqlCommand cmd = new SqlCommand("update tblUser set Password=@a where Username=@b", con);
            cmd.Parameters.AddWithValue("@a", password);
            cmd.Parameters.AddWithValue("@b", username);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            return i;
        }
    }
}
