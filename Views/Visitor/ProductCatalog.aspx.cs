using DECXML_Maximillian_Leonard.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DECXML_Maximillian_Leonard.Views.Visitor
{
    public partial class ProductCatalog : System.Web.UI.Page
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
            try
            {
                string genderQuery = "";
                if (Request.QueryString.HasKeys())
                {
                    genderQuery = Request.QueryString["gender"];
                    catalog_type.InnerText = XmlUtils.CapitalizeLetter(genderQuery);
                }

                string xmlString = XmlUtils.ReadXML("products");
                product_xml.DocumentContent = xmlString;

                if (String.Equals(genderQuery, "male"))
                {
                    product_xml.TransformSource = Server.MapPath("~/xslt/catalog-male.xslt");
                }
                else if (String.Equals(genderQuery, "female"))
                {
                    product_xml.TransformSource = Server.MapPath("~/xslt/catalog-female.xslt");
                }
                else if (String.Equals(genderQuery, "unisex"))
                {
                    product_xml.TransformSource = Server.MapPath("~/xslt/catalog-unisex.xslt");
                }
                else
                {
                    product_xml.TransformSource = Server.MapPath("~/xslt/product-catalog.xslt");
                }
            } catch (Exception ex)
            {
                errMsg.Visible = true;
                errMsg.Text = ex.Message;
            }
        }
    }
}