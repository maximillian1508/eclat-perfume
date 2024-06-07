using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Text;
using System.IO;
using Microsoft.Ajax.Utilities;

namespace DECXML_Maximillian_Leonard.Views.Admin
{
    public partial class Dashboard : System.Web.UI.Page
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
            try
            {
                total_boxes();
                recent_orders();
                product_sales();
            }
            catch (Exception ex)
            {
                errMsg.Visible = true;
                errMsg.Text = ex.Message;
            }
        }

        protected void total_boxes()
        {
            try
            {
                SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                con1.Open();
                string query1 = "SELECT COUNT(*) AS total_product FROM products; SELECT COUNT(*) AS total_order FROM orders; SELECT COUNT(*) AS total_paid_order FROM orders WHERE status = 'paid'; SELECT COUNT(*) AS total_delivered_order FROM orders WHERE status = 'delivered'; SELECT COUNT (*) AS total_customer FROM users WHERE user_type='customer';";
                SqlCommand cmd1 = new SqlCommand(query1, con1);
                SqlDataReader dr1 = cmd1.ExecuteReader();

                if (dr1.Read())
                {
                    total_product.InnerText = dr1["total_product"].ToString();
                }

                dr1.NextResult();
                if (dr1.Read())
                {
                    total_order.InnerText = dr1["total_order"].ToString();
                }

                dr1.NextResult();
                if (dr1.Read())
                {
                    total_paid_order.InnerText = dr1["total_paid_order"].ToString();
                }

                dr1.NextResult();
                if (dr1.Read())
                {
                    total_delivered_order.InnerText = dr1["total_delivered_order"].ToString();
                }

                dr1.NextResult();
                if (dr1.Read())
                {
                    total_customer.InnerText = dr1["total_customer"].ToString();
                }
                con1.Close();
            }
            catch (Exception ex) { errMsg.Visible = true; errMsg.Text = ex.Message; }
        }

        protected void recent_orders()
        {
            try
            {
                SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                SqlCommand cmd1 = new SqlCommand("SELECT TOP 3 Id AS order_id, user_id AS customer_id, total_amount AS order_amount, status AS order_status FROM orders ORDER BY Id DESC;", con1);

                StringBuilder html = new StringBuilder();
                SqlDataAdapter sda = new SqlDataAdapter();
                sda.SelectCommand = cmd1;
                DataTable dt = new DataTable();
                sda.Fill(dt);
                con1.Close();

                foreach (DataRow row in dt.Rows)
                {
                    html.Append("<tr>");
                    html.Append($"<td>{row["order_id"]}</td>");
                    html.Append($"<td>Cust {row["customer_id"]}</td>");
                    html.Append($"<td>RM {row["order_amount"]}</td>");
                    if (String.Equals(row["order_status"], "fail"))
                    {
                        html.Append("<td><span style='padding: 5px;border-radius: 5px; background-color: #ffeaef; color: #ef144a'>Failed</span></td>");
                        html.Append("<td></td>");
                    }
                    else if (String.Equals(row["order_status"], "delivered"))
                    {
                        html.Append("<td><span style='padding: 5px; border-radius: 5px; background-color: #0fb01b; color:#d6ffde'>Delivered</span></td>");
                        html.Append("<td></td>");
                    }
                    else
                    {
                        html.Append("<td><span style='padding: 5px;border-radius: 5px; color:#fa6e3f; background-color: #fff0b3'>In Process</span></td>");
                        html.Append($"<td><a href='deliver-order?Id={row["order_id"]}' class='black-button' style='cursor: pointer;padding: 7.5px 5px; border-radius: 10px;'>Deliver</a></td>");
                    }
                    html.Append("</tr>");
                }
                order_Placeholder.Controls.Add(new Literal { Text = html.ToString() });
            }
            catch (Exception ex)
            {
                errMsg.Visible = true;
                errMsg.Text = ex.Message;
            }
        }

        protected void product_sales()
        {
            try
            {
                string rootDirectoryPath = AppDomain.CurrentDomain.BaseDirectory;
                string salesPath = Path.Combine(rootDirectoryPath, "xml", "sales.xml");

                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                con.Open();
                string strSQL = "SELECT products.name AS product_name, SUM(order_details.quantity) AS total_sales FROM products INNER JOIN order_details ON products.Id = order_details.product_id INNER JOIN orders ON order_details.order_id = orders.Id WHERE NOT orders.status = 'fail' GROUP BY products.name";
                SqlDataAdapter dt = new SqlDataAdapter(strSQL, con);
                DataSet ds = new DataSet("sales");
                dt.Fill(ds, "product");
                ds.WriteXml(salesPath);

                con.Close();
                //Part 2 - to visualize the xml data in chart control 
                DataSet xmlds = new DataSet();
                xmlds.ReadXml(salesPath);
                
                if (xmlds.Tables[0].Rows.Count == 0 || xmlds.Tables.Count == 0 || xmlds == null)
                {
                    Chart1.Visible = false;
                    throw new Exception("Sales Dataset has no value");
                } 
                else
                {
                    Chart1.Visible = true;
                    Chart1.Series["Series1"].XValueMember = "product_name";
                    Chart1.Series["Series1"].YValueMembers = "total_sales";
                    Chart1.DataSource = xmlds;
                    Chart1.DataBind();
                }
            }
            catch (Exception ex)
            {
                errMsg.Visible = true;
                errMsg.Text = ex.Message;
            }
        }
    }
}