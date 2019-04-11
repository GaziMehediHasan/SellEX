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
    public partial class Order : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void DataList2_ItemCommand(object source, DataListCommandEventArgs e)
        {
            string p = "";
            string name = "";
            if (e.CommandName == "GetText")
            {
                p = e.CommandArgument.ToString();
            }

            string user = Session["id"].ToString();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("select Name from Users where Email='" + user + "'", con);
            cmd.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            name = dt.Rows[0][0].ToString();
            cmd = new SqlCommand("insert into Cart(PName,BName) values(@PN, @BN)", con);
            cmd.Parameters.AddWithValue("@BN" , name);
            cmd.Parameters.AddWithValue("@PN", p);
            cmd.ExecuteNonQuery();
            cmd = new SqlCommand("delete from Product where ProductName=@PN", con);
            cmd.Parameters.AddWithValue("@PN", p);
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}