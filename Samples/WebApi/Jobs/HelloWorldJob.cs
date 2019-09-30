using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Quartz;

namespace WebApi
{
    [DisallowConcurrentExecution]
    public class HelloWorldJob : IJob
    {
        private readonly ILogger<HelloWorldJob> _logger;
        public HelloWorldJob(ILogger<HelloWorldJob> logger)
        {
            _logger = logger;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            await Task.Delay(1000);
            _logger.LogInformation("Hello world!" + DateTime.Now);
        }

    }
}