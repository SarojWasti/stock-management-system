using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StockManagement
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] != null & Session["role"] != null)
            {
                User.Text = Session["user"].ToString().Split(' ')[0];
                UserType.Text = Session["role"].ToString();
            }
            else {
                Response.Redirect("Login.aspx");
            }

            if (Session["role"].ToString() == "Staff") {
                UserNavigation.Visible = false;
                ChangePassPanel.Visible = true;
            }
        }

        public void GridView_PreRender(object sender, EventArgs e) {
            GridView gv = (GridView)sender;

            if ((gv.ShowHeader == true && gv.Rows.Count > 0)
                || (gv.ShowHeaderWhenEmpty == true))
            {
                //Force GridView to use <thead> instead of <tbody>
                gv.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            if (gv.ShowFooter == true && gv.Rows.Count > 0)
            {
                //Force GridView to use <tfoot> instead of <tbody>
                gv.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }

        protected void LogoutBtn_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Response.Redirect("Login.aspx");
        }
    }
}