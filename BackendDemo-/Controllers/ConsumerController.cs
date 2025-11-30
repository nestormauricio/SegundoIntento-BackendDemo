using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("consumer")]
public class ConsumerController : ControllerBase
{
    [HttpPost("stop")]
    public IActionResult Stop()
    {
        // lógica para detener el consumidor
        return Ok("Consumer stopped");
    }
}