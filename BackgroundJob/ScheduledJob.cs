using System;
using Microsoft.Extensions.DependencyInjection;

namespace BackgroundJob
{
    public class ScheduledJob
    {
        public ScheduledJob(Type type, string cronExpression, ServiceLifetime serviceLifetime)
        {
            Type = type;
            CronExpression = cronExpression;
            ServiceLifetime = serviceLifetime;
        }

        public ScheduledJob(Type type, string cronExpression, ServiceLifetime serviceLifetime, string description)
        : this(type, cronExpression, serviceLifetime)
        {
            Description = description;
        }

        public Type Type { get; }

        public string CronExpression { get; }

        public string Description { get; }

        public ServiceLifetime ServiceLifetime { get; }
    }
}
