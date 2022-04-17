using System.Collections.Generic;

using AggregateGroot.ApplicationInsightsDemo.Api.Models;

namespace AggregateGroot.ApplicationInsightsDemo.Client
{
    /// <summary>
    /// Represents a collection of whiskies.
    /// </summary>
    internal static class WhiskyCollection
    {
        /// <summary>
        /// Gets the collection of whiskies.
        /// </summary>
        public static IEnumerable<WhiskyModel> All()
        {
            return _whiskies;
        }

        /// <summary>
        /// Gets a random whisky from the collection.
        /// </summary>
        public static WhiskyModel Random()
        {

            return _whiskies[new System.Random().Next(_whiskies.Length)];
        }

        private static readonly WhiskyModel[] _whiskies = new[]
        {
            new WhiskyModel
            {
                Brand = "Glenlivet",
                Name = "The Glenlivet 18th Anniversary"
            },
            new WhiskyModel
            {
                Brand = "The Macallan",
                Name = "12 Year Old Sherry Cask"
            },
            new WhiskyModel
            {
                Brand = "The Macallan",
                Name = "The Harmony Collection"
            }
        };
    }
}