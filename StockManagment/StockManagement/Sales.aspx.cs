using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;

namespace StockManagement
{
    public partial class Sales : System.Web.UI.Page
    {
        Item item = new Item();
        Transaction txn = new Transaction();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CustomerDetails cust = new CustomerDetails();

                CustomerNameDropDown.DataSource = cust.GetRecords();
                CustomerNameDropDown.DataBind();
                CustomerNameDropDown.DataTextField = "name";
                CustomerNameDropDown.DataValueField = "customer_id";
                CustomerNameDropDown.DataBind();
            }
        }

        protected void SellBtn_Click(object sender, EventArgs e)
        {
            try
            {
                int quantity = int.Parse(Quantity.Text);
                DataTable datatbl = item.GetItem(ItemID.Text);

                if (int.Parse(datatbl.Rows[0]["quantity"].ToString()) < quantity)
                {
                    ErrorPanel.Visible = true;
                    ErrorAlert.Text = "Available item quantity is not sufficient";
                    return;
                }

                string currentDateString = DateTime.UtcNow.ToString("yyyy-MM-dd");
                int txnId = txn.CreateNewTransaction(ItemID.Text, CustomerNameDropDown.SelectedValue, quantity, int.Parse(TotalAmount.Text.Split(' ')[1]), currentDateString);

                item.ReduceItemQuantity(quantity, ItemID.Text);

                ResetFields();

                FillBillingDetails(txnId);
            }
            catch (Exception ex)
            {
                ErrorPanel.Visible = true;
                ErrorAlert.Text = ex.Message;
            }
        }

        protected void Quantity_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (ItemID.Text != null)
                {
                    DataTable datatbl = item.GetItem(ItemID.Text);

                    int price = int.Parse(datatbl.Rows[0]["price"].ToString());

                    TotalAmount.Text = "Rs. " + (price * int.Parse(Quantity.Text)).ToString();
                }
            }
            catch (Exception ex)
            {
                ErrorPanel.Visible = true;
                ErrorAlert.Text = ex.Message;
            }
        }

        protected void FillBillingDetails(int transactionId)
        {
            DataTable dtb = txn.GetBillingDetails(transactionId);

            SalesForm.Visible = false;
            BillingDetails.Visible = true;

            ItemName.Text = dtb.Rows[0]["item_name"].ToString();
            Category.Text = dtb.Rows[0]["category_name"].ToString();
            Amount.Text = "Rs. " + dtb.Rows[0]["total_amount"].ToString();
            ItemQuantity.Text = dtb.Rows[0]["quantity"].ToString();
            TransactionDate.Text = dtb.Rows[0]["transaction_date"].ToString().Split(' ')[0];
        }

        /*
         * Set empty text to all the text fields.
         */
        protected void ResetFields()
        {
            ItemID.Text = "";
            CustomerNameDropDown.SelectedIndex = 0;
            Quantity.Text = "";
            TotalAmount.Text = "";
        }

        protected void GoBackBtn_Click(object sender, EventArgs e)
        {
            SalesForm.Visible = true;
            BillingDetails.Visible = false;
        }
    }
}