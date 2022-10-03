using System.Data.SqlClient;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class ProductService
    {
        private static string db_source = "yugidbserver.database.windows.net";
        private static string db_user = "senthil937";
        private static string db_password = "Arasan@937890";
        private static string db_database = "ProductDB";



        private SqlConnection GetConnection()
        {
            //var _builder = new SqlConnectionStringBuilder();
            
            //_builder.ConnectionString = "data source=localhost;initial catalog=productDB;persist security info=True;Integrated Security=SSPI;";
            //return new SqlConnection(_builder.ConnectionString);
            var _builder = new SqlConnectionStringBuilder();
            _builder.DataSource = db_source;
            _builder.UserID = db_user;
            _builder.Password = db_password;
            _builder.InitialCatalog = db_database;
            return new SqlConnection(_builder.ConnectionString);
        }
        public List<Product> GetProducts()
        {
            List<Product> _product_lst = new List<Product>();
            string _statement = "SELECT ProductID,ProductName,Quantity from Products";
            SqlConnection _connection = GetConnection();

            _connection.Open();

            SqlCommand _sqlcommand = new SqlCommand(_statement, _connection);

            using (SqlDataReader _reader = _sqlcommand.ExecuteReader())
            {
                while (_reader.Read())
                {
                    Product _product = new Product()
                    {
                        ProductID = _reader.GetInt32(0),
                        ProductName = _reader.GetString(1),
                        Quantity = _reader.GetInt32(2)
                    };



                    _product_lst.Add(_product);
                }
            }
            _connection.Close();
            return _product_lst;
        }



    }
}
