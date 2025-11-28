using BackendDemo.Domain;

namespace BackendDemo.Repositories;

public class ProductRepository
{
    private readonly List<Product> _products = new();

    public Task<Product?> GetById(int id) => Task.FromResult(_products.FirstOrDefault(p => p.Id == id));
    public Task<IEnumerable<Product>> GetAll() => Task.FromResult(_products.AsEnumerable());
    public Task<Product> Add(Product product)
    {
        _products.Add(product);
        return Task.FromResult(product);
    }
    public Task<Product?> Update(Product product)
    {
        var index = _products.FindIndex(p => p.Id == product.Id);
        if (index == -1) return Task.FromResult<Product?>(null);
        _products[index] = product;
        return Task.FromResult(product);
    }
    public Task Delete(int id)
    {
        _products.RemoveAll(p => p.Id == id);
        return Task.CompletedTask;
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