using Microsoft.ApplicationInsights.Channel;
using Microsoft.ApplicationInsights.Extensibility;

namespace AggregateGroot.ApplicationInsightsDemo.Functions.Middleware.Telemetry
{
    /// <summary>
    /// Represents a custom telemetry initialize to apply to the Functions.
    /// </summary>
    public class FunctionsTelemetryInitializer : ITelemetryInitializer
    {
        /// <inheritdoc />
        public void Initialize(ITelemetry telemetry)
        {
            telemetry.Context.Cloud.RoleName = "Whisky Functions";
        }
    }
}