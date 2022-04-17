using System;
using System.Threading.Tasks;
using AggregateGroot.ApplicationInsightsDemo.Api.Models;
using McMaster.Extensions.CommandLineUtils;

namespace AggregateGroot.ApplicationInsightsDemo.Client.Commands
{
    /// <summary>
    /// Represents the command used to run a simulation against the API.
    /// </summary>
    [Command("run-simulation", Description = "Runs a simulation of the API.")]
    internal class RunSimulationCommand
    {
        /// <summary>
        /// Creates a new instance of the <see cref="RunSimulationCommand"/> class.
        /// </summary>
        /// <param name="console">
        /// Required type used to interact with the console.
        /// </param>
        /// <param name="apiClient">
        /// Required client used to interact with the API.
        /// </param>
        public RunSimulationCommand(IConsole console, IApiClient apiClient)
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
            _console.WriteLine("Running simulation...");

            for (int index = 0; index < 100; index++)
            {
                RatingModel rating = CreateRandomRating();

                _console.WriteLine($"[{index}]: Rating whisky {rating.WhiskyId} as {rating.Value}...");
                
                await _apiClient.AddRatingAsync(rating);
            }

            _console.WriteLine("Simulation complete.");

            return 1;
        }

        /// <summary>
        /// Creates a random rating.
        /// </summary>
        private RatingModel CreateRandomRating()
        {
            return new RatingModel
            {
                WhiskyId = WhiskyCollection.Random().Id,
                Value = new Random().Next(1, 5)
            };
        }

        private readonly IConsole _console;
        private readonly IApiClient _apiClient;
    }
}