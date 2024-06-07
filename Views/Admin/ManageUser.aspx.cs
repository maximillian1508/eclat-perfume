using DECXML_Maximillian_Leonard.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DECXML_Maximillian_Leonard.Views.Admin
{
    public partial class ManageUser : System.Web.UI.Page
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
            string xmlString = XmlUtils.ReadXML("users");
            user_xml.DocumentContent = xmlString;
            user_xml.TransformSource = Server.MapPath("~/xslt/manage-user.xslt");
        }
    }
}