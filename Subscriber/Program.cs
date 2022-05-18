using MessageBroker.Infrastructure;
using MessageBroker.Infrastructure.RabbitMq.Builder.Configurations;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Subscriber;

using var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((_, services) =>
    {
        services.AddMessageBrokerPubSubServices(new RabbitMqConfiguration { HostName = "localhost" });
        services.AddHostedService<Worker>();
    }).Build();

await host.RunAsync();
