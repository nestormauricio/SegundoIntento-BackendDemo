using RabbitMQ.Client;
using System.Text;

public class RabbitMqProducer
{
    private readonly ConnectionFactory _factory;

    public RabbitMqProducer()
    {
        _factory = new ConnectionFactory()
        {
            HostName = "localhost",
            UserName = "guest",
            Password = "guest"
        };
    }

    public void SendMessage(string queue, string message)
    {
        using var connection = _factory.CreateConnection();
        using var channel = connection.CreateModel();

        channel.QueueDeclare(
            queue: queue,
            durable: false,
            exclusive: false,
            autoDelete: false,
            arguments: null
        );

        var body = Encoding.UTF8.GetBytes(message);

        channel.BasicPublish(
            exchange: "",
            routingKey: queue,
            basicProperties: null,
            body: body
        );
    }
}





















// // Messaging/RabbitMqPublisher.cs
// using System.Text;
// using System.Text.Json;
// // No "using RabbitMQ.Client;" aquí a propósito para evitar ambigüedades de nombres.
// // Usaremos el nombre totalmente calificado donde haga falta.

// namespace BackendDemo.Messaging;

// public class RabbitMqPublisher
// {
//     private readonly string _hostname = "localhost";
//     private readonly string _queueName = "products";

//     public void Publish(object message)
//     {
//         // Crear la fábrica explícitamente usando el tipo completo para evitar colisiones de nombres.
//         var factory = new global::RabbitMQ.Client.ConnectionFactory
//         {
//             HostName = _hostname
//         };

//         // Usar variables de tipo explícito para claridad
//         global::RabbitMQ.Client.IConnection? connection = null;
//         global::RabbitMQ.Client.IModel? channel = null;

//         try
//         {
//             connection = factory.CreateConnection();
//             channel = connection.CreateModel();

//             channel.QueueDeclare(
//                 queue: _queueName,
//                 durable: false,
//                 exclusive: false,
//                 autoDelete: false,
//                 arguments: null);

//             var json = JsonSerializer.Serialize(message);
//             var body = Encoding.UTF8.GetBytes(json);

//             channel.BasicPublish(
//                 exchange: string.Empty,
//                 routingKey: _queueName,
//                 basicProperties: null,
//                 body: body);
//         }
//         finally
//         {
//             // Cerrar/Dispose con seguridad
//             if (channel != null)
//             {
//                 try { channel.Close(); } catch { }
//                 channel.Dispose();
//             }

//             if (connection != null)
//             {
//                 try { connection.Close(); } catch { }
//                 connection.Dispose();
//             }
//         }
//     }
// }




// using System.Text;
// using RabbitMQ.Client;

// namespace BackendDemo.Messaging;

// public class RabbitMqProducer : IRabbitMqProducer
// {
//     private readonly RabbitMqSettings _settings;

//     public RabbitMqProducer(RabbitMqSettings settings)
//     {
//         _settings = settings;
//     }

//     public void Publish(string message)
//     {
//         var factory = new ConnectionFactory()
//         {
//             HostName = _settings.HostName
//         };

//         using var connection = factory.CreateConnection();
//         using var channel = connection.CreateModel();

//         channel.QueueDeclare(
//             queue: _settings.QueueName,
//             durable: false,
//             exclusive: false,
//             autoDelete: false,
//             arguments: null);

//         var body = Encoding.UTF8.GetBytes(message);

//         channel.BasicPublish(
//             exchange: "",
//             routingKey: _settings.QueueName,
//             basicProperties: null,
//             body: body);
//     }
// }