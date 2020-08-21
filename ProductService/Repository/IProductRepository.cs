using ProductService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService.Repository
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetProducts();
        Product GetProductById (Guid ProductId);
        void InsertProduct (Product Product);
        void DeleteProduct (Guid ProductId);
        void UpdateProduct(Product Product);
        void Save();
    }
}
