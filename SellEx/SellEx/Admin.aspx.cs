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
    public partial class Admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Visible = false;
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("Complain.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("update Users set Status = @Status where Email=@Email", con);
            cmd.Parameters.AddWithValue("@Status", 0);
            cmd.Parameters.AddWithValue("@Email", TextBox2.Text);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
                cmd.ExecuteNonQuery();
            else
            {
                Label1.Text = "User not found!";
                Label1.Visible = true;
            }
            con.Close();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("delete from Product where ProductName=@PN", con);
            cmd.Parameters.AddWithValue("@PN", TextBox1.Text);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
                cmd.ExecuteNonQuery();
            else
            {
                Label1.Text = "Product not found!";
                Label1.Visible = true;
            }
            con.Close();
        }
    }
}