using BackendDemo.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackendDemo.Repositories;

public class CompositeProductRepository : IProductRepository
{
    private readonly SqliteProductRepository _sqlite = new();
    private readonly MongoProductRepository _mongo = new();

    public async Task<List<Product>> GetAll()
    {
        var list = await _sqlite.GetAll();
        return list.Count > 0 ? list : await _mongo.GetAll();
    }

    public async Task<Product?> GetById(int id)
    {
        var product = await _sqlite.GetById(id);
        if (product != null) return product;
        return await _mongo.GetById(id);
    }

    public async Task<Product> Create(Product product)
    {
        var created = await _sqlite.Create(product);
        await _mongo.Create(product);
        return created;
    }

    public async Task<Product?> Update(Product product)
    {
        var updated = await _sqlite.Update(product);
        await _mongo.Update(product);
        return updated;
    }

    public async Task<bool> Delete(int id)
    {
        var deletedSqlite = await _sqlite.Delete(id);
        var deletedMongo = await _mongo.Delete(id);
        return deletedSqlite || deletedMongo;
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