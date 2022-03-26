using System.Reflection;

using McMaster.Extensions.CommandLineUtils;

namespace AggregateGroot.ApplicationInsightsDemo.Client.Commands
{
    /// <summary>
    /// Represents the root command for the CLI.
    /// </summary>
    [Subcommand(typeof(SeedCommand))]
    public class RootCommand
    {
        /// <summary>
        /// Runs when this command is executed.
        /// </summary>
        /// <param name="application">
        /// Required command line application.
        /// </param>
        /// <param name="console">
        /// Required console.
        /// </param>
        private int OnExecute(CommandLineApplication application, IConsole console)
        {
            string versionNumber = Assembly
                .GetExecutingAssembly()
                .GetName()
                .Version?
                .ToString();

            console.WriteLine("-----------------------------------");
            console.WriteLine("Application Insights Demo Client.");
            console.WriteLine("Use -h for more help.");
            console.WriteLine("Version: " + versionNumber);
            console.WriteLine("-----------------------------------");

            application.ShowHelp();
            return 1;
        }
    }
}