using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.SqlClient;
namespace StockManagement
{
    public class ItemCategory
    {
        GlobalConnection gcon = new GlobalConnection();

        public void AddCategory(string categoryName)
        {
            SqlCommand sqlCmd = new SqlCommand("INSERT INTO [category](category_name) VALUES (@categoryName)", gcon.cn);

            sqlCmd.Parameters.AddWithValue("@categoryName", categoryName);

            sqlCmd.ExecuteNonQuery();
            gcon.cn.Close();
        }
        public DataTable GetRecords()
        {
            GlobalConnection gc = new GlobalConnection();

            string query = "SELECT * FROM [category]";

            SqlDataAdapter sda = new SqlDataAdapter(query, gc.cn);

            DataTable dtb = new DataTable();
            sda.Fill(dtb);

            return dtb;
        }
        public void UpdateCategory(string categoryId, string categoryName)
        {
            SqlCommand sqlCmd = new SqlCommand("UPDATE [category] SET category_name = @categoryName WHERE category_id = @categoryId", gcon.cn);
            sqlCmd.Parameters.AddWithValue("@categoryName", categoryName);
            sqlCmd.Parameters.AddWithValue("@categoryId", categoryId);

            sqlCmd.ExecuteNonQuery();
            gcon.cn.Close();
        }
        public void DeleteCategory(string categoryId)
        {
            SqlCommand sqlCmd = new SqlCommand("DELETE FROM [category] WHERE category_id = @categoryId", gcon.cn);
            sqlCmd.Parameters.AddWithValue("@categoryId", categoryId);

            sqlCmd.ExecuteNonQuery();
            gcon.cn.Close();
        }
    }
}