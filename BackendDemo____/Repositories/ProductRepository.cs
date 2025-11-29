namespace BackendDemo.Repositories;

using BackendDemo.Domain;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class ProductRepository : IProductRepository
{
    private readonly List<Product> _db = new();

    public Task<List<Product>> GetAll() => Task.FromResult(_db);

    public Task<Product?> GetById(int id) =>
        Task.FromResult(_db.FirstOrDefault(p => p.Id == id));

    public Task<Product> Create(Product product)
    {
        product.Id = _db.Count + 1; // Auto-incremento simple
        _db.Add(product);
        return Task.FromResult(product);
    }

    public Task<Product?> Update(Product product)
    {
        var existing = _db.FirstOrDefault(p => p.Id == product.Id);
        if (existing == null) return Task.FromResult<Product?>(null);

        existing.Name = product.Name;
        existing.Price = product.Price;
        // return Task.FromResult(existing);
        return Task.FromResult<Product?>(existing);
    }

    public Task<bool> Delete(int id)
    {
        var p = _db.FirstOrDefault(x => x.Id == id);
        if (p == null) return Task.FromResult(false);
        _db.Remove(p);
        return Task.FromResult(true);
    }
}























// namespace BackendDemo.Repositories;

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