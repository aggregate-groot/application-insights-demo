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

        /// <summary>
        /// Adds a new rating for a whisky.
        /// </summary>
        /// <param name="rating">
        /// Required rating to add.
        /// </param>
        Task AddRatingAsync(RatingModel rating);
    }
}