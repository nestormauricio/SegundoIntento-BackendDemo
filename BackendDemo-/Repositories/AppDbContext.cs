using BackendDemo.Domain;
using Microsoft.EntityFrameworkCore;

namespace BackendDemo.Repositories;

public class AppDbContext : DbContext
{
    public DbSet<Product> Products => Set<Product>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Archivo SQLite dentro de la carpeta del proyecto
        optionsBuilder.UseSqlite("Data Source=Products.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>().HasKey(p => p.Id);
        base.OnModelCreating(modelBuilder);
    }
}





















// using BackendDemo.Domain;
// using Microsoft.EntityFrameworkCore;

// namespace BackendDemo.Repositories;

// public class AppDbContext : DbContext
// {
//     public DbSet<Product> Products => Set<Product>();

//     protected override void OnConfiguring(DbContextOptionsBuilder options)
//         => options.UseSqlite("Data Source=products.db");
// }