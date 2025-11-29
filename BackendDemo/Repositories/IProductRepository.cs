using BackendDemo.Domain;

namespace BackendDemo.Repositories;

public interface IProductRepository
{
    Task<Product> GetById(int id);
    Task<IEnumerable<Product>> GetAll();
    Task<Product> Add(Product product);
    Task<Product> Update(Product product);
    Task Delete(int id);
}




















// namespace BackendDemo.Repositories;

// using BackendDemo.Domain;
// using System.Collections.Generic;
// using System.Threading.Tasks;

// public interface IProductRepository
// {
//     Task<List<Product>> GetAll();
//     Task<Product> GetById(int id);
//     Task<Product> Create(Product product);
//     Task<Product> Update(Product product);
//     Task<bool> Delete(int id);
// }






















// using System.Collections.Generic;
// using System.Threading.Tasks;

// public interface IProductRepository
// {
//     Task<List<Product>> GetAll();
//     Task<Product> GetById(int id);
//     Task<Product> Create(Product product);
//     Task<Product> Update(Product product);
//     Task<bool> Delete(int id);
// }