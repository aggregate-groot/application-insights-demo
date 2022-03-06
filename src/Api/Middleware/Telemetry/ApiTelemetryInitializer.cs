using Microsoft.ApplicationInsights.Channel;
using Microsoft.ApplicationInsights.Extensibility;

namespace AggregateGroot.ApplicationInsightsDemo.Api.Middleware.Telemetry
{
    /// <summary>
    /// Represents a custom telemetry initialize to apply to the API.
    /// </summary>
    public class ApiTelemetryInitializer : ITelemetryInitializer
    {
        /// <inheritdoc />
        public void Initialize(ITelemetry telemetry)
        {
            telemetry.Context.Cloud.RoleName = "Whisky API";
        }
    }
}