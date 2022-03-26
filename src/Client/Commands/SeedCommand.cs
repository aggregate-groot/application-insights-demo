using System.Threading.Tasks;

using McMaster.Extensions.CommandLineUtils;

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
        public SeedCommand()
        {

        }
        
        /// <summary>
        /// Runs when the command executes.
        /// </summary>
        /// <param name="application">
        /// Required current command line application.
        /// </param>
        public async Task<int> OnExecuteAsync(CommandLineApplication application)
        {
            
            return 1;
        }

    }
}