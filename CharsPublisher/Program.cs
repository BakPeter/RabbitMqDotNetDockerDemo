//Chars Publisher
using RabbitMQ.Client;
using RabbitMqCommon;
using System.Text;

//var rabitMqUtils = RabbitMqCommon.RabbitMqCommonUtils.GetIntatance();

var factory = new ConnectionFactory() { HostName = "localhost" };
using var connection = factory.CreateConnection();
using var channel = connection.CreateModel();
//var channel = RabbitMqCommonUtils.OpenChannel(hostName: "localhost");

channel.QueueDeclare(queue: "CharsQueue", durable: false, exclusive: false, autoDelete: false, arguments: null);
//RabbitMqCommonUtils.DeclareQueue(channel:channel, queue: "CharsQueue");

for (int i = 0; i < 10; i++)
{
    int ch = 'a';
    ch += i;
    string message = (char)ch + "";
    var body = Encoding.UTF8.GetBytes(message);

    channel.BasicPublish(exchange: "", routingKey: "CharsQueue", basicProperties: null, body: body);
    Console.WriteLine($"Chars Publisher Sent '{message}'");

    Thread.Sleep(1000);
}

Console.WriteLine(" Press [enter] to exit.");
Console.ReadLine();