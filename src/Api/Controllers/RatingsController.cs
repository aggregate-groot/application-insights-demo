using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Cosmos;

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
        public RatingsController(CosmosClient cosmosClient)
        {
            _cosmosClient = cosmosClient;
        }

        /// <summary>
        /// Adds the provided <paramref name="rating"/>.
        /// </summary>
        /// <param name="rating">
        /// Required rating to add.
        /// </param>
        public async Task<IActionResult> Add(RatingModel rating)
        {
            Container container = _cosmosClient.GetContainer("ApplicationInsightsDemo", "Ratings");
            await container.CreateItemAsync(rating);

            return Ok();
        }

        private readonly CosmosClient _cosmosClient;
    }
}