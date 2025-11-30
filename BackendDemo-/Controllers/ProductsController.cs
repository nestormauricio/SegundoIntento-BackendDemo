using BackendDemo.Domain;
using BackendDemo.Services;
using Microsoft.AspNetCore.Mvc;

namespace BackendDemo.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly ProductService _productService;

    public ProductsController(ProductService productService)
    {
        _productService = productService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var product = await _productService.GetById(id);
        if (product == null) return NotFound();
        return Ok(product);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var products = await _productService.GetAll();
        return Ok(products);
    }

    [HttpPost]
    public async Task<IActionResult> Add(Product product)
    {
        var newProduct = await _productService.Add(product);
        return CreatedAtAction(nameof(GetById), new { id = newProduct.Id }, newProduct);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Product product)
    {
        if (id != product.Id) return BadRequest();
        var updatedProduct = await _productService.Update(product);
        return Ok(updatedProduct);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _productService.Delete(id);
        return NoContent();
    }
}





















// using BackendDemo.Domain;
// using BackendDemo.Repositories;

// namespace BackendDemo.Services;

// public class ProductService
// {
//     private readonly IProductRepository _repository;

//     public ProductService(IProductRepository repository)
//     {
//         _repository = repository;
//     }

//     public Task<Product> GetById(int id) => _repository.GetById(id);
//     public Task<IEnumerable<Product>> GetAll() => _repository.GetAll();
//     public Task<Product> Add(Product product) => _repository.Add(product);
//     public Task<Product> Update(Product product) => _repository.Update(product);
//     public Task Delete(int id) => _repository.Delete(id);
// }

























// namespace BackendDemo.Controllers;

// using BackendDemo.Domain;
// using BackendDemo.Services;
// using Microsoft.AspNetCore.Mvc;
// using System.Threading.Tasks;

// [ApiController]
// [Route("api/[controller]")]
// public class ProductsController : ControllerBase
// {
//     private readonly ProductService _service;

//     public ProductsController(ProductService service)
//     {
//         _service = service;
//     }

//     [HttpGet]
//     public async Task<IActionResult> GetAll() => Ok(await _service.GetAll());

//     [HttpGet("{id}")]
//     public async Task<IActionResult> GetById(int id)
//     {
//         var p = await _service.GetById(id);
//         return p == null ? NotFound() : Ok(p);
//     }

//     [HttpPost]
//     public async Task<IActionResult> Create(Product p) => Ok(await _service.Create(p));

//     [HttpPut("{id}")]
//     public async Task<IActionResult> Update(int id, Product p)
//     {
//         if (id != p.Id) return BadRequest("IDs no coinciden.");
//         var updated = await _service.Update(p);
//         return updated == null ? NotFound() : Ok(updated);
//     }

//     [HttpDelete("{id}")]
//     public async Task<IActionResult> Delete(int id) => Ok(await _service.Delete(id));
// }























// using Microsoft.AspNetCore.Mvc;
// using System.Threading.Tasks;

// [ApiController]
// [Route("api/[controller]")]
// public class ProductsController : ControllerBase
// {
//     private readonly ProductService _service;

//     public ProductsController(ProductService service)
//     {
//         _service = service;
//     }

//     [HttpGet]
//     public async Task<IActionResult> GetAll()
//         => Ok(await _service.GetAll());

//     [HttpGet("{id}")]
//     public async Task<IActionResult> GetById(int id)
//     {
//         var p = await _service.GetById(id);
//         return p == null ? NotFound() : Ok(p);
//     }

//     [HttpPost]
//     public async Task<IActionResult> Create(Product p)
//         => Ok(await _service.Create(p));

//     [HttpPut("{id}")]
//     public async Task<IActionResult> Update(int id, Product p)
//     {
//         if (id != p.Id) return BadRequest("IDs no coinciden.");
//         var updated = await _service.Update(p);
//         return updated == null ? NotFound() : Ok(updated);
//     }

//     [HttpDelete("{id}")]
//     public async Task<IActionResult> Delete(int id)
//         => Ok(await _service.Delete(id));
// }