namespace MessageBroker.Infrastructure.Interfaces;

internal interface IPublisherAdapter
{
    Task PublishAsync(string topic, string message);
}