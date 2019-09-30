using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Quartz;

namespace WebApi
{
    [DisallowConcurrentExecution]
    public class SingletonJob : IJob
    {
        private readonly ILogger<SingletonJob> _logger;
        public SingletonJob(ILogger<SingletonJob> logger)
        {
            _logger = logger;
        }

        public Task Execute(IJobExecutionContext context)
        {
            _logger.LogInformation("Cache is updated!" + DateTime.Now);
            return Task.CompletedTask;
        }
    }
}