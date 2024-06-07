using DECXML_Maximillian_Leonard.Utils;
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

namespace DECXML_Maximillian_Leonard.Views.Admin
{
    public partial class AddAds : System.Web.UI.Page
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

        protected void addAds_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            try
            {
                string uniqueFileName = Guid.NewGuid().ToString();
                check_input();
                con.Open();
                string query = "INSERT INTO Advertisements (ImageUrl, NavigateUrl, AlternateText, Keyword, Impressions) VALUES(@ImageUrl, @NavigateUrl, @AlternateText, @Keyword, @Impressions)";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@ImageUrl", $"../Image/Ads/{uniqueFileName}.jpg");
                cmd.Parameters.AddWithValue("@NavigateUrl", nav_url.Text);
                cmd.Parameters.AddWithValue("@AlternateText", alt_text.Text);
                cmd.Parameters.AddWithValue("@Keyword", keyword.Text);
                cmd.Parameters.AddWithValue("@Impressions", impressions.Text);


                cmd.ExecuteNonQuery();

                XmlUtils.WriteXML("Advertisements", "Ad");

                con.Close();

                ads_img.SaveAs(Server.MapPath($"Image/Ads/{uniqueFileName}.jpg"));

                Response.Redirect("manage-ads");

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
            if (String.IsNullOrEmpty(nav_url.Text)
                || String.IsNullOrEmpty(alt_text.Text)
                || String.IsNullOrEmpty(keyword.Text)
                || String.IsNullOrEmpty(impressions.Text)
                || !ads_img.HasFile)
            {
                throw new Exception("Please enter all field.");
            }
        }
    }
}