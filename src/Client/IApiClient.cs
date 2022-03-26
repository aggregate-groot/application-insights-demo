using System.Threading.Tasks;
using AggregateGroot.ApplicationInsightsDemo.Api.Models;

namespace AggregateGroot.ApplicationInsightsDemo.Client
{
    /// <summary>
    /// Interface for types that can be used to invoke the API.
    /// </summary>
    internal interface IApiClient
    {
        /// <summary>
        /// Adds a new whisky.
        /// </summary>
        /// <param name="whisky">
        /// Required whisky to add.
        /// </param>
        Task AddWhiskyAsync(WhiskyModel whisky);
    }
}