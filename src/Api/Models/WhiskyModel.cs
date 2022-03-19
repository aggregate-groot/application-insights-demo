using Newtonsoft.Json;

namespace AggregateGroot.ApplicationInsightsDemo.Api.Models
{
    /// <summary>
    /// Represents a whisky.
    /// </summary>
    public record WhiskyModel
    {
        /// <summary>
        /// Creates a new instance of the <see cref="WhiskyModel"/> class.
        /// </summary>
        public WhiskyModel()
        {
            Name = string.Empty;
            Brand = string.Empty;
        }

        /// <summary>
        /// Gets the unique identifier for the whisky.
        /// </summary>
        [JsonProperty("id")]
        public string Id => $"{Brand}-{Name}";

        /// <summary>
        /// Gets or initializes the name of the whisky.
        /// </summary>
        public string Name { get; init; }

        /// <summary>
		/// Gets or initializes the brand of the whisky.
		/// </summary>
		public string Brand { get; init; }
    }
}