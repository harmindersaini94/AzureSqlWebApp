using AzureSqlWebApp.Models;
using Microsoft.AspNetCore.Connections.Features;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;

namespace AzureSqlWebApp.Pages
{
    public class ProductController
    {
        public static string db_source = "azureappserver.database.windows.net";
        public static string db_user = "systemadmin";
        public static string db_password = "Rootadmin@94";
        public static string db_database = "azureAppDB";

        private SqlConnection GetConnection()
        {
            var _builder = new SqlConnectionStringBuilder();
            _builder.DataSource = db_source;
            _builder.UserID = db_user;
            _builder.Password = db_password;
            _builder.InitialCatalog = db_database;

            return new SqlConnection(_builder.ConnectionString);

        }

        public List<Product> GetProducts()
        {
            SqlConnection conn = GetConnection();
            List<Product> products_list = new List<Product>();
            string stmt = "Select * from Products";
            conn.Open();

            SqlCommand cmd = new SqlCommand(stmt, conn);
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while(reader.Read())
                {
                    Product prod = new Product();
                    prod.ProductID = reader.GetInt32(0);    
                    prod.ProductName = reader.GetString(1);    
                    prod.Quantity = reader.GetInt32(2);

                    products_list.Add(prod);
                }
            }
            conn.Close();
            return products_list;
        }

    }
}
