using RabbitMQ.Client;
using System.Text;

namespace BackendDemo.Services
{
    public class RabbitMqService
    {
        private readonly IConnection _connection;
        private readonly IModel _channel;

        public RabbitMqService()
        {
            var factory = new ConnectionFactory
            {
                HostName = "localhost"
            };

            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();

            _channel.QueueDeclare(
                queue: "product-events",
                durable: false,
                exclusive: false,
                autoDelete: false,
                arguments: null
            );
        }

        public void Publish(string message)
        {
            var body = Encoding.UTF8.GetBytes(message);

            _channel.BasicPublish(
                exchange: "",
                routingKey: "product-events",
                basicProperties: null,
                body: body
            );
        }
    }
}