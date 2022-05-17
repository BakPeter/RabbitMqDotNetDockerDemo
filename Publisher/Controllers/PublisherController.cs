using MessageBroker.Core;
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
        public async Task Publish(string topic, string message) => await _publisher.PublishAsync(topic, message);
    }
}