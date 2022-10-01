using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ClassLibrary5
{
    public class Class1
    {
        public SqlConnection con;
        public void connection()
        {
            string str = @"Data Source=DESKTOP-GI21EV1\SQLEXPRESS; Initial Catalog=Membership; Integrated Security=true;";
            con = new SqlConnection(str);
        }

        public DataSet selectCondoctor()
        {
            con.Open();
            string query = "select * from login";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sqlDataAdapter.Fill(ds);
            //var temp = ds.Tables[0].AsEnumerable().ToList();
            con.Close();
            return ds;
        }

        public void insertData(int id, string name, string pass, string email, string mo)
        {
            con.Open();
            string q = "insert into login (UserId,Name,password,email,Mobile_No) values('" + id + "','" + name + "','" + pass + "','" + email + "','" + mo + "')";
            SqlCommand sqlCommand = new SqlCommand(q, con);
            SqlDataAdapter d = new SqlDataAdapter(sqlCommand);
            d.SelectCommand.ExecuteNonQuery();
            con.Close();
        }


    }
}
