using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Quartz;

namespace WebApi
{
    [DisallowConcurrentExecution]
    public class CacheUpdateJob : IJob
    {
        private readonly ILogger<CacheUpdateJob> _logger;
        public CacheUpdateJob(ILogger<CacheUpdateJob> logger)
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