using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DECXML_Maximillian_Leonard.Views.Visitor
{
    public partial class Login : System.Web.UI.Page
    {

        protected void Page_PreInit(object sender, EventArgs e)
        {
            if (Session["user_type"] != null)
            {
                if (String.Equals(Session["user_type"].ToString(), "customer"))
                {
                    Response.Redirect("/");
                }
                else if (String.Equals(Session["user_type"].ToString(), "admin"))
                {
                    Response.Redirect("dashboard");
                }
            }
            else
            {
                MasterPageFile = "~/MasterPage/Visitor.Master";
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void email_TextChanged(object sender, EventArgs e)
        {

        }

        protected void login_submit_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            try
            {
                if (String.IsNullOrEmpty(password.Text) || String.IsNullOrEmpty(email.Text))
                {
                    throw new Exception("Please enter all field.");
                }

                con.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM users WHERE email=@email AND password=@password", con);
                command.Parameters.AddWithValue("@email", email.Text);
                command.Parameters.AddWithValue("@password", password.Text);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Session["user_id"] = reader["Id"].ToString().Trim();
                        Session["user_first_name"] = reader["first_name"].ToString().Trim();
                        Session["user_phone"] = reader["phone"].ToString().Trim();
                        Session["user_email"] = reader["email"].ToString().Trim();
                        Session["user_type"] = reader["user_type"].ToString().Trim();
                        Session["user_address"] = reader["address"].ToString().Trim();
                    }
                    if (Session["user_type"].ToString() == "customer")
                    {
                        Response.Redirect("/");
                    }
                    else
                    {
                        Response.Redirect("dashboard");
                    }
                }
                else
                {
                    throw new Exception("Incorrect username or password.");
                }
            }
            catch (Exception ex)
            {
                errMsg.Visible = true;
                errMsg.Text = ex.Message;
            } finally
            {
                con.Close();    
            }
        }
    }
}