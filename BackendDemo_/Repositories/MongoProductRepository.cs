using BackendDemo.Domain;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackendDemo.Repositories;

public class MongoProductRepository : IProductRepository
{
    private readonly IMongoCollection<Product> _collection;

    public MongoProductRepository()
    {
        var client = new MongoClient("mongodb://localhost:27017");
        var database = client.GetDatabase("TechDB");
        _collection = database.GetCollection<Product>("Products");
    }

    public async Task<List<Product>> GetAll() => await _collection.Find(_ => true).ToListAsync();

    public async Task<Product?> GetById(int id) => 
        await _collection.Find(p => p.Id == id).FirstOrDefaultAsync();

    public async Task<Product> Create(Product product)
    {
        await _collection.InsertOneAsync(product);
        return product;
    }

    public async Task<Product?> Update(Product product)
    {
        await _collection.ReplaceOneAsync(p => p.Id == product.Id, product);
        return product;
    }

    public async Task<bool> Delete(int id)
    {
        var result = await _collection.DeleteOneAsync(p => p.Id == id);
        return result.DeletedCount > 0;
    }
}





















// using BackendDemo.Domain;
// using MongoDB.Driver;
// using System.Collections.Generic;
// using System.Threading.Tasks;

// namespace BackendDemo.Repositories;

// public class MongoProductRepository : IProductRepository
// {
//     private readonly IMongoCollection<Product> _products;

//     public MongoProductRepository()
//     {
//         var client = new MongoClient("mongodb://localhost:27017");
//         var database = client.GetDatabase("TechDB");
//         _products = database.GetCollection<Product>("Products");
//     }

//     public async Task<List<Product>> GetAll() => await _products.Find(_ => true).ToListAsync();

//     public async Task<Product?> GetById(int id) => 
//         await _products.Find(p => p.Id == id).FirstOrDefaultAsync();

//     public async Task<Product> Create(Product product)
//     {
//         // Asegurarse de que Mongo genere el _id automáticamente
//         product.Id = 0;
//         await _products.InsertOneAsync(product);
//         return product;
//     }

//     public async Task<Product?> Update(Product product)
//     {
//         var filter = Builders<Product>.Filter.Eq(p => p.Id, product.Id);
//         var result = await _products.ReplaceOneAsync(filter, product);
//         return result.MatchedCount > 0 ? product : null;
//     }

//     public async Task<bool> Delete(int id)
//     {
//         var result = await _products.DeleteOneAsync(p => p.Id == id);
//         return result.DeletedCount > 0;
//     }
// }





















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