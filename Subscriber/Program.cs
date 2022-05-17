using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Subscriber;

using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((_, services) =>
    {
        services.AddTransient<IPerson, Person>();
        services.AddHostedService<Worker>();
    }).Build();

await host.RunAsync();

namespace Subscriber
{
    //sample
    public interface IPerson
    {
        string Name { get; }
    }

    public class Person : IPerson
    {
        public string Name => "abc";
    }
}