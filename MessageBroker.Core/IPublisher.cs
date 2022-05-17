namespace MessageBroker.Core;

public interface IPublisher
{
    Task PublishAsync(string topic, string message);
}
