using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.SqlClient;
namespace StockManagement
{
    public class ItemSupplier
    {
        GlobalConnection gcon = new GlobalConnection();

        public void AddSupplier(string name, string address, string phone)
        {
            SqlCommand sqlCmd = new SqlCommand("INSERT INTO [supplier](name, address, phone) VALUES (@name, @address, @phone)", gcon.cn);

            sqlCmd.Parameters.AddWithValue("@name", name);
            sqlCmd.Parameters.AddWithValue("@address", address);
            sqlCmd.Parameters.AddWithValue("@phone", phone);

            sqlCmd.ExecuteNonQuery();
            gcon.cn.Close();
        }

        public DataTable GetRecords()
        {
            GlobalConnection gc = new GlobalConnection();

            string query = "SELECT * FROM [supplier]";

            SqlDataAdapter sda = new SqlDataAdapter(query, gc.cn);

            DataTable dtb = new DataTable();
            sda.Fill(dtb);

            return dtb;
        }
        public void UpdateSupplier(string supplierId, string name, string address, string phone)
        {
            SqlCommand sqlCmd = new SqlCommand("UPDATE [supplier] SET name = @name, address = @address, phone = @phone WHERE supplier_id = @supplier_id", gcon.cn);
            sqlCmd.Parameters.AddWithValue("@supplier_id", supplierId);
            sqlCmd.Parameters.AddWithValue("@name", name);
            sqlCmd.Parameters.AddWithValue("@address", address);
            sqlCmd.Parameters.AddWithValue("@phone", phone);

            sqlCmd.ExecuteNonQuery();
            gcon.cn.Close();
        }

        public void DeleteSupplier(string supplierId)
        {
            SqlCommand sqlCmd = new SqlCommand("DELETE FROM [supplier] WHERE supplier_id = @supplier_id", gcon.cn);
            sqlCmd.Parameters.AddWithValue("@supplier_id", supplierId);

            sqlCmd.ExecuteNonQuery();
            gcon.cn.Close();
        }
    }
}