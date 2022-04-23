using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StockManagement
{
    public partial class Dashboard : System.Web.UI.Page
    {
        UserDashboard dsb = new UserDashboard();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {

                OutOfStock.DataSource = dsb.GetOutOfStockItems("Item Name");
                OutOfStock.DataBind();

                InactiveCustomers.DataSource = dsb.GetInactiveCustomers();
                InactiveCustomers.DataBind();

                UnsoldItems.DataSource = dsb.GetUnsoldItems();
                UnsoldItems.DataBind();

                Item item = new Item();
                if (item.AreItemsRunningOutOfStock())
                {
                    string message = "There are some items running out of stock. They need your immediate attention!!";
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    sb.Append("<script type = 'text/javascript'>");
                    sb.Append("window.onload=function(){");
                    sb.Append("alert('");
                    sb.Append(message);
                    sb.Append("')};");
                    sb.Append("</script>");

                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
                }
            } 
        }

        protected void GetItems()
        {
            OutOfStock.DataSource = dsb.GetOutOfStockItems(SortDropDown.SelectedValue);
            OutOfStock.DataBind();
        }

        protected void SortDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetItems();
        }
    }
}