using Microsoft.Extensions.Hosting;

internal class Worker : BackgroundService
{
    private readonly IPerson person;

    public Worker(IPerson person)
    {
        this.person = person;
    }
    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var a = person.Name;
        return Task.CompletedTask;
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