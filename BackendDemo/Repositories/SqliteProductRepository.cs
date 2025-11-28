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