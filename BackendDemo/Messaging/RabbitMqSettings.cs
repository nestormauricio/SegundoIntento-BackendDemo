namespace BackendDemo.Messaging;

public class RabbitMqSettings
{
    public string HostName { get; set; } = "localhost";
    public string QueueName { get; set; } = "products_queue";
}