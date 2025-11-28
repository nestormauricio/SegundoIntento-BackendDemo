using BackendDemo.Domain;
using BackendDemo.Data; // Ajusta según tu proyecto
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackendDemo.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetAll()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> GetById(int id)
        {
            return await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Product> Create(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<Product> Update(Product product)
        {
            var existingProduct = await _context.Products.FirstOrDefaultAsync(p => p.Id == product.Id);
            if (existingProduct == null)
                return null;

            existingProduct.Name = product.Name;
            existingProduct.Price = product.Price;
            existingProduct.Description = product.Description;

            await _context.SaveChangesAsync();
            return existingProduct;
        }

        public async Task<bool> Delete(int id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
            if (product == null)
                return false;

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
















// namespace BackendDemo.Repositories; // Creo que es este el que mantiene en memoria lo que se haga

// using BackendDemo.Domain;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;

// public class ProductRepository : IProductRepository
// {
//     private readonly List<Product> _db = new();

//     public Task<List<Product>> GetAll() => Task.FromResult(_db);

//     public Task<Product> GetById(int id) =>
//         Task.FromResult(_db.FirstOrDefault(p => p.Id == id));

//     public Task<Product> Create(Product product)
//     {
//         product.Id = _db.Count + 1; // Simple auto-incremento
//         _db.Add(product);
//         return Task.FromResult(product);
//     }

//     public Task<Product> Update(Product product)
//     {
//         var existing = _db.FirstOrDefault(p => p.Id == product.Id);
//         if (existing == null) return Task.FromResult<Product>(null);

//         existing.Name = product.Name;
//         existing.Price = product.Price;
//         return Task.FromResult(existing);
//     }

//     public Task<bool> Delete(int id)
//     {
//         var p = _db.FirstOrDefault(x => x.Id == id);
//         if (p == null) return Task.FromResult(false);
//         _db.Remove(p);
//         return Task.FromResult(true);
//     }
// }





















// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;

// public class ProductRepository : IProductRepository
// {
//     private readonly List<Product> _db = new();

//     public Task<List<Product>> GetAll() => Task.FromResult(_db);

//     public Task<Product> GetById(int id) =>
//         Task.FromResult(_db.FirstOrDefault(p => p.Id == id));

//     public Task<Product> Create(Product product)
//     {
//         product.Id = _db.Count + 1;
//         _db.Add(product);
//         return Task.FromResult(product);
//     }

//     public Task<Product> Update(Product product)
//     {
//         var existing = _db.FirstOrDefault(p => p.Id == product.Id);
//         if (existing == null) return Task.FromResult<Product>(null);

//         existing.Name = product.Name;
//         existing.Price = product.Price;
//         return Task.FromResult(existing);
//     }

//     public Task<bool> Delete(int id)
//     {
//         var p = _db.FirstOrDefault(x => x.Id == id);
//         if (p == null) return Task.FromResult(false);
//         _db.Remove(p);
//         return Task.FromResult(true);
//     }
// }