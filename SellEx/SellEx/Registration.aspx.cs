using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SellEx
{
    public partial class Registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Visible = false;
            Label2.Visible = false;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("select Email from Users where Email= @Email", con);
            cmd.Parameters.AddWithValue("@Email", TextBox2.Text);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                Label2.Visible = true;
            }
            else
            {
                if (TextBox3.Text == TextBox4.Text)
                {
                    cmd = new SqlCommand("insert into Users(Name,Email,Password)values(@Name, @Email, @Password)", con);
                    cmd.Parameters.AddWithValue("@Name", TextBox1.Text);
                    cmd.Parameters.AddWithValue("@Email", TextBox2.Text);
                    cmd.Parameters.AddWithValue("@Password", TextBox3.Text);
                    cmd.ExecuteNonQuery();
                    Session["id"] = TextBox2.Text;
                    Response.Redirect("Home.aspx");
                }
                else
                {
                    Label1.Visible = true;
                }
            }
            
        }
    }
}