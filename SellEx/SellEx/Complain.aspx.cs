using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SellEx
{
    public partial class Complain : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("select Name,Email,Messege from Complain", con);
            cmd.ExecuteNonQuery();

            string temp = "";

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                temp += reader["Name"].ToString();
                temp += " ";
                temp += reader["Email"].ToString();
                temp += " ";
                temp += reader["Messege"].ToString();
                temp += "<br/ >";
            }
            con.Close();

            Label1.Text = temp;
        }
    }
}