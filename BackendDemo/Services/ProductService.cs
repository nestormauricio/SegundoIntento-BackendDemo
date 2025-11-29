namespace BackendDemo.Services;

using BackendDemo.Domain;
using BackendDemo.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

public class ProductService
{
    private readonly IProductRepository _repo;
    private readonly RabbitMqService _rabbit;

    public ProductService(IProductRepository repo, RabbitMqService rabbit)
    {
        _repo = repo;
        _rabbit = rabbit;
    }

    public Task<List<Product>> GetAll() => _repo.GetAll();
    public Task<Product?> GetById(int id) => _repo.GetById(id);

    public async Task<Product> Create(Product p)
    {
        var created = await _repo.Create(p);
        _rabbit.Publish($"CREATED: {created.Id} - {created.Name}");
        return created;
    }

    public async Task<Product?> Update(Product p)
    {
        var updated = await _repo.Update(p);
        if (updated != null)
            _rabbit.Publish($"UPDATED: {updated.Id} - {updated.Name}");

        return updated;
    }

    public async Task<bool> Delete(int id)
    {
        var result = await _repo.Delete(id);
        if (result)
            _rabbit.Publish($"DELETED: {id}");

        return result;
    }
}





















// using BackendDemo.Domain;
// using BackendDemo.Repositories;
// using System.Collections.Generic;
// using System.Threading.Tasks;
// using BackendDemo.Services;

// namespace BackendDemo.Services
// {
//     public class ProductService
//     {
//         private readonly IProductRepository _repo;
//         private readonly RabbitMqService _rabbit;

//         public ProductService(IProductRepository repo, RabbitMqService rabbit)
//         {
//             _repo = repo;
//             _rabbit = rabbit;
//         }

//         public Task<List<Product>> GetAll() => _repo.GetAll();

//         public Task<Product?> GetById(int id) => _repo.GetById(id);

//         public async Task<Product> Create(Product p)
//         {
//             var created = await _repo.Create(p);
//             // _rabbit.Publish($"Producto creado: {created.Id} - {created.Nombre}");
//                         _rabbit.Publish($"Producto creado: {created.Id} - {created.Name}");
//             return created;
//         }

//         public async Task<Product?> Update(Product p)
//         {
//             var updated = await _repo.Update(p);

//             if (updated != null)
//                 _rabbit.Publish($"Producto actualizado: {updated.Id}");

//             return updated;
//         }

//         public async Task<bool> Delete(int id)
//         {
//             var deleted = await _repo.Delete(id);

//             if (deleted)
//                 _rabbit.Publish($"Producto eliminado: {id}");

//             return deleted;
//         }
//     }
// }




















// namespace BackendDemo.Services;

// using BackendDemo.Domain;
// using BackendDemo.Repositories;
// using System.Collections.Generic;
// using System.Threading.Tasks;

// public class ProductService
// {
//     private readonly IProductRepository _repo;

//     // public ProductService(IProductRepository repo)
//     // {
//     //     _repo = repo;
//     // }
//     private readonly IProductRepository _repo;
// private readonly RabbitMqService _rabbit;
//     public ProductService(IProductRepository repo, RabbitMqService rabbit)
// {
//     _repo = repo;
//     _rabbit = rabbit;
// }

//     public Task<List<Product>> GetAll() => _repo.GetAll();
//     public Task<Product?> GetById(int id) => _repo.GetById(id);
//     public Task<Product> Create(Product p) => _repo.Create(p);
//     public Task<Product?> Update(Product p) => _repo.Update(p);
//     public Task<bool> Delete(int id) => _repo.Delete(id);
// }





















// using System.Collections.Generic;
// using System.Threading.Tasks;

// public class ProductService
// {
//     private readonly IProductRepository _repo;

//     public ProductService(IProductRepository repo)
//     {
//         _repo = repo;
//     }

//     public Task<List<Product>> GetAll() => _repo.GetAll();
//     public Task<Product> GetById(int id) => _repo.GetById(id);
//     public Task<Product> Create(Product p) => _repo.Create(p);
//     public Task<Product> Update(Product p) => _repo.Update(p);
//     public Task<bool> Delete(int id) => _repo.Delete(id);
// }