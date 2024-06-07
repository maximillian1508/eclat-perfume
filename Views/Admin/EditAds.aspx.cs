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
using System.Text;

namespace DECXML_Maximillian_Leonard.Views.Admin
{
    public partial class EditAds : System.Web.UI.Page
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
                string query = "SELECT ImageUrl, NavigateUrl, AlternateText, Keyword, Impressions FROM Advertisements WHERE Id = @Id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Id", id);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    ads_image.ImageUrl = "../" + dr["ImageUrl"].ToString();
                    nav_url.Attributes.Add("placeholder", dr["NavigateUrl"].ToString());
                    alt_text.Attributes.Add("placeholder", dr["AlternateText"].ToString());
                    keyword.Attributes.Add("placeholder", dr["Keyword"].ToString());
                    impressions.Attributes.Add("placeholder", dr["Impressions"].ToString());
                }

                con.Close();
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

        protected void editAdvertisement_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            try
            {
                StringBuilder setClause = new StringBuilder("SET ");
                bool hasUpdates = false;
                string uniqueFileName = Guid.NewGuid().ToString();


                if (ads_img.HasFile)
                {
                    setClause.Append($"ImageUrl= '../Image/Ads/{uniqueFileName}.jpg', ");
                    hasUpdates = true;
                }

                if (!string.IsNullOrEmpty(nav_url.Text))
                {
                    setClause.Append($"NavigateUrl= '{nav_url.Text}', ");
                    hasUpdates = true;
                }

                if (!string.IsNullOrEmpty(alt_text.Text))
                {
                    setClause.Append($"AlternativeText= '{alt_text.Text}', ");
                    hasUpdates = true;
                }

                if (!string.IsNullOrEmpty(keyword.Text))
                {
                    setClause.Append($"Keyword= '{keyword.Text}', ");
                    hasUpdates = true;
                }

                if (!string.IsNullOrEmpty(impressions.Text))
                {
                    setClause.Append($"Impressions= '{impressions.Text}', ");
                    hasUpdates = true;
                }


                if (hasUpdates)
                {
                    setClause.Remove(setClause.Length - 2, 2);

                    con.Open();
                    string query = $"UPDATE Advertisements {setClause} WHERE Id='{Request.QueryString["Id"]}'";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    con.Close();

                    if (ads_img.HasFile)
                    {
                        ads_img.SaveAs(Server.MapPath($"Image/Ads/{uniqueFileName}.jpg"));
                    }
                    XmlUtils.WriteXML("Advertisements", "Ad");
                }
                Response.Redirect("manage-ads");
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

        protected void deleteAdvertisement_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            try
            {
                con.Open();
                string query = $"DELETE FROM Advertisements WHERE Id='{Request.QueryString["Id"]}'";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();

                XmlUtils.WriteXML("Advertisements", "Ad");
                Response.Redirect("manage-ads");
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