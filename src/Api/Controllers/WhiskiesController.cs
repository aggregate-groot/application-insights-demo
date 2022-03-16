using Microsoft.AspNetCore.Mvc;

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
        public IActionResult Add(WhiskyModel whisky)
        {
            return Ok();
        }
    }
}