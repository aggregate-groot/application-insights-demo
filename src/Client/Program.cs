using System;

using McMaster.Extensions.CommandLineUtils;
using Microsoft.Extensions.DependencyInjection;

using AggregateGroot.ApplicationInsightsDemo.Client.Commands;

namespace AggregateGroot.ApplicationInsightsDemo.Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ServiceCollection services = new ServiceCollection();
            services.AddHttpClient<IApiClient, HttpApiClient>(client =>
            {
                client.BaseAddress = new Uri("http://localhost:8400/");
            });
            services.AddSingleton<IConsole>(PhysicalConsole.Singleton);

            ServiceProvider serviceProvider = services.BuildServiceProvider();

            CommandLineApplication<RootCommand> application = new ();
            application.Conventions
                .UseDefaultConventions()
                .UseConstructorInjection(serviceProvider);

            application.Execute(args);
        }
    }
}