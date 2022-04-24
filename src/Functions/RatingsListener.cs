using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace AggregateGroot.ApplicationInsightsDemo.Functions
{
    /// <summary>
    /// Monitors the notify-rating service bus queue and processes the messages.
    /// </summary>
    public class RatingsListener
    {
        /// <summary>
        /// Executes the function.
        /// </summary>
        /// <param name="message">
        /// Required message to process.
        /// </param>
        /// <param name="log">
        /// Required logger.
        /// </param>
        [FunctionName("Function1")]
        public void Run(
            [ServiceBusTrigger(
                "notify-rating", 
                Connection = "Azure:ServiceBus:ConnectionString")]string message, 
            ILogger log)
        {
            log.LogInformation("Message processed.");
        }
    }
}