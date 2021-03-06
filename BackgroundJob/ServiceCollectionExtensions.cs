﻿using System;
using BackgroundJob;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Quartz;
using Quartz.Impl;
using Quartz.Spi;

namespace BackgroundJob
{
    public static class ServiceCollectionExtensions
    {
        public static ScheduledHostServiceBuilder AddScheduledHostedService(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.TryAddSingleton<IJobFactory, QuartzJobFactory>();
            services.TryAddSingleton<ISchedulerFactory, StdSchedulerFactory>();

            services.AddHostedService<ScheduledHostedService>();

            return new ScheduledHostServiceBuilder(services);
        }
    }
}
