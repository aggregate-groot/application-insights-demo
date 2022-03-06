using Microsoft.ApplicationInsights.Extensibility;
using Microsoft.Extensions.DependencyInjection;

namespace AggregateGroot.ApplicationInsightsDemo.Api.Middleware.Telemetry
{
    /// <summary>
    /// Extension methods for adding telemetry to the API.
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
            services.AddSingleton<ITelemetryInitializer, ApiTelemetryInitializer>();
            services.AddApplicationInsightsTelemetry();

            return services;
        }
    }
}