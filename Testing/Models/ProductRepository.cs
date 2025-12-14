using System.Collections;
using System.Data;
using System.Collections.Generic;
using Dapper;

namespace Testing.Models
{
    public class ProductRepository : IProductRepository
    {
        private readonly IDbConnection _connection;
        public ProductRepository(IDbConnection connection)
        {
            _connection = connection;
        }
       public IEnumerable<Products> GetAllProducts()
        {
            return _connection.Query<Products>("SELECT * FROM Products");
        }

        public Products GetProduct(int id)
        {
           return _connection.QuerySingle<Products>("SELECT * FROM PRODUCTS WHERE PRODUCTID = @id",
               new {id = id});
        }
    }
}
