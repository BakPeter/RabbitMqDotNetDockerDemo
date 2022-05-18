using MessageBroker.Core;
using MessageBroker.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace Publisher.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PublisherController : Controller
    {
        private readonly IPublisher _publisher;

        public PublisherController(IPublisher publisher)
        {
            _publisher = publisher;
        }

        [HttpPost]
        public MessageBrokerResultModel Publish(string topic, string message) => _publisher.Publish(topic, message);
    }
}