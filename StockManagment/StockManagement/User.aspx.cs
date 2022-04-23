using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StockManagement
{
    public partial class User1 : System.Web.UI.Page
    {
        User usr = new User();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null || Session["role"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            if (Session["role"].ToString() == "Staff")
            {
                Response.Redirect("Dashboard.aspx");
            }
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

        /*
         * Handle add user button click by adding new entry of user in database 
         * using data filled in text fields by calling the add user service.
         */
        protected void AddUser_Click(object sender, EventArgs e)
        {
            try
            {
                ErrorPanel.Visible = false;
                SuccessPanel.Visible = false;

                // Check if user is already registered and if show an error message.
                if (usr.IsEmailRegistered(Email.Text))
                {
                    ResetFields();
                    ErrorPanel.Visible = true;
                    ErrorAlert.Text = "The provided email address is already registered in the system.";
                    return;
                }

                usr.AddUser(Name.Text, Phone.Text, Email.Text, Password.Text);

                RefreshView();
                SuccessPanel.Visible = true;
                SuccessAlert.Text = "User Added successfully!";
            }
            catch (Exception ex)
            {
                ErrorPanel.Visible = true;
                ErrorAlert.Text = ex.Message;
            }

        }

        /**
         * Fetch records of all the staffs in the system and bind the data into the gridview. 
         */
        protected void FillGridView()
        {
            UsersTable.DataSource = usr.GetStaffRecords();
            UsersTable.DataBind();
        }

        /*
         * Handler for rowcommand of gridview. Check the rowcommand type get the gridviewrow object 
         * using arguments and either delete or select item into textfield depending on the command name.
         */
        protected void UsersTable_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "select")
                {
                    int index = Convert.ToInt32(e.CommandArgument);
                    GridViewRow row = UsersTable.Rows[index];

                    UserId.Text = row.Cells[0].Text;
                    Name.Text = row.Cells[1].Text;
                    Phone.Text = row.Cells[2].Text;
                    Email.Text = row.Cells[3].Text;
                    Password.Text = row.Cells[4].Text;
                }

                if (e.CommandName == "deleteuser")
                {
                    int index = Convert.ToInt32(e.CommandArgument);
                    GridViewRow row = UsersTable.Rows[index];

                    usr.DeleteUser(row.Cells[0].Text);
                    FillGridView();
                }
            }
            catch (Exception ex)
            {
                ErrorPanel.Visible = true;
                ErrorAlert.Text = ex.Message;
            }
        }

        /**
         * Click Handler for update button. Gets new user details from fields and 
         * calls update method of user class with those arguments. 
         * 
         */
        protected void UpdateUser_Click(object sender, EventArgs e)
        {
            try
            {
                string id = UserId.Text;
                string name = Name.Text;
                string email = Email.Text;
                string phoneNo = Phone.Text;
                string password = Password.Text;

                usr.UpdateUser(id, name, email, phoneNo, password);

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

        /**
         * Reset text fields and refill the gridview 
         */
        protected void RefreshView()
        {
            ResetFields();
            FillGridView();
        }

        /*
         * Set empty text to all the text fields.
         */
        protected void ResetFields()
        {
            Phone.Text = "";
            Name.Text = "";
            Email.Text = "";
            Password.Text = "";
        }
    }
}