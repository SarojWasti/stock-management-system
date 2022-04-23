using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StockManagement
{
    public partial class Category : System.Web.UI.Page
    {
        ItemCategory cat = new ItemCategory();
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

        protected void AddCategory_Click(object sender, EventArgs e)
        {
            try
            {
                cat.AddCategory(CategoryName.Text);
                SuccessPanel.Visible = true;
                CategoryName.Text = "";
                SuccessAlert.Text = "Category Added successfully!";
                FillGridView();

            }
            catch(Exception ex)
            {
                ErrorPanel.Visible = true;
                ErrorAlert.Text = ex.Message;
            }
        }
        protected void FillGridView()
        {
            CategoryTable.DataSource = cat.GetRecords();
            CategoryTable.DataBind();
        }
        protected void CategoryTable_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "select")
                {
                    int index = Convert.ToInt32(e.CommandArgument);
                    GridViewRow row = CategoryTable.Rows[index];

                    CategoryID.Text = row.Cells[0].Text;
                    CategoryName.Text = row.Cells[1].Text;
                }

                if (e.CommandName == "deletecategory")
                {
                    int index = Convert.ToInt32(e.CommandArgument);
                    GridViewRow row = CategoryTable.Rows[index];

                    cat.DeleteCategory(row.Cells[0].Text);
                    FillGridView();
                }
            }
            catch (Exception ex)
            {
                ErrorPanel.Visible = true;
                ErrorAlert.Text = ex.Message;
            }
        }
        

        protected void UpdateCategory_Click(object sender, EventArgs e)
        {
            try
            {
                string categoryId = CategoryID.Text;
                string categoryName = CategoryName.Text;
                cat.UpdateCategory(categoryId, categoryName);

                RefreshView();
                SuccessPanel.Visible = true;
                SuccessAlert.Text = "Category updated successfully!";
            }
            catch (Exception ex)
            {
                ErrorPanel.Visible = true;
                ErrorAlert.Text = ex.Message;
            }
        }
        protected void RefreshView()
        {
            CategoryName.Text = "";

            FillGridView();
        }
    }
}