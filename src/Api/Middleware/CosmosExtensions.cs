using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using AggregateGroot.ApplicationInsightsDemo.Api.Infrastructure;

namespace AggregateGroot.ApplicationInsightsDemo.Api.Middleware
{
    /// <summary>
    /// Extension methods for adding Cosmos DB support to the API.
    /// </summary>
    public static class CosmosExtensions
    {
        /// <summary>
        /// Adds Cosmos DB to the provided <paramref name="services"/>.
        /// </summary>
        /// <param name="services">
        /// Required service collection to add Cosmos DB to.
        /// </param>
        /// <param name="configuration">
        /// Required configuration containing the information for connecting to Cosmos DB.
        /// </param>
        /// <returns>
        /// The provided <paramref name="services"/> with Cosmos DB support added..
        /// </returns>
        public static IServiceCollection AddCosmos(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            CosmosSettings cosmosSettings = new();
            configuration.Bind("Azure:Cosmos", cosmosSettings);
            CosmosClient cosmosClient = new(cosmosSettings.Endpoint, cosmosSettings.Key);

            services.AddSingleton(cosmosClient);

            return services;
        }
    }
}
