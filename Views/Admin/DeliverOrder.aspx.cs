using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace DECXML_Maximillian_Leonard.Views.Admin
{
    public partial class DeliverOrder : System.Web.UI.Page
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
            SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            try
            {
                con.Open();
                string query = "SELECT orders.total_amount AS order_amount, users.email AS cust_email, users.phone AS cust_phone, users.address AS cust_address FROM orders INNER JOIN users ON orders.user_id = users.Id WHERE orders.Id = @Id;";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Id", id);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    order_id.Text = $"Order #{id}";
                    order_amount.Text = dr["order_amount"].ToString();
                    cust_email.Text = dr["cust_email"].ToString();
                    cust_phone.Text = dr["cust_phone"].ToString();
                    cust_address.Text = dr["cust_address"].ToString();
                }
                con.Close();

                con1.Open();
                string query1 = "SELECT order_details.quantity AS item_quantity, products.name AS product_name, products.price AS product_price FROM order_details INNER JOIN products ON order_details.product_id = products.Id WHERE order_details.order_id = @Id;";
                SqlCommand cmd1 = new SqlCommand(query1, con1);
                cmd1.Parameters.AddWithValue("@Id", id);
                SqlDataReader dr1 = cmd1.ExecuteReader();
                string item = "";

                while (dr1.Read())
                {
                    item = item + $"{dr1["product_name"]} - {dr1["item_quantity"]} QTY (RM {dr1["product_price"]}), ";
                }
                order_item.Text = item.Remove(item.Length - 2);
                con1.Close();
            } catch (Exception ex)
            {
                errMsg.Visible = true;
                errMsg.Text = ex.Message;
            } finally
            {
                con.Close();
                con1.Close();
            }
        }

        protected void deliverOrder_Click(object sender, EventArgs e)
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
                string query = "UPDATE orders SET status = 'delivered' WHERE Id=@Id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("Id", id);
                cmd.ExecuteNonQuery();
                con.Close();

                Response.Redirect("manage-order");
            } catch (Exception ex)
            {
                errMsg.Visible = true;
                errMsg.Text = ex.Message;
            }
            finally
            {
                con.Close();
            }
        }
    }
}