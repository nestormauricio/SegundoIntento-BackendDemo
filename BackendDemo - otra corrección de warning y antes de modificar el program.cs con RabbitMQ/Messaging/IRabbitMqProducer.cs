namespace BackendDemo.Messaging;

public interface IRabbitMqProducer
{
    void Publish(string message);
}