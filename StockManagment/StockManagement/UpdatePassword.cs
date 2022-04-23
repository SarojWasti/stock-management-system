using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.SqlClient;
namespace StockManagement
{
    public class UpdatePassword
    {
        GlobalConnection gcon = new GlobalConnection();
        public DataTable VerifyOldPassword(string userId)
        {
            GlobalConnection gc = new GlobalConnection();

            string query = "SELECT password FROM [user] WHERE user_id='" + userId +"'";

            SqlDataAdapter sda = new SqlDataAdapter(query, gc.cn);

            DataTable dtb = new DataTable();
            sda.Fill(dtb);
            return dtb;
        }

        public void UpdateUserPassword(string password, string userID)
        {
            SqlCommand sqlCmd = new SqlCommand("UPDATE [user] SET password = @password WHERE user_id = @user_id", gcon.cn);
            sqlCmd.Parameters.AddWithValue("@user_id", userID);
            sqlCmd.Parameters.AddWithValue("@password", password);

            sqlCmd.ExecuteNonQuery();
            gcon.cn.Close();
        }
    }
}