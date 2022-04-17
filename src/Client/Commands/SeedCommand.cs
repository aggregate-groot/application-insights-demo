using System;
using System.Threading.Tasks;

using McMaster.Extensions.CommandLineUtils;

using AggregateGroot.ApplicationInsightsDemo.Api.Models;

namespace AggregateGroot.ApplicationInsightsDemo.Client.Commands
{
    /// <summary>
    /// Represents the command used to seed the API with data.
    /// </summary>
    [Command("seed", Description = "Seeds the API with data.")]
    internal class SeedCommand
    {
        /// <summary>
        /// Creates a new instance of the <see cref="SeedCommand"/> class.
        /// </summary>
        /// <param name="console"></param>
        /// <param name="apiClient">
        /// Required client used to interact with the API.
        /// </param>
        public SeedCommand(IConsole console, IApiClient apiClient)
        {
            _console = console 
                ?? throw new ArgumentNullException(nameof(console));
            _apiClient = apiClient 
                ?? throw new ArgumentNullException(nameof(apiClient));
        }

        /// <summary>
        /// Runs when the command executes.
        /// </summary>
        /// <param name="application">
        /// Required current command line application.
        /// </param>
        public async Task<int> OnExecuteAsync(CommandLineApplication application)
        {
            _console.WriteLine("Seeding the API with whiskies...");
            
            foreach (WhiskyModel whisky in WhiskyCollection.All())
            {
                await _apiClient.AddWhiskyAsync(whisky);
            }

            _console.WriteLine("Seeding complete.");

            return 1;
        }

        private readonly IConsole _console;
        private readonly IApiClient _apiClient;
    }
}