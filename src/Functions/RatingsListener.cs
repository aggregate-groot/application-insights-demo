using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace Functions
{
    public class RatingsListener
    {
        [FunctionName("Function1")]
        public void Run(
            [ServiceBusTrigger(
                "notify-rating", 
                Connection = "Azure:ServiceBus:ConnectionString")]string myQueueItem, 
            ILogger log)
        {
            
        }
    }
}