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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Visible = false;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Registration.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (TextBox1.Text=="Admin@gmail.com" && TextBox2.Text=="123456")
            {
                Response.Redirect("Admin.aspx");
            }
            else
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                con.Open();

                SqlCommand cmd = new SqlCommand("select Email,Password from Users where Email=@Email and Password=@Password", con);
                cmd.Parameters.AddWithValue("@Email", TextBox1.Text);
                cmd.Parameters.AddWithValue("Password", TextBox2.Text);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                int i = cmd.ExecuteNonQuery();
                con.Close();
                if (dt.Rows.Count > 0)
                {
                    Session["id"] = TextBox1.Text;
                    Response.Redirect("Home.aspx");
                }
                else
                {
                    Label1.Visible = true;
                    Label1.Text = "Your Email or Password is incorrect";
                    Label1.ForeColor = System.Drawing.Color.Red;

                }
            }
            
        }
    }
}