using MessageBroker.Core;
using MessageBroker.Core.Models;
using Microsoft.Extensions.Hosting;

namespace Subscriber;

internal class Worker : BackgroundService
{
    private readonly ISubscriber _subscriber;

    public Worker(ISubscriber subscriber)
    {
        _subscriber = subscriber;
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        Console.WriteLine("Waiting for messages...");
        _subscriber.Subscribe("topic1", (msg) => 
                              new MessageBrokerResultModel(Success: true, Message: msg), stoppingToken);
        return Task.CompletedTask;
    }
}