using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace StockManagement
{
    public class GlobalConnection
    {
        public SqlConnection cn;
        public GlobalConnection() 
        {
            string sqlCon = System.Configuration.ConfigurationManager
                .AppSettings.Get("MyConnection").ToString();
            cn = new SqlConnection(sqlCon);
            cn.Open();
        }
    }
}