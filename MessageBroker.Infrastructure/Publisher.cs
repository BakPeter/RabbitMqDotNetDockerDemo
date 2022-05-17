using MessageBroker.Core;
using MessageBroker.Infrastructure.Interfaces;

namespace MessageBroker.Infrastructure;

internal class Publisher : IPublisher
{
    private readonly IPublisherAdapter _publisherAdapter;

    public Publisher(IPublisherAdapter publisherAdapter)
    {
        _publisherAdapter = publisherAdapter;
    }

    public async Task PublishAsync(string topic, string message)
    {
        await _publisherAdapter.PublishAsync(topic, message);
    }
}