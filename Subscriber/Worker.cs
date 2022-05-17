using MessageBroker.Core;
using Microsoft.Extensions.Hosting;

namespace Subscriber;

internal class Worker : BackgroundService
{
    private readonly ISubscriber _subscriber;

    public Worker(ISubscriber subscriber)
    {
        _subscriber = subscriber;
    }
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        Console.WriteLine("Waiting for messages...");
        await _subscriber.SubscribeAsync("topic1", Console.WriteLine);
    }
}


//var factory = new ConnectionFactory() { HostName = "localhost" };
//using var connection = factory.CreateConnection();
//using var channel = connection.CreateModel();

//channel.QueueDeclare(queue: "EntitiesQueue", durable: false, exclusive: false, autoDelete: false, arguments: null);

//Console.WriteLine("Subscriber Waiting for messages.");
//Console.WriteLine("================================");

//var consumer = new EventingBasicConsumer(channel);
//consumer.Received += (model, ea) =>
//{
//    var body = ea.Body.ToArray();
//    var message = Encoding.UTF8.GetString(body);
//    Console.WriteLine($"Subscriber Received '{message}'");
//};

//channel.BasicConsume(queue: "EntitiesQueue", autoAck: true, consumer: consumer,);

//Console.WriteLine("Press [enter] to exit.");
//Console.ReadLine();