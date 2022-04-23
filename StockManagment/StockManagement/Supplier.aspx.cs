using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StockManagement
{
    public partial class Supplier : System.Web.UI.Page
    {
        ItemSupplier sup = new ItemSupplier();
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

        protected void AddSupplier_Click(object sender, EventArgs e)
        {
            try
            {
                sup.AddSupplier(SupName.Text, Address.Text, Phone.Text);

                RefreshView();
                SuccessPanel.Visible = true;
                SuccessAlert.Text = "User Added successfully!";
            }
            catch (Exception ex) {
                ErrorPanel.Visible = true;
                ErrorAlert.Text = ex.Message;
             }
        }
        protected void FillGridView()
        {
            SupplierTable.DataSource = sup.GetRecords();
            SupplierTable.DataBind();
        }

        protected void SupplierTable_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "select")
                {
                    int index = Convert.ToInt32(e.CommandArgument);
                    GridViewRow row = SupplierTable.Rows[index];

                    SupplierID.Text = row.Cells[0].Text;
                    SupName.Text = row.Cells[1].Text;
                    Address.Text = row.Cells[2].Text;
                    Phone.Text = row.Cells[3].Text;
                }

                if (e.CommandName == "deletesupplier")
                {
                    int index = Convert.ToInt32(e.CommandArgument);
                    GridViewRow row = SupplierTable.Rows[index];

                    sup.DeleteSupplier(row.Cells[0].Text);
                    FillGridView();
                }
            }
            catch (Exception ex)
            {
                ErrorPanel.Visible = true;
                ErrorAlert.Text = ex.Message;
            }
        }
        protected void UpdateSupplier_Click(object sender, EventArgs e)
        {
            try
            {
                string supplierId = SupplierID.Text;
                string name = SupName.Text;
                string address = Address.Text;
                string phone = Phone.Text;

                sup.UpdateSupplier(supplierId, name, address, phone);

                RefreshView();
                SuccessPanel.Visible = true;
                SuccessAlert.Text = "User updated successfully!";
            }
            catch (Exception ex)
            {
                ErrorPanel.Visible = true;
                ErrorAlert.Text = ex.Message;
            }
        }

        protected void RefreshView()
        {
            SupName.Text = "";
            Address.Text = "";
            Phone.Text = "";

            FillGridView();
        }
    }
}