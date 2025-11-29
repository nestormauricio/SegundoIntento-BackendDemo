using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace BackendDemo.Services
{
    public class ProductConsumerService
    {
        private readonly IConnection _connection;
        private readonly IModel _channel;
        private EventingBasicConsumer? _consumer;
        private string _consumerTag = "";
        private bool _running = false;

        public ProductConsumerService()
        {
            var factory = new ConnectionFactory()
            {
                HostName = "localhost",
                UserName = "admin",
                Password = "admin"
            };

            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();

            _channel.QueueDeclare(
                queue: "product-events",
                durable: true,
                exclusive: false,
                autoDelete: false,
                arguments: null
            );
        }

        public string Start()
        {
            if (_running)
                return "Consumer ya estaba encendido.";

            _running = true;

            _consumer = new EventingBasicConsumer(_channel);
            _consumer.Received += (sender, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);

                Console.WriteLine($"[Consumer] Recibido: {message}");

                _channel.BasicAck(ea.DeliveryTag, multiple: false);
            };

            _consumerTag = _channel.BasicConsume(
                queue: "product-events",
                autoAck: false,
                consumer: _consumer
            );

            return "Consumer encendido.";
        }

        public string Stop()
        {
            if (!_running)
                return "Consumer ya estaba apagado.";

            _running = false;

            _channel.BasicCancel(_consumerTag);

            return "Consumer apagado.";
        }
    }
}