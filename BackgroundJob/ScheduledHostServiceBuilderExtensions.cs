using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace BackgroundJob
{
    public static class ScheduledHostServiceBuilderExtensions
    {
        public static ScheduledHostServiceBuilder AddJob(this ScheduledHostServiceBuilder builder, Type type, string cronExpression, ServiceLifetime serviceLifetime,
            string description = null)
        {
            if (builder == null) throw new ArgumentNullException(nameof(builder));

            builder.Services.Add(new ServiceDescriptor(type, type, serviceLifetime));
            builder.Services.AddSingleton(new ScheduledJob(type, cronExpression, serviceLifetime, description));
            
            return builder;
        }

        public static ScheduledHostServiceBuilder AddJob(this ScheduledHostServiceBuilder builder, params ScheduledJob[] jobs)
        {
            if (builder == null) throw new ArgumentNullException(nameof(builder));

            builder.Services.Add(jobs.Select(job => new ServiceDescriptor(job.Type, job.Type, job.ServiceLifetime)));
            jobs.ToList().ForEach(job => builder.Services.AddSingleton(job));

            return builder;
        }
    }
}