using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SellEx
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string user = Session["id"].ToString();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("select Name from Users where Email='" + user + "'", con);
            cmd.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (Session["id"] != null)
            {
                TextBox1.Text = dt.Rows[0][0].ToString();
                TextBox2.Text = user;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (TextBox3.Text=="")
            {
                Response.Write("<script>alert('Please enter your messege')</script>");
            }
            else
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("insert into Complain(Name,Email,Messege)values(@Name, @Email, @Messege)", con);
                cmd.Parameters.AddWithValue("@Name", TextBox1.Text);
                cmd.Parameters.AddWithValue("@Email", TextBox2.Text);
                cmd.Parameters.AddWithValue("@Messege", TextBox3.Text);
                cmd.ExecuteNonQuery();
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("select ProductName from Product where ProductName=@PN", con);
            cmd.Parameters.AddWithValue("@PN", TextBox4.Text);
            cmd.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count>0)
            {
                Response.Redirect("Order.aspx");
            }
        }
    }
}