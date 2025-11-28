using BackendDemo.Domain;

namespace BackendDemo.Repositories;

public class CompositeProductRepository : IProductRepository
{
    private readonly ProductRepository _mem;
    private readonly SqliteProductRepository _sqlite;
    private readonly MongoProductRepository _mongo;

    public CompositeProductRepository(ProductRepository mem, SqliteProductRepository sqlite, MongoProductRepository mongo)
    {
        _mem = mem;
        _sqlite = sqlite;
        _mongo = mongo;
    }

    public async Task<Product> GetById(int id)
    {
        var product = await _mem.GetById(id);
        if (product != null) return product;
        product = await _sqlite.GetById(id);
        if (product != null) return product;
        return await _mongo.GetById(id);
    }

    public async Task<IEnumerable<Product>> GetAll()
    {
        var mem = await _mem.GetAll();
        var sqlite = await _sqlite.GetAll();
        var mongo = await _mongo.GetAll();
        return mem.Concat(sqlite).Concat(mongo);
    }

    public async Task<Product> Add(Product product)
    {
        await _mem.Add(product);
        await _sqlite.Add(product);
        await _mongo.Add(product);
        return product;
    }

    public async Task<Product> Update(Product product)
    {
        await _mem.Update(product);
        await _sqlite.Update(product);
        await _mongo.Update(product);
        return product;
    }

    public async Task Delete(int id)
    {
        await _mem.Delete(id);
        await _sqlite.Delete(id);
        await _mongo.Delete(id);
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