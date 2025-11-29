using BackendDemo.Domain;
using Dapper;
using Microsoft.Data.Sqlite;

namespace BackendDemo.Repositories;

public class SqliteProductRepository : IProductRepository
{
    private readonly string _connectionString = "Data Source=Products.db";

    public async Task<Product> GetById(int id)
    {
        using var connection = new SqliteConnection(_connectionString);
        return await connection.QuerySingleOrDefaultAsync<Product>("SELECT * FROM Products WHERE Id = @Id", new { Id = id }) 
               ?? throw new Exception("Product not found");
    }

    public async Task<IEnumerable<Product>> GetAll()
    {
        using var connection = new SqliteConnection(_connectionString);
        return await connection.QueryAsync<Product>("SELECT * FROM Products");
    }

    public async Task<Product> Add(Product product)
    {
        using var connection = new SqliteConnection(_connectionString);
        var sql = "INSERT INTO Products (Name, Price) VALUES (@Name, @Price); SELECT last_insert_rowid();";
        var id = await connection.ExecuteScalarAsync<int>(sql, product);
        product.Id = id;
        return product;
    }

    public async Task<Product> Update(Product product)
    {
        using var connection = new SqliteConnection(_connectionString);
        await connection.ExecuteAsync("UPDATE Products SET Name = @Name, Price = @Price WHERE Id = @Id", product);
        return product;
    }

    public async Task Delete(int id)
    {
        using var connection = new SqliteConnection(_connectionString);
        await connection.ExecuteAsync("DELETE FROM Products WHERE Id = @Id", new { Id = id });
    }
}






















// using BackendDemo.Domain;
// using Dapper;
// using Microsoft.Data.Sqlite;

// namespace BackendDemo.Repositories;

// public class SqliteProductRepository : IProductRepository
// {
//     private readonly string _connectionString = "Data Source=Products.db";

//     public async Task<Product> GetById(int id)
//     {
//         using var connection = new SqliteConnection(_connectionString);
//         return await connection.QuerySingleOrDefaultAsync<Product>("SELECT * FROM Products WHERE Id = @Id", new { Id = id }) 
//                ?? throw new Exception("Product not found");
//     }

//     public async Task<IEnumerable<Product>> GetAll()
//     {
//         using var connection = new SqliteConnection(_connectionString);
//         return await connection.QueryAsync<Product>("SELECT * FROM Products");
//     }

//     public async Task<Product> Add(Product product)
//     {
//         using var connection = new SqliteConnection(_connectionString);
//         var sql = "INSERT INTO Products (Name, Price) VALUES (@Name, @Price); SELECT last_insert_rowid();";
//         var id = await connection.ExecuteScalarAsync<int>(sql, product);
//         product.Id = id;
//         return product;
//     }

//     public async Task<Product> Update(Product product)
//     {
//         using var connection = new SqliteConnection(_connectionString);
//         await connection.ExecuteAsync("UPDATE Products SET Name = @Name, Price = @Price WHERE Id = @Id", product);
//         return product;
//     }

//     public async Task Delete(int id)
//     {
//         using var connection = new SqliteConnection(_connectionString);
//         await connection.ExecuteAsync("DELETE FROM Products WHERE Id = @Id", new { Id = id });
//     }
// }














// using BackendDemo.Domain;
// using Microsoft.Data.Sqlite;
// using Dapper;

// namespace BackendDemo.Repositories;

// public class SqliteProductRepository
// {
//     private readonly string _connectionString = "Data Source=Products.db";

//     public async Task<Product?> GetById(int id)
//     {
//         using var connection = new SqliteConnection(_connectionString);
//         return await connection.QueryFirstOrDefaultAsync<Product>("SELECT * FROM Product WHERE Id = @Id", new { Id = id });
//     }

//     public async Task<Product?> Update(Product product)
//     {
//         using var connection = new SqliteConnection(_connectionString);
//         await connection.ExecuteAsync("UPDATE Product SET Name=@Name, Price=@Price WHERE Id=@Id", product);
//         return product;
//     }

//     public async Task<IEnumerable<Product>> GetAll()
//     {
//         using var connection = new SqliteConnection(_connectionString);
//         return await connection.QueryAsync<Product>("SELECT * FROM Product");
//     }

//     public async Task Add(Product product)
//     {
//         using var connection = new SqliteConnection(_connectionString);
//         await connection.ExecuteAsync("INSERT INTO Product (Id, Name, Price) VALUES (@Id, @Name, @Price)", product);
//     }
// }























// using BackendDemo.Domain;
// using Microsoft.EntityFrameworkCore;
// using System.Collections.Generic;
// using System.Threading.Tasks;

// namespace BackendDemo.Repositories;

// public class SqliteProductRepository : IProductRepository
// {
//     private readonly AppDbContext _context = new();

//     public SqliteProductRepository()
//     {
//         _context.Database.EnsureCreated();
//     }

//     public async Task<List<Product>> GetAll() => await _context.Products.ToListAsync();

//     public async Task<Product?> GetById(int id) => await _context.Products.FindAsync(id);

//     public async Task<Product> Create(Product product)
//     {
//         _context.Products.Add(product);
//         await _context.SaveChangesAsync();
//         return product;
//     }

//     public async Task<Product?> Update(Product product)
//     {
//         _context.Products.Update(product);
//         await _context.SaveChangesAsync();
//         return product;
//     }

//     public async Task<bool> Delete(int id)
//     {
//         var existing = await _context.Products.FindAsync(id);
//         if (existing == null) return false;
//         _context.Products.Remove(existing);
//         await _context.SaveChangesAsync();
//         return true;
//     }
// }