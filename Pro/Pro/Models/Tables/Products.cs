using Pro.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Pro.Models.Tables
{

    public class Products
    {
        
            SqlConnection conn;
            public Products(SqlConnection conn)
            {
                this.conn = conn;
            }
            public void Create(Product p)
            {

                conn.Open();
                string query = String.Format("insert into Products values ('{0}','{1}','{2}','{3}','{4}')", p.Name, p.Price, p.Quantity,p.Description);
                SqlCommand cmd = new SqlCommand(query, conn);
                int r = cmd.ExecuteNonQuery();
                conn.Close();
            }
            public List<Product> Get()
            {
                conn.Open();
                string query = "select * from Students";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                List<Product> students = new List<Product>();
                while (reader.Read())
                {
                    Product s = new Product()
                    {

                        Id = reader.GetInt32(reader.GetOrdinal("Id")),
                        Name = reader.GetString(reader.GetOrdinal("Name")),
                        Price = reader.GetString(reader.GetOrdinal("Price")),
                        Quantity = reader.GetString(reader.GetOrdinal("Quantity")),
                        Description = reader.GetString(reader.GetOrdinal("Description"))

                    };

                    Products.Add(s);
                }

                conn.Close();
                return students;
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
                        Price = reader.GetString(reader.GetOrdinal("Price")),
                        Quantity = reader.GetString(reader.GetOrdinal("Quantity")),
                        Description = reader.GetString(reader.GetOrdinal("Description"))
                    };
                }
                conn.Close();
                return p;
            }
    }



}
