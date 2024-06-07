using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using DECXML_Maximillian_Leonard.Utils;

namespace DECXML_Maximillian_Leonard.Views.Visitor
{
    public partial class Register : System.Web.UI.Page
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

        protected void registerSubmit_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            try
            {
                check_input();

                con.Open();
                string query = "INSERT INTO users (first_name, last_name, phone, email, password, user_type) VALUES(@first_name, @last_name, @phone, @email, @password, @user_type)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@first_name", first_name.Text);
                cmd.Parameters.AddWithValue("@last_name", last_name.Text);
                cmd.Parameters.AddWithValue("@phone", phone.Text);
                cmd.Parameters.AddWithValue("@email", email.Text);
                cmd.Parameters.AddWithValue("@password", password.Text);
                cmd.Parameters.AddWithValue("@user_type", "customer");
                cmd.ExecuteNonQuery();

                XmlUtils.WriteXML("users", "user");
                Response.Redirect("login");
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

        protected void check_input()
        {
            if (String.IsNullOrEmpty(first_name.Text)
                || String.IsNullOrEmpty(last_name.Text)
                || String.IsNullOrEmpty(phone.Text)
                || String.IsNullOrEmpty(email.Text)
                || String.IsNullOrEmpty(password.Text))
            {
                throw new Exception("Please enter all field.");
            }

            if (password.Text.Length < 5)
            {
                throw new Exception("Minimum 5 characters for password.");
            }

            if (!Int64.TryParse(phone.Text, out long value))
            {
                throw new Exception("Please enter a valid phone number (Digit).");
            }

            if (phone.Text.Length < 10)
            {
                throw new Exception("Please enter a valid phone number (Min 10).");
            }


            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            con.Open();

            string query = $"SELECT COUNT(*) FROM users WHERE phone = '{phone.Text}'";
            string query2 = $"SELECT COUNT(*) FROM users WHERE email = '{email.Text}'";

            SqlCommand cmd = new SqlCommand(query, con);
            SqlCommand cmd2 = new SqlCommand(query2, con);

            if (Convert.ToInt32(cmd.ExecuteScalar().ToString()) > 0)
            {
                con.Close();
                throw new Exception("The phone number already exists.");
            }


            if (Convert.ToInt32(cmd2.ExecuteScalar().ToString()) > 0)
            {
                con.Close();
                throw new Exception("The email address already exists.");
            }

            con.Close();
        }
    }
}