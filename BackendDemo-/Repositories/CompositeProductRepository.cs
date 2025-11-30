using BackendDemo.Domain;

namespace BackendDemo.Repositories;

public class CompositeProductRepository : IProductRepository
{
    private readonly IProductRepository _memoryRepo;
    private readonly IProductRepository _sqliteRepo;
    private readonly IProductRepository _mongoRepo;

    public CompositeProductRepository(
        IProductRepository memoryRepo,
        IProductRepository sqliteRepo,
        IProductRepository mongoRepo)
    {
        _memoryRepo = memoryRepo;
        _sqliteRepo = sqliteRepo;
        _mongoRepo = mongoRepo;
    }

    public async Task<Product?> GetById(int id)
    {
        // Prioridad: memoria -> sqlite -> mongo
        var mem = await _memoryRepo.GetById(id);
        if (mem != null) return mem;

        var sql = await _sqliteRepo.GetById(id);
        if (sql != null) return sql;

        return await _mongoRepo.GetById(id);
    }

    public async Task<IEnumerable<Product>> GetAll()
    {
        var mem = await _memoryRepo.GetAll();
        var sql = await _sqliteRepo.GetAll();
        var mongo = await _mongoRepo.GetAll();

        return mem.Concat(sql).Concat(mongo);
    }

    public async Task<Product> Add(Product product)
    {
        // Crear en los tres repositorios
        var mem = await _memoryRepo.Add(product);
        await _sqliteRepo.Add(product);
        await _mongoRepo.Add(product);

        return mem;
    }

    public async Task<Product?> Update(Product product)
    {
        var mem = await _memoryRepo.Update(product);
        await _sqliteRepo.Update(product);
        await _mongoRepo.Update(product);

        return mem;
    }

    public async Task Delete(int id)
    {
        await _memoryRepo.Delete(id);
        await _sqliteRepo.Delete(id);
        await _mongoRepo.Delete(id);
    }
}






















// using BackendDemo.Domain;

// namespace BackendDemo.Repositories;

// public class CompositeProductRepository : IProductRepository
// {
//     private readonly IProductRepository _memoryRepo;
//     private readonly SqliteProductRepository _sqliteRepo;
//     private readonly MongoProductRepository _mongoRepo;

//     public CompositeProductRepository(
//         IProductRepository memoryRepo,
//         SqliteProductRepository sqliteRepo,
//         MongoProductRepository mongoRepo)
//     {
//         _memoryRepo = memoryRepo;
//         _sqliteRepo = sqliteRepo;
//         _mongoRepo = mongoRepo;
//     }

//     public async Task<Product?> GetById(int id)
//     {
//         // 1. Buscar en memoria
//         var product = await _memoryRepo.GetById(id);
//         if (product != null) return product;

//         // 2. Buscar en SQLite
//         product = await _sqliteRepo.GetById(id);
//         if (product != null) return product;

//         // 3. Buscar en Mongo
//         return await _mongoRepo.GetById(id);
//     }

//     public async Task<IEnumerable<Product>> GetAll()
//     {
//         var mem = await _memoryRepo.GetAll();
//         var sqlite = await _sqliteRepo.GetAll();
//         var mongo = await _mongoRepo.GetAll();

//         return mem.Concat(sqlite).Concat(mongo);
//     }

//     public async Task<Product> Add(Product product)
//     {
//         // Crear en los tres repositorios
//         var created = await _memoryRepo.Add(product);
//         await _sqliteRepo.Add(product);
//         await _mongoRepo.Add(product);

//         return created; // devolver el de memoria por consistencia
//     }

//     public async Task<Product> Update(Product product)
//     {
//         var updated = await _memoryRepo.Update(product);
//         await _sqliteRepo.Update(product);
//         await _mongoRepo.Update(product);

//         return updated;
//     }

//     public async Task Delete(int id)
//     {
//         await _memoryRepo.Delete(id);
//         await _sqliteRepo.Delete(id);
//         await _mongoRepo.Delete(id);
//     }
// }






















// using BackendDemo.Domain;

// namespace BackendDemo.Repositories;

// public class CompositeProductRepository : IProductRepository
// {
// <<<<<<< HEAD
//     private readonly IProductRepository _memoryRepo;
//     private readonly IProductRepository _sqliteRepo;
//     private readonly IProductRepository _mongoRepo;

//     public CompositeProductRepository(
//         IProductRepository memoryRepo,
//         SqliteProductRepository sqliteRepo,
//         MongoProductRepository mongoRepo)
//     {
//         _memoryRepo = memoryRepo;
//         _sqliteRepo = sqliteRepo;
//         _mongoRepo = mongoRepo;
// =======
//     private readonly ProductRepository _mem;
//     private readonly SqliteProductRepository _sqlite;
//     private readonly MongoProductRepository _mongo;

//     public CompositeProductRepository(ProductRepository mem, SqliteProductRepository sqlite, MongoProductRepository mongo)
//     {
//         _mem = mem;
//         _sqlite = sqlite;
//         _mongo = mongo;
// >>>>>>> stable
//     }

//     public async Task<Product> GetById(int id)
//     {
// <<<<<<< HEAD
//         // Leemos de memoria como referencia principal
//         return await _memoryRepo.GetAll();
// =======
//         var product = await _mem.GetById(id);
//         if (product != null) return product;
//         product = await _sqlite.GetById(id);
//         if (product != null) return product;
//         return await _mongo.GetById(id);
// >>>>>>> stable
//     }

//     public async Task<IEnumerable<Product>> GetAll()
//     {
//         var mem = await _mem.GetAll();
//         var sqlite = await _sqlite.GetAll();
//         var mongo = await _mongo.GetAll();
//         return mem.Concat(sqlite).Concat(mongo);
//     }

//     public async Task<Product> Add(Product product)
//     {
// <<<<<<< HEAD
//         // Crear en los tres repositorios
//         var mem = await _memoryRepo.Create(product);
//         var sql = await _sqliteRepo.Create(product);
//         var mongo = await _mongoRepo.Create(product);

//         return mem; // devolver el de memoria por consistencia
// =======
//         await _mem.Add(product);
//         await _sqlite.Add(product);
//         await _mongo.Add(product);
//         return product;
// >>>>>>> stable
//     }

//     public async Task<Product> Update(Product product)
//     {
// <<<<<<< HEAD
//         var mem = await _memoryRepo.Update(product);
//         var sql = await _sqliteRepo.Update(product);
//         var mongo = await _mongoRepo.Update(product);

//         return mem;
// =======
//         await _mem.Update(product);
//         await _sqlite.Update(product);
//         await _mongo.Update(product);
//         return product;
// >>>>>>> stable
//     }

//     public async Task Delete(int id)
//     {
// <<<<<<< HEAD
//         var mem = await _memoryRepo.Delete(id);
//         var sql = await _sqliteRepo.Delete(id);
//         var mongo = await _mongoRepo.Delete(id);

//         return mem;
// =======
//         await _mem.Delete(id);
//         await _sqlite.Delete(id);
//         await _mongo.Delete(id);
// >>>>>>> stable
//     }
// }






















// <<<<<<< HEAD

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






















// =======
// >>>>>>> stable
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