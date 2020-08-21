using Microsoft.EntityFrameworkCore;
using ProductService.Model;

namespace OrderService.DBContexts
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options) : base(options)
        {
        }
        public DbSet<Product> Orders { get; set; }


    }
}