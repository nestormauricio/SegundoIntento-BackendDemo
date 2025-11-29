using BackendDemo.Domain;
using MongoDB.Bson;
using MongoDB.Driver;

namespace BackendDemo.Repositories;

public class MongoProductRepository : IProductRepository
{
    private readonly IMongoCollection<Product> _collection;

    public MongoProductRepository()
    {
        var client = new MongoClient("mongodb://localhost:27017");
<<<<<<< HEAD
        var database = client.GetDatabase("MyDatabase");
        _collection = database.GetCollection<Product>("Products");
    }

    public async Task<List<Product>> GetAll() => await _collection.Find(new BsonDocument()).ToListAsync();
    public async Task<Product?> GetById(int id) => await _collection.Find(p => p.Id == id).FirstOrDefaultAsync();
    public async Task<Product> Create(Product product)
=======
        var database = client.GetDatabase("products_db");
        _collection = database.GetCollection<Product>("products");
    }

    public async Task<Product> GetById(int id) =>
        await _collection.Find(p => p.Id == id).FirstOrDefaultAsync() ?? throw new Exception("Product not found");

    public async Task<IEnumerable<Product>> GetAll() =>
        await _collection.Find(_ => true).ToListAsync();

    public async Task<Product> Add(Product product)
>>>>>>> stable
    {
        await _collection.InsertOneAsync(product);
        return product;
    }

    public async Task<Product> Update(Product product)
    {
<<<<<<< HEAD
        await _collection.ReplaceOneAsync(p => p.Id == product.Id, product);
        return product;
    }

    public async Task<bool> Delete(int id)
    {
        var result = await _collection.DeleteOneAsync(p => p.Id == id);
        return result.DeletedCount > 0;
    }
=======
        var result = await _collection.ReplaceOneAsync(p => p.Id == product.Id, product);
        return product;
    }

    public async Task Delete(int id) =>
        await _collection.DeleteOneAsync(p => p.Id == id);
>>>>>>> stable
}






















// using BackendDemo.Domain;
// using MongoDB.Driver;
// using System.Collections.Generic;
// using System.Threading.Tasks;

// namespace BackendDemo.Repositories;

// public class MongoProductRepository : IProductRepository
// {
//     private readonly IMongoCollection<Product> _collection;

//     public MongoProductRepository()
//     {
//         var client = new MongoClient("mongodb://localhost:27017");
//         var database = client.GetDatabase("TechDB");
//         _collection = database.GetCollection<Product>("Products");
//     }

//     public async Task<List<Product>> GetAll() =>
//         await _collection.Find(_ => true).ToListAsync();

//     public async Task<Product?> GetById(int id) =>
//         await _collection.Find(p => p.Id == id).FirstOrDefaultAsync();

//     public async Task<Product> Create(Product product)
//     {
//         await _collection.InsertOneAsync(product);
//         return product;
//     }

//     public async Task<Product?> Update(Product product)
//     {
//         var result = await _collection.ReplaceOneAsync(p => p.Id == product.Id, product);
//         return result.MatchedCount > 0 ? product : null;
//     }

//     public async Task<bool> Delete(int id)
//     {
//         var result = await _collection.DeleteOneAsync(p => p.Id == id);
//         return result.DeletedCount > 0;
//     }
// }