using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DECXML_Maximillian_Leonard.MasterPage
{
    public partial class Admin : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!String.Equals(Session["user_type"], "admin"))
            {
                Response.Redirect("/");
            } else
            {
                string name = Session["user_first_name"].ToString();
                greetings.InnerText = "Hello, " + name + "!";
                admin_name.InnerText = name;
            }
        }

        protected void logout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Request.Cookies.Clear();
            Response.Cookies.Clear();
            Response.Redirect("/");
        }
    }
}