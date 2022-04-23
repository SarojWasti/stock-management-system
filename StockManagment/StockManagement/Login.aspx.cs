using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace StockManagement
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            try
            {
                User user = new User();
                DataTable result = user.Verify(Email.Text, Password.Text, IsAdmin.Checked);

                if (result.Rows.Count > 0)
                {
                    Session["userId"] = result.Rows[0]["user_id"].ToString();

                    Session["user"] = result.Rows[0]["name"].ToString();

                    Session["role"] = Convert.ToBoolean(result.Rows[0]["is_admin"].ToString()) ? "Admin" : "Staff";

                    ErrorMessage.Text = "";
                    Response.Redirect("Dashboard.aspx");
                }
                else {
                    ErrorMessage.Text = "Wrong email or password";
                }
            }
            catch (Exception ex) {
                ErrorMessage.Text = ex.Message;
            }
        }
    }
}