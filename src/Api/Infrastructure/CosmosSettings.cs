namespace AggregateGroot.ApplicationInsightsDemo.Api.Infrastructure
{
    /// <summary>
    /// Represents the settings required to connect to Azure Cosmos DB.
    /// </summary>
    public record CosmosSettings
    {
        /// <summary>
        /// Creates a new instance of <see cref="CosmosSettings"/> class.
        /// </summary>
        public CosmosSettings()
        {
            Endpoint = string.Empty;
            Key = string.Empty;
        }

        /// <summary>
        /// Gets the endpoint for the Cosmos DB instance.
        /// </summary>
        public string Endpoint { get; init; }

        /// <summary>
        /// Gets the secret key used to connect to the Cosmos DB instance.
        /// </summary>
        public string Key { get; init; }
    }
}
