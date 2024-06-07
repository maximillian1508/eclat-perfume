using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using DECXML_Maximillian_Leonard.Utils;

namespace DECXML_Maximillian_Leonard.Views.Member
{
    public partial class PaymentConfirmation : System.Web.UI.Page
    {

        protected void Page_PreInit(object sender, EventArgs e)
        {
            if (Session["user_type"] == null)
            {
                Response.Redirect("/");
            }
            else if (String.Equals(Session["user_type"].ToString(), "admin"))
            {
                Response.Redirect("dashboard");
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            string order_id = "";
            string payment_status = "";
            SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            SqlConnection con2 = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            SqlConnection con3 = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            try
            {
                if (Request.QueryString["orderId"] != null)
                {
                    order_id = Request.QueryString["orderId"];
                }

                if (Request.QueryString["billplz[paid]"] != null)
                {
                    payment_status = Request.QueryString["billplz[paid]"];
                }

                if (String.Equals(payment_status, "true"))
                {
                    order_success.Visible = true;
                    success_order_id.InnerText = order_id;

                    con1.Open();
                    string query1 = $"UPDATE orders SET status = 'paid' WHERE Id = {order_id}";
                    SqlCommand cmd1 = new SqlCommand(query1, con1);
                    cmd1.ExecuteNonQuery();
                    con1.Close();

                    con2.Open();
                    string query2 = $"SELECT products.stock AS product_quantity, order_details.product_id AS product_id, order_details.quantity AS order_quantity FROM order_details INNER JOIN products ON order_details.product_id = products.Id WHERE order_details.order_id = {order_id}";
                    SqlCommand cmd2 = new SqlCommand(query2, con2);
                    SqlDataReader dr = cmd2.ExecuteReader();
                    while (dr.Read())
                    {
                        con3.Open();
                        string query3 = $"UPDATE products SET stock = @quantity WHERE Id = @Id";
                        SqlCommand cmd3 = new SqlCommand(query3, con3);
                        cmd3.Parameters.AddWithValue("quantity", Convert.ToInt32(dr["product_quantity"].ToString()) - Convert.ToInt32(dr["order_quantity"].ToString()));
                        cmd3.Parameters.AddWithValue("Id", dr["product_id"].ToString());
                        cmd3.ExecuteNonQuery();
                        con3.Close();
                    }
                    con2.Close();
                    XmlUtils.WriteXML("products", "product");
                }
                else if (String.Equals(payment_status, "false"))
                {
                    order_fail.Visible = true;
                    fail_order_id.InnerText = order_id;
                }
            } catch (Exception Ex)
            {
                errMsg.Visible = true;
                errMsg.Text = Ex.Message;
            } finally
            {
                con1.Close();
                con2.Close();
                con3.Close();
            }
        }
    }
}