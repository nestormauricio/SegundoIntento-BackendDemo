using BackendDemo.Domain;
using Microsoft.EntityFrameworkCore;

namespace BackendDemo.Infrastructure.SQLite;

public class ProductDbContext : DbContext
{
    public ProductDbContext(DbContextOptions<ProductDbContext> options)
        : base(options)
    {
    }

    public DbSet<Product> Products => Set<Product>();
}