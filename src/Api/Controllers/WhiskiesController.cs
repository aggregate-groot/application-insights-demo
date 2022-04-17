using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Cosmos;

using AggregateGroot.ApplicationInsightsDemo.Api.Models;

namespace AggregateGroot.ApplicationInsightsDemo.Api.Controllers
{
    /// <summary>
    /// Manages the whisky endpoints.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class WhiskiesController : ControllerBase
    {
        /// <summary>
        /// Creates a new instance of the <see cref="WhiskiesController"/> class.
        /// </summary>
        public WhiskiesController(CosmosClient cosmosClient)
        {
            _cosmosClient = cosmosClient;
        }

        /// <summary>
        /// Lists the available whiskies.
        /// </summary>
        [HttpGet]
        public IActionResult List()
        {
            return Ok();
        }

        /// <summary>
        /// Adds the provided <paramref name="whisky"/> to the list of whiskies.
        /// </summary>
        /// <param name="whisky">
        /// Required whisky to add.
        /// </param>
        [HttpPost]
        public async Task<IActionResult> Add(WhiskyModel whisky)
        {
            Container container = _cosmosClient.GetContainer("ApplicationInsightsDemo", "Whiskies");
            await container.CreateItemAsync(whisky);

            return Ok();
        }

        private readonly CosmosClient _cosmosClient;
    }
}