using System;
using System.Data;
using System.Web.UI.WebControls;

namespace StockManagement
{
    public partial class Items : System.Web.UI.Page
    {
        Item item = new Item();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ItemCategory cat = new ItemCategory();
                CategoryDropdown.DataSource = cat.GetRecords();
                CategoryDropdown.DataBind();
                CategoryDropdown.DataTextField = "category_name";
                CategoryDropdown.DataValueField = "category_id";
                CategoryDropdown.DataBind();

                ItemSupplier sup = new ItemSupplier();
                SupplierDropdown.DataSource = sup.GetRecords();
                SupplierDropdown.DataBind();
                SupplierDropdown.DataTextField = "name";
                SupplierDropdown.DataValueField = "supplier_id";
                SupplierDropdown.DataBind();

                FillGridView("All Items");

                FindLongDueOutOfStockItems();
            }
        }

        public void GridView_PreRender(object sender, EventArgs e)
        {
            Site1 MasterPage = (Site1)Page.Master;
            MasterPage.GridView_PreRender(sender, e);
        }

        protected void FillGridView(string filterType)
        {
            ItemsTable.DataSource = item.GetRecords(filterType);
            ItemsTable.DataBind();
        }

        protected void AddItem_Click(object sender, EventArgs e)
        {
            try
            {
                item.AddItem(ItemName.Text, Desc.Text, int.Parse(Price.Text), ManufDate.Text, ExpDate.Text, CategoryDropdown.SelectedValue, Convert.ToInt32(Quantity.Text), StockedDate.Text, SupplierDropdown.SelectedValue);

                RefreshView();
                SuccessPanel.Visible = true;
                SuccessAlert.Text = "Added new item successfully!";
            }
            catch (Exception ex)
            {
                ErrorPanel.Visible = true;
                ErrorAlert.Text = ex.Message;
            }
        }

        protected void ItemsTable_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "select")
                {
                    int index = Convert.ToInt32(e.CommandArgument);
                    GridViewRow row = ItemsTable.Rows[index];

                    ExpDate.Enabled = false;
                    ManufDate.Enabled = false;
                    StockedDate.Enabled = false;
                    StockedDateRequiredValidator.Enabled = false;

                    ItemId.Text = row.Cells[0].Text;
                    ItemName.Text = row.Cells[1].Text;
                    Desc.Text = row.Cells[2].Text;
                    Price.Text = row.Cells[3].Text;
                    CategoryDropdown.SelectedValue = row.Cells[6].Text;
                    System.Diagnostics.Debug.WriteLine(CategoryDropdown.Items);
                    Quantity.Text = row.Cells[7].Text;
                    SupplierDropdown.SelectedValue = row.Cells[9].Text;
                }

                if (e.CommandName == "deleteitem")
                {
                    SuccessPanel.Visible = false;
                    ErrorPanel.Visible = false;

                    int index = Convert.ToInt32(e.CommandArgument);
                    GridViewRow row = ItemsTable.Rows[index];

                    item.DeleteItem(row.Cells[0].Text);
                    FillGridView(ItemsFilterType.SelectedValue);
                }
            }
            catch (Exception ex)
            {
                ErrorPanel.Visible = true;
                ErrorAlert.Text = ex.Message;
            }
        }
        protected void UpdateItem_Click(object sender, EventArgs e)
        {
            try
            {
                item.UpdateItem(ItemId.Text, ItemName.Text, Desc.Text, Convert.ToInt32(Price.Text), CategoryDropdown.SelectedValue, Convert.ToInt32(Quantity.Text), SupplierDropdown.SelectedValue);

                RefreshView();
                SuccessPanel.Visible = true;
                SuccessAlert.Text = "Item details updated successfully!";
            }
            catch (Exception ex)
            {
                ErrorPanel.Visible = true;
                ErrorAlert.Text = ex.Message;
            }
        }

        protected void ItemsFilterType_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillGridView(ItemsFilterType.SelectedValue);
        }

        protected void FindLongDueOutOfStockItems() {
            DataTable longDueItems = item.GetLongDueOutOfStockItems();
            MultiDeletableItems.DataSource = longDueItems;
            MultiDeletableItems.DataBind();

        }

        protected void DeleteMultiple_OnClick(object sender, EventArgs e) {
            item.DeleteLongDueOutOfStockItems();
            RefreshView();
        }

        protected void RefreshView()
        {
            ResetFields();
            FillGridView("All Items");
        }

        protected void ResetFields()
        {
            ExpDate.Enabled = true;
            ManufDate.Enabled = true;
            StockedDate.Enabled = true;
            StockedDateRequiredValidator.Enabled = true;

            ItemName.Text = "";
            Desc.Text = "";
            ManufDate.Text = "";
            ExpDate.Text = "";
            Quantity.Text = "";
            Price.Text = "";
            StockedDate.Text = "";

            ItemsFilterType.SelectedIndex = 0;
        }
    }
}