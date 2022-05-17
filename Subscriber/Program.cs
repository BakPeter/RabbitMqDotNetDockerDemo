using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((_, services) =>
    {
        services.AddTransient<IPerson, Person>();
        services.AddHostedService<Worker>();
    }).Build();

await host.RunAsync();

//sample
public interface IPerson
{
    string Name { get; }
}

public class Person : IPerson
{
    public string Name => "abc";
}
