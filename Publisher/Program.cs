using RabbitMQ.Client;
using System.Text;

var factory = new ConnectionFactory() { HostName = "localhost" };
using var connection = factory.CreateConnection();
using var channel = connection.CreateModel();

channel.QueueDeclare(queue: "EntitiesQueue", durable: false, exclusive: false, autoDelete: false, arguments: null);

string message = "{param1:value1, param2:value2}";
var body = Encoding.UTF8.GetBytes(message);

channel.BasicPublish(exchange: "", routingKey: "EntitiesQueue", basicProperties: null, body: body);
Console.WriteLine($"Chars Publisher Sent '{message}'");

Console.WriteLine(" Press [enter] to exit.");
Console.ReadLine();