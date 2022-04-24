using Microsoft.Azure.Functions.Extensions.DependencyInjection;

using AggregateGroot.ApplicationInsightsDemo.Functions;
using AggregateGroot.ApplicationInsightsDemo.Functions.Middleware.Telemetry;

[assembly: FunctionsStartup(typeof(Startup))]

namespace AggregateGroot.ApplicationInsightsDemo.Functions
{
    /// <summary>
    /// Manages the startup routine for the functions application.
    /// </summary>
    public class Startup : FunctionsStartup
    {
        /// <inheritdoc />
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddTelemetry();
        }
    }
}