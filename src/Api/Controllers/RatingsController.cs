using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

using Azure.Messaging.ServiceBus;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Cosmos;
using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.DataContracts;

using AggregateGroot.ApplicationInsightsDemo.Api.Models;

namespace AggregateGroot.ApplicationInsightsDemo.Api.Controllers
{
    /// <summary>
    /// Manages the ratings endpoints.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class RatingsController : ControllerBase
    {
        /// <summary>
        /// Creates a new instance of the <see cref="RatingsController"/> class.
        /// </summary>
        public RatingsController(
            CosmosClient cosmosClient, 
            TelemetryClient telemetryClient,
            ServiceBusClient serviceBusClient)
        {
            _cosmosClient = cosmosClient;
            _telemetryClient = telemetryClient;
            _serviceBusClient = serviceBusClient;
        }

        /// <summary>
        /// Adds the provided <paramref name="rating"/>.
        /// </summary>
        /// <param name="rating">
        /// Required rating to add.
        /// </param>
        [HttpPost]
        public async Task<IActionResult> Add(RatingModel rating)
        {
            int randomDelay = new System.Random().Next(0, 3000);
            await Task.Delay(randomDelay);
            
            using (var operation = _telemetryClient.StartOperation<DependencyTelemetry>("Create Ratings Document"))
            {
                operation.Telemetry.Type = "CosmosDB";
                
                Container container = _cosmosClient.GetContainer("ApplicationInsightsDemo", "Ratings");
                await container.CreateItemAsync(rating);
            }

            TrackEvents(rating);

            TrackMetrics(rating);

            await PublishMessageAsync(rating);

            return Ok();
        }

        /// <summary>
        /// Tracks the custom metrics to Application Insights.
        /// </summary>
        /// <param name="rating">
        /// Required rating containing the values to use for the metrics.
        /// </param>
        private void TrackMetrics(RatingModel rating)
        {
            _telemetryClient.TrackMetric("Whisky Rating", rating.Value);
        }

        /// <summary>
        /// Tracks the custom events to Application Insights.
        /// </summary>
        /// <param name="rating">
        /// Required rating containing the event data.
        /// </param>
        private void TrackEvents(RatingModel rating)
        {
            _telemetryClient.TrackEvent("Rating Added", new Dictionary<string, string>
            {
                { "Rating", rating.Value.ToString() },
                { "WhiskyId", rating.WhiskyId }
            });
        }

        /// <summary>
        /// Publishes a message to the service bus indicating that a rating has
        /// been submitted.
        /// </summary>
        /// <param name="rating">
        /// Required rating containing the data to use in the service bus message.
        /// </param>
        private Task PublishMessageAsync(RatingModel rating)
        {
            ServiceBusSender? sender = _serviceBusClient.CreateSender("notify-rating");
            ServiceBusMessage message = new(JsonSerializer.Serialize(rating));

            return sender.SendMessageAsync(message);
        }

        private readonly CosmosClient _cosmosClient;
        private readonly TelemetryClient _telemetryClient;
        private readonly ServiceBusClient _serviceBusClient;
    }
}