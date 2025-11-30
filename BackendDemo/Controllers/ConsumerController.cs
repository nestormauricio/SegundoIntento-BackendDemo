using BackendDemo.Services;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("consumer")]
public class ConsumerController : ControllerBase
{
    private readonly ProductConsumerService _consumer;

    public ConsumerController(ProductConsumerService consumer)
    {
        _consumer = consumer;
    }

    [HttpPost("start")]
    public IActionResult Start()
    {
        return Ok(_consumer.Start());
    }

    [HttpPost("stop")]
    public IActionResult Stop()
    {
        return Ok(_consumer.Stop());
    }
}