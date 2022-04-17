using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Cosmos;

using AggregateGroot.ApplicationInsightsDemo.Api.Models;
using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.DataContracts;

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
        public RatingsController(CosmosClient cosmosClient, TelemetryClient telemetryClient)
        {
            _cosmosClient = cosmosClient;
            _telemetryClient = telemetryClient;
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

            _telemetryClient.TrackEvent("Rating Added", new Dictionary<string, string>
            {
                { "Rating", rating.Value.ToString() },
                { "WhiskyId", rating.WhiskyId }
            });

            _telemetryClient.TrackMetric("Whisky Rating", rating.Value);

            return Ok();
        }

        private readonly CosmosClient _cosmosClient;
        private readonly TelemetryClient _telemetryClient;
    }
}