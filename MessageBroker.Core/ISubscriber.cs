namespace MessageBroker.Core;

public interface ISubscriber
{
    Task SubscribeAsync(string topic, Action<string> callBack);
}