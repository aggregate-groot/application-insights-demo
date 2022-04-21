using System;

using Azure.Messaging.ServiceBus;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AggregateGroot.ApplicationInsightsDemo.Api.Middleware
{
    /// <summary>
    /// Extension methods to add Azure Service Bus support to the application.
    /// </summary>
    public static class ServiceBusExtensions
    {
        /// <summary>
        /// Adds Azure Service Bus support to the provided <paramref name="services"/>.
        /// </summary>
        /// <param name="services">
        /// Required service collection to add Azure Service Bus support to.
        /// </param>
        /// <param name="configuration">
        /// Required configuration containing the information for connecting to
        /// the Azure Service Bus instance.
        /// </param>
        /// <returns>
        /// The provided <paramref name="services"/> with Azure Service Bus support added.
        /// </returns>
        public static IServiceCollection AddAzureServiceBus(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            ServiceBusClient client = new(
                configuration["Azure:ServiceBus:ConnectionString"]);

            services.AddSingleton(client);

            return services;
        }
    }
}