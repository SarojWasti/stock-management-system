using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
namespace StockManagement
{
    public class UserDashboard
    {
        public DataTable GetOutOfStockItems(string value)
        {
            string query = "SELECT item_id, [item].name, description, price, [supplier].name as supplier FROM [item] JOIN [supplier] on [item].supplier_id = [supplier].supplier_id WHERE quantity < '1'";

            GlobalConnection gc = new GlobalConnection();
            if(value == "Item Name")
            {
                query += " ORDER BY [item].name ASC";
            }
            else if(value == "Quantity")
            {
                query += "ORDER BY [item].quantity DESC";
            }
            else if(value == "Stocked Date")
            {
                query += "ORDER BY [item].stocked_date DESC";
            }
            
            SqlDataAdapter sda = new SqlDataAdapter(query, gc.cn);

            DataTable dtb = new DataTable();
            sda.Fill(dtb);

            return dtb;
        }
        public DataTable GetInactiveCustomers()
        {
            GlobalConnection gc = new GlobalConnection();
            string query = "SELECT [customers].name, [customers].address, [customers].number, [customers].email from [transaction] JOIN [customers] on [transaction].customer_id = [customers].customer_id WHERE [customers].customer_id NOT IN (SELECT customer_id from [transaction] WHERE DATEDIFF(day, [transaction].transaction_date, GETDATE()) <= 31)";

            SqlDataAdapter sda = new SqlDataAdapter(query, gc.cn);

            DataTable dtb = new DataTable();
            sda.Fill(dtb);

            return dtb;
        }
        public DataTable GetUnsoldItems()
        {
            GlobalConnection gc = new GlobalConnection();
            string query = "SELECT [item].name, [item].description, [item].price, [item].stocked_date from [transaction] JOIN [item] on [transaction].customer_id = [item].item_id WHERE [item].item_id NOT IN (SELECT item_id from [transaction] WHERE DATEDIFF(day, [transaction].transaction_date, GETDATE()) <= 31)";

            SqlDataAdapter sda = new SqlDataAdapter(query, gc.cn);

            DataTable dtb = new DataTable();
            sda.Fill(dtb);

            return dtb;
        }
    }
}