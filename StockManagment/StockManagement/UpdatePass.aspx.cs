using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;

namespace StockManagement
{
    public partial class UpdatePass : System.Web.UI.Page
    {
        UpdatePassword upd = new UpdatePassword();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void ChangePassword_Click(object sender, EventArgs e)
        {
            
            string oldPass = OldPass.Text;
            DataTable tbl = upd.VerifyOldPassword(Session["userID"].ToString());
            if(oldPass != tbl.Rows[0]["password"].ToString())
            {
                ErrorPanel.Visible = true;
                ErrorAlert.Text = "Old Password Doesn't Match.";
            }
            else
            {
                upd.UpdateUserPassword(NewPass.Text, Session["userID"].ToString());
                SuccessPanel.Visible = true;
                SuccessAlert.Text = "Password changed successfully.";

                OldPass.Text = "";
                NewPass.Text = "";
            }
        }
    }
}