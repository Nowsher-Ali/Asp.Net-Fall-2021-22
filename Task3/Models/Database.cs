using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Task2.Models.Tables;
using System.Data.SqlClient;

namespace Task2.Models
{
    public class Database
    {
        SqlConnection conn;
        public Products Products { get; set; }
        public Database()
        {
            string connString = @"Server=DESKTOP-V63RO42\SQLEXPRESS; Database=PMS; Integrated Security=true";
            conn = new SqlConnection(connString);
            Products = new Products(conn);

        }
    }
}