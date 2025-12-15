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
        //Get all products actions
       public IEnumerable<Products> GetAllProducts()
        {
            return _connection.Query<Products>("SELECT * FROM Products");
        }

        //Get product action
        public Products GetProduct(int id)
        {
           return _connection.QuerySingle<Products>("SELECT * FROM PRODUCTS WHERE PRODUCTID = @id",
               new {id = id});
        }

        //Update product action

        public void UpdateProduct(Products product)
        {
            _connection.Execute("UPDATE products SET Name = @name, Price = @price WHERE ProductID = @id",
                new { name = product.Name, price = product.Price, id = product.ProductID });
        }

         
    }
}
