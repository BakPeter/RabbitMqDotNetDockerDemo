namespace MessageBroker.Core;

public interface ISubscriber
{
    void Subscribe(string topic, Action<string> callBack);
}