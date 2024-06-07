using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using DECXML_Maximillian_Leonard.Utils;
using System.Text;
using System.Data.Entity.Core.Common.CommandTrees;

namespace DECXML_Maximillian_Leonard.Views.Admin
{
    public partial class EditProduct : System.Web.UI.Page
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
                string query = "SELECT name, type, gender, note, price, stock, [desc], image FROM products WHERE Id = @Id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Id", id);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    product_image.ImageUrl = "../../" + dr["image"].ToString();
                    name.Attributes.Add("placeholder", dr["name"].ToString());
                    type_placeholder.Text = dr["type"].ToString();
                    gender_placeholder.Text = dr["gender"].ToString();
                    note_placeholder.Text = dr["note"].ToString();
                    price.Attributes.Add("placeholder", dr["price"].ToString());
                    stock.Attributes.Add("placeholder", dr["stock"].ToString());
                    desc.Attributes.Add("placeholder", dr["desc"].ToString());
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

        protected void editProduct_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            try
            {
                StringBuilder setClause = new StringBuilder("SET ");
                bool hasUpdates = false;
                string uniqueFileName = Guid.NewGuid().ToString();

                if (!string.IsNullOrEmpty(name.Text))
                {
                    setClause.Append($"name= '{name.Text}', ");
                    hasUpdates = true;
                }

                if (!string.IsNullOrEmpty(price.Text))
                {
                    setClause.Append($"price= '{price.Text}', ");
                    hasUpdates = true;
                }

                if (!string.IsNullOrEmpty(stock.Text))
                {
                    setClause.Append($"stock= '{stock.Text}', ");
                    hasUpdates = true;
                }

                if (!string.IsNullOrEmpty(desc.Text))
                {
                    setClause.Append($"[desc]= '{desc.Text}', ");
                    hasUpdates = true;
                }

                if (product_img.HasFile)
                {
                    setClause.Append($"image= 'Image/Product/{uniqueFileName}.jpg', ");
                    hasUpdates = true;
                }

                if (!string.IsNullOrEmpty(type.SelectedValue)) // Check for non-empty value
                {
                    setClause.Append($"type= '{type.SelectedValue}', ");
                    hasUpdates = true;
                }

                if (!string.IsNullOrEmpty(gender.SelectedValue)) // Check for non-empty value
                {
                    setClause.Append($"gender= '{gender.SelectedValue}', ");
                    hasUpdates = true;
                }

                if (!string.IsNullOrEmpty(note.SelectedValue)) // Check for non-empty value
                {
                    setClause.Append($"note= '{note.SelectedValue}', ");
                    hasUpdates = true;
                }


                if (hasUpdates)
                {
                    setClause.Remove(setClause.Length - 2, 2);

                    con.Open();
                    string query = $"UPDATE products {setClause} WHERE Id='{Request.QueryString["Id"]}'";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    con.Close();

                    if (product_img.HasFile)
                    {
                        product_img.SaveAs(Server.MapPath($"Image/Product/{uniqueFileName}.jpg"));
                    }
                    XmlUtils.WriteXML("products", "product");
                }
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

        protected void deleteProduct_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            try
            {
                con.Open();

                string query = $"DELETE FROM products WHERE Id='{Request.QueryString["Id"]}'";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.ExecuteNonQuery();
                con.Close();

                XmlUtils.WriteXML("products", "product");
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
    }
}