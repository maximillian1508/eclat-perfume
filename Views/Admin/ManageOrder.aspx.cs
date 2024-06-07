using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Text;

namespace DECXML_Maximillian_Leonard.Views.Admin
{
    public partial class ManageOrder : System.Web.UI.Page
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
            processed_order();
            delivered_order();
            failed_order();
        }

        protected void processed_order()
        {
            SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            con1.Open();
            string query1 = "SELECT orders.Id AS order_id, orders.total_amount AS order_amount, orders.status AS order_status, users.email AS user_email FROM orders INNER JOIN users ON orders.user_id = users.Id WHERE status = 'paid' ORDER BY orders.Id DESC";
            SqlCommand cmd1 = new SqlCommand(query1, con1);

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
                html.Append($"<span style='font-size: 26px; font-weight: 500'>Order #{row["order_id"]} - {row["user_email"]}</span>");
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
                if (String.Equals(row["order_status"], "paid"))
                {
                    html.Append($"<span style='padding: 10px; font-size: 20px; border-radius: 5px; color:#fa6e3f; background-color: #fff0b3'>Waiting for Delivery</span>");
                }
                html.Append("<span style='font-size: 20px; margin-top: auto'>Total Order</span>");
                html.Append($"<span style='font-size:24px; font-weight: 500'>RM {row["order_amount"]}</span>");
                html.Append($"<a class='black-button' href='deliver-order?Id={row["order_id"]}' style='padding: 5px 10px; border-radius: 10px; margin-top: 10px;'>Deliver Order</a>");


                html.Append("</div>");

                html.Append("</div>");
                html.Append("</div>");
            }
            if (dt.Rows.Count < 1)
            {
                html.Append("<h3>No waiting to be delivered order!</h3>");
            }
            process_placeholder.Controls.Add(new Literal { Text = html.ToString() });
        }

        protected void delivered_order()
        {
            SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            con1.Open();
            string query1 = "SELECT orders.Id AS order_id, orders.total_amount AS order_amount, orders.status AS order_status, users.email AS user_email FROM orders INNER JOIN users ON orders.user_id = users.Id WHERE status = 'delivered' ORDER BY orders.Id DESC";
            SqlCommand cmd1 = new SqlCommand(query1, con1);

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
                html.Append($"<span style='font-size: 26px; font-weight: 500'>Order #{row["order_id"]} - {row["user_email"]}</span>");
                html.Append("<div class='row row-cols-auto gap-3'>");
                if(dt2.Rows.Count > 0 )
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
                if (String.Equals(row["order_status"], "delivered"))
                {
                    html.Append($"<span style='padding: 10px; font-size: 20px; border-radius: 5px; background-color: #0fb01b; color:#d6ffde'>Delivered</span>");
                }
                html.Append("<span style='font-size: 20px; margin-top: auto'>Total Order</span>");
                html.Append($"<span style='font-size:24px; font-weight: 500'>RM {row["order_amount"]}</span>");
                html.Append("</div>");
                html.Append("</div>");
                html.Append("</div>");
            }

            if (dt.Rows.Count < 1)
            {
                html.Append("<h3>No delivered order!</h3>");
            }
            delivered_placeholder.Controls.Add(new Literal { Text = html.ToString() });
        }

        protected void failed_order()
        {
            SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            con1.Open();
            string query1 = "SELECT orders.Id AS order_id, orders.total_amount AS order_amount, orders.status AS order_status, users.email AS user_email FROM orders INNER JOIN users ON orders.user_id = users.Id WHERE status = 'fail' ORDER BY orders.Id DESC";
            SqlCommand cmd1 = new SqlCommand(query1, con1);

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
                html.Append($"<span style='font-size: 26px; font-weight: 500'>Order #{row["order_id"]} - {row["user_email"]}</span>");
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
                html.Append("<span style='font-size: 20px; margin-top: auto'>Total Order</span>");
                html.Append($"<span style='font-size:24px; font-weight: 500'>RM {row["order_amount"]}</span>");
                html.Append("</div>");
                html.Append("</div>");
                html.Append("</div>");
            }

            if (dt.Rows.Count < 1)
            {
                html.Append("<h3>No failed order!</h3>");
            }
            failed_placeholder.Controls.Add(new Literal { Text = html.ToString() });
        }
    }
}