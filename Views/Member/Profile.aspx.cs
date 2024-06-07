using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Text;
using DECXML_Maximillian_Leonard.Utils;
using System.Data;

namespace DECXML_Maximillian_Leonard.Views.Member
{
    public partial class Profile : System.Web.UI.Page
    {
        protected void Page_PreInit(object sender, EventArgs e)
        {

            if (Session["user_type"] == null)
            {
                Response.Redirect("/");
            }
            else if (String.Equals(Session["user_type"].ToString(), "admin"))
            {
                MasterPageFile = "~/MasterPage/Admin.Master";
            }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                con.Open();
                string query = "SELECT first_name, last_name, email, phone, address FROM users WHERE Id = @userID";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@userId", Session["user_id"]);

                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    firstName.Text = dr["first_name"].ToString();
                    lastName.Text = dr["last_name"].ToString();
                    email.Text = dr["email"].ToString();
                    phone.Text = dr["phone"].ToString();
                    address.Text = dr["address"].ToString();
                }
                con.Close();

                if (String.Equals(Session["user_type"].ToString(), "customer") && String.IsNullOrEmpty(address.Text))
                {
                    no_address.Visible = true;
                }

                if (String.Equals(Session["user_type"].ToString(), "admin"))
                {
                    order_nav_list.Visible = false;
                }
                else
                {
                    order_page();
                }
            }
            catch (Exception ex)
            {
                errMsg.Visible = true;
                errMsg.Text = ex.Message;
            }
        }


        protected void password_Click(object sender, EventArgs e)
        {
            password_input.Visible = !password_input.Visible;
        }

        protected void editProfile_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            try
            {
                check_input();

                StringBuilder setClause = new StringBuilder("SET ");
                bool hasUpdates = false;

                if (!string.IsNullOrEmpty(first_name_input.Text))
                {
                    setClause.Append($"first_name= '{first_name_input.Text}', ");
                    hasUpdates = true;
                }

                if (!string.IsNullOrEmpty(last_name_input.Text))
                {
                    setClause.Append($"last_name= '{last_name_input.Text}', ");
                    hasUpdates = true;
                }

                if (!string.IsNullOrEmpty(email_input.Text))
                {
                    setClause.Append($"email= '{email_input.Text}', ");
                    hasUpdates = true;
                }

                if (!string.IsNullOrEmpty(phone_input.Text))
                {
                    setClause.Append($"phone= '{phone_input.Text}', ");
                    hasUpdates = true;
                }


                if (!string.IsNullOrEmpty(address_input.Text))
                {
                    setClause.Append($"address= '{address_input.Text}', ");
                    hasUpdates = true;
                }

                if (!string.IsNullOrEmpty(password_input.Text))
                {
                    setClause.Append($"password= '{password_input.Text}', ");
                    hasUpdates = true;
                }

                if (hasUpdates)
                {
                    setClause.Remove(setClause.Length - 2, 2);
                    con.Open();
                    string query = $"UPDATE users {setClause} WHERE Id='{Session["user_id"]}'";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    con.Close();

                    if (!String.IsNullOrEmpty(first_name_input.Text))
                    {
                        Session["user_first_name"] = first_name_input.Text;
                    }
                    if (!String.IsNullOrEmpty(address_input.Text))
                    {
                        Session["user_address"] = address_input.Text;
                    }
                    XmlUtils.WriteXML("users", "user");
                }
                Response.Redirect(Request.RawUrl);
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

        protected void fn_edit_Click(object sender, EventArgs e)
        {
            first_name_input.Visible = !first_name_input.Visible;
            firstName.Visible = !firstName.Visible;
        }

        protected void ln_edit_Click(object sender, EventArgs e)
        {
            last_name_input.Visible = !last_name_input.Visible;
            lastName.Visible = !lastName.Visible;
        }

        protected void email_edit_Click(object sender, EventArgs e)
        {
            email_input.Visible = !email_input.Visible;
            email.Visible = !email.Visible;
        }

        protected void phone_edit_Click(object sender, EventArgs e)
        {
            phone_input.Visible = !phone_input.Visible;
            phone.Visible = !phone.Visible;
        }

        protected void address_edit_Click(object sender, EventArgs e)
        {
            address_input.Visible = !address_input.Visible;
            address.Visible = !address.Visible;
        }

        protected void order_page()
        {

            SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            con1.Open();
            string query1 = "SELECT Id AS order_id, total_amount AS order_amount, status AS order_status FROM orders WHERE user_id = @userId ORDER BY Id DESC";
            SqlCommand cmd1 = new SqlCommand(query1, con1);
            cmd1.Parameters.AddWithValue("@userId", Session["user_id"]);

            StringBuilder html = new StringBuilder();
            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = cmd1;
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con1.Close();

            foreach (DataRow row in dt.Rows)
            {
                SqlConnection con2 = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                con2.Open();
                string query2 = "SELECT order_details.quantity AS order_quantity, products.name AS product_name, products.price AS product_price, products.image AS product_image FROM order_details INNER JOIN products ON order_details.product_id = products.Id WHERE order_details.order_id= @orderId";
                SqlCommand cmd2 = new SqlCommand(query2, con2);
                cmd2.Parameters.AddWithValue("@orderId", row["order_id"]);

                SqlDataAdapter sda2 = new SqlDataAdapter();
                sda2.SelectCommand = cmd2;
                DataTable dt2 = new DataTable();
                sda2.Fill(dt2);
                con2.Close();


                con2.Open();
                int deleted_product = 0;
                SqlCommand cmd3 = new SqlCommand($"SELECT COUNT(*) FROM order_details WHERE order_id = '{row["order_id"]}'", con2);
                int product_in_order = Convert.ToInt32(cmd3.ExecuteScalar().ToString());
                con2.Close();
                if (dt2.Rows.Count != product_in_order)
                {
                    deleted_product = product_in_order - dt2.Rows.Count;
                }


                html.Append("<div class='container-shadow' style='padding: 0;width:100%; border: 1px solid black; border-radius: 10px'>");
                html.Append("<div style='width:95%; margin: 25px auto; display:flex; flex-direction: row;justify-content: space-between'>");
                html.Append("<div style='display: flex; flex-direction: column; width:60%'>");
                html.Append($"<span style='font-size: 26px; font-weight: 500'>Order #{row["order_id"]}</span>");
                html.Append("<div class='row row-cols-auto gap-3'>");
                foreach (DataRow row2 in dt2.Rows)
                {
                    html.Append("<div style='width:100%; display:flex; flex-direction: row'>");
                    html.Append($"<img style='width: 150px; height: 150px; object-fit: cover; aspect-ratio:1/1' src='{row2["product_image"]}'/>");
                    html.Append("<div style='display:flex; flex-direction: column; margin-left: 10px; justify-content:center'>");
                    html.Append($"<span style='font-size: 26px; font-weight:500'>{row2["product_name"]}</span>");
                    html.Append($"<span style='font-size: 18px'>{row2["order_quantity"]}x</span>");
                    html.Append($"<span style='font-size: 18px'>RM {row2["product_price"]}</span>");
                    html.Append("</div>");
                    html.Append("</div>");
                }
                for (int i = 0; i < deleted_product; i++)
                {
                    html.Append("<div style='display:flex; flex-direction: column; margin-left: 10px; justify-content:center; border: 1px solid black;border-radius:10px'>");
                    html.Append($"<span style='font-size: 26px; font-weight:500'>Product no longer available</span>");
                    html.Append($"<span style='font-size: 18px'>xxxxx</span>");
                    html.Append($"<span style='font-size: 18px'>RM xxxx</span>");
                    html.Append("</div>");
                }
                html.Append("</div>");
                html.Append("</div>");
                html.Append("<div style='display:flex; flex-direction: column; align-items:flex-end;width: 30%; text-align:center; margin-right: 10px; '>");
                if (String.Equals(row["order_status"], "fail"))
                {
                    html.Append($"<span style='padding: 10px; font-size: 20px; border-radius: 5px; background-color: #ffeaef; color: #ef144a'>Order Failed</span>");
                }
                else if (String.Equals(row["order_status"], "paid"))
                {
                    html.Append($"<span style='padding: 10px; font-size: 20px; border-radius: 5px; color:#fa6e3f; background-color: #fff0b3'>In Process</span>");
                }
                else
                {
                    html.Append($"<span style='padding: 10px; font-size: 20px; border-radius: 5px; background-color: #0fb01b; color:#d6ffde'>Delivered</span>");
                }
                html.Append("<span style='font-size: 20px; margin-top: auto'>Total Order</span>");
                html.Append($"<span style='font-size:24px; font-weight: 500'>RM {row["order_amount"]}</span>");

                html.Append("</div>");

                html.Append("</div>");
                html.Append("</div>");
            }
            order_placeholder.Controls.Add(new Literal { Text = html.ToString() });
        }

        protected void check_input()
        {
            if (!string.IsNullOrEmpty(password_input.Text))
            {
                if (password_input.Text.Length < 5)
                {
                    throw new Exception("Minimum 5 characters for password.");
                }
            }

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            con.Open();

            string query = $"SELECT COUNT(*) FROM users WHERE phone = '{phone_input.Text}'";
            string query2 = $"SELECT COUNT(*) FROM users WHERE email = '{email_input.Text}'";

            SqlCommand cmd = new SqlCommand(query, con);
            SqlCommand cmd2 = new SqlCommand(query2, con);

            if (!string.IsNullOrEmpty(email_input.Text))
            {
                if (Convert.ToInt32(cmd2.ExecuteScalar().ToString()) > 0)
                {
                    con.Close();
                    throw new Exception("The email address already exists.");
                }
            }

            if (!string.IsNullOrEmpty(phone_input.Text))
            {
                if (!Int64.TryParse(phone_input.Text, out long value))
                {
                    con.Close();
                    throw new Exception("Please enter a valid phone number (Digit).");
                }

                if (phone_input.Text.Length < 10)
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
            con.Close();
        }
    }
}