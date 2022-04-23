using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.SqlClient;

namespace StockManagement
{
    public class Transaction
    {
        GlobalConnection gcon = new GlobalConnection();
        public int CreateNewTransaction(string itemId, string customerId, int quantity, int totalAmount, string transactionDate) {
            SqlCommand sqlCmd = new SqlCommand("INSERT INTO [transaction](item_id, customer_id, quantity, total_amount, transaction_date) output INSERTED.transaction_id VALUES (@item_id, @customer_id, @quantity, @total_amount, @transaction_date)", gcon.cn);

            sqlCmd.Parameters.AddWithValue("@item_id", itemId);
            sqlCmd.Parameters.AddWithValue("@customer_id", customerId);
            sqlCmd.Parameters.AddWithValue("@quantity", quantity);
            sqlCmd.Parameters.AddWithValue("@total_amount", totalAmount);
            sqlCmd.Parameters.AddWithValue("@transaction_date", transactionDate);

            int modified = (int)sqlCmd.ExecuteScalar();

            gcon.cn.Close();

            return modified;
        }

        public DataTable GetBillingDetails(int transactionId) {
            GlobalConnection gc = new GlobalConnection();

            string query = "SELECT [item].name AS item_name, category_name, total_amount, [transaction].quantity, transaction_date FROM [transaction] JOIN [item] ON [transaction].item_id = item.item_id JOIN [category] ON item.category_id = category.category_id WHERE transaction_id = '" + transactionId + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, gc.cn);;

            DataSet dst = new DataSet();
            sda.Fill(dst, "billing");

            return dst.Tables[0];
        }

        public DataTable GetLatestTransactionsOfCustomer(string customerId) {
            GlobalConnection gc = new GlobalConnection();

            string query = "SELECT [item].name AS item_name, category_name, price, total_amount, [transaction].quantity, transaction_date FROM [transaction] JOIN [item] ON [transaction].item_id = item.item_id JOIN [category] ON item.category_id = category.category_id WHERE customer_id = '" + customerId + "' AND DATEDIFF(day, transaction_date, GETDATE()) <= 31";
            SqlDataAdapter sda = new SqlDataAdapter(query, gc.cn); ;

            DataSet dst = new DataSet();
            sda.Fill(dst, "transactions");

            return dst.Tables[0];
        }
    }
}