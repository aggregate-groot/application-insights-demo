using Microsoft.ApplicationInsights.Extensibility;
using Microsoft.Extensions.DependencyInjection;

namespace AggregateGroot.ApplicationInsightsDemo.Functions.Middleware.Telemetry
{
    /// <summary>
    /// Extension methods for adding telemetry to the Functions.
    /// </summary>
    public static class TelemetryExtensions
    {
        /// <summary>
        /// Adds Application Insights telemetry to the provided <paramref name="services"/>.
        /// </summary>
        /// <param name="services">
        /// Required <see cref="IServiceCollection"/> to add telemetry to.
        /// </param>
        /// <returns>
        /// The provided <paramref name="services"/> with Application Insights telemetry
        /// added.
        /// </returns>
        public static IServiceCollection AddTelemetry(this IServiceCollection services)
        {
            services.AddSingleton<ITelemetryInitializer, FunctionsTelemetryInitializer>();
            services.AddApplicationInsightsTelemetry();

            return services;
        }
    }
}