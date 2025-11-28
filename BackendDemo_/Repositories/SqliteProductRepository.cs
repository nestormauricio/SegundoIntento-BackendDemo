using BackendDemo.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackendDemo.Repositories;

public class SqliteProductRepository : IProductRepository
{
    private readonly AppDbContext _context = new();

    public SqliteProductRepository()
    {
        _context.Database.EnsureCreated();
    }

    public async Task<List<Product>> GetAll() => await _context.Products.ToListAsync();

    public async Task<Product?> GetById(int id) => await _context.Products.FindAsync(id);

    public async Task<Product> Create(Product product)
    {
        _context.Products.Add(product);
        await _context.SaveChangesAsync();
        return product;
    }

    public async Task<Product?> Update(Product product)
    {
        _context.Products.Update(product);
        await _context.SaveChangesAsync();
        return product;
    }

    public async Task<bool> Delete(int id)
    {
        var existing = await _context.Products.FindAsync(id);
        if (existing == null) return false;
        _context.Products.Remove(existing);
        await _context.SaveChangesAsync();
        return true;
    }
}






















// using BackendDemo.Domain;
// using Microsoft.EntityFrameworkCore;
// using System.Collections.Generic;
// using System.Threading.Tasks;

// namespace BackendDemo.Repositories;

// public class SqliteProductRepository : IProductRepository
// {
//     private readonly AppDbContext _context = new();

//     public SqliteProductRepository()
//     {
//         _context.Database.EnsureCreated();
//     }

//     public async Task<List<Product>> GetAll() => await _context.Products.ToListAsync();

//     public async Task<Product?> GetById(int id) => await _context.Products.FindAsync(id);

//     public async Task<Product> Create(Product product)
//     {
//         _context.Products.Add(product);
//         await _context.SaveChangesAsync();
//         return product;
//     }

//     public async Task<Product?> Update(Product product)
//     {
//         // Obtener la entidad existente para evitar el error de "already tracked"
//         var existing = await _context.Products.FindAsync(product.Id);
//         if (existing == null) return null;

//         // Actualizar solo los campos necesarios
//         existing.Name = product.Name;
//         existing.Price = product.Price;
//         existing.Stock = product.Stock;

//         await _context.SaveChangesAsync();
//         return existing;
//     }

//     public async Task<bool> Delete(int id)
//     {
//         var existing = await _context.Products.FindAsync(id);
//         if (existing == null) return false;

//         _context.Products.Remove(existing);
//         await _context.SaveChangesAsync();
//         return true;
//     }
// }




















// using BackendDemo.Domain;
// using Microsoft.EntityFrameworkCore;
// using System.Collections.Generic;
// using System.Threading.Tasks;

// namespace BackendDemo.Repositories;

// public class SqliteProductRepository : IProductRepository
// {
//     private readonly AppDbContext _context = new();

//     public SqliteProductRepository()
//     {
//         _context.Database.EnsureCreated();
//     }

//     public async Task<List<Product>> GetAll() => await _context.Products.ToListAsync();

//     public async Task<Product?> GetById(int id) => await _context.Products.FindAsync(id);

//     public async Task<Product> Create(Product product)
//     {
//         _context.Products.Add(product);
//         await _context.SaveChangesAsync();
//         return product;
//     }

//     public async Task<Product?> Update(Product product)
//     {
//         _context.Products.Update(product);
//         await _context.SaveChangesAsync();
//         return product;
//     }

//     public async Task<bool> Delete(int id)
//     {
//         var existing = await _context.Products.FindAsync(id);
//         if (existing == null) return false;
//         _context.Products.Remove(existing);
//         await _context.SaveChangesAsync();
//         return true;
//     }
// }






















// using BackendDemo.Domain;
// using Microsoft.EntityFrameworkCore;
// using System.Collections.Generic;
// using System.Threading.Tasks;

// namespace BackendDemo.Repositories;

// public class SqliteProductRepository : IProductRepository
// {
//     private readonly AppDbContext _context = new();

//     public SqliteProductRepository()
//     {
//         _context.Database.EnsureCreated();
//     }

//     public async Task<List<Product>> GetAll() => await _context.Products.ToListAsync();

//     public async Task<Product?> GetById(int id) => await _context.Products.FindAsync(id);

//     public async Task<Product> Create(Product product)
//     {
//         _context.Products.Add(product);
//         await _context.SaveChangesAsync();
//         return product;
//     }

//     public async Task<Product?> Update(Product product)
//     {
//         _context.Products.Update(product);
//         await _context.SaveChangesAsync();
//         return product;
//     }

//     public async Task<bool> Delete(int id)
//     {
//         var existing = await _context.Products.FindAsync(id);
//         if (existing == null) return false;
//         _context.Products.Remove(existing);
//         await _context.SaveChangesAsync();
//         return true;
//     }
// }