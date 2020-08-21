using Microsoft.EntityFrameworkCore;
using OrderService.Model;

namespace OrderService.DBContexts
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options) : base(options)
        {
        }
        public DbSet<Order> Orders { get; set; }


    }
}