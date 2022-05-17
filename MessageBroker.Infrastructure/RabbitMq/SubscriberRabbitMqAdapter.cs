
using System.Text;
using MessageBroker.Infrastructure.Interfaces;
using MessageBroker.Infrastructure.RabbitMq.Builder;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace MessageBroker.Infrastructure.RabbitMq;

internal class SubscriberRabbitMqAdapter : ISubscriberAdapter, IDisposable
{
    private readonly IModel _channel;

    public SubscriberRabbitMqAdapter(RabbitMqChannelBuilder rabbitMqChannelBuilder)
    {
        _channel = rabbitMqChannelBuilder.Build();
    }

    public async Task SubscribeAsync(string topic, Action<string> callBack)
    {
        await Task.Run(() =>
        {
            _channel.QueueDeclare(queue: topic, durable: false, exclusive: false, autoDelete: false, arguments: null);

            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                callBack(message);
            };

            _channel.BasicConsume(queue: topic, autoAck: true, consumer: consumer);
        });
    }

    public void Dispose()
    {
        _channel.Dispose();
    }
}