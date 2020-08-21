using Microsoft.EntityFrameworkCore;
using ProductService.DBContexts;
using ProductService.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProductService.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductContext _dbContext;

        public ProductRepository(ProductContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void DeleteProduct(Guid ProductId)
        {
            var product = _dbContext.Products.Find(ProductId);
            _dbContext.Products.Remove(product);
            Save();
        }

        public Product GetProductById(Guid ProductId)
        {
            Product p = _dbContext.Products.Find(ProductId);
            return p;
        }

        public IEnumerable<Product> GetProducts()
        {
            return _dbContext.Products.ToList();
        }

        public void InsertProduct(Product product)
        {
            _dbContext.Add(product);
            Save();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void UpdateProduct(Product product)
        {
            _dbContext.Entry(product).State = EntityState.Modified;
            Save();
        }
    }
}