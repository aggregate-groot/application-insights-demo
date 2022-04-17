using System;

using Newtonsoft.Json;

namespace AggregateGroot.ApplicationInsightsDemo.Api.Models
{
    /// <summary>
    /// Represents a whisky rating.
    /// </summary>
    public record RatingModel
    {
        /// <summary>
        /// Creates a new instance of the <see cref="RatingModel"/> class.
        /// </summary>
        public RatingModel()
        {
            WhiskyId = string.Empty;
            Value = 0;
        }
        
        /// <summary>
        /// Gets the unique identifier for the whisky.
        /// </summary>
        [JsonProperty("id")]
        public string Id => Guid.NewGuid().ToString();

        /// <summary>
		/// Gets or initializes the unique identifier of the whisky being rated.
		/// </summary>
		public string WhiskyId { get; init; }

        /// <summary>
		/// Gets or initializes the value of the whisky rating.
		/// </summary>
		public int Value { get; init; }
    }
}