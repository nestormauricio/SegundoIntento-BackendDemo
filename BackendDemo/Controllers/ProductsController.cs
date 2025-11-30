namespace BackendDemo.Controllers;

using BackendDemo.Domain;
using BackendDemo.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly ProductService _service;

    public ProductsController(ProductService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await _service.GetAll());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var p = await _service.GetById(id);
        return p == null ? NotFound() : Ok(p);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Product p) => Ok(await _service.Create(p));

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Product p)
    {
        if (id != p.Id) return BadRequest("IDs no coinciden.");
        var updated = await _service.Update(p);
        return updated == null ? NotFound() : Ok(updated);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id) => Ok(await _service.Delete(id));
}























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