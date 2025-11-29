using BackendDemo.Domain;
using BackendDemo.Infrastructure.SQLite;
using Microsoft.EntityFrameworkCore;

namespace BackendDemo.Repositories;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


public class ProductRepositorySqlite : IProductRepository
{
    private readonly ProductDbContext _context;

    public ProductRepositorySqlite(ProductDbContext context)
    {
        _context = context;
    }

    public async Task<List<Product>> GetAll() =>
        await _context.Products.ToListAsync();

    public async Task<Product?> GetById(int id) =>
        await _context.Products.FindAsync(id);

    public async Task<Product> Create(Product product)
    {
        _context.Products.Add(product);
        await _context.SaveChangesAsync();
        return product;
    }

    public async Task<Product?> Update(Product product)
    {
        var existing = await _context.Products.FindAsync(product.Id);
        if (existing == null)
            return null;

        existing.Name = product.Name;
        existing.Price = product.Price;
        await _context.SaveChangesAsync();

        return existing;
    }

    public async Task<bool> Delete(int id)
    {
        var existing = await _context.Products.FindAsync(id);
        if (existing == null)
            return false;

        _context.Products.Remove(existing);
        await _context.SaveChangesAsync();
        return true;
    }
}