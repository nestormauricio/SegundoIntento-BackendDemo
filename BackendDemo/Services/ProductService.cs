using BackendDemo.Domain;
using BackendDemo.Repositories;

namespace BackendDemo.Services;

public class ProductService
{
    private readonly IProductRepository _repository;

    public ProductService(IProductRepository repository)
    {
        _repository = repository;
    }

    public Task<Product> GetById(int id) => _repository.GetById(id);
    public Task<IEnumerable<Product>> GetAll() => _repository.GetAll();
    public Task<Product> Add(Product product) => _repository.Add(product);
    public Task<Product> Update(Product product) => _repository.Update(product);
    public Task Delete(int id) => _repository.Delete(id);
}




















// namespace BackendDemo.Services;

// using BackendDemo.Domain;
// using BackendDemo.Repositories;
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