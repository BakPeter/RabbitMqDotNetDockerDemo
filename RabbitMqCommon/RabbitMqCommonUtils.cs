using RabbitMQ.Client;

namespace RabbitMqCommon
{
    public class RabbitMqCommonUtils
    {
        //private static RabbitMqCommonUtils? _instance;
        //private RabbitMqCommonUtils() { }
        //public static RabbitMqCommonUtils GetIntatance() => _instance ?? new RabbitMqCommonUtils();

        public static IModel OpenChannel(string hostName)
        {
            var factory = new ConnectionFactory() { HostName = hostName };
            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();

            return channel;
        }

        public static QueueDeclareOk DeclareQueue(IModel channel, string queue) =>
            channel.QueueDeclare(queue: queue, durable: false, exclusive: false, autoDelete: false, arguments: null);
    }
}
