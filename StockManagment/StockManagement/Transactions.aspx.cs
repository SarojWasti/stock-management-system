using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StockManagement
{
    public partial class Transactions : System.Web.UI.Page
    {
        CustomerDetails cust = new CustomerDetails();
        Transaction txn = new Transaction();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                CustomerDropdown.DataSource = cust.GetRecords();
                CustomerDropdown.DataBind();
                CustomerDropdown.DataTextField = "name";
                CustomerDropdown.DataValueField = "customer_id";
                CustomerDropdown.DataBind();

                FillTransactionsGridView(CustomerDropdown.SelectedValue);
            }
        }

        public void GridView_PreRender(object sender, EventArgs e)
        {
            Site1 MasterPage = (Site1)Page.Master;
            MasterPage.GridView_PreRender(sender, e);
        }

        public void FillTransactionsGridView(string customerId) {
            TransactionsTable.DataSource = txn.GetLatestTransactionsOfCustomer(customerId);
            TransactionsTable.DataBind();
        }

        protected void CustomerDropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillTransactionsGridView(CustomerDropdown.SelectedValue);
        }
    }
}