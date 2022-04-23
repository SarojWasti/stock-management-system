using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StockManagement
{
    public partial class Customer : System.Web.UI.Page
    {
        CustomerDetails cus = new CustomerDetails();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillGridView();
            }
        }

        public void GridView_PreRender(object sender, EventArgs e)
        {
            Site1 MasterPage = (Site1)Page.Master;
            MasterPage.GridView_PreRender(sender, e);
        }

        protected void AddCustomer_Click(object sender, EventArgs e)
        {
            try { 
                cus.AddCustomer(CusName.Text, Address.Text, NumberBox.Text, Email.Text, CategoryDropDown.SelectedItem.Value);

                RefreshView();
                SuccessPanel.Visible = true;
                SuccessAlert.Text = "Customer Added successfully!";
            
            }
            catch(Exception ex)
            {
                ErrorPanel.Visible = true;
                ErrorAlert.Text = ex.Message;
            }
        }
        protected void FillGridView()
        {
            CustomerTable.DataSource = cus.GetRecords();
            CustomerTable.DataBind();
        }
        protected void CustomerTable_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "select")
                {
                    int index = Convert.ToInt32(e.CommandArgument);
                    GridViewRow row = CustomerTable.Rows[index];

                    CusName.Text = row.Cells[0].Text;
                    Address.Text = row.Cells[1].Text;
                    NumberBox.Text = row.Cells[2].Text;
                    Email.Text = row.Cells[3].Text;
                }

                if (e.CommandName == "deletecustomer")
                {
                    int index = Convert.ToInt32(e.CommandArgument);
                    GridViewRow row = CustomerTable.Rows[index];

                    cus.DeleteUser(row.Cells[3].Text);
                    FillGridView();
                }
            }
            catch (Exception ex)
            {
                ErrorPanel.Visible = true;
                ErrorAlert.Text = ex.Message;
            }
        }

        protected void RefreshView()
        {
            CusName.Text = "";
            Address.Text = "";
            NumberBox.Text = "";
            Email.Text = "";
            FillGridView();
        }

        protected void UpdateCustomer_Click(object sender, EventArgs e)
        {
            try
            {
                string name = CusName.Text;
                string address = Address.Text;
                string number = NumberBox.Text;
                string email = Email.Text;

                cus.UpdateUser(name, address, number, email);

                RefreshView();
                SuccessPanel.Visible = true;
                SuccessAlert.Text = "Customer updated successfully!";
            }
            catch (Exception ex)
            {
                ErrorPanel.Visible = true;
                ErrorAlert.Text = ex.Message;
            }
        }
    }
}