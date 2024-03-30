using System.CommandLine;
using System.CommandLine.Builder;
using System.CommandLine.Hosting;
using System.CommandLine.NamingConventionBinder;
using System.CommandLine.Parsing;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using NMD.Api;

var runner = BuildCommandLine()
    .UseHost(_ => Host.CreateDefaultBuilder(args),
        host =>
        {
            host.ConfigureServices((hostContext, services) =>
            {
                services.AddNmdApiClient(options =>
                {
                    options.ClientId = hostContext.Configuration.GetValue<string>("NMD:ClientId");
                    options.ClientSecret = hostContext.Configuration.GetValue<string>("NMD:ClientSecret");
                });
            });
        })
    .Build();

await runner.InvokeAsync(args);

static CommandLineBuilder BuildCommandLine()
{
    var root = new RootCommand()
    {
        Handler = CommandHandler.Create<IHost>(async host =>
        {
            var client = host.Services.GetRequiredService<INMDClient>();
            var response = await client.ElementsGetAsync(100, 0);
            Console.WriteLine(response);
        })
    };

    return new CommandLineBuilder(root);
}
