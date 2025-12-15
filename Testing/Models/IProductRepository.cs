using System.Collections;
using System.Collections.Generic;

namespace Testing.Models
{
    public interface IProductRepository
    {
        public IEnumerable<Products> GetAllProducts();
        public Products GetProduct(int id);

        public void UpdateProduct(Products id);
    }
}
