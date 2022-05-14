//numbers publisher
using RabbitMQ.Client;
using System.Text;


var factory = new ConnectionFactory() { HostName = "localhost" };
using var connection = factory.CreateConnection();
using var channel = connection.CreateModel();

channel.QueueDeclare(queue: "CounterQueue", durable: false, exclusive: false, autoDelete: false, arguments: null);

for (int i = 0; i < 10; i++)
{
    string message = "count = " + i;
    var body = Encoding.UTF8.GetBytes(message);

    channel.BasicPublish(exchange: "", routingKey: "CounterQueue", basicProperties: null, body: body);
    Console.WriteLine($"Counter Publisher Sent '{message}'");

    Thread.Sleep(1000);
}

Console.WriteLine(" Press [enter] to exit.");
Console.ReadLine();