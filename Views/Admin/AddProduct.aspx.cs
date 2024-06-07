using DECXML_Maximillian_Leonard.Utils;
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
    public partial class AddProduct : System.Web.UI.Page
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

        }

        protected void addProduct_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            try
            {
                check_input();
                string uniqueFileName = Guid.NewGuid().ToString();

                con.Open();
                string query = "INSERT INTO products (name, type, gender, note, price, stock, [desc], image) VALUES(@name, @type, @gender, @note, @price, @stock, @desc, @image)";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@name", name.Text);
                cmd.Parameters.AddWithValue("@type", type.SelectedValue);
                cmd.Parameters.AddWithValue("@gender", gender.SelectedValue);
                cmd.Parameters.AddWithValue("@note", note.SelectedValue);
                cmd.Parameters.AddWithValue("@price", price.Text);
                cmd.Parameters.AddWithValue("@stock", stock.Text);
                cmd.Parameters.AddWithValue("@desc", desc.Text);
                cmd.Parameters.AddWithValue("@image", $"Image/Product/{uniqueFileName}.jpg");
                cmd.ExecuteNonQuery();

                XmlUtils.WriteXML("products", "product");

                con.Close();

                product_img.SaveAs(Server.MapPath($"Image/Product/{uniqueFileName}.jpg"));

                Response.Redirect("manage-product");

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
            if (String.IsNullOrEmpty(name.Text)
                || String.IsNullOrEmpty(price.Text)
                || String.IsNullOrEmpty(stock.Text)
                || String.IsNullOrEmpty(desc.Text)
                || !product_img.HasFile)
            {
                throw new Exception("Please enter all field.");
            }
        }
    }
}