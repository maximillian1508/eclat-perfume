using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using System.Configuration;
using DECXML_Maximillian_Leonard.Utils;
using System.Drawing;

namespace DECXML_Maximillian_Leonard.Views.Visitor
{
    public partial class ProductDetails : System.Web.UI.Page
    {
        protected void Page_PreInit(object sender, EventArgs e)
        {
            if (Session["user_type"] != null)
            {
                if (String.Equals(Session["user_type"].ToString(), "customer"))
                {
                    MasterPageFile = "~/MasterPage/Member.Master";
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
            string id = "";
            if (Request.QueryString["Id"] != null)
            {
                id = Request.QueryString["Id"];
            }
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            try
            {
                con.Open();
                string query = "SELECT name, type, gender, note, price, stock, [desc], image FROM products WHERE Id = @Id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Id", id);

                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    product_image.ImageUrl = "../../" + dr["image"].ToString();
                    name.Text = XmlUtils.CapitalizeLetter(dr["name"].ToString());
                    type.Text = XmlUtils.CapitalizeLetter(dr["type"].ToString());
                    gender.Text = XmlUtils.CapitalizeLetter(dr["gender"].ToString());
                    note.Text = XmlUtils.CapitalizeLetter(dr["note"].ToString());
                    price.Text = "RM " + dr["price"].ToString();
                    stock.Text = "Available: " + dr["stock"].ToString();
                    quantity.Attributes.Add("max", dr["stock"].ToString());
                    desc.Text = dr["desc"].ToString();
                    if (Convert.ToInt32(dr["stock"].ToString()) == 0)
                    {
                        addToCart.Enabled = false;
                        addToCart.Text = "Out of stock!";
                        addToCart.Style.Add("padding", "5px 10px");
                        addToCart.Style.Add("font-size", "24px");
                        addToCart.Style.Add("opacity", "0.5");
                        addToCart.Style.Add("background-color", "black");
                        addToCart.Style.Add("color", "white");
                    }
                }
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

        protected void addToCart_Click(object sender, EventArgs e)
        {
            if (Session["user_type"] == null)
            {
                Response.Redirect("login");
            }

            SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            SqlConnection con2 = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            try
            {
                con1.Open();
                string query1 = $"SELECT Id, quantity FROM cart WHERE user_id = '{Session["user_id"]}' AND product_id = '{Request.QueryString["Id"]}' AND status='0'";
                SqlCommand cmd1 = new SqlCommand(query1, con1);
                SqlDataReader dr = cmd1.ExecuteReader();

                if (dr.Read())
                {
                    int prodInCart = Convert.ToInt32(dr["quantity"]);
                    string prodId = dr["Id"].ToString();

                    con2.Open();
                    string query2 = $"UPDATE cart SET quantity = @quantity WHERE Id = '{prodId}'";
                    SqlCommand cmd2 = new SqlCommand(query2, con2);
                    cmd2.Parameters.AddWithValue("@quantity", prodInCart + Convert.ToInt32(quantity.Text));
                    cmd2.ExecuteNonQuery();
                }
                else
                {
                    con2.Open();
                    string query2 = "INSERT INTO cart (product_id, quantity, user_id, status) VALUES(@product_id, @quantity, @user_id, @status)";

                    SqlCommand cmd2 = new SqlCommand(query2, con2);
                    cmd2.Parameters.AddWithValue("@product_id", Request.QueryString["Id"]);
                    cmd2.Parameters.AddWithValue("@quantity", quantity.Text);
                    cmd2.Parameters.AddWithValue("@user_id", Session["user_id"]);
                    cmd2.Parameters.AddWithValue("@status", "0");
                    cmd2.ExecuteNonQuery();
                }

                Response.Redirect(Request.RawUrl);
            }
            catch (Exception ex)
            {
                errMsg.Visible = true;
                errMsg.Text = ex.Message;
            } finally
            {
                con1.Close();
                con2.Close();
            }

        }
    }
}