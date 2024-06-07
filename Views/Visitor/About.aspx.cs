using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DECXML_Maximillian_Leonard.Views.Visitor
{
    public partial class About : System.Web.UI.Page
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

        }
    }
}