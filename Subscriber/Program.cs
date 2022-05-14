using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

var factory = new ConnectionFactory() { HostName = "localhost" };
using var connection = factory.CreateConnection();
using var channel = connection.CreateModel();

channel.QueueDeclare(queue: "CounterQueue", durable: false, exclusive: false, autoDelete: false, arguments: null);
channel.QueueDeclare(queue: "CharsQueue", durable: false, exclusive: false, autoDelete: false, arguments: null);

Console.WriteLine("Subscriber Waiting for messages.");
Console.WriteLine("================================");

var consumer = new EventingBasicConsumer(channel);
consumer.Received += (model, ea) =>
{
    var body = ea.Body.ToArray();
    var message = Encoding.UTF8.GetString(body);
    Console.WriteLine($"Subscriber Received '{message}'");
};
channel.BasicConsume(queue: "CounterQueue", autoAck: true, consumer: consumer);
channel.BasicConsume(queue: "CharsQueue", autoAck: true, consumer: consumer);

Console.WriteLine("Press [enter] to exit.");
Console.ReadLine();