using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace AggregateGroot.ApplicationInsightsDemo.Api
{
    /// <summary>
    /// Represents the API application.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Main entry point for the application.
        /// </summary>
        /// <param name="args">
        /// Optional command line arguments.
        /// </param>
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        /// <summary>
        /// Creates the Web host builder.
        /// </summary>
        /// <param name="args">
        /// Optional command line arguments.
        /// </param>
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }
}