using Microsoft.AspNetCore.Mvc;

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
    }
}