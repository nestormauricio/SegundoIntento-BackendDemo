using BackendDemo.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackendDemo.Repositories;

public class CompositeProductRepository : IProductRepository
{
    private readonly IProductRepository _memoryRepo;
    private readonly IProductRepository _sqliteRepo;
    private readonly IProductRepository _mongoRepo;

    public CompositeProductRepository(
        IProductRepository memoryRepo,
        SqliteProductRepository sqliteRepo,
        MongoProductRepository mongoRepo)
    {
        _memoryRepo = memoryRepo;
        _sqliteRepo = sqliteRepo;
        _mongoRepo = mongoRepo;
    }

    public async Task<List<Product>> GetAll()
    {
        // Leemos de memoria como referencia principal
        return await _memoryRepo.GetAll();
    }

    public async Task<Product?> GetById(int id)
    {
        return await _memoryRepo.GetById(id);
    }

    public async Task<Product> Create(Product product)
    {
        // Crear en los tres repositorios
        var mem = await _memoryRepo.Create(product);
        var sql = await _sqliteRepo.Create(product);
        var mongo = await _mongoRepo.Create(product);

        return mem; // devolver el de memoria por consistencia
    }

    public async Task<Product?> Update(Product product)
    {
        var mem = await _memoryRepo.Update(product);
        var sql = await _sqliteRepo.Update(product);
        var mongo = await _mongoRepo.Update(product);

        return mem;
    }

    public async Task<bool> Delete(int id)
    {
        var mem = await _memoryRepo.Delete(id);
        var sql = await _sqliteRepo.Delete(id);
        var mongo = await _mongoRepo.Delete(id);

        return mem;
    }
}























// using BackendDemo.Domain;
// using System.Collections.Generic;
// using System.Threading.Tasks;

// namespace BackendDemo.Repositories;

// public class CompositeProductRepository : IProductRepository
// {
//     private readonly IProductRepository _memoryRepo;
//     private readonly IProductRepository _mongoRepo;
//     private readonly IProductRepository _sqliteRepo;

//     public CompositeProductRepository(
//         IProductRepository memoryRepo,
//         IProductRepository mongoRepo,
//         IProductRepository sqliteRepo)
//     {
//         _memoryRepo = memoryRepo;
//         _mongoRepo = mongoRepo;
//         _sqliteRepo = sqliteRepo;
//     }

//     public async Task<List<Product>> GetAll()
//     {
//         // Para GetAll devolvemos los productos del repo en memoria
//         return await _memoryRepo.GetAll();
//     }

//     public async Task<Product?> GetById(int id)
//     {
//         return await _memoryRepo.GetById(id);
//     }

//     public async Task<Product> Create(Product product)
//     {
//         var p1 = await _memoryRepo.Create(product);
//         var p2 = await _mongoRepo.Create(product);
//         var p3 = await _sqliteRepo.Create(product);
//         return p1; // devolver el de memoria
//     }

//     public async Task<Product?> Update(Product product)
//     {
//         var u1 = await _memoryRepo.Update(product);
//         var u2 = await _mongoRepo.Update(product);
//         var u3 = await _sqliteRepo.Update(product);
//         return u1;
//     }

//     public async Task<bool> Delete(int id)
//     {
//         var d1 = await _memoryRepo.Delete(id);
//         var d2 = await _mongoRepo.Delete(id);
//         var d3 = await _sqliteRepo.Delete(id);
//         return d1;
//     }
// }






















// using BackendDemo.Domain;
// using System.Collections.Generic;
// using System.Threading.Tasks;

// namespace BackendDemo.Repositories;

// public class CompositeProductRepository : IProductRepository
// {
//     private readonly IProductRepository _memoryRepo;
//     private readonly IProductRepository _mongoRepo;
//     private readonly IProductRepository _sqliteRepo;

//     public CompositeProductRepository(
//         IProductRepository memoryRepo,
//         IProductRepository mongoRepo,
//         IProductRepository sqliteRepo)
//     {
//         _memoryRepo = memoryRepo;
//         _mongoRepo = mongoRepo;
//         _sqliteRepo = sqliteRepo;
//     }

//     public async Task<List<Product>> GetAll()
//     {
//         // Para GetAll devolvemos los productos del repo en memoria
//         return await _memoryRepo.GetAll();
//     }

//     public async Task<Product?> GetById(int id)
//     {
//         return await _memoryRepo.GetById(id);
//     }

//     public async Task<Product> Create(Product product)
//     {
//         var p1 = await _memoryRepo.Create(product);
//         var p2 = await _mongoRepo.Create(product);
//         var p3 = await _sqliteRepo.Create(product);
//         return p1; // devolver el de memoria
//     }

//     public async Task<Product?> Update(Product product)
//     {
//         var u1 = await _memoryRepo.Update(product);
//         var u2 = await _mongoRepo.Update(product);
//         var u3 = await _sqliteRepo.Update(product);
//         return u1;
//     }

//     public async Task<bool> Delete(int id)
//     {
//         var d1 = await _memoryRepo.Delete(id);
//         var d2 = await _mongoRepo.Delete(id);
//         var d3 = await _sqliteRepo.Delete(id);
//         return d1;
//     }
// }