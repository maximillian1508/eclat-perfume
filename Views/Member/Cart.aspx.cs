using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using RestSharp;
using System.Runtime.InteropServices;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Xml.Linq;
using System.Configuration;
using System.Data;
using System.Text;
using DECXML_Maximillian_Leonard.Utils;
using System.Data.Entity.Core.Common.CommandTrees;
using WebGrease.Extensions;

namespace DECXML_Maximillian_Leonard.Views.Member
{
    public partial class Cart : System.Web.UI.Page
    {

        protected void Page_PreInit(object sender, EventArgs e)
        {
            if (Session["user_type"] == null)
            {
                Response.Redirect("login");
            }
            else if (String.Equals(Session["user_type"].ToString(), "admin"))
            {
                Response.Redirect("dashboard");
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            SqlConnection con2 = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            try
            {
                if (!IsPostBack)
                {
                    SqlCommand cmd1 = new SqlCommand("SELECT products.Id as product_id, products.name as product_name, products.price as product_price, products.image as product_image, cart.quantity as cart_quantity, cart.Id as cart_id, cart.user_id as user_id FROM products INNER JOIN cart ON products.Id = cart.product_id INNER JOIN users ON cart.user_id = users.Id WHERE cart.user_id = " + Session["user_id"] + " AND cart.status=0", con1);
                    DataSet ds = new DataSet();
                    SqlDataAdapter da = new SqlDataAdapter(cmd1);
                    da.Fill(ds);
                    cartRepeater.DataSource = ds;
                    cartRepeater.DataBind();

                    DataTable dt = new DataTable();
                    double total_cart = 0;
                    List<string> cart_item = new List<string>();
                    List<string> item_quantity = new List<string>();
                    da.Fill(dt);
                    con1.Close();

                    foreach (DataRow row in dt.Rows)
                    {
                        double total = Convert.ToDouble(row["cart_quantity"]) * Convert.ToDouble(row["product_price"]);
                        total_cart = total_cart + total;
                        cart_item.Add(row["product_id"].ToString());
                        item_quantity.Add(row["cart_quantity"].ToString());
                    }
                    subtotal.Text = total_cart.ToString();
                    Session["cart_item"] = cart_item.ToArray();
                    Session["item_quantity"] = item_quantity.ToArray();
                }

                con2.Open();
                string query2 = "SELECT address FROM users WHERE Id = @Id";
                SqlCommand cmd2 = new SqlCommand(query2, con2);
                cmd2.Parameters.AddWithValue("@Id", Session["user_id"]);
                SqlDataReader dr = cmd2.ExecuteReader();
                dr.Read();
                cust_address.Text = dr["address"].ToString();
                con2.Close();

            }
            catch (Exception ex)
            {
                errMsg.Visible = true;
                errMsg.Text = ex.Message;
            }
            finally
            {
                con1.Close();
                con2.Close();
            }
        }

        protected void checkout_Click(object sender, EventArgs e)
        {
            SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            SqlConnection con2 = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            SqlConnection con3 = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            try
            {
                if (String.IsNullOrEmpty(Session["user_address"] as string))
                {
                    Response.Redirect("profile");
                }
                con1.Open();
                string query1 = "INSERT INTO orders (user_id, total_amount, status) VALUES(@user_id, @total_amount, @status); SELECT scope_identity();";
                SqlCommand cmd1 = new SqlCommand(query1, con1);

                cmd1.Parameters.AddWithValue("user_id", Session["user_id"]);
                cmd1.Parameters.AddWithValue("total_amount", subtotal.Text);
                cmd1.Parameters.AddWithValue("status", "fail");

                string order_id = cmd1.ExecuteScalar().ToString();
                con1.Close();

                string[] cart_item = { };
                string[] item_quantity = { };

                if (Session["cart_item"] != null && Session["item_quantity"] != null)
                {
                    cart_item = (String[])Session["cart_item"];
                    item_quantity = (String[])Session["item_quantity"];
                    Session.Remove("cart_item");
                    Session.Remove("item_quantity");
                }

                if (cart_item.Length > 0)
                {
                    for (int i = 0; i < cart_item.Length; i++)
                    {
                        con2.Open();
                        string query2 = "INSERT INTO order_details (order_id, product_id, quantity) VALUES(@order_id, @product_id, @quantity)";
                        SqlCommand cmd2 = new SqlCommand(query2, con2);

                        cmd2.Parameters.AddWithValue("order_id", order_id);
                        cmd2.Parameters.AddWithValue("product_id", cart_item[i]);
                        cmd2.Parameters.AddWithValue("quantity", item_quantity[i]);

                        cmd2.ExecuteNonQuery();
                        con2.Close();

                        con3.Open();
                        string query3 = "UPDATE cart SET status = '1' WHERE user_id=@user_id AND product_id=@product_id AND status='0'";
                        SqlCommand cmd3 = new SqlCommand(query3, con3);

                        cmd3.Parameters.AddWithValue("user_id", Session["user_id"]);
                        cmd3.Parameters.AddWithValue("product_id", cart_item[i]);

                        cmd3.ExecuteNonQuery();
                        con3.Close();
                    }


                    RestClient client = new RestClient("https://www.billplz-sandbox.com");
                    var request = new RestRequest("/api/v3/bills");

                    // Add parameters to request
                    request.AddParameter("collection_id", "gd8lkely");
                    request.AddParameter("email", Session["user_email"].ToString());
                    request.AddParameter("name", Session["user_first_name"].ToString());
                    request.AddParameter("description", "Pay for your perfume");
                    request.AddParameter("amount", subtotal.Text + "00");
                    request.AddParameter("callback_url", "https://eclatperfume.azurewebsites.net/payment-confirmation");
                    request.AddParameter("redirect_url", $"https://eclatperfume.azurewebsites.net/payment-confirmation?orderId={order_id}");
                    //request.AddParameter("callback_url", "https://localhost:44334/payment-confirmation");
                    //request.AddParameter("redirect_url", $"https://localhost:44334/payment-confirmation?orderId={order_id}");

                    // Set the Authorization header
                    request.AddHeader("Authorization", "Basic ZjExYjE2OTUtOGM5Ny00Y2ViLWE2OTEtMWJkNTAxZTgwYjQ0");

                    // Execute the request synchronously
                    RestResponse response = client.Post(request);

                    // Process the response
                    if (response.IsSuccessful)
                    {
                        var content = response.Content; // This is the raw content as a string
                        var url = ParseUrlFromResponse(content);
                        Response.Redirect(url);
                    }
                    else
                    {
                        throw new Exception($"Error: {response.ErrorMessage}");
                    }
                }
                else
                {
                    throw new Exception("Empty Cart!");
                }
            }
            catch (Exception Ex)
            {
                errMsg.Visible = true;
                errMsg.Text = Ex.Message;
            }
            finally
            {

            }
        }

        private string ParseUrlFromResponse(string responseContent)
        {
            var jsonContent = JsonSerializer.Deserialize<JsonElement>(responseContent);

            // Check if the "url" property exists and extract its value
            if (jsonContent.TryGetProperty("url", out JsonElement urlElement))
            {
                return urlElement.GetString();
            }
            else
            {
                // Handle the case where the "url" field is not found
                throw new Exception("URL field not found in the JSON response.");
            }
        }

        protected void removeItem_Click(object sender, EventArgs e)
        {
            Button remove_button = (Button)sender;
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            string cart_item_id = remove_button.Attributes["cart_id"].ToString();

            try
            {
                con.Open();
                string query = $"DELETE FROM cart WHERE Id='{cart_item_id}'";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();

                Response.Redirect(Request.RawUrl);
            }
            catch (Exception ex)
            {
                errMsg.Visible = true;
                errMsg.Text = ex.Message;
            }
            finally
            {
                con.Close();
            }
        }

        protected void stock_TextChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            try
            {
                TextBox quant = (TextBox)sender;

                string cart_item_id = quant.Attributes["cart_id"].ToString();

                con.Open();
                string query = $"UPDATE cart SET quantity='{quant.Text}' WHERE Id='{cart_item_id}'";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();

                Response.Redirect(Request.RawUrl);
            }
            catch (Exception ex)
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