using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using System.Configuration;
using DECXML_Maximillian_Leonard.Utils;
using System.Diagnostics;
using System.Text;

namespace DECXML_Maximillian_Leonard.Views.Admin
{
    public partial class EditUser : System.Web.UI.Page
    {

        protected void Page_PreInit(object sender, EventArgs e)
        {
            if (Session["user_type"] != null && !String.Equals(Session["user_type"].ToString(), "admin"))
            {
                Response.Redirect("/");
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            string id = "";
            if (Request.QueryString["Id"] != null)
            {
                id = Request.QueryString["Id"];
            }
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            try
            {
                con.Open();
                string query = "SELECT first_name, last_name, phone, email, address FROM users WHERE Id = @Id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Id", id);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    first_name.Attributes.Add("placeholder", dr["first_name"].ToString());
                    last_name.Attributes.Add("placeholder", dr["last_name"].ToString());
                    phone.Attributes.Add("placeholder", dr["phone"].ToString());
                    email.Attributes.Add("placeholder", dr["email"].ToString());
                    address.Attributes.Add("placeholder", dr["address"].ToString());
                }

                con.Close();
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

        protected void editUser_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            try
            {
                check_input();
                StringBuilder setClause = new StringBuilder("SET ");
                bool hasUpdates = false;

                if (!string.IsNullOrEmpty(first_name.Text))
                {
                    setClause.Append($"first_name= '{first_name.Text}', ");
                    hasUpdates = true;
                }

                if (!string.IsNullOrEmpty(last_name.Text))
                {
                    setClause.Append($"last_name= '{last_name.Text}', ");
                    hasUpdates = true;
                }

                if (!string.IsNullOrEmpty(phone.Text))
                {
                    setClause.Append($"phone= '{phone.Text}', ");
                    hasUpdates = true;
                }

                if (!string.IsNullOrEmpty(email.Text))
                {
                    setClause.Append($"email= '{email.Text}', ");
                    hasUpdates = true;
                }

                if (!string.IsNullOrEmpty(password.Text))
                {
                    setClause.Append($"password= '{password.Text}', ");
                    hasUpdates = true;
                }

                if (!string.IsNullOrEmpty(address.Text))
                {
                    setClause.Append($"address= '{address.Text}', ");
                    hasUpdates = true;
                }

                if (hasUpdates)
                {
                    setClause.Remove(setClause.Length - 2, 2);

                    con.Open();
                    string query = $"UPDATE users {setClause} WHERE Id='{Request.QueryString["Id"]}'";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    con.Close();

                    XmlUtils.WriteXML("users", "user");
                }
                Response.Redirect("manage-user");
            } catch (Exception ex)
            {
                errMsg.Visible = true;
                errMsg.Text= ex.Message;
            } finally
            {
                con.Close();    
            }
        }

        protected void deleteUser_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            try
            {
                con.Open();
                string query = $"DELETE FROM users WHERE Id='{Request.QueryString["Id"]}'";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();

                XmlUtils.WriteXML("users", "user");
                Response.Redirect("manage-user");
            }
            catch (Exception ex)
            {
                errMsg.Visible = true;
                errMsg.Text= ex.Message;
            } finally
            {
                con.Close();
            }
        }

        protected void check_input()
        {
            if (!string.IsNullOrEmpty(password.Text))
            {
                if (password.Text.Length < 5)
                {
                    throw new Exception("Minimum 5 characters for password.");
                }
            }

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            con.Open();

            string query = $"SELECT COUNT(*) FROM users WHERE phone = '{phone.Text}'";
            string query2 = $"SELECT COUNT(*) FROM users WHERE email = '{email.Text}'";

            SqlCommand cmd = new SqlCommand(query, con);
            SqlCommand cmd2 = new SqlCommand(query2, con);

            if (!string.IsNullOrEmpty(email.Text))
            {
                if (Convert.ToInt32(cmd2.ExecuteScalar().ToString()) > 0)
                {
                    con.Close();
                    throw new Exception("The email address already exists.");
                }
            }

            if (!string.IsNullOrEmpty(phone.Text))
            {
                if (!Int64.TryParse(phone.Text, out long value))
                {
                    con.Close();
                    throw new Exception("Please enter a valid phone number (Digit).");
                }

                if (phone.Text.Length < 10)
                {
                    con.Close();
                    throw new Exception("Please enter a valid phone number (Min 10).");
                }

                if (Convert.ToInt32(cmd.ExecuteScalar().ToString()) > 0)
                {
                    con.Close();
                    throw new Exception("The phone number already exists.");
                }
            }
        }
    }
}