using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace StockManagement
{
    public class User
    {
        GlobalConnection gcon = new GlobalConnection();

        /**
         * Query user table to find entry with provided email & password
         */
        public DataTable Verify(string email, string password, bool isAdmin) {
            GlobalConnection gc = new GlobalConnection();

            string query = "SELECT * FROM [user] WHERE email='" + email + "'" + " AND password ='" + password + "'" + " AND is_admin=" + "'" + isAdmin + "'";

            SqlDataAdapter sda = new SqlDataAdapter(query, gc.cn);

            DataSet dst = new DataSet();
            sda.Fill(dst, "user");

            return dst.Tables[0];
        }

        /**
         * Check if the the provided email is already registered in the system. 
         */
        public Boolean IsEmailRegistered(string email) {
            string query = "SELECT * FROM [user] WHERE email = '" + email + "'";

            SqlDataAdapter sda = new SqlDataAdapter(query, gcon.cn);

            DataSet dst = new DataSet();
            sda.Fill(dst, "user");

            if (dst.Tables[0].Rows.Count > 0) {
                return true;
            }

            return false;
        }

        /**
         * Add new user record in the database. 
         */
        public void AddUser(string name, string phone, string email, string password) {
            SqlCommand sqlCmd = new SqlCommand("INSERT INTO [user](name, phone_no, email, password, is_admin) VALUES (@name, @phoneNo, @email, @password, @isAdmin)", gcon.cn);

            sqlCmd.Parameters.AddWithValue("@name", name);
            sqlCmd.Parameters.AddWithValue("@phoneNo", phone);
            sqlCmd.Parameters.AddWithValue("@email", email);
            sqlCmd.Parameters.AddWithValue("@password", password);
            sqlCmd.Parameters.AddWithValue("@isAdmin", false);

            sqlCmd.ExecuteNonQuery();
            gcon.cn.Close();
        }

        /**
         * Fetch records of all the staffs present in the database. 
         */
        public DataTable GetStaffRecords() {
            GlobalConnection gc = new GlobalConnection();

            string query = "SELECT * FROM [user] WHERE is_admin = 'false'";

            SqlDataAdapter sda = new SqlDataAdapter(query, gc.cn);

            DataTable dtb = new DataTable();
            sda.Fill(dtb);

            return dtb;
        }

        /**
         * Update details of a user. 
         */
        public void UpdateUser(string id, string name, string email, string phone, string password) {
            SqlCommand sqlCmd = new SqlCommand("UPDATE [user] SET name = @name, email = @email, phone_no = @phoneNo, password = @password WHERE user_id = @id", gcon.cn);
            sqlCmd.Parameters.AddWithValue("@id", id);
            sqlCmd.Parameters.AddWithValue("@name", name);
            sqlCmd.Parameters.AddWithValue("@phoneNo", phone);
            sqlCmd.Parameters.AddWithValue("@email", email);
            sqlCmd.Parameters.AddWithValue("@password", password);

            sqlCmd.ExecuteNonQuery();
            gcon.cn.Close();
        }

        /**
         * Delete entry for the user matching the provided email address. 
         */
        public void DeleteUser(string id)
        {
            SqlCommand sqlCmd = new SqlCommand("DELETE FROM [user] WHERE user_id = @user_id", gcon.cn);
            sqlCmd.Parameters.AddWithValue("@user_id", id);
            
            sqlCmd.ExecuteNonQuery();
            gcon.cn.Close();
        }
    }
}