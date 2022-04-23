using System;
using System.Web;
using System.Linq;
using System.Collections.Generic;

using System.Data;
using System.Data.SqlClient;

namespace StockManagement
{
    public class Item
    {
        GlobalConnection gcon = new GlobalConnection();

        /**
         * Add new item entry in the database. 
         */
        public void AddItem(string name, string description, int price, string manufacturedDate, string expiryDate, string categoryId,
            int quantity, string stockedDate, string supplierId)
        {
            SqlCommand sqlCmd = new SqlCommand("INSERT INTO [item](name, description, price, manufactured_date, expiry_date, category_id, " +
                "quantity, stocked_date, supplier_id) VALUES (@name, @description, @price, @manufactured_date, @expiry_date, @category_id, @quantity," +
                " @stocked_date, @supplier_id)", gcon.cn);

            sqlCmd.Parameters.AddWithValue("@name", name);
            sqlCmd.Parameters.AddWithValue("@description", description);
            sqlCmd.Parameters.AddWithValue("@price", price);
            sqlCmd.Parameters.AddWithValue("@manufactured_date", manufacturedDate);
            sqlCmd.Parameters.AddWithValue("@expiry_date", expiryDate);
            sqlCmd.Parameters.AddWithValue("@category_id", categoryId);
            sqlCmd.Parameters.AddWithValue("@quantity", quantity);
            sqlCmd.Parameters.AddWithValue("@stocked_date", stockedDate);
            sqlCmd.Parameters.AddWithValue("@supplier_id", supplierId);

            sqlCmd.ExecuteNonQuery();
            gcon.cn.Close();
        }

        /**
         * Fetch records of all the items present in the database. 
         */
        public DataTable GetRecords(string filterType)
        {
            GlobalConnection gc = new GlobalConnection();

            string filterQuery = "";

            if (filterType == "Available on Stock")
            {
                filterQuery = "WHERE quantity > 0";
            }

            string query = "SELECT * FROM [item]" + filterQuery;

            SqlDataAdapter sda = new SqlDataAdapter(query, gc.cn);

            DataTable dtb = new DataTable();
            sda.Fill(dtb);

            return dtb;
        }

        /**
         * Get a single item record from it's item id.
         */
        public DataTable GetItem(string itemId)
        {
            string query = "SELECT * FROM [item] WHERE item_id='" + itemId + "'";

            SqlDataAdapter sda = new SqlDataAdapter(query, gcon.cn);

            DataTable dtb = new DataTable();
            sda.Fill(dtb);

            return dtb;
        }

        /**
         * Update details of a item.
         */
        public void UpdateItem(string itemId, string name, string description, int price, string categoryId,
            int quantity, string supplierId)
        {
            SqlCommand sqlCmd = new SqlCommand("UPDATE [item] SET name = @name, description = @description, price = @price," +
                "category_id = @category_id, quantity = @quantity, supplier_id = @supplier_id WHERE item_id = @item_id", gcon.cn);

            sqlCmd.Parameters.AddWithValue("@name", name);
            sqlCmd.Parameters.AddWithValue("@description", description);
            sqlCmd.Parameters.AddWithValue("@price", price);
            sqlCmd.Parameters.AddWithValue("@category_id", categoryId);
            sqlCmd.Parameters.AddWithValue("@quantity", quantity);
            sqlCmd.Parameters.AddWithValue("@supplier_id", supplierId);
            sqlCmd.Parameters.AddWithValue("@item_id", itemId);

            sqlCmd.ExecuteNonQuery();
            gcon.cn.Close();
        }

        /**
         * Delete entry for the item with the item id. 
         */
        public void DeleteItem(string itemId)
        {
            SqlCommand sqlCmd = new SqlCommand("DELETE FROM [item] WHERE item_id = @item_id", gcon.cn);
            sqlCmd.Parameters.AddWithValue("@item_id", itemId);

            sqlCmd.ExecuteNonQuery();
            gcon.cn.Close();
        }

        /*
         * Delete items which are out of stock from more than a month.
         */
        public void DeleteLongDueOutOfStockItems()
        {
            SqlCommand sqlCmd = new SqlCommand("DELETE FROM [item] WHERE quantity < 1 AND  DATEDIFF(day, stocked_date, GETDATE()) >= 31", gcon.cn);

            sqlCmd.ExecuteNonQuery();
            gcon.cn.Close();
        }

       /*
        * Fetch items which are out of stock from more than a month.
        */
        public DataTable GetLongDueOutOfStockItems()
        {
            string query = "SELECT name AS item_name FROM [item] WHERE quantity < 1 AND DATEDIFF(day, stocked_date, GETDATE()) >= 31";

            SqlDataAdapter sda = new SqlDataAdapter(query, gcon.cn);

            DataTable dtb = new DataTable();
            sda.Fill(dtb);

            return dtb;
        }

        public void ReduceItemQuantity(int quantity, string itemId)
        {
            SqlCommand sqlCmd = new SqlCommand("UPDATE [item] SET quantity = quantity - @quantity WHERE item_id = @item_id", gcon.cn);

            sqlCmd.Parameters.AddWithValue("@item_id", itemId);
            sqlCmd.Parameters.AddWithValue("@quantity", quantity);
            sqlCmd.ExecuteNonQuery();

            gcon.cn.Close();
        }

        public Boolean AreItemsRunningOutOfStock() {
            string query = "SELECT name AS item_name FROM [item] WHERE quantity <= 10";

            SqlDataAdapter sda = new SqlDataAdapter(query, gcon.cn);

            DataTable dtb = new DataTable();
            sda.Fill(dtb);

            return dtb.Rows.Count > 0;
        }
    }
}