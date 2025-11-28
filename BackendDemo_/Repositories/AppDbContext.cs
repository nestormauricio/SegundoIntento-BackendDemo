using BackendDemo.Domain;
using Microsoft.EntityFrameworkCore;

namespace BackendDemo.Repositories;

public class AppDbContext : DbContext
{
    public DbSet<Product> Products => Set<Product>();

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite("Data Source=products.db");
}