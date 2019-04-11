using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;

namespace SellEx
{
    public partial class Profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string user = Session["id"].ToString();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            con.Open();
            
            if (TextBox1.Text != "" && TextBox2.Text != "")
            {
                SqlCommand cmd = new SqlCommand("update Users set Address = @Address, Phone = @Phone where Email='" + user + "'", con);
                cmd.Parameters.AddWithValue("@Address", TextBox1.Text);
                cmd.Parameters.AddWithValue("@Phone", TextBox2.Text);
                cmd.ExecuteNonQuery();
            }

            else if (TextBox1.Text == "")
            {
                SqlCommand cmd = new SqlCommand("update Users set Phone = @Phone where Email='" + user + "'", con);
                cmd.Parameters.AddWithValue("@Phone", TextBox2.Text);
                cmd.ExecuteNonQuery();
            }

            else if (TextBox2.Text == "")
            {
                SqlCommand cmd = new SqlCommand("update Users set Address = @Address where Email='" + user + "'", con);
                cmd.Parameters.AddWithValue("@Address", TextBox1.Text);
                cmd.ExecuteNonQuery();
            }
            else if (TextBox1.Text == "" && TextBox2.Text == "")
            {
                 Response.Write("<script>alert('Enter your data to update')</script>");
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string user = Session["id"].ToString();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("select Name,Status,Phone from Users where Email='" + user + "'", con);
            cmd.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            string name= dt.Rows[0][0].ToString();
            string st= dt.Rows[0][1].ToString();
            string ph = dt.Rows[0][2].ToString();
            if (st=="1")
            {
                if (ph !="")
                {
                    if (FileUpload1.HasFile)
                    {
                        string ext = System.IO.Path.GetExtension(FileUpload1.FileName);
                        if (ext == ".jpg" || ext == ".png")
                        {
                            FileUpload1.SaveAs(Server.MapPath("~/products/") + Path.GetFileName(FileUpload1.FileName));
                            string img = "products/" + Path.GetFileName(FileUpload1.FileName);
                            cmd = new SqlCommand("insert into Product(ProductName,UserName,Image,Price,Phone)values(@PName, @UName, @Image,@Price,@Phone)", con);
                            cmd.Parameters.AddWithValue("@PName", TextBox3.Text);
                            cmd.Parameters.AddWithValue("@UName", name);
                            cmd.Parameters.AddWithValue("@Image", img);
                            cmd.Parameters.AddWithValue("@Price", TextBox4.Text);
                            cmd.Parameters.AddWithValue("@Phone", ph);
                            cmd.ExecuteNonQuery();
                        }
                        else
                        {
                            Response.Write("<script>alert('Only image(.jpg,.png) can upload')</script>");
                        }
                    }
                }
                else
                    Response.Write("<script>alert('You need to add your contact number to sell object')</script>");
            }
            else
                Response.Write("<script>alert('You are disable to sell object')</script>");

        }
    }
}