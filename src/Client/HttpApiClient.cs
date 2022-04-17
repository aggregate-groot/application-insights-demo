using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

using AggregateGroot.ApplicationInsightsDemo.Api.Models;

namespace AggregateGroot.ApplicationInsightsDemo.Client
{
    /// <summary>
    /// HTTP implementation of the <see cref="IApiClient"/> interface.
    /// </summary>
    internal class HttpApiClient : IApiClient
    {
        /// <summary>
        /// Creates a new instance of the <see cref="HttpApiClient"/> class.
        /// </summary>
        /// <param name="httpClient">
        /// Required HTTP client.
        /// </param>
        public HttpApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient 
                ?? throw new ArgumentNullException(nameof(httpClient));
        }

        /// <inheritdoc />
        public async Task AddWhiskyAsync(WhiskyModel whisky)
        {
            await _httpClient.PostAsJsonAsync("api/whiskies", whisky);
        }

        
        /// <inheritdoc />
        public async Task AddRatingAsync(RatingModel rating)
        {
            await _httpClient.PostAsJsonAsync("api/ratings", rating);
        }

        private readonly HttpClient _httpClient;
    }
}