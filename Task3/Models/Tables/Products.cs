using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using Task2.Models.Entities;

namespace Task2.Models.Tables
{
    public class Products
    {
        SqlConnection conn;

        public object Session { get; private set; }

        public Products(SqlConnection conn)
        {
            this.conn = conn;
        }

        public void Create(Product p)
        {

            conn.Open();
            string query = String.Format("insert into Products values ('{0}',{1},{2},'{3}')", p.Name, p.Qty, p.Price, p.Desc);
            SqlCommand cmd = new SqlCommand(query, conn);
            int r = cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void CheckOut(List<Product>Products)
        {

            conn.Open();
            string orders = "";
            int cnt = 0;
            foreach (var p in Products) {
                orders += p.Id;
                if (cnt != Products.Count - 1)
                {
                    orders += ",";
                }
                cnt++;
            }
  
            string query = String.Format("insert into Orders values ('{0}')", orders);
            SqlCommand cmd = new SqlCommand(query, conn);
            int r = cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void Edit(Product p, int id)
        {
            conn.Open();
            string query = String.Format("Update Products set  Price=" + @p.Price + ", Name='" + p.Name + "' where Id= {0} ", id);
            SqlCommand cmd = new SqlCommand(query, conn);
            int r = cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void Delete(int id)
        {
            conn.Open();
            string query = String.Format("Delete from Products where Id={0}", id);
            SqlCommand cmd = new SqlCommand(query, conn);
            int r = cmd.ExecuteNonQuery();
            conn.Close();
        }

        public Product Get(int id)
        {
            conn.Open();
            string query = String.Format("Select * from Products where Id={0}", id);
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            Product p = null;
            while (reader.Read())
            {
                p = new Product()
                {
                    Id = reader.GetInt32(reader.GetOrdinal("Id")),
                    Name = reader.GetString(reader.GetOrdinal("Name")),
                    Qty = reader.GetInt32(reader.GetOrdinal("Qty")),
                    Price = (float)reader.GetDouble(reader.GetOrdinal("Price")),
                    Desc = reader.GetString(reader.GetOrdinal("Desc"))
                };
            }
            conn.Close();
            return p;
        }
        public List<Product> Get()
        {
            conn.Open();
            string query = "select * from Products";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            List<Product> products = new List<Product>();
            while (reader.Read())
            {
                Product p = new Product()
                {

                    Id = reader.GetInt32(reader.GetOrdinal("Id")),
                    Name = reader.GetString(reader.GetOrdinal("Name")),
                    Qty = reader.GetInt32(reader.GetOrdinal("Qty")),
                    Price= (float)reader.GetDouble(reader.GetOrdinal("Price")),
                    Desc = reader.GetString(reader.GetOrdinal("Desc"))

                };
                products.Add(p);
            }

            conn.Close();
            return products;
        }


    }
}