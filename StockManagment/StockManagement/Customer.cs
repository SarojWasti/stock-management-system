using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
namespace StockManagement
{
    public class CustomerDetails
    {
        GlobalConnection gcon = new GlobalConnection();
        public void AddCustomer(string name, string address, string number, string email, string customer_type)
        {
            SqlCommand sqlCmd = new SqlCommand("INSERT INTO [customers](name, address, number, email, customer_type) VALUES (@name, @address, @number, @email, @customer_type)", gcon.cn);

            sqlCmd.Parameters.AddWithValue("@name", name);
            sqlCmd.Parameters.AddWithValue("@address", address);
            sqlCmd.Parameters.AddWithValue("@number", number);
            sqlCmd.Parameters.AddWithValue("@email", email);
            sqlCmd.Parameters.AddWithValue("@customer_type", customer_type);

            sqlCmd.ExecuteNonQuery();
            gcon.cn.Close();
        }

        public DataTable GetRecords()
        {
            GlobalConnection gc = new GlobalConnection();

            string query = "SELECT * FROM [customers]";

            SqlDataAdapter sda = new SqlDataAdapter(query, gc.cn);

            DataTable dtb = new DataTable();
            sda.Fill(dtb);

            return dtb;
        }
        public void UpdateUser(string name, string address, string number, string email)
        {
            SqlCommand sqlCmd = new SqlCommand("UPDATE [customers] SET name = @name, address = @address, number = @number, email = @email WHERE email = @email", gcon.cn);
            sqlCmd.Parameters.AddWithValue("@name", name);
            sqlCmd.Parameters.AddWithValue("@address", address);
            sqlCmd.Parameters.AddWithValue("@number", number);
            sqlCmd.Parameters.AddWithValue("@email", email);

            sqlCmd.ExecuteNonQuery();
            gcon.cn.Close();
        }

        public void DeleteUser(string @email)
        {
            SqlCommand sqlCmd = new SqlCommand("DELETE FROM [customers] WHERE email = @email", gcon.cn);
            sqlCmd.Parameters.AddWithValue("@email", email);

            sqlCmd.ExecuteNonQuery();
            gcon.cn.Close();
        }
    }
}