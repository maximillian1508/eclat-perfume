using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace DECXML_Maximillian_Leonard.MasterPage
{
    public partial class Member : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (String.Equals(Session["user_type"], "admin") && !String.Equals(HttpContext.Current.Request.Url.AbsolutePath, "/profile"))
            {
                Response.Redirect("dashboard");
            }
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            con.Open();
            string query = "SELECT COUNT(*) FROM cart WHERE user_id = @user_id AND status='0'";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@user_id", Session["user_id"]);

            int cartQuant = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();


            if (cartQuant > 0) { 
                cart_quantity.InnerText = cartQuant.ToString();
                cart_quantity.Style.Add("display", "inline-block");
            }
        }
        protected void logout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Request.Cookies.Clear();
            Response.Cookies.Clear();
            Response.Redirect("/");
        }
    }
}