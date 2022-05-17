using MessageBroker.Core;
using MessageBroker.Infrastructure.Interfaces;

namespace MessageBroker.Infrastructure;

internal class Subscriber : ISubscriber
{
    private readonly ISubscriberAdapter _subscriberAdapter;

    public Subscriber(ISubscriberAdapter subscriberAdapter)
    {
        _subscriberAdapter = subscriberAdapter;
    }
 
    public async Task SubscribeAsync(string topic, Action<string> callBack)
    {
        await _subscriberAdapter.SubscribeAsync(topic, callBack);
    }
}