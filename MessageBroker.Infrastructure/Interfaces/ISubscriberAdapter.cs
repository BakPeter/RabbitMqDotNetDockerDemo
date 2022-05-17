namespace MessageBroker.Infrastructure.Interfaces;

internal interface ISubscriberAdapter
{
    Task SubscribeAsync(string topic, Action<string> callBack);
}